namespace CryptoCurrency.WebApi.Extensions;

public static class HttpContextExtensions
{
    public static string GetIp(this HttpContext context) 
        => context.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
}