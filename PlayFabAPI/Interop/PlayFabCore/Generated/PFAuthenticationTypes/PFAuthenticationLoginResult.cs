namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationLoginResult
    {
        [NativeTypeName("const PFGetPlayerCombinedInfoResultPayload *")]
        public PFGetPlayerCombinedInfoResultPayload* infoResultPayload;

        [NativeTypeName("const time_t *")]
        public long* lastLoginTime;

        public byte newlyCreated;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const PFAuthenticationUserSettings *")]
        public PFAuthenticationUserSettings* settingsForUser;

        [NativeTypeName("const PFTreatmentAssignment *")]
        public PFTreatmentAssignment* treatmentAssignment;
    }
}
