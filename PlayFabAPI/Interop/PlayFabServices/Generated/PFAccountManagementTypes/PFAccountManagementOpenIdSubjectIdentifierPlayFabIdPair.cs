namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementOpenIdSubjectIdentifierPlayFabIdPair
    {
        [NativeTypeName("const PFAccountManagementOpenIdSubjectIdentifier *")]
        public PFAccountManagementOpenIdSubjectIdentifier* openIdSubjectIdentifier;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
