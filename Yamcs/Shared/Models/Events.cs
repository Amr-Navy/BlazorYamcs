using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class ListEventsResponse
    {
        public Evvent[] Events { get; set; }
    }
    public class Evvent
    {
        public string Source { get; set; }
        public string GenerationTime { set; get; }
        public string ReceptionTime { get; set; }
        public int SeqNumber { get; set; }
        public string Type { set; get; }
        public string Message { get; set; }
        public EventSeverity Severity { set; get; }
        public string CreatedBy { set; get; }


    }
    public class EventSeverity
    {
        public const string INFO = "INFO";
        public const string WARNING = "WARNING";
        public const string ERROR = "ERROR";
        //the levels below are compatible with XTCE
        // we left the 4 out since it could be used
        // for warning if we ever decide to get rid of the old ones
        public const string WATCH = "WATCH";
        public const string DISTRESS = "DISTRESS";
        public const string CRITICAL = "CRITICAL";
        public const string SEVERE = "SEVERE";
    }

    public class CreateEventRequest
    {
       public string message { set; get; }
  public string type  { set; get; }
   public EventSeverity severity { set; get; }
  public string time { set; get; }
    }

    public class GetEventsOptions
    {
        /**
         * Inclusive lower bound
         */
      public string  start { set; get; }
        /**
         * Exclusive upper bound
         */
        public string stop { set; get; }
        /**
         * Search string
         */
        public string q { set; get; }
       public EventSeverity  severity { set; get; }
  //source?: string | string[];
  public int pos { set; get; }
        public int  limit { set; get; }
        //order?: 'asc' | 'desc';
}

    public class DownloadEventsOptions
    {
        /**
         * Inclusive lower bound
         */
        public string start { set; get; }
        /**
         * Exclusive upper bound
         */
        public string stop { set; get; }
        /**
         * Search string
         */
        public string q { set; get; }
        public EventSeverity  severity {set; get;}

  //source?: string | string[];
  //delimiter?: 'COMMA' | 'SEMICOLON' | 'TAB';
}

}
