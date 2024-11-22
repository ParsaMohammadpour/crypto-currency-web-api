using CryptoCurrency.WebApi.Configurations;
using CryptoCurrency.WebApi.Services.HttpClients.CoinMarketCap.Models;
using System.Text.Json;
using System.Web;

namespace CryptoCurrency.WebApi.Services.HttpClients.CoinMarketCap;

public class CmcHttpClientService(HttpClient client, ICoinMarketCapConfig config, ILogger<CmcHttpClientService> logger)
    : ICmcHttpClientService
{
    private readonly UriBuilder _urlBuilder = new UriBuilder(config.Url);

    private void AddQueryStringsToUrl(string symbol)
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["symbol"] = symbol;
        queryString["convert"] = config.ConvertToCurrencies;

        _urlBuilder.Query = queryString.ToString();
    }

    private void AddClientHeaders()
    {
        client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", config.ApiKey);
        client.DefaultRequestHeaders.Add("Accepts", "application/json");
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

    public async Task<CmcResponseModel> GetCryptoLatestAsync(string symbol, CancellationToken ct = default)
    {
        AddQueryStringsToUrl(symbol);

        AddClientHeaders();

        var res = await client.GetAsync(_urlBuilder.ToString(), ct) ??
                  throw new NullReferenceException("Response is null");

        var resStr = await res.Content.ReadAsStringAsync(ct) ??
                     throw new NullReferenceException("ResponseMessage is null");

        var formattedRes = FormatJsonString(resStr, symbol);

        var resObj = JsonSerializer.Deserialize<CmcResponseModel>(resStr);

        if (resObj is null)
            throw new NullReferenceException("Result object is null");

        return resObj;
    }
}