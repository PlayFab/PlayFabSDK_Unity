// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFTitleEntity
    {
        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured
        /// for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be
        /// notified.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_PUSH_NOT_ENABLED_FOR_ACCOUNT, E_PF_PUSH_SERVICE_ERROR or any of the
        /// global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> PushNotificationsServerSendPushNotificationAsync(
            PFPushNotificationsSendPushNotificationRequest request
        )
        {
            return InteropWrapper.Services.PFPushNotifications.PFPushNotificationsServerSendPushNotificationAsync(InteropHandle, request);
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification template to a specific user, if that user's device has been
        /// configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both
        /// will be notified.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_PUSH_NOT_ENABLED_FOR_ACCOUNT, E_PF_PUSH_NOTIFICATION_TEMPLATE_NOT_FOUND,
        /// E_PF_PUSH_SERVICE_ERROR or any of the global PlayFab Service errors. See doc page "Handling PlayFab
        /// Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> PushNotificationsServerSendPushNotificationFromTemplateAsync(
            PFPushNotificationsSendPushNotificationFromTemplateRequest request
        )
        {
            return InteropWrapper.Services.PFPushNotifications.PFPushNotificationsServerSendPushNotificationFromTemplateAsync(InteropHandle, request);
        }
    }
}
