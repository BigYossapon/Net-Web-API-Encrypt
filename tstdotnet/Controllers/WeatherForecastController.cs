using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace tstdotnet.Controllers;



[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }
    /// <remarks>
    /// Sample request
    ///  
    /// Sample request:
    ///
    ///     POST /Account
    ///     {
    ///        "userId": null,
    ///        "bankId": null,
    ///        "dateCreated": null
    ///     }
    ///     OR
    ///     
    ///     POST /Account
    ///     {
    ///        "userId": null,
    ///        "bankId": 000,
    ///        "dateCreated": null
    ///     } 
    /// </remarks>
    /// <param name=""></param>
    /// <returns> This endpoint returns a list of Accounts.</returns>
    [HttpGet("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    /// <summary>
    /// test
    /// </summary>
    /// <returns></returns>

    [HttpGet("GetEncrypt")]
    public ActionResult<List<string>> GetEncryptwithName()
    {
        var products = new List<string>();
        products.Add("VueJS");
        products.Add("Flutter");
        products.Add("React");
        return Ok(products);
    }

    /// <remark>
    /// 
    /// </remark>
    /// <returns></returns>
    [HttpGet("GetEncrypts")]
    public ActionResult<List<string>> GetEncryptwithNames()
    {
        var products = new List<string>();
        products.Add("VueJS");
        products.Add("Flutter");
        products.Add("React");
        return Ok(products);
    }


    /// <response code="201">
    /// "WeatherForecast"
    /// </response>
    /// <response code="400" cref="WeatherForecast">Bad Request</response>
    [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status400BadRequest)]
    [SwaggerResponse(401, "returns a new id of the bla bla", type: typeof(WeatherForecast))]
    [HttpGet("GetEncryptresponse")]
    public ActionResult<List<string>> GetEncryptwithNamesresponse()
    {
        var products = new List<string>();
        products.Add("VueJS");
        products.Add("Flutter");
        products.Add("React");
        return Ok(products);
    }

}

