namespace Yamcs.Shared.Models
{
    public class SubscribeGlobalAlarmStatusRequest
    {
        public SubscribeGlobalAlarmStatusRequest(string instance, string processor)
        {
            this.Instance = instance;
            this.Processor = processor;
        }

        public string Instance { set; get; }
        public string Processor { set; get; }
    }
    public class SubscribeAlarmsRequest
    {
        public string Instance { set; get; }
        public string Processor { set; get; }


    }
    //    public class EventSeverity
    //{
    //        public const string INFO = "INFO";
    //        public const string WARNING = "WARNING";
    //        public const string ERROR = "ERROR";

    //        //the levels below are compatible with XTCE
    //        // we left the 4 out since it could be used
    //        // for warning if we ever decide to get rid of the old ones
    //        public const string WATCH = "WATCH";
    //        public const string DISTRESS = "DISTRESS";
    //        public const string CRITICAL = "CRITICAL";
    //        public const string SEVERE = "SEVERE";
    //    }

}
