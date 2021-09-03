
using System.Text.Json;

namespace Yamcs.Shared.Models
{
    public static class YamcsSerialization
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true
        };
        public static T Deserialize<T>(string msg)
        {
            return JsonSerializer.Deserialize<T>(msg, Options);
        }
        public static string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj, Options);
        }
    }
}
