// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFEvents
    {

        /// <summary>
        /// Write batches of entity based events to PlayStream. The namespace of the Event must be 'custom' or
        /// start with 'custom.'.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEventsWriteEventsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFEventsWriteEventsGetResultSize"/> and <see
        /// cref="PFEventsWriteEventsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFEventsWriteEventsResponse>> PFEventsWriteEventsAsync(
            PFEntityHandle entityHandle,
            PFEventsWriteEventsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFEventsWriteEventsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFEventsWriteEventsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFEventsWriteEventsResponse* result = null;

                    hr = Interop.Methods.PFEventsWriteEventsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFEventsWriteEventsRequest* requestInterop = stackalloc Interop.PFEventsWriteEventsRequest[1];
                PFEventsWriteEventsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFEventsWriteEventsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Write batches of entity based events to as Telemetry events (bypass PlayStream). The namespace must
        /// be 'custom' or start with 'custom.'
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEventsWriteEventsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This API must be called with either X-EntityToken or X-TelemetryKey headers. If sending X-EntityToken
        /// the value must be a valid EntityToken for your title. If using X-TelemetryKey the value must be a
        /// Telemetry Key configured for your title set to 'Active'. If both are provided, X-TelemetryKey will
        /// be ignored.
        ///
        /// When the asynchronous task is complete, call <see cref="PFEventsWriteTelemetryEventsGetResultSize"/>
        /// and <see cref="PFEventsWriteTelemetryEventsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFEventsWriteEventsResponse>> PFEventsWriteTelemetryEventsAsync(
            PFEntityHandle entityHandle,
            PFEventsWriteEventsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFEventsWriteEventsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFEventsWriteTelemetryEventsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFEventsWriteEventsResponse* result = null;

                    hr = Interop.Methods.PFEventsWriteTelemetryEventsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFEventsWriteEventsRequest* requestInterop = stackalloc Interop.PFEventsWriteEventsRequest[1];
                PFEventsWriteEventsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFEventsWriteTelemetryEventsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
