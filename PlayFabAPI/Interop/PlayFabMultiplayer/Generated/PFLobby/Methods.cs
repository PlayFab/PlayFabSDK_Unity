using PlayFab.Interop;
using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop.Multiplayer
{
    public static unsafe partial class Methods
    {
        [NativeTypeName("const uint32_t")]
        public const uint PFLobbyMaxMemberCountLowerLimit = 2;

        [NativeTypeName("const uint32_t")]
        public const uint PFLobbyMaxMemberCountUpperLimit = 128;

        [NativeTypeName("const uint32_t")]
        public const uint PFLobbyMaxSearchPropertyCount = 30;

        [NativeTypeName("const uint32_t")]
        public const uint PFLobbyMaxLobbyPropertyCount = 30;

        [NativeTypeName("const uint32_t")]
        public const uint PFLobbyMaxMemberPropertyCount = 30;

        [NativeTypeName("const uint32_t")]
        public const uint PFLobbyMaxServerPropertyCount = 30;

        [NativeTypeName("const uint32_t")]
        public const uint PFLobbyClientRequestedSearchResultCountUpperLimit = 50;

        [NativeTypeName("const char [18]")]
        public static ReadOnlySpan<byte> PFLobbyMemberCountSearchKey => new byte[] { 0x6C, 0x6F, 0x62, 0x62, 0x79, 0x2F, 0x6D, 0x65, 0x6D, 0x62, 0x65, 0x72, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x00 };

        [NativeTypeName("const char [27]")]
        public static ReadOnlySpan<byte> PFLobbyMemberCountRemainingSearchKey => new byte[] { 0x6C, 0x6F, 0x62, 0x62, 0x79, 0x2F, 0x6D, 0x65, 0x6D, 0x62, 0x65, 0x72, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x52, 0x65, 0x6D, 0x61, 0x69, 0x6E, 0x69, 0x6E, 0x67, 0x00 };

        [NativeTypeName("const char [15]")]
        public static ReadOnlySpan<byte> PFLobbyAmMemberSearchKey => new byte[] { 0x6C, 0x6F, 0x62, 0x62, 0x79, 0x2F, 0x61, 0x6D, 0x4D, 0x65, 0x6D, 0x62, 0x65, 0x72, 0x00 };

        [NativeTypeName("const char [14]")]
        public static ReadOnlySpan<byte> PFLobbyAmOwnerSearchKey => new byte[] { 0x6C, 0x6F, 0x62, 0x62, 0x79, 0x2F, 0x61, 0x6D, 0x4F, 0x77, 0x6E, 0x65, 0x72, 0x00 };

        [NativeTypeName("const char [21]")]
        public static ReadOnlySpan<byte> PFLobbyMembershipLockSearchKey => new byte[] { 0x6C, 0x6F, 0x62, 0x62, 0x79, 0x2F, 0x6D, 0x65, 0x6D, 0x62, 0x65, 0x72, 0x73, 0x68, 0x69, 0x70, 0x4C, 0x6F, 0x63, 0x6B, 0x00 };

        [NativeTypeName("const char [15]")]
        public static ReadOnlySpan<byte> PFLobbyAmServerSearchKey => new byte[] { 0x6C, 0x6F, 0x62, 0x62, 0x79, 0x2F, 0x61, 0x6D, 0x53, 0x65, 0x72, 0x76, 0x65, 0x72, 0x00 };

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetLobbyId([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const char **")] sbyte** id);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetMaxMemberCount([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("uint32_t *")] uint* maxMemberCount);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetOwner([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const PFEntityKey **")] PFEntityKey** owner);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetOwnerMigrationPolicy([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, PFLobbyOwnerMigrationPolicy* ownerMigrationPolicy);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetAccessPolicy([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, PFLobbyAccessPolicy* accessPolicy);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetMembershipLock([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, PFLobbyMembershipLock* lockState);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetConnectionString([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const char **")] sbyte** connectionString);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetMembers([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("uint32_t *")] uint* memberCount, [NativeTypeName("const PFEntityKey **")] PFEntityKey** members);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyAddMemberWithEntityHandle([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("PFEntityHandle")] IntPtr localUser, [NativeTypeName("uint32_t")] uint memberPropertyCount, [NativeTypeName("const char *const *")] sbyte** memberPropertyKeys, [NativeTypeName("const char *const *")] sbyte** memberPropertyValues, void* asyncContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyForceRemoveMember([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const PFEntityKey *")] PFEntityKey* targetMember, byte preventRejoin, void* asyncContext);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyLeaveWithEntityHandle([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("PFEntityHandle")] IntPtr localUser, void* asyncContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetSearchPropertyKeys([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("uint32_t *")] uint* propertyCount, [NativeTypeName("const char *const **")] sbyte*** keys);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetSearchProperty([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char **")] sbyte** value);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetLobbyPropertyKeys([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("uint32_t *")] uint* propertyCount, [NativeTypeName("const char *const **")] sbyte*** keys);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetLobbyProperty([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char **")] sbyte** value);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetMemberPropertyKeys([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const PFEntityKey *")] PFEntityKey* member, [NativeTypeName("uint32_t *")] uint* propertyCount, [NativeTypeName("const char *const **")] sbyte*** keys);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetMemberProperty([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const PFEntityKey *")] PFEntityKey* member, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char **")] sbyte** value);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetMemberConnectionStatus([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const PFEntityKey *")] PFEntityKey* member, PFLobbyMemberConnectionStatus* connectionStatus);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetServer([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const PFEntityKey **")] PFEntityKey** server);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetServerPropertyKeys([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("uint32_t *")] uint* propertyCount, [NativeTypeName("const char *const **")] sbyte*** keys);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetServerProperty([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char **")] sbyte** value);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetServerConnectionStatus([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, PFLobbyServerConnectionStatus* connectionStatus);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyPostUpdateWithEntityHandle([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("PFEntityHandle")] IntPtr localUser, [NativeTypeName("const PFLobbyDataUpdate *")] PFLobbyDataUpdate* lobbyUpdate, [NativeTypeName("const PFLobbyMemberDataUpdate *")] PFLobbyMemberDataUpdate* memberUpdate, void* asyncContext);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbySendInviteWithEntityHandle([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("PFEntityHandle")] IntPtr sender, [NativeTypeName("const PFEntityKey *")] PFEntityKey* invitee, void* asyncContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyGetCustomContext([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, void** customContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbySetCustomContext([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, void* customContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerStartProcessingLobbyStateChanges([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("uint32_t *")] uint* stateChangeCount, [NativeTypeName("const PFLobbyStateChange *const **")] PFLobbyStateChange*** stateChanges);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerFinishProcessingLobbyStateChanges([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("uint32_t")] uint stateChangeCount, [NativeTypeName("const PFLobbyStateChange *const *")] PFLobbyStateChange** stateChanges);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerCreateAndJoinLobbyWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr creator, [NativeTypeName("const PFLobbyCreateConfiguration *")] PFLobbyCreateConfiguration* createConfiguration, [NativeTypeName("const PFLobbyJoinConfiguration *")] PFLobbyJoinConfiguration* joinConfiguration, void* asyncContext, [NativeTypeName("PFLobbyHandle *")] PFLobby** lobby);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerConnectToLobby([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("const PFEntityKey *")] PFEntityKey* newMember, [NativeTypeName("const char *")] sbyte* lobbyId, void* asyncContext, [NativeTypeName("PFLobbyHandle *")] PFLobby** lobby);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerJoinLobbyWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr newMember, [NativeTypeName("const char *")] sbyte* connectionString, [NativeTypeName("const PFLobbyJoinConfiguration *")] PFLobbyJoinConfiguration* configuration, void* asyncContext, [NativeTypeName("PFLobbyHandle *")] PFLobby** lobby);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerJoinArrangedLobbyWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr newMember, [NativeTypeName("const char *")] sbyte* arrangementString, [NativeTypeName("const PFLobbyArrangedJoinConfiguration *")] PFLobbyArrangedJoinConfiguration* configuration, void* asyncContext, [NativeTypeName("PFLobbyHandle *")] PFLobby** lobby);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerFindLobbiesWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr searchingEntity, [NativeTypeName("const PFLobbySearchConfiguration *")] PFLobbySearchConfiguration* searchConfiguration, void* asyncContext);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerStartListeningForLobbyInvitesWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr listeningEntity);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerStopListeningForLobbyInvitesWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr listeningEntity);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerGetLobbyInviteListenerStatus([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("const PFEntityKey *")] PFEntityKey* listeningEntity, PFLobbyInviteListenerStatus* status);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerCreateAndClaimServerLobbyWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr server, [NativeTypeName("const PFLobbyCreateConfiguration *")] PFLobbyCreateConfiguration* createConfiguration, void* asyncContext, [NativeTypeName("PFLobbyHandle *")] PFLobby** lobby);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerClaimServerLobbyWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr server, [NativeTypeName("const char *")] sbyte* lobbyId, void* asyncContext, [NativeTypeName("PFLobbyHandle *")] PFLobby** lobby);


        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFMultiplayerJoinLobbyAsServerWithEntityHandle([NativeTypeName("PFMultiplayerHandle")] PFMultiplayer* handle, [NativeTypeName("PFEntityHandle")] IntPtr server, [NativeTypeName("const char *")] sbyte* connectionString, [NativeTypeName("const PFLobbyServerJoinConfiguration *")] PFLobbyServerJoinConfiguration* configuration, void* asyncContext, [NativeTypeName("PFLobbyHandle *")] PFLobby** lobby);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyServerPostUpdate([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const PFLobbyDataUpdate *")] PFLobbyDataUpdate* lobbyUpdate, void* asyncContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyServerPostUpdateAsServer([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, [NativeTypeName("const PFLobbyServerDataUpdate *")] PFLobbyServerDataUpdate* serverUpdate, void* asyncContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyServerLeaveAsServer([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, void* asyncContext);

        [DllImport(PlayFabMultiplayerLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PFLobbyServerDeleteLobby([NativeTypeName("PFLobbyHandle")] PFLobby* lobby, void* asyncContext);
    }
}
