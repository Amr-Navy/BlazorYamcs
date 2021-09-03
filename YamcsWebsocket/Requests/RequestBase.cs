
using Newtonsoft.Json;
using YamcsWebsocket.Messages;

namespace YamcsWebsocket.Requests
{
    /// <summary>
    /// Base class for every request
    /// </summary>
    public abstract class RequestBase : MessageBase
    {
        /// <inheritdoc />
        public override MessageType type
        {
            get => EventType;
            set { }
        }

        /// <summary>
        /// Unique event type, need to be set in descendants
        /// </summary>
        [JsonIgnore]
        public abstract MessageType EventType { get; }
    }
}