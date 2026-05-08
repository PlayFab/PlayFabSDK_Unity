// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// IdentifiedDeviceType enum.
    /// </summary>
    public enum PFAuthenticationIdentifiedDeviceType : uint
    {
        Unknown = Interop.PFAuthenticationIdentifiedDeviceType.Unknown,
        XboxOne = Interop.PFAuthenticationIdentifiedDeviceType.XboxOne,
        Scarlett = Interop.PFAuthenticationIdentifiedDeviceType.Scarlett,
        WindowsOneCore = Interop.PFAuthenticationIdentifiedDeviceType.WindowsOneCore,
        WindowsOneCoreMobile = Interop.PFAuthenticationIdentifiedDeviceType.WindowsOneCoreMobile,
        Win32 = Interop.PFAuthenticationIdentifiedDeviceType.Win32,
        android = Interop.PFAuthenticationIdentifiedDeviceType.android,
        iOS = Interop.PFAuthenticationIdentifiedDeviceType.iOS,
        PlayStation = Interop.PFAuthenticationIdentifiedDeviceType.PlayStation,
        Nintendo = Interop.PFAuthenticationIdentifiedDeviceType.Nintendo
    }

    /// <summary>
    /// PFAuthenticationUserSettings data model.
    /// </summary>
    public struct PFAuthenticationUserSettings
    {
        /// <summary>
        /// Boolean for whether this player is eligible for gathering device info.
        /// </summary>
        public bool GatherDeviceInfo;

        /// <summary>
        /// Boolean for whether this player should report OnFocus play-time tracking.
        /// </summary>
        public bool GatherFocusInfo;

        /// <summary>
        /// Boolean for whether this player is eligible for ad tracking.
        /// </summary>
        public bool NeedsAttribution;

        internal unsafe PFAuthenticationUserSettings(Interop.PFAuthenticationUserSettings interop)
        {

            GatherDeviceInfo = InteropWrapper.WrapperHelpers.InteropToBool(interop.gatherDeviceInfo);

            GatherFocusInfo = InteropWrapper.WrapperHelpers.InteropToBool(interop.gatherFocusInfo);

            NeedsAttribution = InteropWrapper.WrapperHelpers.InteropToBool(interop.needsAttribution);

        }

        internal unsafe static void ToInterop(PFAuthenticationUserSettings self, Interop.PFAuthenticationUserSettings* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->gatherDeviceInfo = InteropWrapper.WrapperHelpers.BoolToInterop(self.GatherDeviceInfo);

            interop->gatherFocusInfo = InteropWrapper.WrapperHelpers.BoolToInterop(self.GatherFocusInfo);

            interop->needsAttribution = InteropWrapper.WrapperHelpers.BoolToInterop(self.NeedsAttribution);

        }
    }

    /// <summary>
    /// PFAuthenticationLoginResult data model.
    /// </summary>
    public struct PFAuthenticationLoginResult
    {
        /// <summary>
        /// (Optional) Results for requested info.
        /// </summary>
        public PFGetPlayerCombinedInfoResultPayload? InfoResultPayload;

        /// <summary>
        /// (Optional) The time of this user's previous login. If there was no previous login, then it's DateTime.MinValue.
        /// </summary>
        public long? LastLoginTime;

        /// <summary>
        /// True if the master_player_account was newly created on this login.
        /// </summary>
        public bool NewlyCreated;

        /// <summary>
        /// (Optional) Player's unique PlayFabId.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Settings specific to this user.
        /// </summary>
        public PFAuthenticationUserSettings? SettingsForUser;

        /// <summary>
        /// (Optional) The experimentation treatments for this user at the time of login.
        /// </summary>
        public PFTreatmentAssignment? TreatmentAssignment;

        internal unsafe PFAuthenticationLoginResult(Interop.PFAuthenticationLoginResult interop)
        {

            InfoResultPayload = (interop.infoResultPayload == null) ? null : new(*interop.infoResultPayload);

            LastLoginTime = (interop.lastLoginTime == null) ? null : *interop.lastLoginTime;

            NewlyCreated = InteropWrapper.WrapperHelpers.InteropToBool(interop.newlyCreated);

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            SettingsForUser = (interop.settingsForUser == null) ? null : new(*interop.settingsForUser);

            TreatmentAssignment = (interop.treatmentAssignment == null) ? null : new(*interop.treatmentAssignment);

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithAppleRequest data model.
    /// </summary>
    public struct PFAuthenticationLoginWithAppleRequest
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
        /// The JSON Web token (JWT) returned by Apple after login. Represented as the identityToken field in
        /// the authorization credential payload. If you choose to ignore the expiration date for identity tokens,
        /// you will receive an NotAuthorized error if Apple rotates the signing key. In this case, users have
        /// to login to provide a fresh identity token.
        /// </summary>
        public string IdentityToken;

        /// <summary>
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        /// <summary>
        /// (Optional) Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string? PlayerSecret;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithAppleRequest self, Interop.PFAuthenticationLoginWithAppleRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

            if (self.InfoRequestParameters != null)
            {
                interop->infoRequestParameters = (Interop.PFGetPlayerCombinedInfoRequestParams*)buffer.AddBuffer(sizeof(Interop.PFGetPlayerCombinedInfoRequestParams));
                PFGetPlayerCombinedInfoRequestParams.ToInterop(self.InfoRequestParameters.Value, interop->infoRequestParameters, buffer);
            }

            if (self.PlayerSecret != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerSecret, &interop->playerSecret, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithBattleNetRequest data model.
    /// </summary>
    public struct PFAuthenticationLoginWithBattleNetRequest
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
        /// The JSON Web Token (JWT) returned by Battle.net after login.
        /// </summary>
        public string IdentityToken;

        /// <summary>
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        /// <summary>
        /// (Optional) Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string? PlayerSecret;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithBattleNetRequest self, Interop.PFAuthenticationLoginWithBattleNetRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

            if (self.InfoRequestParameters != null)
            {
                interop->infoRequestParameters = (Interop.PFGetPlayerCombinedInfoRequestParams*)buffer.AddBuffer(sizeof(Interop.PFGetPlayerCombinedInfoRequestParams));
                PFGetPlayerCombinedInfoRequestParams.ToInterop(self.InfoRequestParameters.Value, interop->infoRequestParameters, buffer);
            }

            if (self.PlayerSecret != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerSecret, &interop->playerSecret, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithCustomIDRequest data model. It is highly recommended that developers ensure
    /// that it is extremely unlikely that a customer could generate an ID which is already in use by another
    /// customer. If this is the first time a user has signed in with the Custom ID and CreateAccount is set
    /// to true, a new PlayFab account will be created and linked to the Custom ID. In this case, no email
    /// or username will be associated with the PlayFab account. Otherwise, if no PlayFab account is linked
    /// to the Custom ID, an error indicating this will be returned, so that the title can guide the user
    /// through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationLoginWithCustomIDRequest
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool CreateAccount;

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
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        /// <summary>
        /// (Optional) Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string? PlayerSecret;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithCustomIDRequest self, Interop.PFAuthenticationLoginWithCustomIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

            InteropWrapper.WrapperHelpers.StringToInterop(self.CustomId, &interop->customId, buffer);

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

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithFacebookRequest data model. Facebook sign-in is accomplished using the Facebook
    /// User Access Token. More information on the Token can be found in the Facebook developer documentation
    /// (https://developers.facebook.com/docs/facebook-login/access-tokens/). In Unity, for example, the Token
    /// is available as AccessToken in the Facebook SDK ScriptableObject FB. If this is the first time a user
    /// has signed in with the Facebook account and CreateAccount is set to true, a new PlayFab account will
    /// be created and linked to the provided account's Facebook ID. In this case, no email or username will
    /// be associated with the PlayFab account. Otherwise, if no PlayFab account is linked to the Facebook
    /// account, an error indicating this will be returned, so that the title can guide the user through creation
    /// of a PlayFab account. Note that titles should never re-use the same Facebook applications between
    /// PlayFab Title IDs, as Facebook provides unique user IDs per application and doing so can result in
    /// issues with the Facebook ID for the user in their PlayFab account information. If you must re-use
    /// an application in a new PlayFab Title ID, please be sure to first unlink all accounts from Facebook,
    /// or delete all users in the first Title ID. Note: If the user is authenticated with AuthenticationToken,
    /// instead of AccessToken, the GetFriendsList API will return an empty list.
    /// </summary>
    public struct PFAuthenticationLoginWithFacebookRequest
    {
        /// <summary>
        /// Unique identifier from Facebook for the user.
        /// </summary>
        public string AccessToken;

        /// <summary>
        /// (Optional) Token used for limited login authentication.
        /// </summary>
        public string? AuthenticationToken;

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

        internal unsafe static void ToInterop(PFAuthenticationLoginWithFacebookRequest self, Interop.PFAuthenticationLoginWithFacebookRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.AccessToken, &interop->accessToken, buffer);

            if (self.AuthenticationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AuthenticationToken, &interop->authenticationToken, buffer);
            }

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

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithGameCenterRequest data model. The Game Center player identifier (https://developer.apple.com/library/ios/documentation/Accounts/Reference/ACAccountClassRef/index.html#//apple_ref/occ/instp/ACAccount/identifier)
    /// is a generated string which is stored on the local device. As with device identifiers, care must be
    /// taken to never expose a player's Game Center identifier to end users, as that could result in a user's
    /// account being compromised. If this is the first time a user has signed in with Game Center and CreateAccount
    /// is set to true, a new PlayFab account will be created and linked to the Game Center identifier. In
    /// this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
    /// account is linked to the Game Center account, an error indicating this will be returned, so that the
    /// title can guide the user through creation of a PlayFab account. If an invalid iOS Game Center player
    /// identifier is used, an error indicating this will be returned.
    /// </summary>
    public struct PFAuthenticationLoginWithGameCenterRequest
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
        /// (Optional) Unique Game Center player id.
        /// </summary>
        public string? PlayerId;

        /// <summary>
        /// (Optional) Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string? PlayerSecret;

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

        internal unsafe static void ToInterop(PFAuthenticationLoginWithGameCenterRequest self, Interop.PFAuthenticationLoginWithGameCenterRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            if (self.PlayerId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerId, &interop->playerId, buffer);
            }

            if (self.PlayerSecret != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerSecret, &interop->playerSecret, buffer);
            }

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
    /// PFAuthenticationLoginWithGoogleAccountRequest data model. Google sign-in is accomplished by obtaining
    /// a Google OAuth 2.0 credential using the Google sign-in for Android APIs on the device and passing
    /// it to this API. If this is the first time a user has signed in with the Google account and CreateAccount
    /// is set to true, a new PlayFab account will be created and linked to the Google account. Otherwise,
    /// if no PlayFab account is linked to the Google account, an error indicating this will be returned,
    /// so that the title can guide the user through creation of a PlayFab account. The current (recommended)
    /// method for obtaining a Google account credential in an Android application is to call GoogleSignInAccount.getServerAuthCode()
    /// and send the auth code as the ServerAuthCode parameter of this API. Before doing this, you must create
    /// an OAuth 2.0 web application client ID in the Google API Console and configure its client ID and secret
    /// in the PlayFab Game Manager Google Add-on for your title. This method does not require prompting of
    /// the user for additional Google account permissions, resulting in a user experience with the least
    /// possible friction. For more information about obtaining the server auth code, see https://developers.google.com/identity/sign-in/android/offline-access.
    /// The previous (deprecated) method was to obtain an OAuth access token by calling GetAccessToken() on
    /// the client and passing it as the AccessToken parameter to this API. for the with the Google OAuth
    /// 2.0 Access Token. More information on this change can be found in the Google developer documentation
    /// (https://android-developers.googleblog.com/2016/01/play-games-permissions-are-changing-in.html).
    /// </summary>
    public struct PFAuthenticationLoginWithGoogleAccountRequest
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
        /// OAuth 2.0 server authentication code obtained on the client by calling the getServerAuthCode() (https://developers.google.com/identity/sign-in/android/offline-access)
        /// Google client API.
        /// </summary>
        public string ServerAuthCode;

        /// <summary>
        /// (Optional) Optional boolean to opt out of setting the MPA email when creating a Google account, defaults
        /// to true.
        /// </summary>
        public bool? SetEmail;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithGoogleAccountRequest self, Interop.PFAuthenticationLoginWithGoogleAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.ServerAuthCode, &interop->serverAuthCode, buffer);

            if (self.SetEmail != null)
            {
                interop->setEmail = (byte*)buffer.AddBuffer(sizeof(byte));
                *interop->setEmail = InteropWrapper.WrapperHelpers.BoolToInterop(self.SetEmail.Value);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithGooglePlayGamesServicesRequest data model. Google Play Games sign-in is
    /// accomplished by obtaining a Google OAuth 2.0 credential using the Google Play Games sign-in for Android
    /// APIs on the device and passing it to this API. If this is the first time a user has signed in with
    /// the Google Play Games account and CreateAccount is set to true, a new PlayFab account will be created
    /// and linked to the Google Play Games account. Otherwise, if no PlayFab account is linked to the Google
    /// Play Games account, an error indicating this will be returned, so that the title can guide the user
    /// through creation of a PlayFab account. The current (recommended) method for obtaining a Google Play
    /// Games account credential in an Android application is to call GamesSignInClient.requestServerSideAccess()
    /// and send the auth code as the ServerAuthCode parameter of this API. Before doing this, you must create
    /// an OAuth 2.0 web application client ID in the Google API Console and configure its client ID and secret
    /// in the PlayFab Game Manager Google Add-on for your title. This method does not require prompting of
    /// the user for additional Google account permissions, resulting in a user experience with the least
    /// possible friction. For more information about obtaining the server auth code, see https://developers.google.com/games/services/android/signin.
    /// </summary>
    public struct PFAuthenticationLoginWithGooglePlayGamesServicesRequest
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
        /// OAuth 2.0 server authentication code obtained on the client by calling the requestServerSideAccess()
        /// (https://developers.google.com/games/services/android/signin) Google Play Games client API.
        /// </summary>
        public string ServerAuthCode;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithGooglePlayGamesServicesRequest self, Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.ServerAuthCode, &interop->serverAuthCode, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithNintendoServiceAccountRequest data model.
    /// </summary>
    public struct PFAuthenticationLoginWithNintendoServiceAccountRequest
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
        /// The JSON Web token (JWT) returned by Nintendo after login.
        /// </summary>
        public string IdentityToken;

        /// <summary>
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        /// <summary>
        /// (Optional) Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string? PlayerSecret;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithNintendoServiceAccountRequest self, Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

            if (self.InfoRequestParameters != null)
            {
                interop->infoRequestParameters = (Interop.PFGetPlayerCombinedInfoRequestParams*)buffer.AddBuffer(sizeof(Interop.PFGetPlayerCombinedInfoRequestParams));
                PFGetPlayerCombinedInfoRequestParams.ToInterop(self.InfoRequestParameters.Value, interop->infoRequestParameters, buffer);
            }

            if (self.PlayerSecret != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerSecret, &interop->playerSecret, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithOpenIdConnectRequest data model.
    /// </summary>
    public struct PFAuthenticationLoginWithOpenIdConnectRequest
    {
        /// <summary>
        /// A name that identifies which configured OpenID Connect provider relationship to use. Maximum 100
        /// characters.
        /// </summary>
        public string ConnectionId;

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
        /// The JSON Web token (JWT) returned by the identity provider after login. Represented as the id_token
        /// field in the identity provider's response.
        /// </summary>
        public string IdToken;

        /// <summary>
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        /// <summary>
        /// (Optional) Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string? PlayerSecret;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithOpenIdConnectRequest self, Interop.PFAuthenticationLoginWithOpenIdConnectRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.ConnectionId, &interop->connectionId, buffer);

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdToken, &interop->idToken, buffer);

            if (self.InfoRequestParameters != null)
            {
                interop->infoRequestParameters = (Interop.PFGetPlayerCombinedInfoRequestParams*)buffer.AddBuffer(sizeof(Interop.PFGetPlayerCombinedInfoRequestParams));
                PFGetPlayerCombinedInfoRequestParams.ToInterop(self.InfoRequestParameters.Value, interop->infoRequestParameters, buffer);
            }

            if (self.PlayerSecret != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerSecret, &interop->playerSecret, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithPSNRequest data model. If this is the first time a user has signed in with
    /// the PlayStation :tm: Network account and CreateAccount is set to true, a new PlayFab account will
    /// be created and linked to the PlayStation :tm: Network account. In this case, no email or username
    /// will be associated with the PlayFab account. Otherwise, if no PlayFab account is linked to the PlayStation
    /// :tm: Network account, an error indicating this will be returned, so that the title can guide the user
    /// through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationLoginWithPSNRequest
    {
        /// <summary>
        /// Auth code provided by the PlayStation :tm: Network OAuth provider.
        /// </summary>
        public string AuthCode;

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
        /// (Optional) Id of the PlayStation :tm: Network issuer environment. If null, defaults to production
        /// environment.
        /// </summary>
        public int? IssuerId;

        /// <summary>
        /// (Optional) Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string? PlayerSecret;

        /// <summary>
        /// (Optional) Redirect URI supplied to PlayStation :tm: Network when requesting an auth code.
        /// </summary>
        public string? RedirectUri;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithPSNRequest self, Interop.PFAuthenticationLoginWithPSNRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.AuthCode, &interop->authCode, buffer);

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

            if (self.IssuerId != null)
            {
                interop->issuerId = (int*)buffer.AddBuffer(sizeof(int));
                *interop->issuerId = self.IssuerId.Value;
            }

            if (self.PlayerSecret != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerSecret, &interop->playerSecret, buffer);
            }

            if (self.RedirectUri != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RedirectUri, &interop->redirectUri, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithSteamRequest data model. Steam sign-in is accomplished with the Steam Session
    /// Ticket. More information on the Ticket can be found in the Steamworks SDK, here: https://partner.steamgames.com/documentation/auth.
    /// NOTE: For Steam authentication to work, the title must be configured with the Steam Application ID
    /// and Web API Key in the PlayFab Game Manager (under Steam in the Add-ons Marketplace). You can obtain
    /// a Web API Key from the Permissions page of any Group associated with your App ID in the Steamworks
    /// site. If this is the first time a user has signed in with the Steam account and CreateAccount is set
    /// to true, a new PlayFab account will be created and linked to the provided account's Steam ID. In this
    /// case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab account
    /// is linked to the Steam account, an error indicating this will be returned, so that the title can guide
    /// the user through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationLoginWithSteamRequest
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
        /// Authentication token for the user, returned as a byte array from Steam, and converted to a string
        /// (for example, the byte 0x08 should become "08").
        /// </summary>
        public string SteamTicket;

        /// <summary>
        /// (Optional) True if ticket was generated using ISteamUser::GetAuthTicketForWebAPI() using "AzurePlayFab"
        /// as the identity string. False if the ticket was generated with ISteamUser::GetAuthSessionTicket().
        /// </summary>
        public bool? TicketIsServiceSpecific;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithSteamRequest self, Interop.PFAuthenticationLoginWithSteamRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.SteamTicket, &interop->steamTicket, buffer);

            if (self.TicketIsServiceSpecific != null)
            {
                interop->ticketIsServiceSpecific = (byte*)buffer.AddBuffer(sizeof(byte));
                *interop->ticketIsServiceSpecific = InteropWrapper.WrapperHelpers.BoolToInterop(self.TicketIsServiceSpecific.Value);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithXboxRequest data model. If this is the first time a user has signed in with
    /// the Xbox Live account and CreateAccount is set to true, a new PlayFab account will be created and
    /// linked to the Xbox Live account. In this case, no email or username will be associated with the PlayFab
    /// account. Otherwise, if no PlayFab account is linked to the Xbox Live account, an error indicating
    /// this will be returned, so that the title can guide the user through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationLoginWithXboxRequest
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
        /// Token provided by the Xbox Live SDK/XDK method GetTokenAndSignatureAsync("POST", "https://playfabapi.com/",
        /// "").
        /// </summary>
        public string XboxToken;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithXboxRequest self, Interop.PFAuthenticationLoginWithXboxRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.XboxToken, &interop->xboxToken, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationServerLoginWithAndroidDeviceIDRequest data model. On Android devices, the recommendation
    /// is to use the Settings.Secure.ANDROID_ID as the AndroidDeviceId, as described in this blog post (http://android-developers.blogspot.com/2011/03/identifying-app-installations.html).
    /// More information on this identifier can be found in the Android documentation (http://developer.android.com/reference/android/provider/Settings.Secure.html).
    /// If this is the first time a user has signed in with the Android device and CreateAccount is set to
    /// true, a new PlayFab account will be created and linked to the Android device ID. In this case, no
    /// email or username will be associated with the PlayFab account. Otherwise, if no PlayFab account is
    /// linked to the Android device, an error indicating this will be returned, so that the title can guide
    /// the user through creation of a PlayFab account. Please note that while multiple devices of this type
    /// can be linked to a single user account, only the one most recently used to login (or most recently
    /// linked) will be reflected in the user's account information. We will be updating to show all linked
    /// devices in a future release.
    /// </summary>
    public struct PFAuthenticationServerLoginWithAndroidDeviceIDRequest
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
        /// (Optional) Specific Operating System version for the user's device.
        /// </summary>
        public string? OS;

        internal unsafe static void ToInterop(PFAuthenticationServerLoginWithAndroidDeviceIDRequest self, Interop.PFAuthenticationServerLoginWithAndroidDeviceIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AndroidDevice != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AndroidDevice, &interop->androidDevice, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.AndroidDeviceId, &interop->androidDeviceId, buffer);

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

            if (self.OS != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OS, &interop->OS, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationServerLoginWithBattleNetRequest data model.
    /// </summary>
    public struct PFAuthenticationServerLoginWithBattleNetRequest
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
        /// The JSON Web Token (JWT) returned by Battle.net after login.
        /// </summary>
        public string IdentityToken;

        /// <summary>
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        internal unsafe static void ToInterop(PFAuthenticationServerLoginWithBattleNetRequest self, Interop.PFAuthenticationServerLoginWithBattleNetRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.IdentityToken, &interop->identityToken, buffer);

            if (self.InfoRequestParameters != null)
            {
                interop->infoRequestParameters = (Interop.PFGetPlayerCombinedInfoRequestParams*)buffer.AddBuffer(sizeof(Interop.PFGetPlayerCombinedInfoRequestParams));
                PFGetPlayerCombinedInfoRequestParams.ToInterop(self.InfoRequestParameters.Value, interop->infoRequestParameters, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationServerLoginWithCustomIDRequest data model. It is highly recommended that developers
    /// ensure that it is extremely unlikely that a customer could generate an ID which is already in use
    /// by another customer. If this is the first time a user has signed in with the Custom ID and CreateAccount
    /// is set to true, a new PlayFab account will be created and linked to the Custom ID. In this case, no
    /// email or username will be associated with the PlayFab account. Otherwise, if no PlayFab account is
    /// linked to the Custom ID, an error indicating this will be returned, so that the title can guide the
    /// user through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationServerLoginWithCustomIDRequest
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool CreateAccount;

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
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        internal unsafe static void ToInterop(PFAuthenticationServerLoginWithCustomIDRequest self, Interop.PFAuthenticationServerLoginWithCustomIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

            InteropWrapper.WrapperHelpers.StringToInterop(self.CustomId, &interop->customId, buffer);

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

        }
    }

    /// <summary>
    /// PFAuthenticationServerLoginWithIOSDeviceIDRequest data model. On iOS devices, the identifierForVendor
    /// (https://developer.apple.com/library/ios/documentation/UIKit/Reference/UIDevice_Class/index.html#//apple_ref/occ/instp/UIDevice/identifierForVendor)
    /// must be used as the DeviceId, as the UIDevice uniqueIdentifier has been deprecated as of iOS 5, and
    /// use of the advertisingIdentifier for this purpose will result in failure of Apple's certification
    /// process. If this is the first time a user has signed in with the iOS device and CreateAccount is set
    /// to true, a new PlayFab account will be created and linked to the vendor-specific iOS device ID. In
    /// this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
    /// account is linked to the iOS device, an error indicating this will be returned, so that the title
    /// can guide the user through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationServerLoginWithIOSDeviceIDRequest
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
        /// Vendor-specific iOS identifier for the user's device.
        /// </summary>
        public string DeviceId;

        /// <summary>
        /// (Optional) Specific model of the user's device.
        /// </summary>
        public string? DeviceModel;

        /// <summary>
        /// (Optional) Flags for which pieces of info to return for the user.
        /// </summary>
        public PFGetPlayerCombinedInfoRequestParams? InfoRequestParameters;

        /// <summary>
        /// (Optional) Specific Operating System version for the user's device.
        /// </summary>
        public string? OS;

        internal unsafe static void ToInterop(PFAuthenticationServerLoginWithIOSDeviceIDRequest self, Interop.PFAuthenticationServerLoginWithIOSDeviceIDRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->createAccount = InteropWrapper.WrapperHelpers.BoolToInterop(self.CreateAccount);

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

            if (self.InfoRequestParameters != null)
            {
                interop->infoRequestParameters = (Interop.PFGetPlayerCombinedInfoRequestParams*)buffer.AddBuffer(sizeof(Interop.PFGetPlayerCombinedInfoRequestParams));
                PFGetPlayerCombinedInfoRequestParams.ToInterop(self.InfoRequestParameters.Value, interop->infoRequestParameters, buffer);
            }

            if (self.OS != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OS, &interop->OS, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationServerLoginWithPSNRequest data model. If this is the first time a user has signed
    /// in with the PlayStation :tm: Network account and CreateAccount is set to true, a new PlayFab account
    /// will be created and linked to the PlayStation :tm: Network account. In this case, no email or username
    /// will be associated with the PlayFab account. Otherwise, if no PlayFab account is linked to the PlayStation
    /// :tm: Network account, an error indicating this will be returned, so that the title can guide the user
    /// through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationServerLoginWithPSNRequest
    {
        /// <summary>
        /// Auth code provided by the PlayStation :tm: Network OAuth provider.
        /// </summary>
        public string AuthCode;

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
        /// (Optional) Id of the PlayStation :tm: Network issuer environment. If null, defaults to production
        /// environment.
        /// </summary>
        public int? IssuerId;

        /// <summary>
        /// Redirect URI supplied to PlayStation :tm: Network when requesting an auth code.
        /// </summary>
        public string RedirectUri;

        internal unsafe static void ToInterop(PFAuthenticationServerLoginWithPSNRequest self, Interop.PFAuthenticationServerLoginWithPSNRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.AuthCode, &interop->authCode, buffer);

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

            if (self.IssuerId != null)
            {
                interop->issuerId = (int*)buffer.AddBuffer(sizeof(int));
                *interop->issuerId = self.IssuerId.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.RedirectUri, &interop->redirectUri, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithServerCustomIdRequest data model.
    /// </summary>
    public struct PFAuthenticationLoginWithServerCustomIdRequest
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
        /// The backend server identifier for this player.
        /// </summary>
        public string ServerCustomId;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithServerCustomIdRequest self, Interop.PFAuthenticationLoginWithServerCustomIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.ServerCustomId, &interop->serverCustomId, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithSteamIdRequest data model. If this is the first time a user has signed in
    /// with the Steam ID and CreateAccount is set to true, a new PlayFab account will be created and linked
    /// to the Steam account. In this case, no email or username will be associated with the PlayFab account.
    /// Otherwise, if no PlayFab account is linked to the Steam account, an error indicating this will be
    /// returned, so that the title can guide the user through creation of a PlayFab account. Steam users
    /// that are not logged into the Steam Client app will only have their Steam username synced, other data,
    /// such as currency and country will not be available until they login while the Client is open.
    /// </summary>
    public struct PFAuthenticationLoginWithSteamIdRequest
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
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamId;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithSteamIdRequest self, Interop.PFAuthenticationLoginWithSteamIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.SteamId, &interop->steamId, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationServerLoginWithXboxRequest data model. If this is the first time a user has signed
    /// in with the Xbox Live account and CreateAccount is set to true, a new PlayFab account will be created
    /// and linked to the Xbox Live account. In this case, no email or username will be associated with the
    /// PlayFab account. Otherwise, if no PlayFab account is linked to the Xbox Live account, an error indicating
    /// this will be returned, so that the title can guide the user through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationServerLoginWithXboxRequest
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
        /// Token provided by the Xbox Live SDK/XDK method GetTokenAndSignatureAsync("POST", "https://playfabapi.com/",
        /// "").
        /// </summary>
        public string XboxToken;

        internal unsafe static void ToInterop(PFAuthenticationServerLoginWithXboxRequest self, Interop.PFAuthenticationServerLoginWithXboxRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.XboxToken, &interop->xboxToken, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationLoginWithXboxIdRequest data model. If this is the first time a user has signed in
    /// with the Xbox ID and CreateAccount is set to true, a new PlayFab account will be created and linked
    /// to the Xbox Live account. In this case, no email or username will be associated with the PlayFab account.
    /// Otherwise, if no PlayFab account is linked to the Xbox Live account, an error indicating this will
    /// be returned, so that the title can guide the user through creation of a PlayFab account.
    /// </summary>
    public struct PFAuthenticationLoginWithXboxIdRequest
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
        /// The id of Xbox Live sandbox.
        /// </summary>
        public string Sandbox;

        /// <summary>
        /// Unique Xbox identifier for a user.
        /// </summary>
        public string XboxId;

        internal unsafe static void ToInterop(PFAuthenticationLoginWithXboxIdRequest self, Interop.PFAuthenticationLoginWithXboxIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.Sandbox, &interop->sandbox, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.XboxId, &interop->xboxId, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationAuthenticateCustomIdRequest data model. Create or return a game_server entity token.
    /// Caller must be a title entity.
    /// </summary>
    public struct PFAuthenticationAuthenticateCustomIdRequest
    {
        /// <summary>
        /// The customId used to create and retrieve game_server entity tokens. This is unique at the title level.
        /// CustomId must be between 32 and 100 characters.
        /// </summary>
        public string CustomId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFAuthenticationAuthenticateCustomIdRequest self, Interop.PFAuthenticationAuthenticateCustomIdRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.CustomId, &interop->customId, buffer);

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
    }

    /// <summary>
    /// PFAuthenticationEntityTokenResponse data model.
    /// </summary>
    public struct PFAuthenticationEntityTokenResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The token used to set X-EntityToken for all entity based API calls.
        /// </summary>
        public string? EntityToken;

        /// <summary>
        /// (Optional) The time the token will expire, if it is an expiring token, in UTC.
        /// </summary>
        public long? TokenExpiration;

        internal unsafe PFAuthenticationEntityTokenResponse(Interop.PFAuthenticationEntityTokenResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            EntityToken = (interop.entityToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.entityToken);

            TokenExpiration = (interop.tokenExpiration == null) ? null : *interop.tokenExpiration;

        }

        internal unsafe static void ToInterop(PFAuthenticationEntityTokenResponse self, Interop.PFAuthenticationEntityTokenResponse* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            if (self.EntityToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EntityToken, &interop->entityToken, buffer);
            }

            if (self.TokenExpiration != null)
            {
                interop->tokenExpiration = (long*)buffer.AddBuffer(sizeof(long));
                *interop->tokenExpiration = self.TokenExpiration.Value;
            }

        }
    }

    /// <summary>
    /// PFAuthenticationAuthenticateCustomIdResult data model.
    /// </summary>
    public struct PFAuthenticationAuthenticateCustomIdResult
    {
        /// <summary>
        /// (Optional) The token generated used to set X-EntityToken for game_server calls.
        /// </summary>
        public PFAuthenticationEntityTokenResponse? EntityToken;

        /// <summary>
        /// True if the account was newly created on this authentication.
        /// </summary>
        public bool NewlyCreated;

        internal unsafe PFAuthenticationAuthenticateCustomIdResult(Interop.PFAuthenticationAuthenticateCustomIdResult interop)
        {

            EntityToken = (interop.entityToken == null) ? null : new(*interop.entityToken);

            NewlyCreated = InteropWrapper.WrapperHelpers.InteropToBool(interop.newlyCreated);

        }
    }

    /// <summary>
    /// PFAuthenticationDeleteRequest data model. Delete a game_server entity. The caller can be the game_server
    /// entity attempting to delete itself. Or a title entity attempting to delete game_server entities for
    /// this title.
    /// </summary>
    public struct PFAuthenticationDeleteRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The game_server entity to be removed.
        /// </summary>
        public PFEntityKey Entity;

        internal unsafe static void ToInterop(PFAuthenticationDeleteRequest self, Interop.PFAuthenticationDeleteRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationGetEntityRequest data model. This API must be called with X-SecretKey, X-Authentication
    /// or X-EntityToken headers. An optional EntityKey may be included to attempt to set the resulting EntityToken
    /// to a specific entity, however the entity must be a relation of the caller, such as the master_player_account
    /// of a character. If sending X-EntityToken the account will be marked as freshly logged in and will
    /// issue a new token. If using X-Authentication or X-EntityToken the header must still be valid and cannot
    /// be expired or revoked.
    /// </summary>
    public struct PFAuthenticationGetEntityRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe static void ToInterop(PFAuthenticationGetEntityRequest self, Interop.PFAuthenticationGetEntityRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

        }
    }

    /// <summary>
    /// PFAuthenticationValidateEntityTokenRequest data model. Given an entity token, validates that it hasn't
    /// expired or been revoked and will return details of the owner.
    /// </summary>
    public struct PFAuthenticationValidateEntityTokenRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Client EntityToken.
        /// </summary>
        public string EntityToken;

        internal unsafe static void ToInterop(PFAuthenticationValidateEntityTokenRequest self, Interop.PFAuthenticationValidateEntityTokenRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.EntityToken, &interop->entityToken, buffer);

        }
    }

    /// <summary>
    /// PFAuthenticationValidateEntityTokenResponse data model.
    /// </summary>
    public struct PFAuthenticationValidateEntityTokenResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The authenticated device for this entity, for the given login.
        /// </summary>
        public PFAuthenticationIdentifiedDeviceType? IdentifiedDeviceType;

        /// <summary>
        /// (Optional) The identity provider for this entity, for the given login.
        /// </summary>
        public PFLoginIdentityProvider? IdentityProvider;

        /// <summary>
        /// (Optional) The ID issued by the identity provider, e.g. a XUID on Xbox Live.
        /// </summary>
        public string? IdentityProviderIssuedId;

        /// <summary>
        /// (Optional) The lineage of this profile.
        /// </summary>
        public PFEntityLineage? Lineage;

        internal unsafe PFAuthenticationValidateEntityTokenResponse(Interop.PFAuthenticationValidateEntityTokenResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            IdentifiedDeviceType = (interop.identifiedDeviceType == null) ? null : (PFAuthenticationIdentifiedDeviceType?)(*interop.identifiedDeviceType);

            IdentityProvider = (interop.identityProvider == null) ? null : (PFLoginIdentityProvider?)(*interop.identityProvider);

            IdentityProviderIssuedId = (interop.identityProviderIssuedId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.identityProviderIssuedId);

            Lineage = (interop.lineage == null) ? null : new(*interop.lineage);

        }
    }

}
