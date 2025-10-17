// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFFriends
    {

        /// <summary>
        /// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list
        /// of the local user. At least one of FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName
        /// should be initialized.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFFriendsAddFriendResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientGetFriendsListAsync, ClientSetFriendTagsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFFriendsClientAddFriendGetResult"/> to get
        /// the result.
        /// </remarks>
        public static Task<PFResult<PFFriendsAddFriendResult>> PFFriendsClientAddFriendAsync(
            PFEntityHandle entityHandle,
            PFFriendsClientAddFriendRequest request
        )
        {
            TaskCompletionSource<PFResult<PFFriendsAddFriendResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFFriendsAddFriendResult result = default;

                    hr = Interop.Methods.PFFriendsClientAddFriendGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFFriendsClientAddFriendRequest* requestInterop = stackalloc Interop.PFFriendsClientAddFriendRequest[1];
                PFFriendsClientAddFriendRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFFriendsClientAddFriendAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts.
        /// Friends from linked accounts (Facebook, Steam) are also included. You may optionally exclude some
        /// linked services' friends.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFFriendsGetFriendsListResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientAddFriendAsync, ClientGetPlayerProfileAsync, ClientRemoveFriendAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFFriendsClientGetFriendsListGetResultSize"/>
        /// and <see cref="PFFriendsClientGetFriendsListGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFFriendsGetFriendsListResult>> PFFriendsClientGetFriendsListAsync(
            PFEntityHandle entityHandle,
            PFFriendsClientGetFriendsListRequest request
        )
        {
            TaskCompletionSource<PFResult<PFFriendsGetFriendsListResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFFriendsClientGetFriendsListGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFFriendsGetFriendsListResult* result = null;

                    hr = Interop.Methods.PFFriendsClientGetFriendsListGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFFriendsClientGetFriendsListRequest* requestInterop = stackalloc Interop.PFFriendsClientGetFriendsListRequest[1];
                PFFriendsClientGetFriendsListRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFFriendsClientGetFriendsListAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Removes a specified user from the friend list of the local user
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientAddFriendAsync, ClientSetFriendTagsAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFFriendsClientRemoveFriendAsync(
            PFEntityHandle entityHandle,
            PFFriendsClientRemoveFriendRequest request
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
                Interop.PFFriendsClientRemoveFriendRequest* requestInterop = stackalloc Interop.PFFriendsClientRemoveFriendRequest[1];
                PFFriendsClientRemoveFriendRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFFriendsClientRemoveFriendAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of the local user
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This operation is not additive. It will completely replace the tag list for the specified user. Please
        /// note that only users in the PlayFab friends list can be assigned tags. Attempting to set a tag on
        /// a friend only included in the friends list from a social site integration (such as Facebook or Steam)
        /// will return the AccountNotFound error. See also ClientAddFriendAsync, ClientRemoveFriendAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFFriendsClientSetFriendTagsAsync(
            PFEntityHandle entityHandle,
            PFFriendsClientSetFriendTagsRequest request
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
                Interop.PFFriendsClientSetFriendTagsRequest* requestInterop = stackalloc Interop.PFFriendsClientSetFriendTagsRequest[1];
                PFFriendsClientSetFriendTagsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFFriendsClientSetFriendTagsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of FriendPlayFabId,FriendUsername,FriendEmail,
        /// or FriendTitleDisplayName should be initialized.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerGetFriendsListAsync, ServerRemoveFriendAsync, ServerSetFriendTagsAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_USERS_ALREADY_FRIENDS or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFFriendsServerAddFriendAsync(
            PFEntityHandle titleEntityHandle,
            PFFriendsServerAddFriendRequest request
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
                Interop.PFFriendsServerAddFriendRequest* requestInterop = stackalloc Interop.PFFriendsServerAddFriendRequest[1];
                PFFriendsServerAddFriendRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFFriendsServerAddFriendAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab
        /// accounts. Friends from linked accounts (Facebook, Steam) are also included. You may optionally exclude
        /// some linked services' friends.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFFriendsGetFriendsListResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerAddFriendAsync, ServerGetPlayerProfileAsync, ServerRemoveFriendAsync, ServerSetFriendTagsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFFriendsServerGetFriendsListGetResultSize"/>
        /// and <see cref="PFFriendsServerGetFriendsListGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFFriendsGetFriendsListResult>> PFFriendsServerGetFriendsListAsync(
            PFEntityHandle titleEntityHandle,
            PFFriendsServerGetFriendsListRequest request
        )
        {
            TaskCompletionSource<PFResult<PFFriendsGetFriendsListResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFFriendsServerGetFriendsListGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFFriendsGetFriendsListResult* result = null;

                    hr = Interop.Methods.PFFriendsServerGetFriendsListGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFFriendsServerGetFriendsListRequest* requestInterop = stackalloc Interop.PFFriendsServerGetFriendsListRequest[1];
                PFFriendsServerGetFriendsListRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFFriendsServerGetFriendsListAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Removes the specified friend from the the user's friend list
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerAddFriendAsync, ServerSetFriendTagsAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_FOUND or any of the global PlayFab Service errors. See doc
        /// page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFFriendsServerRemoveFriendAsync(
            PFEntityHandle titleEntityHandle,
            PFFriendsServerRemoveFriendRequest request
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
                Interop.PFFriendsServerRemoveFriendRequest* requestInterop = stackalloc Interop.PFFriendsServerRemoveFriendRequest[1];
                PFFriendsServerRemoveFriendRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFFriendsServerRemoveFriendAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of another user
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This operation is not additive. It will completely replace the tag list for the specified user. Please
        /// note that only users in the PlayFab friends list can be assigned tags. Attempting to set a tag on
        /// a friend only included in the friends list from a social site integration (such as Facebook or Steam)
        /// will return the AccountNotFound error. See also ServerAddFriendAsync, ServerGetFriendsListAsync, ServerRemoveFriendAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFFriendsServerSetFriendTagsAsync(
            PFEntityHandle titleEntityHandle,
            PFFriendsServerSetFriendTagsRequest request
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
                Interop.PFFriendsServerSetFriendTagsRequest* requestInterop = stackalloc Interop.PFFriendsServerSetFriendTagsRequest[1];
                PFFriendsServerSetFriendTagsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFFriendsServerSetFriendTagsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
