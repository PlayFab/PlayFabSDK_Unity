using System;

namespace PlayFab.Interop
{
    public unsafe partial struct PFLocalStorageHooks
    {
        [NativeTypeName("XTaskQueueHandle")]
        public IntPtr queueHandle;

        [NativeTypeName("PFPlatformLocalStorageReadAsyncHandler *")]
        public IntPtr* read;

        [NativeTypeName("PFPlatformLocalStorageWriteAsyncHandler *")]
        public IntPtr* write;

        [NativeTypeName("PFPlatformLocalStorageClearAsyncHandler *")]
        public IntPtr* clear;

        public void* context;
    }
}
