// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFLocalization
    {

        /// <summary>
        /// Retrieves the list of allowed languages, only accessible by title entities
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLocalizationGetLanguageListResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFLocalizationGetLanguageListGetResultSize"/>
        /// and <see cref="PFLocalizationGetLanguageListGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFLocalizationGetLanguageListResponse>> PFLocalizationGetLanguageListAsync(
            PFEntityHandle entityHandle,
            PFLocalizationGetLanguageListRequest request
        )
        {
            TaskCompletionSource<PFResult<PFLocalizationGetLanguageListResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFLocalizationGetLanguageListGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFLocalizationGetLanguageListResponse* result = null;

                    hr = Interop.Methods.PFLocalizationGetLanguageListGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFLocalizationGetLanguageListRequest* requestInterop = stackalloc Interop.PFLocalizationGetLanguageListRequest[1];
                PFLocalizationGetLanguageListRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLocalizationGetLanguageListAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
