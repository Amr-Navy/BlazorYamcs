using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class IndexGroup
    {
     public NamedObjectId id { set; get; }
  public IndexEntry[] entry { set; get; }
}

    public class IndexEntry
    {
      public string  start { set; get; }
        public string stop { set; get; }
       public int count { set; get; }
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
        public string start { set; get; }
        public string stop { set; get; }
        public int mergeTime { set; get; }
        public int  limit { set; get; }
    }

    public class GetCompletenessIndexOptions
    {
        public string start { set; get; }
        public string stop { set; get; }
        public int limit{ set; get; }
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
