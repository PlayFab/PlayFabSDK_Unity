// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFCore
    {
        /// <summary>
        /// Sets global HTTP retry settings for the SDK.
        /// </summary>
        /// <param name="settings">Pointer to retry settings.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFSetHttpRetrySettings(PFHttpRetrySettings settings)
        {
            unsafe
            {
                Interop.PFHttpRetrySettings* settingsInterop = stackalloc Interop.PFHttpRetrySettings[1];
                PFHttpRetrySettings.ToInterop(settings, settingsInterop);
                var hr = Interop.Methods.PFSetHttpRetrySettings(settingsInterop);
                
                return new(hr);
            }
        }

        /// <summary>
        /// Gets the current HTTP retry settings for the SDK.
        /// </summary>
        /// <param name="settings">Pointer to retry settings that will be populated.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult<PFHttpRetrySettings> PFGetHttpRetrySettings()
        {
            unsafe
            {
                Interop.PFHttpRetrySettings* settingsInterop = stackalloc Interop.PFHttpRetrySettings[1];
                var hr = Interop.Methods.PFGetHttpRetrySettings(settingsInterop);
                
                return HRESULT.Failed(hr) ? new(hr)
                                          : new(new(*settingsInterop), hr);
            }
        }

        /// <summary>
        /// Sets global generic HTTP settings for the SDK.
        /// </summary>
        /// <param name="settings">Pointer to generic settings.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFSetHttpSettings(PFHttpSettings settings)
        {
            unsafe
            {
                Interop.PFHttpSettings* settingsInterop = stackalloc Interop.PFHttpSettings[1];
                PFHttpSettings.ToInterop(settings, settingsInterop);
                var hr = Interop.Methods.PFSetHttpSettings(settingsInterop);
                
                return new(hr);
            }
        }

        /// <summary>
        /// Gets the current generic HTTP settings for the SDK.
        /// </summary>
        /// <param name="settings">Pointer to generic settings that will be populated.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult<PFHttpSettings> PFGetHttpSettings()
        {
            unsafe
            {
                Interop.PFHttpSettings* settingsInterop = stackalloc Interop.PFHttpSettings[1];
                var hr = Interop.Methods.PFGetHttpSettings(settingsInterop);
                
                return HRESULT.Failed(hr) ? new(hr)
                                          : new(new(*settingsInterop), hr);
            }
        }
    }
}
