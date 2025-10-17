namespace PlayFab.Interop
{
    public unsafe partial struct PFLocationModel
    {
        [NativeTypeName("const char *")]
        public sbyte* city;

        [NativeTypeName("const PFContinentCode *")]
        public PFContinentCode* continentCode;

        [NativeTypeName("const PFCountryCode *")]
        public PFCountryCode* countryCode;

        [NativeTypeName("const double *")]
        public double* latitude;

        [NativeTypeName("const double *")]
        public double* longitude;
    }
}
