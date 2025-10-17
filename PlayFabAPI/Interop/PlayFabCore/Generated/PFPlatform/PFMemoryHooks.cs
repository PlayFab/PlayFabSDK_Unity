using System;

namespace PlayFab.Interop
{
    public unsafe partial struct PFMemoryHooks
    {
        [NativeTypeName("PFMemAllocFunction *")]
        public IntPtr* alloc;

        [NativeTypeName("PFMemFreeFunction *")]
        public IntPtr* free;
    }
}
