using CryptoCurrency.WebApi.Controllers;
using CryptoCurrency.WebApi.DTOs.CryptoCode;
using CryptoCurrency.WebApi.DTOs.CryptoCode.SimpleCode;
using CryptoCurrency.WebApi.Services.CoinMarketCap;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CryptoCurrency.UnitTest.Controller;

public class CryptoCode
{
    private readonly Mock<ICmcServices> _cmcService;

    public CryptoCode()
    {
        _cmcService = new Mock<ICmcServices>();
    }


    [Theory]
    [InlineData("BTC")]
    [InlineData("ETH")]
    [InlineData("ABC")]
    public async Task GetCmcResponse_Success(string code)
    {
        // Arrange
        var reqModel = new SimpleCodeRequestModel(code);
        var cryptoRes = GetCmcServiceSuccessData(code);
        _cmcService.Setup(x => x.SimpleCode(reqModel, CancellationToken.None))
            .Returns(Task.FromResult(cryptoRes));

        // Act
        var cryptoCodeController = new CryptoCodeController(_cmcService.Object);
        var response = await cryptoCodeController.Get(reqModel, CancellationToken.None);
        var okObjectResult = response.Result as OkObjectResult;
        var res = okObjectResult.Value as SimpleCodeResponseModel;

        //Assert
        Assert.NotNull(okObjectResult);
        Assert.NotNull(response);
        Assert.NotNull(res);
        Assert.True(res.Symbol == cryptoRes.Value.Symbol);
        Assert.True(res.Name == cryptoRes.Value.Name);
        Assert.True(res.LastUpdate == cryptoRes.Value.LastUpdate);
        Assert.True(res.EUR == cryptoRes.Value.EUR);
        Assert.True(res.GBP == cryptoRes.Value.GBP);
        Assert.True(res.AUD == cryptoRes.Value.AUD);
        Assert.True(res.BRL == cryptoRes.Value.BRL);
        Assert.True(res.USD == cryptoRes.Value.USD);
        Assert.True(res == cryptoRes.Value);
    }


    [Theory]
    [InlineData("BTC", "Not crypto found")]
    [InlineData("ETH", "Internal server error")]
    [InlineData("ABC", "Internal server error")]
    public async Task GetCmcResponse_Failure(string code, string error)
    {
        // Arrange
        var reqModel = new SimpleCodeRequestModel(code);
        var cryptoRes = GetCmcServiceFailureData(error);
        _cmcService.Setup(x => x.SimpleCode(reqModel, CancellationToken.None))
            .Returns(Task.FromResult(cryptoRes));

        // Act
        var cryptoCodeController = new CryptoCodeController(_cmcService.Object);
        var response = await cryptoCodeController.Get(reqModel, CancellationToken.None);
        var badObjectRes = response.Result as BadRequestObjectResult;
        var errorMsgs = badObjectRes.Value as ICollection<IError>;
        var errorMsgStr = errorMsgs?.FirstOrDefault()?.Message;

        //Assert
        Assert.NotNull(badObjectRes);
        Assert.NotNull(response);
        Assert.NotNull(errorMsgs);
        Assert.NotEmpty(errorMsgs);
        Assert.NotNull(errorMsgStr);
        Assert.NotEmpty(errorMsgStr);
        Assert.Equal(error, errorMsgStr);
    }


    private Result<SimpleCodeResponseModel> GetCmcServiceSuccessData(string symbol)
    {
        return Result.Ok(new SimpleCodeResponseModel
        {
            USD = new Currency
            {
                LastUpdated = DateTime.Now,
                FullyDilutedMarketCap = 34.788,
                MarketCap = 65.687,
                MarketCapDominance = 45665,
                PercentChange1H = 4567.2354,
                PercentChange24H = 345.245,
                PercentChange30D = 0.45,
                PercentChange7D = 0.23543465,
                Price = 4565346,
                Volume24H = 3415.0,
                VolumeChange24H = 346.88
            },
            EUR = new Currency
            {
                LastUpdated = DateTime.Now,
                FullyDilutedMarketCap = 34.788,
                MarketCap = 65.687,
                MarketCapDominance = 45665,
                PercentChange1H = 4567.2354,
                PercentChange24H = 345.245,
                PercentChange30D = 0.45,
                PercentChange7D = 0.23543465,
                Price = 4565346,
                Volume24H = 3415.0,
                VolumeChange24H = 346.88
            },
            GBP = new Currency
            {
                LastUpdated = DateTime.Now,
                FullyDilutedMarketCap = 34.788,
                MarketCap = 65.687,
                MarketCapDominance = 45665,
                PercentChange1H = 4567.2354,
                PercentChange24H = 345.245,
                PercentChange30D = 0.45,
                PercentChange7D = 0.23543465,
                Price = 4565346,
                Volume24H = 3415.0,
                VolumeChange24H = 346.88
            },
            BRL = new Currency
            {
                LastUpdated = DateTime.Now,
                FullyDilutedMarketCap = 34.788,
                MarketCap = 65.687,
                MarketCapDominance = 45665,
                PercentChange1H = 4567.2354,
                PercentChange24H = 345.245,
                PercentChange30D = 0.45,
                PercentChange7D = 0.23543465,
                Price = 4565346,
                Volume24H = 3415.0,
                VolumeChange24H = 346.88
            },
            AUD = new Currency
            {
                LastUpdated = DateTime.Now,
                FullyDilutedMarketCap = 34.788,
                MarketCap = 65.687,
                MarketCapDominance = 45665,
                PercentChange1H = 4567.2354,
                PercentChange24H = 345.245,
                PercentChange30D = 0.45,
                PercentChange7D = 0.23543465,
                Price = 4565346,
                Volume24H = 3415.0,
                VolumeChange24H = 346.88
            },
            Name = "BITCOIN",
            LastUpdate = DateTime.UtcNow,
            Symbol = symbol
        });
    }

    private Result<SimpleCodeResponseModel> GetCmcServiceFailureData(string error)
    {
        return Result.Fail(error);
    }
}
