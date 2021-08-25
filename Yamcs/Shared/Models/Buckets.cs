using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class ListBucketsResponse
    {
        public BucketInfo[] Buckets { get; set; }
    }
    public class BucketInfo
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public int NumObjects { set; get; }
    }
}
