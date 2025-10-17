using PlayFab.Interop;
using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop.Multiplayer
{
    public static unsafe partial class Methods
    {
        [NativeTypeName("const uint64_t")]
        public const ulong PFMultiplayerAnyProcessor = 0xffffffffffffffff;

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PFMultiplayerGetErrorMessage(int error);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerSetMemoryCallbacks([NativeTypeName("PFMultiplayerAllocateMemoryCallback")] IntPtr allocateMemoryCallback, [NativeTypeName("PFMultiplayerFreeMemoryCallback")] IntPtr freeMemoryCallback);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerSetThreadAffinityMask(PFMultiplayerThreadId threadId, [NativeTypeName("uint64_t")] ulong threadAffinityMask);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerInitialize([NativeTypeName("const MultiplayerInitializationConfiguration *")] MultiplayerInitializationConfiguration* initializationConfiguration, [NativeTypeName("PFMultiplayerHandle *")] PFMultiplayer** handle);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerUninitialize([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle);

    }
}
