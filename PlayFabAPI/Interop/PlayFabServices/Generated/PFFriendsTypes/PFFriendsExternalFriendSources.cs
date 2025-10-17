namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFFriendsExternalFriendSources : uint
    {
        None = 0x0,
        Steam = 0x1,
        Facebook = 0x2,
        Xbox = 0x4,
        Psn = 0x8,
        All = 0x10,
    }
}
