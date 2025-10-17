namespace PlayFab.Interop
{
    public unsafe partial struct PFEntityLineage
    {
        [NativeTypeName("const char *")]
        public sbyte* characterId;

        [NativeTypeName("const char *")]
        public sbyte* groupId;

        [NativeTypeName("const char *")]
        public sbyte* masterPlayerAccountId;

        [NativeTypeName("const char *")]
        public sbyte* namespaceId;

        [NativeTypeName("const char *")]
        public sbyte* titleId;

        [NativeTypeName("const char *")]
        public sbyte* titlePlayerAccountId;
    }
}
