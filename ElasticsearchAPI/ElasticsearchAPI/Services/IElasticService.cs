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
    Task UpdateMovie(string title, Movie movie);

    //DELETE
    Task DeleteMovie(string title);
}