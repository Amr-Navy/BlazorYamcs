
using System;
using System.Reactive.Subjects;
using System.Text.Json;

using Yamcs.Client.Services;
using Yamcs.Shared.Models;


namespace YamcsWebsocket.Client
{
    internal class YamcsWebsocketPublicHandler
    {
    

        private readonly YamcsClientStreams _streams;
   

        public YamcsWebsocketPublicHandler(YamcsClientStreams streams)
        {
            _streams = streams;
        }

        public void OnMessage(string jsonString)
        {
            var parsed = JsonSerializer.Deserialize<WebSocketResponse>(jsonString);

            switch (parsed.Type)
            {

                case ("reply"):
                    ReplyResponse.Handle(jsonString, _streams._ReplySubject);
                    break;
                case ("tmstats"):
                    StatisticsResponse.Handle(jsonString, _streams._StatisticsSubject);
                    break;
                default:
                       
                       break;
            }
        }

      

    }
}
