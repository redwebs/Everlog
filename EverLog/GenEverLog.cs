using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogCalLib;

namespace EverLog
{
    public static class GenEverLog
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // <span><hr/><div><span style=\"color: rgb(54, 101, 238);\"><b>2017.01.01 Sun (001)</b></span></div><div><br/></div><div><br/></div><div><br/></div></span>

        private const string HtmlStart = "<span><hr/><div><span style=\"color: rgb(54, 101, 238);\"><b>";
        private const string HtmlEnd = "</b></span></div><div><br/></div><div><br/></div><div><br/></div></span>";

        private const string HtmlHolidayStart = "<span><div><span style=\"color: rgb(123, 0, 61);\"><b>";

        private const string HtmlEventStart = "<span><div><span style=\"color: rgb(50, 135, 18);\"><b><a href='";
        private const string HtmlEventMiddle = "'>";
        private const string HtmlEventEnd = "</a>";

        // <span><hr/><div><span style=\"color: rgb(123, 0, 61);\">=== <b>Week 1</b> ===</span></div><div><br/></div></span>

        private const string HtmlWeekStart = "<span><hr/><div><span style=\"color: rgb(123, 0, 61);\">=== <b>Week ";
        private const string HtmlWeekEnd = "</b> ===</span></div><div><br/></div></span>";

        // <span><div><span><br/></span></div><hr/><div style=\"text-align: center\"><span><b><span style=\"color: rgb(50, 135, 18);\">Month 2017</span></b></span></div></span>

        private const string HtmlStartMonth = "<span><div><span><br/></span></div><hr/><div style=\"text-align: center\"><span><b><span style=\"color: rgb(50, 135, 18);\">";
        private const string HtmlEndMonth = "</span></b></span></div></span>";

        private const string MonthFormat = "MMM yyyy";
        private const string DayFormat = "yyyy.MM.dd ddd";
        private const string TimeFormat = "hh:mm tt";

        public static Tuple<StringBuilder, StringBuilder> CreateYear(int calendarYear, List<CalendarItem> calendarItems)
        {
            var dateIncr = new DateTime(calendarYear - 1, 12, 31);

            var year = calendarYear;
            var lastMonth = 0;
            var week = 0;

            var curCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture.Clone();
            curCulture.DateTimeFormat.AMDesignator = "AM";
            curCulture.DateTimeFormat.PMDesignator = "PM";
            

            var sbHtml = new StringBuilder();
            var sbText = new StringBuilder();

            while (year == calendarYear)
            {
                // Increment date
                dateIncr = dateIncr.AddDays(1);
                year = dateIncr.Year;

                if (year != calendarYear)
                {
                    break;
                }
                var month = dateIncr.Month;

                if (month != lastMonth)
                {
                    lastMonth = month;
                    // Do month header
                    sbHtml.AppendLine($"{HtmlStartMonth}{dateIncr.ToString(MonthFormat)}{HtmlEndMonth}");
                    sbText.AppendLine($"{dateIncr.ToString(MonthFormat)}");
                }
                // Week entry
                if (dateIncr.DayOfWeek.Equals(DayOfWeek.Monday))
                {
                    sbHtml.AppendLine($"{HtmlWeekStart}{++week}{HtmlWeekEnd}");
                }
                // Do date entry
                sbHtml.AppendLine($"{HtmlStart}{dateIncr.ToString(DayFormat)} - ({dateIncr.DayOfYear:D3})");
                sbText.AppendLine($"{ dateIncr.ToString(DayFormat)} - ({ dateIncr.DayOfYear:D3})");
                
                // Get Holidays and calendar entries
                var holidayItems = from row in calendarItems
                    where row.CalendarOrdinal == 0 && row.StartDateTime == dateIncr.Date
                    orderby row.Summary
                    select row;

                foreach (var holiday in holidayItems)
                {
                    sbHtml.AppendLine(
                        $"{HtmlHolidayStart}{holiday.Summary}");
                    sbText.AppendLine($"{holiday.Summary}");
                }

                var eventItems = from row in calendarItems
                    where row.CalendarOrdinal > 0 && row.StartDateTime.Date == dateIncr.Date
                    orderby row.StartDateTime
                    select row;

                foreach (var calEvent in eventItems)
                {
                    if (calEvent.HasTime)
                    {
                        // Event entry with starting / ending time
                        sbHtml.AppendLine(
                        $"{HtmlEventStart}{calEvent.HtmlLink}{HtmlEventMiddle}{calEvent.Summary} - {calEvent.StartDateTime.ToString(TimeFormat, curCulture)}{HtmlEventEnd}");
                        sbText.AppendLine($"{calEvent.Summary} - {calEvent.StartDateTime.ToString(TimeFormat, curCulture)}");
                    }
                    else  // All day event entry
                    {
                        sbHtml.AppendLine(
                            $"{HtmlEventStart}{calEvent.HtmlLink}{HtmlEventMiddle}{calEvent.Summary}{HtmlEventEnd}");
                        sbText.AppendLine($"{calEvent.Summary}");
                    }
                }
                // Add end of day entry with three blank lines
                sbHtml.AppendLine($"{HtmlEnd}");
            }
            sbHtml.AppendLine($"{HtmlStartMonth}End of {calendarYear}{HtmlEndMonth}");
            sbText.AppendLine($"End of {calendarYear}");

            ClipboardHelper.CopyToClipboard(sbHtml.ToString(), sbText.ToString());

            return new Tuple<StringBuilder, StringBuilder>(sbHtml, sbText);
        }
        public static Tuple<StringBuilder, StringBuilder> CreateYear(int calendarYear)
        {
            var dateIncr = new DateTime(calendarYear - 1, 12, 31);

            var year = calendarYear;
            var lastMonth = 0;
            var week = 0;

            var sbHtml = new StringBuilder();
            var sbText = new StringBuilder();

            while (year == calendarYear)
            {
                // Increment date
                dateIncr = dateIncr.AddDays(1);
                year = dateIncr.Year;

                if (year != calendarYear)
                {
                    break;
                }
                var month = dateIncr.Month;

                if (month != lastMonth)
                {
                    lastMonth = month;
                    // Do month header
                    sbHtml.AppendLine($"{HtmlStartMonth}{dateIncr.ToString(MonthFormat)}{HtmlEndMonth}");
                    sbText.AppendLine($"{dateIncr.ToString(MonthFormat)}");
                }
                // Week entry
                if (dateIncr.DayOfWeek.Equals(DayOfWeek.Monday))
                {
                    sbHtml.AppendLine($"{HtmlWeekStart}{++week}{HtmlWeekEnd}");
                }
                // Do date entry
                sbHtml.AppendLine($"{HtmlStart}{dateIncr.ToString(DayFormat)} - ({dateIncr.DayOfYear:D3}){HtmlEnd}");
                sbText.AppendLine($"{ dateIncr.ToString(DayFormat)} - ({ dateIncr.DayOfYear:D3})");
            }
            sbHtml.AppendLine($"{HtmlStartMonth}End of {calendarYear}{HtmlEndMonth}");
            sbText.AppendLine($"End of {calendarYear}");

            ClipboardHelper.CopyToClipboard(sbHtml.ToString(), sbText.ToString());

            return new Tuple<StringBuilder, StringBuilder>(sbHtml, sbText);
        }
    }
}
