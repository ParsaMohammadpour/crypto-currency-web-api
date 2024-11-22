using CryptoCurrency.WebApi.DTOs.CryptoCode.SimpleCode;
using CryptoCurrency.WebApi.Exceptions;
using FluentResults;
using System.Text.Json;
using System.Web;
using CryptoCurrency.WebApi.Configurations;
using CryptoCurrency.WebApi.Services.CoinMarketCap.Models;
using Newtonsoft.Json;

namespace CryptoCurrency.WebApi.Services.CoinMarketCap;

public class CmcServices(HttpClient httpClient, ICoinMarketCapConfig config) : ICmcServices
{
    private string GetUrl(string symbol)
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["symbol"] = symbol;
        queryString["convert"] = config.ConvertToCurrencies;

        return config.CryptoCurrencyUrl + "?" + queryString;
    }

    /// <summary>
    /// Replacing symbol appearance with Crypto in order to be able to deserialize json string to the object
    /// </summary>
    /// <param name="jsonStr"></param>
    /// <param name="symbol"></param>
    /// <returns>correct format of json string</returns>
    private string FormatJsonString(string jsonStr, string symbol)
    {
        // The api returns the symbol as the property name of json object, so we replace this symbol
        // with the Crypto and also set the Crypto name in the CmcResponseModel.cs class
        var invalidStr = "\"data\":{\"" + $"{symbol}" + "\":";
        const string validStr = "\"data\":{\"Crypto\":";
        var resStr = jsonStr.Replace(invalidStr, validStr);
        return resStr;
    }

    private Result<SimpleCodeResponseModel> GenerateResult(CmcResponseModel response)
    {
        if (response is null)
            throw new InvalidResponseException("Result object is null");

        if (response.Data?.Crypto is null || response.Data.Crypto.Count == 0)
            return Result.Fail("Crypto not found");

        var res = new SimpleCodeResponseModel(response);

        return Result.Ok(res);
    }

    public async Task<Result<SimpleCodeResponseModel>> SimpleCode(SimpleCodeRequestModel request, CancellationToken ct = default)
    {
        var url = GetUrl(request.Code);
        var res = await httpClient.GetStringAsync(url, ct) ??
                  throw new InvalidResponseException("Response message is null");

        var formattedRes = FormatJsonString(res, request.Code);

        var resObj = JsonConvert.DeserializeObject<CmcResponseModel>(formattedRes);

        return GenerateResult(resObj);
    }
}
