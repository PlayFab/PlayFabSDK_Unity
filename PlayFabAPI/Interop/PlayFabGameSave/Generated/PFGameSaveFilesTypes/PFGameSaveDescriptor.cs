namespace PlayFab.Interop
{
    public unsafe partial struct PFGameSaveDescriptor
    {
        [NativeTypeName("time_t")]
        public long time;

        [NativeTypeName("uint64_t")]
        public ulong totalBytes;

        [NativeTypeName("uint64_t")]
        public ulong uploadedBytes;

        [NativeTypeName("char [256]")]
        public fixed sbyte deviceType[256];

        [NativeTypeName("char [256]")]
        public fixed sbyte deviceId[256];

        [NativeTypeName("char [256]")]
        public fixed sbyte deviceFriendlyName[256];

        [NativeTypeName("char [2048]")]
        public fixed sbyte thumbnailUri[2048];

        [NativeTypeName("char [4096]")]
        public fixed sbyte shortSaveDescription[4096];
    }
}
