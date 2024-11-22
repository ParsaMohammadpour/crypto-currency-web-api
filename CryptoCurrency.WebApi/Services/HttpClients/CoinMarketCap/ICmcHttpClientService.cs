using CryptoCurrency.WebApi.Services.HttpClients.CoinMarketCap.Models;

namespace CryptoCurrency.WebApi.Services.HttpClients.CoinMarketCap;

public interface ICmcHttpClientService
{
    /// <summary>
    /// getting result of calling https://sandbox-api.coinmarketcap.com/v2/cryptocurrency/quotes/latest api
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<CmcResponseModel> GetCryptoLatestAsync(string symbol, CancellationToken ct = default);
}