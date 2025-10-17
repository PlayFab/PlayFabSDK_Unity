namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesEntityPermissionStatement
    {
        [NativeTypeName("const char *")]
        public sbyte* action;

        [NativeTypeName("const char *")]
        public sbyte* comment;

        public PFJsonObject condition;

        public PFProfilesEffectType effect;

        public PFJsonObject principal;

        [NativeTypeName("const char *")]
        public sbyte* resource;
    }
}
