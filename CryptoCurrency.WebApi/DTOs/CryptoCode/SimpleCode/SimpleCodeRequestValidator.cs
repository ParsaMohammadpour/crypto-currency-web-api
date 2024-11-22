using FluentValidation;

namespace CryptoCurrency.WebApi.DTOs.CryptoCode.SimpleCode;

public class SimpleCodeRequestValidator :  AbstractValidator<SimpleCodeRequestModel>
{
    public SimpleCodeRequestValidator()
    {
        Include(new BaseCryptoCodeRequestModelValidator());
    }
}