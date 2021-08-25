using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Yamcs.Shared.Models;
namespace Yamcs.Client.Services
{
    public class WebSocketClient
    {

        // public event EventHandler<WebSocketReplayResponse<T>> Notify;
        private readonly Subject<WebSocketReplayResponse<StatisticsResponse>> _messageReceivedSubject = new Subject<WebSocketReplayResponse<StatisticsResponse>>();
        public IObservable<WebSocketReplayResponse<StatisticsResponse>> MessageReceived => _messageReceivedSubject.AsObservable();

        private ClientWebSocket clientWebSocket;
        CancellationTokenSource disposalTokenSource = new CancellationTokenSource();
        public  WebSocketClient(ClientWebSocket _clientWebSocket)
        {
            clientWebSocket = _clientWebSocket;
           
            
        }

      

        public async Task Connect ()
        {

            await clientWebSocket.ConnectAsync(new Uri("ws://localhost:8090/api/websocket"), disposalTokenSource.Token);
            Console.WriteLine("connected");

        }
        public async Task Send<T>(WebSocketRequest<T> request)
        {
            string RequestString = JsonSerializer.Serialize(request);
            var dataToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(RequestString));
            await clientWebSocket.SendAsync(dataToSend, WebSocketMessageType.Text, true, disposalTokenSource.Token);
        }
        public  async Task CreateSubscribtion<T> (string _type,int _id,T _option)
        {
            if (clientWebSocket.State != WebSocketState.Open)
            {
                await Connect();
            }
            WebSocketRequest<T> Request = new()
            {
                type = _type,
                id = _id,
                options = _option
            };
           await Send(Request);
           await Receive();
        }
      
        public async Task Receive()
        {
            var buffer = new ArraySegment<byte>(new byte[4096]);
            //WebSocketReplayResponse<T> resp = new WebSocketReplayResponse<T>();
            while (!disposalTokenSource.IsCancellationRequested)
            {
                var received = await clientWebSocket.ReceiveAsync(buffer, disposalTokenSource.Token);

                //Console.WriteLine("ok");
                var jsonString = Encoding.UTF8.GetString(buffer.Array, 0, received.Count);
                // Console.WriteLine
                if (jsonString.Contains("reply"))
                {
                    //_messageReceivedSubject.OnNext(jsonString);
                    //Console.WriteLine("this is reply {0}", jsonString);
                   // _messageReceivedSubject.OnNext(jsonString);
                    // var v = JsonSerializer.Deserialize<WebSocketReplayResponse<T>>(jsonString);
                    // Notify.Invoke(this, v);
                }
                else
                {
                    try
                    {
                        var resp =JsonSerializer.Deserialize<WebSocketReplayResponse<StatisticsResponse>>(jsonString);
                        _messageReceivedSubject.OnNext(resp);
                        Console.WriteLine("done");
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine(ex.Message);
                       
                    }
                 
                }
                
            }
            
        }
            public async void Close()
        {
            disposalTokenSource.Cancel();
           await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Bye", CancellationToken.None);
        }

       
    }
}
