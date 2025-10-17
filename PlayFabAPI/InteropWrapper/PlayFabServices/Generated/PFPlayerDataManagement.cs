// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFPlayerDataManagement
    {

        /// <summary>
        /// Deletes title-specific custom properties for a player
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Deletes custom properties for the specified player. The list of provided property names must be non-empty.
        /// See also ClientGetPlayerCustomPropertyAsync, ClientListPlayerCustomPropertiesAsync, ClientUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientDeletePlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientDeletePlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult>> PFPlayerDataManagementClientDeletePlayerCustomPropertiesAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementClientDeletePlayerCustomPropertiesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementClientDeletePlayerCustomPropertiesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest[1];
                PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientDeletePlayerCustomPropertiesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves a title-specific custom property value for a player.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetPlayerCustomPropertyResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientDeletePlayerCustomPropertiesAsync, ClientListPlayerCustomPropertiesAsync, ClientUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetPlayerCustomPropertyGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetPlayerCustomPropertyGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementClientGetPlayerCustomPropertyResult>> PFPlayerDataManagementClientGetPlayerCustomPropertyAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementClientGetPlayerCustomPropertyRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementClientGetPlayerCustomPropertyResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementClientGetPlayerCustomPropertyGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementClientGetPlayerCustomPropertyResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementClientGetPlayerCustomPropertyGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementClientGetPlayerCustomPropertyRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementClientGetPlayerCustomPropertyRequest[1];
                PFPlayerDataManagementClientGetPlayerCustomPropertyRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientGetPlayerCustomPropertyAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Data is stored as JSON key-value pairs. Every time the data is updated via any source, the version
        /// counter is incremented. If the Version parameter is provided, then this call will only return data
        /// if the current version on the system is greater than the value provided. If the Keys parameter is
        /// provided, the data object returned will only contain the data specific to the indicated Keys. Otherwise,
        /// the full set of custom user data will be returned. See also ClientGetUserReadOnlyDataAsync, ClientUpdateUserDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetUserDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetUserDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementClientGetUserDataResult>> PFPlayerDataManagementClientGetUserDataAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementClientGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementClientGetUserDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementClientGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementClientGetUserDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientGetUserDataAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ClientGetUserPublisherReadOnlyDataAsync, ClientUpdateUserPublisherDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetUserPublisherDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetUserPublisherDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementClientGetUserDataResult>> PFPlayerDataManagementClientGetUserPublisherDataAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementClientGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementClientGetUserPublisherDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementClientGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementClientGetUserPublisherDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientGetUserPublisherDataAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ClientGetUserPublisherDataAsync, ClientUpdateUserPublisherDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetUserPublisherReadOnlyDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetUserPublisherReadOnlyDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementClientGetUserDataResult>> PFPlayerDataManagementClientGetUserPublisherReadOnlyDataAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementClientGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementClientGetUserPublisherReadOnlyDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementClientGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementClientGetUserPublisherReadOnlyDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientGetUserPublisherReadOnlyDataAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Data is stored as JSON key-value pairs. Every time the data is updated via any source, the version
        /// counter is incremented. If the Version parameter is provided, then this call will only return data
        /// if the current version on the system is greater than the value provided. If the Keys parameter is
        /// provided, the data object returned will only contain the data specific to the indicated Keys. Otherwise,
        /// the full set of custom user data will be returned. See also ClientGetUserDataAsync, ClientUpdateUserDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetUserReadOnlyDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetUserReadOnlyDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementClientGetUserDataResult>> PFPlayerDataManagementClientGetUserReadOnlyDataAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementClientGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementClientGetUserReadOnlyDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementClientGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementClientGetUserReadOnlyDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientGetUserReadOnlyDataAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves title-specific custom property values for a player.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientListPlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientDeletePlayerCustomPropertiesAsync, ClientGetPlayerCustomPropertyAsync, ClientUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientListPlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientListPlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementClientListPlayerCustomPropertiesResult>> PFPlayerDataManagementClientListPlayerCustomPropertiesAsync(
            PFEntityHandle entityHandle
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementClientListPlayerCustomPropertiesResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementClientListPlayerCustomPropertiesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementClientListPlayerCustomPropertiesResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementClientListPlayerCustomPropertiesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                int hr = Interop.Methods.PFPlayerDataManagementClientListPlayerCustomPropertiesAsync(entityHandle.Handle, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the title-specific custom property values for a player
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Performs an additive update of the custom properties for the specified player. In updating the player's
        /// custom properties, properties which already exist will have their values overwritten. No other properties
        /// will be changed apart from those specified in the call. See also ClientDeletePlayerCustomPropertiesAsync,
        /// ClientGetPlayerCustomPropertyAsync, ClientListPlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientUpdatePlayerCustomPropertiesGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult>> PFPlayerDataManagementClientUpdatePlayerCustomPropertiesAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementClientUpdatePlayerCustomPropertiesGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest[1];
                PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientUpdatePlayerCustomPropertiesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user which is readable and writable by
        /// the client
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This function performs an additive update of the arbitrary strings containing the custom data for
        /// the user. In updating the custom data object, keys which already exist in the object will have their
        /// values overwritten, while keys with null values will be removed. New keys will be added, with the
        /// given values. No other key-value pairs will be changed apart from those specified in the call. See
        /// also ClientGetUserDataAsync, ClientGetUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientUpdateUserDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PFPlayerDataManagementClientUpdateUserDataAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementClientUpdateUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementUpdateUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementUpdateUserDataResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementClientUpdateUserDataGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementClientUpdateUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementClientUpdateUserDataRequest[1];
                PFPlayerDataManagementClientUpdateUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientUpdateUserDataAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Creates and updates the publisher-specific custom data for the user which is readable and writable
        /// by the client
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This function performs an additive update of the arbitrary strings containing the custom data for
        /// the user. In updating the custom data object, keys which already exist in the object will have their
        /// values overwritten, while keys with null values will be removed. New keys will be added, with the
        /// given values. No other key-value pairs will be changed apart from those specified in the call. See
        /// also ClientGetUserPublisherDataAsync, ClientGetUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientUpdateUserPublisherDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PFPlayerDataManagementClientUpdateUserPublisherDataAsync(
            PFEntityHandle entityHandle,
            PFPlayerDataManagementClientUpdateUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementUpdateUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementUpdateUserDataResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementClientUpdateUserPublisherDataGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementClientUpdateUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementClientUpdateUserDataRequest[1];
                PFPlayerDataManagementClientUpdateUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementClientUpdateUserPublisherDataAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Deletes title-specific custom properties for a player
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Deletes custom properties for the specified player. The list of provided property names must be non-empty.
        /// See also ServerGetPlayerCustomPropertyAsync, ServerListPlayerCustomPropertiesAsync, ServerUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerDeletePlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerDeletePlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult>> PFPlayerDataManagementServerDeletePlayerCustomPropertiesAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerDeletePlayerCustomPropertiesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerDeletePlayerCustomPropertiesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest[1];
                PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerDeletePlayerCustomPropertiesAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves a title-specific custom property value for a player.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetPlayerCustomPropertyResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ServerDeletePlayerCustomPropertiesAsync, ServerListPlayerCustomPropertiesAsync, ServerUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetPlayerCustomPropertyGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetPlayerCustomPropertyGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerGetPlayerCustomPropertyResult>> PFPlayerDataManagementServerGetPlayerCustomPropertyAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementServerGetPlayerCustomPropertyRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerGetPlayerCustomPropertyResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerGetPlayerCustomPropertyGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerGetPlayerCustomPropertyResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerGetPlayerCustomPropertyGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementServerGetPlayerCustomPropertyRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementServerGetPlayerCustomPropertyRequest[1];
                PFPlayerDataManagementServerGetPlayerCustomPropertyRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerGetPlayerCustomPropertyAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserInternalDataAsync, ServerGetUserReadOnlyDataAsync, ServerUpdateUserDataAsync,
        /// ServerUpdateUserInternalDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PFPlayerDataManagementServerGetUserDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerGetUserDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserDataAsync, ServerGetUserReadOnlyDataAsync, ServerUpdateUserDataAsync,
        /// ServerUpdateUserInternalDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserInternalDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserInternalDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PFPlayerDataManagementServerGetUserInternalDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserInternalDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserInternalDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerGetUserInternalDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserPublisherInternalDataAsync, ServerGetUserPublisherReadOnlyDataAsync,
        /// ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherInternalDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserPublisherDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserPublisherDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PFPlayerDataManagementServerGetUserPublisherDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherReadOnlyDataAsync,
        /// ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherInternalDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserPublisherInternalDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserPublisherInternalDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PFPlayerDataManagementServerGetUserPublisherInternalDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherInternalDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherInternalDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherInternalDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherInternalDataAsync,
        /// ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherInternalDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserPublisherReadOnlyDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserPublisherReadOnlyDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PFPlayerDataManagementServerGetUserPublisherReadOnlyDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherReadOnlyDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherReadOnlyDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerGetUserPublisherReadOnlyDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserDataAsync, ServerGetUserInternalDataAsync, ServerUpdateUserDataAsync,
        /// ServerUpdateUserInternalDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserReadOnlyDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserReadOnlyDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PFPlayerDataManagementServerGetUserReadOnlyDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerGetUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserReadOnlyDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerGetUserDataResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerGetUserReadOnlyDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementGetUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementGetUserDataRequest[1];
                PFPlayerDataManagementGetUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerGetUserReadOnlyDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves title-specific custom property values for a player.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerListPlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ServerDeletePlayerCustomPropertiesAsync, ServerGetPlayerCustomPropertyAsync, ServerUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerListPlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerListPlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerListPlayerCustomPropertiesResult>> PFPlayerDataManagementServerListPlayerCustomPropertiesAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementListPlayerCustomPropertiesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerListPlayerCustomPropertiesResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerListPlayerCustomPropertiesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerListPlayerCustomPropertiesResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerListPlayerCustomPropertiesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementListPlayerCustomPropertiesRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementListPlayerCustomPropertiesRequest[1];
                PFPlayerDataManagementListPlayerCustomPropertiesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerListPlayerCustomPropertiesAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the title-specific custom property values for a player
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Performs an additive update of the custom properties for the specified player. In updating the player's
        /// custom properties, properties which already exist will have their values overwritten. No other properties
        /// will be changed apart from those specified in the call. See also ServerDeletePlayerCustomPropertiesAsync,
        /// ServerGetPlayerCustomPropertyAsync, ServerListPlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdatePlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerUpdatePlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult>> PFPlayerDataManagementServerUpdatePlayerCustomPropertiesAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult* result = null;

                    hr = Interop.Methods.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest[1];
                PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, while keys with null values will be removed. No other key-value pairs will
        /// be changed apart from those specified in the call. See also ServerGetUserDataAsync, ServerGetUserInternalDataAsync,
        /// ServerGetUserReadOnlyDataAsync, ServerUpdateUserInternalDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PFPlayerDataManagementServerUpdateUserDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementServerUpdateUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementUpdateUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementUpdateUserDataResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserDataGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementServerUpdateUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementServerUpdateUserDataRequest[1];
                PFPlayerDataManagementServerUpdateUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, keys with null values will be removed. No other key-value pairs will be
        /// changed apart from those specified in the call. See also ServerGetUserDataAsync, ServerGetUserInternalDataAsync,
        /// ServerGetUserReadOnlyDataAsync, ServerUpdateUserDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserInternalDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PFPlayerDataManagementServerUpdateUserInternalDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementUpdateUserInternalDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementUpdateUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementUpdateUserDataResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserInternalDataGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementUpdateUserInternalDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementUpdateUserInternalDataRequest[1];
                PFPlayerDataManagementUpdateUserInternalDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserInternalDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, while keys with null values will be removed. No other key-value pairs will
        /// be changed apart from those specified in the call. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherInternalDataAsync,
        /// ServerGetUserPublisherReadOnlyDataAsync, ServerUpdateUserPublisherInternalDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserPublisherDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PFPlayerDataManagementServerUpdateUserPublisherDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementServerUpdateUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementUpdateUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementUpdateUserDataResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserPublisherDataGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementServerUpdateUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementServerUpdateUserDataRequest[1];
                PFPlayerDataManagementServerUpdateUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserPublisherDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, keys with null values will be removed. No other key-value pairs will be
        /// changed apart from those specified in the call. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherInternalDataAsync,
        /// ServerGetUserPublisherReadOnlyDataAsync, ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserPublisherInternalDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PFPlayerDataManagementServerUpdateUserPublisherInternalDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementUpdateUserInternalDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementUpdateUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementUpdateUserDataResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserPublisherInternalDataGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementUpdateUserInternalDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementUpdateUserInternalDataRequest[1];
                PFPlayerDataManagementUpdateUserInternalDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserPublisherInternalDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, keys with null values will be removed. No other key-value pairs will be
        /// changed apart from those specified in the call. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherInternalDataAsync,
        /// ServerGetUserPublisherReadOnlyDataAsync, ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherInternalDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserPublisherReadOnlyDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PFPlayerDataManagementServerUpdateUserPublisherReadOnlyDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementServerUpdateUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementUpdateUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementUpdateUserDataResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserPublisherReadOnlyDataGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementServerUpdateUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementServerUpdateUserDataRequest[1];
                PFPlayerDataManagementServerUpdateUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserPublisherReadOnlyDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, keys with null values will be removed. No other key-value pairs will be
        /// changed apart from those specified in the call. See also ServerGetUserDataAsync, ServerGetUserInternalDataAsync,
        /// ServerGetUserReadOnlyDataAsync, ServerUpdateUserDataAsync, ServerUpdateUserInternalDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserReadOnlyDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PFPlayerDataManagementServerUpdateUserReadOnlyDataAsync(
            PFEntityHandle titleEntityHandle,
            PFPlayerDataManagementServerUpdateUserDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlayerDataManagementUpdateUserDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFPlayerDataManagementUpdateUserDataResult result = default;

                    hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserReadOnlyDataGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlayerDataManagementServerUpdateUserDataRequest* requestInterop = stackalloc Interop.PFPlayerDataManagementServerUpdateUserDataRequest[1];
                PFPlayerDataManagementServerUpdateUserDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlayerDataManagementServerUpdateUserReadOnlyDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
