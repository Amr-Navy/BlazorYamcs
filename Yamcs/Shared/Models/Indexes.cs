using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class IndexGroup
    {
     public NamedObjectId Id { set; get; }
  public IndexEntry[] Entry { set; get; }
}

    public class IndexEntry
    {
      public string  Start { set; get; }
        public string Stop { set; get; }
       public int Count { set; get; }
    }
    //public class GetCommandIndexOptions
    //{
    //  public string  start { set; get; }
    //    public string stop { set; get; }
    //   public int  mergeTime { set; get; }
    //   public int  limit { set; get; }
    //}

    public class GetEventIndexOptions
    {
        public string Start { set; get; }
        public string Stop { set; get; }
        public int MergeTime { set; get; }
        public int  Limit { set; get; }
    }

    public class GetCompletenessIndexOptions
    {
        public string Start { set; get; }
        public string Stop { set; get; }
        public int Limit { set; get; }
}


//    public class GetPacketIndexOptions
//    {
//        public string start { set; get; }
//        public string stop { set; get; }
//        public int mergeTime { set; get; }
//       public int  limit{ set; get; }
//}

    //public class GetParameterIndexOptions
    //{
    //    public string start { set; get; }
    //    public string stop { set; get; }
    //    public int mergeTime { set; get; }
    //    public int limit { set; get; }
    //}
}
