namespace PlayFab.Interop
{
    public unsafe partial struct PFUserSteamInfo
    {
        [NativeTypeName("const PFTitleActivationStatus *")]
        public PFTitleActivationStatus* steamActivationStatus;

        [NativeTypeName("const char *")]
        public sbyte* steamCountry;

        [NativeTypeName("const PFCurrency *")]
        public PFCurrency* steamCurrency;

        [NativeTypeName("const char *")]
        public sbyte* steamId;

        [NativeTypeName("const char *")]
        public sbyte* steamName;
    }
}
