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
        var properResponse = JArray.Parse(JsonConvert.SerializeObject(response, Formatting.Indented));
        var contextObject = new JObject { { "@schema", "elasticsearch" } };

        foreach (var value in properResponse)
        {
            value.First?.AddBeforeSelf(new JProperty("@id", Guid.NewGuid()));
        }

        var convertedObject = new JObject
        {
            { "@context", contextObject },
            { "@type", type },
            { "@list", properResponse }
        };
        return JsonConvert.SerializeObject(convertedObject);
    }
}