namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerSchedule
    {
        [NativeTypeName("const char *")]
        public sbyte* description;

        [NativeTypeName("time_t")]
        public long endTime;

        public byte isDisabled;

        public byte isRecurringWeekly;

        [NativeTypeName("time_t")]
        public long startTime;

        [NativeTypeName("int32_t")]
        public int targetStandby;
    }
}
