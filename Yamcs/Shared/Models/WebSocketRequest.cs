using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;

namespace Yamcs.Shared.Models
{
    public  class WebSocketRequest <T>
    {
        public string type { get; set; }
        public int id { get; set; }
        //public int Call { get; set; }
        public T options {set;get;}
    }

    public class WebSocketReplayResponse<T>
    {
       
        public string type { get; set; }
        public int seq { get; set; }
        public int call { get; set; }
        public T data { set; get; }
     
    }
}
