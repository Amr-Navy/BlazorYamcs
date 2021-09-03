using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamcsWebsocket.Messages;

namespace YamcsWebsocket.Requests
{
    public class SubscribeTMStatisticsRequest 
    {
       
        public SubscribeTMStatisticsRequest(string Instance, string Processor)
        {
            instance = Instance;
            processor = Processor;
        }

        public string instance { set; get; }
        public string processor { set; get; }
    }
    

}
