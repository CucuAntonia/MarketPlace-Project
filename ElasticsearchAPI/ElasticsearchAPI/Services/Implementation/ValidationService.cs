namespace ElasticsearchAPI.Services.Implementation;

public static class ValidationService
{
    //------------------------------------------------------------------------------------------------------------
    //Function that filters useless data (30% or more missing properties per object) out of the response
    //------------------------------------------------------------------------------------------------------------
    // public static void ValidateResponseData(ref IEnumerable<object> response)
    // {
    //     var objectsToRemove = new List<object>();
    //     foreach (var obj in response)
    //     {
    //         if (obj is not Dictionary<string, object> dict) continue;
    //         var invalidDataCount = dict.Count(kvp => kvp.Value == null || kvp.Value.ToString() == string.Empty);
    //         if (invalidDataCount > (int)(0.3 * dict.Count))
    //         {
    //             objectsToRemove.Add(obj);
    //         }
    //     }
    //     response = objectsToRemove.Aggregate(response, (current, objToRemove) => current.Where(obj => !obj.Equals(objToRemove)));
    // }
}