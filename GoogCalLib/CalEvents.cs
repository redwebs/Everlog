﻿// Copyright 2017 DAIMTO ([Linda Lawton](https://twitter.com/LindaLawtonDK)) :  [www.daimto.com](http://www.daimto.com/)
// Licensed under the Apache License, http://www.apache.org/licenses/LICENSE-2.0
//
//------------------------------------------------------------------------------  
// About 
// 
// Unoffical sample for the Calendar v3 API for C#. 
// API Description: Manipulates events and other calendar data.
// API Documentation Link https://developers.google.com/google-apps/calendar/firstapp
// Discovery Doc  https://www.googleapis.com/discovery/v1/apis/Calendar/v3/rest
//
//------------------------------------------------------------------------------
// Installation
//
// This sample code uses the Google .Net client library (https://github.com/google/google-api-dotnet-client)
// NuGet package: https://www.nuget.org/packages/Google.Apis.Calendar.v3/ 
// Install Command: PM>  Install-Package Google.Apis.Calendar.v3
//
//------------------------------------------------------------------------------  
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System;

namespace GoogCalLib
{
    public static class CalEvents
    {
        public class EventsDeleteOptionalParms
        {
            /// Whether to send notifications about the deletion of the event. Optional. The default is False.
            public bool? SendNotifications { get; set; }

        }

        /// <summary>
        /// Deletes an event. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/delete
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="optional">Optional paramaters.</param>
        public static void Delete(CalendarService service, string calendarId, string eventId, EventsDeleteOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));
                if (eventId == null)
                    throw new ArgumentNullException(nameof(eventId));

                // Building the initial request.
                var request = service.Events.Delete(calendarId, eventId);

                // Applying optional parameters to the request.                
                request = (EventsResource.DeleteRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Delete failed.", ex);
            }
        }
        public class EventsGetOptionalParms
        {
            /// Whether to always include a value in the email field for the organizer, creator and attendees, even if no real email is available (i.e. a generated, non-working value will be provided). The use of this option is discouraged and should only be used by clients which cannot handle the absence of an email address value in the mentioned places. Optional. The default is False.
            public bool? AlwaysIncludeEmail { get; set; }
            /// The maximum number of attendees to include in the response. If there are more than the specified number of attendees, only the participant is returned. Optional.
            public int? MaxAttendees { get; set; }
            /// Time zone used in the response. Optional. The default is the time zone of the calendar.
            public string TimeZone { get; set; }

        }

        /// <summary>
        /// Returns an event. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/get
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventResponse</returns>
        public static Event Get(CalendarService service, string calendarId, string eventId, EventsGetOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));
                if (eventId == null)
                    throw new ArgumentNullException(nameof(eventId));

                // Building the initial request.
                var request = service.Events.Get(calendarId, eventId);

                // Applying optional parameters to the request.                
                request = (EventsResource.GetRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Get failed.", ex);
            }
        }
        public class EventsImportOptionalParms
        {
            /// Whether API client performing operation supports event attachments. Optional. The default is False.
            public bool? SupportsAttachments { get; set; }

        }

        /// <summary>
        /// Imports an event. This operation is used to add a private copy of an existing event to a calendar. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/import
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventResponse</returns>
        public static Event Import(CalendarService service, string calendarId, Event body, EventsImportOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (body == null)
                    throw new ArgumentNullException(nameof(body));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));

                // Building the initial request.
                var request = service.Events.Import(body, calendarId);

                // Applying optional parameters to the request.                
                request = (EventsResource.ImportRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Import failed.", ex);
            }
        }
        public class EventsInsertOptionalParms
        {
            /// The maximum number of attendees to include in the response. If there are more than the specified number of attendees, only the participant is returned. Optional.
            public int? MaxAttendees { get; set; }
            /// Whether to send notifications about the creation of the new event. Optional. The default is False.
            public bool? SendNotifications { get; set; }
            /// Whether API client performing operation supports event attachments. Optional. The default is False.
            public bool? SupportsAttachments { get; set; }

        }

        /// <summary>
        /// Creates an event. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/insert
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventResponse</returns>
        public static Event Insert(CalendarService service, string calendarId, Event body, EventsInsertOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (body == null)
                    throw new ArgumentNullException(nameof(body));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));

                // Building the initial request.
                var request = service.Events.Insert(body, calendarId);

                // Applying optional parameters to the request.                
                request = (EventsResource.InsertRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Insert failed.", ex);
            }
        }
        public class EventsInstancesOptionalParms
        {
            /// Whether to always include a value in the email field for the organizer, creator and attendees, 
            /// even if no real email is available (i.e. a generated, non-working value will be provided). 
            /// The use of this option is discouraged and should only be used by clients which cannot handle 
            /// the absence of an email address value in the mentioned places. Optional. The default is False.
            public bool? AlwaysIncludeEmail { get; set; }
            /// The maximum number of attendees to include in the response. If there are more than the specified number 
            /// of attendees, only the participant is returned. Optional.
            public int? MaxAttendees { get; set; }
            /// Maximum number of events returned on one result page. By default the value is 250 events. 
            /// The page size can never be larger than 2500 events. Optional.
            public int? MaxResults { get; set; }
            /// The original start time of the instance in the result. Optional.
            public string OriginalStart { get; set; }
            /// Token specifying which result page to return. Optional.
            public string PageToken { get; set; }
            /// Whether to include deleted events (with status equals "cancelled") in the result. 
            /// Cancelled instances of recurring events will still be included if singleEvents is False. 
            /// Optional. The default is False.
            public bool? ShowDeleted { get; set; }
            /// Upper bound (exclusive) for an event's start time to filter by. Optional. 
            /// The default is not to filter by start time. Must be an RFC3339 timestamp with mandatory time zone offset.
            public string TimeMax { get; set; }
            /// Lower bound (inclusive) for an event's end time to filter by. Optional. 
            /// The default is not to filter by end time. Must be an RFC3339 timestamp with mandatory time zone offset.
            public string TimeMin { get; set; }
            /// Time zone used in the response. Optional. The default is the time zone of the calendar.
            public string TimeZone { get; set; }

        }

        /// <summary>
        /// Returns instances of the specified recurring event. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/instances
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="eventId">Recurring event identifier.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventsResponse</returns>
        public static Events Instances(CalendarService service, string calendarId, string eventId, EventsInstancesOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));
                if (eventId == null)
                    throw new ArgumentNullException(nameof(eventId));

                // Building the initial request.
                var request = service.Events.Instances(calendarId, eventId);

                // Applying optional parameters to the request.                
                request = (EventsResource.InstancesRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Instances failed.", ex);
            }
        }
        public class EventsListOptionalParms
        {
            /// Whether to always include a value in the email field for the organizer, creator and attendees, 
            /// even if no real email is available (i.e. a generated, non-working value will be provided). 
            /// The use of this option is discouraged and should only be used by clients which cannot handle 
            /// the absence of an email address value in the mentioned places. Optional. The default is False.
            public bool? AlwaysIncludeEmail { get; set; }
            /// Specifies event ID in the iCalendar format to be included in the response. Optional.
            public string ICalUID { get; set; }
            /// The maximum number of attendees to include in the response. If there are more than the specified number of attendees, 
            /// only the participant is returned. Optional.
            public int? MaxAttendees { get; set; }
            /// Maximum number of events returned on one result page. The number of events in the resulting page may be 
            /// less than this value, or none at all, even if there are more events matching the query. Incomplete pages 
            /// can be detected by a non-empty nextPageToken field in the response. By default the value is 250 events. 
            /// The page size can never be larger than 2500 events. Optional.
            public int? MaxResults { get; set; }
            /// The order of the events returned in the result. Optional. The default is an unspecified, stable order.
            public string OrderBy { get; set; }
            /// Token specifying which result page to return. Optional.
            public string PageToken { get; set; }
            /// Extended properties constraint specified as propertyName=value. Matches only private properties. 
            /// This parameter might be repeated multiple times to return events that match all given constraints.
            public string PrivateExtendedProperty { get; set; }
            /// Free text search terms to find events that match these terms in any field, except for extended properties. Optional.
            public string Q { get; set; }
            /// Extended properties constraint specified as propertyName=value. Matches only shared properties. 
            /// This parameter might be repeated multiple times to return events that match all given constraints.
            public string SharedExtendedProperty { get; set; }
            /// Whether to include deleted events (with status equals "cancelled") in the result. 
            /// Cancelled instances of recurring events (but not the underlying recurring event) will still be included if 
            /// showDeleted and singleEvents are both False. If showDeleted and singleEvents are both True, 
            /// only single instances of deleted events (but not the underlying recurring events) are returned. Optional. 
            /// The default is False.
            public bool? ShowDeleted { get; set; }
            /// Whether to include hidden invitations in the result. Optional. The default is False.
            public bool? ShowHiddenInvitations { get; set; }
            /// Whether to expand recurring events into instances and only return single one-off events and instances of recurring events, 
            /// but not the underlying recurring events themselves. Optional. The default is False.
            public bool? SingleEvents { get; set; }
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list request. 
            /// It makes the result of this list request contain only entries that have changed since then. 
            /// All events deleted since the previous list request will always be in the result set and it is not allowed 
            /// to set showDeleted to False.There are several query parameters that cannot be specified together with 
            /// nextSyncToken to ensure consistency of the client state. 
            /// These are: - iCalUID - orderBy - privateExtendedProperty - q - sharedExtendedProperty - timeMin - timeMax 
            /// - updatedMin If the syncToken expires, the server will respond with a 410 GONE response code and the client 
            /// should clear its storage and perform a full synchronization without any syncToken.
            /// Learn more about incremental synchronization. Optional. The default is to return all entries.
            public string SyncToken { get; set; }
            /// Upper bound (exclusive) for an event's start time to filter by. Optional. The default is not to filter by start time. 
            /// Must be an RFC3339 timestamp with mandatory time zone offset, e.g., 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. 
            /// Milliseconds may be provided but will be ignored. If timeMin is set, timeMax must be greater than timeMin.
            public DateTime TimeMax { get; set; }
            /// Lower bound (inclusive) for an event's end time to filter by. Optional. The default is not to filter by end time. 
            /// Must be an RFC3339 timestamp with mandatory time zone offset, e.g., 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. 
            /// Milliseconds may be provided but will be ignored. If timeMax is set, timeMin must be smaller than timeMax.
            public DateTime TimeMin { get; set; }
            /// Time zone used in the response. Optional. The default is the time zone of the calendar.
            public string TimeZone { get; set; }
            /// Lower bound for an event's last modification time (as a RFC3339 timestamp) to filter by. 
            /// When specified, entries deleted since this time will always be included regardless of showDeleted. 
            /// Optional. The default is not to filter by last modification time.
            public string UpdatedMin { get; set; }

        }

        /// <summary>
        /// Returns events on the specified calendar. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/list
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventsResponse</returns>
        public static Events List(CalendarService service, string calendarId, EventsListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));

                // Building the initial request.
                var request = service.Events.List(calendarId);

                // Applying optional parameters to the request.                
                request = (EventsResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.List failed.", ex);
            }
        }
        public class EventsMoveOptionalParms
        {
            /// Whether to send notifications about the change of the event's organizer. Optional. The default is False.
            public bool? SendNotifications { get; set; }

        }

        /// <summary>
        /// Moves an event to another calendar, i.e. changes an event's organizer. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/move
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier of the source calendar where the event currently is on.</param>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="destination">Calendar identifier of the target calendar where the event is to be moved to.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventResponse</returns>
        public static Event Move(CalendarService service, string calendarId, string eventId, string destination, EventsMoveOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));
                if (eventId == null)
                    throw new ArgumentNullException(nameof(eventId));
                if (destination == null)
                    throw new ArgumentNullException(nameof(destination));

                // Building the initial request.
                var request = service.Events.Move(calendarId, eventId, destination);

                // Applying optional parameters to the request.                
                request = (EventsResource.MoveRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Move failed.", ex);
            }
        }
        public class EventsPatchOptionalParms
        {
            /// Whether to always include a value in the email field for the organizer, creator and attendees, even if no real email is available (i.e. a generated, non-working value will be provided). The use of this option is discouraged and should only be used by clients which cannot handle the absence of an email address value in the mentioned places. Optional. The default is False.
            public bool? AlwaysIncludeEmail { get; set; }
            /// The maximum number of attendees to include in the response. If there are more than the specified number of attendees, only the participant is returned. Optional.
            public int? MaxAttendees { get; set; }
            /// Whether to send notifications about the event update (e.g. attendee's responses, title changes, etc.). Optional. The default is False.
            public bool? SendNotifications { get; set; }
            /// Whether API client performing operation supports event attachments. Optional. The default is False.
            public bool? SupportsAttachments { get; set; }

        }

        /// <summary>
        /// Updates an event. This method supports patch semantics. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/patch
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventResponse</returns>
        public static Event Patch(CalendarService service, string calendarId, string eventId, Event body, EventsPatchOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (body == null)
                    throw new ArgumentNullException(nameof(body));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));
                if (eventId == null)
                    throw new ArgumentNullException(nameof(eventId));

                // Building the initial request.
                var request = service.Events.Patch(body, calendarId, eventId);

                // Applying optional parameters to the request.                
                request = (EventsResource.PatchRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Patch failed.", ex);
            }
        }
        public class EventsQuickAddOptionalParms
        {
            /// Whether to send notifications about the creation of the event. Optional. The default is False.
            public bool? SendNotifications { get; set; }

        }

        /// <summary>
        /// Creates an event based on a simple text string. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/quickAdd
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="text">The text describing the event to be created.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventResponse</returns>
        public static Event QuickAdd(CalendarService service, string calendarId, string text, EventsQuickAddOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));
                if (text == null)
                    throw new ArgumentNullException(nameof(text));

                // Building the initial request.
                var request = service.Events.QuickAdd(calendarId, text);

                // Applying optional parameters to the request.                
                request = (EventsResource.QuickAddRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.QuickAdd failed.", ex);
            }
        }
        public class EventsUpdateOptionalParms
        {
            /// Whether to always include a value in the email field for the organizer, creator and attendees, even if no real email is available (i.e. a generated, non-working value will be provided). The use of this option is discouraged and should only be used by clients which cannot handle the absence of an email address value in the mentioned places. Optional. The default is False.
            public bool? AlwaysIncludeEmail { get; set; }
            /// The maximum number of attendees to include in the response. If there are more than the specified number of attendees, only the participant is returned. Optional.
            public int? MaxAttendees { get; set; }
            /// Whether to send notifications about the event update (e.g. attendee's responses, title changes, etc.). Optional. The default is False.
            public bool? SendNotifications { get; set; }
            /// Whether API client performing operation supports event attachments. Optional. The default is False.
            public bool? SupportsAttachments { get; set; }

        }

        /// <summary>
        /// Updates an event. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/update
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>EventResponse</returns>
        public static Event Update(CalendarService service, string calendarId, string eventId, Event body, EventsUpdateOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (body == null)
                    throw new ArgumentNullException(nameof(body));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));
                if (eventId == null)
                    throw new ArgumentNullException(nameof(eventId));

                // Building the initial request.
                var request = service.Events.Update(body, calendarId, eventId);

                // Applying optional parameters to the request.                
                request = (EventsResource.UpdateRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Update failed.", ex);
            }
        }
        public class EventsWatchOptionalParms
        {
            /// Whether to always include a value in the email field for the organizer, creator and attendees, even if no real email is available (i.e. a generated, non-working value will be provided). The use of this option is discouraged and should only be used by clients which cannot handle the absence of an email address value in the mentioned places. Optional. The default is False.
            public bool? AlwaysIncludeEmail { get; set; }
            /// Specifies event ID in the iCalendar format to be included in the response. Optional.
            public string ICalUID { get; set; }
            /// The maximum number of attendees to include in the response. If there are more than the specified number of attendees, only the participant is returned. Optional.
            public int? MaxAttendees { get; set; }
            /// Maximum number of events returned on one result page. The number of events in the resulting page may be less than this value, or none at all, even if there are more events matching the query. Incomplete pages can be detected by a non-empty nextPageToken field in the response. By default the value is 250 events. The page size can never be larger than 2500 events. Optional.
            public int? MaxResults { get; set; }
            /// The order of the events returned in the result. Optional. The default is an unspecified, stable order.
            public string OrderBy { get; set; }
            /// Token specifying which result page to return. Optional.
            public string PageToken { get; set; }
            /// Extended properties constraint specified as propertyName=value. Matches only private properties. This parameter might be repeated multiple times to return events that match all given constraints.
            public string PrivateExtendedProperty { get; set; }
            /// Free text search terms to find events that match these terms in any field, except for extended properties. Optional.
            public string Q { get; set; }
            /// Extended properties constraint specified as propertyName=value. Matches only shared properties. This parameter might be repeated multiple times to return events that match all given constraints.
            public string SharedExtendedProperty { get; set; }
            /// Whether to include deleted events (with status equals "cancelled") in the result. Cancelled instances of recurring events (but not the underlying recurring event) will still be included if showDeleted and singleEvents are both False. If showDeleted and singleEvents are both True, only single instances of deleted events (but not the underlying recurring events) are returned. Optional. The default is False.
            public bool? ShowDeleted { get; set; }
            /// Whether to include hidden invitations in the result. Optional. The default is False.
            public bool? ShowHiddenInvitations { get; set; }
            /// Whether to expand recurring events into instances and only return single one-off events and instances of recurring events, but not the underlying recurring events themselves. Optional. The default is False.
            public bool? SingleEvents { get; set; }
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list request. It makes the result of this list request contain only entries that have changed since then. All events deleted since the previous list request will always be in the result set and it is not allowed to set showDeleted to False.There are several query parameters that cannot be specified together with nextSyncToken to ensure consistency of the client state.These are: - iCalUID - orderBy - privateExtendedProperty - q - sharedExtendedProperty - timeMin - timeMax - updatedMin If the syncToken expires, the server will respond with a 410 GONE response code and the client should clear its storage and perform a full synchronization without any syncToken.Learn more about incremental synchronization.Optional. The default is to return all entries.
            public string SyncToken { get; set; }
            /// Upper bound (exclusive) for an event's start time to filter by. Optional. The default is not to filter by start time. Must be an RFC3339 timestamp with mandatory time zone offset, e.g., 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. Milliseconds may be provided but will be ignored. If timeMin is set, timeMax must be greater than timeMin.
            public string TimeMax { get; set; }
            /// Lower bound (inclusive) for an event's end time to filter by. Optional. The default is not to filter by end time. Must be an RFC3339 timestamp with mandatory time zone offset, e.g., 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. Milliseconds may be provided but will be ignored. If timeMax is set, timeMin must be smaller than timeMax.
            public string TimeMin { get; set; }
            /// Time zone used in the response. Optional. The default is the time zone of the calendar.
            public string TimeZone { get; set; }
            /// Lower bound for an event's last modification time (as a RFC3339 timestamp) to filter by. When specified, entries deleted since this time will always be included regardless of showDeleted. Optional. The default is not to filter by last modification time.
            public string UpdatedMin { get; set; }

        }

        /// <summary>
        /// Watch for changes to Events resources. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/watch
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>ChannelResponse</returns>
        public static Channel Watch(CalendarService service, string calendarId, Channel body, EventsWatchOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException(nameof(service));
                if (body == null)
                    throw new ArgumentNullException(nameof(body));
                if (calendarId == null)
                    throw new ArgumentNullException(nameof(calendarId));  // Was just calendarId in github

                // Building the initial request.
                var request = service.Events.Watch(body, calendarId);

                // Applying optional parameters to the request.                
                request = (EventsResource.WatchRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.Watch failed.", ex);
            }
        }
    }
}