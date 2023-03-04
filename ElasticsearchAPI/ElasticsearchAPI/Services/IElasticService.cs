using ElasticsearchAPI.Model;

namespace ElasticsearchAPI.Services;

public interface IElasticService
{
    
    //GET
    Task<Movie> GetMovie(string title);
    Task<IEnumerable<Movie>> GetAllMovies();
    
    //POST
    Task PostMovie(Movie movie);
    Task PostListOfMovies(IEnumerable<Movie> movieList);
    
    //PUT
    // future implementation of updating a movie
    //
    
    //DELETE
    // future implementation of deleting a movie
    //
}