
using System.Text.Json;

namespace Yamcs.Shared.Models
{
    public static class YamcsSerialization
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true,
            
        };
        public static readonly JsonSerializerOptions Options1 = new JsonSerializerOptions
        {

            PropertyNamingPolicy = new UpperCaseNamingPolicy()
        };
        public static T Deserialize<T>(string msg)
        {
            return JsonSerializer.Deserialize<T>(msg, Options);
        }
        public static string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj, Options1);
        }
        public class UpperCaseNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name) =>
                name.ToLower();
        }
    }
}
