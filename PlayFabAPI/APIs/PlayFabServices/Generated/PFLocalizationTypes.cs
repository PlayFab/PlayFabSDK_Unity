// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFLocalizationGetLanguageListRequest data model.
    /// </summary>
    public struct PFLocalizationGetLanguageListRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFLocalizationGetLanguageListRequest self, Interop.PFLocalizationGetLanguageListRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
    }

    /// <summary>
    /// PFLocalizationGetLanguageListResponse data model.
    /// </summary>
    public struct PFLocalizationGetLanguageListResponse
    {
        /// <summary>
        /// (Optional) The list of allowed languages, in BCP47 two-letter format.
        /// </summary>
        public string[]? LanguageList;

        internal unsafe PFLocalizationGetLanguageListResponse(Interop.PFLocalizationGetLanguageListResponse interop)
        {

            LanguageList = (interop.languageList == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.languageList, interop.languageListCount);

        }
    }

}
