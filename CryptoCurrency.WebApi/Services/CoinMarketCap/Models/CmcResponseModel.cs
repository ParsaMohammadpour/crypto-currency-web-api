using Newtonsoft.Json;

namespace CryptoCurrency.WebApi.Services.CoinMarketCap.Models;

public class CmcResponseModel
{
    [JsonProperty("status")]
    public Status Status { get; set; }

    [JsonProperty("data")]
    public Data Data { get; set; }
}

public class Data
{
    [JsonProperty("Crypto")]
    public List<Crypto> Crypto { get; set; }
}

public class Crypto
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("is_active")]
    public long IsActive { get; set; }

    [JsonProperty("is_fiat")]
    public object IsFiat { get; set; }

    [JsonProperty("circulating_supply")]
    public long CirculatingSupply { get; set; }

    [JsonProperty("total_supply")]
    public long TotalSupply { get; set; }

    [JsonProperty("max_supply")]
    public long MaxSupply { get; set; }

    [JsonProperty("date_added")]
    public DateTime? DateAdded { get; set; }

    [JsonProperty("num_market_pairs")]
    public long NumMarketPairs { get; set; }

    [JsonProperty("cmc_rank")]
    public long CmcRank { get; set; }

    [JsonProperty("last_updated")]
    public DateTime? LastUpdated { get; set; }

    [JsonProperty("tags")]
    public string[] Tags { get; set; }

    [JsonProperty("platform")]
    public object Platform { get; set; }

    [JsonProperty("self_reported_circulating_supply")]
    public object SelfReportedCirculatingSupply { get; set; }

    [JsonProperty("self_reported_market_cap")]
    public object SelfReportedMarketCap { get; set; }

    [JsonProperty("quote")]
    public Quote Quote { get; set; }
}

public class Quote
{
    [JsonProperty("AUD")]
    public Currency Aud { get; set; }

    [JsonProperty("BRL")]
    public Currency Brl { get; set; }

    [JsonProperty("EUR")]
    public Currency Eur { get; set; }

    [JsonProperty("GBP")]
    public Currency Gbp { get; set; }

    [JsonProperty("USD")]
    public Currency Usd { get; set; }
}

public class Currency
{
    [JsonProperty("price")]
    public double Price { get; set; }

    [JsonProperty("volume_24h")]
    public double Volume24H { get; set; }

    [JsonProperty("volume_change_24h")]
    public double VolumeChange24H { get; set; }

    [JsonProperty("percent_change_1h")]
    public double PercentChange1H { get; set; }

    [JsonProperty("percent_change_24h")]
    public double PercentChange24H { get; set; }

    [JsonProperty("percent_change_7d")]
    public double PercentChange7D { get; set; }

    [JsonProperty("percent_change_30d")]
    public double PercentChange30D { get; set; }

    [JsonProperty("market_cap")]
    public double MarketCap { get; set; }

    [JsonProperty("market_cap_dominance")]
    public long MarketCapDominance { get; set; }

    [JsonProperty("fully_diluted_market_cap")]
    public double FullyDilutedMarketCap { get; set; }

    [JsonProperty("last_updated")]
    public DateTimeOffset? LastUpdated { get; set; }
}

public class Status
{
    [JsonProperty("timestamp")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonProperty("error_code")]
    public long ErrorCode { get; set; }

    [JsonProperty("error_message")]
    public object ErrorMessage { get; set; }

    [JsonProperty("elapsed")]
    public long Elapsed { get; set; }

    [JsonProperty("credit_count")]
    public long CreditCount { get; set; }

    [JsonProperty("notice")]
    public object Notice { get; set; }
}