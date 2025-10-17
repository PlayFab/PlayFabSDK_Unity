using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesInitialize(PFGameSaveInitArgs* args);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesAddUserWithUiAsync([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesAddUserOptions options, XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesAddUserWithUiResult(XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesGetFolderSize([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("size_t *")] ulong* saveRootFolderSize);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesGetFolder([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("size_t")] ulong saveRootFolderSize, [NativeTypeName("char *")] sbyte* saveRootFolderBuffer, [NativeTypeName("size_t *")] ulong* saveRootFolderUsed);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesUploadWithUiAsync([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesUploadOption option, XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesUploadWithUiResult(XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesGetRemainingQuota([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("int64_t *")] long* remainingQuota);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesIsConnectedToCloud([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("bool *")] byte* isConnectedToCloud);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetActiveDeviceChangedCallback([NativeTypeName("XTaskQueueHandle")] IntPtr callbackQueue, PFGameSaveFilesActiveDeviceChangedCallback callback, void* context);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetSaveDescriptionAsync([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("const char *")] sbyte* shortSaveDescription, XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetSaveDescriptionResult(XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesResetCloudAsync([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesResetCloudResult(XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesUninitializeAsync(XAsyncBlock* async);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesUninitializeResult(XAsyncBlock* async);
    }
}
