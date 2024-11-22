using CryptoCurrency.WebApi.Services.CoinMarketCap;
using Polly;

namespace CryptoCurrency.WebApi.Configurations;

public static class HttpClientConfig
{
    public static IHttpClientBuilder ConfigCmcHttpClient(this IServiceCollection service, ICoinMarketCapConfig config)
    {
        return service.AddHttpClient<ICmcServices, CmcServices>(o =>
        {
            var url = new UriBuilder(config.BaseAddress);
            o.BaseAddress = url.Uri;

            o.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", config.ApiKey);
            o.DefaultRequestHeaders.Add("Accepts", "application/json");
        }).SetHandlerLifetime(TimeSpan.FromSeconds(config.TimeOut))
            .AddTransientHttpErrorPolicy(builder =>
            builder.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3),
                TimeSpan.FromSeconds(4),
                TimeSpan.FromSeconds(5),
            }));
    }
}
