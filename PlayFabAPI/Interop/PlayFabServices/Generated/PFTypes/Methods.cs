namespace PlayFab.Interop
{
    public static partial class Methods
    {
        [NativeTypeName("#define E_PF_SERVICES_NOT_INITIALIZED MAKE_E_HC(0x5A00L)")]
        public const int E_PF_SERVICES_NOT_INITIALIZED = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x5A00))));

        [NativeTypeName("#define E_PF_SERVICES_ALREADY_INITIALIZED MAKE_E_HC(0x5A01L)")]
        public const int E_PF_SERVICES_ALREADY_INITIALIZED = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x5A01))));
    }
}
