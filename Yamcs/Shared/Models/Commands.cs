namespace Yamcs.Shared.Models
{
    public class SubscribeQueueStatisticsRequest
    {
        public string Instance { set; get; }
        public string Processor { set; get; }
    }

    public class SubscribeQueueEventsRequest
    {
        public string Instance { set; get; }
        public string Processor { set; get; }
    }

    public class CommandQueueEntry
    {
        public string Instance { set; get; }
        public string ProcessorName { set; get; }
        public string QueueName { set; get; }
        public string Id { set; get; }
        public string CommandName { set; get; }
        public string Origin { set; get; }
        public int SequenceNumber { set; get; }
        public string Source { set; get; }
        public string Binary { set; get; }
        public string Username { set; get; }
        public string GenerationTime { set; get; }
        public string Uuid { set; get; }
        public bool PendingTransmissionConstraints { set; get; }
    }
    public class ListCommandQueuesRespnse
    {
        public CommandQueue[] Queues { set; get; }
    }
    public class CommandQueue
    {
        public string Instance { set; get; }
        public string ProcessorName { set; get; }
        public string Name { set; get; }
        //  state: 'BLOCKED' | 'DISABLED' | 'ENABLED';
        public string[] Users { set; get; }
        public string[] Groups { set; get; }
        public string MinLevel { set; get; }
        public int NbSentCommands { set; get; }
        public int NbRejectCommands { set; get; }
        public int StateExpirationTimeS { set; get; }
        public CommandQueueEntry[] Entry { set; get; }
        public int Order { set; get; }
    }

    public class CommandQueueEvent
    {
        //  type: 'COMMAND_ADDED' | 'COMMAND_UPDATED' | 'COMMAND_REJECTED' | 'COMMAND_SENT';
        public CommandQueueEntry Data { set; get; }
    }

    public class EditCommandQueueOptions
    {
        //   state: 'enabled' | 'disabled' | 'blocked';
    }

    public class EditCommandQueueEntryOptions
    {
        // state: 'released' | 'rejected';
    }

    public class SubscribeCommandsRequest
    {
        public string Instance { set; get; }
        public string Processor { set; get; }
        public bool IgnorePastCommands { set; get; }
    }
}
