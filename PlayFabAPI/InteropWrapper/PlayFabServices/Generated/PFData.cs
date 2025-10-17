// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFData
    {

        /// <summary>
        /// Abort pending file uploads to an entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataAbortFileUploadsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Aborts the pending upload of the requested files. See also FileDeleteFilesAsync, FileFinalizeFileUploadsAsync,
        /// FileGetFilesAsync, FileInitiateFileUploadsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataAbortFileUploadsGetResultSize"/> and
        /// <see cref="PFDataAbortFileUploadsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFDataAbortFileUploadsResponse>> PFDataAbortFileUploadsAsync(
            PFEntityHandle entityHandle,
            PFDataAbortFileUploadsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFDataAbortFileUploadsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFDataAbortFileUploadsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFDataAbortFileUploadsResponse* result = null;

                    hr = Interop.Methods.PFDataAbortFileUploadsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFDataAbortFileUploadsRequest* requestInterop = stackalloc Interop.PFDataAbortFileUploadsRequest[1];
                PFDataAbortFileUploadsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFDataAbortFileUploadsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Delete files on an entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataDeleteFilesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Deletes the requested files from the entity's profile. See also FileAbortFileUploadsAsync, FileFinalizeFileUploadsAsync,
        /// FileGetFilesAsync, FileInitiateFileUploadsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataDeleteFilesGetResultSize"/> and <see
        /// cref="PFDataDeleteFilesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFDataDeleteFilesResponse>> PFDataDeleteFilesAsync(
            PFEntityHandle entityHandle,
            PFDataDeleteFilesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFDataDeleteFilesResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFDataDeleteFilesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFDataDeleteFilesResponse* result = null;

                    hr = Interop.Methods.PFDataDeleteFilesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFDataDeleteFilesRequest* requestInterop = stackalloc Interop.PFDataDeleteFilesRequest[1];
                PFDataDeleteFilesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFDataDeleteFilesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Finalize file uploads to an entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataFinalizeFileUploadsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Finalizes the upload of the requested files. Verifies that the files have been successfully uploaded
        /// and moves the file pointers from pending to live. See also FileAbortFileUploadsAsync, FileDeleteFilesAsync,
        /// FileGetFilesAsync, FileInitiateFileUploadsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataFinalizeFileUploadsGetResultSize"/>
        /// and <see cref="PFDataFinalizeFileUploadsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFDataFinalizeFileUploadsResponse>> PFDataFinalizeFileUploadsAsync(
            PFEntityHandle entityHandle,
            PFDataFinalizeFileUploadsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFDataFinalizeFileUploadsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFDataFinalizeFileUploadsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFDataFinalizeFileUploadsResponse* result = null;

                    hr = Interop.Methods.PFDataFinalizeFileUploadsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFDataFinalizeFileUploadsRequest* requestInterop = stackalloc Interop.PFDataFinalizeFileUploadsRequest[1];
                PFDataFinalizeFileUploadsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFDataFinalizeFileUploadsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves file metadata from an entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataGetFilesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns URLs that may be used to download the files for a profile for a limited length of time. Only
        /// returns files that have been successfully uploaded, files that are still pending will either return
        /// the old value, if it exists, or nothing. See also FileAbortFileUploadsAsync, FileDeleteFilesAsync,
        /// FileFinalizeFileUploadsAsync, FileInitiateFileUploadsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataGetFilesGetResultSize"/> and <see cref="PFDataGetFilesGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFDataGetFilesResponse>> PFDataGetFilesAsync(
            PFEntityHandle entityHandle,
            PFDataGetFilesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFDataGetFilesResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFDataGetFilesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFDataGetFilesResponse* result = null;

                    hr = Interop.Methods.PFDataGetFilesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFDataGetFilesRequest* requestInterop = stackalloc Interop.PFDataGetFilesRequest[1];
                PFDataGetFilesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFDataGetFilesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves objects from an entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataGetObjectsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Gets JSON objects from an entity profile and returns it.  See also ObjectSetObjectsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataGetObjectsGetResultSize"/> and <see
        /// cref="PFDataGetObjectsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFDataGetObjectsResponse>> PFDataGetObjectsAsync(
            PFEntityHandle entityHandle,
            PFDataGetObjectsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFDataGetObjectsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFDataGetObjectsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFDataGetObjectsResponse* result = null;

                    hr = Interop.Methods.PFDataGetObjectsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFDataGetObjectsRequest* requestInterop = stackalloc Interop.PFDataGetObjectsRequest[1];
                PFDataGetObjectsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFDataGetObjectsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Initiates file uploads to an entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataInitiateFileUploadsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns URLs that may be used to upload the files for a profile 5 minutes. After using the upload
        /// calls FinalizeFileUploads must be called to move the file status from pending to live. See also FileAbortFileUploadsAsync,
        /// FileDeleteFilesAsync, FileFinalizeFileUploadsAsync, FileGetFilesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataInitiateFileUploadsGetResultSize"/>
        /// and <see cref="PFDataInitiateFileUploadsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFDataInitiateFileUploadsResponse>> PFDataInitiateFileUploadsAsync(
            PFEntityHandle entityHandle,
            PFDataInitiateFileUploadsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFDataInitiateFileUploadsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFDataInitiateFileUploadsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFDataInitiateFileUploadsResponse* result = null;

                    hr = Interop.Methods.PFDataInitiateFileUploadsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFDataInitiateFileUploadsRequest* requestInterop = stackalloc Interop.PFDataInitiateFileUploadsRequest[1];
                PFDataInitiateFileUploadsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFDataInitiateFileUploadsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Sets objects on an entity's profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataSetObjectsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Sets JSON objects on the requested entity profile. May include a version number to be used to perform
        /// optimistic concurrency operations during update. If the current version differs from the version in
        /// the request the request will be ignored. If no version is set on the request then the value will always
        /// be updated if the values differ. Using the version value does not guarantee a write though, ConcurrentEditError
        /// may still occur if multiple clients are attempting to update the same profile.  See also ObjectGetObjectsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataSetObjectsGetResultSize"/> and <see
        /// cref="PFDataSetObjectsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFDataSetObjectsResponse>> PFDataSetObjectsAsync(
            PFEntityHandle entityHandle,
            PFDataSetObjectsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFDataSetObjectsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFDataSetObjectsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFDataSetObjectsResponse* result = null;

                    hr = Interop.Methods.PFDataSetObjectsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFDataSetObjectsRequest* requestInterop = stackalloc Interop.PFDataSetObjectsRequest[1];
                PFDataSetObjectsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFDataSetObjectsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
