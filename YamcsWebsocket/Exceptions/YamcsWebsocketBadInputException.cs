using System;

namespace YamcsWebsocket.Exceptions
{
    public class YamcsWebsocketBadInputException : YamcsWebsocketException
    {
        public YamcsWebsocketBadInputException()
        {
        }

        public YamcsWebsocketBadInputException(string message) : base(message)
        {
        }

        public YamcsWebsocketBadInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
