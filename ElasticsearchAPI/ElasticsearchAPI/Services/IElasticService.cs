using System.Collections;
using ElasticsearchAPI.Model;

namespace ElasticsearchAPI.Services;

public interface IElasticService
{
    //Get all data from DB considering it's type
    Task<IEnumerable<object>> GetAllData(string dataType);
    
    // Movie side of the DB
    Task<Movie> GetMovie(string seriesTitle);
    Task<IEnumerable<Movie>> GetAllMovies();
}