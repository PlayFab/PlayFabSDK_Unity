// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFCore
    {
#if UNITY_ANDROID
        /// <summary>
        /// Initializes PlayFabCore global state with the JVM and Java Application Context. Custom platform hooks must be configured prior to calling PFInitialize.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFInitialize()
        {
            var result = Interop.Methods.PFInitialize(AsyncHelpers.DefaultQueue.handle.intPtr, UnityEngine.AndroidJNI.GetJavaVM(), UnityEngine.Android.AndroidApplication.currentContext.GetRawObject());
            return new(result);
        }
#else
        /// <summary>
        /// Initialize PlayFabCore global state. Custom platform hooks must be configured prior to calling PFInitialize.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFInitialize()
        {
            var result = Interop.Methods.PFInitialize(AsyncHelpers.DefaultQueue.handle.intPtr);
            return new(result);
        }
#endif

        /// <summary>
        /// Cleanup PlayFab Core global state.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// This will internally call PFUninitializeAsync() if PFCoreInitialize() needed 
        /// to call PFInitialize() interally.
        /// </remarks>
        public static Task<PFResult> PFUninitializeAsync()
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

                int hr = Interop.Methods.PFUninitializeAsync((Interop.XAsyncBlock*)asyncBlock.Handle);

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
