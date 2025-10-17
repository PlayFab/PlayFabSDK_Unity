namespace PlayFab.Interop
{
    public unsafe partial struct PFCharacterResult
    {
        [NativeTypeName("const char *")]
        public sbyte* characterId;

        [NativeTypeName("const char *")]
        public sbyte* characterName;

        [NativeTypeName("const char *")]
        public sbyte* characterType;
    }
}
