namespace PlayFab.Interop
{
    public unsafe partial struct PFVirtualCurrencyRechargeTimeDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFVirtualCurrencyRechargeTime *")]
        public PFVirtualCurrencyRechargeTime* value;
    }
}
