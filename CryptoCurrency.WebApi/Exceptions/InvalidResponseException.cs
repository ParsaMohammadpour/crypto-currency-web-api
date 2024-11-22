namespace CryptoCurrency.WebApi.Exceptions;

public class InvalidResponseException : HttpRequestException
{
    public InvalidResponseException() : base("Invalid external service response")
    {
    }

    public InvalidResponseException(string message) : base(message)
    {
    }
}
