// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// ExternalFriendSources enum.
    /// </summary>
    public enum PFFriendsExternalFriendSources : uint
    {
        None = Interop.PFFriendsExternalFriendSources.None,
        Steam = Interop.PFFriendsExternalFriendSources.Steam,
        Facebook = Interop.PFFriendsExternalFriendSources.Facebook,
        Xbox = Interop.PFFriendsExternalFriendSources.Xbox,
        Psn = Interop.PFFriendsExternalFriendSources.Psn,
        All = Interop.PFFriendsExternalFriendSources.All
    }

    /// <summary>
    /// PFFriendsClientAddFriendRequest data model.
    /// </summary>
    public struct PFFriendsClientAddFriendRequest
    {
        /// <summary>
        /// (Optional) Email address of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string? FriendEmail;

        /// <summary>
        /// (Optional) PlayFab identifier of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string? FriendPlayFabId;

        /// <summary>
        /// (Optional) Title-specific display name of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string? FriendTitleDisplayName;

        /// <summary>
        /// (Optional) PlayFab username of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string? FriendUsername;

        internal unsafe static void ToInterop(PFFriendsClientAddFriendRequest self, Interop.PFFriendsClientAddFriendRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FriendEmail != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendEmail, &interop->friendEmail, buffer);
            }

            if (self.FriendPlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendPlayFabId, &interop->friendPlayFabId, buffer);
            }

            if (self.FriendTitleDisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendTitleDisplayName, &interop->friendTitleDisplayName, buffer);
            }

            if (self.FriendUsername != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendUsername, &interop->friendUsername, buffer);
            }

        }
    }

    /// <summary>
    /// PFFriendsAddFriendResult data model.
    /// </summary>
    public struct PFFriendsAddFriendResult
    {
        /// <summary>
        /// True if the friend request was processed successfully.
        /// </summary>
        public bool Created;

        internal unsafe PFFriendsAddFriendResult(Interop.PFFriendsAddFriendResult interop)
        {

            Created = InteropWrapper.WrapperHelpers.InteropToBool(interop.created);

        }
    }

    /// <summary>
    /// PFFriendsClientGetFriendsListRequest data model.
    /// </summary>
    public struct PFFriendsClientGetFriendsListRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Indicates which other platforms' friends should be included in the response. In HTTP,
        /// it is represented as a comma-separated list of platforms.
        /// </summary>
        public PFFriendsExternalFriendSources? ExternalPlatformFriends;

        /// <summary>
        /// (Optional) If non-null, this determines which properties of the resulting player profiles to return.
        /// For API calls from the client, only the allowed client profile properties for the title may be requested.
        /// These allowed properties are configured in the Game Manager "Client Profile Options" tab in the "Settings"
        /// section.
        /// </summary>
        public PFPlayerProfileViewConstraints? ProfileConstraints;

#if MICROSOFT_GDK_SUPPORT
        /// <summary>
        /// (Optional) XUserHandle if Xbox friends should be included.
        /// When using the Microsoft GDK Unity API, this is the Handle property or the value returned from DangerousGetHandle() of the XUserHandle object acquired from the XUserAddAsync or XUserAddByIdWithUiAsync methods.
        /// </summary>
        public IntPtr UserHandle;
#endif

        internal unsafe static void ToInterop(PFFriendsClientGetFriendsListRequest self, Interop.PFFriendsClientGetFriendsListRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ExternalPlatformFriends != null)
            {
                *interop->externalPlatformFriends = (Interop.PFFriendsExternalFriendSources)self.ExternalPlatformFriends.Value;
            }

            if (self.ProfileConstraints != null)
            {
                interop->profileConstraints = (Interop.PFPlayerProfileViewConstraints*)buffer.AddBuffer(sizeof(Interop.PFPlayerProfileViewConstraints));
                PFPlayerProfileViewConstraints.ToInterop(self.ProfileConstraints.Value, interop->profileConstraints, buffer);
            }

#if MICROSOFT_GDK_SUPPORT
            interop->user = self.UserHandle;
#endif

        }
    }

    /// <summary>
    /// PFFriendsFriendInfo data model.
    /// </summary>
    public struct PFFriendsFriendInfo
    {
        /// <summary>
        /// (Optional) Available Facebook information (if the user and connected Facebook friend both have PlayFab
        /// Accounts in the same title).
        /// </summary>
        public PFUserFacebookInfo? FacebookInfo;

        /// <summary>
        /// (Optional) PlayFab unique identifier for this friend.
        /// </summary>
        public string? FriendPlayFabId;

        /// <summary>
        /// (Optional) Available Game Center information (if the user and connected Game Center friend both have
        /// PlayFab Accounts in the same title).
        /// </summary>
        public PFUserGameCenterInfo? GameCenterInfo;

        /// <summary>
        /// (Optional) The profile of the user, if requested.
        /// </summary>
        public PFPlayerProfileModel? Profile;

        /// <summary>
        /// (Optional) Available PlayStation :tm: Network information, if the user connected PlayStation :tm
        /// Network friend both have PlayFab Accounts in the same title.
        /// </summary>
        public PFUserPsnInfo? PSNInfo;

        /// <summary>
        /// (Optional) Available Steam information (if the user and connected Steam friend both have PlayFab
        /// Accounts in the same title).
        /// </summary>
        public PFUserSteamInfo? SteamInfo;

        /// <summary>
        /// (Optional) Tags which have been associated with this friend.
        /// </summary>
        public string[]? Tags;

        /// <summary>
        /// (Optional) Title-specific display name for this friend.
        /// </summary>
        public string? TitleDisplayName;

        /// <summary>
        /// (Optional) PlayFab unique username for this friend.
        /// </summary>
        public string? Username;

        /// <summary>
        /// (Optional) Available Xbox information, (if the user and connected Xbox Live friend both have PlayFab
        /// Accounts in the same title).
        /// </summary>
        public PFUserXboxInfo? XboxInfo;

        internal unsafe PFFriendsFriendInfo(Interop.PFFriendsFriendInfo interop)
        {

            FacebookInfo = (interop.facebookInfo == null) ? null : new(*interop.facebookInfo);

            FriendPlayFabId = (interop.friendPlayFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.friendPlayFabId);

            GameCenterInfo = (interop.gameCenterInfo == null) ? null : new(*interop.gameCenterInfo);

            Profile = (interop.profile == null) ? null : new(*interop.profile);

            PSNInfo = (interop.PSNInfo == null) ? null : new(*interop.PSNInfo);

            SteamInfo = (interop.steamInfo == null) ? null : new(*interop.steamInfo);

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount);

            TitleDisplayName = (interop.titleDisplayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.titleDisplayName);

            Username = (interop.username == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.username);

            XboxInfo = (interop.xboxInfo == null) ? null : new(*interop.xboxInfo);

        }

        internal unsafe static void ToInterop(PFFriendsFriendInfo self, Interop.PFFriendsFriendInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FacebookInfo != null)
            {
                interop->facebookInfo = (Interop.PFUserFacebookInfo*)buffer.AddBuffer(sizeof(Interop.PFUserFacebookInfo));
                PFUserFacebookInfo.ToInterop(self.FacebookInfo.Value, interop->facebookInfo, buffer);
            }

            if (self.FriendPlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendPlayFabId, &interop->friendPlayFabId, buffer);
            }

            if (self.GameCenterInfo != null)
            {
                interop->gameCenterInfo = (Interop.PFUserGameCenterInfo*)buffer.AddBuffer(sizeof(Interop.PFUserGameCenterInfo));
                PFUserGameCenterInfo.ToInterop(self.GameCenterInfo.Value, interop->gameCenterInfo, buffer);
            }

            if (self.Profile != null)
            {
                interop->profile = (Interop.PFPlayerProfileModel*)buffer.AddBuffer(sizeof(Interop.PFPlayerProfileModel));
                PFPlayerProfileModel.ToInterop(self.Profile.Value, interop->profile, buffer);
            }

            if (self.PSNInfo != null)
            {
                interop->PSNInfo = (Interop.PFUserPsnInfo*)buffer.AddBuffer(sizeof(Interop.PFUserPsnInfo));
                PFUserPsnInfo.ToInterop(self.PSNInfo.Value, interop->PSNInfo, buffer);
            }

            if (self.SteamInfo != null)
            {
                interop->steamInfo = (Interop.PFUserSteamInfo*)buffer.AddBuffer(sizeof(Interop.PFUserSteamInfo));
                PFUserSteamInfo.ToInterop(self.SteamInfo.Value, interop->steamInfo, buffer);
            }

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
                interop->tagsCount = (uint)self.Tags.Length;
            }

            if (self.TitleDisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TitleDisplayName, &interop->titleDisplayName, buffer);
            }

            if (self.Username != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Username, &interop->username, buffer);
            }

            if (self.XboxInfo != null)
            {
                interop->xboxInfo = (Interop.PFUserXboxInfo*)buffer.AddBuffer(sizeof(Interop.PFUserXboxInfo));
                PFUserXboxInfo.ToInterop(self.XboxInfo.Value, interop->xboxInfo, buffer);
            }

        }
    }

    /// <summary>
    /// PFFriendsGetFriendsListResult data model. If any additional services are queried for the user's friends,
    /// those friends who also have a PlayFab account registered for the title will be returned in the results.
    /// For Facebook, user has to have logged into the title's Facebook app recently, and only friends who
    /// also plays this game will be included. Note: If the user authenticated with AuthenticationToken when
    /// calling LoginWithFacebook, instead of AccessToken, an empty list will be returned. For Xbox Live,
    /// user has to have logged into the Xbox Live recently, and only friends who also play this game will
    /// be included. Xbox Live friends include all users the caller is following, regardless of whether those
    /// users follow the caller back. This differs from FindFriendLobbies, which only considers mutual Xbox
    /// Live friends (where both users follow each other).
    /// </summary>
    public struct PFFriendsGetFriendsListResult
    {
        /// <summary>
        /// (Optional) Array of friends found.
        /// </summary>
        public PFFriendsFriendInfo[]? Friends;

        internal unsafe PFFriendsGetFriendsListResult(Interop.PFFriendsGetFriendsListResult interop)
        {

            Friends = (interop.friends == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.friends, interop.friendsCount, elem => new PFFriendsFriendInfo(elem));

        }
    }

    /// <summary>
    /// PFFriendsClientRemoveFriendRequest data model.
    /// </summary>
    public struct PFFriendsClientRemoveFriendRequest
    {
        /// <summary>
        /// PlayFab identifier of the friend account which is to be removed.
        /// </summary>
        public string FriendPlayFabId;

        internal unsafe static void ToInterop(PFFriendsClientRemoveFriendRequest self, Interop.PFFriendsClientRemoveFriendRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.FriendPlayFabId, &interop->friendPlayFabId, buffer);

        }
    }

    /// <summary>
    /// PFFriendsClientSetFriendTagsRequest data model. This operation is not additive. It will completely
    /// replace the tag list for the specified user. Please note that only users in the PlayFab friends list
    /// can be assigned tags. Attempting to set a tag on a friend only included in the friends list from a
    /// social site integration (such as Facebook or Steam) will return the AccountNotFound error.
    /// </summary>
    public struct PFFriendsClientSetFriendTagsRequest
    {
        /// <summary>
        /// PlayFab identifier of the friend account to which the tag(s) should be applied.
        /// </summary>
        public string FriendPlayFabId;

        /// <summary>
        /// Array of tags to set on the friend account.
        /// </summary>
        public string[] Tags;

        internal unsafe static void ToInterop(PFFriendsClientSetFriendTagsRequest self, Interop.PFFriendsClientSetFriendTagsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.FriendPlayFabId, &interop->friendPlayFabId, buffer);

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
            interop->tagsCount = (uint)self.Tags.Length;

        }
    }

    /// <summary>
    /// PFFriendsServerAddFriendRequest data model.
    /// </summary>
    public struct PFFriendsServerAddFriendRequest
    {
        /// <summary>
        /// (Optional) Email address of the user being added.
        /// </summary>
        public string? FriendEmail;

        /// <summary>
        /// (Optional) The PlayFab identifier of the user being added.
        /// </summary>
        public string? FriendPlayFabId;

        /// <summary>
        /// (Optional) Title-specific display name of the user to being added.
        /// </summary>
        public string? FriendTitleDisplayName;

        /// <summary>
        /// (Optional) The PlayFab username of the user being added.
        /// </summary>
        public string? FriendUsername;

        /// <summary>
        /// PlayFab identifier of the player to add a new friend.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFFriendsServerAddFriendRequest self, Interop.PFFriendsServerAddFriendRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FriendEmail != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendEmail, &interop->friendEmail, buffer);
            }

            if (self.FriendPlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendPlayFabId, &interop->friendPlayFabId, buffer);
            }

            if (self.FriendTitleDisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendTitleDisplayName, &interop->friendTitleDisplayName, buffer);
            }

            if (self.FriendUsername != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FriendUsername, &interop->friendUsername, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFFriendsServerGetFriendsListRequest data model.
    /// </summary>
    public struct PFFriendsServerGetFriendsListRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Indicates which other platforms' friends should be included in the response. In HTTP,
        /// it is represented as a comma-separated list of platforms.
        /// </summary>
        public PFFriendsExternalFriendSources? ExternalPlatformFriends;

        /// <summary>
        /// PlayFab identifier of the player whose friend list to get.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// (Optional) If non-null, this determines which properties of the resulting player profiles to return.
        /// For API calls from the client, only the allowed client profile properties for the title may be requested.
        /// These allowed properties are configured in the Game Manager "Client Profile Options" tab in the "Settings"
        /// section.
        /// </summary>
        public PFPlayerProfileViewConstraints? ProfileConstraints;

        /// <summary>
        /// (Optional) Xbox token if Xbox friends should be included. Requires Xbox be configured on PlayFab.
        /// When provided, all Xbox Live users the caller is following are included regardless of whether they
        /// follow the caller back.
        /// </summary>
        public string? XboxToken;

        internal unsafe static void ToInterop(PFFriendsServerGetFriendsListRequest self, Interop.PFFriendsServerGetFriendsListRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ExternalPlatformFriends != null)
            {
                *interop->externalPlatformFriends = (Interop.PFFriendsExternalFriendSources)self.ExternalPlatformFriends.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            if (self.ProfileConstraints != null)
            {
                interop->profileConstraints = (Interop.PFPlayerProfileViewConstraints*)buffer.AddBuffer(sizeof(Interop.PFPlayerProfileViewConstraints));
                PFPlayerProfileViewConstraints.ToInterop(self.ProfileConstraints.Value, interop->profileConstraints, buffer);
            }

            if (self.XboxToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.XboxToken, &interop->xboxToken, buffer);
            }

        }
    }

    /// <summary>
    /// PFFriendsServerRemoveFriendRequest data model.
    /// </summary>
    public struct PFFriendsServerRemoveFriendRequest
    {
        /// <summary>
        /// PlayFab identifier of the friend account which is to be removed.
        /// </summary>
        public string FriendPlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFFriendsServerRemoveFriendRequest self, Interop.PFFriendsServerRemoveFriendRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.FriendPlayFabId, &interop->friendPlayFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFFriendsServerSetFriendTagsRequest data model. This operation is not additive. It will completely
    /// replace the tag list for the specified user. Please note that only users in the PlayFab friends list
    /// can be assigned tags. Attempting to set a tag on a friend only included in the friends list from a
    /// social site integration (such as Facebook or Steam) will return the AccountNotFound error.
    /// </summary>
    public struct PFFriendsServerSetFriendTagsRequest
    {
        /// <summary>
        /// PlayFab identifier of the friend account to which the tag(s) should be applied.
        /// </summary>
        public string FriendPlayFabId;

        /// <summary>
        /// PlayFab identifier of the player whose friend is to be updated.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Array of tags to set on the friend account.
        /// </summary>
        public string[] Tags;

        internal unsafe static void ToInterop(PFFriendsServerSetFriendTagsRequest self, Interop.PFFriendsServerSetFriendTagsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.FriendPlayFabId, &interop->friendPlayFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
            interop->tagsCount = (uint)self.Tags.Length;

        }
    }

}
