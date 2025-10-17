using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    public unsafe partial struct PFMatchmakingMatchMember
    {
        public PFEntityKey entityKey;

        [NativeTypeName("const char *")]
        public sbyte* teamId;

        [NativeTypeName("const char *")]
        public sbyte* attributes;
    }
}
