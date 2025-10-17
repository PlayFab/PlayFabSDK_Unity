namespace PlayFab.Interop
{
    public unsafe partial struct PFCharacterInventory
    {
        [NativeTypeName("const char *")]
        public sbyte* characterId;

        [NativeTypeName("const PFItemInstance *const *")]
        public PFItemInstance** inventory;

        [NativeTypeName("uint32_t")]
        public uint inventoryCount;
    }
}
