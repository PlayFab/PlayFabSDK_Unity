namespace PlayFab.Interop
{
    public unsafe partial struct PFDateTimeDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("time_t")]
        public long value;
    }
}
