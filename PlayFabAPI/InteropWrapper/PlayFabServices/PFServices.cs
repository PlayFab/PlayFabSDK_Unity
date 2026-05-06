using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab.InteropWrapper.Core;

namespace PlayFab.InteropWrapper.Services
{
    public static class PFServices
    {
#if UNITY_ANDROID
        /// <summary>
        /// Initializes PlayFab Services global state with the JVM and Java Application Context.
        /// </summary>
        /// <remarks>
        /// This will internally call PFInitialize() if it hasn't been called already by the
        /// title. If control of PFCore background work is needed, the title should explicitly call
        /// PFInitialize and PFUninitialize.
        /// </remarks>
        /// <returns>Result code for this API operation.</returns>
        public static int PFServicesInitialize()
        {
            unsafe
            {
                Interop.HCInitArgs* initArgs = stackalloc Interop.HCInitArgs[1];
                initArgs->javaVM = UnityEngine.AndroidJNI.GetJavaVM();
                initArgs->applicationContext = UnityEngine.Android.AndroidApplication.currentContext.GetRawObject();
            
                return Interop.Methods.PFServicesInitialize(AsyncHelpers.DefaultQueue.handle.intPtr, initArgs);
            }
        }
#else
        /// <summary>
        /// Initializes PlayFab Services global state
        /// </summary>
        /// <remarks>
        /// This will internally call PFInitialize() if it hasn't been called already by the
        /// title. If control of PFCore background work is needed, the title should explicitly call
        /// PFInitialize and PFUninitialize.
        /// </remarks>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFServicesInitialize()
        {
            var result = Interop.Methods.PFServicesInitialize(AsyncHelpers.DefaultQueue.handle.intPtr);
            return new(result);
        }
#endif

        /// <summary>
        /// Cleanup PlayFab Services global state.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// This will internally call PFUninitializeAsync() if PFServicesInitialize() needed 
        /// to call PFInitialize() interally.
        /// </remarks>
        public static Task<PFResult> PFServicesUninitializeAsync()
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

                int hr = Interop.Methods.PFServicesUninitializeAsync((Interop.XAsyncBlock*)asyncBlock.Handle);

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
