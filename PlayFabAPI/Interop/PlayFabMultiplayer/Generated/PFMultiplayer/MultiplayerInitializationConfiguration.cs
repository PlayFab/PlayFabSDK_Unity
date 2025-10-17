using PlayFab.Interop;
using System;

namespace PlayFab.Interop.Multiplayer
{
    public unsafe partial struct MultiplayerInitializationConfiguration
    {
        [NativeTypeName("const char *")]
        public sbyte* titleId;

        [NativeTypeName("XTaskQueueHandle")]
        public IntPtr multiplayerTaskQueue;
    }
}
