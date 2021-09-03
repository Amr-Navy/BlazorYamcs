using System;

namespace YamcsWebsocket.Exceptions
{
    public class YamcsWebsocketException : Exception
    {
        public YamcsWebsocketException()
        {
        }

        public YamcsWebsocketException(string message)
            : base(message)
        {
        }

        public YamcsWebsocketException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
