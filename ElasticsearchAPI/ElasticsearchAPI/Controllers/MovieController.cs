using System.ComponentModel.DataAnnotations;
using ElasticsearchAPI.Model;
using ElasticsearchAPI.Services;
using ElasticsearchAPI.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchAPI.Controllers;

[ApiController]
[Route("/get_data")]
public class MovieController : ControllerBase
{
    private readonly IElasticService _elasticService;

    public MovieController()
    {
        _elasticService = new ElasticService();
    }
    
}