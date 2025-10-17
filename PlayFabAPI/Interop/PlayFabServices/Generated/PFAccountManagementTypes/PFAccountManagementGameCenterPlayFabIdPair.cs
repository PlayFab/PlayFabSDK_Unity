namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGameCenterPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* gameCenterId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
