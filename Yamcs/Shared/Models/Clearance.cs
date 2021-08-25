using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class ListClearancesResponse
    {
        public ClearanceInfo[] clearanceInfos { set; get; }
    }
    public class ClearanceInfo
    {
        public string Username { set; get; }
        public string IssuedBy { get; set; }
        public string IssuedTime { get; set; }
        public SignificanceLevelType Level { set; get; }
        public bool HasCommandPrivilages { set; get; }
    }
}
