using PlayFab.Interop;
using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop.Multiplayer
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerStartProcessingMatchmakingStateChanges([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("uint32_t *")] uint* stateChangeCount, [NativeTypeName("const PFMatchmakingStateChange *const **")] PFMatchmakingStateChange*** stateChanges);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerFinishProcessingMatchmakingStateChanges([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("uint32_t")] uint stateChangeCount, [NativeTypeName("const PFMatchmakingStateChange *const *")] PFMatchmakingStateChange** stateChanges);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerCreateMatchmakingTicketWithEntityHandles([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("uint32_t")] uint localUserCount, [NativeTypeName("const PFEntityHandle *")] IntPtr* localUsers, [NativeTypeName("const char *const *")] sbyte** localUserAttributes, [NativeTypeName("const PFMatchmakingTicketConfiguration *")] PFMatchmakingTicketConfiguration* configuration, void* asyncContext, [NativeTypeName("PFMatchmakingTicketHandle *")] PFMatchmakingTicket** ticket);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerJoinMatchmakingTicketFromIdWithEntityHandles([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("uint32_t")] uint localUserCount, [NativeTypeName("const PFEntityHandle *")] IntPtr* localUsers, [NativeTypeName("const char *const *")] sbyte** localUserAttributes, [NativeTypeName("const char *")] sbyte* ticketId, [NativeTypeName("const char *")] sbyte* queueName, void* asyncContext, [NativeTypeName("PFMatchmakingTicketHandle *")] PFMatchmakingTicket** ticket);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerDestroyMatchmakingTicket([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFMatchmakingTicketHandle")] PFMatchmakingTicket* ticket);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMatchmakingTicketGetStatus([NativeTypeName("PFMatchmakingTicketHandle")] PFMatchmakingTicket* ticket, PFMatchmakingTicketStatus* status);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMatchmakingTicketCancel([NativeTypeName("PFMatchmakingTicketHandle")] PFMatchmakingTicket* ticket);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMatchmakingTicketGetTicketId([NativeTypeName("PFMatchmakingTicketHandle")] PFMatchmakingTicket* ticket, [NativeTypeName("const char **")] sbyte** id);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMatchmakingTicketGetMatch([NativeTypeName("PFMatchmakingTicketHandle")] PFMatchmakingTicket* ticket, [NativeTypeName("const PFMatchmakingMatchDetails **")] PFMatchmakingMatchDetails** match);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMatchmakingTicketGetCustomContext([NativeTypeName("PFMatchmakingTicketHandle")] PFMatchmakingTicket* ticket, void** customContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMatchmakingTicketSetCustomContext([NativeTypeName("PFMatchmakingTicketHandle")] PFMatchmakingTicket* ticket, void* customContext);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerCreateServerBackfillTicketWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr server, [NativeTypeName("const PFMatchmakingServerBackfillTicketConfiguration *")] PFMatchmakingServerBackfillTicketConfiguration* configuration, void* asyncContext, [NativeTypeName("PFMatchmakingTicketHandle *")] PFMatchmakingTicket** ticket);
    }
}
