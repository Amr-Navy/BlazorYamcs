using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class ReplicationInfo
    {
       public ReplicationMaster[] masters { set; get; }
  public ReplicationSlave[] slaves { set; get; }
}

    public class ReplicationMaster
    {
        public string instance { set; get; }
         public string []streams { set; get; }
        public string localAddress { set; get; }
        public string remoteAddress { set; get; }
        public bool push { set; get; }
        public string  pushTo { set; get; }
        public int localTx { set; get; }
        public int nextTx { set; get; }
    }

    public class ReplicationSlave
    {
     public string   instance { set; get; }
        public string streams{ set; get; }
 public string localAddress{ set; get; }
  public string  remoteAddress{ set; get; }
 public bool push { set; get; }
 public string pullFrom{ set; get; }
 public int  tx { set; get; }
    }
}
