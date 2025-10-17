using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListBuildAliasesAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFMultiplayerServerListBuildAliasesRequest *")] PFMultiplayerServerListBuildAliasesRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListBuildAliasesGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListBuildAliasesGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFMultiplayerServerListBuildAliasesResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListBuildSummariesV2Async([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFMultiplayerServerListBuildSummariesRequest *")] PFMultiplayerServerListBuildSummariesRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListBuildSummariesV2GetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListBuildSummariesV2GetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFMultiplayerServerListBuildSummariesResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListQosServersForTitleAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFMultiplayerServerListQosServersForTitleRequest *")] PFMultiplayerServerListQosServersForTitleRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListQosServersForTitleGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerListQosServersForTitleGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFMultiplayerServerListQosServersForTitleResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerRequestMultiplayerServerAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFMultiplayerServerRequestMultiplayerServerRequest *")] PFMultiplayerServerRequestMultiplayerServerRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerRequestMultiplayerServerGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFMultiplayerServerRequestMultiplayerServerGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFMultiplayerServerRequestMultiplayerServerResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);
    }
}
