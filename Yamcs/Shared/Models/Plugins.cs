using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared
{
    public class PluginsResponse
    {
        public string YamcsVersion { set; get; }
        public string ServerId { get; set; }
        public string DefaultYamcsInstance { set; get; }
        public Plugin[] Plugins { set; get; }

    }
    public class Plugin {

        public string Name { set; get; }
        public string Description { set; get; }
        public string Version { set; get; }
        public string Vendor { set; get; }
    }
}
