using CryptoCurrency.WebApi.Services.CoinMarketCap.Models;

namespace CryptoCurrency.WebApi.DTOs.CryptoCode.SimpleCode;

public record SimpleCodeResponseModel : BaseCryptoCodeResponseModel
{
    public SimpleCodeResponseModel()
    {
    }
    public SimpleCodeResponseModel(CmcResponseModel response)
    {
        LastUpdate = response.Data.Crypto![0].LastUpdated;
        Symbol = response.Data.Crypto[0].Symbol;
        Name = response.Data.Crypto[0].Name;
        AUD = new Currency(response.Data.Crypto[0].Quote.Aud);
        BRL = new Currency(response.Data.Crypto[0].Quote.Brl);
        EUR = new Currency(response.Data.Crypto[0].Quote.Eur);
        GBP = new Currency(response.Data.Crypto[0].Quote.Gbp);
        USD = new Currency(response.Data.Crypto[0].Quote.Usd);
    }
}
