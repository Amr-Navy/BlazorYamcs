using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class CreateTimelineItemRequest
    {
        public string name { set; get; }
        public string start { set; get; }
        public string duration { set; get; }
        public TimelineItemType type { set; get; }
        public string[] tags { set; get; }
    }

    public class UpdateTimelineItemRequest
    {
        public string name { set; get; }
        public string start { set; get; }
        public string duration { set; get; }
        public string[] tags { set; get; }
    }

    public enum TimelineItemType { EVENT, MANUAL_ACTIVITY, AUTO_ACTIVITY }

    public class TimelineItem
    {
        public string id { set; get; }
        public string name { set; get; }
        public string start { set; get; }
        public string duration { set; get; }
        TimelineItemType type { set; get; }
    }

    public class TimelineViewsPage
    {
        TimelineView[] views { set; get; }
    }

    public class TimelineBandsPage
    {
        TimelineBand[] bands { set; get; }
    }

    public class TimelineTagsPage
    {
        string[] tags { set; get; }
    }

    public class TimelineItemsPage
    {
        TimelineItem[] items { set; get; }
    }

    public class GetTimelineItemsOptions
    {
        public string start { set; get; }
        public string stop { set; get; }
        public string band { set; get; }
    }

    public enum TimelineBandType { TIME_RULER, ITEM_BAND, SPACER }

    public class CreateTimelineBandRequest
    {
        public string name { set; get; }
        public string description { set; get; }
        public TimelineBandType type { set; get; }
        public bool shared { set; get; }
        public string[] tags { set; get; }
        //  properties?: { [key: string]: string; };
    }

    public class TimelineBand
    {
        public string id { set; get; }
        public TimelineBandType type { set; get; }
        public bool shared { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string[] tags { set; get; }
        // properties?: { [key: string]: string; };
        public string username { set; get; }
    }

    public class UpdateTimelineBandRequest
    {
        public string name { set; get; }
        public string description { set; get; }
        public bool shared { set; get; }
        public string[] tags { set; get; }
        // properties?: { [key: string]: string; };
    }

    public class TimelineView
    {
        public string id { set; get; }
        public string name { set; get; }
        public TimelineBand[] bands { set; get; }
    }

    public class CreateTimelineViewRequest
    {
        public string name { set; get; }
        public string[] bands { set; get; }
    }

    public class UpdateTimelineViewRequest
    {
        public string name { set; get; }
        public string[] bands { set; get; }
    }
}


