using Microsoft.AspNetCore.Mvc;
using CryptoCurrency.WebApi.DTOs.CryptoCode.SimpleCode;
using CryptoCurrency.WebApi.Services.CoinMarketCap;


namespace CryptoCurrency.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CryptoCodeController(ICmcServices cmcService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<SimpleCodeResponseModel>> Get([FromQuery] SimpleCodeRequestModel request, CancellationToken ct = default)
    {
        var res = await cmcService.SimpleCode(request, ct);
        return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Errors);
    }
}