namespace CryptoCurrency.WebApi.Configurations;

public interface ICoinMarketCapConfig
{
    string Url { get; }
    string ApiKey { get; }
    string ConvertToCurrencies { get; }
}

public class CoinMarketCapConfig : ICoinMarketCapConfig
{
    public static string AppSettingName { get; private set; } = "CoinMarketCap";
    public string Url { get; set; }

    [ConfigurationKeyName("Api_Key")]
    public string ApiKey { get; set; }

    [ConfigurationKeyName("Convert_To_Currencies")]
    public string ConvertToCurrencies { get; set; }
}