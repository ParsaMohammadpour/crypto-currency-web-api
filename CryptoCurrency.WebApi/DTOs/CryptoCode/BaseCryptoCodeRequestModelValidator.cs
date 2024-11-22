using FluentValidation;

namespace CryptoCurrency.WebApi.DTOs.CryptoCode;

public class BaseCryptoCodeRequestModelValidator : AbstractValidator<BaseCryptoCodeRequestModel>
{
    public BaseCryptoCodeRequestModelValidator()
    {
        RuleFor(m => m.Code)
            .NotNull().WithMessage("Code can't be null")
            .NotEmpty().WithMessage("Code can't be empty")
            .Must(m => m != null && m.All(c => !char.IsWhiteSpace(c))).WithMessage("Code can't contain whitespace");
    }
}
