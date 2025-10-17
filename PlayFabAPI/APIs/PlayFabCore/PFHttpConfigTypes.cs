// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab
{
    /// <summary>
    /// Struct the defines retry settings for PlayFab HTTP requests.
    /// </summary>
    public struct PFHttpRetrySettings
    {
        /// <summary>
        /// Controls whether the SDK should automatically retry select errors. There are certain errors that will never be
        /// handled internally and will always be returned directly to the client. Default value is 'true'.
        /// </summary>
        public bool AllowRetry;

        /// <summary>
        /// The minimum number of seconds the SDK will wait after an HTTP failure before retrying the call. 
        /// The default and minimum value is 2 seconds.
        /// </summary>
        public uint MinimumRetryDelayInSeconds;

        /// <summary>
        /// The maximum number of seconds the SDK will attempt to retry an HTTP request before returning to the client.
        /// The default value is 20 seconds.
        /// </summary>
        public uint TimeoutWindowInSeconds;

        internal unsafe PFHttpRetrySettings(Interop.PFHttpRetrySettings interop)
        {

            AllowRetry = InteropWrapper.WrapperHelpers.InteropToBool(interop.allowRetry);

            MinimumRetryDelayInSeconds = interop.minimumRetryDelayInSeconds;
            
            TimeoutWindowInSeconds = interop.timeoutWindowInSeconds;
        }

        internal unsafe static void ToInterop(PFHttpRetrySettings self, Interop.PFHttpRetrySettings* interop)
        {
            interop->allowRetry = InteropWrapper.WrapperHelpers.BoolToInterop(self.AllowRetry);
            interop->minimumRetryDelayInSeconds = self.MinimumRetryDelayInSeconds;
            interop->timeoutWindowInSeconds = self.TimeoutWindowInSeconds;
        }
    }

    /// <summary>
    /// Struct that defines generic Http settings for PlayFab HTTP requests.
    /// Currently holds settings to enable gzip compression on all sdk responses.
    /// </summary>
    public struct PFHttpSettings
    {
        /// <summary>
        /// Controls whether the SDK currently requests that incoming responses be compressed. 
        /// Response compression is enabled by specifying the Accept-Encoding Header as "application/gzip".
        /// In order to decompress a compressed response provided by an API endpoint PFHCHttpCallResponseSetGzipCompressed 
        /// must be called prior to calling PFHCHttpCallPerformAsync.
        /// </summary>
        public bool RequestResponseCompression;

        internal unsafe PFHttpSettings(Interop.PFHttpSettings interop)
        {

            RequestResponseCompression = InteropWrapper.WrapperHelpers.InteropToBool(interop.requestResponseCompression);
        }

        internal unsafe static void ToInterop(PFHttpSettings self, Interop.PFHttpSettings* interop)
        {
            interop->requestResponseCompression = InteropWrapper.WrapperHelpers.BoolToInterop(self.RequestResponseCompression);
        }
    }
}
