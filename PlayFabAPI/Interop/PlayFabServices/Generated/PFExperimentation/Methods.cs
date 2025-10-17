using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFExperimentationGetTreatmentAssignmentAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFExperimentationGetTreatmentAssignmentRequest *")] PFExperimentationGetTreatmentAssignmentRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFExperimentationGetTreatmentAssignmentGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFExperimentationGetTreatmentAssignmentGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFExperimentationGetTreatmentAssignmentResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);
    }
}
