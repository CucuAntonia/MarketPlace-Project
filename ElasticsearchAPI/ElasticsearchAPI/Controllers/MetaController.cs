using ElasticsearchAPI.Converters;
using ElasticsearchAPI.Services;
using ElasticsearchAPI.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var data = await _elasticService.GetAllIndices();
            return Ok(JsonLdConverter.MetaToJsonLd(data));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}