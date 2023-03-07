using ElasticsearchAPI.Converters;
using ElasticsearchAPI.Services;
using ElasticsearchAPI.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchAPI.Controllers;

[ApiController]
[Route("/get_data")]
public class MovieController : ControllerBase
{
    #region Constructor and parameters

    private readonly IElasticService _elasticService;

    public MovieController()
    {
        _elasticService = new ElasticService();
    }

    #endregion

    [HttpGet]
    public async Task<IActionResult> GetAllData([FromQuery] string data_type)
    {
        try
        {
            var data = await _elasticService.GetAllData(data_type);

            return Ok(JsonLdConverter.ObjectToJsonLd(data, data_type));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #region Population Purpose

    [HttpPost("populateDB")]
    public async Task<ActionResult> PopulateDb()
    {
        try
        {
            await JsonLdConverter.Populate();

            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion
}