using System;
using YamcsWebsocket.Logging;
using YamcsWebsocket.Messages;
using YamcsWebsocket.Responses;

namespace YamcsWebsocket.Client
{
    internal class YamcsWebsocketPublicHandler
    {
      //  private static readonly ILog Log = LogProvider.GetCurrentClassLogger(); 

        private readonly YamcsWebsocketClientStreams _streams;
       // private readonly BitfinexChannelList _channelIdToHandler;

        public YamcsWebsocketPublicHandler(YamcsWebsocketClientStreams streams)
        {
            _streams = streams;
        }

        public void OnObjectMessage(string msg)
        {
            var parsed = YamcsWebsocketSerialization.Deserialize<MessageBase>(msg);

            switch (parsed.type)
            {
                case MessageType.reply:
                    ReplyResponse.Handle(msg, _streams.ReplySubject);
                    break;
                case MessageType.tmstats:
                    TmStatistics.Handle(msg, _streams.TmstatsSubject);
                    break;
                    //default:
                    //    Log.Warning($"Missing handler for public stream, data: '{msg}'");
                    //    break;
            }
        }

      

    }
}
