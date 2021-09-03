using System.Reactive.Subjects;
using YamcsWebsocket.Client;
using YamcsWebsocket.Messages;
    
namespace YamcsWebsocket.Responses
{
    /// <summary>
    /// Reply To subscription
    /// </summary>
    public class ReplyResponse : MessageBase
    {
        public int replyTo { set; get; }

        internal static void Handle(string msg, Subject<ReplyResponse> subject)
        {
            var reply = YamcsWebsocketSerialization.Deserialize<ReplyResponse>(msg);
            subject.OnNext(reply);
        }
    }
}
