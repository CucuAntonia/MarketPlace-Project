using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ElasticsearchAPI.Model;
using Nest;

namespace ElasticsearchAPI.Converters;

public static class JsonLdConverter
{
    public static string ObjectToJsonLd(IEnumerable<object> response,string type)
    {
        var properResponse = JArray.Parse(JsonConvert.SerializeObject(response, Formatting.Indented));
        var contextObject = new JObject { { "@schema", "elasticsearch" } };

        foreach (var value in properResponse)
        {
            value.First?.AddBeforeSelf(new JProperty("@id",Guid.NewGuid()));
        }
        
        var convertedObject = new JObject
        {
            { "@context", contextObject },
            { "@type", type },
            { "@list", properResponse }
        };
        return JsonConvert.SerializeObject(convertedObject);
    }

    public static Movie JsonLdToMovie()
    {
        throw new NotImplementedException();
    }
}