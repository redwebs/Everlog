using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Calendar.v3;

namespace GoogCalLib
{
    public static class YearList
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static CalendarService _service;

        public static string ClientSecretPath { get; set; }

        public static List<CalendarItem> GetList(int targetYear, string calendarId, string holidayCalendarId, 
            bool getPersonal, bool getHolidays)
        {
            var timeMin = new DateTime(targetYear, 1, 1).ToUniversalTime();
            var timeMax = timeMin.AddYears(1).AddSeconds(-1);

            if (!GetService(calendarId, CalendarService.Scope.CalendarEventsReadonly))
            {
                return new List<CalendarItem>();
            }

            var eventParms = new CalEvents.EventsListOptionalParms
            {
                AlwaysIncludeEmail = true,
                MaxAttendees = null,
                MaxResults = null,
                OrderBy = null,  // only for single events
                TimeMax = timeMax,
                TimeMin = timeMin,
                SingleEvents = false
            };

            var calItemsAccumulator = new List<CalendarItem>();

            if (!string.IsNullOrEmpty(holidayCalendarId) && getHolidays)
            {
                calItemsAccumulator.AddRange(GetCalendarItems(holidayCalendarId, eventParms, 0));
            }

            if (!string.IsNullOrEmpty(calendarId) && getPersonal)
            {
                calItemsAccumulator.AddRange(GetCalendarItems(calendarId, eventParms, 1));
            }
            var sorted = from row in calItemsAccumulator
                orderby row.StartDateTime, row.CalendarOrdinal
                select row;

            return sorted.ToList();
        }

        private static List<CalendarItem> GetCalendarItems(string calendarId, CalEvents.EventsListOptionalParms parms, int calOrdinal)
        {
            var targetYear = parms.TimeMin.Year.ToString();

            Log.Debug($"******************** Starting GetCalendarItems.List for Id {calendarId}");

            var itemList = new List<CalendarItem>();

            var events = CalEvents.List(_service, calendarId, parms);

            foreach (var calEvent in events.Items)
            {
                var item = new CalendarItem
                {
                    Summary = calEvent.Summary,
                    CalendarOrdinal = calOrdinal,
                    CreatedDateTime = calEvent.Created ?? DateTime.MinValue,
                    UpatedDateTime = calEvent.Updated ?? DateTime.MinValue,

                    Description = calEvent.Description,

                    Etag = calEvent.ETag,
                    HtmlLink = calEvent.HtmlLink,
                    IcalUid = calEvent.ICalUID,
                    Id = calEvent.Id,
                    Location = calEvent.Location,
                    RecurringEventId = calEvent.RecurringEventId,
                    EndTimeUnspecified = calEvent.EndTimeUnspecified ?? true,
                    OriginalStartTime = DateTime.MinValue
                };

                if (calEvent.Creator != null)
                {
                    item.CreatorDisplayName = calEvent.Creator.DisplayName;
                    item.CreatorEmail = calEvent.Creator.Email;
                }

                if (calEvent.Source != null)
                {
                    item.SourceTitle = calEvent.Source.Title;
                    item.SourceUrl = calEvent.Source.Url;
                }

                if (calEvent.OriginalStartTime?.DateTime != null)
                {
                    item.OriginalStartTime = calEvent.OriginalStartTime.DateTime.Value;
                }

                if (calEvent.Start.DateTime != null)
                {
                    item.HasTime = true;
                    item.StartDateTime = (DateTime)calEvent.Start.DateTime;
                }
                else
                {
                    item.HasTime = false;
                    item.StartDateTime = DateTime.Parse(targetYear + calEvent.Start.Date.Remove(0, 4));
                }
                if (calEvent.End.DateTime != null)
                {
                    item.EndDateTime = (DateTime)calEvent.End.DateTime;
                }
                else
                {
                    item.EndDateTime = DateTime.Parse(targetYear + calEvent.End.Date.Remove(0, 4));

                    if (item.EndDateTime - item.StartDateTime > TimeSpan.FromDays(1f))
                    {
                        // This is a multiday event
                        itemList.AddRange(AddMultidays(item));
                    }
                }
                itemList.Add(item);
            }
            return itemList;
        }

        private static List<CalendarItem> AddMultidays(CalendarItem item)
        {
            Log.Debug($"AddMultidays input: Start: {item.StartDateTime} End: {item.EndDateTime}");

            var multiList = new List<CalendarItem>();
            var processing = true;
            var nextDayStart = item.StartDateTime;
            var dayCntr = 2;

            while (processing)
            {
                nextDayStart = nextDayStart.AddDays(1);

                if (nextDayStart >= item.EndDateTime)
                {
                    // Clean up the input end date and summary
                    item.Summary = $"{item.Summary} - Day 1";
                    item.EndDateTime = item.StartDateTime.AddDays(1);
                    processing = false;
                }
                else
                {
                    var nextDay = new CalendarItem(item)
                    {
                        StartDateTime = nextDayStart,
                        EndDateTime = nextDayStart.AddDays(1),
                        Summary = $"{item.Summary} - Day {dayCntr++}"
                    };
                    Log.Debug($"AddMultidays entry: Start: {nextDay.StartDateTime} End: {nextDay.EndDateTime}");
                    multiList.Add(nextDay);
                }
            }
            Log.Debug($"AddMultidays input changed: Start: {item.StartDateTime} End: {item.EndDateTime}");
            return multiList;
        }

        private static bool GetService(string id, string scope)
        {
            try
            {
                Log.Debug($"Execute OAuth2.GetCalendarService {id} ************************************");

                // Only get the permissions needed. Scope.Calendar will give all read / write
                _service = Oauth2.GetCalendarService(ClientSecretPath, id, new[] { scope });

                if (_service == null)
                {
                    Log.Debug("Null Service");
                    return false;
                }
                Log.Debug("Got service");
                return true;
            }
            catch (ArgumentException aex)
            {
                Log.Debug($"Argument exception: {aex.Message}");
            }
            catch (Exception ex)
            {
                Log.Debug($"Exception in Calendar Access: {ex.Message}");
            }
            return false;
        }
    }
}
