namespace Yamcs.Shared.Models
{
    public class LeapSecondsTableResponse
    {
        public ValidityRange[] Ranges { get; set; }
    }
    public class ValidityRange
    {
        public string Start { get; set; }
        public string Stop { get; set; }
        public int LeapSeconds { get; set; }
        public int TaiDifference { get; set; }
    }
}
