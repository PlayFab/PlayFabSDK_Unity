// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
        /// <summary>
        /// Retrieves the title player accounts associated with the given XUIDs.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetTitlePlayersFromProviderIDsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given a collection of Xbox IDs (XUIDs), returns all title player accounts.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementGetTitlePlayersFromXboxLiveIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementGetTitlePlayersFromXboxLiveIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetTitlePlayersFromProviderIDsResponse>> AccountManagementGetTitlePlayersFromXboxLiveIDsAsync(
            PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementGetTitlePlayersFromXboxLiveIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Update the display name of the entity
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementSetDisplayNameResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity profile, will update its display name to the one passed in if the profile's version
        /// is equal to the specified value See also ProfileGetProfileAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementSetDisplayNameGetResultSize"/>
        /// and <see cref="PFAccountManagementSetDisplayNameGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementSetDisplayNameResponse>> AccountManagementSetDisplayNameAsync(
            PFAccountManagementSetDisplayNameRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementSetDisplayNameAsync(InteropHandle, request);
        }
    }

    public partial class PFPlayerEntity
    {
        /// <summary>
        /// Adds or updates a contact email to the player's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API adds a contact email to the player's profile. If the player's profile already contains a
        /// contact email, it will update the contact email to the email address specified.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientAddOrUpdateContactEmailAsync(
            PFAccountManagementAddOrUpdateContactEmailRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientAddOrUpdateContactEmailAsync(InteropHandle, request);
        }

        /// <summary>
        /// Adds playfab username/password auth to an existing account created via an anonymous auth method,
        /// e.g. automatic device ID login.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementAddUsernamePasswordResult.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLoginWithEmailAddressAsync, ClientLoginWithPlayFabAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientAddUsernamePasswordGetResultSize"/>
        /// and <see cref="PFAccountManagementClientAddUsernamePasswordGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementAddUsernamePasswordResult>> AccountManagementClientAddUsernamePasswordAsync(
            PFAccountManagementAddUsernamePasswordRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientAddUsernamePasswordAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the user's PlayFab account details
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetAccountInfoResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetAccountInfoGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetAccountInfoGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetAccountInfoResult>> AccountManagementClientGetAccountInfoAsync(
            PFAccountManagementGetAccountInfoRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetAccountInfoAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves all of the user's different kinds of info.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayerCombinedInfoResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayerCombinedInfoGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayerCombinedInfoGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayerCombinedInfoResult>> AccountManagementClientGetPlayerCombinedInfoAsync(
            PFAccountManagementGetPlayerCombinedInfoRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayerCombinedInfoAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayerProfileResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This API allows for access to details regarding a user in the PlayFab service, usually for purposes
        /// of customer support. Note that data returned may be Personally Identifying Information (PII), such
        /// as email address, and so care should be taken in how this data is stored and managed. Since this call
        /// will always return the relevant information for users who have accessed the title, the recommendation
        /// is to not store this data locally.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayerProfileGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayerProfileGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayerProfileResult>> AccountManagementClientGetPlayerProfileAsync(
            PFAccountManagementGetPlayerProfileRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayerProfileAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Battle.net account identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsGetResult"/> to get the
        /// result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult>> AccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsAsync(
            PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromFacebookIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, Android, iOS, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromFacebookIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromFacebookIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookIDsResult>> AccountManagementClientGetPlayFabIDsFromFacebookIDsAsync(
            PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromFacebookIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Game identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsGetResult"/> to get
        /// the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult>> AccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsAsync(
            PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Game Center identifiers (referenced
        /// in the Game Center Programming Guide as the Player Identifier).
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, iOS, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult>> AccountManagementClientGetPlayFabIDsFromGameCenterIDsAsync(
            PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google identifiers. The Google identifiers
        /// are the IDs for the user accounts, available as 'id' in the Google+ People API calls.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromGoogleIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, Android, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromGoogleIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromGoogleIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromGoogleIDsResult>> AccountManagementClientGetPlayFabIDsFromGoogleIDsAsync(
            PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromGoogleIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google Play Games identifiers. The
        /// Google Play Games identifiers are the IDs for the user accounts, available as 'playerId' in the Google
        /// Play Games Services - Players API calls.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, Android, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsGetResult"/> to get
        /// the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult>> AccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsAsync(
            PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Kongregate identifiers. The Kongregate
        /// identifiers are the IDs for the user accounts, available as 'user_id' from the Kongregate API methods(ex:
        /// http://developers.kongregate.com/docs/client/getUserId).
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromKongregateIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromKongregateIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromKongregateIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromKongregateIDsResult>> AccountManagementClientGetPlayFabIDsFromKongregateIDsAsync(
            PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromKongregateIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Service Account identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Nintendo Switch, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsGetResult"/> to
        /// get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult>> AccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsAsync(
            PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch Device identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResult"/> to get
        /// the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> AccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(
            PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Sony PlayStation®, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult>> AccountManagementClientGetPlayFabIDsFromPSNAccountIDsAsync(
            PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult>> AccountManagementClientGetPlayFabIDsFromPSNOnlineIDsAsync(
            PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers
        /// are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromSteamIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromSteamIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromSteamIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromSteamIDsResult>> AccountManagementClientGetPlayFabIDsFromSteamIDsAsync(
            PFAccountManagementGetPlayFabIDsFromSteamIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromSteamIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers
        /// are persona names.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromSteamNamesResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromSteamNamesGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromSteamNamesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromSteamNamesResult>> AccountManagementClientGetPlayFabIDsFromSteamNamesAsync(
            PFAccountManagementGetPlayFabIDsFromSteamNamesRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromSteamNamesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers
        /// are the IDs for the user accounts, available as '_id' from the Twitch API methods (ex: https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromTwitchIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromTwitchIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromTwitchIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromTwitchIDsResult>> AccountManagementClientGetPlayFabIDsFromTwitchIDsAsync(
            PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromTwitchIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of XboxLive identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult>> AccountManagementClientGetPlayFabIDsFromXboxLiveIDsAsync(
            PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Android device identifier to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLoginWithAndroidDeviceIDAsync, ClientUnlinkAndroidDeviceIDAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_LINKED_DEVICE_ALREADY_CLAIMED
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkAndroidDeviceIDAsync(
            PFAccountManagementLinkAndroidDeviceIDRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkAndroidDeviceIDAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Apple account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, iOS, and macOS.
        /// See also ClientLoginWithAppleAsync, ClientUnlinkAppleAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_APPLE_NOT_ENABLED_FOR_TITLE,
        /// E_PF_INVALID_IDENTITY_PROVIDER_ID, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED, E_PF_TOKEN_SIGNING_KEY_NOT_FOUND
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkAppleAsync(
            PFAccountManagementLinkAppleRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkAppleAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Battle.net account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ClientLoginWithBattleNetAsync, ClientUnlinkBattleNetAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_BATTLE_NET_NOT_ENABLED_FOR_TITLE, E_PF_INVALID_IDENTITY_PROVIDER_ID,
        /// E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED, E_PF_TOKEN_SIGNING_KEY_NOT_FOUND or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkBattleNetAccountAsync(
            PFAccountManagementClientLinkBattleNetAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkBattleNetAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the custom identifier, generated by the title, to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLoginWithCustomIDAsync, ClientUnlinkCustomIDAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkCustomIDAsync(
            PFAccountManagementLinkCustomIDRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkCustomIDAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab
        /// account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, Android, iOS, and macOS.
        /// Facebook sign-in is accomplished using the Facebook User Access Token. More information on the Token
        /// can be found in the Facebook developer documentation (https://developers.facebook.com/docs/facebook-login/access-tokens/).
        /// In Unity, for example, the Token is available as AccessToken in the Facebook SDK ScriptableObject
        /// FB. Note that titles should never re-use the same Facebook applications between PlayFab Title IDs,
        /// as Facebook provides unique user IDs per application and doing so can result in issues with the Facebook
        /// ID for the user in their PlayFab account information. If you must re-use an application in a new PlayFab
        /// Title ID, please be sure to first unlink all accounts from Facebook, or delete all users in the first
        /// Title ID. See also ClientLoginWithFacebookAsync, ClientUnlinkFacebookAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_ACCOUNT_NOT_FOUND,
        /// E_PF_FACEBOOK_API_ERROR, E_PF_INVALID_FACEBOOK_TOKEN, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED or any of
        /// the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkFacebookAccountAsync(
            PFAccountManagementLinkFacebookAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkFacebookAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Facebook Instant Games Id to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLoginWithFacebookInstantGamesIdAsync, ClientUnlinkFacebookInstantGamesIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_FACEBOOK_INSTANT_GAMES_AUTH_NOT_CONFIGURED_FOR_TITLE,
        /// E_PF_INVALID_FACEBOOK_INSTANT_GAMES_SIGNATURE, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED or any of the
        /// global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkFacebookInstantGamesIdAsync(
            PFAccountManagementLinkFacebookInstantGamesIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkFacebookInstantGamesIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account.
        /// Logging in with a Game Center ID is insecure if you do not include the optional PublicKeyUrl, Salt,
        /// Signature, and Timestamp parameters in this request. It is recommended you require these parameters
        /// on all Game Center calls by going to the Apple Add-ons page in the PlayFab Game Manager and enabling
        /// the 'Require secure authentication only for this app' option.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, iOS, and macOS.
        /// See also ClientUnlinkGameCenterAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_GAME_CENTER_AUTHENTICATION_FAILED,
        /// E_PF_INVALID_GAME_CENTER_AUTH_REQUEST, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkGameCenterAccountAsync(
            PFAccountManagementLinkGameCenterAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkGameCenterAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the currently signed-in user account to their Google account, using their Google account credentials
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, Android, and macOS.
        /// Google sign-in is accomplished by obtaining a Google OAuth 2.0 credential using the Google sign-in
        /// for Android APIs on the device and passing it to this API. See also ClientLoginWithGoogleAccountAsync,
        /// ClientUnlinkGoogleAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_GOOGLE_O_AUTH_ERROR,
        /// E_PF_GOOGLE_O_AUTH_NO_ID_TOKEN_INCLUDED_IN_RESPONSE, E_PF_GOOGLE_O_AUTH_NOT_CONFIGURED_FOR_TITLE,
        /// E_PF_INVALID_GOOGLE_TOKEN, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED or any of the global PlayFab Service
        /// errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkGoogleAccountAsync(
            PFAccountManagementLinkGoogleAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkGoogleAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the currently signed-in user account to their Google Play Games account, using their Google
        /// Play Games account credentials
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, Android, and macOS.
        /// Google Play Games sign-in is accomplished by obtaining a Google OAuth 2.0 credential using the Google
        /// Play Games sign-in for Android APIs on the device and passing it to this API. See also ClientLoginWithGooglePlayGamesServicesAsync,
        /// ClientUnlinkGooglePlayGamesServicesAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_GOOGLE_O_AUTH_ERROR,
        /// E_PF_GOOGLE_O_AUTH_NOT_CONFIGURED_FOR_TITLE, E_PF_INVALID_GOOGLE_PLAY_GAMES_SERVER_AUTH_CODE, E_PF_INVALID_GOOGLE_TOKEN,
        /// E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED or any of the global PlayFab Service errors. See doc page "Handling
        /// PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkGooglePlayGamesServicesAccountAsync(
            PFAccountManagementLinkGooglePlayGamesServicesAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkGooglePlayGamesServicesAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the vendor-specific iOS device identifier to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLoginWithIOSDeviceIDAsync, ClientUnlinkIOSDeviceIDAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_LINKED_DEVICE_ALREADY_CLAIMED
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkIOSDeviceIDAsync(
            PFAccountManagementLinkIOSDeviceIDRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkIOSDeviceIDAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Kongregate identifier to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLoginWithKongregateAsync, ClientUnlinkKongregateAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_FEATURE_NOT_CONFIGURED_FOR_TITLE,
        /// E_PF_INVALID_KONGREGATE_TOKEN, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED or any of the global PlayFab Service
        /// errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkKongregateAsync(
            PFAccountManagementLinkKongregateAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkKongregateAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Nintendo account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Nintendo Switch, Linux, and macOS.
        /// See also ClientLoginWithNintendoServiceAccountAsync, ClientUnlinkNintendoServiceAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_INVALID_IDENTITY_PROVIDER_ID,
        /// E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED, E_PF_NINTENDO_SWITCH_NOT_ENABLED_FOR_TITLE or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkNintendoServiceAccountAsync(
            PFAccountManagementClientLinkNintendoServiceAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkNintendoServiceAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLoginWithNintendoSwitchDeviceIdAsync, ClientUnlinkNintendoSwitchDeviceIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkNintendoSwitchDeviceIdAsync(
            PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkNintendoSwitchDeviceIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links an OpenID Connect account to a user's PlayFab account, based on an existing relationship between
        /// a title and an Open ID Connect provider and the OpenId Connect JWT from that provider.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLoginWithOpenIdConnectAsync, ClientUnlinkOpenIdConnectAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_INVALID_IDENTITY_PROVIDER_ID,
        /// E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED or any of the global PlayFab Service errors. See doc page "Handling
        /// PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkOpenIdConnectAsync(
            PFAccountManagementLinkOpenIdConnectRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkOpenIdConnectAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided access code to the user's
        /// PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Sony PlayStation®, Linux, and macOS.
        /// See also ClientLoginWithPSNAsync, ClientUnlinkPSNAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_INVALID_PSN_AUTH_CODE,
        /// E_PF_INVALID_PSN_AUTH_CODE, E_PF_INVALID_PSN_ISSUER_ID, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED, E_PF_PSN_INACCESSIBLE
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkPSNAccountAsync(
            PFAccountManagementClientLinkPSNAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkPSNAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab
        /// account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Steam authentication is accomplished with the Steam Session Ticket. More information on the Ticket
        /// can be found in the Steamworks SDK, here: https://partner.steamgames.com/documentation/auth (requires
        /// sign-in). NOTE: For Steam authentication to work, the title must be configured with the Steam Application
        /// ID and Publisher Key in the PlayFab Game Manager (under Properties). Information on creating a Publisher
        /// Key (referred to as the Secret Key in PlayFab) for your title can be found here: https://partner.steamgames.com/documentation/webapi#publisherkey.
        /// See also ClientLoginWithSteamAsync, ClientUnlinkSteamAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_INVALID_STEAM_TICKET,
        /// E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED, E_PF_STEAM_NOT_ENABLED_FOR_TITLE, E_PF_STEAM_USER_NOT_FOUND or
        /// any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkSteamAccountAsync(
            PFAccountManagementLinkSteamAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkSteamAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Twitch account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLoginWithTwitchAsync, ClientUnlinkTwitchAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_LINKED_TO_A_BANNED_PLAYER, E_PF_FEATURE_NOT_CONFIGURED_FOR_TITLE,
        /// E_PF_INVALID_TWITCH_TOKEN, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED, E_PF_TWITCH_RESPONSE_ERROR or any
        /// of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkTwitchAsync(
            PFAccountManagementClientLinkTwitchAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkTwitchAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLoginWithXboxAsync, ClientUnlinkXboxAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_EXPIRED_XBOX_LIVE_TOKEN, E_PF_INVALID_XBOX_LIVE_TOKEN,
        /// E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED or any of the global PlayFab Service errors. See doc page "Handling
        /// PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientLinkXboxAccountAsync(
            PFAccountManagementClientLinkXboxAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientLinkXboxAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Removes a contact email from the player's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API removes an existing contact email from the player's profile.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientRemoveContactEmailAsync(
            PFAccountManagementRemoveContactEmailRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientRemoveContactEmailAsync(InteropHandle, request);
        }

        /// <summary>
        /// Submit a report for another player (due to bad bahavior, etc.), so that customer service representatives
        /// for the title can take action concerning potentially toxic players.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementReportPlayerClientResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientReportPlayerGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementReportPlayerClientResult>> AccountManagementClientReportPlayerAsync(
            PFAccountManagementReportPlayerClientRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientReportPlayerAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Android device identifier from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLinkAndroidDeviceIDAsync, ClientLoginWithAndroidDeviceIDAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_DEVICE_NOT_LINKED or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkAndroidDeviceIDAsync(
            PFAccountManagementUnlinkAndroidDeviceIDRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkAndroidDeviceIDAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Apple account from the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, iOS, and macOS.
        /// See also ClientLinkAppleAsync, ClientLoginWithAppleAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_APPLE_NOT_ENABLED_FOR_TITLE or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkAppleAsync(
            PFAccountManagementUnlinkAppleRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkAppleAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Battle.net account from the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ClientLinkBattleNetAccountAsync, ClientLoginWithBattleNetAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_BATTLE_NET_NOT_ENABLED_FOR_TITLE or any of
        /// the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkBattleNetAccountAsync(
            PFAccountManagementClientUnlinkBattleNetAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkBattleNetAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related custom identifier from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLinkCustomIDAsync, ClientLoginWithCustomIDAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_CUSTOM_ID_NOT_LINKED or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkCustomIDAsync(
            PFAccountManagementUnlinkCustomIDRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkCustomIDAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Facebook account from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, Android, iOS, and macOS.
        /// See also ClientLinkFacebookAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkFacebookAccountAsync(
            PFAccountManagementClientUnlinkFacebookAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkFacebookAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Facebook Instant Game Ids from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLinkFacebookInstantGamesIdAsync, ClientLoginWithFacebookInstantGamesIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_FACEBOOK_INSTANT_GAMES_ID_NOT_LINKED or any
        /// of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkFacebookInstantGamesIdAsync(
            PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkFacebookInstantGamesIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Game Center account from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, iOS, and macOS.
        /// See also ClientLinkGameCenterAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkGameCenterAccountAsync(
            PFAccountManagementUnlinkGameCenterAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkGameCenterAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Google account from the user's PlayFab account (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods).
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, Android, and macOS.
        /// See also ClientLinkGoogleAccountAsync, ClientLoginWithGoogleAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkGoogleAccountAsync(
            PFAccountManagementUnlinkGoogleAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkGoogleAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Google Play Games account from the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux, Android, and macOS.
        /// See also ClientLinkGooglePlayGamesServicesAccountAsync, ClientLoginWithGooglePlayGamesServicesAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkGooglePlayGamesServicesAccountAsync(
            PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkGooglePlayGamesServicesAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related iOS device identifier from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLinkIOSDeviceIDAsync, ClientLoginWithIOSDeviceIDAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_DEVICE_NOT_LINKED or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkIOSDeviceIDAsync(
            PFAccountManagementUnlinkIOSDeviceIDRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkIOSDeviceIDAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Kongregate identifier from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLinkKongregateAsync, ClientLoginWithKongregateAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkKongregateAsync(
            PFAccountManagementUnlinkKongregateAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkKongregateAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Nintendo account from the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Nintendo Switch, Linux, and macOS.
        /// See also ClientLinkNintendoServiceAccountAsync, ClientLoginWithNintendoServiceAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_NINTENDO_SWITCH_NOT_ENABLED_FOR_TITLE or any
        /// of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkNintendoServiceAccountAsync(
            PFAccountManagementClientUnlinkNintendoServiceAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkNintendoServiceAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLinkNintendoSwitchDeviceIdAsync, ClientLoginWithNintendoSwitchDeviceIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_NINTENDO_SWITCH_DEVICE_ID_NOT_LINKED or any
        /// of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkNintendoSwitchDeviceIdAsync(
            PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkNintendoSwitchDeviceIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks an OpenID Connect account from a user's PlayFab account, based on the connection ID of an
        /// existing relationship between a title and an Open ID Connect provider.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLinkOpenIdConnectAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkOpenIdConnectAsync(
            PFAccountManagementUnlinkOpenIdConnectRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkOpenIdConnectAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related PlayStation :tm: Network account from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Sony PlayStation®, Linux, and macOS.
        /// See also ClientLinkPSNAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkPSNAccountAsync(
            PFAccountManagementClientUnlinkPSNAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkPSNAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Steam account from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ClientLinkSteamAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkSteamAccountAsync(
            PFAccountManagementUnlinkSteamAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkSteamAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Twitch account from the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLinkTwitchAsync, ClientLoginWithTwitchAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_FEATURE_NOT_CONFIGURED_FOR_TITLE, E_PF_INVALID_TWITCH_TOKEN
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkTwitchAsync(
            PFAccountManagementClientUnlinkTwitchAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkTwitchAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLinkXboxAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_INVALID_XBOX_LIVE_TOKEN or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUnlinkXboxAccountAsync(
            PFAccountManagementClientUnlinkXboxAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUnlinkXboxAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Update the avatar URL of the player
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientUpdateAvatarUrlAsync(
            PFAccountManagementClientUpdateAvatarUrlRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUpdateAvatarUrlAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the title specific display name for the user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementUpdateUserTitleDisplayNameResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// In addition to the PlayFab username, titles can make use of a DisplayName which is also a unique
        /// identifier, but specific to the title. This allows for unique names which more closely match the theme
        /// or genre of a title, for example.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientUpdateUserTitleDisplayNameGetResultSize"/>
        /// and <see cref="PFAccountManagementClientUpdateUserTitleDisplayNameGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementUpdateUserTitleDisplayNameResult>> AccountManagementClientUpdateUserTitleDisplayNameAsync(
            PFAccountManagementUpdateUserTitleDisplayNameRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientUpdateUserTitleDisplayNameAsync(InteropHandle, request);
        }
    }

    public partial class PFTitleEntity
    {
        /// <summary>
        /// Bans users by PlayFab ID with optional IP address for the provided game.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementBanUsersResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// The existence of each user will not be verified. When banning by IP, multiple players may be affected,
        /// so use this feature with caution. Returns information about the new bans. See also ServerGetUserBansAsync,
        /// ServerRevokeAllBansForUserAsync, ServerRevokeBansAsync, ServerUpdateBansAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerBanUsersGetResultSize"/>
        /// and <see cref="PFAccountManagementServerBanUsersGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementBanUsersResult>> AccountManagementServerBanUsersAsync(
            PFAccountManagementBanUsersRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerBanUsersAsync(InteropHandle, request);
        }

        /// <summary>
        /// Removes a user's player account from a title and deletes all associated data
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Deletes all data associated with the player, including statistics, custom data, inventory, purchases,
        /// virtual currency balances, characters and shared group memberships. Removes the player from all leaderboards
        /// and player search indexes. Does not delete PlayStream event history associated with the player. Does
        /// not delete the publisher user account that created the player in the title nor associated data such
        /// as username, password, email address, account linkages, or friends list. Note, this API queues the
        /// player for deletion and returns immediately. It may take several minutes or more before all player
        /// data is fully deleted. Until the player data is fully deleted, attempts to recreate the player with
        /// the same user account in the same title will fail with the 'AccountDeleted' error. This API must be
        /// enabled for use as an option in the game manager website. It is disabled by default.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_API_NOT_ENABLED_FOR_GAME_SERVER_ACCESS or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerDeletePlayerAsync(
            PFAccountManagementDeletePlayerRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerDeletePlayerAsync(InteropHandle, request);
        }

        /// <summary>
        /// Returns whatever info is requested in the response for the user. Note that PII (like email address,
        /// facebook id) may be returned. All parameters default to false.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayerCombinedInfoResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayerCombinedInfoGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayerCombinedInfoGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayerCombinedInfoResult>> AccountManagementServerGetPlayerCombinedInfoAsync(
            PFAccountManagementGetPlayerCombinedInfoRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayerCombinedInfoAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayerProfileResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API allows for access to details regarding a user in the PlayFab service, usually for purposes
        /// of customer support. Note that data returned may be Personally Identifying Information (PII), such
        /// as email address, and so care should be taken in how this data is stored and managed. Since this call
        /// will always return the relevant information for users who have accessed the title, the recommendation
        /// is to not store this data locally.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayerProfileGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayerProfileGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayerProfileResult>> AccountManagementServerGetPlayerProfileAsync(
            PFAccountManagementGetPlayerProfileRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayerProfileAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Battle.net account identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsGetResult"/> to get the
        /// result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult>> AccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsAsync(
            PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromFacebookIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromFacebookIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromFacebookIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookIDsResult>> AccountManagementServerGetPlayFabIDsFromFacebookIDsAsync(
            PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromFacebookIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Games identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsGetResult"/> to get
        /// the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult>> AccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsAsync(
            PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Service Account identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsGetResult"/> to
        /// get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult>> AccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsAsync(
            PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch Device identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResult"/> to get
        /// the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> AccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(
            PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult>> AccountManagementServerGetPlayFabIDsFromPSNAccountIDsAsync(
            PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult>> AccountManagementServerGetPlayFabIDsFromPSNOnlineIDsAsync(
            PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers
        /// are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromSteamIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromSteamIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromSteamIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromSteamIDsResult>> AccountManagementServerGetPlayFabIDsFromSteamIDsAsync(
            PFAccountManagementGetPlayFabIDsFromSteamIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromSteamIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers
        /// are persona names.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromSteamNamesResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromSteamNamesGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromSteamNamesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromSteamNamesResult>> AccountManagementServerGetPlayFabIDsFromSteamNamesAsync(
            PFAccountManagementGetPlayFabIDsFromSteamNamesRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromSteamNamesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers
        /// are the IDs for the user accounts, available as '_id' from the Twitch API methods (ex: https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromTwitchIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromTwitchIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromTwitchIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromTwitchIDsResult>> AccountManagementServerGetPlayFabIDsFromTwitchIDsAsync(
            PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromTwitchIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of XboxLive identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult>> AccountManagementServerGetPlayFabIDsFromXboxLiveIDsAsync(
            PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the associated PlayFab account identifiers for the given set of server custom identifiers.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult>> AccountManagementServerGetServerCustomIDsFromPlayFabIDsAsync(
            PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetUserAccountInfoResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API allows for access to details regarding a user in the PlayFab service, usually for purposes
        /// of customer support. Note that data returned may be Personally Identifying Information (PII), such
        /// as email address, and so care should be taken in how this data is stored and managed. Since this call
        /// will always return the relevant information for users who have accessed the title, the recommendation
        /// is to not store this data locally. See also ServerGetUserInventoryAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetUserAccountInfoGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetUserAccountInfoGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetUserAccountInfoResult>> AccountManagementServerGetUserAccountInfoAsync(
            PFAccountManagementGetUserAccountInfoRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetUserAccountInfoAsync(InteropHandle, request);
        }

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetUserBansResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Get all bans for a user, including inactive and expired bans.  See also ServerBanUsersAsync, ServerRevokeAllBansForUserAsync,
        /// ServerRevokeBansAsync, ServerUpdateBansAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetUserBansGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetUserBansGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementGetUserBansResult>> AccountManagementServerGetUserBansAsync(
            PFAccountManagementGetUserBansRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerGetUserBansAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Battle.net account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ServerUnlinkBattleNetAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_BATTLE_NET_NOT_ENABLED_FOR_TITLE, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkBattleNetAccountAsync(
            PFAccountManagementServerLinkBattleNetAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkBattleNetAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Nintendo account associated with the token to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLinkNintendoServiceAccountSubjectAsync, ServerUnlinkNintendoServiceAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_INVALID_IDENTITY_PROVIDER_ID, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED,
        /// E_PF_NINTENDO_SWITCH_NOT_ENABLED_FOR_TITLE or any of the global PlayFab Service errors. See doc page
        /// "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkNintendoServiceAccountAsync(
            PFAccountManagementServerLinkNintendoServiceAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkNintendoServiceAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Nintendo account associated with the Nintendo Service Account subject or id to the user's
        /// PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLinkNintendoServiceAccountAsync, ServerUnlinkNintendoServiceAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_INVALID_IDENTITY_PROVIDER_ID, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED,
        /// E_PF_NINTENDO_SWITCH_NOT_ENABLED_FOR_TITLE or any of the global PlayFab Service errors. See doc page
        /// "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkNintendoServiceAccountSubjectAsync(
            PFAccountManagementLinkNintendoServiceAccountSubjectRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkNintendoServiceAccountSubjectAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerUnlinkNintendoSwitchDeviceIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED or any of the global PlayFab Service
        /// errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkNintendoSwitchDeviceIdAsync(
            PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkNintendoSwitchDeviceIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided access code to the user's
        /// PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerUnlinkPSNAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_NOT_FOUND, E_PF_INVALID_NAMESPACE_MISMATCH,
        /// E_PF_INVALID_PSN_AUTH_CODE, E_PF_INVALID_PSN_ISSUER_ID, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED, E_PF_PSN_INACCESSIBLE,
        /// E_PF_REQUEST_VIEW_CONSTRAINT_PARAMS_NOT_ALLOWED or any of the global PlayFab Service errors. See doc
        /// page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkPSNAccountAsync(
            PFAccountManagementServerLinkPSNAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkPSNAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided user id to the user's PlayFab
        /// account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_ACCOUNT_NOT_FOUND, E_PF_INVALID_NAMESPACE_MISMATCH,
        /// E_PF_INVALID_PSN_AUTH_CODE, E_PF_INVALID_PSN_ISSUER_ID, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED, E_PF_PSN_INACCESSIBLE
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkPSNIdAsync(
            PFAccountManagementLinkPSNIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkPSNIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the custom server identifier, generated by the title, to the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_FOUND, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED or any of
        /// the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkServerCustomIdAsync(
            PFAccountManagementLinkServerCustomIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkServerCustomIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam ID to the user's PlayFab account 
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLoginWithSteamIdAsync, ServerUnlinkSteamIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_INVALID_STEAM_TICKET, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED,
        /// E_PF_STEAM_NOT_ENABLED_FOR_TITLE, E_PF_STEAM_USER_NOT_FOUND or any of the global PlayFab Service errors.
        /// See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkSteamIdAsync(
            PFAccountManagementLinkSteamIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkSteamIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLoginWithXboxAsync, ServerUnlinkXboxAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_ALREADY_LINKED, E_PF_INVALID_XBOX_LIVE_TOKEN, E_PF_LINKED_ACCOUNT_ALREADY_CLAIMED
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerLinkXboxAccountAsync(
            PFAccountManagementServerLinkXboxAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerLinkXboxAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementRevokeAllBansForUserResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Setting the active state of all non-expired bans for a user to Inactive. Expired bans with an Active
        /// state will be ignored, however. Returns information about applied updates only. See also ServerBanUsersAsync,
        /// ServerGetUserBansAsync, ServerRevokeBansAsync, ServerUpdateBansAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerRevokeAllBansForUserGetResultSize"/>
        /// and <see cref="PFAccountManagementServerRevokeAllBansForUserGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementRevokeAllBansForUserResult>> AccountManagementServerRevokeAllBansForUserAsync(
            PFAccountManagementRevokeAllBansForUserRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerRevokeAllBansForUserAsync(InteropHandle, request);
        }

        /// <summary>
        /// Revoke all active bans specified with BanId.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementRevokeBansResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Setting the active state of all bans requested to Inactive regardless of whether that ban has already
        /// expired. BanIds that do not exist will be skipped. Returns information about applied updates only.
        ///  See also ServerBanUsersAsync, ServerGetUserBansAsync, ServerRevokeAllBansForUserAsync, ServerUpdateBansAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerRevokeBansGetResultSize"/>
        /// and <see cref="PFAccountManagementServerRevokeBansGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementRevokeBansResult>> AccountManagementServerRevokeBansAsync(
            PFAccountManagementRevokeBansRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerRevokeBansAsync(InteropHandle, request);
        }

        /// <summary>
        /// Forces an email to be sent to the registered contact email address for the user's account based on
        /// an account recovery email template
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// PlayFab accounts which have valid email address or username will be able to receive a password reset
        /// email using this API.The email sent must be an account recovery email template. The username or email
        /// can be passed in to send the email.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_EMAIL_CLIENT_CANCELED_TASK, E_PF_EMAIL_CLIENT_TIMEOUT, E_PF_EMAIL_MESSAGE_TO_ADDRESS_IS_MISSING,
        /// E_PF_EMAIL_TEMPLATE_MISSING, E_PF_NO_CONTACT_EMAIL_ADDRESS_FOUND, E_PF_SMTP_ADDON_NOT_ENABLED or any
        /// of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerSendCustomAccountRecoveryEmailAsync(
            PFAccountManagementSendCustomAccountRecoveryEmailRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerSendCustomAccountRecoveryEmailAsync(InteropHandle, request);
        }

        /// <summary>
        /// Sends an email based on an email template to a player's contact email 
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Sends an email for only players that have contact emails associated with them. Takes in an email
        /// template ID specifyingthe email template to send.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_EMAIL_CLIENT_CANCELED_TASK, E_PF_EMAIL_CLIENT_TIMEOUT, E_PF_EMAIL_TEMPLATE_MISSING,
        /// E_PF_NO_CONTACT_EMAIL_ADDRESS_FOUND, E_PF_SMTP_ADDON_NOT_ENABLED or any of the global PlayFab Service
        /// errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerSendEmailFromTemplateAsync(
            PFAccountManagementSendEmailFromTemplateRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerSendEmailFromTemplateAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Battle.net account from the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ServerLinkBattleNetAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_BATTLE_NET_NOT_ENABLED_FOR_TITLE or any of
        /// the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerUnlinkBattleNetAccountAsync(
            PFAccountManagementServerUnlinkBattleNetAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUnlinkBattleNetAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Nintendo account from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLinkNintendoServiceAccountAsync, ServerLinkNintendoServiceAccountSubjectAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_NINTENDO_SWITCH_NOT_ENABLED_FOR_TITLE or any
        /// of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerUnlinkNintendoServiceAccountAsync(
            PFAccountManagementServerUnlinkNintendoServiceAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUnlinkNintendoServiceAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLinkNintendoSwitchDeviceIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_NINTENDO_SWITCH_DEVICE_ID_NOT_LINKED or any
        /// of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerUnlinkNintendoSwitchDeviceIdAsync(
            PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUnlinkNintendoSwitchDeviceIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related PlayStation :tm: Network account from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLinkPSNAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerUnlinkPSNAccountAsync(
            PFAccountManagementServerUnlinkPSNAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUnlinkPSNAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the custom server identifier from the user's PlayFab account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLinkServerCustomIdAsync, ServerLoginWithServerCustomIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_IDENTIFIER_NOT_LINKED or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerUnlinkServerCustomIdAsync(
            PFAccountManagementUnlinkServerCustomIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUnlinkServerCustomIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the Steam account associated with the provided Steam ID to the user's PlayFab account 
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLinkSteamIdAsync, ServerLoginWithSteamIdAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerUnlinkSteamIdAsync(
            PFAccountManagementUnlinkSteamIdRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUnlinkSteamIdAsync(InteropHandle, request);
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerLinkXboxAccountAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_LINKED, E_PF_INVALID_XBOX_LIVE_TOKEN or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerUnlinkXboxAccountAsync(
            PFAccountManagementServerUnlinkXboxAccountRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUnlinkXboxAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// Update the avatar URL of the specified player
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementServerUpdateAvatarUrlAsync(
            PFAccountManagementServerUpdateAvatarUrlRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUpdateAvatarUrlAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementUpdateBansResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// For each ban, only updates the values that are set. Leave any value to null for no change. If a ban
        /// could not be found, the rest are still applied. Returns information about applied updates only. See
        /// also ServerBanUsersAsync, ServerGetUserBansAsync, ServerRevokeAllBansForUserAsync, ServerRevokeBansAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerUpdateBansGetResultSize"/>
        /// and <see cref="PFAccountManagementServerUpdateBansGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAccountManagementUpdateBansResult>> AccountManagementServerUpdateBansAsync(
            PFAccountManagementUpdateBansRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementServerUpdateBansAsync(InteropHandle, request);
        }
    }

    public partial class PFServiceConfig
    {
        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing
        /// the user to change the password.If an account recovery email template ID is provided, an email using
        /// the custom email template will be used.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// If the account in question is a 'temporary' account (for example, one that was created via a call
        /// to LoginFromIOSDeviceID), thisfunction will have no effect. Only PlayFab accounts which have valid
        /// email addresses will be able to receive a password reset email using this API.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_EMAIL_RECIPIENT_BLACKLISTED, E_PF_INVALID_EMAIL_ADDRESS, E_PF_NO_CONTACT_EMAIL_ADDRESS_FOUND,
        /// E_PF_SMTP_ADDON_NOT_ENABLED or any of the global PlayFab Service errors. See doc page "Handling PlayFab
        /// Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> AccountManagementClientSendAccountRecoveryEmailAsync(
            PFAccountManagementSendAccountRecoveryEmailRequest request
        )
        {
            return InteropWrapper.Services.PFAccountManagement.PFAccountManagementClientSendAccountRecoveryEmailAsync(InteropHandle, request);
        }
    }
}
