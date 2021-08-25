using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class ListClientResponse
    {
        public ClientInfo[] Clientsinfo { set; get; }
    }
    public class ClientInfo
    {
        public int Number { set; get; }
        public string Username { set; get; }
        public string ApplicationName { set; get; }
        public string Address { set; get; }
        public string Instance { set; get; }
        public string Processorname { set; get; }
        public ClientState State { set; get; }
        public string LoginTime { set; get; }
    }
    public enum ClientState
    {
        Connected,
        Disconnected
    }
}

