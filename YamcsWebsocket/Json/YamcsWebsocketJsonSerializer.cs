using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace YamcsWebsocket.Json
{
    /// <summary>
    /// Helper class for JSON serialization
    /// </summary>
    public static class YamcsWebsocketJsonSerializer
    {
        /// <summary>
        /// Unified JSON settings
        /// </summary>
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.None,
            Converters = new List<JsonConverter>() { new StringEnumConverter() { CamelCaseText = true} },
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        /// <summary>
        /// Custom preconfigured serializer
        /// </summary>
        public static readonly JsonSerializer Serializer = JsonSerializer.Create(Settings);
    }
}
