using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ElasticsearchAPI.Model;

namespace ElasticsearchAPI.Converters;

public static class JsonLdConverter
{
    //------------------------------------------------------------------------------------------------------------
    //Function that converts the Elastic Search response from string to a JsonLd serialized object
    //------------------------------------------------------------------------------------------------------------
    public static string ObjectToJsonLd(IEnumerable<object> response, string type)
    {
        var properResponse = JArray.Parse(JsonConvert.SerializeObject(response));
        var contextObject = new JObject { { "@schema", $"elasticsearch/{type}" } };

        foreach (var value in properResponse)
        {
            value.First?.AddBeforeSelf(new JProperty("@id", Guid.NewGuid()));
        }

        var convertedObject = new JObject
        {
            { "@context", contextObject },
            { "@list", properResponse }
        };
        return JsonConvert.SerializeObject(convertedObject);
    }
    public static string MetaToJsonLd(IEnumerable<object> response)
    {
        
        var contextObject = new JObject { { "@schema", $"elasticsearch" } };
        
        var convertedObject = new JObject
        {
            { "@context", contextObject },
            { "properties", response.ToString() }
        };
        return JsonConvert.SerializeObject(convertedObject);
    }
}