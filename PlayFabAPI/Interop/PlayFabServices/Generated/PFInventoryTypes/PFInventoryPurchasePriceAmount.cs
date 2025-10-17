namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryPurchasePriceAmount
    {
        [NativeTypeName("int32_t")]
        public int amount;

        [NativeTypeName("const char *")]
        public sbyte* itemId;

        [NativeTypeName("const char *")]
        public sbyte* stackId;
    }
}
