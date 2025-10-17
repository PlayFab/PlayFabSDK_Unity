namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsPlayerLocation
    {
        [NativeTypeName("const char *")]
        public sbyte* city;

        public PFContinentCode continentCode;

        public PFCountryCode countryCode;

        [NativeTypeName("const double *")]
        public double* latitude;

        [NativeTypeName("const double *")]
        public double* longitude;
    }
}
