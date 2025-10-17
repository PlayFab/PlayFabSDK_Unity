namespace PlayFab.Interop
{
    public partial struct PFVirtualCurrencyRechargeTime
    {
        [NativeTypeName("int32_t")]
        public int rechargeMax;

        [NativeTypeName("time_t")]
        public long rechargeTime;

        [NativeTypeName("int32_t")]
        public int secondsToRecharge;
    }
}
