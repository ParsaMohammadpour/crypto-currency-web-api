using CryptoCurrency.WebApi.DTOs.CryptoCode.SimpleCode;

namespace CryptoCurrency.UnitTest.ValidatorTest;

public class RequestModelValidationTest
{
    [Theory]
    [InlineData("BTC")]
    [InlineData("ETH")]
    [InlineData("SomeOtherThing")]
    [InlineData("Input")]
    public void ValidRequestInput_Valid(string code)
    {
        // Arrange
        var req = new SimpleCodeRequestModel(code);

        // Act
        var validator = new SimpleCodeRequestValidator();
        var validation = validator.Validate(req);

        // Assert
        Assert.True(validation.IsValid);
        Assert.Empty(validation.Errors);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Bit Coin")]
    [InlineData("Some Thing With whitespace")]
    [InlineData("Some Thing \t With whitespace\n")]
    public void ValidRequestInput_Invalid(string code)
    {
        // Arrange
        var req = new SimpleCodeRequestModel(code);

        // Act
        var validator = new SimpleCodeRequestValidator();
        var validation = validator.Validate(req);

        // Assert
        Assert.False(validation.IsValid);
        Assert.NotEmpty(validation.Errors);
    }
}