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

    public static class CalendarLists
    {


        /// <summary>
        /// Deletes an entry on the user's calendar list. 
        /// Documentation https://developers.google.com/calendar/v3/reference/calendarList/delete
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        public static void Delete(CalendarService service, string calendarId)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (calendarId == null)
                    throw new ArgumentNullException(calendarId);

                // Make the request.
                service.CalendarList.Delete(calendarId).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CalendarList.Delete failed.", ex);
            }
        }

        /// <summary>
        /// Returns an entry on the user's calendar list. 
        /// Documentation https://developers.google.com/calendar/v3/reference/calendarList/get
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <returns>CalendarListEntryResponse</returns>
        public static CalendarListEntry Get(CalendarService service, string calendarId)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (calendarId == null)
                    throw new ArgumentNullException(calendarId);

                // Make the request.
                return service.CalendarList.Get(calendarId).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CalendarList.Get failed.", ex);
            }
        }
        public class CalendarListInsertOptionalParms
        {
            /// Whether to use the foregroundColor and backgroundColor fields to write the calendar colors (RGB). If this feature is used, the index-based colorId field will be set to the best matching option automatically. Optional. The default is False.
            public bool? ColorRgbFormat { get; set; }

        }

        /// <summary>
        /// Adds an entry to the user's calendar list. 
        /// Documentation https://developers.google.com/calendar/v3/reference/calendarList/insert
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>CalendarListEntryResponse</returns>
        public static CalendarListEntry Insert(CalendarService service, CalendarListEntry body, CalendarListInsertOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");

                // Building the initial request.
                var request = service.CalendarList.Insert(body);

                // Applying optional parameters to the request.                
                request = (CalendarListResource.InsertRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CalendarList.Insert failed.", ex);
            }
        }
        public class CalendarListListOptionalParms
        {
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page size can never be larger than 250 entries. Optional.
            public int? MaxResults { get; set; }
            /// The minimum access role for the user in the returned entries. Optional. The default is no restriction.
            public string MinAccessRole { get; set; }
            /// Token specifying which result page to return. Optional.
            public string PageToken { get; set; }
            /// Whether to include deleted calendar list entries in the result. Optional. The default is False.
            public bool? ShowDeleted { get; set; }
            /// Whether to show hidden entries. Optional. The default is False.
            public bool? ShowHidden { get; set; }
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list request. It makes the result of this list request contain only entries that have changed since then. If only read-only fields such as calendar properties or ACLs have changed, the entry won't be returned. All entries deleted and hidden since the previous list request will always be in the result set and it is not allowed to set showDeleted neither showHidden to False.To ensure client state consistency minAccessRole query parameter cannot be specified together with nextSyncToken.If the syncToken expires, the server will respond with a 410 GONE response code and the client should clear its storage and perform a full synchronization without any syncToken.Learn more about incremental synchronization.Optional. The default is to return all entries.
            public string SyncToken { get; set; }

        }

        /// <summary>
        /// Returns entries on the user's calendar list. 
        /// Documentation https://developers.google.com/calendar/v3/reference/calendarList/list
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>CalendarListResponse</returns>
        public static CalendarList List(CalendarService service, CalendarListListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");

                // Building the initial request.
                var request = service.CalendarList.List();

                // Applying optional parameters to the request.                
                request = (CalendarListResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CalendarList.List failed.", ex);
            }
        }
        public class CalendarListPatchOptionalParms
        {
            /// Whether to use the foregroundColor and backgroundColor fields to write the calendar colors (RGB). If this feature is used, the index-based colorId field will be set to the best matching option automatically. Optional. The default is False.
            public bool? ColorRgbFormat { get; set; }

        }

        /// <summary>
        /// Updates an entry on the user's calendar list. This method supports patch semantics. 
        /// Documentation https://developers.google.com/calendar/v3/reference/calendarList/patch
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>CalendarListEntryResponse</returns>
        public static CalendarListEntry Patch(CalendarService service, string calendarId, CalendarListEntry body, CalendarListPatchOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");
                if (calendarId == null)
                    throw new ArgumentNullException(calendarId);

                // Building the initial request.
                var request = service.CalendarList.Patch(body, calendarId);

                // Applying optional parameters to the request.                
                request = (CalendarListResource.PatchRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CalendarList.Patch failed.", ex);
            }
        }
        public class CalendarListUpdateOptionalParms
        {
            /// Whether to use the foregroundColor and backgroundColor fields to write the calendar colors (RGB). If this feature is used, the index-based colorId field will be set to the best matching option automatically. Optional. The default is False.
            public bool? ColorRgbFormat { get; set; }

        }

        /// <summary>
        /// Updates an entry on the user's calendar list. 
        /// Documentation https://developers.google.com/calendar/v3/reference/calendarList/update
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>CalendarListEntryResponse</returns>
        public static CalendarListEntry Update(CalendarService service, string calendarId, CalendarListEntry body, CalendarListUpdateOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");
                if (calendarId == null)
                    throw new ArgumentNullException(calendarId);

                // Building the initial request.
                var request = service.CalendarList.Update(body, calendarId);

                // Applying optional parameters to the request.                
                request = (CalendarListResource.UpdateRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CalendarList.Update failed.", ex);
            }
        }
        public class CalendarListWatchOptionalParms
        {
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page size can never be larger than 250 entries. Optional.
            public int? MaxResults { get; set; }
            /// The minimum access role for the user in the returned entries. Optional. The default is no restriction.
            public string MinAccessRole { get; set; }
            /// Token specifying which result page to return. Optional.
            public string PageToken { get; set; }
            /// Whether to include deleted calendar list entries in the result. Optional. The default is False.
            public bool? ShowDeleted { get; set; }
            /// Whether to show hidden entries. Optional. The default is False.
            public bool? ShowHidden { get; set; }
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list request. It makes the result of this list request contain only entries that have changed since then. If only read-only fields such as calendar properties or ACLs have changed, the entry won't be returned. All entries deleted and hidden since the previous list request will always be in the result set and it is not allowed to set showDeleted neither showHidden to False.To ensure client state consistency minAccessRole query parameter cannot be specified together with nextSyncToken.If the syncToken expires, the server will respond with a 410 GONE response code and the client should clear its storage and perform a full synchronization without any syncToken.Learn more about incremental synchronization.Optional. The default is to return all entries.
            public string SyncToken { get; set; }

        }

        /// <summary>
        /// Watch for changes to CalendarList resources. 
        /// Documentation https://developers.google.com/calendar/v3/reference/calendarList/watch
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Calendar service.</param>  
        /// <param name="body">A valid Calendar v3 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>ChannelResponse</returns>
        public static Channel Watch(CalendarService service, Channel body, CalendarListWatchOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");

                // Building the initial request.
                var request = service.CalendarList.Watch(body);

                // Applying optional parameters to the request.                
                request = (CalendarListResource.WatchRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CalendarList.Watch failed.", ex);
            }
        }

    }

}