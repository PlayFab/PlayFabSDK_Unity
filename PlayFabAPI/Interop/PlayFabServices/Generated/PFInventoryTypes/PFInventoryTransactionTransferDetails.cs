namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryTransactionTransferDetails
    {
        [NativeTypeName("const char *")]
        public sbyte* givingCollectionId;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* givingEntity;

        [NativeTypeName("const char *")]
        public sbyte* receivingCollectionId;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* receivingEntity;

        [NativeTypeName("const char *")]
        public sbyte* transferId;
    }
}
