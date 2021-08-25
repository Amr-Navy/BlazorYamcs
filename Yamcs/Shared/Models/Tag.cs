using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class ListTagsResponsecs
    {
        public ArchiveTag[] Tags { get; set; }
    }
    public class ArchiveTag
    {
        public int Number { get; set; }
        public string Name { set; get; }
        public string Start { set; get; }
        public string Stop { set; get; }
        public string Description { set; get; }
        public string Color { set; get; }
        public string StartUtc { get; set; }
        public string StopUtc { get; set; }

    }
}
