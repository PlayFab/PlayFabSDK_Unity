namespace PlayFab.Interop
{
    public unsafe partial struct PFUserKongregateInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* kongregateId;

        [NativeTypeName("const char *")]
        public sbyte* kongregateName;
    }
}
