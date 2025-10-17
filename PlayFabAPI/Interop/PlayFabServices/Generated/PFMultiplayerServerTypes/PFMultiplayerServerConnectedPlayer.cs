namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerConnectedPlayer
    {
        [NativeTypeName("const char *")]
        public sbyte* playerId;
    }
}
