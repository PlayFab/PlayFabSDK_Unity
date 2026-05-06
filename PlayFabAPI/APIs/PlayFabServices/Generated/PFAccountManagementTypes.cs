// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// UserFamilyType enum.
    /// </summary>
    public enum PFAccountManagementUserFamilyType : uint
    {
        None = Interop.PFAccountManagementUserFamilyType.None,
        Xbox = Interop.PFAccountManagementUserFamilyType.Xbox,
        Steam = Interop.PFAccountManagementUserFamilyType.Steam
    }

    /// <summary>
    /// PFAccountManagementAddOrUpdateContactEmailRequest data model. This API adds a contact email to the
    /// player's profile. If the player's profile already contains a contact email, it will update the contact
    /// email to the email address specified.
    /// </summary>
    public struct PFAccountManagementAddOrUpdateContactEmailRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The new contact email to associate with the player.
        /// </summary>
        public string EmailAddress;

        internal unsafe static void ToInterop(PFAccountManagementAddOrUpdateContactEmailRequest self, Interop.PFAccountManagementAddOrUpdateContactEmailRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.EmailAddress, &interop->emailAddress, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementAddUsernamePasswordRequest data model.
    /// </summary>
    public struct PFAccountManagementAddUsernamePasswordRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// User email address attached to their account.
        /// </summary>
        public string Email;

        /// <summary>
        /// Password for the PlayFab account (6-100 characters).
        /// </summary>
        public string Password;

        /// <summary>
        /// PlayFab username for the account (3-20 characters).
        /// </summary>
        public string Username;

        internal unsafe static void ToInterop(PFAccountManagementAddUsernamePasswordRequest self, Interop.PFAccountManagementAddUsernamePasswordRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Email, &interop->email, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.Password, &interop->password, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.Username, &interop->username, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementAddUsernamePasswordResult data model. Each account must have a unique username
    /// and email address in the PlayFab service. Once created, the account may be associated with additional
    /// accounts (Steam, Facebook, Game Center, etc.), allowing for added social network lists and achievements
    /// systems. This can also be used to provide a recovery method if the user loses their original means
    /// of access.
    /// </summary>
    public struct PFAccountManagementAddUsernamePasswordResult
    {
        /// <summary>
        /// (Optional) PlayFab unique user name.
        /// </summary>
        public string? Username;

        internal unsafe PFAccountManagementAddUsernamePasswordResult(Interop.PFAccountManagementAddUsernamePasswordResult interop)
        {

            Username = (interop.username == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.username);

        }
    }

    /// <summary>
    /// PFAccountManagementGetAccountInfoRequest data model.
    /// </summary>
    public struct PFAccountManagementGetAccountInfoRequest
    {
        /// <summary>
        /// (Optional) User email address for the account to find (if no Username is specified).
        /// </summary>
        public string? Email;

        /// <summary>
        /// (Optional) Unique PlayFab identifier of the user whose info is being requested. Optional, defaults
        /// to the authenticated user if no other lookup identifier set.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Title-specific username for the account to find (if no Email is set). Note that if the
        /// non-unique Title Display Names option is enabled for the title, attempts to look up users by Title
        /// Display Name will always return AccountNotFound.
        /// </summary>
        public string? TitleDisplayName;

        /// <summary>
        /// (Optional) PlayFab Username for the account to find (if no PlayFabId is specified).
        /// </summary>
        public string? Username;

        internal unsafe static void ToInterop(PFAccountManagementGetAccountInfoRequest self, Interop.PFAccountManagementGetAccountInfoRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Email != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Email, &interop->email, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.TitleDisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TitleDisplayName, &interop->titleDisplayName, buffer);
            }

            if (self.Username != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Username, &interop->username, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetAccountInfoResult data model. This API retrieves details regarding the player
    /// in the PlayFab service. Note that when this call is used to retrieve data about another player (not
    /// the one signed into the local client), some data, such as Personally Identifying Information (PII),
    /// will be omitted for privacy reasons or to comply with the requirements of the platform belongs to.
    /// The user account returned will be based on the identifier provided in priority order: PlayFabId, Username,
    /// Email, then TitleDisplayName. If no identifier is specified, the currently signed in user's information
    /// will be returned.
    /// </summary>
    public struct PFAccountManagementGetAccountInfoResult
    {
        /// <summary>
        /// (Optional) Account information for the local user.
        /// </summary>
        public PFUserAccountInfo? AccountInfo;

        internal unsafe PFAccountManagementGetAccountInfoResult(Interop.PFAccountManagementGetAccountInfoResult interop)
        {

            AccountInfo = (interop.accountInfo == null) ? null : new(*interop.accountInfo);

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayerCombinedInfoRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayerCombinedInfoRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams InfoRequestParameters;

        /// <summary>
        /// (Optional) PlayFabId of the user whose data will be returned. If not filled included, we return the
        /// data for the calling player. .
        /// </summary>
        public string? PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayerCombinedInfoRequest self, Interop.PFAccountManagementGetPlayerCombinedInfoRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->infoRequestParameters = (Interop.PFGetPlayerCombinedInfoRequestParams*)buffer.AddBuffer(sizeof(Interop.PFGetPlayerCombinedInfoRequestParams));
            PFGetPlayerCombinedInfoRequestParams.ToInterop(self.InfoRequestParameters, interop->infoRequestParameters, buffer);

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayerCombinedInfoResult data model. Returns whatever info is requested in
    /// the response for the user. If no user is explicitly requested this defaults to the authenticated user.
    /// If the user is the same as the requester, PII (like email address, facebook id) is returned if available.
    /// Otherwise, only public information is returned. All parameters default to false.
    /// </summary>
    public struct PFAccountManagementGetPlayerCombinedInfoResult
    {
        /// <summary>
        /// (Optional) Results for requested info.
        /// </summary>
        public PFGetPlayerCombinedInfoResultPayload? InfoResultPayload;

        /// <summary>
        /// (Optional) Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementGetPlayerCombinedInfoResult(Interop.PFAccountManagementGetPlayerCombinedInfoResult interop)
        {

            InfoResultPayload = (interop.infoResultPayload == null) ? null : new(*interop.infoResultPayload);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayerProfileRequest data model. This API allows for access to details regarding
    /// a user in the PlayFab service, usually for purposes of customer support. Note that data returned may
    /// be Personally Identifying Information (PII), such as email address, and so care should be taken in
    /// how this data is stored and managed. Since this call will always return the relevant information for
    /// users who have accessed the title, the recommendation is to not store this data locally.
    /// </summary>
    public struct PFAccountManagementGetPlayerProfileRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) If non-null, this determines which properties of the resulting player profiles to return.
        /// For API calls from the client, only the allowed client profile properties for the title may be requested.
        /// These allowed properties are configured in the Game Manager "Client Profile Options" tab in the "Settings"
        /// section.
        /// </summary>
        public PFPlayerProfileViewConstraints? ProfileConstraints;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayerProfileRequest self, Interop.PFAccountManagementGetPlayerProfileRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.ProfileConstraints != null)
            {
                interop->profileConstraints = (Interop.PFPlayerProfileViewConstraints*)buffer.AddBuffer(sizeof(Interop.PFPlayerProfileViewConstraints));
                PFPlayerProfileViewConstraints.ToInterop(self.ProfileConstraints.Value, interop->profileConstraints, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayerProfileResult data model.
    /// </summary>
    public struct PFAccountManagementGetPlayerProfileResult
    {
        /// <summary>
        /// (Optional) The profile of the player. This profile is not guaranteed to be up-to-date. For a new
        /// player, this profile will not exist.
        /// </summary>
        public PFPlayerProfileModel? PlayerProfile;

        internal unsafe PFAccountManagementGetPlayerProfileResult(Interop.PFAccountManagementGetPlayerProfileResult interop)
        {

            PlayerProfile = (interop.playerProfile == null) ? null : new(*interop.playerProfile);

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest
    {
        /// <summary>
        /// Array of unique Battle.net account identifiers for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 10 in length.
        /// </summary>
        public string[] BattleNetAccountIds;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.BattleNetAccountIds, &interop->battleNetAccountIds, buffer);
            interop->battleNetAccountIdsCount = (uint)self.BattleNetAccountIds.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementBattleNetAccountPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementBattleNetAccountPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Battle.net account identifier for a user.
        /// </summary>
        public string? BattleNetAccountId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Battle.net
        /// account identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementBattleNetAccountPlayFabIdPair(Interop.PFAccountManagementBattleNetAccountPlayFabIdPair interop)
        {

            BattleNetAccountId = (interop.battleNetAccountId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.battleNetAccountId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementBattleNetAccountPlayFabIdPair self, Interop.PFAccountManagementBattleNetAccountPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.BattleNetAccountId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.BattleNetAccountId, &interop->battleNetAccountId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult data model. For Battle.net account
    /// identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult
    {
        /// <summary>
        /// (Optional) Mapping of Battle.net account identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementBattleNetAccountPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult(Interop.PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementBattleNetAccountPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest
    {
        /// <summary>
        /// Array of unique Facebook identifiers for which the title needs to get PlayFab identifiers. The array
        /// cannot exceed 25 in length.
        /// </summary>
        public string[] FacebookIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.FacebookIDs, &interop->facebookIDs, buffer);
            interop->facebookIDsCount = (uint)self.FacebookIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementFacebookPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementFacebookPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Facebook identifier for a user.
        /// </summary>
        public string? FacebookId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook
        /// identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementFacebookPlayFabIdPair(Interop.PFAccountManagementFacebookPlayFabIdPair interop)
        {

            FacebookId = (interop.facebookId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.facebookId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementFacebookPlayFabIdPair self, Interop.PFAccountManagementFacebookPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FacebookId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FacebookId, &interop->facebookId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromFacebookIDsResult data model. For Facebook identifiers which
    /// have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromFacebookIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of Facebook identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementFacebookPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromFacebookIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromFacebookIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementFacebookPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest
    {
        /// <summary>
        /// Array of unique Facebook Instant Games identifiers for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 25 in length.
        /// </summary>
        public string[] FacebookInstantGamesIds;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.FacebookInstantGamesIds, &interop->facebookInstantGamesIds, buffer);
            interop->facebookInstantGamesIdsCount = (uint)self.FacebookInstantGamesIds.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementFacebookInstantGamesPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementFacebookInstantGamesPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Facebook Instant Games identifier for a user.
        /// </summary>
        public string? FacebookInstantGamesId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook
        /// Instant Games identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementFacebookInstantGamesPlayFabIdPair(Interop.PFAccountManagementFacebookInstantGamesPlayFabIdPair interop)
        {

            FacebookInstantGamesId = (interop.facebookInstantGamesId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.facebookInstantGamesId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementFacebookInstantGamesPlayFabIdPair self, Interop.PFAccountManagementFacebookInstantGamesPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FacebookInstantGamesId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FacebookInstantGamesId, &interop->facebookInstantGamesId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult data model. For Facebook Instant
    /// Game identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult
    {
        /// <summary>
        /// (Optional) Mapping of Facebook Instant Games identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementFacebookInstantGamesPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult(Interop.PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementFacebookInstantGamesPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest
    {
        /// <summary>
        /// Array of unique Game Center identifiers (the Player Identifier) for which the title needs to get
        /// PlayFab identifiers. The array cannot exceed 25 in length.
        /// </summary>
        public string[] GameCenterIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.GameCenterIDs, &interop->gameCenterIDs, buffer);
            interop->gameCenterIDsCount = (uint)self.GameCenterIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementGameCenterPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementGameCenterPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Game Center identifier for a user.
        /// </summary>
        public string? GameCenterId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Game
        /// Center identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementGameCenterPlayFabIdPair(Interop.PFAccountManagementGameCenterPlayFabIdPair interop)
        {

            GameCenterId = (interop.gameCenterId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.gameCenterId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementGameCenterPlayFabIdPair self, Interop.PFAccountManagementGameCenterPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.GameCenterId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GameCenterId, &interop->gameCenterId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult data model. For Game Center identifiers which
    /// have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of Game Center identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementGameCenterPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementGameCenterPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest
    {
        /// <summary>
        /// Array of unique Google identifiers (Google+ user IDs) for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 25 in length.
        /// </summary>
        public string[] GoogleIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.GoogleIDs, &interop->googleIDs, buffer);
            interop->googleIDsCount = (uint)self.GoogleIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementGooglePlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementGooglePlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Google identifier for a user.
        /// </summary>
        public string? GoogleId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Google
        /// identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementGooglePlayFabIdPair(Interop.PFAccountManagementGooglePlayFabIdPair interop)
        {

            GoogleId = (interop.googleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googleId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementGooglePlayFabIdPair self, Interop.PFAccountManagementGooglePlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.GoogleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GoogleId, &interop->googleId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromGoogleIDsResult data model. For Google identifiers which have
    /// not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromGoogleIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of Google identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementGooglePlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromGoogleIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromGoogleIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementGooglePlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest
    {
        /// <summary>
        /// Array of unique Google Play Games identifiers (Google+ user IDs) for which the title needs to get
        /// PlayFab identifiers. The array cannot exceed 25 in length.
        /// </summary>
        public string[] GooglePlayGamesPlayerIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.GooglePlayGamesPlayerIDs, &interop->googlePlayGamesPlayerIDs, buffer);
            interop->googlePlayGamesPlayerIDsCount = (uint)self.GooglePlayGamesPlayerIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementGooglePlayGamesPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementGooglePlayGamesPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Google Play Games identifier for a user.
        /// </summary>
        public string? GooglePlayGamesPlayerId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Google
        /// Play Games identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementGooglePlayGamesPlayFabIdPair(Interop.PFAccountManagementGooglePlayGamesPlayFabIdPair interop)
        {

            GooglePlayGamesPlayerId = (interop.googlePlayGamesPlayerId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googlePlayGamesPlayerId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementGooglePlayGamesPlayFabIdPair self, Interop.PFAccountManagementGooglePlayGamesPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.GooglePlayGamesPlayerId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GooglePlayGamesPlayerId, &interop->googlePlayGamesPlayerId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult data model. For Google Play Games
    /// identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of Google Play Games identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementGooglePlayGamesPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementGooglePlayGamesPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest
    {
        /// <summary>
        /// Array of unique Kongregate identifiers (Kongregate's user_id) for which the title needs to get PlayFab
        /// identifiers. The array cannot exceed 25 in length.
        /// </summary>
        public string[] KongregateIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.KongregateIDs, &interop->kongregateIDs, buffer);
            interop->kongregateIDsCount = (uint)self.KongregateIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementKongregatePlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementKongregatePlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Kongregate identifier for a user.
        /// </summary>
        public string? KongregateId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Kongregate
        /// identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementKongregatePlayFabIdPair(Interop.PFAccountManagementKongregatePlayFabIdPair interop)
        {

            KongregateId = (interop.kongregateId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.kongregateId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementKongregatePlayFabIdPair self, Interop.PFAccountManagementKongregatePlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.KongregateId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.KongregateId, &interop->kongregateId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromKongregateIDsResult data model. For Kongregate identifiers which
    /// have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromKongregateIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of Kongregate identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementKongregatePlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromKongregateIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromKongregateIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementKongregatePlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest
    {
        /// <summary>
        /// Array of unique Nintendo Switch Account identifiers for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 25 in length.
        /// </summary>
        public string[] NintendoAccountIds;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.NintendoAccountIds, &interop->nintendoAccountIds, buffer);
            interop->nintendoAccountIdsCount = (uint)self.NintendoAccountIds.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementNintendoServiceAccountPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementNintendoServiceAccountPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Nintendo Switch Service Account identifier for a user.
        /// </summary>
        public string? NintendoServiceAccountId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Nintendo
        /// Switch Service Account identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementNintendoServiceAccountPlayFabIdPair(Interop.PFAccountManagementNintendoServiceAccountPlayFabIdPair interop)
        {

            NintendoServiceAccountId = (interop.nintendoServiceAccountId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.nintendoServiceAccountId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementNintendoServiceAccountPlayFabIdPair self, Interop.PFAccountManagementNintendoServiceAccountPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.NintendoServiceAccountId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoServiceAccountId, &interop->nintendoServiceAccountId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult data model. For Nintendo Service
    /// Account identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult
    {
        /// <summary>
        /// (Optional) Mapping of Nintendo Switch Service Account identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementNintendoServiceAccountPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult(Interop.PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementNintendoServiceAccountPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest
    {
        /// <summary>
        /// Array of unique Nintendo Switch Device identifiers for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 25 in length.
        /// </summary>
        public string[] NintendoSwitchDeviceIds;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.NintendoSwitchDeviceIds, &interop->nintendoSwitchDeviceIds, buffer);
            interop->nintendoSwitchDeviceIdsCount = (uint)self.NintendoSwitchDeviceIds.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementNintendoSwitchPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementNintendoSwitchPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique Nintendo Switch Device identifier for a user.
        /// </summary>
        public string? NintendoSwitchDeviceId;

        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Nintendo
        /// Switch Device identifier.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFAccountManagementNintendoSwitchPlayFabIdPair(Interop.PFAccountManagementNintendoSwitchPlayFabIdPair interop)
        {

            NintendoSwitchDeviceId = (interop.nintendoSwitchDeviceId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.nintendoSwitchDeviceId);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }

        internal unsafe static void ToInterop(PFAccountManagementNintendoSwitchPlayFabIdPair self, Interop.PFAccountManagementNintendoSwitchPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.NintendoSwitchDeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoSwitchDeviceId, &interop->nintendoSwitchDeviceId, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult data model. For Nintendo Switch
    /// identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult
    {
        /// <summary>
        /// (Optional) Mapping of Nintendo Switch Device identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementNintendoSwitchPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult(Interop.PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementNintendoSwitchPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest
    {
        /// <summary>
        /// (Optional) Id of the PlayStation :tm: Network issuer environment. If null, defaults to production
        /// environment.
        /// </summary>
        public int? IssuerId;

        /// <summary>
        /// Array of unique PlayStation :tm: Network identifiers for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 25 in length.
        /// </summary>
        public string[] PSNAccountIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.IssuerId != null)
            {
                *interop->issuerId = self.IssuerId.Value;
            }

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.PSNAccountIDs, &interop->PSNAccountIDs, buffer);
            interop->PSNAccountIDsCount = (uint)self.PSNAccountIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementPSNAccountPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementPSNAccountPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the PlayStation
        /// :tm: Network identifier.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Unique PlayStation :tm: Network identifier for a user.
        /// </summary>
        public string? PSNAccountId;

        internal unsafe PFAccountManagementPSNAccountPlayFabIdPair(Interop.PFAccountManagementPSNAccountPlayFabIdPair interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            PSNAccountId = (interop.PSNAccountId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.PSNAccountId);

        }

        internal unsafe static void ToInterop(PFAccountManagementPSNAccountPlayFabIdPair self, Interop.PFAccountManagementPSNAccountPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.PSNAccountId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PSNAccountId, &interop->PSNAccountId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult data model. For PlayStation :tm: Network
    /// identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of PlayStation :tm: Network identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementPSNAccountPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementPSNAccountPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest
    {
        /// <summary>
        /// (Optional) Id of the PlayStation :tm: Network issuer environment. If null, defaults to production
        /// environment.
        /// </summary>
        public int? IssuerId;

        /// <summary>
        /// Array of unique PlayStation :tm: Network identifiers for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 25 in length.
        /// </summary>
        public string[] PSNOnlineIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.IssuerId != null)
            {
                *interop->issuerId = self.IssuerId.Value;
            }

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.PSNOnlineIDs, &interop->PSNOnlineIDs, buffer);
            interop->PSNOnlineIDsCount = (uint)self.PSNOnlineIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementPSNOnlinePlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementPSNOnlinePlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the PlayStation
        /// :tm: Network identifier.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Unique PlayStation :tm: Network identifier for a user.
        /// </summary>
        public string? PSNOnlineId;

        internal unsafe PFAccountManagementPSNOnlinePlayFabIdPair(Interop.PFAccountManagementPSNOnlinePlayFabIdPair interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            PSNOnlineId = (interop.PSNOnlineId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.PSNOnlineId);

        }

        internal unsafe static void ToInterop(PFAccountManagementPSNOnlinePlayFabIdPair self, Interop.PFAccountManagementPSNOnlinePlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.PSNOnlineId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PSNOnlineId, &interop->PSNOnlineId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult data model. For PlayStation :tm: Network identifiers
    /// which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of PlayStation :tm: Network identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementPSNOnlinePlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementPSNOnlinePlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromSteamIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromSteamIDsRequest
    {
        /// <summary>
        /// (Optional) Array of unique Steam identifiers (Steam profile IDs) for which the title needs to get
        /// PlayFab identifiers. The array cannot exceed 25 in length.
        /// </summary>
        public string[]? SteamStringIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromSteamIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromSteamIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.SteamStringIDs != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.SteamStringIDs, &interop->steamStringIDs, buffer);
                interop->steamStringIDsCount = (uint)self.SteamStringIDs.Length;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementSteamPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementSteamPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam
        /// identifier.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Unique Steam identifier for a user.
        /// </summary>
        public string? SteamStringId;

        internal unsafe PFAccountManagementSteamPlayFabIdPair(Interop.PFAccountManagementSteamPlayFabIdPair interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            SteamStringId = (interop.steamStringId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.steamStringId);

        }

        internal unsafe static void ToInterop(PFAccountManagementSteamPlayFabIdPair self, Interop.PFAccountManagementSteamPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.SteamStringId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SteamStringId, &interop->steamStringId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromSteamIDsResult data model. For Steam identifiers which have not
    /// been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromSteamIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of Steam identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementSteamPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromSteamIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromSteamIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementSteamPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromSteamNamesRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromSteamNamesRequest
    {
        /// <summary>
        /// Array of unique Steam identifiers for which the title needs to get PlayFab identifiers. The array
        /// cannot exceed 25 in length.
        /// </summary>
        public string[] SteamNames;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromSteamNamesRequest self, Interop.PFAccountManagementGetPlayFabIDsFromSteamNamesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.SteamNames, &interop->steamNames, buffer);
            interop->steamNamesCount = (uint)self.SteamNames.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementSteamNamePlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementSteamNamePlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam
        /// identifier.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Unique Steam identifier for a user, also known as Steam persona name.
        /// </summary>
        public string? SteamName;

        internal unsafe PFAccountManagementSteamNamePlayFabIdPair(Interop.PFAccountManagementSteamNamePlayFabIdPair interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            SteamName = (interop.steamName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.steamName);

        }

        internal unsafe static void ToInterop(PFAccountManagementSteamNamePlayFabIdPair self, Interop.PFAccountManagementSteamNamePlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.SteamName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SteamName, &interop->steamName, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromSteamNamesResult data model. For Steam identifiers which have
    /// not been linked to PlayFab accounts, or if the user has not logged in recently, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromSteamNamesResult
    {
        /// <summary>
        /// (Optional) Mapping of Steam identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementSteamNamePlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromSteamNamesResult(Interop.PFAccountManagementGetPlayFabIDsFromSteamNamesResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementSteamNamePlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest
    {
        /// <summary>
        /// Array of unique Twitch identifiers (Twitch's _id) for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 25 in length.
        /// </summary>
        public string[] TwitchIds;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.TwitchIds, &interop->twitchIds, buffer);
            interop->twitchIdsCount = (uint)self.TwitchIds.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementTwitchPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementTwitchPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Twitch
        /// identifier.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Unique Twitch identifier for a user.
        /// </summary>
        public string? TwitchId;

        internal unsafe PFAccountManagementTwitchPlayFabIdPair(Interop.PFAccountManagementTwitchPlayFabIdPair interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            TwitchId = (interop.twitchId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.twitchId);

        }

        internal unsafe static void ToInterop(PFAccountManagementTwitchPlayFabIdPair self, Interop.PFAccountManagementTwitchPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.TwitchId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TwitchId, &interop->twitchId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromTwitchIDsResult data model. For Twitch identifiers which have
    /// not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromTwitchIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of Twitch identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementTwitchPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromTwitchIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromTwitchIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementTwitchPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest
    {
        /// <summary>
        /// (Optional) The ID of Xbox Live sandbox.
        /// </summary>
        public string? Sandbox;

        /// <summary>
        /// Array of unique Xbox Live account identifiers for which the title needs to get PlayFab identifiers.
        /// The array cannot exceed 25 in length.
        /// </summary>
        public string[] XboxLiveAccountIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest self, Interop.PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Sandbox != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Sandbox, &interop->sandbox, buffer);
            }

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.XboxLiveAccountIDs, &interop->xboxLiveAccountIDs, buffer);
            interop->xboxLiveAccountIDsCount = (uint)self.XboxLiveAccountIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementXboxLiveAccountPlayFabIdPair data model.
    /// </summary>
    public struct PFAccountManagementXboxLiveAccountPlayFabIdPair
    {
        /// <summary>
        /// (Optional) Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Xbox
        /// Live identifier.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Unique Xbox Live identifier for a user.
        /// </summary>
        public string? XboxLiveAccountId;

        internal unsafe PFAccountManagementXboxLiveAccountPlayFabIdPair(Interop.PFAccountManagementXboxLiveAccountPlayFabIdPair interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            XboxLiveAccountId = (interop.xboxLiveAccountId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.xboxLiveAccountId);

        }

        internal unsafe static void ToInterop(PFAccountManagementXboxLiveAccountPlayFabIdPair self, Interop.PFAccountManagementXboxLiveAccountPlayFabIdPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.XboxLiveAccountId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.XboxLiveAccountId, &interop->xboxLiveAccountId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult data model. For XboxLive identifiers which
    /// have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    public struct PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of Xbox Live identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementXboxLiveAccountPlayFabIdPair[]? Data;

        internal unsafe PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult(Interop.PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementXboxLiveAccountPlayFabIdPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementLinkAndroidDeviceIDRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkAndroidDeviceIDRequest
    {
        /// <summary>
        /// (Optional) Specific model of the user's device.
        /// </summary>
        public string? AndroidDevice;

        /// <summary>
        /// Android device identifier for the user's device.
        /// </summary>
        public string AndroidDeviceId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the device, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// (Optional) Specific Operating System version for the user's device.
        /// </summary>
        public string? OS;

        internal unsafe static void ToInterop(PFAccountManagementLinkAndroidDeviceIDRequest self, Interop.PFAccountManagementLinkAndroidDeviceIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AndroidDevice != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AndroidDevice, &interop->androidDevice, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.AndroidDeviceId, &interop->androidDeviceId, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            if (self.OS != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OS, &interop->OS, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementLinkAppleRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkAppleRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to a specific Apple account, unlink the other user and
        /// re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// The JSON Web token (JWT) returned by Apple after login. Represented as the identityToken field in
        /// the authorization credential payload. Used to validate the request and find the user ID (Apple subject)
        /// to link with.
        /// </summary>
        public string IdentityToken;

        internal unsafe static void ToInterop(PFAccountManagementLinkAppleRequest self, Interop.PFAccountManagementLinkAppleRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementClientLinkBattleNetAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientLinkBattleNetAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to a specific Battle.net account, unlink the other user
        /// and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// The JSON Web Token (JWT) returned by Battle.net after login.
        /// </summary>
        public string IdentityToken;

        internal unsafe static void ToInterop(PFAccountManagementClientLinkBattleNetAccountRequest self, Interop.PFAccountManagementClientLinkBattleNetAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementLinkCustomIDRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkCustomIDRequest
    {
        /// <summary>
        /// Custom unique identifier for the user, generated by the title.
        /// </summary>
        public string CustomId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the custom ID, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        internal unsafe static void ToInterop(PFAccountManagementLinkCustomIDRequest self, Interop.PFAccountManagementLinkCustomIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.CustomId, &interop->customId, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementLinkFacebookAccountRequest data model. Facebook sign-in is accomplished using
    /// the Facebook User Access Token. More information on the Token can be found in the Facebook developer
    /// documentation (https://developers.facebook.com/docs/facebook-login/access-tokens/). In Unity, for
    /// example, the Token is available as AccessToken in the Facebook SDK ScriptableObject FB. Note that
    /// titles should never re-use the same Facebook applications between PlayFab Title IDs, as Facebook provides
    /// unique user IDs per application and doing so can result in issues with the Facebook ID for the user
    /// in their PlayFab account information. If you must re-use an application in a new PlayFab Title ID,
    /// please be sure to first unlink all accounts from Facebook, or delete all users in the first Title
    /// ID.
    /// </summary>
    public struct PFAccountManagementLinkFacebookAccountRequest
    {
        /// <summary>
        /// (Optional) Unique identifier from Facebook for the user.
        /// </summary>
        public string? AccessToken;

        /// <summary>
        /// (Optional) Token used for limited login authentication.
        /// </summary>
        public string? AuthenticationToken;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        internal unsafe static void ToInterop(PFAccountManagementLinkFacebookAccountRequest self, Interop.PFAccountManagementLinkFacebookAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AccessToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AccessToken, &interop->accessToken, buffer);
            }

            if (self.AuthenticationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AuthenticationToken, &interop->authenticationToken, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementLinkFacebookInstantGamesIdRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkFacebookInstantGamesIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Facebook Instant Games signature for the user.
        /// </summary>
        public string FacebookInstantGamesSignature;

        /// <summary>
        /// (Optional) If another user is already linked to the Facebook Instant Games ID, unlink the other user
        /// and re-link.
        /// </summary>
        public bool? ForceLink;

        internal unsafe static void ToInterop(PFAccountManagementLinkFacebookInstantGamesIdRequest self, Interop.PFAccountManagementLinkFacebookInstantGamesIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.FacebookInstantGamesSignature, &interop->facebookInstantGamesSignature, buffer);

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementLinkGameCenterAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkGameCenterAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link. If
        /// the current user is already linked, link both accounts.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// Game Center identifier for the player account to be linked.
        /// </summary>
        public string GameCenterId;

        /// <summary>
        /// (Optional) The URL for the public encryption key that will be used to verify the signature.
        /// </summary>
        public string? PublicKeyUrl;

        /// <summary>
        /// (Optional) A random value used to compute the hash and keep it randomized.
        /// </summary>
        public string? Salt;

        /// <summary>
        /// (Optional) The verification signature of the authentication payload.
        /// </summary>
        public string? Signature;

        /// <summary>
        /// (Optional) The integer representation of date and time that the signature was created on. PlayFab
        /// will reject authentication signatures not within 10 minutes of the server's current time.
        /// </summary>
        public string? Timestamp;

        internal unsafe static void ToInterop(PFAccountManagementLinkGameCenterAccountRequest self, Interop.PFAccountManagementLinkGameCenterAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.GameCenterId, &interop->gameCenterId, buffer);

            if (self.PublicKeyUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PublicKeyUrl, &interop->publicKeyUrl, buffer);
            }

            if (self.Salt != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Salt, &interop->salt, buffer);
            }

            if (self.Signature != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Signature, &interop->signature, buffer);
            }

            if (self.Timestamp != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Timestamp, &interop->timestamp, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementLinkGoogleAccountRequest data model. Google sign-in is accomplished by obtaining
    /// a Google OAuth 2.0 credential using the Google sign-in for Android APIs on the device and passing
    /// it to this API.
    /// </summary>
    public struct PFAccountManagementLinkGoogleAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link. If
        /// the current user is already linked, link both accounts.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// (Optional) Server authentication code obtained on the client by calling getServerAuthCode() (https://developers.google.com/identity/sign-in/android/offline-access)
        /// from Google Play for the user.
        /// </summary>
        public string? ServerAuthCode;

        internal unsafe static void ToInterop(PFAccountManagementLinkGoogleAccountRequest self, Interop.PFAccountManagementLinkGoogleAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            if (self.ServerAuthCode != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ServerAuthCode, &interop->serverAuthCode, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementLinkGooglePlayGamesServicesAccountRequest data model. Google Play Games sign-in
    /// is accomplished by obtaining a Google OAuth 2.0 credential using the Google Play Games sign-in for
    /// Android APIs on the device and passing it to this API.
    /// </summary>
    public struct PFAccountManagementLinkGooglePlayGamesServicesAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link. If
        /// the current user is already linked, link both accounts.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// OAuth 2.0 server authentication code obtained on the client by calling the requestServerSideAccess()
        /// (https://developers.google.com/games/services/android/signin) Google Play Games client API.
        /// </summary>
        public string ServerAuthCode;

        internal unsafe static void ToInterop(PFAccountManagementLinkGooglePlayGamesServicesAccountRequest self, Interop.PFAccountManagementLinkGooglePlayGamesServicesAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.ServerAuthCode, &interop->serverAuthCode, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementLinkIOSDeviceIDRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkIOSDeviceIDRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Vendor-specific iOS identifier for the user's device.
        /// </summary>
        public string DeviceId;

        /// <summary>
        /// (Optional) Specific model of the user's device.
        /// </summary>
        public string? DeviceModel;

        /// <summary>
        /// (Optional) If another user is already linked to the device, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// (Optional) Specific Operating System version for the user's device.
        /// </summary>
        public string? OS;

        internal unsafe static void ToInterop(PFAccountManagementLinkIOSDeviceIDRequest self, Interop.PFAccountManagementLinkIOSDeviceIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.DeviceId, &interop->deviceId, buffer);

            if (self.DeviceModel != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DeviceModel, &interop->deviceModel, buffer);
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            if (self.OS != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OS, &interop->OS, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementLinkKongregateAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkKongregateAccountRequest
    {
        /// <summary>
        /// Valid session auth ticket issued by Kongregate.
        /// </summary>
        public string AuthTicket;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// Numeric user ID assigned by Kongregate.
        /// </summary>
        public string KongregateId;

        internal unsafe static void ToInterop(PFAccountManagementLinkKongregateAccountRequest self, Interop.PFAccountManagementLinkKongregateAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.AuthTicket, &interop->authTicket, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.KongregateId, &interop->kongregateId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementClientLinkNintendoServiceAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientLinkNintendoServiceAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to a specific Nintendo Switch account, unlink the other
        /// user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// The JSON Web token (JWT) returned by Nintendo after login. Used to validate the request and find
        /// the user ID (Nintendo Switch subject) to link with.
        /// </summary>
        public string IdentityToken;

        internal unsafe static void ToInterop(PFAccountManagementClientLinkNintendoServiceAccountRequest self, Interop.PFAccountManagementClientLinkNintendoServiceAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest data model.
    /// </summary>
    public struct PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the Nintendo Switch Device ID, unlink the other user
        /// and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// Nintendo Switch unique identifier for the user's device.
        /// </summary>
        public string NintendoSwitchDeviceId;

        internal unsafe static void ToInterop(PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest self, Interop.PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoSwitchDeviceId, &interop->nintendoSwitchDeviceId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementLinkOpenIdConnectRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkOpenIdConnectRequest
    {
        /// <summary>
        /// A name that identifies which configured OpenID Connect provider relationship to use. Maximum 100
        /// characters.
        /// </summary>
        public string ConnectionId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to a specific OpenId Connect user, unlink the other
        /// user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// The JSON Web token (JWT) returned by the identity provider after login. Represented as the id_token
        /// field in the identity provider's response. Used to validate the request and find the user ID (OpenID
        /// Connect subject) to link with.
        /// </summary>
        public string IdToken;

        internal unsafe static void ToInterop(PFAccountManagementLinkOpenIdConnectRequest self, Interop.PFAccountManagementLinkOpenIdConnectRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.ConnectionId, &interop->connectionId, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdToken, &interop->idToken, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementClientLinkPSNAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientLinkPSNAccountRequest
    {
        /// <summary>
        /// Authentication code provided by the PlayStation :tm: Network.
        /// </summary>
        public string AuthCode;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// (Optional) Id of the PlayStation :tm: Network issuer environment. If null, defaults to production
        /// environment.
        /// </summary>
        public int? IssuerId;

        /// <summary>
        /// Redirect URI supplied to PlayStation :tm: Network when requesting an auth code.
        /// </summary>
        public string RedirectUri;

        internal unsafe static void ToInterop(PFAccountManagementClientLinkPSNAccountRequest self, Interop.PFAccountManagementClientLinkPSNAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.AuthCode, &interop->authCode, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            if (self.IssuerId != null)
            {
                *interop->issuerId = self.IssuerId.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.RedirectUri, &interop->redirectUri, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementLinkSteamAccountRequest data model. Steam authentication is accomplished with
    /// the Steam Session Ticket. More information on the Ticket can be found in the Steamworks SDK, here:
    /// https://partner.steamgames.com/documentation/auth (requires sign-in). NOTE: For Steam authentication
    /// to work, the title must be configured with the Steam Application ID and Publisher Key in the PlayFab
    /// Game Manager (under Properties). Information on creating a Publisher Key (referred to as the Secret
    /// Key in PlayFab) for your title can be found here: https://partner.steamgames.com/documentation/webapi#publisherkey.
    /// </summary>
    public struct PFAccountManagementLinkSteamAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// Authentication token for the user, returned as a byte array from Steam, and converted to a string
        /// (for example, the byte 0x08 should become "08").
        /// </summary>
        public string SteamTicket;

        /// <summary>
        /// (Optional) True if ticket was generated using ISteamUser::GetAuthTicketForWebAPI() using "AzurePlayFab"
        /// as the identity string. False if the ticket was generated with ISteamUser::GetAuthSessionTicket().
        /// </summary>
        public bool? TicketIsServiceSpecific;

        internal unsafe static void ToInterop(PFAccountManagementLinkSteamAccountRequest self, Interop.PFAccountManagementLinkSteamAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.SteamTicket, &interop->steamTicket, buffer);

            if (self.TicketIsServiceSpecific != null)
            {
                *interop->ticketIsServiceSpecific = InteropWrapper.WrapperHelpers.BoolToInterop(self.TicketIsServiceSpecific.Value);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementClientLinkTwitchAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientLinkTwitchAccountRequest
    {
        /// <summary>
        /// Valid token issued by Twitch.
        /// </summary>
        public string AccessToken;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        internal unsafe static void ToInterop(PFAccountManagementClientLinkTwitchAccountRequest self, Interop.PFAccountManagementClientLinkTwitchAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.AccessToken, &interop->accessToken, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementClientLinkXboxAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientLinkXboxAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

#if MICROSOFT_GDK_SUPPORT
        /// <summary>
        /// XUser of the account to link to.
        /// When using the Microsoft GDK Unity API, this is the Handle property or the value returned from DangerousGetHandle() of the XUserHandle object acquired from the XUserAddAsync or XUserAddByIdWithUiAsync methods.
        /// </summary>
        public IntPtr UserHandle;
#endif

        internal unsafe static void ToInterop(PFAccountManagementClientLinkXboxAccountRequest self, Interop.PFAccountManagementClientLinkXboxAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

#if MICROSOFT_GDK_SUPPORT
            interop->user = self.UserHandle;
#endif

        }
    }

    /// <summary>
    /// PFAccountManagementRemoveContactEmailRequest data model. This API removes an existing contact email
    /// from the player's profile.
    /// </summary>
    public struct PFAccountManagementRemoveContactEmailRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementRemoveContactEmailRequest self, Interop.PFAccountManagementRemoveContactEmailRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementReportPlayerClientRequest data model.
    /// </summary>
    public struct PFAccountManagementReportPlayerClientRequest
    {
        /// <summary>
        /// (Optional) Optional additional comment by reporting player.
        /// </summary>
        public string? Comment;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab identifier of the reported player.
        /// </summary>
        public string ReporteeId;

        internal unsafe static void ToInterop(PFAccountManagementReportPlayerClientRequest self, Interop.PFAccountManagementReportPlayerClientRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Comment != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Comment, &interop->comment, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.ReporteeId, &interop->reporteeId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementReportPlayerClientResult data model. Players are currently limited to five reports
    /// per day. Attempts by a single user account to submit reports beyond five will result in Updated being
    /// returned as false.
    /// </summary>
    public struct PFAccountManagementReportPlayerClientResult
    {
        /// <summary>
        /// The number of remaining reports which may be filed today.
        /// </summary>
        public int SubmissionsRemaining;

        internal unsafe PFAccountManagementReportPlayerClientResult(Interop.PFAccountManagementReportPlayerClientResult interop)
        {

            SubmissionsRemaining = interop.submissionsRemaining;

        }
    }

    /// <summary>
    /// PFAccountManagementSendAccountRecoveryEmailRequest data model. If the account in question is a "temporary"
    /// account (for example, one that was created via a call to LoginFromIOSDeviceID), thisfunction will
    /// have no effect. Only PlayFab accounts which have valid email addresses will be able to receive a password
    /// reset email using this API.
    /// </summary>
    public struct PFAccountManagementSendAccountRecoveryEmailRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// User email address attached to their account.
        /// </summary>
        public string Email;

        /// <summary>
        /// (Optional) The email template id of the account recovery email template to send.
        /// </summary>
        public string? EmailTemplateId;

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer
        /// site when a title has been selected.
        /// </summary>
        public string TitleId;

        internal unsafe static void ToInterop(PFAccountManagementSendAccountRecoveryEmailRequest self, Interop.PFAccountManagementSendAccountRecoveryEmailRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Email, &interop->email, buffer);

            if (self.EmailTemplateId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EmailTemplateId, &interop->emailTemplateId, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.TitleId, &interop->titleId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementUnlinkAndroidDeviceIDRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkAndroidDeviceIDRequest
    {
        /// <summary>
        /// (Optional) Android device identifier for the user's device. If not specified, the most recently signed
        /// in Android Device ID will be used.
        /// </summary>
        public string? AndroidDeviceId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkAndroidDeviceIDRequest self, Interop.PFAccountManagementUnlinkAndroidDeviceIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AndroidDeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AndroidDeviceId, &interop->androidDeviceId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementUnlinkAppleRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkAppleRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkAppleRequest self, Interop.PFAccountManagementUnlinkAppleRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementClientUnlinkBattleNetAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUnlinkBattleNetAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementClientUnlinkBattleNetAccountRequest self, Interop.PFAccountManagementClientUnlinkBattleNetAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementUnlinkCustomIDRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkCustomIDRequest
    {
        /// <summary>
        /// (Optional) Custom unique identifier for the user, generated by the title. If not specified, the most
        /// recently signed in Custom ID will be used.
        /// </summary>
        public string? CustomId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkCustomIDRequest self, Interop.PFAccountManagementUnlinkCustomIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CustomId, &interop->customId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementClientUnlinkFacebookAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUnlinkFacebookAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementClientUnlinkFacebookAccountRequest self, Interop.PFAccountManagementClientUnlinkFacebookAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Facebook Instant Games identifier for the user. If not specified, the most recently signed
        /// in ID will be used.
        /// </summary>
        public string? FacebookInstantGamesId;

        internal unsafe static void ToInterop(PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest self, Interop.PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.FacebookInstantGamesId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FacebookInstantGamesId, &interop->facebookInstantGamesId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementUnlinkGameCenterAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkGameCenterAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkGameCenterAccountRequest self, Interop.PFAccountManagementUnlinkGameCenterAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementUnlinkGoogleAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkGoogleAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkGoogleAccountRequest self, Interop.PFAccountManagementUnlinkGoogleAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest self, Interop.PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementUnlinkIOSDeviceIDRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkIOSDeviceIDRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Vendor-specific iOS identifier for the user's device. If not specified, the most recently
        /// signed in iOS Device ID will be used.
        /// </summary>
        public string? DeviceId;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkIOSDeviceIDRequest self, Interop.PFAccountManagementUnlinkIOSDeviceIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.DeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DeviceId, &interop->deviceId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementUnlinkKongregateAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkKongregateAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkKongregateAccountRequest self, Interop.PFAccountManagementUnlinkKongregateAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementClientUnlinkNintendoServiceAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUnlinkNintendoServiceAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementClientUnlinkNintendoServiceAccountRequest self, Interop.PFAccountManagementClientUnlinkNintendoServiceAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Nintendo Switch Device identifier for the user. If not specified, the most recently signed
        /// in device ID will be used.
        /// </summary>
        public string? NintendoSwitchDeviceId;

        internal unsafe static void ToInterop(PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest self, Interop.PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.NintendoSwitchDeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoSwitchDeviceId, &interop->nintendoSwitchDeviceId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementUnlinkOpenIdConnectRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkOpenIdConnectRequest
    {
        /// <summary>
        /// A name that identifies which configured OpenID Connect provider relationship to use. Maximum 100
        /// characters.
        /// </summary>
        public string ConnectionId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkOpenIdConnectRequest self, Interop.PFAccountManagementUnlinkOpenIdConnectRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.ConnectionId, &interop->connectionId, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementClientUnlinkPSNAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUnlinkPSNAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementClientUnlinkPSNAccountRequest self, Interop.PFAccountManagementClientUnlinkPSNAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementUnlinkSteamAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkSteamAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkSteamAccountRequest self, Interop.PFAccountManagementUnlinkSteamAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementClientUnlinkTwitchAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUnlinkTwitchAccountRequest
    {
        /// <summary>
        /// (Optional) Valid token issued by Twitch. Used to specify which twitch account to unlink from the
        /// profile. By default it uses the one that is present on the profile.
        /// </summary>
        public string? AccessToken;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementClientUnlinkTwitchAccountRequest self, Interop.PFAccountManagementClientUnlinkTwitchAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AccessToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AccessToken, &interop->accessToken, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementClientUnlinkXboxAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUnlinkXboxAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementClientUnlinkXboxAccountRequest self, Interop.PFAccountManagementClientUnlinkXboxAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFAccountManagementClientUpdateAvatarUrlRequest data model.
    /// </summary>
    public struct PFAccountManagementClientUpdateAvatarUrlRequest
    {
        /// <summary>
        /// URL of the avatar image. If empty, it removes the existing avatar URL.
        /// </summary>
        public string ImageUrl;

        internal unsafe static void ToInterop(PFAccountManagementClientUpdateAvatarUrlRequest self, Interop.PFAccountManagementClientUpdateAvatarUrlRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.ImageUrl, &interop->imageUrl, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementUpdateUserTitleDisplayNameRequest data model. In addition to the PlayFab username,
    /// titles can make use of a DisplayName which is also a unique identifier, but specific to the title.
    /// This allows for unique names which more closely match the theme or genre of a title, for example.
    /// </summary>
    public struct PFAccountManagementUpdateUserTitleDisplayNameRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// New title display name for the user - must be between 3 and 25 characters.
        /// </summary>
        public string DisplayName;

        internal unsafe static void ToInterop(PFAccountManagementUpdateUserTitleDisplayNameRequest self, Interop.PFAccountManagementUpdateUserTitleDisplayNameRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayName, &interop->displayName, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementUpdateUserTitleDisplayNameResult data model.
    /// </summary>
    public struct PFAccountManagementUpdateUserTitleDisplayNameResult
    {
        /// <summary>
        /// (Optional) Current title display name for the user (this will be the original display name if the
        /// rename attempt failed).
        /// </summary>
        public string? DisplayName;

        internal unsafe PFAccountManagementUpdateUserTitleDisplayNameResult(Interop.PFAccountManagementUpdateUserTitleDisplayNameResult interop)
        {

            DisplayName = (interop.displayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.displayName);

        }
    }

    /// <summary>
    /// PFAccountManagementBanRequest data model. Represents a single ban request.
    /// </summary>
    public struct PFAccountManagementBanRequest
    {
        /// <summary>
        /// (Optional) The duration in hours for the ban. Leave this blank for a permanent ban.
        /// </summary>
        public uint? DurationInHours;

        /// <summary>
        /// (Optional) IP address to be banned. May affect multiple players.
        /// </summary>
        public string? IPAddress;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// (Optional) The reason for this ban. Maximum 140 characters.
        /// </summary>
        public string? Reason;

        /// <summary>
        /// (Optional) The family type of the user that should be included in the ban if applicable. May affect
        /// multiple players.
        /// </summary>
        public PFAccountManagementUserFamilyType? UserFamilyType;

        internal unsafe PFAccountManagementBanRequest(Interop.PFAccountManagementBanRequest interop)
        {

            DurationInHours = (interop.durationInHours == null) ? null : *interop.durationInHours;

            IPAddress = (interop.IPAddress == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.IPAddress);

            PlayFabId = InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId)!;

            Reason = (interop.reason == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.reason);

            UserFamilyType = (interop.userFamilyType == null) ? null : (PFAccountManagementUserFamilyType?)(*interop.userFamilyType);

        }

        internal unsafe static void ToInterop(PFAccountManagementBanRequest self, Interop.PFAccountManagementBanRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.DurationInHours != null)
            {
                *interop->durationInHours = self.DurationInHours.Value;
            }

            if (self.IPAddress != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IPAddress, &interop->IPAddress, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            if (self.Reason != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Reason, &interop->reason, buffer);
            }

            if (self.UserFamilyType != null)
            {
                *interop->userFamilyType = (Interop.PFAccountManagementUserFamilyType)self.UserFamilyType.Value;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementBanUsersRequest data model. The existence of each user will not be verified. When
    /// banning by IP, multiple players may be affected, so use this feature with caution. Returns information
    /// about the new bans.
    /// </summary>
    public struct PFAccountManagementBanUsersRequest
    {
        /// <summary>
        /// List of ban requests to be applied. Maximum 100.
        /// </summary>
        public PFAccountManagementBanRequest[] Bans;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAccountManagementBanUsersRequest self, Interop.PFAccountManagementBanUsersRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Bans, &interop->bans, buffer, PFAccountManagementBanRequest.ToInterop);
            interop->bansCount = (uint)self.Bans.Length;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementBanInfo data model. Contains information for a ban.
    /// </summary>
    public struct PFAccountManagementBanInfo
    {
        /// <summary>
        /// The active state of this ban. Expired bans may still have this value set to true but they will have
        /// no effect.
        /// </summary>
        public bool Active;

        /// <summary>
        /// (Optional) The unique Ban Id associated with this ban.
        /// </summary>
        public string? BanId;

        /// <summary>
        /// (Optional) The time when this ban was applied.
        /// </summary>
        public long? Created;

        /// <summary>
        /// (Optional) The time when this ban expires. Permanent bans do not have expiration date.
        /// </summary>
        public long? Expires;

        /// <summary>
        /// (Optional) The IP address on which the ban was applied. May affect multiple players.
        /// </summary>
        public string? IPAddress;

        /// <summary>
        /// (Optional) Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) The reason why this ban was applied.
        /// </summary>
        public string? Reason;

        /// <summary>
        /// (Optional) The family type of the user that is included in the ban.
        /// </summary>
        public string? UserFamilyType;

        internal unsafe PFAccountManagementBanInfo(Interop.PFAccountManagementBanInfo interop)
        {

            Active = InteropWrapper.WrapperHelpers.InteropToBool(interop.active);

            BanId = (interop.banId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.banId);

            Created = (interop.created == null) ? null : *interop.created;

            Expires = (interop.expires == null) ? null : *interop.expires;

            IPAddress = (interop.IPAddress == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.IPAddress);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            Reason = (interop.reason == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.reason);

            UserFamilyType = (interop.userFamilyType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.userFamilyType);

        }

        internal unsafe static void ToInterop(PFAccountManagementBanInfo self, Interop.PFAccountManagementBanInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->active = InteropWrapper.WrapperHelpers.BoolToInterop(self.Active);

            if (self.BanId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.BanId, &interop->banId, buffer);
            }

            if (self.Created != null)
            {
                *interop->created = self.Created.Value;
            }

            if (self.Expires != null)
            {
                *interop->expires = self.Expires.Value;
            }

            if (self.IPAddress != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IPAddress, &interop->IPAddress, buffer);
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.Reason != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Reason, &interop->reason, buffer);
            }

            if (self.UserFamilyType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.UserFamilyType, &interop->userFamilyType, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementBanUsersResult data model.
    /// </summary>
    public struct PFAccountManagementBanUsersResult
    {
        /// <summary>
        /// (Optional) Information on the bans that were applied.
        /// </summary>
        public PFAccountManagementBanInfo[]? BanData;

        internal unsafe PFAccountManagementBanUsersResult(Interop.PFAccountManagementBanUsersResult interop)
        {

            BanData = (interop.banData == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.banData, interop.banDataCount, elem => new PFAccountManagementBanInfo(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementDeletePlayerRequest data model. Deletes all data associated with the player, including
    /// statistics, custom data, inventory, purchases, virtual currency balances, characters and shared group
    /// memberships. Removes the player from all leaderboards and player search indexes. Does not delete PlayStream
    /// event history associated with the player. Does not delete the publisher user account that created
    /// the player in the title nor associated data such as username, password, email address, account linkages,
    /// or friends list. Note, this API queues the player for deletion and returns immediately. It may take
    /// several minutes or more before all player data is fully deleted. Until the player data is fully deleted,
    /// attempts to recreate the player with the same user account in the same title will fail with the 'AccountDeleted'
    /// error. This API must be enabled for use as an option in the game manager website. It is disabled by
    /// default.
    /// </summary>
    public struct PFAccountManagementDeletePlayerRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementDeletePlayerRequest self, Interop.PFAccountManagementDeletePlayerRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest data model.
    /// </summary>
    public struct PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest
    {
        /// <summary>
        /// Array of unique PlayFab player identifiers for which the title needs to get server custom identifiers.
        /// Cannot contain more than 25 identifiers.
        /// </summary>
        public string[] PlayFabIDs;

        internal unsafe static void ToInterop(PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest self, Interop.PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.PlayFabIDs, &interop->playFabIDs, buffer);
            interop->playFabIDsCount = (uint)self.PlayFabIDs.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementServerCustomIDPlayFabIDPair data model.
    /// </summary>
    public struct PFAccountManagementServerCustomIDPlayFabIDPair
    {
        /// <summary>
        /// (Optional) Unique PlayFab identifier.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Unique server custom identifier for this player.
        /// </summary>
        public string? ServerCustomId;

        internal unsafe PFAccountManagementServerCustomIDPlayFabIDPair(Interop.PFAccountManagementServerCustomIDPlayFabIDPair interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            ServerCustomId = (interop.serverCustomId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.serverCustomId);

        }

        internal unsafe static void ToInterop(PFAccountManagementServerCustomIDPlayFabIDPair self, Interop.PFAccountManagementServerCustomIDPlayFabIDPair* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.ServerCustomId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ServerCustomId, &interop->serverCustomId, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult data model. For a PlayFab account that
    /// isn't associated with a server custom identity, ServerCustomId will be null.
    /// </summary>
    public struct PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult
    {
        /// <summary>
        /// (Optional) Mapping of server custom player identifiers to PlayFab identifiers.
        /// </summary>
        public PFAccountManagementServerCustomIDPlayFabIDPair[]? Data;

        internal unsafe PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult(Interop.PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.data, interop.dataCount, elem => new PFAccountManagementServerCustomIDPlayFabIDPair(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetUserAccountInfoRequest data model. This API allows for access to details regarding
    /// a user in the PlayFab service, usually for purposes of customer support. Note that data returned may
    /// be Personally Identifying Information (PII), such as email address, and so care should be taken in
    /// how this data is stored and managed. Since this call will always return the relevant information for
    /// users who have accessed the title, the recommendation is to not store this data locally.
    /// </summary>
    public struct PFAccountManagementGetUserAccountInfoRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementGetUserAccountInfoRequest self, Interop.PFAccountManagementGetUserAccountInfoRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementGetUserAccountInfoResult data model.
    /// </summary>
    public struct PFAccountManagementGetUserAccountInfoResult
    {
        /// <summary>
        /// (Optional) Account details for the user whose information was requested.
        /// </summary>
        public PFUserAccountInfo? UserInfo;

        internal unsafe PFAccountManagementGetUserAccountInfoResult(Interop.PFAccountManagementGetUserAccountInfoResult interop)
        {

            UserInfo = (interop.userInfo == null) ? null : new(*interop.userInfo);

        }
    }

    /// <summary>
    /// PFAccountManagementGetUserBansRequest data model. Get all bans for a user, including inactive and
    /// expired bans. .
    /// </summary>
    public struct PFAccountManagementGetUserBansRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementGetUserBansRequest self, Interop.PFAccountManagementGetUserBansRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementGetUserBansResult data model.
    /// </summary>
    public struct PFAccountManagementGetUserBansResult
    {
        /// <summary>
        /// (Optional) Information about the bans.
        /// </summary>
        public PFAccountManagementBanInfo[]? BanData;

        internal unsafe PFAccountManagementGetUserBansResult(Interop.PFAccountManagementGetUserBansResult interop)
        {

            BanData = (interop.banData == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.banData, interop.banDataCount, elem => new PFAccountManagementBanInfo(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementServerLinkBattleNetAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementServerLinkBattleNetAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to a specific Battle.net account, unlink the other user
        /// and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// The JSON Web Token (JWT) returned by Battle.net after login.
        /// </summary>
        public string IdentityToken;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerLinkBattleNetAccountRequest self, Interop.PFAccountManagementServerLinkBattleNetAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerLinkNintendoServiceAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementServerLinkNintendoServiceAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to a specific Nintendo Switch account, unlink the other
        /// user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// The JSON Web token (JWT) returned by Nintendo after login. Used to validate the request and find
        /// the user ID (Nintendo Switch subject) to link with.
        /// </summary>
        public string IdentityToken;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerLinkNintendoServiceAccountRequest self, Interop.PFAccountManagementServerLinkNintendoServiceAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementLinkNintendoServiceAccountSubjectRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkNintendoServiceAccountSubjectRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to a specific Nintendo Service Account, unlink the other
        /// user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// The Nintendo Service Account subject or id to link to the PlayFab user.
        /// </summary>
        public string Subject;

        internal unsafe static void ToInterop(PFAccountManagementLinkNintendoServiceAccountSubjectRequest self, Interop.PFAccountManagementLinkNintendoServiceAccountSubjectRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.Subject, &interop->subject, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest data model.
    /// </summary>
    public struct PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the Nintendo Switch Device ID, unlink the other user
        /// and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// Nintendo Switch unique identifier for the user's device.
        /// </summary>
        public string NintendoSwitchDeviceId;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest self, Interop.PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoSwitchDeviceId, &interop->nintendoSwitchDeviceId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerLinkPSNAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementServerLinkPSNAccountRequest
    {
        /// <summary>
        /// Authentication code provided by the PlayStation :tm: Network.
        /// </summary>
        public string AuthCode;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// (Optional) Id of the PlayStation :tm: Network issuer environment. If null, defaults to production
        /// environment.
        /// </summary>
        public int? IssuerId;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Redirect URI supplied to PlayStation :tm: Network when requesting an auth code.
        /// </summary>
        public string RedirectUri;

        internal unsafe static void ToInterop(PFAccountManagementServerLinkPSNAccountRequest self, Interop.PFAccountManagementServerLinkPSNAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.AuthCode, &interop->authCode, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            if (self.IssuerId != null)
            {
                *interop->issuerId = self.IssuerId.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.RedirectUri, &interop->redirectUri, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementLinkPSNIdRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkPSNIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// (Optional) Id of the PlayStation :tm: Network issuer environment. If null, defaults to production
        /// environment.
        /// </summary>
        public int? IssuerId;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Id of the PlayStation :tm: Network user. Also known as the PSN Account Id.
        /// </summary>
        public string PSNUserId;

        internal unsafe static void ToInterop(PFAccountManagementLinkPSNIdRequest self, Interop.PFAccountManagementLinkPSNIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            if (self.IssuerId != null)
            {
                *interop->issuerId = self.IssuerId.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PSNUserId, &interop->PSNUserId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementLinkServerCustomIdRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkServerCustomIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the custom ID, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// Unique PlayFab identifier.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique server custom identifier for this player.
        /// </summary>
        public string ServerCustomId;

        internal unsafe static void ToInterop(PFAccountManagementLinkServerCustomIdRequest self, Interop.PFAccountManagementLinkServerCustomIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.ServerCustomId, &interop->serverCustomId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementLinkSteamIdRequest data model.
    /// </summary>
    public struct PFAccountManagementLinkSteamIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// PlayFab unique identifier of the user to link.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamId;

        internal unsafe static void ToInterop(PFAccountManagementLinkSteamIdRequest self, Interop.PFAccountManagementLinkSteamIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.SteamId, &interop->steamId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerLinkXboxAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementServerLinkXboxAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;

        /// <summary>
        /// PlayFab unique identifier of the user to link.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Token provided by the Xbox Live SDK/XDK method GetTokenAndSignatureAsync("POST", "https://playfabapi.com/",
        /// "").
        /// </summary>
        public string XboxToken;

        internal unsafe static void ToInterop(PFAccountManagementServerLinkXboxAccountRequest self, Interop.PFAccountManagementServerLinkXboxAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ForceLink != null)
            {
                *interop->forceLink = InteropWrapper.WrapperHelpers.BoolToInterop(self.ForceLink.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.XboxToken, &interop->xboxToken, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementRevokeAllBansForUserRequest data model. Setting the active state of all non-expired
    /// bans for a user to Inactive. Expired bans with an Active state will be ignored, however. Returns information
    /// about applied updates only.
    /// </summary>
    public struct PFAccountManagementRevokeAllBansForUserRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementRevokeAllBansForUserRequest self, Interop.PFAccountManagementRevokeAllBansForUserRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementRevokeAllBansForUserResult data model.
    /// </summary>
    public struct PFAccountManagementRevokeAllBansForUserResult
    {
        /// <summary>
        /// (Optional) Information on the bans that were revoked.
        /// </summary>
        public PFAccountManagementBanInfo[]? BanData;

        internal unsafe PFAccountManagementRevokeAllBansForUserResult(Interop.PFAccountManagementRevokeAllBansForUserResult interop)
        {

            BanData = (interop.banData == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.banData, interop.banDataCount, elem => new PFAccountManagementBanInfo(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementRevokeBansRequest data model. Setting the active state of all bans requested to
    /// Inactive regardless of whether that ban has already expired. BanIds that do not exist will be skipped.
    /// Returns information about applied updates only. .
    /// </summary>
    public struct PFAccountManagementRevokeBansRequest
    {
        /// <summary>
        /// Ids of the bans to be revoked. Maximum 100.
        /// </summary>
        public string[] BanIds;

        internal unsafe static void ToInterop(PFAccountManagementRevokeBansRequest self, Interop.PFAccountManagementRevokeBansRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.BanIds, &interop->banIds, buffer);
            interop->banIdsCount = (uint)self.BanIds.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementRevokeBansResult data model.
    /// </summary>
    public struct PFAccountManagementRevokeBansResult
    {
        /// <summary>
        /// (Optional) Information on the bans that were revoked.
        /// </summary>
        public PFAccountManagementBanInfo[]? BanData;

        internal unsafe PFAccountManagementRevokeBansResult(Interop.PFAccountManagementRevokeBansResult interop)
        {

            BanData = (interop.banData == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.banData, interop.banDataCount, elem => new PFAccountManagementBanInfo(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementSendCustomAccountRecoveryEmailRequest data model. PlayFab accounts which have
    /// valid email address or username will be able to receive a password reset email using this API.The
    /// email sent must be an account recovery email template. The username or email can be passed in to send
    /// the email.
    /// </summary>
    public struct PFAccountManagementSendCustomAccountRecoveryEmailRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) User email address attached to their account.
        /// </summary>
        public string? Email;

        /// <summary>
        /// The email template id of the account recovery email template to send.
        /// </summary>
        public string EmailTemplateId;

        /// <summary>
        /// (Optional) The user's username requesting an account recovery.
        /// </summary>
        public string? Username;

        internal unsafe static void ToInterop(PFAccountManagementSendCustomAccountRecoveryEmailRequest self, Interop.PFAccountManagementSendCustomAccountRecoveryEmailRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Email != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Email, &interop->email, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.EmailTemplateId, &interop->emailTemplateId, buffer);

            if (self.Username != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Username, &interop->username, buffer);
            }

        }
    }

    /// <summary>
    /// PFAccountManagementSendEmailFromTemplateRequest data model. Sends an email for only players that
    /// have contact emails associated with them. Takes in an email template ID specifyingthe email template
    /// to send.
    /// </summary>
    public struct PFAccountManagementSendEmailFromTemplateRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The email template id of the email template to send.
        /// </summary>
        public string EmailTemplateId;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementSendEmailFromTemplateRequest self, Interop.PFAccountManagementSendEmailFromTemplateRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.EmailTemplateId, &interop->emailTemplateId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerUnlinkBattleNetAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementServerUnlinkBattleNetAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerUnlinkBattleNetAccountRequest self, Interop.PFAccountManagementServerUnlinkBattleNetAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerUnlinkNintendoServiceAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementServerUnlinkNintendoServiceAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerUnlinkNintendoServiceAccountRequest self, Interop.PFAccountManagementServerUnlinkNintendoServiceAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest data model.
    /// </summary>
    public struct PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Nintendo Switch Device identifier for the user. If not specified, the most recently signed
        /// in device ID will be used.
        /// </summary>
        public string? NintendoSwitchDeviceId;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest self, Interop.PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.NintendoSwitchDeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoSwitchDeviceId, &interop->nintendoSwitchDeviceId, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerUnlinkPSNAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementServerUnlinkPSNAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerUnlinkPSNAccountRequest self, Interop.PFAccountManagementServerUnlinkPSNAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementUnlinkServerCustomIdRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkServerCustomIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab identifier.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique server custom identifier for this player.
        /// </summary>
        public string ServerCustomId;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkServerCustomIdRequest self, Interop.PFAccountManagementUnlinkServerCustomIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.ServerCustomId, &interop->serverCustomId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementUnlinkSteamIdRequest data model.
    /// </summary>
    public struct PFAccountManagementUnlinkSteamIdRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam account.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementUnlinkSteamIdRequest self, Interop.PFAccountManagementUnlinkSteamIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerUnlinkXboxAccountRequest data model.
    /// </summary>
    public struct PFAccountManagementServerUnlinkXboxAccountRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// PlayFab unique identifier of the user to unlink.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerUnlinkXboxAccountRequest self, Interop.PFAccountManagementServerUnlinkXboxAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementServerUpdateAvatarUrlRequest data model.
    /// </summary>
    public struct PFAccountManagementServerUpdateAvatarUrlRequest
    {
        /// <summary>
        /// URL of the avatar image. If empty, it removes the existing avatar URL.
        /// </summary>
        public string ImageUrl;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFAccountManagementServerUpdateAvatarUrlRequest self, Interop.PFAccountManagementServerUpdateAvatarUrlRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.ImageUrl, &interop->imageUrl, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFAccountManagementUpdateBanRequest data model. Represents a single update ban request.
    /// </summary>
    public struct PFAccountManagementUpdateBanRequest
    {
        /// <summary>
        /// (Optional) The updated active state for the ban. Null for no change.
        /// </summary>
        public bool? Active;

        /// <summary>
        /// The id of the ban to be updated.
        /// </summary>
        public string BanId;

        /// <summary>
        /// (Optional) The updated expiration date for the ban. Null for no change.
        /// </summary>
        public long? Expires;

        /// <summary>
        /// (Optional) The updated IP address for the ban. Null for no change.
        /// </summary>
        public string? IPAddress;

        /// <summary>
        /// (Optional) Whether to make this ban permanent. Set to true to make this ban permanent. This will
        /// not modify Active state.
        /// </summary>
        public bool? Permanent;

        /// <summary>
        /// (Optional) The updated reason for the ban to be updated. Maximum 140 characters. Null for no change.
        /// </summary>
        public string? Reason;

        /// <summary>
        /// (Optional) The updated family type of the user that should be included in the ban. Null for no change.
        /// </summary>
        public PFAccountManagementUserFamilyType? UserFamilyType;

        internal unsafe PFAccountManagementUpdateBanRequest(Interop.PFAccountManagementUpdateBanRequest interop)
        {

            Active = (interop.active == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.active);

            BanId = InteropWrapper.WrapperHelpers.InteropToString(interop.banId)!;

            Expires = (interop.expires == null) ? null : *interop.expires;

            IPAddress = (interop.IPAddress == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.IPAddress);

            Permanent = (interop.permanent == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.permanent);

            Reason = (interop.reason == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.reason);

            UserFamilyType = (interop.userFamilyType == null) ? null : (PFAccountManagementUserFamilyType?)(*interop.userFamilyType);

        }

        internal unsafe static void ToInterop(PFAccountManagementUpdateBanRequest self, Interop.PFAccountManagementUpdateBanRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Active != null)
            {
                *interop->active = InteropWrapper.WrapperHelpers.BoolToInterop(self.Active.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.BanId, &interop->banId, buffer);

            if (self.Expires != null)
            {
                *interop->expires = self.Expires.Value;
            }

            if (self.IPAddress != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IPAddress, &interop->IPAddress, buffer);
            }

            if (self.Permanent != null)
            {
                *interop->permanent = InteropWrapper.WrapperHelpers.BoolToInterop(self.Permanent.Value);
            }

            if (self.Reason != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Reason, &interop->reason, buffer);
            }

            if (self.UserFamilyType != null)
            {
                *interop->userFamilyType = (Interop.PFAccountManagementUserFamilyType)self.UserFamilyType.Value;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementUpdateBansRequest data model. For each ban, only updates the values that are set.
    /// Leave any value to null for no change. If a ban could not be found, the rest are still applied. Returns
    /// information about applied updates only.
    /// </summary>
    public struct PFAccountManagementUpdateBansRequest
    {
        /// <summary>
        /// List of bans to be updated. Maximum 100.
        /// </summary>
        public PFAccountManagementUpdateBanRequest[] Bans;

        internal unsafe static void ToInterop(PFAccountManagementUpdateBansRequest self, Interop.PFAccountManagementUpdateBansRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Bans, &interop->bans, buffer, PFAccountManagementUpdateBanRequest.ToInterop);
            interop->bansCount = (uint)self.Bans.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementUpdateBansResult data model.
    /// </summary>
    public struct PFAccountManagementUpdateBansResult
    {
        /// <summary>
        /// (Optional) Information on the bans that were updated.
        /// </summary>
        public PFAccountManagementBanInfo[]? BanData;

        internal unsafe PFAccountManagementUpdateBansResult(Interop.PFAccountManagementUpdateBansResult interop)
        {

            BanData = (interop.banData == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.banData, interop.banDataCount, elem => new PFAccountManagementBanInfo(elem));

        }
    }

    /// <summary>
    /// PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest data model. Given a collection of Xbox IDs
    /// (XUIDs), returns all title player accounts.
    /// </summary>
    public struct PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Xbox Sandbox the players had on their Xbox tokens.
        /// </summary>
        public string Sandbox;

        /// <summary>
        /// (Optional) Optional ID of title to get players from, required if calling using a master_player_account.
        /// </summary>
        public string? TitleId;

        /// <summary>
        /// List of Xbox Live XUIDs.
        /// </summary>
        public string[] XboxLiveIds;

        internal unsafe static void ToInterop(PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest self, Interop.PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Sandbox, &interop->sandbox, buffer);

            if (self.TitleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TitleId, &interop->titleId, buffer);
            }

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.XboxLiveIds, &interop->xboxLiveIds, buffer);
            interop->xboxLiveIdsCount = (uint)self.XboxLiveIds.Length;

        }
    }

    /// <summary>
    /// PFAccountManagementGetTitlePlayersFromProviderIDsResponse data model.
    /// </summary>
    public struct PFAccountManagementGetTitlePlayersFromProviderIDsResponse
    {
        /// <summary>
        /// (Optional) Dictionary of provider identifiers mapped to title_player_account lineage. Missing lineage
        /// indicates the player either doesn't exist or doesn't play the requested title.
        /// </summary>
        public Dictionary<string, PFEntityLineage>? TitlePlayerAccounts;

        internal unsafe PFAccountManagementGetTitlePlayersFromProviderIDsResponse(Interop.PFAccountManagementGetTitlePlayersFromProviderIDsResponse interop)
        {

            TitlePlayerAccounts = (interop.titlePlayerAccounts == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.titlePlayerAccounts, interop.titlePlayerAccountsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFEntityLineage(*pair.value)));

        }
    }

    /// <summary>
    /// PFAccountManagementSetDisplayNameRequest data model. Given an entity profile, will update its display
    /// name to the one passed in if the profile's version is equal to the specified value.
    /// </summary>
    public struct PFAccountManagementSetDisplayNameRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The new value to be set on Entity Profile's display name.
        /// </summary>
        public string? DisplayName;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The expected version of a profile to perform this update on.
        /// </summary>
        public int? ExpectedVersion;

        internal unsafe static void ToInterop(PFAccountManagementSetDisplayNameRequest self, Interop.PFAccountManagementSetDisplayNameRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.DisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayName, &interop->displayName, buffer);
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            if (self.ExpectedVersion != null)
            {
                *interop->expectedVersion = self.ExpectedVersion.Value;
            }

        }
    }

    /// <summary>
    /// PFAccountManagementSetDisplayNameResponse data model.
    /// </summary>
    public struct PFAccountManagementSetDisplayNameResponse
    {
        /// <summary>
        /// (Optional) The type of operation that occured on the profile's display name.
        /// </summary>
        public PFOperationTypes? OperationResult;

        /// <summary>
        /// (Optional) The updated version of the profile after the display name update.
        /// </summary>
        public int? VersionNumber;

        internal unsafe PFAccountManagementSetDisplayNameResponse(Interop.PFAccountManagementSetDisplayNameResponse interop)
        {

            OperationResult = (interop.operationResult == null) ? null : (PFOperationTypes?)(*interop.operationResult);

            VersionNumber = (interop.versionNumber == null) ? null : *interop.versionNumber;

        }
    }

}
