// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if MICROSOFT_GDK_SUPPORT
#nullable enable

using System;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFAuthenticationLoginWithXUserRequest data model. If this is the first time a user has signed in with
    /// the Xbox Live account and CreateAccount is set to true, a new PlayFab account will be created and
    /// linked to the Xbox Live account. In this case, no email or username will be associated with the PlayFab
    /// account. Otherwise, if no PlayFab account is linked to the Xbox Live account, an error indicating
    /// this will be returned, so that the title can guide the user through creation of a PlayFab account.
    /// Request object for PFAuthenticationLoginWithXUserAsync.
    /// </summary>
    public struct PFAuthenticationLoginWithXUserRequest
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool CreateAccount;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        /// <summary>
        /// (Optional) Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string? PlayerSecret;

        /// <summary>
        /// XUserHandle of the user to log in with.
        /// When using the Microsoft GDK Unity API, this is the Handle property or the value returned from DangerousGetHandle() of the XUserHandle object acquired from the XUserAddAsync or XUserAddByIdWithUiAsync methods.
        /// </summary>
        public IntPtr UserHandle;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithXUserRequest self, Interop.PFAuthenticationLoginWithXUserRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.InfoRequestParameters != null)
            {
                interop->infoRequestParameters = (Interop.PFGetPlayerCombinedInfoRequestParams*)buffer.AddBuffer(sizeof(Interop.PFGetPlayerCombinedInfoRequestParams));
                PFGetPlayerCombinedInfoRequestParams.ToInterop(self.InfoRequestParameters.Value, interop->infoRequestParameters, buffer);
            }

            if (self.PlayerSecret != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerSecret, &interop->playerSecret, buffer);
            }

            interop->user = self.UserHandle;

        }
    }
}
#endif