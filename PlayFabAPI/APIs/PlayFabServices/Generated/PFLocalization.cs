// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Retrieves the list of allowed languages, only accessible by title entities
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLocalizationGetLanguageListResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFLocalizationGetLanguageListGetResultSize"/>
        /// and <see cref="PFLocalizationGetLanguageListGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFLocalizationGetLanguageListResponse>> LocalizationGetLanguageListAsync(
            PFLocalizationGetLanguageListRequest request
        )
        {
            return InteropWrapper.Services.PFLocalization.PFLocalizationGetLanguageListAsync(InteropHandle, request);
        }
#endif
    }
}
