using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptClientExecuteCloudScriptAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFCloudScriptExecuteCloudScriptRequest *")] PFCloudScriptExecuteCloudScriptRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptClientExecuteCloudScriptGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptClientExecuteCloudScriptGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFCloudScriptExecuteCloudScriptResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptServerExecuteCloudScriptAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFCloudScriptExecuteCloudScriptServerRequest *")] PFCloudScriptExecuteCloudScriptServerRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptServerExecuteCloudScriptGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptServerExecuteCloudScriptGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFCloudScriptExecuteCloudScriptResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptExecuteEntityCloudScriptAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFCloudScriptExecuteEntityCloudScriptRequest *")] PFCloudScriptExecuteEntityCloudScriptRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptExecuteEntityCloudScriptGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptExecuteEntityCloudScriptGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFCloudScriptExecuteCloudScriptResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptExecuteFunctionAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFCloudScriptExecuteFunctionRequest *")] PFCloudScriptExecuteFunctionRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptExecuteFunctionGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFCloudScriptExecuteFunctionGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFCloudScriptExecuteFunctionResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);
    }
}
