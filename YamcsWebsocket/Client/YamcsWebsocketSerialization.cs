using YamcsWebsocket.Json;
using Newtonsoft.Json;

namespace YamcsWebsocket.Client
{
    internal static class YamcsWebsocketSerialization
    {
        public static T Deserialize<T>(string msg)
        {
            return JsonConvert.DeserializeObject<T>(msg, YamcsWebsocketJsonSerializer.Settings);
        }
    }
}
