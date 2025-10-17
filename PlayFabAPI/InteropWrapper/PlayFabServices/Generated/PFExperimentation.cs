// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFExperimentation
    {

        /// <summary>
        /// Gets the treatment assignments for a player for every running experiment in the title.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFExperimentationGetTreatmentAssignmentResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFExperimentationGetTreatmentAssignmentGetResultSize"/>
        /// and <see cref="PFExperimentationGetTreatmentAssignmentGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFExperimentationGetTreatmentAssignmentResult>> PFExperimentationGetTreatmentAssignmentAsync(
            PFEntityHandle entityHandle,
            PFExperimentationGetTreatmentAssignmentRequest request
        )
        {
            TaskCompletionSource<PFResult<PFExperimentationGetTreatmentAssignmentResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFExperimentationGetTreatmentAssignmentGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFExperimentationGetTreatmentAssignmentResult* result = null;

                    hr = Interop.Methods.PFExperimentationGetTreatmentAssignmentGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFExperimentationGetTreatmentAssignmentRequest* requestInterop = stackalloc Interop.PFExperimentationGetTreatmentAssignmentRequest[1];
                PFExperimentationGetTreatmentAssignmentRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFExperimentationGetTreatmentAssignmentAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
