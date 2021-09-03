using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Yamcs.Shared.Models;
using YamcsWebsocket.Client;

namespace Yamcs.Client.Services
{
    public class WebSocketClient
    {

        private int _id = 0;
        private ClientWebSocket _clientWebSocket;
        private readonly YamcsWebsocketPublicHandler _publicHandler;
        public YamcsClientStreams Streams { get; } = new YamcsClientStreams();
        CancellationTokenSource disposalTokenSource = new CancellationTokenSource();
        public WebSocketClient(ClientWebSocket clientWebSocket)
        {
            _clientWebSocket = clientWebSocket;
            _publicHandler = new YamcsWebsocketPublicHandler(Streams);

        }
        public async Task Connect()
        {
            try
            {
                await _clientWebSocket.ConnectAsync(new Uri("ws://localhost:8090/api/websocket"), disposalTokenSource.Token);
                _ = Receive();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



        }
        public async Task Send<T>(WebSocketRequest<T> request)
        {

            if (_clientWebSocket.State != WebSocketState.Open)
            {
                await Connect();

            }
            request.Id = _id++;

            string RequestString = YamcsSerialization.Serialize(request);

            var dataToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(RequestString));
            await _clientWebSocket.SendAsync(dataToSend, WebSocketMessageType.Text, true, disposalTokenSource.Token);


        }
        //public  async Task CreateSubscribtion<T> (string _type,int _id,T _option)
        //{
        //    if (_clientWebSocket.State != WebSocketState.Open)
        //    {
        //        await Connect();

        //    }
        //    WebSocketRequest<T> Request = new()
        //    {
        //        type = _type,
        //        id = _id,
        //        options = _option
        //    };
        //   await Send(Request);

        //}


        public async Task Receive()
        {
            var buffer = new ArraySegment<byte>(new byte[4096]);
            Console.WriteLine(disposalTokenSource.IsCancellationRequested);
            while (!disposalTokenSource.IsCancellationRequested)
            {
                try
                {
                    //Console.WriteLine("in");

                    var received = await _clientWebSocket.ReceiveAsync(buffer, disposalTokenSource.Token);

                    var jsonString = Encoding.UTF8.GetString(buffer.Array, 0, received.Count);
                    _publicHandler.OnMessage(jsonString);
                }
                catch (Exception ex)
                {

                    //   Console.WriteLine(ex.Message);
                }

            }

        }
        public async void Close()
        {
            disposalTokenSource.Cancel();
            await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Bye", CancellationToken.None);
        }


    }
}
