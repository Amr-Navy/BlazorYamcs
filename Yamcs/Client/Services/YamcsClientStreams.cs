using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Yamcs.Shared.Models;

namespace Yamcs.Client.Services
{
    public class YamcsClientStreams
    {
        // public event EventHandler<WebSocketReplayResponse<T>> Notify;
        internal readonly Subject<WebSocketResponse<StatisticsResponse>> _StatisticsSubject = new ();
        public IObservable<WebSocketResponse<StatisticsResponse>> MessageReceived => _StatisticsSubject.AsObservable();

        internal readonly Subject<WebSocketResponse<ReplyResponse>> _ReplySubject = new Subject<WebSocketResponse<ReplyResponse>>();
        public IObservable<WebSocketResponse<ReplyResponse>> ReplyReceived => _ReplySubject.AsObservable();

    }
}
