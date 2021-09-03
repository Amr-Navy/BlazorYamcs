namespace Yamcs.Shared.Models
{
    public class ListClearancesResponse
    {
        public ClearanceInfo[] ClearanceInfos { set; get; }
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
