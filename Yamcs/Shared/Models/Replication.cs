namespace Yamcs.Shared.Models
{
    public class ReplicationInfo
    {
        public ReplicationMaster[] Masters { set; get; }
        public ReplicationSlave[] Slaves { set; get; }
    }

    public class ReplicationMaster
    {
        public string Instance { set; get; }
        public string[] Streams { set; get; }
        public string LocalAddress { set; get; }
        public string RemoteAddress { set; get; }
        public bool Push { set; get; }
        public string PushTo { set; get; }
        public int LocalTx { set; get; }
        public int NextTx { set; get; }
    }

    public class ReplicationSlave
    {
        public string Instance { set; get; }
        public string Streams { set; get; }
        public string LocalAddress { set; get; }
        public string RemoteAddress { set; get; }
        public bool Push { set; get; }
        public string PullFrom { set; get; }
        public int Tx { set; get; }
    }
}
