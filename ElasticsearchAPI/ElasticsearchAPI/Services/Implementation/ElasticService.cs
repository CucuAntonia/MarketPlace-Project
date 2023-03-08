using ElasticsearchAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElasticsearchAPI.Services.Implementation;

public class ElasticService : IElasticService
{
    private readonly ElasticClient _client;
    private const string IndexName = "movie-db-index";
    private const string CloudUrl = "https://8f9677360fc34e2eb943d737b2597c7b.us-east-1.aws.found.io:9243";
    private const string Username = "elastic";
    private const string Password = "AWbtmGda2Q7BI2bYpdjyF4qd";

    #region Constructor

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

    #endregion

    public async Task<IEnumerable<object>> GetAllData(string type)
    {
        var searchResponse = await _client.SearchAsync<object>(s => s
            .Index(IndexName)
            .Query(q => q
                .Match(m => m
                    .Field("_type")
                    .Query(type)
                )
            )
        );

        return searchResponse.Documents;
    }
    //------------------------------------------------------------------------------------------------------------
    //Look up Interface for description
    //------------------------------------------------------------------------------------------------------------
    //
    // public async Task PopulateMovieDb()
    // {
    //     var json = await File.ReadAllTextAsync("C:\\Compendium\\ProiectePROG\\MoviesDataSets\\archive\\moviesDB.json");
    //     var moviesArray = JArray.Parse(json);
    //
    //     foreach (var mvs in moviesArray)
    //     {
    //         var indexResponse = await _client.IndexAsync(mvs.ToObject<Movie>(), i => i.Index(IndexName));
    //         
    //         if (!indexResponse.IsValid)
    //         {
    //             throw new InvalidOperationException();
    //         }
    //     }
    // }
    //------------------------------------------------------------------------------------------------------------
}