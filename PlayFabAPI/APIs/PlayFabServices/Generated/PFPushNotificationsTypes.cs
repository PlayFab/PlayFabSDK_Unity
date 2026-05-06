// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFPushNotificationsAdvancedPushPlatformMsg data model.
    /// </summary>
    public struct PFPushNotificationsAdvancedPushPlatformMsg
    {
        /// <summary>
        /// (Optional) Stops GoogleCloudMessaging notifications from including both notification and data properties
        /// and instead only sends the data property.
        /// </summary>
        public bool? GCMDataOnly;

        /// <summary>
        /// The Json the platform should receive.
        /// </summary>
        public string Json;

        /// <summary>
        /// The platform that should receive the Json.
        /// </summary>
        public PFPushNotificationPlatform Platform;

        internal unsafe PFPushNotificationsAdvancedPushPlatformMsg(Interop.PFPushNotificationsAdvancedPushPlatformMsg interop)
        {

            GCMDataOnly = (interop.gCMDataOnly == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.gCMDataOnly);

            Json = InteropWrapper.WrapperHelpers.InteropToString(interop.json)!;

            Platform = (PFPushNotificationPlatform)(interop.platform);

        }

        internal unsafe static void ToInterop(PFPushNotificationsAdvancedPushPlatformMsg self, Interop.PFPushNotificationsAdvancedPushPlatformMsg* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.GCMDataOnly != null)
            {
                *interop->gCMDataOnly = InteropWrapper.WrapperHelpers.BoolToInterop(self.GCMDataOnly.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Json, &interop->json, buffer);

            interop->platform = (Interop.PFPushNotificationPlatform)self.Platform;

        }
    }

    /// <summary>
    /// PFPushNotificationsPushNotificationPackage data model.
    /// </summary>
    public struct PFPushNotificationsPushNotificationPackage
    {
        /// <summary>
        /// Numerical badge to display on App icon (iOS only).
        /// </summary>
        public int Badge;

        /// <summary>
        /// (Optional) This must be a JSON formatted object. For use with developer-created custom Push Notification
        /// plugins.
        /// </summary>
        public string? CustomData;

        /// <summary>
        /// (Optional) Icon file to display with the message (Not supported for iOS).
        /// </summary>
        public string? Icon;

        /// <summary>
        /// Content of the message (all platforms).
        /// </summary>
        public string Message;

        /// <summary>
        /// (Optional) Sound file to play with the message (all platforms).
        /// </summary>
        public string? Sound;

        /// <summary>
        /// Title/Subject of the message. Not supported for iOS.
        /// </summary>
        public string Title;

        internal unsafe PFPushNotificationsPushNotificationPackage(Interop.PFPushNotificationsPushNotificationPackage interop)
        {

            Badge = interop.badge;

            CustomData = (interop.customData == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.customData);

            Icon = (interop.icon == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.icon);

            Message = InteropWrapper.WrapperHelpers.InteropToString(interop.message)!;

            Sound = (interop.sound == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.sound);

            Title = InteropWrapper.WrapperHelpers.InteropToString(interop.title)!;

        }

        internal unsafe static void ToInterop(PFPushNotificationsPushNotificationPackage self, Interop.PFPushNotificationsPushNotificationPackage* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->badge = self.Badge;

            if (self.CustomData != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CustomData, &interop->customData, buffer);
            }

            if (self.Icon != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Icon, &interop->icon, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Message, &interop->message, buffer);

            if (self.Sound != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Sound, &interop->sound, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Title, &interop->title, buffer);

        }
    }

    /// <summary>
    /// PFPushNotificationsSendPushNotificationRequest data model.
    /// </summary>
    public struct PFPushNotificationsSendPushNotificationRequest
    {
        /// <summary>
        /// (Optional) Allows you to provide precisely formatted json to target devices. This is an advanced
        /// feature, allowing you to deliver to custom plugin logic, fields, or functionality not natively supported
        /// by PlayFab.
        /// </summary>
        public PFPushNotificationsAdvancedPushPlatformMsg[]? AdvancedPlatformDelivery;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Text of message to send.
        /// </summary>
        public string? Message;

        /// <summary>
        /// (Optional) Defines all possible push attributes like message, title, icon, etc. Some parameters are
        /// device specific - please see the PushNotificationPackage documentation for details.
        /// </summary>
        public PFPushNotificationsPushNotificationPackage? Package;

        /// <summary>
        /// PlayFabId of the recipient of the push notification.
        /// </summary>
        public string Recipient;

        /// <summary>
        /// (Optional) Subject of message to send (may not be displayed in all platforms).
        /// </summary>
        public string? Subject;

        /// <summary>
        /// (Optional) Target Platforms that should receive the Message or Package. If omitted, we will send
        /// to all available platforms.
        /// </summary>
        public PFPushNotificationPlatform[]? TargetPlatforms;

        internal unsafe static void ToInterop(PFPushNotificationsSendPushNotificationRequest self, Interop.PFPushNotificationsSendPushNotificationRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AdvancedPlatformDelivery != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.AdvancedPlatformDelivery, &interop->advancedPlatformDelivery, buffer, PFPushNotificationsAdvancedPushPlatformMsg.ToInterop);
                interop->advancedPlatformDeliveryCount = (uint)self.AdvancedPlatformDelivery.Length;
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Message != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Message, &interop->message, buffer);
            }

            if (self.Package != null)
            {
                interop->package = (Interop.PFPushNotificationsPushNotificationPackage*)buffer.AddBuffer(sizeof(Interop.PFPushNotificationsPushNotificationPackage));
                PFPushNotificationsPushNotificationPackage.ToInterop(self.Package.Value, interop->package, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Recipient, &interop->recipient, buffer);

            if (self.Subject != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Subject, &interop->subject, buffer);
            }

            if (self.TargetPlatforms != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToEnumInterop(self.TargetPlatforms, &interop->targetPlatforms, buffer, elem => (Interop.PFPushNotificationPlatform)elem);
                interop->targetPlatformsCount = (uint)self.TargetPlatforms.Length;
            }

        }
    }

    /// <summary>
    /// PFPushNotificationsSendPushNotificationFromTemplateRequest data model. Represents the request for
    /// sending a push notification template to a recipient.
    /// </summary>
    public struct PFPushNotificationsSendPushNotificationFromTemplateRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Id of the push notification template.
        /// </summary>
        public string PushNotificationTemplateId;

        /// <summary>
        /// PlayFabId of the push notification recipient.
        /// </summary>
        public string Recipient;

        internal unsafe static void ToInterop(PFPushNotificationsSendPushNotificationFromTemplateRequest self, Interop.PFPushNotificationsSendPushNotificationFromTemplateRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PushNotificationTemplateId, &interop->pushNotificationTemplateId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.Recipient, &interop->recipient, buffer);

        }
    }

}
