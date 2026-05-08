// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFAccountManagement
    {

        /// <summary>
        /// Adds or updates a contact email to the player's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientAddOrUpdateContactEmailAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementAddOrUpdateContactEmailRequest request
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
                Interop.PFAccountManagementAddOrUpdateContactEmailRequest* requestInterop = stackalloc Interop.PFAccountManagementAddOrUpdateContactEmailRequest[1];
                PFAccountManagementAddOrUpdateContactEmailRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientAddOrUpdateContactEmailAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Adds playfab username/password auth to an existing account created via an anonymous auth method,
        /// e.g. automatic device ID login.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementAddUsernamePasswordResult.</returns>
        /// <remarks>
        /// This API is available on Linux and macOS.
        /// See also ClientLoginWithEmailAddressAsync, ClientLoginWithPlayFabAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientAddUsernamePasswordGetResultSize"/>
        /// and <see cref="PFAccountManagementClientAddUsernamePasswordGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementAddUsernamePasswordResult>> PFAccountManagementClientAddUsernamePasswordAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementAddUsernamePasswordRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementAddUsernamePasswordResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientAddUsernamePasswordGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementAddUsernamePasswordResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientAddUsernamePasswordGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementAddUsernamePasswordRequest* requestInterop = stackalloc Interop.PFAccountManagementAddUsernamePasswordRequest[1];
                PFAccountManagementAddUsernamePasswordRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientAddUsernamePasswordAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the user's PlayFab account details
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetAccountInfoResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetAccountInfoGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetAccountInfoGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetAccountInfoResult>> PFAccountManagementClientGetAccountInfoAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetAccountInfoRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetAccountInfoResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetAccountInfoGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetAccountInfoResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetAccountInfoGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetAccountInfoRequest* requestInterop = stackalloc Interop.PFAccountManagementGetAccountInfoRequest[1];
                PFAccountManagementGetAccountInfoRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetAccountInfoAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves all of the user's different kinds of info.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayerCombinedInfoResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayerCombinedInfoGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayerCombinedInfoGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayerCombinedInfoResult>> PFAccountManagementClientGetPlayerCombinedInfoAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayerCombinedInfoRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayerCombinedInfoResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayerCombinedInfoGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayerCombinedInfoResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayerCombinedInfoGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayerCombinedInfoRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayerCombinedInfoRequest[1];
                PFAccountManagementGetPlayerCombinedInfoRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayerCombinedInfoAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult<PFAccountManagementGetPlayerProfileResult>> PFAccountManagementClientGetPlayerProfileAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayerProfileRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayerProfileResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayerProfileGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayerProfileResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayerProfileGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayerProfileRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayerProfileRequest[1];
                PFAccountManagementGetPlayerProfileRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayerProfileAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Battle.net account identifiers.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsGetResult"/> to get the
        /// result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult>> PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest[1];
                PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromFacebookIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, Android, iOS, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromFacebookIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromFacebookIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookIDsResult>> PFAccountManagementClientGetPlayFabIDsFromFacebookIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromFacebookIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromFacebookIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromFacebookIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromFacebookIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Game identifiers.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsGetResult"/> to get
        /// the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult>> PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest[1];
                PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Game Center identifiers (referenced
        /// in the Game Center Programming Guide as the Player Identifier).
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, iOS, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult>> PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google identifiers. The Google identifiers
        /// are the IDs for the user accounts, available as 'id' in the Google+ People API calls.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromGoogleIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, Android, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromGoogleIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromGoogleIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromGoogleIDsResult>> PFAccountManagementClientGetPlayFabIDsFromGoogleIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromGoogleIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGoogleIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromGoogleIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGoogleIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGoogleIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google Play Games identifiers. The
        /// Google Play Games identifiers are the IDs for the user accounts, available as 'playerId' in the Google
        /// Play Games Services - Players API calls.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, Android, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsGetResult"/> to get
        /// the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult>> PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Kongregate identifiers. The Kongregate
        /// identifiers are the IDs for the user accounts, available as 'user_id' from the Kongregate API methods(ex:
        /// http://developers.kongregate.com/docs/client/getUserId).
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromKongregateIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromKongregateIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromKongregateIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromKongregateIDsResult>> PFAccountManagementClientGetPlayFabIDsFromKongregateIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromKongregateIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromKongregateIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromKongregateIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromKongregateIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromKongregateIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Service Account identifiers.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Nintendo Switch, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsGetResult"/> to
        /// get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult>> PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest[1];
                PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch Device identifiers.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResult"/> to get
        /// the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest[1];
                PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Sony PlayStation®, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult>> PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult>> PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers
        /// are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromSteamIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromSteamIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromSteamIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromSteamIDsResult>> PFAccountManagementClientGetPlayFabIDsFromSteamIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromSteamIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromSteamIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromSteamIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromSteamIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromSteamIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromSteamIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromSteamIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromSteamIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromSteamIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers
        /// are persona names.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromSteamNamesResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromSteamNamesGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromSteamNamesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromSteamNamesResult>> PFAccountManagementClientGetPlayFabIDsFromSteamNamesAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromSteamNamesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromSteamNamesResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromSteamNamesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromSteamNamesResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromSteamNamesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromSteamNamesRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromSteamNamesRequest[1];
                PFAccountManagementGetPlayFabIDsFromSteamNamesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromSteamNamesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers
        /// are the IDs for the user accounts, available as '_id' from the Twitch API methods (ex: https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromTwitchIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromTwitchIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromTwitchIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromTwitchIDsResult>> PFAccountManagementClientGetPlayFabIDsFromTwitchIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromTwitchIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromTwitchIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromTwitchIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromTwitchIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromTwitchIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of XboxLive identifiers.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult>> PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Android device identifier to the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkAndroidDeviceIDAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkAndroidDeviceIDRequest request
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
                Interop.PFAccountManagementLinkAndroidDeviceIDRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkAndroidDeviceIDRequest[1];
                PFAccountManagementLinkAndroidDeviceIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkAndroidDeviceIDAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Apple account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkAppleAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkAppleRequest request
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
                Interop.PFAccountManagementLinkAppleRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkAppleRequest[1];
                PFAccountManagementLinkAppleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkAppleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Battle.net account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkBattleNetAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientLinkBattleNetAccountRequest request
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
                Interop.PFAccountManagementClientLinkBattleNetAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientLinkBattleNetAccountRequest[1];
                PFAccountManagementClientLinkBattleNetAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkBattleNetAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the custom identifier, generated by the title, to the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkCustomIDAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkCustomIDRequest request
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
                Interop.PFAccountManagementLinkCustomIDRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkCustomIDRequest[1];
                PFAccountManagementLinkCustomIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkCustomIDAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab
        /// account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkFacebookAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkFacebookAccountRequest request
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
                Interop.PFAccountManagementLinkFacebookAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkFacebookAccountRequest[1];
                PFAccountManagementLinkFacebookAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkFacebookAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Facebook Instant Games Id to the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkFacebookInstantGamesIdAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkFacebookInstantGamesIdRequest request
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
                Interop.PFAccountManagementLinkFacebookInstantGamesIdRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkFacebookInstantGamesIdRequest[1];
                PFAccountManagementLinkFacebookInstantGamesIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkFacebookInstantGamesIdAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account.
        /// Logging in with a Game Center ID is insecure if you do not include the optional PublicKeyUrl, Salt,
        /// Signature, and Timestamp parameters in this request. It is recommended you require these parameters
        /// on all Game Center calls by going to the Apple Add-ons page in the PlayFab Game Manager and enabling
        /// the 'Require secure authentication only for this app' option.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkGameCenterAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkGameCenterAccountRequest request
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
                Interop.PFAccountManagementLinkGameCenterAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkGameCenterAccountRequest[1];
                PFAccountManagementLinkGameCenterAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkGameCenterAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the currently signed-in user account to their Google account, using their Google account credentials
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkGoogleAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkGoogleAccountRequest request
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
                Interop.PFAccountManagementLinkGoogleAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkGoogleAccountRequest[1];
                PFAccountManagementLinkGoogleAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkGoogleAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the currently signed-in user account to their Google Play Games account, using their Google
        /// Play Games account credentials
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkGooglePlayGamesServicesAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkGooglePlayGamesServicesAccountRequest request
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
                Interop.PFAccountManagementLinkGooglePlayGamesServicesAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkGooglePlayGamesServicesAccountRequest[1];
                PFAccountManagementLinkGooglePlayGamesServicesAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkGooglePlayGamesServicesAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the vendor-specific iOS device identifier to the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkIOSDeviceIDAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkIOSDeviceIDRequest request
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
                Interop.PFAccountManagementLinkIOSDeviceIDRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkIOSDeviceIDRequest[1];
                PFAccountManagementLinkIOSDeviceIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkIOSDeviceIDAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Kongregate identifier to the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkKongregateAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkKongregateAccountRequest request
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
                Interop.PFAccountManagementLinkKongregateAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkKongregateAccountRequest[1];
                PFAccountManagementLinkKongregateAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkKongregateAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Nintendo account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkNintendoServiceAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientLinkNintendoServiceAccountRequest request
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
                Interop.PFAccountManagementClientLinkNintendoServiceAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientLinkNintendoServiceAccountRequest[1];
                PFAccountManagementClientLinkNintendoServiceAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkNintendoServiceAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkNintendoSwitchDeviceIdAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest request
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
                Interop.PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest* requestInterop = stackalloc Interop.PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest[1];
                PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkNintendoSwitchDeviceIdAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links an OpenID Connect account to a user's PlayFab account, based on an existing relationship between
        /// a title and an Open ID Connect provider and the OpenId Connect JWT from that provider.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkOpenIdConnectAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkOpenIdConnectRequest request
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
                Interop.PFAccountManagementLinkOpenIdConnectRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkOpenIdConnectRequest[1];
                PFAccountManagementLinkOpenIdConnectRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkOpenIdConnectAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided access code to the user's
        /// PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkPSNAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientLinkPSNAccountRequest request
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
                Interop.PFAccountManagementClientLinkPSNAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientLinkPSNAccountRequest[1];
                PFAccountManagementClientLinkPSNAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkPSNAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab
        /// account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkSteamAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementLinkSteamAccountRequest request
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
                Interop.PFAccountManagementLinkSteamAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkSteamAccountRequest[1];
                PFAccountManagementLinkSteamAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkSteamAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Twitch account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkTwitchAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientLinkTwitchAccountRequest request
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
                Interop.PFAccountManagementClientLinkTwitchAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientLinkTwitchAccountRequest[1];
                PFAccountManagementClientLinkTwitchAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkTwitchAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientLinkXboxAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientLinkXboxAccountRequest request
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
                Interop.PFAccountManagementClientLinkXboxAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientLinkXboxAccountRequest[1];
                PFAccountManagementClientLinkXboxAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientLinkXboxAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Removes a contact email from the player's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientRemoveContactEmailAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementRemoveContactEmailRequest request
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
                Interop.PFAccountManagementRemoveContactEmailRequest* requestInterop = stackalloc Interop.PFAccountManagementRemoveContactEmailRequest[1];
                PFAccountManagementRemoveContactEmailRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientRemoveContactEmailAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Submit a report for another player (due to bad bahavior, etc.), so that customer service representatives
        /// for the title can take action concerning potentially toxic players.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementReportPlayerClientResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementClientReportPlayerGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementReportPlayerClientResult>> PFAccountManagementClientReportPlayerAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementReportPlayerClientRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementReportPlayerClientResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFAccountManagementReportPlayerClientResult result = default;

                    hr = Interop.Methods.PFAccountManagementClientReportPlayerGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementReportPlayerClientRequest* requestInterop = stackalloc Interop.PFAccountManagementReportPlayerClientRequest[1];
                PFAccountManagementReportPlayerClientRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientReportPlayerAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing
        /// the user to change the password.If an account recovery email template ID is provided, an email using
        /// the custom email template will be used.
        /// </summary>
        /// <param name="serviceConfigHandle">PFServiceConfigHandle returned from PFServiceConfigCreateHandle call.</param>
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
        public static Task<PFResult> PFAccountManagementClientSendAccountRecoveryEmailAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAccountManagementSendAccountRecoveryEmailRequest request
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
                Interop.PFAccountManagementSendAccountRecoveryEmailRequest* requestInterop = stackalloc Interop.PFAccountManagementSendAccountRecoveryEmailRequest[1];
                PFAccountManagementSendAccountRecoveryEmailRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientSendAccountRecoveryEmailAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Android device identifier from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkAndroidDeviceIDAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkAndroidDeviceIDRequest request
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
                Interop.PFAccountManagementUnlinkAndroidDeviceIDRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkAndroidDeviceIDRequest[1];
                PFAccountManagementUnlinkAndroidDeviceIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkAndroidDeviceIDAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Apple account from the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkAppleAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkAppleRequest request
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
                Interop.PFAccountManagementUnlinkAppleRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkAppleRequest[1];
                PFAccountManagementUnlinkAppleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkAppleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Battle.net account from the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkBattleNetAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUnlinkBattleNetAccountRequest request
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
                Interop.PFAccountManagementClientUnlinkBattleNetAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUnlinkBattleNetAccountRequest[1];
                PFAccountManagementClientUnlinkBattleNetAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkBattleNetAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related custom identifier from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkCustomIDAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkCustomIDRequest request
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
                Interop.PFAccountManagementUnlinkCustomIDRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkCustomIDRequest[1];
                PFAccountManagementUnlinkCustomIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkCustomIDAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Facebook account from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkFacebookAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUnlinkFacebookAccountRequest request
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
                Interop.PFAccountManagementClientUnlinkFacebookAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUnlinkFacebookAccountRequest[1];
                PFAccountManagementClientUnlinkFacebookAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkFacebookAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Facebook Instant Game Ids from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkFacebookInstantGamesIdAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest request
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
                Interop.PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest[1];
                PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkFacebookInstantGamesIdAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Game Center account from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkGameCenterAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkGameCenterAccountRequest request
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
                Interop.PFAccountManagementUnlinkGameCenterAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkGameCenterAccountRequest[1];
                PFAccountManagementUnlinkGameCenterAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkGameCenterAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Google account from the user's PlayFab account (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods).
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkGoogleAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkGoogleAccountRequest request
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
                Interop.PFAccountManagementUnlinkGoogleAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkGoogleAccountRequest[1];
                PFAccountManagementUnlinkGoogleAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkGoogleAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Google Play Games account from the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkGooglePlayGamesServicesAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest request
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
                Interop.PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest[1];
                PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkGooglePlayGamesServicesAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related iOS device identifier from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkIOSDeviceIDAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkIOSDeviceIDRequest request
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
                Interop.PFAccountManagementUnlinkIOSDeviceIDRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkIOSDeviceIDRequest[1];
                PFAccountManagementUnlinkIOSDeviceIDRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkIOSDeviceIDAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Kongregate identifier from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkKongregateAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkKongregateAccountRequest request
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
                Interop.PFAccountManagementUnlinkKongregateAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkKongregateAccountRequest[1];
                PFAccountManagementUnlinkKongregateAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkKongregateAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Nintendo account from the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkNintendoServiceAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUnlinkNintendoServiceAccountRequest request
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
                Interop.PFAccountManagementClientUnlinkNintendoServiceAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUnlinkNintendoServiceAccountRequest[1];
                PFAccountManagementClientUnlinkNintendoServiceAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkNintendoServiceAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkNintendoSwitchDeviceIdAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest request
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
                Interop.PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest[1];
                PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkNintendoSwitchDeviceIdAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks an OpenID Connect account from a user's PlayFab account, based on the connection ID of an
        /// existing relationship between a title and an Open ID Connect provider.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkOpenIdConnectAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkOpenIdConnectRequest request
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
                Interop.PFAccountManagementUnlinkOpenIdConnectRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkOpenIdConnectRequest[1];
                PFAccountManagementUnlinkOpenIdConnectRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkOpenIdConnectAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related PlayStation :tm: Network account from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkPSNAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUnlinkPSNAccountRequest request
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
                Interop.PFAccountManagementClientUnlinkPSNAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUnlinkPSNAccountRequest[1];
                PFAccountManagementClientUnlinkPSNAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkPSNAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Steam account from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkSteamAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUnlinkSteamAccountRequest request
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
                Interop.PFAccountManagementUnlinkSteamAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkSteamAccountRequest[1];
                PFAccountManagementUnlinkSteamAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkSteamAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Twitch account from the user's PlayFab account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkTwitchAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUnlinkTwitchAccountRequest request
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
                Interop.PFAccountManagementClientUnlinkTwitchAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUnlinkTwitchAccountRequest[1];
                PFAccountManagementClientUnlinkTwitchAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkTwitchAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFAccountManagementClientUnlinkXboxAccountAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUnlinkXboxAccountRequest request
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
                Interop.PFAccountManagementClientUnlinkXboxAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUnlinkXboxAccountRequest[1];
                PFAccountManagementClientUnlinkXboxAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUnlinkXboxAccountAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Update the avatar URL of the player
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFAccountManagementClientUpdateAvatarUrlAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementClientUpdateAvatarUrlRequest request
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
                Interop.PFAccountManagementClientUpdateAvatarUrlRequest* requestInterop = stackalloc Interop.PFAccountManagementClientUpdateAvatarUrlRequest[1];
                PFAccountManagementClientUpdateAvatarUrlRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUpdateAvatarUrlAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the title specific display name for the user
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult<PFAccountManagementUpdateUserTitleDisplayNameResult>> PFAccountManagementClientUpdateUserTitleDisplayNameAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementUpdateUserTitleDisplayNameRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementUpdateUserTitleDisplayNameResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementClientUpdateUserTitleDisplayNameGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementUpdateUserTitleDisplayNameResult* result = null;

                    hr = Interop.Methods.PFAccountManagementClientUpdateUserTitleDisplayNameGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementUpdateUserTitleDisplayNameRequest* requestInterop = stackalloc Interop.PFAccountManagementUpdateUserTitleDisplayNameRequest[1];
                PFAccountManagementUpdateUserTitleDisplayNameRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementClientUpdateUserTitleDisplayNameAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Bans users by PlayFab ID with optional IP address for the provided game.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult<PFAccountManagementBanUsersResult>> PFAccountManagementServerBanUsersAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementBanUsersRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementBanUsersResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerBanUsersGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementBanUsersResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerBanUsersGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementBanUsersRequest* requestInterop = stackalloc Interop.PFAccountManagementBanUsersRequest[1];
                PFAccountManagementBanUsersRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerBanUsersAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Removes a user's player account from a title and deletes all associated data
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerDeletePlayerAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementDeletePlayerRequest request
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
                Interop.PFAccountManagementDeletePlayerRequest* requestInterop = stackalloc Interop.PFAccountManagementDeletePlayerRequest[1];
                PFAccountManagementDeletePlayerRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerDeletePlayerAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Returns whatever info is requested in the response for the user. Note that PII (like email address,
        /// facebook id) may be returned. All parameters default to false.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayerCombinedInfoResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayerCombinedInfoGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayerCombinedInfoGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayerCombinedInfoResult>> PFAccountManagementServerGetPlayerCombinedInfoAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayerCombinedInfoRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayerCombinedInfoResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayerCombinedInfoGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayerCombinedInfoResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayerCombinedInfoGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayerCombinedInfoRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayerCombinedInfoRequest[1];
                PFAccountManagementGetPlayerCombinedInfoRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayerCombinedInfoAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult<PFAccountManagementGetPlayerProfileResult>> PFAccountManagementServerGetPlayerProfileAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayerProfileRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayerProfileResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayerProfileGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayerProfileResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayerProfileGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayerProfileRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayerProfileRequest[1];
                PFAccountManagementGetPlayerProfileRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayerProfileAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Battle.net account identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsGetResult"/> to get the
        /// result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult>> PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest[1];
                PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromFacebookIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromFacebookIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromFacebookIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookIDsResult>> PFAccountManagementServerGetPlayFabIDsFromFacebookIDsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromFacebookIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromFacebookIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromFacebookIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromFacebookIDsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Games identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsGetResult"/> to get
        /// the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult>> PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest[1];
                PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Service Account identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsGetResult"/> to
        /// get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult>> PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest[1];
                PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch Device identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResult"/> to get
        /// the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest[1];
                PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult>> PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult>> PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers
        /// are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromSteamIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromSteamIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromSteamIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromSteamIDsResult>> PFAccountManagementServerGetPlayFabIDsFromSteamIDsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromSteamIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromSteamIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromSteamIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromSteamIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromSteamIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromSteamIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromSteamIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromSteamIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromSteamIDsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers
        /// are persona names.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromSteamNamesResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromSteamNamesGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromSteamNamesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromSteamNamesResult>> PFAccountManagementServerGetPlayFabIDsFromSteamNamesAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromSteamNamesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromSteamNamesResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromSteamNamesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromSteamNamesResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromSteamNamesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromSteamNamesRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromSteamNamesRequest[1];
                PFAccountManagementGetPlayFabIDsFromSteamNamesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromSteamNamesAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers
        /// are the IDs for the user accounts, available as '_id' from the Twitch API methods (ex: https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromTwitchIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromTwitchIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromTwitchIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromTwitchIDsResult>> PFAccountManagementServerGetPlayFabIDsFromTwitchIDsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromTwitchIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromTwitchIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromTwitchIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromTwitchIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromTwitchIDsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of XboxLive identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult>> PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest[1];
                PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the associated PlayFab account identifiers for the given set of server custom identifiers.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult>> PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest[1];
                PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult<PFAccountManagementGetUserAccountInfoResult>> PFAccountManagementServerGetUserAccountInfoAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetUserAccountInfoRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetUserAccountInfoResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetUserAccountInfoGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetUserAccountInfoResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetUserAccountInfoGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetUserAccountInfoRequest* requestInterop = stackalloc Interop.PFAccountManagementGetUserAccountInfoRequest[1];
                PFAccountManagementGetUserAccountInfoRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetUserAccountInfoAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult<PFAccountManagementGetUserBansResult>> PFAccountManagementServerGetUserBansAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementGetUserBansRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetUserBansResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerGetUserBansGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetUserBansResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerGetUserBansGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetUserBansRequest* requestInterop = stackalloc Interop.PFAccountManagementGetUserBansRequest[1];
                PFAccountManagementGetUserBansRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerGetUserBansAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Battle.net account associated with the token to the user's PlayFab account.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerLinkBattleNetAccountAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerLinkBattleNetAccountRequest request
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
                Interop.PFAccountManagementServerLinkBattleNetAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementServerLinkBattleNetAccountRequest[1];
                PFAccountManagementServerLinkBattleNetAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkBattleNetAccountAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Nintendo account associated with the token to the user's PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerLinkNintendoServiceAccountAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerLinkNintendoServiceAccountRequest request
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
                Interop.PFAccountManagementServerLinkNintendoServiceAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementServerLinkNintendoServiceAccountRequest[1];
                PFAccountManagementServerLinkNintendoServiceAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkNintendoServiceAccountAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Nintendo account associated with the Nintendo Service Account subject or id to the user's
        /// PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerLinkNintendoServiceAccountSubjectAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementLinkNintendoServiceAccountSubjectRequest request
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
                Interop.PFAccountManagementLinkNintendoServiceAccountSubjectRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkNintendoServiceAccountSubjectRequest[1];
                PFAccountManagementLinkNintendoServiceAccountSubjectRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkNintendoServiceAccountSubjectAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerLinkNintendoSwitchDeviceIdAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest request
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
                Interop.PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest* requestInterop = stackalloc Interop.PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest[1];
                PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkNintendoSwitchDeviceIdAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided access code to the user's
        /// PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerLinkPSNAccountAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerLinkPSNAccountRequest request
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
                Interop.PFAccountManagementServerLinkPSNAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementServerLinkPSNAccountRequest[1];
                PFAccountManagementServerLinkPSNAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkPSNAccountAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided user id to the user's PlayFab
        /// account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerLinkPSNIdAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementLinkPSNIdRequest request
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
                Interop.PFAccountManagementLinkPSNIdRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkPSNIdRequest[1];
                PFAccountManagementLinkPSNIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkPSNIdAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the custom server identifier, generated by the title, to the user's PlayFab account.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_FOUND, E_PF_LINKED_IDENTIFIER_ALREADY_CLAIMED or any of
        /// the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public static Task<PFResult> PFAccountManagementServerLinkServerCustomIdAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementLinkServerCustomIdRequest request
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
                Interop.PFAccountManagementLinkServerCustomIdRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkServerCustomIdRequest[1];
                PFAccountManagementLinkServerCustomIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkServerCustomIdAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam ID to the user's PlayFab account 
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerLinkSteamIdAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementLinkSteamIdRequest request
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
                Interop.PFAccountManagementLinkSteamIdRequest* requestInterop = stackalloc Interop.PFAccountManagementLinkSteamIdRequest[1];
                PFAccountManagementLinkSteamIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkSteamIdAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerLinkXboxAccountAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerLinkXboxAccountRequest request
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
                Interop.PFAccountManagementServerLinkXboxAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementServerLinkXboxAccountRequest[1];
                PFAccountManagementServerLinkXboxAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerLinkXboxAccountAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult<PFAccountManagementRevokeAllBansForUserResult>> PFAccountManagementServerRevokeAllBansForUserAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementRevokeAllBansForUserRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementRevokeAllBansForUserResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerRevokeAllBansForUserGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementRevokeAllBansForUserResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerRevokeAllBansForUserGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementRevokeAllBansForUserRequest* requestInterop = stackalloc Interop.PFAccountManagementRevokeAllBansForUserRequest[1];
                PFAccountManagementRevokeAllBansForUserRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerRevokeAllBansForUserAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Revoke all active bans specified with BanId.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult<PFAccountManagementRevokeBansResult>> PFAccountManagementServerRevokeBansAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementRevokeBansRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementRevokeBansResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerRevokeBansGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementRevokeBansResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerRevokeBansGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementRevokeBansRequest* requestInterop = stackalloc Interop.PFAccountManagementRevokeBansRequest[1];
                PFAccountManagementRevokeBansRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerRevokeBansAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Forces an email to be sent to the registered contact email address for the user's account based on
        /// an account recovery email template
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerSendCustomAccountRecoveryEmailAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementSendCustomAccountRecoveryEmailRequest request
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
                Interop.PFAccountManagementSendCustomAccountRecoveryEmailRequest* requestInterop = stackalloc Interop.PFAccountManagementSendCustomAccountRecoveryEmailRequest[1];
                PFAccountManagementSendCustomAccountRecoveryEmailRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerSendCustomAccountRecoveryEmailAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Sends an email based on an email template to a player's contact email 
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerSendEmailFromTemplateAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementSendEmailFromTemplateRequest request
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
                Interop.PFAccountManagementSendEmailFromTemplateRequest* requestInterop = stackalloc Interop.PFAccountManagementSendEmailFromTemplateRequest[1];
                PFAccountManagementSendEmailFromTemplateRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerSendEmailFromTemplateAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Battle.net account from the user's PlayFab account.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerUnlinkBattleNetAccountAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerUnlinkBattleNetAccountRequest request
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
                Interop.PFAccountManagementServerUnlinkBattleNetAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementServerUnlinkBattleNetAccountRequest[1];
                PFAccountManagementServerUnlinkBattleNetAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUnlinkBattleNetAccountAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Nintendo account from the user's PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerUnlinkNintendoServiceAccountAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerUnlinkNintendoServiceAccountRequest request
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
                Interop.PFAccountManagementServerUnlinkNintendoServiceAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementServerUnlinkNintendoServiceAccountRequest[1];
                PFAccountManagementServerUnlinkNintendoServiceAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUnlinkNintendoServiceAccountAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerUnlinkNintendoSwitchDeviceIdAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest request
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
                Interop.PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest* requestInterop = stackalloc Interop.PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest[1];
                PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUnlinkNintendoSwitchDeviceIdAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related PlayStation :tm: Network account from the user's PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerUnlinkPSNAccountAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerUnlinkPSNAccountRequest request
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
                Interop.PFAccountManagementServerUnlinkPSNAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementServerUnlinkPSNAccountRequest[1];
                PFAccountManagementServerUnlinkPSNAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUnlinkPSNAccountAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the custom server identifier from the user's PlayFab account.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerUnlinkServerCustomIdAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementUnlinkServerCustomIdRequest request
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
                Interop.PFAccountManagementUnlinkServerCustomIdRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkServerCustomIdRequest[1];
                PFAccountManagementUnlinkServerCustomIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUnlinkServerCustomIdAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the Steam account associated with the provided Steam ID to the user's PlayFab account 
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerUnlinkSteamIdAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementUnlinkSteamIdRequest request
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
                Interop.PFAccountManagementUnlinkSteamIdRequest* requestInterop = stackalloc Interop.PFAccountManagementUnlinkSteamIdRequest[1];
                PFAccountManagementUnlinkSteamIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUnlinkSteamIdAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult> PFAccountManagementServerUnlinkXboxAccountAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerUnlinkXboxAccountRequest request
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
                Interop.PFAccountManagementServerUnlinkXboxAccountRequest* requestInterop = stackalloc Interop.PFAccountManagementServerUnlinkXboxAccountRequest[1];
                PFAccountManagementServerUnlinkXboxAccountRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUnlinkXboxAccountAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Update the avatar URL of the specified player
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFAccountManagementServerUpdateAvatarUrlAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementServerUpdateAvatarUrlRequest request
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
                Interop.PFAccountManagementServerUpdateAvatarUrlRequest* requestInterop = stackalloc Interop.PFAccountManagementServerUpdateAvatarUrlRequest[1];
                PFAccountManagementServerUpdateAvatarUrlRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUpdateAvatarUrlAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
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
        public static Task<PFResult<PFAccountManagementUpdateBansResult>> PFAccountManagementServerUpdateBansAsync(
            PFEntityHandle titleEntityHandle,
            PFAccountManagementUpdateBansRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementUpdateBansResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementServerUpdateBansGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementUpdateBansResult* result = null;

                    hr = Interop.Methods.PFAccountManagementServerUpdateBansGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementUpdateBansRequest* requestInterop = stackalloc Interop.PFAccountManagementUpdateBansRequest[1];
                PFAccountManagementUpdateBansRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementServerUpdateBansAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title player accounts associated with the given XUIDs.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFAccountManagementGetTitlePlayersFromProviderIDsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given a collection of Xbox IDs (XUIDs), returns all title player accounts.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAccountManagementGetTitlePlayersFromXboxLiveIDsGetResultSize"/>
        /// and <see cref="PFAccountManagementGetTitlePlayersFromXboxLiveIDsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFAccountManagementGetTitlePlayersFromProviderIDsResponse>> PFAccountManagementGetTitlePlayersFromXboxLiveIDsAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementGetTitlePlayersFromProviderIDsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementGetTitlePlayersFromXboxLiveIDsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementGetTitlePlayersFromProviderIDsResponse* result = null;

                    hr = Interop.Methods.PFAccountManagementGetTitlePlayersFromXboxLiveIDsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest* requestInterop = stackalloc Interop.PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest[1];
                PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementGetTitlePlayersFromXboxLiveIDsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Update the display name of the entity
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult<PFAccountManagementSetDisplayNameResponse>> PFAccountManagementSetDisplayNameAsync(
            PFEntityHandle entityHandle,
            PFAccountManagementSetDisplayNameRequest request
        )
        {
            TaskCompletionSource<PFResult<PFAccountManagementSetDisplayNameResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAccountManagementSetDisplayNameGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAccountManagementSetDisplayNameResponse* result = null;

                    hr = Interop.Methods.PFAccountManagementSetDisplayNameGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAccountManagementSetDisplayNameRequest* requestInterop = stackalloc Interop.PFAccountManagementSetDisplayNameRequest[1];
                PFAccountManagementSetDisplayNameRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAccountManagementSetDisplayNameAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
