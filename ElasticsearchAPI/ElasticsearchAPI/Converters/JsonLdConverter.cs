using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ElasticsearchAPI.Model;
using Nest;

namespace ElasticsearchAPI.Converters;

public class JsonLdConverter
{
    public static string MovieToJsonLd(IEnumerable<object> response)
    {
        var responseToString = JsonConvert.SerializeObject(response, Formatting.Indented);

        var contextObject = new JObject { { "@schema", "elasticsearch" } };

        var convertedObject = new JObject
        {
            { "@context", contextObject },
            { "@type", "movies" },
            { "@list", responseToString }
        };
        // de reparat formatul raspunsului ( array iau fiecare element si-l deserializez
        return JsonConvert.SerializeObject(convertedObject);
    }

    public static Movie JsonLdToMovie()
    {
        throw new NotImplementedException();
    }
}