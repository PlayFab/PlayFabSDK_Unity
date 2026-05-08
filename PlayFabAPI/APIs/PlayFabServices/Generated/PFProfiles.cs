// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesGetEntityProfileResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity type and entity identifier will retrieve the profile from the entity store. If the
        /// profile being retrieved is the caller's, then the read operation is consistent, if not it is an inconsistent
        /// read. An inconsistent read means that we do not guarantee all committed writes have occurred before
        /// reading the profile, allowing for a stale read. If consistency is important the Version Number on
        /// the result can be used to compare which version of the profile any reader has.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesGetProfileGetResultSize"/> and
        /// <see cref="PFProfilesGetProfileGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFProfilesGetEntityProfileResponse>> ProfilesGetProfileAsync(
            PFProfilesGetEntityProfileRequest request
        )
        {
            return InteropWrapper.Services.PFProfiles.PFProfilesGetProfileAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesGetEntityProfilesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given a set of entity types and entity identifiers will retrieve all readable profiles properties
        /// for the caller. Profiles that the caller is not allowed to read will silently not be included in the
        /// results.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesGetProfilesGetResultSize"/> and
        /// <see cref="PFProfilesGetProfilesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFProfilesGetEntityProfilesResponse>> ProfilesGetProfilesAsync(
            PFProfilesGetEntityProfilesRequest request
        )
        {
            return InteropWrapper.Services.PFProfiles.PFProfilesGetProfilesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the title player accounts associated with the given master player account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given a master player account id (PlayFab ID), returns all title player accounts associated with
        /// it.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsGetResultSize"/>
        /// and <see cref="PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse>> ProfilesGetTitlePlayersFromMasterPlayerAccountIdsAsync(
            PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest request
        )
        {
            return InteropWrapper.Services.PFProfiles.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the entity's language. The precedence hierarchy for communication to the player is Title
        /// Player Account language, Master Player Account language, and then title default language if the first
        /// two aren't set or supported.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesSetProfileLanguageResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity profile, will update its language to the one passed in if the profile's version is
        /// equal to the one passed in.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesSetProfileLanguageGetResultSize"/>
        /// and <see cref="PFProfilesSetProfileLanguageGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFProfilesSetProfileLanguageResponse>> ProfilesSetProfileLanguageAsync(
            PFProfilesSetProfileLanguageRequest request
        )
        {
            return InteropWrapper.Services.PFProfiles.PFProfilesSetProfileLanguageAsync(InteropHandle, request);
        }

        /// <summary>
        /// Sets the profiles access policy
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesSetEntityProfilePolicyResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This will set the access policy statements on the given entity profile. This is not additive, any
        /// existing statements will be replaced with the statements in this request. See also ProfileGetProfileAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesSetProfilePolicyGetResultSize"/>
        /// and <see cref="PFProfilesSetProfilePolicyGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFProfilesSetEntityProfilePolicyResponse>> ProfilesSetProfilePolicyAsync(
            PFProfilesSetEntityProfilePolicyRequest request
        )
        {
            return InteropWrapper.Services.PFProfiles.PFProfilesSetProfilePolicyAsync(InteropHandle, request);
        }
    }
}
