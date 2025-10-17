namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerPartyInvitationConfiguration
    {
        [NativeTypeName("const PFEntityKey *const *")]
        public PFEntityKey** entityKeys;

        [NativeTypeName("uint32_t")]
        public uint entityKeysCount;

        [NativeTypeName("const char *")]
        public sbyte* identifier;

        [NativeTypeName("const char *")]
        public sbyte* revocability;
    }
}
