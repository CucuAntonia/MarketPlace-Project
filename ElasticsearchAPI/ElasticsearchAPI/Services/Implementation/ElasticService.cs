using ElasticsearchAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElasticsearchAPI.Services.Implementation;

public class ElasticService : IElasticService
{
    private readonly ElasticClient _client;
    private static string _indexName = "movie-db-index";
    private const string CloudUrl = "https://8f9677360fc34e2eb943d737b2597c7b.us-east-1.aws.found.io:9243";
    private const string Username = "elastic";
    private const string Password = "AWbtmGda2Q7BI2bYpdjyF4qd";

    #region Constructor

    public ElasticService()
    {
        var settings = new ConnectionSettings(new Uri(CloudUrl))
            .DefaultIndex(_indexName)
            .BasicAuthentication(Username, Password);
        _client = new ElasticClient(settings);

        if (_client.Indices.Exists(_indexName).Exists) return;

        var createIndexResponse = _client.Indices.Create(_indexName, c => c
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
        await ChangeIndex(type);

        var countResponse = await _client.CountAsync<object>(c => c.Index(_indexName));
        var searchResponse = await _client.SearchAsync<object>(s => s
            .Query(q => q.MatchAll())
            .From(0)
            .Size((int?)countResponse.Count)
        );
        
        return searchResponse.Documents;
    }

    public async Task<IEnumerable<object>> GetSnippetData(string type)
    {
        await ChangeIndex(type);
        
        var countResponse = await _client.CountAsync<object>(c => c.Index(_indexName));
        var rnd = new Random().Next(1, (int)countResponse.Count - 11);
        var searchResponse = await _client.SearchAsync<object>(s => s
            .Query(q => q.MatchAll())
            .From(rnd)
            .Size(10)
        );
        
        return searchResponse.Documents;
    }

    public async Task<Dictionary<string,string>> GetAllIndicesProperties()
    {
        var indicesResponse = await _client.Cat.IndicesAsync();
        var indices = indicesResponse.Records
            .Where(r => r.Index.Contains("-db-index"))
            .Select(r => r.Index);
        
        var propDictionary = new Dictionary<string, string>();
        foreach (var index in indices)
        {
            var mappingResponse = await _client.Indices.GetMappingAsync(new GetMappingRequest(index));
            var properties = mappingResponse.Indices[index].Mappings.Properties;
            var propString = properties.Aggregate(string.Empty, (current, property) => current + property.Key+",").TrimEnd(',');
            propDictionary.Add(index,propString);
        }
        
        return propDictionary;
    }

    private async Task ChangeIndex(string newIndexName)
    {
        var auxIndex = newIndexName + "-db-index";
        if (!(await _client.Indices.ExistsAsync(auxIndex)).Exists)
        {
            throw new InvalidOperationException();
        }

        _indexName = auxIndex;
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