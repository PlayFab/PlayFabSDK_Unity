namespace PlayFab.Interop
{
    public unsafe partial struct PFTreatmentAssignment
    {
        [NativeTypeName("const PFVariable *const *")]
        public PFVariable** variables;

        [NativeTypeName("uint32_t")]
        public uint variablesCount;

        [NativeTypeName("const char *const *")]
        public sbyte** variants;

        [NativeTypeName("uint32_t")]
        public uint variantsCount;
    }
}
