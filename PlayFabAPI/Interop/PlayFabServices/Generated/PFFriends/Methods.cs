using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsClientAddFriendAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFFriendsClientAddFriendRequest *")] PFFriendsClientAddFriendRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsClientAddFriendGetResult(XAsyncBlock* async, PFFriendsAddFriendResult* result);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsClientGetFriendsListAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFFriendsClientGetFriendsListRequest *")] PFFriendsClientGetFriendsListRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsClientGetFriendsListGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsClientGetFriendsListGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFFriendsGetFriendsListResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsClientRemoveFriendAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFFriendsClientRemoveFriendRequest *")] PFFriendsClientRemoveFriendRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsClientSetFriendTagsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFFriendsClientSetFriendTagsRequest *")] PFFriendsClientSetFriendTagsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsServerAddFriendAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFFriendsServerAddFriendRequest *")] PFFriendsServerAddFriendRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsServerGetFriendsListAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFFriendsServerGetFriendsListRequest *")] PFFriendsServerGetFriendsListRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsServerGetFriendsListGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsServerGetFriendsListGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFFriendsGetFriendsListResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsServerRemoveFriendAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFFriendsServerRemoveFriendRequest *")] PFFriendsServerRemoveFriendRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFFriendsServerSetFriendTagsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFFriendsServerSetFriendTagsRequest *")] PFFriendsServerSetFriendTagsRequest* request, XAsyncBlock* async);
    }
}
