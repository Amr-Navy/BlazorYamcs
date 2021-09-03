namespace YamcsWebsocket.Client
{
    internal static class YamcsWebsocketLogger
    {
        public static string L(string msg)
        {
            return $"[BFX WEBSOCKET CLIENT] {msg}";
        }
    }
}
