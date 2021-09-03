using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class CreateTimelineItemRequest
    {
        public string Name { set; get; }
        public string Start { set; get; }
        public string Duration { set; get; }
        public TimelineItemType type { set; get; }
        public string[] Tags { set; get; }
    }

    public class UpdateTimelineItemRequest
    {
        public string Name { set; get; }
        public string Start { set; get; }
        public string Duration { set; get; }
        public string[] Tags { set; get; }
    }

    public enum TimelineItemType { EVENT, MANUAL_ACTIVITY, AUTO_ACTIVITY }

    public class TimelineItem
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Start { set; get; }
        public string Duration { set; get; }
        TimelineItemType Type { set; get; }
    }

    public class TimelineViewsPage
    {
        TimelineView[] Views { set; get; }
    }

    public class TimelineBandsPage
    {
        TimelineBand[] Bands { set; get; }
    }

    public class TimelineTagsPage
    {
        string[] Tags { set; get; }
    }

    public class TimelineItemsPage
    {
        TimelineItem[] Items { set; get; }
    }

    public class GetTimelineItemsOptions
    {
        public string Start { set; get; }
        public string Stop { set; get; }
        public string Band { set; get; }
    }

    public enum TimelineBandType { TIME_RULER, ITEM_BAND, SPACER }

    public class CreateTimelineBandRequest
    {
        public string name { set; get; }
        public string Description { set; get; }
        public TimelineBandType Type { set; get; }
        public bool Shared { set; get; }
        public string[] Tags { set; get; }
        //  properties?: { [key: string]: string; };
    }

    public class TimelineBand
    {
        public string Id { set; get; }
        public TimelineBandType Type { set; get; }
        public bool Shared { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string[] Tags { set; get; }
        // properties?: { [key: string]: string; };
        public string Username { set; get; }
    }

    public class UpdateTimelineBandRequest
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public bool Shared { set; get; }
        public string[] Tags { set; get; }
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


