using System;

namespace Yamcs.Shared
{
    public class PacketNameResponse
    {
       
      public string[] Names { get; set; }

        
    }
    public class ListPacketsResponse
    {
        public TmPacketData[] Packets { set; get; }
        public string ContinuationToken { set; get; }
    }
    public class TmPacketData
    {
        public string Packet { get; set; }
        public int SequenceNumber { get; set; }
        public NamedObjectid Id { get; set; }
        public string ReceptionTime { set; get; }
        public string GenerationTime { set; get; }
    }
    public class NamedObjectid
    {
        public string Name { set; get; }
        public string Namespace { set; get; }
    }
    public class SubscribePacketsRequest 
    {
        public string Instance { get; set; }
        public  string Stream { set; get; }
        public string   Processor { set; get; }
    }
}
