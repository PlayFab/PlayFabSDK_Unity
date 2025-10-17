using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetUiCallbacks(PFGameSaveUICallbacks* callbacks);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesUiProgressGetProgress([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesSyncState* syncState, [NativeTypeName("uint64_t *")] ulong* current, [NativeTypeName("uint64_t *")] ulong* total);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetUiProgressResponse([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesUiProgressUserAction action);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetUiSyncFailedResponse([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesUiSyncFailedUserAction action);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetUiActiveDeviceContentionResponse([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesUiActiveDeviceContentionUserAction action);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetUiConflictResponse([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesUiConflictUserAction action);

        [DllImport(PlayFabGameSaveLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGameSaveFilesSetUiOutOfStorageResponse([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesUiOutOfStorageUserAction action);
    }
}
