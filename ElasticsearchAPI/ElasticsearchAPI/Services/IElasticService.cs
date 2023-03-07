namespace ElasticsearchAPI.Services;

public interface IElasticService
{
    //Get all data from DB considering it's type
    Task<IEnumerable<object>> GetAllData(string type);
}