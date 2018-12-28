using System;

namespace GoogCalLib
{
    public class CalendarItem
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public int CalendarOrdinal { get; set; }
        public bool HasTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpatedDateTime { get; set; }
        public string CreatorDisplayName { get; set; }
        public string CreatorEmail { get; set; }
        public string Etag { get; set; }
        public string HtmlLink { get; set; }
        public string IcalUid { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public string RecurringEventId { get; set; }
        public string SourceTitle { get; set; }
        public string SourceUrl { get; set; }
        public bool EndTimeUnspecified { get; set; }
        public DateTime OriginalStartTime { get; set; }
    }
}
