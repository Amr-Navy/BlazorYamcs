using System.Reactive.Subjects;

namespace Yamcs.Shared.Models
{
    public class ReplyResponse
    {
        public int ReplyTo { set; get; }

        public static void Handle(string msg, Subject<WebSocketResponse<ReplyResponse>> subject)
        {
            var rep = YamcsSerialization.Deserialize<WebSocketResponse<ReplyResponse>>(msg);
            subject.OnNext(rep);

        }
    }
}
