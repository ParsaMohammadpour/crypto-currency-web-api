namespace CryptoCurrency.WebApi.Configurations;

public interface ICoinMarketCapConfig
{
    string BaseAddress { get; }
    string CryptoCurrencyUrl { get; }
    string ApiKey { get; }
    string ConvertToCurrencies { get; }
    int TimeOut { get; }
}

public class CoinMarketCapConfig : ICoinMarketCapConfig
{
    public static string AppSettingName { get; private set; } = "CoinMarketCap";
    public string BaseAddress { get; set; }
    public string CryptoCurrencyUrl { get; set; }

    [ConfigurationKeyName("Api_Key")]
    public string ApiKey { get; set; }

    [ConfigurationKeyName("Convert_To_Currencies")]
    public string ConvertToCurrencies { get; set; }

    public int TimeOut { get; set; }
}