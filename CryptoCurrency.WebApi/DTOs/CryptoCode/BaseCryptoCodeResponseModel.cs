namespace CryptoCurrency.WebApi.DTOs.CryptoCode;

/// <summary>
/// base response model for CryptoCodeResponseModel
/// </summary>
public abstract record BaseCryptoCodeResponseModel
{
    public string Symbol { get; set; }
    public DateTime? LastUpdate { get; set; }
    public string? Name { get; set; }
    public Currency USD { get; set; }
    public Currency EUR { get; set; }
    public Currency BRL { get; set; }
    public Currency GBP { get; set; }
    public Currency AUD { get; set; }
}

/// <summary>
/// Data holder dto for each currency
/// </summary>
public record Currency
{
    public Currency()
    {
    }
    public Currency(Services.CoinMarketCap.Models.Currency cur)
    {
        Price = cur.Price;
        Volume24H = cur.Volume24H;
        VolumeChange24H = cur.VolumeChange24H;
        PercentChange1H = cur.PercentChange1H;
        PercentChange24H = cur.PercentChange24H;
        PercentChange7D = cur.PercentChange7D;
        PercentChange30D = cur.PercentChange30D;
        MarketCap = cur.MarketCap;
        MarketCapDominance = cur.MarketCapDominance;
        FullyDilutedMarketCap = cur.FullyDilutedMarketCap;
        LastUpdated = cur.LastUpdated;
    }

    public double Price { get; set; }

    public double Volume24H { get; set; }

    public double VolumeChange24H { get; set; }

    public double PercentChange1H { get; set; }

    public double PercentChange24H { get; set; }

    public double PercentChange7D { get; set; }

    public double PercentChange30D { get; set; }

    public double MarketCap { get; set; }

    public long MarketCapDominance { get; set; }

    public double FullyDilutedMarketCap { get; set; }

    public DateTimeOffset? LastUpdated { get; set; }
}
