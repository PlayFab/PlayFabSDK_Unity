// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab
{
    public static partial class PFCore
    {
        /// <summary>
        /// Sets global HTTP retry settings for the SDK.
        /// </summary>
        /// <param name="settings">Pointer to retry settings.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult SetHttpRetrySettings(PFHttpRetrySettings settings)
        {
            return InteropWrapper.Core.PFCore.PFSetHttpRetrySettings(settings);
        }

        /// <summary>
        /// Gets the current HTTP retry settings for the SDK.
        /// </summary>
        /// <returns>Result for this API operation.</returns>
        public static PFResult<PFHttpRetrySettings> GetHttpRetrySettings()
        {
            return InteropWrapper.Core.PFCore.PFGetHttpRetrySettings();
        }

        /// <summary>
        /// Sets global generic HTTP settings for the SDK.
        /// </summary>
        /// <param name="settings">Pointer to generic settings.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult SetHttpSettings(PFHttpSettings settings)
        {
            return InteropWrapper.Core.PFCore.PFSetHttpSettings(settings);
        }

        /// <summary>
        /// Gets the current generic HTTP settings for the SDK.
        /// </summary>
        /// <param name="settings">Pointer to generic settings that will be populated.</param>
        /// <returns>Result for this API operation.</returns>
        public static PFResult<PFHttpSettings> GetHttpSettings()
        {
            return InteropWrapper.Core.PFCore.PFGetHttpSettings();
        }
    }
}
