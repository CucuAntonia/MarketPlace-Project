namespace ElasticsearchAPI.Services;

public interface IElasticService
{
    //Get all data from DB considering it's type
    Task<IEnumerable<object>> GetAllData(string type);
    public Task PopulateMovieDb();

    public Task PopulateMovieDBWith2Items();
}