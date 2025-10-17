// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PlayFab
{

    /// <summary>
    /// Handle to an authenticated Entity (TitlePlayer, Title, etc.). Contains the auth tokens needed to make PlayFab service
    /// calls. When no longer needed, the Entity handle must be closed with PFEntityCloseHandle.
    /// </summary>
    public readonly struct PFLocalUserHandle
    {
        public readonly IntPtr Handle;

        internal PFLocalUserHandle(IntPtr handle)
        {
            Handle = handle;
        }
    }

    /// <summary>
    /// Callback that will be invoked to enable custom login logic. This can be used in cases where a non-standard
    /// login provider is desired, or if there isn't a default login provider for the platform or from an extension.
    /// The title is responsible for building the login request object and calling one of the PFAuthenticationLoginWith* APIs.
    /// This callback will also be invoked by the SDK to renew an expired token for a previously authenticated user. In that
    /// case, the existingEntityHandle will be non-null, and the title should call the appropriate PFAuthenticationReLoginWith*
    /// API instead.
    /// 
    /// The PFServiceConfigHandle and XAsyncBlock passed to this callback are owned by the SDK and should just be passed
    /// directly to the login API of choice.
    /// </summary>
    /// <param name="localUser">The local user to log in.</param>
    /// <param name="serviceConfig">The service config to use for login.</param>
    /// <param name="existingEntity">The previously authenticated entity if there is one and nullptr otherwise.</param>
    /// <param name="context">Context to be passed through to the login API.</param>
    /// <returns>Return HRESULT of login API or error (E_FAIL) if this fails earlier</returns>
    public delegate int PFLocalUserLoginHandler(
        PFLocalUser localUser,
        PFServiceConfig serviceConfig,
        PFPlayerEntity existingEntity,
        PFLocalUserLoginHandlerContext context
    );

    public readonly struct PFLocalUserLoginHandlerContext
    {
        internal readonly Interop.XAsyncBlockPtr Block;

        internal PFLocalUserLoginHandlerContext(Interop.XAsyncBlockPtr block)
        {
            Block = block;
        }
    }
}
