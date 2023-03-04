using ElasticsearchAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchAPI.Services.Implementation;

public class ElasticService : IElasticService
{
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