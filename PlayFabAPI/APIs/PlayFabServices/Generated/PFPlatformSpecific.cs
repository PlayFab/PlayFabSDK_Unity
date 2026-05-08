// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFPlayerEntity
    {
        /// <summary>
        /// Registers the Android device to receive push notifications
        /// </summary>
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
        public Task<PFResult> PlatformSpecificClientAndroidDevicePushNotificationRegistrationAsync(
            PFPlatformSpecificAndroidDevicePushNotificationRegistrationRequest request
        )
        {
            return InteropWrapper.Services.PFPlatformSpecific.PFPlatformSpecificClientAndroidDevicePushNotificationRegistrationAsync(InteropHandle, request);
        }

        /// <summary>
        /// Registers the iOS device to receive push notifications
        /// </summary>
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
        public Task<PFResult> PlatformSpecificClientRegisterForIOSPushNotificationAsync(
            PFPlatformSpecificRegisterForIOSPushNotificationRequest request
        )
        {
            return InteropWrapper.Services.PFPlatformSpecific.PFPlatformSpecificClientRegisterForIOSPushNotificationAsync(InteropHandle, request);
        }
    }

    public partial class PFTitleEntity
    {
        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlatformSpecificAwardSteamAchievementResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFPlatformSpecificServerAwardSteamAchievementGetResultSize"/>
        /// and <see cref="PFPlatformSpecificServerAwardSteamAchievementGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlatformSpecificAwardSteamAchievementResult>> PlatformSpecificServerAwardSteamAchievementAsync(
            PFPlatformSpecificAwardSteamAchievementRequest request
        )
        {
            return InteropWrapper.Services.PFPlatformSpecific.PFPlatformSpecificServerAwardSteamAchievementAsync(InteropHandle, request);
        }
    }
}
