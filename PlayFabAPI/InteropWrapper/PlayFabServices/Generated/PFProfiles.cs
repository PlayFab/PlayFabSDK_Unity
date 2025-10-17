// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFProfiles
    {

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesGetEntityProfileResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity type and entity identifier will retrieve the profile from the entity store. If the
        /// profile being retrieved is the caller's, then the read operation is consistent, if not it is an inconsistent
        /// read. An inconsistent read means that we do not guarantee all committed writes have occurred before
        /// reading the profile, allowing for a stale read. If consistency is important the Version Number on
        /// the result can be used to compare which version of the profile any reader has.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesGetProfileGetResultSize"/> and
        /// <see cref="PFProfilesGetProfileGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFProfilesGetEntityProfileResponse>> PFProfilesGetProfileAsync(
            PFEntityHandle entityHandle,
            PFProfilesGetEntityProfileRequest request
        )
        {
            TaskCompletionSource<PFResult<PFProfilesGetEntityProfileResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFProfilesGetProfileGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFProfilesGetEntityProfileResponse* result = null;

                    hr = Interop.Methods.PFProfilesGetProfileGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFProfilesGetEntityProfileRequest* requestInterop = stackalloc Interop.PFProfilesGetEntityProfileRequest[1];
                PFProfilesGetEntityProfileRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFProfilesGetProfileAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesGetEntityProfilesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given a set of entity types and entity identifiers will retrieve all readable profiles properties
        /// for the caller. Profiles that the caller is not allowed to read will silently not be included in the
        /// results.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesGetProfilesGetResultSize"/> and
        /// <see cref="PFProfilesGetProfilesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFProfilesGetEntityProfilesResponse>> PFProfilesGetProfilesAsync(
            PFEntityHandle entityHandle,
            PFProfilesGetEntityProfilesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFProfilesGetEntityProfilesResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFProfilesGetProfilesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFProfilesGetEntityProfilesResponse* result = null;

                    hr = Interop.Methods.PFProfilesGetProfilesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFProfilesGetEntityProfilesRequest* requestInterop = stackalloc Interop.PFProfilesGetEntityProfilesRequest[1];
                PFProfilesGetEntityProfilesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFProfilesGetProfilesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title player accounts associated with the given master player account.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given a master player account id (PlayFab ID), returns all title player accounts associated with
        /// it.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsGetResultSize"/>
        /// and <see cref="PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse>> PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsAsync(
            PFEntityHandle entityHandle,
            PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse* result = null;

                    hr = Interop.Methods.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest* requestInterop = stackalloc Interop.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest[1];
                PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the entity's language. The precedence hierarchy for communication to the player is Title
        /// Player Account language, Master Player Account language, and then title default language if the first
        /// two aren't set or supported.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesSetProfileLanguageResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity profile, will update its language to the one passed in if the profile's version is
        /// equal to the one passed in.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesSetProfileLanguageGetResultSize"/>
        /// and <see cref="PFProfilesSetProfileLanguageGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFProfilesSetProfileLanguageResponse>> PFProfilesSetProfileLanguageAsync(
            PFEntityHandle entityHandle,
            PFProfilesSetProfileLanguageRequest request
        )
        {
            TaskCompletionSource<PFResult<PFProfilesSetProfileLanguageResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFProfilesSetProfileLanguageGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFProfilesSetProfileLanguageResponse* result = null;

                    hr = Interop.Methods.PFProfilesSetProfileLanguageGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFProfilesSetProfileLanguageRequest* requestInterop = stackalloc Interop.PFProfilesSetProfileLanguageRequest[1];
                PFProfilesSetProfileLanguageRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFProfilesSetProfileLanguageAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Sets the profiles access policy
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFProfilesSetEntityProfilePolicyResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This will set the access policy statements on the given entity profile. This is not additive, any
        /// existing statements will be replaced with the statements in this request. See also ProfileGetProfileAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFProfilesSetProfilePolicyGetResultSize"/>
        /// and <see cref="PFProfilesSetProfilePolicyGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFProfilesSetEntityProfilePolicyResponse>> PFProfilesSetProfilePolicyAsync(
            PFEntityHandle entityHandle,
            PFProfilesSetEntityProfilePolicyRequest request
        )
        {
            TaskCompletionSource<PFResult<PFProfilesSetEntityProfilePolicyResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFProfilesSetProfilePolicyGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFProfilesSetEntityProfilePolicyResponse* result = null;

                    hr = Interop.Methods.PFProfilesSetProfilePolicyGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFProfilesSetEntityProfilePolicyRequest* requestInterop = stackalloc Interop.PFProfilesSetEntityProfilePolicyRequest[1];
                PFProfilesSetEntityProfilePolicyRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFProfilesSetProfilePolicyAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
