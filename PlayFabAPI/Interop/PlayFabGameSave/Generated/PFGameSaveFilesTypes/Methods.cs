namespace PlayFab.Interop
{
    public static partial class Methods
    {
        [NativeTypeName("#define E_PF_GAMESAVE_USER_CANCELLED 0x800704c7")]
        public const uint E_PF_GAMESAVE_USER_CANCELLED = 0x800704c7;

        [NativeTypeName("#define E_PF_GAMESAVE_NOT_INITIALIZED MAKE_E_HC(0x7000L)")]
        public const int E_PF_GAMESAVE_NOT_INITIALIZED = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7000))));

        [NativeTypeName("#define E_PF_GAMESAVE_ALREADY_INITIALIZED MAKE_E_HC(0x7001L)")]
        public const int E_PF_GAMESAVE_ALREADY_INITIALIZED = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7001))));

        [NativeTypeName("#define E_PF_GAMESAVE_USER_ALREADY_ADDED MAKE_E_HC(0x7002L)")]
        public const int E_PF_GAMESAVE_USER_ALREADY_ADDED = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7002))));

        [NativeTypeName("#define E_PF_GAMESAVE_USER_NOT_ADDED MAKE_E_HC(0x7003L)")]
        public const int E_PF_GAMESAVE_USER_NOT_ADDED = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7003))));

        [NativeTypeName("#define E_PF_GAMESAVE_DISCONNECTED_FROM_CLOUD MAKE_E_HC(0x7004L)")]
        public const int E_PF_GAMESAVE_DISCONNECTED_FROM_CLOUD = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7004))));

        [NativeTypeName("#define E_PF_GAMESAVE_NETWORK_FAILURE MAKE_E_HC(0x7005L)")]
        public const int E_PF_GAMESAVE_NETWORK_FAILURE = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7005))));

        [NativeTypeName("#define E_PF_GAMESAVE_DOWNLOAD_IN_PROGRESS MAKE_E_HC(0x7006L)")]
        public const int E_PF_GAMESAVE_DOWNLOAD_IN_PROGRESS = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7006))));

        [NativeTypeName("#define E_PF_GAMESAVE_DEVICE_NO_LONGER_ACTIVE MAKE_E_HC(0x7007L)")]
        public const int E_PF_GAMESAVE_DEVICE_NO_LONGER_ACTIVE = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7007))));

        [NativeTypeName("#define E_PF_GAMESAVE_DISK_FULL MAKE_E_HC(0x7008L)")]
        public const int E_PF_GAMESAVE_DISK_FULL = unchecked((int)(((uint)(1) << 31) | ((uint)(2339) << 16) | ((uint)(0x7008))));
    }
}
