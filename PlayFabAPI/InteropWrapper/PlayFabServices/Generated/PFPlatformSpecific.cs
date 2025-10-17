// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFPlatformSpecific
    {

        /// <summary>
        /// Registers the Android device to receive push notifications
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Android.
        /// More information can be found on configuring your game for the Google Cloud Messaging service in
        /// the Google developer documentation, here: http://developer.android.com/google/gcm/client.html. The
        /// steps to configure and send Push Notifications is described in the PlayFab tutorials, here: https://docs.microsoft.com/gaming/playfab/features/engagement/push-notifications/quickstart.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_NO_PUSH_NOTIFICATION_ARN_FOR_TITLE, E_PF_PUSH_SERVICE_ERROR or any of
        /// the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public static Task<PFResult> PFPlatformSpecificClientAndroidDevicePushNotificationRegistrationAsync(
            PFEntityHandle entityHandle,
            PFPlatformSpecificAndroidDevicePushNotificationRegistrationRequest request
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
                Interop.PFPlatformSpecificAndroidDevicePushNotificationRegistrationRequest* requestInterop = stackalloc Interop.PFPlatformSpecificAndroidDevicePushNotificationRegistrationRequest[1];
                PFPlatformSpecificAndroidDevicePushNotificationRegistrationRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlatformSpecificClientAndroidDevicePushNotificationRegistrationAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Registers the iOS device to receive push notifications
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on iOS.
        /// The steps to configure and send Push Notifications is described in the PlayFab tutorials, here: https://docs.microsoft.com/gaming/playfab/features/engagement/push-notifications/quickstart.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_NO_PUSH_NOTIFICATION_ARN_FOR_TITLE, E_PF_PUSH_SERVICE_ERROR or any of
        /// the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public static Task<PFResult> PFPlatformSpecificClientRegisterForIOSPushNotificationAsync(
            PFEntityHandle entityHandle,
            PFPlatformSpecificRegisterForIOSPushNotificationRequest request
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
                Interop.PFPlatformSpecificRegisterForIOSPushNotificationRequest* requestInterop = stackalloc Interop.PFPlatformSpecificRegisterForIOSPushNotificationRequest[1];
                PFPlatformSpecificRegisterForIOSPushNotificationRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlatformSpecificClientRegisterForIOSPushNotificationAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlatformSpecificAwardSteamAchievementResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFPlatformSpecificServerAwardSteamAchievementGetResultSize"/>
        /// and <see cref="PFPlatformSpecificServerAwardSteamAchievementGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFPlatformSpecificAwardSteamAchievementResult>> PFPlatformSpecificServerAwardSteamAchievementAsync(
            PFEntityHandle titleEntityHandle,
            PFPlatformSpecificAwardSteamAchievementRequest request
        )
        {
            TaskCompletionSource<PFResult<PFPlatformSpecificAwardSteamAchievementResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFPlatformSpecificServerAwardSteamAchievementGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFPlatformSpecificAwardSteamAchievementResult* result = null;

                    hr = Interop.Methods.PFPlatformSpecificServerAwardSteamAchievementGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFPlatformSpecificAwardSteamAchievementRequest* requestInterop = stackalloc Interop.PFPlatformSpecificAwardSteamAchievementRequest[1];
                PFPlatformSpecificAwardSteamAchievementRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPlatformSpecificServerAwardSteamAchievementAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
