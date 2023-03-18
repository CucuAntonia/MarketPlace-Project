using ElasticsearchAPI.Converters;
using ElasticsearchAPI.Services;
using ElasticsearchAPI.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchAPI.Controllers;

[ApiController]
[Route("/get_meta")]
public class MetaController : ControllerBase
{
    #region Constructor and parameters

    private readonly IElasticService _elasticService;

    public MetaController()
    {
        _elasticService = new ElasticService();
    }

    #endregion

    [HttpGet]
    public async Task<IActionResult> GetMetaProperties()
    {
        try
        {

            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}