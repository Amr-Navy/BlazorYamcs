using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class SubscribeQueueStatisticsRequest
    {
       public string  instance { set; get; }
        public string processor { set; get; }
    }

    public class SubscribeQueueEventsRequest
    {
        public string instance { set; get; }
        public string processor { set; get; }
    }

    public class CommandQueueEntry
    {
        public string instance { set; get; }
        public string processorName { set; get; }
        public string queueName { set; get; }
        public string id { set; get; }
        public string commandName { set; get; }
        public string origin { set; get; }
        public int sequenceNumber { set; get; }
        public string source { set; get; }
        public string binary { set; get; }
        public string username { set; get; }
        public string generationTime { set; get; }
        public string uuid { set; get; }
        public bool pendingTransmissionConstraints { set; get; }
    }
    public class ListCommandQueuesRespnse
    {
        public CommandQueue[] Queues { set; get; }
    }
    public class CommandQueue
    {
        public string instance { set; get; }
        public string processorName { set; get; }
        public string name { set; get; }
      //  state: 'BLOCKED' | 'DISABLED' | 'ENABLED';
        public string[] users { set; get; }
        public string[] groups { set; get; }
        public string minLevel { set; get; }
        public int nbSentCommands { set; get; }
        public int  nbRejectCommands { set; get; }
        public int stateExpirationTimeS { set; get; }
        public CommandQueueEntry[]  entry { set; get; }
 public int order { set; get; }
}

    public class CommandQueueEvent
    {
      //  type: 'COMMAND_ADDED' | 'COMMAND_UPDATED' | 'COMMAND_REJECTED' | 'COMMAND_SENT';
        public CommandQueueEntry data { set; get; }
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
       public string instance { set; get; }
       public string processor { set; get; }
       public bool ignorePastCommands { set; get; }
    }
}
