namespace CryptoCurrency.WebApi.Services.HttpClients.CoinMarketCap.Models;

public record CmcResponseModel
{
    public Status status { get; set; }
    public Data data { get; set; }
}

public record Status
{
    public DateTime timestamp { get; set; }
    public long error_code { get; set; }
    public object error_message { get; set; }
    public long elapsed { get; set; }
    public long credit_count { get; set; }
    public object notice { get; set; }
}

public record Data
{
    public List<Crypto> Crypto { get; set; }
}

public record Currency
{
    public double price { get; set; }
    public double volume_24h { get; set; }
    public double volume_change_24h { get; set; }
    public double percent_change_1h { get; set; }
    public double percent_change_24h { get; set; }
    public double percent_change_7d { get; set; }
    public double percent_change_30d { get; set; }
    public double market_cap { get; set; }
    public long market_cap_dominance { get; set; }
    public double fully_diluted_market_cap { get; set; }
    public DateTime last_updated { get; set; }
}

public record Crypto
{
    public long id { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }
    public string slug { get; set; }
    public long is_active { get; set; }
    public object is_fiat { get; set; }
    public long circulating_supply { get; set; }
    public long total_supply { get; set; }
    public long max_supply { get; set; }
    public DateTime date_added { get; set; }
    public long num_market_pairs { get; set; }
    public long cmc_rank { get; set; }
    public DateTime last_updated { get; set; }
    public List<string> tags { get; set; }
    public object platform { get; set; }
    public object self_reported_circulating_supply { get; set; }
    public object self_reported_market_cap { get; set; }
    public Currency AUD { get; set; }
    public Currency BRL { get; set; }
    public Currency EUR { get; set; }
    public Currency GBP { get; set; }
    public Currency USD { get; set; }
}
