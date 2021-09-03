namespace Yamcs.Shared.Models
{
    public class SubscribeTimeRequest
    {
        public SubscribeTimeRequest(string _instant, string _processor)
        {
            Instance = _instant;
            Processor = _processor;
        }

        public string Instance { get; set; }
        public string Processor { set; get; }
    }
}
