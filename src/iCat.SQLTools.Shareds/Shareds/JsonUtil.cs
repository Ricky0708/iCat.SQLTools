using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace iCat.SQLTools.Shareds.Shareds
{

    public static class JsonUtil
    {
        private static JsonSerializerOptions _option = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs),
            WriteIndented = false,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        };

        public static string Serialize(object model)
        {
            return Serialize(model, _option);
        }

        public static string Serialize(object model, JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(model, options);
        }

        public static T? Deserialize<T>(string value)
        {
            return Deserialize<T>(value, _option);
        }

        public static T? Deserialize<T>(string value, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(value, options);
        }
    }
}
