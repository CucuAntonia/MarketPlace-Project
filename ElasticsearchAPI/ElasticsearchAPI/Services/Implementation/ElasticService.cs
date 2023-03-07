using Elasticsearch.Net;
using ElasticsearchAPI.Model;
using Nest;
using Newtonsoft.Json;

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

    public async Task<IEnumerable<object>> GetAllData(string dataType)
    {
        var response = await _client.SearchAsync<object>(s => s.Query(q => q.MatchAll(m=>m.GetType())
        ));
        return response.Documents;
    }

    public Task<Movie> GetMovie(string seriesTitle)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Movie>> GetAllMovies()
    {
        throw new NotImplementedException();
    }
}