using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class TimeStamp
    {
        public string Seconds { get; set; }
        public int Nano { set; get; }
    }
    public class SubscribeTimeRequest
    {
        public string Instant { get; set; }
        public  string Processor { set; get; }
    }
    public  class LeapSecondsTable
    {
        public ValidityRange[] Ranges { get; set; }
    }

    public class ValidityRange
    {
        public string Start { get; set; }
        public string Stop { get; set; }
        public int LeapSeconds { get; set; }
        public int TaiDifference { get; set; }
    }
}
