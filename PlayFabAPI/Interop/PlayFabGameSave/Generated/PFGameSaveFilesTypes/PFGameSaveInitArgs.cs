using System;

namespace PlayFab.Interop
{
    public unsafe partial struct PFGameSaveInitArgs
    {
        [NativeTypeName("XTaskQueueHandle")]
        public IntPtr backgroundQueue;

        [NativeTypeName("uint64_t")]
        public ulong options;

#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX
        [NativeTypeName("const char *")]
        public sbyte* saveFolder;
#endif
    }
}
