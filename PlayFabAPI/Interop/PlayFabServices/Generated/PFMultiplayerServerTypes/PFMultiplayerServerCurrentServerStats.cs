namespace PlayFab.Interop
{
    public partial struct PFMultiplayerServerCurrentServerStats
    {
        [NativeTypeName("int32_t")]
        public int active;

        [NativeTypeName("int32_t")]
        public int propping;

        [NativeTypeName("int32_t")]
        public int standingBy;

        [NativeTypeName("int32_t")]
        public int total;
    }
}
