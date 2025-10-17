// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFAuthentication
    {

        /// <summary>
        /// Signs in the user with a Sign in with Apple identity token.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on iOS and macOS.
        /// See also ClientLinkAppleAsync, ClientUnlinkAppleAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithAppleGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithAppleAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithAppleRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithAppleGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithAppleGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithAppleRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithAppleRequest[1];
                PFAuthenticationLoginWithAppleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithAppleAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithAppleAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithAppleRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithAppleRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithAppleRequest[1];
                PFAuthenticationLoginWithAppleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithAppleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithAppleAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithAppleRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithAppleRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithAppleRequest[1];
                PFAuthenticationLoginWithAppleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithAppleAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithAppleAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithAppleRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithAppleRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithAppleRequest[1];
                PFAuthenticationLoginWithAppleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithAppleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Sign in the user with a Battle.net identity token
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ClientLinkBattleNetAccountAsync, ClientUnlinkBattleNetAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithBattleNetGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithBattleNetAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithBattleNetRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithBattleNetGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithBattleNetGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithBattleNetRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithBattleNetRequest[1];
                PFAuthenticationLoginWithBattleNetRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithBattleNetAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithBattleNetAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithBattleNetRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithBattleNetRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithBattleNetRequest[1];
                PFAuthenticationLoginWithBattleNetRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithBattleNetAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithBattleNetAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithBattleNetRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithBattleNetRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithBattleNetRequest[1];
                PFAuthenticationLoginWithBattleNetRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithBattleNetAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithBattleNetAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithBattleNetRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithBattleNetRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithBattleNetRequest[1];
                PFAuthenticationLoginWithBattleNetRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithBattleNetAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
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
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithCustomIDAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithCustomIDRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithCustomIDGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithCustomIDGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithCustomIDRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithCustomIDRequest[1];
                PFAuthenticationLoginWithCustomIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithCustomIDAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithCustomIDAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithCustomIDRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithCustomIDRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithCustomIDRequest[1];
                PFAuthenticationLoginWithCustomIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithCustomIDAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithCustomIDAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithCustomIDRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithCustomIDRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithCustomIDRequest[1];
                PFAuthenticationLoginWithCustomIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithCustomIDAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithCustomIDAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithCustomIDRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithCustomIDRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithCustomIDRequest[1];
                PFAuthenticationLoginWithCustomIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithCustomIDAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using a Facebook access token, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
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
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithFacebookAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithFacebookRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithFacebookGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithFacebookGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithFacebookRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithFacebookRequest[1];
                PFAuthenticationLoginWithFacebookRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithFacebookAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithFacebookAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithFacebookRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithFacebookRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithFacebookRequest[1];
                PFAuthenticationLoginWithFacebookRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithFacebookAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithFacebookAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithFacebookRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithFacebookRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithFacebookRequest[1];
                PFAuthenticationLoginWithFacebookRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithFacebookAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithFacebookAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithFacebookRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithFacebookRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithFacebookRequest[1];
                PFAuthenticationLoginWithFacebookRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithFacebookAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using an iOS Game Center player identifier, returning a session identifier that
        /// can subsequently be used for API calls which require an authenticated user. Logging in with a Game
        /// Center ID is insecure if you do not include the optional PublicKeyUrl, Salt, Signature, and Timestamp
        /// parameters in this request. It is recommended you require these parameters on all Game Center calls
        /// by going to the Apple Add-ons page in the PlayFab Game Manager and enabling the 'Require secure authentication
        /// only for this app' option.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
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
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithGameCenterAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithGameCenterRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithGameCenterGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithGameCenterGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGameCenterRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGameCenterRequest[1];
                PFAuthenticationLoginWithGameCenterRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithGameCenterAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithGameCenterAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithGameCenterRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGameCenterRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGameCenterRequest[1];
                PFAuthenticationLoginWithGameCenterRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithGameCenterAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithGameCenterAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithGameCenterRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGameCenterRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGameCenterRequest[1];
                PFAuthenticationLoginWithGameCenterRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithGameCenterAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithGameCenterAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithGameCenterRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGameCenterRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGameCenterRequest[1];
                PFAuthenticationLoginWithGameCenterRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithGameCenterAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using their Google account credentials
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
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
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithGoogleAccountAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithGoogleAccountRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithGoogleAccountGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithGoogleAccountGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGoogleAccountRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGoogleAccountRequest[1];
                PFAuthenticationLoginWithGoogleAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithGoogleAccountAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithGoogleAccountAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithGoogleAccountRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGoogleAccountRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGoogleAccountRequest[1];
                PFAuthenticationLoginWithGoogleAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithGoogleAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithGoogleAccountAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithGoogleAccountRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGoogleAccountRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGoogleAccountRequest[1];
                PFAuthenticationLoginWithGoogleAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithGoogleAccountAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithGoogleAccountAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithGoogleAccountRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGoogleAccountRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGoogleAccountRequest[1];
                PFAuthenticationLoginWithGoogleAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithGoogleAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using their Google Play Games account credentials
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
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
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithGooglePlayGamesServicesAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithGooglePlayGamesServicesRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithGooglePlayGamesServicesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithGooglePlayGamesServicesGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest[1];
                PFAuthenticationLoginWithGooglePlayGamesServicesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithGooglePlayGamesServicesAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithGooglePlayGamesServicesAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithGooglePlayGamesServicesRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest[1];
                PFAuthenticationLoginWithGooglePlayGamesServicesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithGooglePlayGamesServicesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithGooglePlayGamesServicesAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithGooglePlayGamesServicesRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest[1];
                PFAuthenticationLoginWithGooglePlayGamesServicesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithGooglePlayGamesServicesAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithGooglePlayGamesServicesAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithGooglePlayGamesServicesRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithGooglePlayGamesServicesRequest[1];
                PFAuthenticationLoginWithGooglePlayGamesServicesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithGooglePlayGamesServicesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs in the user with a Nintendo service account token.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Nintendo Switch.
        /// See also ClientLinkNintendoServiceAccountAsync, ClientUnlinkNintendoServiceAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithNintendoServiceAccountGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithNintendoServiceAccountAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithNintendoServiceAccountRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithNintendoServiceAccountGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithNintendoServiceAccountGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest[1];
                PFAuthenticationLoginWithNintendoServiceAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithNintendoServiceAccountAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithNintendoServiceAccountAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithNintendoServiceAccountRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest[1];
                PFAuthenticationLoginWithNintendoServiceAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithNintendoServiceAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithNintendoServiceAccountAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithNintendoServiceAccountRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest[1];
                PFAuthenticationLoginWithNintendoServiceAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithNintendoServiceAccountAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithNintendoServiceAccountAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithNintendoServiceAccountRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithNintendoServiceAccountRequest[1];
                PFAuthenticationLoginWithNintendoServiceAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithNintendoServiceAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Logs in a user with an Open ID Connect JWT created by an existing relationship between a title and
        /// an Open ID Connect provider.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientLinkOpenIdConnectAsync, ClientUnlinkOpenIdConnectAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithOpenIdConnectGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithOpenIdConnectAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithOpenIdConnectRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithOpenIdConnectGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithOpenIdConnectGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithOpenIdConnectRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithOpenIdConnectRequest[1];
                PFAuthenticationLoginWithOpenIdConnectRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithOpenIdConnectAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithOpenIdConnectAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithOpenIdConnectRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithOpenIdConnectRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithOpenIdConnectRequest[1];
                PFAuthenticationLoginWithOpenIdConnectRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithOpenIdConnectAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithOpenIdConnectAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithOpenIdConnectRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithOpenIdConnectRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithOpenIdConnectRequest[1];
                PFAuthenticationLoginWithOpenIdConnectRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithOpenIdConnectAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithOpenIdConnectAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithOpenIdConnectRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithOpenIdConnectRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithOpenIdConnectRequest[1];
                PFAuthenticationLoginWithOpenIdConnectRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithOpenIdConnectAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using a PlayStation :tm: Network authentication code, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
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
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithPSNAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithPSNRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithPSNGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithPSNGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithPSNRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithPSNRequest[1];
                PFAuthenticationLoginWithPSNRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithPSNAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithPSNAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithPSNRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithPSNRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithPSNRequest[1];
                PFAuthenticationLoginWithPSNRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithPSNAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithPSNAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithPSNRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithPSNRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithPSNRequest[1];
                PFAuthenticationLoginWithPSNRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithPSNAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithPSNAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithPSNRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithPSNRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithPSNRequest[1];
                PFAuthenticationLoginWithPSNRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithPSNAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
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
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithSteamAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithSteamRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithSteamGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithSteamGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithSteamRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithSteamRequest[1];
                PFAuthenticationLoginWithSteamRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithSteamAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithSteamAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithSteamRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithSteamRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithSteamRequest[1];
                PFAuthenticationLoginWithSteamRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithSteamAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithSteamAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithSteamRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithSteamRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithSteamRequest[1];
                PFAuthenticationLoginWithSteamRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithSteamAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithSteamAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithSteamRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithSteamRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithSteamRequest[1];
                PFAuthenticationLoginWithSteamRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithSteamAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token, returning a session identifier that can subsequently be
        /// used for API calls which require an authenticated user. If possible, PFAuthenticationLoginWithXUserAsync
        /// should be preferred, as it will more seamlessly handle automatic token refresh.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationLoginWithXboxGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithXboxAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithXboxRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithXboxGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithXboxGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithXboxRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithXboxRequest[1];
                PFAuthenticationLoginWithXboxRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithXboxAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle. Used to address situations where the EntityToken expired and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithXboxAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithXboxRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithXboxRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithXboxRequest[1];
                PFAuthenticationLoginWithXboxRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithXboxAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }

        /// <summary>
        /// Authenticates a local user within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the PFLocalUser provided to the PFLocalUserLoginHandler will be updated with a logged in PFPlayerEntity.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserLoginWithXboxAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithXboxRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithXboxRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithXboxRequest[1];
                PFAuthenticationLoginWithXboxRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithXboxAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Reauthenticates a local user's existing PFEntityHandle within a PFLocalUserLoginHandler.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle provided to the PFLocalUserLoginHandler.</param>
        /// <param name="request">Populated request object.</param>
        /// <param name="loginHandlerContext">Context that was provided to the PFLocalUserLoginHandler.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static PFResult PFAuthenticationLocalUserReLoginWithXboxAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithXboxRequest request,
            PFLocalUserLoginHandlerContext loginHandlerContext
        )
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithXboxRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithXboxRequest[1];
                PFAuthenticationLoginWithXboxRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithXboxAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)loginHandlerContext.Block.Handle);

                return new(hr);
            }
        }

        /// <summary>
        /// Signs the user in using the Android device identifier, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
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
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithAndroidDeviceIDAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationServerLoginWithAndroidDeviceIDRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithAndroidDeviceIDGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithAndroidDeviceIDGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationServerLoginWithAndroidDeviceIDRequest* requestInterop = stackalloc Interop.PFAuthenticationServerLoginWithAndroidDeviceIDRequest[1];
                PFAuthenticationServerLoginWithAndroidDeviceIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithAndroidDeviceIDAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Sign in the user with a Battle.net identity token
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ServerLinkBattleNetAccountAsync, ServerUnlinkBattleNetAccountAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithBattleNetGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithBattleNetAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationServerLoginWithBattleNetRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithBattleNetGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithBattleNetGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationServerLoginWithBattleNetRequest* requestInterop = stackalloc Interop.PFAuthenticationServerLoginWithBattleNetRequest[1];
                PFAuthenticationServerLoginWithBattleNetRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithBattleNetAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
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
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithCustomIDAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationServerLoginWithCustomIDRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithCustomIDGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithCustomIDGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationServerLoginWithCustomIDRequest* requestInterop = stackalloc Interop.PFAuthenticationServerLoginWithCustomIDRequest[1];
                PFAuthenticationServerLoginWithCustomIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithCustomIDAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Signs the user in using the iOS device identifier, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
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
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithIOSDeviceIDAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationServerLoginWithIOSDeviceIDRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithIOSDeviceIDGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithIOSDeviceIDGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationServerLoginWithIOSDeviceIDRequest* requestInterop = stackalloc Interop.PFAuthenticationServerLoginWithIOSDeviceIDRequest[1];
                PFAuthenticationServerLoginWithIOSDeviceIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithIOSDeviceIDAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a PlayStation :tm: Network authentication code, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
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
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithPSNAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationServerLoginWithPSNRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithPSNGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithPSNGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationServerLoginWithPSNRequest* requestInterop = stackalloc Interop.PFAuthenticationServerLoginWithPSNRequest[1];
                PFAuthenticationServerLoginWithPSNRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithPSNAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Securely login a game client from an external server backend using a custom identifier for that player.
        /// Server Custom ID and Client Custom ID are mutually exclusive and cannot be used to retrieve the same
        /// player account.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult).</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationServerLoginWithServerCustomIdGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithServerCustomIdAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationLoginWithServerCustomIdRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithServerCustomIdGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithServerCustomIdGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithServerCustomIdRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithServerCustomIdRequest[1];
                PFAuthenticationLoginWithServerCustomIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithServerCustomIdAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Signs the user in using an Steam ID, returning a session identifier that can subsequently be used
        /// for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
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
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithSteamIdAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationLoginWithSteamIdRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithSteamIdGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithSteamIdGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithSteamIdRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithSteamIdRequest[1];
                PFAuthenticationLoginWithSteamIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithSteamIdAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token from an external server backend, returning a session identifier
        /// that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
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
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithXboxAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationServerLoginWithXboxRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithXboxGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithXboxGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationServerLoginWithXboxRequest* requestInterop = stackalloc Interop.PFAuthenticationServerLoginWithXboxRequest[1];
                PFAuthenticationServerLoginWithXboxRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithXboxAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Signs the user in using an Xbox ID and Sandbox ID, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
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
        public static Task<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> PFAuthenticationServerLoginWithXboxIdAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationLoginWithXboxIdRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFAuthenticationEntityTokenResponse entityResponse, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationServerLoginWithXboxIdGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    Interop.PFAuthenticationEntityTokenResponse* entityInterop;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationServerLoginWithXboxIdGetResult(asyncBlock, &entityInterop, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(*entityInterop), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithXboxIdRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithXboxIdRequest[1];
                PFAuthenticationLoginWithXboxIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationServerLoginWithXboxIdAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Delete a game_server entity.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAuthenticationDeleteAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationDeleteRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationDeleteRequest* requestInterop = stackalloc Interop.PFAuthenticationDeleteRequest[1];
                PFAuthenticationDeleteRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationDeleteAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh
        /// a still valid Entity Token.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEntityHandle.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
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
        public static Task<PFResult<PFEntityHandle>> PFAuthenticationGetEntityAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationGetEntityRequest request
        )
        {
            TaskCompletionSource<PFResult<PFEntityHandle>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    IntPtr entityHandle;

                    hr = Interop.Methods.PFAuthenticationGetEntityGetResult(asyncBlock, &entityHandle);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    PFEntityHandle entity = new(entityHandle);
                    completionSource.SetResult(new(entity, hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationGetEntityRequest* requestInterop = stackalloc Interop.PFAuthenticationGetEntityRequest[1];
                PFAuthenticationGetEntityRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationGetEntityAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh
        /// a still valid Entity Token.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
        /// <param name="secretKey">Title Secret Key used to authenticate the service request.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEntityHandle.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API must be called with X-SecretKey, X-Authentication or X-EntityToken headers. An optional
        /// EntityKey may be included to attempt to set the resulting EntityToken to a specific entity, however
        /// the entity must be a relation of the caller, such as the master_player_account of a character. If
        /// sending X-EntityToken the account will be marked as freshly logged in and will issue a new token.
        /// If using X-Authentication or X-EntityToken the header must still be valid and cannot be expired or
        /// revoked.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationGetEntityWithSecretKeyGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFEntityHandle>> PFAuthenticationGetEntityWithSecretKeyAsync(
            PFServiceConfigHandle serviceConfigHandle,
            string secretKey,
            PFAuthenticationGetEntityRequest request
        )
        {
            TaskCompletionSource<PFResult<PFEntityHandle>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    IntPtr entityHandle;

                    hr = Interop.Methods.PFAuthenticationGetEntityWithSecretKeyGetResult(asyncBlock, &entityHandle);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    PFEntityHandle entity = new(entityHandle);
                    completionSource.SetResult(new(entity, hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationGetEntityRequest* requestInterop = stackalloc Interop.PFAuthenticationGetEntityRequest[1];
                PFAuthenticationGetEntityRequest.ToInterop(request, requestInterop, disposableBuffer);

                sbyte* secretKeyInterop;
                WrapperHelpers.StringToInterop(secretKey, &secretKeyInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationGetEntityWithSecretKeyAsync(serviceConfigHandle.Handle, secretKeyInterop, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Method for a server to validate a client provided EntityToken. Only callable by the title entity.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult<PFAuthenticationValidateEntityTokenResponse>> PFAuthenticationValidateEntityTokenAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationValidateEntityTokenRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAuthenticationValidateEntityTokenResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationValidateEntityTokenGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationValidateEntityTokenResponse* result = null;

                    hr = Interop.Methods.PFAuthenticationValidateEntityTokenGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationValidateEntityTokenRequest* requestInterop = stackalloc Interop.PFAuthenticationValidateEntityTokenRequest[1];
                PFAuthenticationValidateEntityTokenRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationValidateEntityTokenAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

    }
}
