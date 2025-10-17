// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFPlayerEntity
    {
        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh
        /// a still valid Entity Token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEntity.</returns>
        /// <remarks>
        /// This API is available on Win32, Linux, and macOS.
        /// This API must be called with X-SecretKey, X-Authentication or X-EntityToken headers. An optional
        /// EntityKey may be included to attempt to set the resulting EntityToken to a specific entity, however
        /// the entity must be a relation of the caller, such as the master_player_account of a character. If
        /// sending X-EntityToken the account will be marked as freshly logged in and will issue a new token.
        /// If using X-Authentication or X-EntityToken the header must still be valid and cannot be expired or
        /// revoked.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationGetEntityGetResult"/> to
        /// get the result.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationGetEntityAsync(
            PFAuthenticationGetEntityRequest request
        )
        {
            PFResult<PFEntityHandle> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationGetEntityAsync(InteropHandle, request);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFEntity(result.Result) as PFPlayerEntity, result.HResult);
        }

#if MICROSOFT_GDK_SUPPORT
        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public async Task<PFResult> AuthenticationReLoginWithXUserAsync(
            PFAuthenticationLoginWithXUserRequest request
        )
        {
            return await InteropWrapper.Core.PFAuthentication.PFAuthenticationReLoginWithXUserAsync(InteropHandle, request);
        }
#endif
    }

    public partial class PFTitleEntity
    {
        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh
        /// a still valid Entity Token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEntity.</returns>
        /// <remarks>
        /// This API is available on Win32, Linux, and macOS.
        /// This API must be called with X-SecretKey, X-Authentication or X-EntityToken headers. An optional
        /// EntityKey may be included to attempt to set the resulting EntityToken to a specific entity, however
        /// the entity must be a relation of the caller, such as the master_player_account of a character. If
        /// sending X-EntityToken the account will be marked as freshly logged in and will issue a new token.
        /// If using X-Authentication or X-EntityToken the header must still be valid and cannot be expired or
        /// revoked.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationGetEntityGetResult"/> to
        /// get the result.
        /// </remarks>
        public async Task<PFResult<PFEntity>> AuthenticationGetEntityAsync(
            PFAuthenticationGetEntityRequest request
        )
        {
            PFResult<PFEntityHandle> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationGetEntityAsync(InteropHandle, request);
            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh
        /// a still valid Entity Token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEntity.</returns>
        /// <remarks>
        /// This API is available on Win32, Linux, and macOS.
        /// This API must be called with X-SecretKey, X-Authentication or X-EntityToken headers. An optional
        /// EntityKey may be included to attempt to set the resulting EntityToken to a specific entity, however
        /// the entity must be a relation of the caller, such as the master_player_account of a character. If
        /// sending X-EntityToken the account will be marked as freshly logged in and will issue a new token.
        /// If using X-Authentication or X-EntityToken the header must still be valid and cannot be expired or
        /// revoked.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationGetEntityGetResult"/> to
        /// get the result.
        /// </remarks>
        public async Task<PFResult<TEntity>> AuthenticationGetEntityAsync<TEntity>(
            PFAuthenticationGetEntityRequest request
        ) where TEntity : PFEntity
        {
            PFResult<PFEntityHandle> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationGetEntityAsync(InteropHandle, request);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFEntity(result.Result) as TEntity, result.HResult);
        }

        /// <summary>
        /// Create a game_server entity token and return a new or existing game_server entity.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEntity.</returns>
        /// <remarks>
        /// This API is available on Win32, Linux, and macOS.
        /// Create or return a game_server entity token. Caller must be a title entity.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationAuthenticateGameServerWithCustomIdGetResultSize"/>
        /// and <see cref="PFAuthenticationAuthenticateGameServerWithCustomIdGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<(PFGameServerEntity entity, bool newlyCreated)>> AuthenticationAuthenticateGameServerWithCustomIdAsync(
            PFAuthenticationAuthenticateCustomIdRequest request
        )
        {
            PFResult<(PFEntityHandle entity, bool newlyCreated)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationAuthenticateGameServerWithCustomIdAsync(InteropHandle, request);
            return result.Failed() ? new(result.HResult)
                                   : new((new PFGameServerEntity(result.Result.entity), result.Result.newlyCreated), result.HResult);
        }
    }

    public partial class PFServiceConfig
    {
        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh
        /// a still valid Entity Token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEntity.</returns>
        /// <remarks>
        /// This API is available on Win32, Linux, and macOS.
        /// This API must be called with X-SecretKey, X-Authentication or X-EntityToken headers. An optional
        /// EntityKey may be included to attempt to set the resulting EntityToken to a specific entity, however
        /// the entity must be a relation of the caller, such as the master_player_account of a character. If
        /// sending X-EntityToken the account will be marked as freshly logged in and will issue a new token.
        /// If using X-Authentication or X-EntityToken the header must still be valid and cannot be expired or
        /// revoked.
        /// </remarks>
        public async Task<PFResult<PFEntity>> AuthenticationGetEntityWithSecretKeyAsync(
            string secretKey,
            PFAuthenticationGetEntityRequest request
        )
        {
            PFResult<PFEntityHandle> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationGetEntityWithSecretKeyAsync(InteropHandle, secretKey, request);
            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh
        /// a still valid Entity Token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEntity.</returns>
        /// <remarks>
        /// This API is available on Win32, Linux, and macOS.
        /// This API must be called with X-SecretKey, X-Authentication or X-EntityToken headers. An optional
        /// EntityKey may be included to attempt to set the resulting EntityToken to a specific entity, however
        /// the entity must be a relation of the caller, such as the master_player_account of a character. If
        /// sending X-EntityToken the account will be marked as freshly logged in and will issue a new token.
        /// If using X-Authentication or X-EntityToken the header must still be valid and cannot be expired or
        /// revoked.
        /// </remarks>
        public async Task<PFResult<TEntity>> AuthenticationGetEntityWithSecretKeyAsync<TEntity>(
            string secretKey,
            PFAuthenticationGetEntityRequest request
        ) where TEntity : PFEntity
        {
            PFResult<PFEntityHandle> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationGetEntityWithSecretKeyAsync(InteropHandle, secretKey, request);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFEntity(result.Result) as TEntity, result.HResult);
        }

#if MICROSOFT_GDK_SUPPORT
        /// <summary>
        /// Signs the user in using an XUserHandle, returning a session identifier that can subsequently be
        /// used for API calls which require an authenticated user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on GDK.
        /// If this is the first time a user has signed in with the Xbox Live account and CreateAccount is set
        /// to true, a new PlayFab account will be created and linked to the Xbox Live account. In this case,
        /// no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab account
        /// is linked to the Xbox Live account, an error indicating this will be returned, so that the title can
        /// guide the user through creation of a PlayFab account. See also ClientLinkXboxAccountAsync, ClientUnlinkXboxAccountAsync.
        /// </remarks>
        public async Task<PFResult<PFPlayerEntity>> AuthenticationLoginWithXUserAsync(
            PFAuthenticationLoginWithXUserRequest request
        )
        {
            PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)> result = await InteropWrapper.Core.PFAuthentication.PFAuthenticationLoginWithXUserAsync(InteropHandle, request);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFPlayerEntity(result.Result.entity, result.Result.loginResult), result.HResult);
        }
#endif
    }
}
