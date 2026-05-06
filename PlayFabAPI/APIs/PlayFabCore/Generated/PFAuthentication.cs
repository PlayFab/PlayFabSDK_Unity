// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Method for a server to validate a client provided EntityToken. Only callable by the title entity.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAuthenticationValidateEntityTokenResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Given an entity token, validates that it hasn't expired or been revoked and will return details of
        /// the owner.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationValidateEntityTokenGetResultSize"/>
        /// and <see cref="PFAuthenticationValidateEntityTokenGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFAuthenticationValidateEntityTokenResponse>> AuthenticationValidateEntityTokenAsync(
            PFAuthenticationValidateEntityTokenRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationValidateEntityTokenAsync(InteropHandle, request);
        }
#endif
    }

    public partial class PFPlayerEntity
    {
        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithAppleAsync(
            PFAuthenticationLoginWithAppleRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithAppleAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithAppleAsync(
            PFAuthenticationLoginWithAppleRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithAppleAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithBattleNetAsync(
            PFAuthenticationLoginWithBattleNetRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithBattleNetAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithBattleNetAsync(
            PFAuthenticationLoginWithBattleNetRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithBattleNetAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithCustomIDAsync(
            PFAuthenticationLoginWithCustomIDRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithCustomIDAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithCustomIDAsync(
            PFAuthenticationLoginWithCustomIDRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithCustomIDAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithFacebookAsync(
            PFAuthenticationLoginWithFacebookRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithFacebookAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithFacebookAsync(
            PFAuthenticationLoginWithFacebookRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithFacebookAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithGameCenterAsync(
            PFAuthenticationLoginWithGameCenterRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithGameCenterAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithGameCenterAsync(
            PFAuthenticationLoginWithGameCenterRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithGameCenterAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithGoogleAccountAsync(
            PFAuthenticationLoginWithGoogleAccountRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithGoogleAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithGoogleAccountAsync(
            PFAuthenticationLoginWithGoogleAccountRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithGoogleAccountAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithGooglePlayGamesServicesAsync(
            PFAuthenticationLoginWithGooglePlayGamesServicesRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithGooglePlayGamesServicesAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithGooglePlayGamesServicesAsync(
            PFAuthenticationLoginWithGooglePlayGamesServicesRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithGooglePlayGamesServicesAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithNintendoServiceAccountAsync(
            PFAuthenticationLoginWithNintendoServiceAccountRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithNintendoServiceAccountAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithNintendoServiceAccountAsync(
            PFAuthenticationLoginWithNintendoServiceAccountRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithNintendoServiceAccountAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithOpenIdConnectAsync(
            PFAuthenticationLoginWithOpenIdConnectRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithOpenIdConnectAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithOpenIdConnectAsync(
            PFAuthenticationLoginWithOpenIdConnectRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithOpenIdConnectAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithPSNAsync(
            PFAuthenticationLoginWithPSNRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithPSNAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithPSNAsync(
            PFAuthenticationLoginWithPSNRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithPSNAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithSteamAsync(
            PFAuthenticationLoginWithSteamRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithSteamAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithSteamAsync(
            PFAuthenticationLoginWithSteamRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithSteamAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public Task<PFResult> AuthenticationReLoginWithXboxAsync(
            PFAuthenticationLoginWithXboxRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithXboxAsync(InteropHandle, request);
        }

        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Reauthenticates a PFLocalUser's existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// If the internal async work is successful, the cached EntityToken for the PFLocalUser's PFEntityHandle will be updated in place.
        /// </remarks>
        public PFResult AuthenticationLocalUserReLoginWithXboxAsync(
            PFAuthenticationLoginWithXboxRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserReLoginWithXboxAsync(InteropHandle, request, loginHandlerContext);
        }
    }

    public partial class PFTitleEntity
    {
        /// <summary>
        /// Delete a game_server entity.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Delete a game_server entity. The caller can be the game_server entity attempting to delete itself.
        /// Or a title entity attempting to delete game_server entities for this title.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public Task<PFResult> AuthenticationDeleteAsync(
            PFAuthenticationDeleteRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationDeleteAsync(InteropHandle, request);
        }
    }

    public partial class PFServiceConfig
    {
        /// <summary>
        /// Signs in the user with a Sign in with Apple identity token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on iOS and macOS.
        /// See also ClientLinkAppleAsync, ClientUnlinkAppleAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithAppleGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithAppleAsync(
            PFAuthenticationLoginWithAppleRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithAppleAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs in the user with a Sign in with Apple identity token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on iOS and macOS.
        /// See also ClientLinkAppleAsync, ClientUnlinkAppleAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithAppleGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithAppleAsync(
            PFAuthenticationLoginWithAppleRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithAppleAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Sign in the user with a Battle.net identity token
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ClientLinkBattleNetAccountAsync, ClientUnlinkBattleNetAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithBattleNetGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithBattleNetAsync(
            PFAuthenticationLoginWithBattleNetRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithBattleNetAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Sign in the user with a Battle.net identity token
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ClientLinkBattleNetAccountAsync, ClientUnlinkBattleNetAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithBattleNetGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithBattleNetAsync(
            PFAuthenticationLoginWithBattleNetRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithBattleNetAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// It is highly recommended that developers ensure that it is extremely unlikely that a customer could
        /// generate an ID which is already in use by another customer. If this is the first time a user has signed
        /// in with the Custom ID and CreateAccount is set to true, a new PlayFab account will be created and
        /// linked to the Custom ID. In this case, no email or username will be associated with the PlayFab account.
        /// Otherwise, if no PlayFab account is linked to the Custom ID, an error indicating this will be returned,
        /// so that the title can guide the user through creation of a PlayFab account. See also ClientLinkCustomIDAsync,
        /// ClientUnlinkCustomIDAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithCustomIDGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithCustomIDAsync(
            PFAuthenticationLoginWithCustomIDRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithCustomIDAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// It is highly recommended that developers ensure that it is extremely unlikely that a customer could
        /// generate an ID which is already in use by another customer. If this is the first time a user has signed
        /// in with the Custom ID and CreateAccount is set to true, a new PlayFab account will be created and
        /// linked to the Custom ID. In this case, no email or username will be associated with the PlayFab account.
        /// Otherwise, if no PlayFab account is linked to the Custom ID, an error indicating this will be returned,
        /// so that the title can guide the user through creation of a PlayFab account. See also ClientLinkCustomIDAsync,
        /// ClientUnlinkCustomIDAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithCustomIDGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithCustomIDAsync(
            PFAuthenticationLoginWithCustomIDRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithCustomIDAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using a Facebook access token, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on Android and iOS.
        /// Facebook sign-in is accomplished using the Facebook User Access Token. More information on the Token
        /// can be found in the Facebook developer documentation (https://developers.facebook.com/docs/facebook-login/access-tokens/).
        /// In Unity, for example, the Token is available as AccessToken in the Facebook SDK ScriptableObject
        /// FB. If this is the first time a user has signed in with the Facebook account and CreateAccount is
        /// set to true, a new PlayFab account will be created and linked to the provided account's Facebook ID.
        /// In this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
        /// account is linked to the Facebook account, an error indicating this will be returned, so that the
        /// title can guide the user through creation of a PlayFab account. Note that titles should never re-use
        /// the same Facebook applications between PlayFab Title IDs, as Facebook provides unique user IDs per
        /// application and doing so can result in issues with the Facebook ID for the user in their PlayFab account
        /// information. If you must re-use an application in a new PlayFab Title ID, please be sure to first
        /// unlink all accounts from Facebook, or delete all users in the first Title ID. Note: If the user is
        /// authenticated with AuthenticationToken, instead of AccessToken, the GetFriendsList API will return
        /// an empty list. See also ClientLinkFacebookAccountAsync, ClientUnlinkFacebookAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithFacebookGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithFacebookAsync(
            PFAuthenticationLoginWithFacebookRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithFacebookAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs the user in using a Facebook access token, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on Android and iOS.
        /// Facebook sign-in is accomplished using the Facebook User Access Token. More information on the Token
        /// can be found in the Facebook developer documentation (https://developers.facebook.com/docs/facebook-login/access-tokens/).
        /// In Unity, for example, the Token is available as AccessToken in the Facebook SDK ScriptableObject
        /// FB. If this is the first time a user has signed in with the Facebook account and CreateAccount is
        /// set to true, a new PlayFab account will be created and linked to the provided account's Facebook ID.
        /// In this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
        /// account is linked to the Facebook account, an error indicating this will be returned, so that the
        /// title can guide the user through creation of a PlayFab account. Note that titles should never re-use
        /// the same Facebook applications between PlayFab Title IDs, as Facebook provides unique user IDs per
        /// application and doing so can result in issues with the Facebook ID for the user in their PlayFab account
        /// information. If you must re-use an application in a new PlayFab Title ID, please be sure to first
        /// unlink all accounts from Facebook, or delete all users in the first Title ID. Note: If the user is
        /// authenticated with AuthenticationToken, instead of AccessToken, the GetFriendsList API will return
        /// an empty list. See also ClientLinkFacebookAccountAsync, ClientUnlinkFacebookAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithFacebookGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithFacebookAsync(
            PFAuthenticationLoginWithFacebookRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithFacebookAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using an iOS Game Center player identifier, returning a session identifier that
        /// can subsequently be used for API calls which require an authenticated user. Logging in with a Game
        /// Center ID is insecure if you do not include the optional PublicKeyUrl, Salt, Signature, and Timestamp
        /// parameters in this request. It is recommended you require these parameters on all Game Center calls
        /// by going to the Apple Add-ons page in the PlayFab Game Manager and enabling the 'Require secure authentication
        /// only for this app' option.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on iOS.
        /// The Game Center player identifier (https://developer.apple.com/library/ios/documentation/Accounts/Reference/ACAccountClassRef/index.html#//apple_ref/occ/instp/ACAccount/identifier)
        /// is a generated string which is stored on the local device. As with device identifiers, care must be
        /// taken to never expose a player's Game Center identifier to end users, as that could result in a user's
        /// account being compromised. If this is the first time a user has signed in with Game Center and CreateAccount
        /// is set to true, a new PlayFab account will be created and linked to the Game Center identifier. In
        /// this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
        /// account is linked to the Game Center account, an error indicating this will be returned, so that the
        /// title can guide the user through creation of a PlayFab account. If an invalid iOS Game Center player
        /// identifier is used, an error indicating this will be returned. See also ClientLoginWithIOSDeviceIDAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithGameCenterGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithGameCenterAsync(
            PFAuthenticationLoginWithGameCenterRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithGameCenterAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs the user in using an iOS Game Center player identifier, returning a session identifier that
        /// can subsequently be used for API calls which require an authenticated user. Logging in with a Game
        /// Center ID is insecure if you do not include the optional PublicKeyUrl, Salt, Signature, and Timestamp
        /// parameters in this request. It is recommended you require these parameters on all Game Center calls
        /// by going to the Apple Add-ons page in the PlayFab Game Manager and enabling the 'Require secure authentication
        /// only for this app' option.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on iOS.
        /// The Game Center player identifier (https://developer.apple.com/library/ios/documentation/Accounts/Reference/ACAccountClassRef/index.html#//apple_ref/occ/instp/ACAccount/identifier)
        /// is a generated string which is stored on the local device. As with device identifiers, care must be
        /// taken to never expose a player's Game Center identifier to end users, as that could result in a user's
        /// account being compromised. If this is the first time a user has signed in with Game Center and CreateAccount
        /// is set to true, a new PlayFab account will be created and linked to the Game Center identifier. In
        /// this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
        /// account is linked to the Game Center account, an error indicating this will be returned, so that the
        /// title can guide the user through creation of a PlayFab account. If an invalid iOS Game Center player
        /// identifier is used, an error indicating this will be returned. See also ClientLoginWithIOSDeviceIDAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithGameCenterGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithGameCenterAsync(
            PFAuthenticationLoginWithGameCenterRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithGameCenterAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using their Google account credentials
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on Android.
        /// Google sign-in is accomplished by obtaining a Google OAuth 2.0 credential using the Google sign-in
        /// for Android APIs on the device and passing it to this API. If this is the first time a user has signed
        /// in with the Google account and CreateAccount is set to true, a new PlayFab account will be created
        /// and linked to the Google account. Otherwise, if no PlayFab account is linked to the Google account,
        /// an error indicating this will be returned, so that the title can guide the user through creation of
        /// a PlayFab account. The current (recommended) method for obtaining a Google account credential in an
        /// Android application is to call GoogleSignInAccount.getServerAuthCode() and send the auth code as the
        /// ServerAuthCode parameter of this API. Before doing this, you must create an OAuth 2.0 web application
        /// client ID in the Google API Console and configure its client ID and secret in the PlayFab Game Manager
        /// Google Add-on for your title. This method does not require prompting of the user for additional Google
        /// account permissions, resulting in a user experience with the least possible friction. For more information
        /// about obtaining the server auth code, see https://developers.google.com/identity/sign-in/android/offline-access.
        /// The previous (deprecated) method was to obtain an OAuth access token by calling GetAccessToken() on
        /// the client and passing it as the AccessToken parameter to this API. for the with the Google OAuth
        /// 2.0 Access Token. More information on this change can be found in the Google developer documentation
        /// (https://android-developers.googleblog.com/2016/01/play-games-permissions-are-changing-in.html).
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithGoogleAccountGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithGoogleAccountAsync(
            PFAuthenticationLoginWithGoogleAccountRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithGoogleAccountAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs the user in using their Google account credentials
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on Android.
        /// Google sign-in is accomplished by obtaining a Google OAuth 2.0 credential using the Google sign-in
        /// for Android APIs on the device and passing it to this API. If this is the first time a user has signed
        /// in with the Google account and CreateAccount is set to true, a new PlayFab account will be created
        /// and linked to the Google account. Otherwise, if no PlayFab account is linked to the Google account,
        /// an error indicating this will be returned, so that the title can guide the user through creation of
        /// a PlayFab account. The current (recommended) method for obtaining a Google account credential in an
        /// Android application is to call GoogleSignInAccount.getServerAuthCode() and send the auth code as the
        /// ServerAuthCode parameter of this API. Before doing this, you must create an OAuth 2.0 web application
        /// client ID in the Google API Console and configure its client ID and secret in the PlayFab Game Manager
        /// Google Add-on for your title. This method does not require prompting of the user for additional Google
        /// account permissions, resulting in a user experience with the least possible friction. For more information
        /// about obtaining the server auth code, see https://developers.google.com/identity/sign-in/android/offline-access.
        /// The previous (deprecated) method was to obtain an OAuth access token by calling GetAccessToken() on
        /// the client and passing it as the AccessToken parameter to this API. for the with the Google OAuth
        /// 2.0 Access Token. More information on this change can be found in the Google developer documentation
        /// (https://android-developers.googleblog.com/2016/01/play-games-permissions-are-changing-in.html).
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithGoogleAccountGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithGoogleAccountAsync(
            PFAuthenticationLoginWithGoogleAccountRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithGoogleAccountAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using their Google Play Games account credentials
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on Android.
        /// Google Play Games sign-in is accomplished by obtaining a Google OAuth 2.0 credential using the Google
        /// Play Games sign-in for Android APIs on the device and passing it to this API. If this is the first
        /// time a user has signed in with the Google Play Games account and CreateAccount is set to true, a new
        /// PlayFab account will be created and linked to the Google Play Games account. Otherwise, if no PlayFab
        /// account is linked to the Google Play Games account, an error indicating this will be returned, so
        /// that the title can guide the user through creation of a PlayFab account. The current (recommended)
        /// method for obtaining a Google Play Games account credential in an Android application is to call GamesSignInClient.requestServerSideAccess()
        /// and send the auth code as the ServerAuthCode parameter of this API. Before doing this, you must create
        /// an OAuth 2.0 web application client ID in the Google API Console and configure its client ID and secret
        /// in the PlayFab Game Manager Google Add-on for your title. This method does not require prompting of
        /// the user for additional Google account permissions, resulting in a user experience with the least
        /// possible friction. For more information about obtaining the server auth code, see https://developers.google.com/games/services/android/signin.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithGooglePlayGamesServicesGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithGooglePlayGamesServicesAsync(
            PFAuthenticationLoginWithGooglePlayGamesServicesRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithGooglePlayGamesServicesAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs the user in using their Google Play Games account credentials
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on Android.
        /// Google Play Games sign-in is accomplished by obtaining a Google OAuth 2.0 credential using the Google
        /// Play Games sign-in for Android APIs on the device and passing it to this API. If this is the first
        /// time a user has signed in with the Google Play Games account and CreateAccount is set to true, a new
        /// PlayFab account will be created and linked to the Google Play Games account. Otherwise, if no PlayFab
        /// account is linked to the Google Play Games account, an error indicating this will be returned, so
        /// that the title can guide the user through creation of a PlayFab account. The current (recommended)
        /// method for obtaining a Google Play Games account credential in an Android application is to call GamesSignInClient.requestServerSideAccess()
        /// and send the auth code as the ServerAuthCode parameter of this API. Before doing this, you must create
        /// an OAuth 2.0 web application client ID in the Google API Console and configure its client ID and secret
        /// in the PlayFab Game Manager Google Add-on for your title. This method does not require prompting of
        /// the user for additional Google account permissions, resulting in a user experience with the least
        /// possible friction. For more information about obtaining the server auth code, see https://developers.google.com/games/services/android/signin.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithGooglePlayGamesServicesGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithGooglePlayGamesServicesAsync(
            PFAuthenticationLoginWithGooglePlayGamesServicesRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithGooglePlayGamesServicesAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs in the user with a Nintendo service account token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on Nintendo Switch.
        /// See also ClientLinkNintendoServiceAccountAsync, ClientUnlinkNintendoServiceAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithNintendoServiceAccountGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithNintendoServiceAccountAsync(
            PFAuthenticationLoginWithNintendoServiceAccountRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithNintendoServiceAccountAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs in the user with a Nintendo service account token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on Nintendo Switch.
        /// See also ClientLinkNintendoServiceAccountAsync, ClientUnlinkNintendoServiceAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithNintendoServiceAccountGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithNintendoServiceAccountAsync(
            PFAuthenticationLoginWithNintendoServiceAccountRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithNintendoServiceAccountAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Logs in a user with an Open ID Connect JWT created by an existing relationship between a title and
        /// an Open ID Connect provider.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLinkOpenIdConnectAsync, ClientUnlinkOpenIdConnectAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithOpenIdConnectGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithOpenIdConnectAsync(
            PFAuthenticationLoginWithOpenIdConnectRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithOpenIdConnectAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Logs in a user with an Open ID Connect JWT created by an existing relationship between a title and
        /// an Open ID Connect provider.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLinkOpenIdConnectAsync, ClientUnlinkOpenIdConnectAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithOpenIdConnectGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithOpenIdConnectAsync(
            PFAuthenticationLoginWithOpenIdConnectRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithOpenIdConnectAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using a PlayStation :tm: Network authentication code, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on Sony PlayStation®.
        /// If this is the first time a user has signed in with the PlayStation :tm: Network account and CreateAccount
        /// is set to true, a new PlayFab account will be created and linked to the PlayStation :tm: Network account.
        /// In this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
        /// account is linked to the PlayStation :tm: Network account, an error indicating this will be returned,
        /// so that the title can guide the user through creation of a PlayFab account. See also ClientLinkPSNAccountAsync,
        /// ClientUnlinkPSNAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithPSNGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithPSNAsync(
            PFAuthenticationLoginWithPSNRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithPSNAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs the user in using a PlayStation :tm: Network authentication code, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on Sony PlayStation®.
        /// If this is the first time a user has signed in with the PlayStation :tm: Network account and CreateAccount
        /// is set to true, a new PlayFab account will be created and linked to the PlayStation :tm: Network account.
        /// In this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
        /// account is linked to the PlayStation :tm: Network account, an error indicating this will be returned,
        /// so that the title can guide the user through creation of a PlayFab account. See also ClientLinkPSNAccountAsync,
        /// ClientUnlinkPSNAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithPSNGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithPSNAsync(
            PFAuthenticationLoginWithPSNRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithPSNAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Steam sign-in is accomplished with the Steam Session Ticket. More information on the Ticket can be
        /// found in the Steamworks SDK, here: https://partner.steamgames.com/documentation/auth. NOTE: For Steam
        /// authentication to work, the title must be configured with the Steam Application ID and Web API Key
        /// in the PlayFab Game Manager (under Steam in the Add-ons Marketplace). You can obtain a Web API Key
        /// from the Permissions page of any Group associated with your App ID in the Steamworks site. If this
        /// is the first time a user has signed in with the Steam account and CreateAccount is set to true, a
        /// new PlayFab account will be created and linked to the provided account's Steam ID. In this case, no
        /// email or username will be associated with the PlayFab account. Otherwise, if no PlayFab account is
        /// linked to the Steam account, an error indicating this will be returned, so that the title can guide
        /// the user through creation of a PlayFab account. See also ClientLinkSteamAccountAsync, ClientUnlinkSteamAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithSteamGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithSteamAsync(
            PFAuthenticationLoginWithSteamRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithSteamAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Steam sign-in is accomplished with the Steam Session Ticket. More information on the Ticket can be
        /// found in the Steamworks SDK, here: https://partner.steamgames.com/documentation/auth. NOTE: For Steam
        /// authentication to work, the title must be configured with the Steam Application ID and Web API Key
        /// in the PlayFab Game Manager (under Steam in the Add-ons Marketplace). You can obtain a Web API Key
        /// from the Permissions page of any Group associated with your App ID in the Steamworks site. If this
        /// is the first time a user has signed in with the Steam account and CreateAccount is set to true, a
        /// new PlayFab account will be created and linked to the provided account's Steam ID. In this case, no
        /// email or username will be associated with the PlayFab account. Otherwise, if no PlayFab account is
        /// linked to the Steam account, an error indicating this will be returned, so that the title can guide
        /// the user through creation of a PlayFab account. See also ClientLinkSteamAccountAsync, ClientUnlinkSteamAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithSteamGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithSteamAsync(
            PFAuthenticationLoginWithSteamRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithSteamAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token, returning a session identifier that can subsequently be
        /// used for API calls which require an authenticated user. If possible, PFAuthenticationLoginWithXUserAsync
        /// should be preferred, as it will more seamlessly handle automatic token refresh.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerEntity.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithXboxGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithXboxAsync(
            PFAuthenticationLoginWithXboxRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithXboxAsync(InteropHandle, request).ConfigureAwait(false);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }


        /// <summary>
        /// This API is only valid when called within a PFLocalUserLoginHandler.
        ///
        /// Signs the user in using a Xbox Live Token, returning a session identifier that can subsequently be
        /// used for API calls which require an authenticated user. If possible, PFAuthenticationLoginWithXUserAsync
        /// should be preferred, as it will more seamlessly handle automatic token refresh.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context provided to the PFLocalUserLoginHandler.</param>
        /// <returns>The result for this API operation. The async result will be returned to the PlayFab SDK internally.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithXboxGetResult"/>
        /// to get the result.
        /// </remarks>
        public PFResult AuthenticationLocalUserLoginWithXboxAsync(
            PFAuthenticationLoginWithXboxRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationLocalUserLoginWithXboxAsync(InteropHandle, request, loginHandlerContext);
        }

        /// <summary>
        /// Signs the user in using the Android device identifier, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// On Android devices, the recommendation is to use the Settings.Secure.ANDROID_ID as the AndroidDeviceId,
        /// as described in this blog post (http://android-developers.blogspot.com/2011/03/identifying-app-installations.html).
        /// More information on this identifier can be found in the Android documentation (http://developer.android.com/reference/android/provider/Settings.Secure.html).
        /// If this is the first time a user has signed in with the Android device and CreateAccount is set to
        /// true, a new PlayFab account will be created and linked to the Android device ID. In this case, no
        /// email or username will be associated with the PlayFab account. Otherwise, if no PlayFab account is
        /// linked to the Android device, an error indicating this will be returned, so that the title can guide
        /// the user through creation of a PlayFab account. Please note that while multiple devices of this type
        /// can be linked to a single user account, only the one most recently used to login (or most recently
        /// linked) will be reflected in the user's account information. We will be updating to show all linked
        /// devices in a future release.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithAndroidDeviceIDGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithAndroidDeviceIDAsync(
            string secretKey,
            PFAuthenticationServerLoginWithAndroidDeviceIDRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithAndroidDeviceIDAsync(InteropHandle, secretKey, request);
        }

        /// <summary>
        /// Sign in the user with a Battle.net identity token
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ServerLinkBattleNetAccountAsync, ServerUnlinkBattleNetAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithBattleNetGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithBattleNetAsync(
            string secretKey,
            PFAuthenticationServerLoginWithBattleNetRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithBattleNetAsync(InteropHandle, secretKey, request);
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// It is highly recommended that developers ensure that it is extremely unlikely that a customer could
        /// generate an ID which is already in use by another customer. If this is the first time a user has signed
        /// in with the Custom ID and CreateAccount is set to true, a new PlayFab account will be created and
        /// linked to the Custom ID. In this case, no email or username will be associated with the PlayFab account.
        /// Otherwise, if no PlayFab account is linked to the Custom ID, an error indicating this will be returned,
        /// so that the title can guide the user through creation of a PlayFab account.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithCustomIDGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithCustomIDAsync(
            string secretKey,
            PFAuthenticationServerLoginWithCustomIDRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithCustomIDAsync(InteropHandle, secretKey, request);
        }

        /// <summary>
        /// Signs the user in using the iOS device identifier, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// On iOS devices, the identifierForVendor (https://developer.apple.com/library/ios/documentation/UIKit/Reference/UIDevice_Class/index.html#//apple_ref/occ/instp/UIDevice/identifierForVendor)
        /// must be used as the DeviceId, as the UIDevice uniqueIdentifier has been deprecated as of iOS 5, and
        /// use of the advertisingIdentifier for this purpose will result in failure of Apple's certification
        /// process. If this is the first time a user has signed in with the iOS device and CreateAccount is set
        /// to true, a new PlayFab account will be created and linked to the vendor-specific iOS device ID. In
        /// this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
        /// account is linked to the iOS device, an error indicating this will be returned, so that the title
        /// can guide the user through creation of a PlayFab account.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithIOSDeviceIDGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithIOSDeviceIDAsync(
            string secretKey,
            PFAuthenticationServerLoginWithIOSDeviceIDRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithIOSDeviceIDAsync(InteropHandle, secretKey, request);
        }

        /// <summary>
        /// Signs the user in using a PlayStation :tm: Network authentication code, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// If this is the first time a user has signed in with the PlayStation :tm: Network account and CreateAccount
        /// is set to true, a new PlayFab account will be created and linked to the PlayStation :tm: Network account.
        /// In this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
        /// account is linked to the PlayStation :tm: Network account, an error indicating this will be returned,
        /// so that the title can guide the user through creation of a PlayFab account. See also ServerLinkPSNAccountAsync,
        /// ServerUnlinkPSNAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithPSNGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithPSNAsync(
            string secretKey,
            PFAuthenticationServerLoginWithPSNRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithPSNAsync(InteropHandle, secretKey, request);
        }

        /// <summary>
        /// Securely login a game client from an external server backend using a custom identifier for that player.
        /// Server Custom ID and Client Custom ID are mutually exclusive and cannot be used to retrieve the same
        /// player account.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithServerCustomIdGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithServerCustomIdAsync(
            string secretKey,
            PFAuthenticationLoginWithServerCustomIdRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithServerCustomIdAsync(InteropHandle, secretKey, request);
        }

        /// <summary>
        /// Signs the user in using an Steam ID, returning a session identifier that can subsequently be used
        /// for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// If this is the first time a user has signed in with the Steam ID and CreateAccount is set to true,
        /// a new PlayFab account will be created and linked to the Steam account. In this case, no email or username
        /// will be associated with the PlayFab account. Otherwise, if no PlayFab account is linked to the Steam
        /// account, an error indicating this will be returned, so that the title can guide the user through creation
        /// of a PlayFab account. Steam users that are not logged into the Steam Client app will only have their
        /// Steam username synced, other data, such as currency and country will not be available until they login
        /// while the Client is open.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithSteamIdGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithSteamIdAsync(
            string secretKey,
            PFAuthenticationLoginWithSteamIdRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithSteamIdAsync(InteropHandle, secretKey, request);
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token from an external server backend, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// If this is the first time a user has signed in with the Xbox Live account and CreateAccount is set
        /// to true, a new PlayFab account will be created and linked to the Xbox Live account. In this case,
        /// no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab account
        /// is linked to the Xbox Live account, an error indicating this will be returned, so that the title can
        /// guide the user through creation of a PlayFab account. See also ServerLinkXboxAccountAsync, ServerUnlinkXboxAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithXboxGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithXboxAsync(
            string secretKey,
            PFAuthenticationServerLoginWithXboxRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithXboxAsync(InteropHandle, secretKey, request);
        }

        /// <summary>
        /// Signs the user in using an Xbox ID and Sandbox ID, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// If this is the first time a user has signed in with the Xbox ID and CreateAccount is set to true,
        /// a new PlayFab account will be created and linked to the Xbox Live account. In this case, no email
        /// or username will be associated with the PlayFab account. Otherwise, if no PlayFab account is linked
        /// to the Xbox Live account, an error indicating this will be returned, so that the title can guide the
        /// user through creation of a PlayFab account.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithXboxIdGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> AuthenticationServerLoginWithXboxIdAsync(
            string secretKey,
            PFAuthenticationLoginWithXboxIdRequest request
        )
        {
            return InteropWrapper.Core.PFAuthentication.PFAuthenticationServerLoginWithXboxIdAsync(InteropHandle, secretKey, request);
        }
    }
}
