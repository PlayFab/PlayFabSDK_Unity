using System;

namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryRedeemMicrosoftStoreInventoryItemsRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* collectionId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

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
