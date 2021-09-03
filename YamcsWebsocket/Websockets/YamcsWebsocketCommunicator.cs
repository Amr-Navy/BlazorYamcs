using System;
using System.Net.WebSockets;
using YamcsWebsocket.Communicator;
using Websocket.Client;

namespace YamcsWebsocket.Client.Websocket.Websockets
{
    /// <inheritdoc cref="WebsocketClient" />
    public class YamcsWebsocketCommunicator : WebsocketClient, Communicator.IYamcsWebsocketCommunicator
    {
        /// <inheritdoc />
        public YamcsWebsocketCommunicator(Uri url, Func<ClientWebSocket> clientFactory = null) 
            : base(url, clientFactory)
        {
        }
    }
}
