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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;

namespace GoogCalLib
{

    public static class Oauth2
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ** Installed Aplication only ** 
        /// This method requests Authentcation from a user using Oauth2.  
        /// </summary>
        /// <param name="clientSecretJson">Path to the client secret json file from Google Developers console.</param>
        /// <param name="userName">Identifying string for the user who is being authentcated.</param>
        /// <param name="scopes">Array of Google scopes</param>
        /// <returns>CalendarService used to make requests against the Calendar API</returns>
        public static CalendarService GetCalendarService(string clientSecretJson, string userName, string[] scopes)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentNullException(nameof(userName));
                if (string.IsNullOrEmpty(clientSecretJson))
                    throw new ArgumentNullException(nameof(clientSecretJson));
                if (!File.Exists(clientSecretJson))
                    throw new Exception("clientSecretJson file does not exist.");

                var cred = GetUserCredential(clientSecretJson, userName, scopes);
                return GetService(cred);

            }
            catch (Exception ex)
            {
                Log.Debug($"GetCalendarService failed: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// ** Installed Aplication only ** 
        /// This method requests Authentcation from a user using Oauth2.  
        /// Credentials are stored in System.Environment.SpecialFolder.Personal
        /// Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="clientSecretJson">Path to the client secret json file from Google Developers console.</param>
        /// <param name="userName">Identifying string for the user who is being authentcated.</param>
        /// <param name="scopes">Array of Google scopes</param>
        /// <returns>authencated UserCredential</returns>
        private static UserCredential GetUserCredential(string clientSecretJson, string userName, string[] scopes)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentNullException(nameof(userName));
                if (string.IsNullOrEmpty(clientSecretJson))
                    throw new ArgumentNullException(nameof(clientSecretJson));
                if (!File.Exists(clientSecretJson))
                    throw new Exception("clientSecretJson file does not exist.");

                // These are the scopes of permissions you need. It is best to request only what you need and not all of them               
                using (var stream = new FileStream(clientSecretJson, FileMode.Open, FileAccess.Read))
                {
                    var credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

                    // Requesting Authentication or loading previously stored authentication for userName
                    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                                                                             scopes,
                                                                             userName,
                                                                             CancellationToken.None,
                                                                             new FileDataStore(credPath, true)).Result;

                    credential.GetAccessTokenForRequestAsync();
                    return credential;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Get user credentials failed.", ex);
            }
        }

        /// <summary>
        /// This method get a valid service
        /// </summary>
        /// <param name="credential">Authecated user credentail</param>
        /// <returns>CalendarService used to make requests against the Calendar API</returns>
        private static CalendarService GetService(UserCredential credential)
        {
            try
            {
                if (credential == null)
                    throw new ArgumentNullException(nameof(credential));

                // Create Calendar API service.
                return new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Calendar Oauth2 Authentication Sample"
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Get Calendar service failed.", ex);
            }
        }
    }
}