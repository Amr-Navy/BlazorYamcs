using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using YamcsWebsocket.Responses;


namespace YamcsWebsocket.Client
{
    /// <summary>
    /// All provided streams from Yamcs websocket API.
    /// You need to subscribe first, send subscription request `)
    /// </summary>
    public class YamcsWebsocketClientStreams
    {
        internal readonly Subject<ReplyResponse> ReplySubject = new Subject<ReplyResponse>();

      //  internal readonly Subject<SubscribedResponse> SubscriptionSubject = new Subject<SubscribedResponse>();
        public IObservable<ReplyResponse> ReplyStream => ReplySubject.AsObservable();

        internal readonly Subject<TmStatisticsResponse> TmstatsSubject = new Subject<TmStatisticsResponse>();

        //  internal readonly Subject<SubscribedResponse> SubscriptionSubject = new Subject<SubscribedResponse>();
        public IObservable<TmStatisticsResponse> TmstatsStream => TmstatsSubject.AsObservable();

        /// <summary>
        /// Info about unsubscription
        /// </summary>

        internal YamcsWebsocketClientStreams()
        {
        }
    }
}