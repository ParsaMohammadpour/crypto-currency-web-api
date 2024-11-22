using Microsoft.AspNetCore.Mvc;
using System.Web;
using CryptoCurrency.WebApi.Configurations;
using CryptoCurrency.WebApi.DTOs.CryptoCode.SimpleCode;
using CryptoCurrency.WebApi.Services.HttpClients.CoinMarketCap;


namespace CryptoCurrency.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoCodeController(ICmcHttpClientService _httpClient) : ControllerBase
    {
        /// <summary>
        /// returning 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Get([FromQuery] SimpleCodeRequestModel request, CancellationToken ct = default)
        {
            var str = await _httpClient.GetCryptoLatestAsync(request.Code, ct);
            return Ok(str);
        }

        //private Task<string> MakeApiCall(CancellationToken ct)
        //{
        //    var URL = new UriBuilder(_cmcConf.Url);

        //    var queryString = HttpUtility.ParseQueryString(string.Empty);
        //    queryString["start"] = "1";
        //    queryString["limit"] = "5000";
        //    queryString["convert"] = "EUR";

        //    URL.Query = queryString.ToString();

        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _cmcConf.ApiKey);
        //    client.DefaultRequestHeaders.Add("Accepts", "application/json");
        //    return client.GetStringAsync(URL.ToString(), ct);
        //}
    }
}