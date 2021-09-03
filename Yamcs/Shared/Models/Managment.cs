namespace Yamcs.Shared.Models
{
    public class ListLinksResponse
    {
        public Link[] Links { set; get; }
    }
    public class Link
    {
        public string Instance { get; set; }
        public string Name { get; set; }
        public string Type { set; get; }
        public string Spec { get; set; }
        public bool Disables { set; get; }
        public string Status { get; set; }
        public string DataInCount { set; get; }
        public string DataOutCount { set; get; }
        public string DetailedStatus { set; get; }
        public string ParentName { get; set; }
    }
    public class SubscribeLinksRequest
    {
        public string Instance { set; get; }
    }
    public class LinkEvent
    {
        public string Type { set; get; }
        public Link LinkInformation { set; get; }
    }
    public class EditLinkOptions
    {
        public EditLinkOptions(Linkstate state, bool resetCounters)
        {
            this.State = state;
            this.ResetCounters = resetCounters;
        }

        public Linkstate State { set; get; }
        public bool ResetCounters { set; get; }
    }
    public enum Linkstate { enabled, disabled }
    public enum LinkStatus { OK, UNAVAIL, DISABLED, FAILED }
}
