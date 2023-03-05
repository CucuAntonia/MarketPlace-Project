using ElasticsearchAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using Index = Nest.Index;

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
            throw new InvalidOperationException();
        }
    }


    [HttpGet]
    public async Task<Movie> GetMovie(string title)
    {
        var searchResponse = await _client.SearchAsync<Movie>(s => s
            .Query(q => q
                .Match(m => m
                    .Field(f => f.SeriesTitle)
                    .Query(title)
                )
            )
        );

        if (!searchResponse.IsValid)
        {
            throw new InvalidOperationException();
        }

        return searchResponse.Documents.SingleOrDefault() ?? throw new InvalidOperationException();
    }

    [HttpGet]
    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        var searchResponse = await _client.SearchAsync<Movie>(s => s
            .Query(q => q.MatchAll())
        );

        return searchResponse.Documents ?? throw new InvalidOperationException();
    }

    [HttpPost]
    public async Task PostMovie(Movie movie)
    {
        var indexResponse = await _client.IndexAsync(movie, i => i.Index(IndexName));

        if (!indexResponse.IsValid)
        {
            throw new InvalidOperationException();
        }
    }

    [HttpPost]
    public async Task PostListOfMovies(IEnumerable<Movie> movieList)
    {
        var bulkResponse = await _client.BulkAsync(b => b.Index(IndexName).IndexMany(movieList));

        if (!bulkResponse.IsValid)
        {
            throw new InvalidOperationException();
        }
    }
}