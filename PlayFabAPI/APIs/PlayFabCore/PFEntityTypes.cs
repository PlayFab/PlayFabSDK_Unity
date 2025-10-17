// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PlayFab
{

    public readonly struct PFEntityConsts
    {
        /// <summary>
        /// Entity type for all TitlePlayer Entities. This const value can be used to populate PFEntityKeys referring to TitlePlayer Entities.
        /// </summary>
        public const string PFEntityTitlePlayerEntityType = "title_player_account";
    }

    /// <summary>
    /// Handle to an authenticated Entity (TitlePlayer, Title, etc.). Contains the auth tokens needed to make PlayFab service
    /// calls. When no longer needed, the Entity handle must be closed with PFEntityCloseHandle.
    /// </summary>
    public readonly struct PFEntityHandle
    {
        public readonly IntPtr Handle;

        internal PFEntityHandle(IntPtr handle)
        {
            Handle = handle;
        }
    }

    /// <summary>
    /// PlayFab EntityToken and its expiration time. Used to authenticate PlayFab service calls.
    /// </summary>
    public readonly struct PFEntityToken
    {
        /// <summary>
        /// The token used to set X-EntityToken for all entity based API calls.
        /// </summary>
        public readonly string Token;

        /// <summary>
        /// (Optional) The time the token will expire, if it is an expiring token, in UTC.
        /// </summary>
        public readonly long? Expiration;

        internal PFEntityToken(Interop.PFEntityToken token)
        {
            unsafe
            {
                Token = new(token.token);
                Expiration = token.expiration == null ? *token.expiration : null;
            }
        }
    }

    /// <summary>
    /// EntityToken expired event handler. Needed to reauthenticate players in scenarios where the SDK is unable to automatically
    /// refresh the cached EntityToken.
    /// </summary>
    /// <param name="context">Optional context pointer to data used by the event handler.</param>
    /// <param name="entityKey">The EntityKey for the Entity whose auth token expired.</param>
    /// <returns></returns>
    public delegate void PFEntityTokenExpiredEventHandler(
        object context,
        PFEntityKey entityKey
    );

    /// <summary>
    /// A handler invoked every time an Entity is automatically re-authenticated, thus obtaining a new EntityToken. An entity
    /// will be automatically re-authenticated prior to its EntityToken expiring.
    /// </summary>
    /// <param name="context">Optional context pointer to data used by the event handler.</param>
    /// <param name="entityKey">The EntityKey for the Entity whose EntityToken expired.</param>
    /// <param name="newToken">The new token for the refreshed entity.</param>
    /// <returns></returns>
    public delegate void PFEntityTokenRefreshedEventHandler(
        object context,
        PFEntityKey entityKey,
        PFEntityToken newToken
    );

}
