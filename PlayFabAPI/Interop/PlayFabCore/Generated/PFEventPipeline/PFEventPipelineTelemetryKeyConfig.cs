using System;

namespace PlayFab.Interop
{
    public unsafe partial struct PFEventPipelineTelemetryKeyConfig
    {
        [NativeTypeName("const char *")]
        public sbyte* telemetryKey;

        [NativeTypeName("PFServiceConfigHandle")]
        public IntPtr serviceConfigHandle;
    }
}
