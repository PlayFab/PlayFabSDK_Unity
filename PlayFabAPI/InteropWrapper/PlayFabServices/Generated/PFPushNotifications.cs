// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFPushNotifications
    {

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured
        /// for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be
        /// notified.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_PUSH_NOT_ENABLED_FOR_ACCOUNT, E_PF_PUSH_SERVICE_ERROR or any of the
        /// global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFPushNotificationsServerSendPushNotificationAsync(
            PFEntityHandle titleEntityHandle,
            PFPushNotificationsSendPushNotificationRequest request
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
                Interop.PFPushNotificationsSendPushNotificationRequest* requestInterop = stackalloc Interop.PFPushNotificationsSendPushNotificationRequest[1];
                PFPushNotificationsSendPushNotificationRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPushNotificationsServerSendPushNotificationAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification template to a specific user, if that user's device has been
        /// configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both
        /// will be notified.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_PUSH_NOT_ENABLED_FOR_ACCOUNT, E_PF_PUSH_NOTIFICATION_TEMPLATE_NOT_FOUND,
        /// E_PF_PUSH_SERVICE_ERROR or any of the global PlayFab Service errors. See doc page "Handling PlayFab
        /// Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFPushNotificationsServerSendPushNotificationFromTemplateAsync(
            PFEntityHandle titleEntityHandle,
            PFPushNotificationsSendPushNotificationFromTemplateRequest request
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
                Interop.PFPushNotificationsSendPushNotificationFromTemplateRequest* requestInterop = stackalloc Interop.PFPushNotificationsSendPushNotificationFromTemplateRequest[1];
                PFPushNotificationsSendPushNotificationFromTemplateRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFPushNotificationsServerSendPushNotificationFromTemplateAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
