using System;

namespace PlayFab.Interop
{
    public unsafe partial struct PFGameSaveUICallbacks
    {
        [NativeTypeName("PFGameSaveFilesUiProgressCallback *")]
        public IntPtr progressCallback;

        public void* progressContext;

        [NativeTypeName("PFGameSaveFilesUiSyncFailedCallback *")]
        public IntPtr syncFailedCallback;

        public void* syncFailedContext;

        [NativeTypeName("PFGameSaveFilesUiActiveDeviceContentionCallback *")]
        public IntPtr activeDeviceContentionCallback;

        public void* activeDeviceContentionContext;

        [NativeTypeName("PFGameSaveFilesUiConflictCallback *")]
        public IntPtr conflictCallback;

        public void* conflictContext;

        [NativeTypeName("PFGameSaveFilesUiOutOfStorageCallback *")]
        public IntPtr outOfStorageCallback;

        public void* outOfStorageContext;
    }
}
