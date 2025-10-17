using System;

namespace PlayFab.Interop
{
    public unsafe partial struct PFFriendsClientGetFriendsListRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFFriendsExternalFriendSources *")]
        public PFFriendsExternalFriendSources* externalPlatformFriends;

        [NativeTypeName("const PFPlayerProfileViewConstraints *")]
        public PFPlayerProfileViewConstraints* profileConstraints;

#if MICROSOFT_GDK_SUPPORT
        [NativeTypeName("XUserHandle")]
        public IntPtr user;
#endif

#if !MICROSOFT_GDK_SUPPORT
        [NativeTypeName("const char *")]
        public sbyte* xboxToken;
#endif
    }
}
