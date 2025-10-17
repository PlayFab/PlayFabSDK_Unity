namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementKongregatePlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* kongregateId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
