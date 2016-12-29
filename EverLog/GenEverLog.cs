using System;
using System.Text;

namespace EverLog
{
    public static class GenEverLog
    {
        // <span><hr/><div><span style=\"color: rgb(54, 101, 238);\"><b>2017.01.01 Sun (001)</b></span></div><div><br/></div><div><br/></div><div><br/></div></span>

        private const string HtmlStart = "<span><hr/><div><span style=\"color: rgb(54, 101, 238);\"><b>";
        private const string HtmlEnd = "</b></span></div><div><br/></div><div><br/></div><div><br/></div></span>";

        // <span><hr/><div><span style=\"color: rgb(123, 0, 61);\">=== <b>Week 1</b> ===</span></div><div><br/></div></span>

        private const string HtmlWeekStart = "<span><hr/><div><span style=\"color: rgb(123, 0, 61);\">=== <b>Week ";
        private const string HtmlWeekEnd = "</b> ===</span></div><div><br/></div></span>";

        // <span><div><span><br/></span></div><hr/><div style=\"text-align: center\"><span><b><span style=\"color: rgb(50, 135, 18);\">Month 2017</span></b></span></div></span>

        private const string HtmlStartMonth = "<span><div><span><br/></span></div><hr/><div style=\"text-align: center\"><span><b><span style=\"color: rgb(50, 135, 18);\">";
        private const string HtmlEndMonth = "</span></b></span></div></span>";

        private const string MonthFormat = "MMM yyyy";
        private const string DayFormat = "yyyy.MM.dd ddd";

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
                sbHtml.AppendLine($"{HtmlStart}{dateIncr.ToString(DayFormat)} - ({dateIncr.DayOfYear.ToString("D3")}){HtmlEnd}");
                sbText.AppendLine($"{ dateIncr.ToString(DayFormat)} - ({ dateIncr.DayOfYear.ToString("D3")})");
            }
            sbHtml.AppendLine($"{HtmlStartMonth}End of {calendarYear}{HtmlEndMonth}");
            sbText.AppendLine($"End of {calendarYear}");

            ClipboardHelper.CopyToClipboard(sbHtml.ToString(), sbText.ToString());

            return new Tuple<StringBuilder, StringBuilder>(sbHtml, sbText);
        }
    }
}
