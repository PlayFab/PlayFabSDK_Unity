namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticModel
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("int32_t")]
        public int value;

        [NativeTypeName("int32_t")]
        public int version;
    }
}
