namespace PlayFab.Interop
{
    public unsafe partial struct PFUserGameCenterInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* gameCenterId;
    }
}
