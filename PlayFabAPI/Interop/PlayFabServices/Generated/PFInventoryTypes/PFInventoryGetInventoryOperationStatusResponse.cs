namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryGetInventoryOperationStatusResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* operationStatus;
    }
}
