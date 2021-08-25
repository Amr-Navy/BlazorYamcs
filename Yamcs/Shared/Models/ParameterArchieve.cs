using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class GetParameterValuesOptions
    {
      public string  start { set; get; }
        public string stop { set; get; }
       public int pos { set; get; }
        public int limit { set; get; }
        public bool norepeat { set; get; }
      //  format?: 'csv';
        public order order { set; get; }
    }

    public class DownloadParameterValuesOptions
    {
       // parameters?: string | string[];
 public string start { set; get; }
        public string stop { set; get; }
        public bool norepeat  { set; get; }
  //delimiter?: 'TAB' | 'COMMA' | 'SEMICOLON';
}

    public class GetParameterSamplesOptions
    {
        public string start { set; get; }
        public string stop { set; get; }
        public int count { set; get; }
        public order order { set; get; }
    }

    public class GetParameterRangesOptions
    {
        public string start { set; get; }
        public string stop { set; get; }
        public int minGap { set; get; }
        public int maxGap { set; get; }
}

    public class GetPacketIndexOptions
    {
       public string  start { set; get; }
       public string  stop { set; get; }
       public int  mergeTime { set; get; }
       public int  limit { set; get; }
    }

    public class GetParameterIndexOptions
    {
       public string  start { set; get; }
       public string stop { set; get; }
      public int  mergeTime { set; get; }
     public int   limit { set; get; }
    }

    public class GetCommandIndexOptions
    {
     public string   start { set; get; }
        public string stop { set; get; }
       public int  mergeTime { set; get; }
        public int  limit { set; get; }
    }

}
