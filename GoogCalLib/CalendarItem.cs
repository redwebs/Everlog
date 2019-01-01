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

        public CalendarItem()
        {
        }

        public CalendarItem(CalendarItem item)
        {
            Summary = item.Summary;
            Description = item.Description;
            CalendarOrdinal = item.CalendarOrdinal;
            HasTime = item.HasTime;
            StartDateTime = item.StartDateTime;
            EndDateTime = item.EndDateTime;
            CreatedDateTime = item.CreatedDateTime;
            UpatedDateTime = item.UpatedDateTime;
            CreatorDisplayName = item.CreatorDisplayName;
            CreatorEmail = item.CreatorEmail;
            Etag = item.Etag;
            HtmlLink = item.HtmlLink;
            IcalUid = item.IcalUid;
            Id = item.Id;
            Location = item.Location;
            RecurringEventId = item.RecurringEventId;
            SourceTitle = item.SourceTitle;
            SourceUrl = item.SourceUrl;
            EndTimeUnspecified = item.EndTimeUnspecified;
            OriginalStartTime = item.OriginalStartTime;
        }
    }
}
