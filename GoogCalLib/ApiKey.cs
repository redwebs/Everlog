// Copyright 2017 DAIMTO ([Linda Lawton](https://twitter.com/LindaLawtonDK)) :  [www.daimto.com](http://www.daimto.com/)
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
using Google.Apis.Services;
using System;

namespace GoogCalLib
{
    /// <summary>
    /// When calling APIs that do not access private user data, you can use simple API keys. These keys are used to authenticate your 
    /// application for accounting purposes. The Google API Console documentation also describes API keys.
    /// https://support.google.com/cloud/answer/6158857
    /// </summary>
    public static class ApiKey
    {
        /// <summary>
        /// Get a valid CalendarService for a public API Key.
        /// </summary>
        /// <param name="apiKey">API key from Google Developer console</param>
        /// <returns>CalendarService</returns>
        public static CalendarService GetService(string apiKey)
        {
            try
            {
                if (string.IsNullOrEmpty(apiKey))
                    throw new ArgumentNullException("api Key");

                return new CalendarService(new BaseClientService.Initializer()
                {
                    ApiKey = apiKey,
                    ApplicationName = string.Format("{0} API key example", System.Diagnostics.Process.GetCurrentProcess().ProcessName),
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create new Calendar Service", ex);
            }
        }
    }
}