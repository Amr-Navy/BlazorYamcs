namespace Yamcs.Shared.Models
{


    public class SubscribeParametersRequest
    {
        public SubscribeParametersRequest(string instance, string processor, int[] id, bool abortOnInvalid, bool updateOnExpiration, bool sendFromCache, bool action)
        {
            Instance = instance;
            Processor = processor;
            Id = id;
            AbortOnInvalid = abortOnInvalid;
            UpdateOnExpiration = updateOnExpiration;
            this.sendFromCache = sendFromCache;
            Action = action;
        }

        public string Instance { set; get; }
        public string Processor { set; get; }
        public int[] Id { set; get; }
        public bool AbortOnInvalid { set; get; }
        public bool UpdateOnExpiration { set; get; }
        public bool sendFromCache { set; get; }
        public bool Action { set; get; }
    }
    public enum action { REPLACE, ADD, REMOVE }
    public class SubscribeParametersData
    {
        //  mapping: { [key: number]: NamedObjectId; };
        public NamedObjectId[] invalid { set; get; }
        ParameterValue[] values { set; get; }
    }

    public class SubscribeProcessorsRequest
    {
        public SubscribeProcessorsRequest(string instance, string processor)
        {
            Instance = instance;
            Processor = processor;
        }

        public string Instance { set; get; }
        public string Processor { set; get; }
    }

    public class ListProcessorResponse
    {
        public Processor[] Processors { set; get; }
    }
    public class Processor
    {
        public string instance { set; get; }
        public string name { set; get; }
        public string type { set; get; }
        public string creator { set; get; }
        public bool hasAlarms { set; get; }
        public bool hasCommanding { set; get; }
        public bool checkCommandClearance { set; get; }
        public string state { set; get; }
        public bool persistent { set; get; }
        public string time { set; get; }
        public bool replay { set; get; }
        //public ReplayRequest replayRequest { set; get; }
        // public Service[]  services { set; get; }
    }

    public class ReplayRequest
    {
        public string Start { set; get; }
        public string Stop { set; get; }
        public ReplaySpeed Speed { set; get; }
    }

    public class ReplaySpeed
    {
        //   type: 'AFAP' | 'FIXED_DELAY' | 'REALTIME';
        public int Param { set; get; }
    }




}
