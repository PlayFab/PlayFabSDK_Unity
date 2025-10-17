using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFPushNotificationsServerSendPushNotificationAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFPushNotificationsSendPushNotificationRequest *")] PFPushNotificationsSendPushNotificationRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFPushNotificationsServerSendPushNotificationFromTemplateAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFPushNotificationsSendPushNotificationFromTemplateRequest *")] PFPushNotificationsSendPushNotificationFromTemplateRequest* request, XAsyncBlock* async);
    }
}
