using ElasticsearchAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace ElasticsearchAPI.Services.Implementation;

public class ElasticService : IElasticService
{
    private readonly ElasticClient _client;
    private const string IndexName = "movie-db-index";
    private const string CloudUrl = "https://8f9677360fc34e2eb943d737b2597c7b.us-east-1.aws.found.io:9243";
    private const string Username = "elastic";
    private const string Password = "AWbtmGda2Q7BI2bYpdjyF4qd";

    public ElasticService()
    {
        var settings = new ConnectionSettings(new Uri(CloudUrl))
            .DefaultIndex(IndexName)
            .BasicAuthentication(Username, Password);
        _client = new ElasticClient(settings);

        if (_client.Indices.Exists(IndexName).Exists) return;

        var createIndexResponse = _client.Indices.Create(IndexName, c => c
            .Map<Movie>(m => m.AutoMap())
        );

        if (!createIndexResponse.IsValid)
        {
            throw new Exception(
                $"Failed to create index '{IndexName}'. Error: {createIndexResponse.OriginalException?.Message ?? createIndexResponse.ServerError.Error.Reason}");
        }
    }


    [HttpGet]
    public async Task<Movie> GetMovie(string title)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task PostMovie(Movie movie)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task PostListOfMovies(IEnumerable<Movie> movieList)
    {
        throw new NotImplementedException();
    }
}