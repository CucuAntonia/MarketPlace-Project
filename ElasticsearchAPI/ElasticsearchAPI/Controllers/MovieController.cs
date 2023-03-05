using System.ComponentModel.DataAnnotations;
using ElasticsearchAPI.Model;
using ElasticsearchAPI.Services;
using ElasticsearchAPI.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly IElasticService _elasticService;

    public MovieController()
    {
        _elasticService = new ElasticService();
    }

    #region GET

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var movies = await _elasticService.GetAllMovies();
            return Ok(movies);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{title}")]
    public async Task<IActionResult> Get([Required] string title)
    {
        try
        {
            var movie = await _elasticService.GetMovie(title);
            return Ok(movie);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region POST

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        try
        {
            await _elasticService.PostMovie(movie);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostMany([FromBody] IEnumerable<Movie> movieList)
    {
        try
        {
            await _elasticService.PostListOfMovies(movieList);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region DELETE

    [HttpDelete("{title}")]
    public async Task<IActionResult> Delete([Required] string title)
    {
        try
        {
            await _elasticService.DeleteMovie(title);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region UPDATE

    [HttpPut("{title}")]
    public async Task<IActionResult> Update(string title, [FromBody] Movie movie)
    {
        try
        {
            await _elasticService.UpdateMovie(title, movie);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion
}