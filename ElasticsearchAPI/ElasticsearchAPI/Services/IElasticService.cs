namespace ElasticsearchAPI.Services;

public interface IElasticService
{
    //Get all data from DB considering it's type
    Task<IEnumerable<object>> GetAllData(string type);

    Task<IEnumerable<object>> GetSnippetData(string type);

    Task<Dictionary<string,string>> GetAllIndicesProperties();
//------------------------------------------------------------------------------------------------------------
    //Function used to populate the Elastic Search Database with Movie Objects using a Json file
    //------------------------------------------------------------------------------------------------------------
    //
    //public Task PopulateMovieDb();
    //
    //------------------------------------------------------------------------------------------------------------

}