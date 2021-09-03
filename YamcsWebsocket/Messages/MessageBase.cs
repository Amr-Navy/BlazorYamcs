namespace YamcsWebsocket.Messages
{
    /// <summary>
    /// Base class for every message
    /// </summary>
    public class MessageBase
    {
        /// <summary>
        /// Unique message type
        /// </summary>
        public virtual MessageType type { get; set; }
        public int seq { get; set; }
        public int call { get; set; }
    }
}
