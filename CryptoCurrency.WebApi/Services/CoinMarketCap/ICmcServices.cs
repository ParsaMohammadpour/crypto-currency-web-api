using CryptoCurrency.WebApi.DTOs.CryptoCode.SimpleCode;
using FluentResults;

namespace CryptoCurrency.WebApi.Services.CoinMarketCap;

public interface ICmcServices
{
    Task<Result<SimpleCodeResponseModel>> SimpleCode(SimpleCodeRequestModel request, CancellationToken ct);
}
