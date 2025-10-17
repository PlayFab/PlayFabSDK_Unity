namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryTransactionClawbackDetails
    {
        [NativeTypeName("const char *")]
        public sbyte* transactionIdClawedback;
    }
}
