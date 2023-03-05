using ElasticsearchAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Movie> Get()
    {
        throw new NotImplementedException();
    }
}