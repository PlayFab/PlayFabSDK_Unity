namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerScheduledStandbySettings
    {
        public byte isEnabled;

        [NativeTypeName("const PFMultiplayerServerSchedule *const *")]
        public PFMultiplayerServerSchedule** scheduleList;

        [NativeTypeName("uint32_t")]
        public uint scheduleListCount;
    }
}
