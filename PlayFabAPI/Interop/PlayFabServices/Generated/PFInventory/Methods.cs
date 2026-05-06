using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryAddInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryAddInventoryItemsRequest *")] PFInventoryAddInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryAddInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryAddInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryAddInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryDeleteInventoryCollectionAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryDeleteInventoryCollectionRequest *")] PFInventoryDeleteInventoryCollectionRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryDeleteInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryDeleteInventoryItemsRequest *")] PFInventoryDeleteInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryDeleteInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryDeleteInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryDeleteInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryExecuteInventoryOperationsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryExecuteInventoryOperationsRequest *")] PFInventoryExecuteInventoryOperationsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryExecuteInventoryOperationsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryExecuteInventoryOperationsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryExecuteInventoryOperationsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryExecuteTransferOperationsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryExecuteTransferOperationsRequest *")] PFInventoryExecuteTransferOperationsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryExecuteTransferOperationsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryExecuteTransferOperationsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryExecuteTransferOperationsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryCollectionIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryGetInventoryCollectionIdsRequest *")] PFInventoryGetInventoryCollectionIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryCollectionIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryCollectionIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryGetInventoryCollectionIdsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryGetInventoryItemsRequest *")] PFInventoryGetInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryGetInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryOperationStatusAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryGetInventoryOperationStatusRequest *")] PFInventoryGetInventoryOperationStatusRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryOperationStatusGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetInventoryOperationStatusGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryGetInventoryOperationStatusResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetTransactionHistoryAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryGetTransactionHistoryRequest *")] PFInventoryGetTransactionHistoryRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetTransactionHistoryGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryGetTransactionHistoryGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryGetTransactionHistoryResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryPurchaseInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryPurchaseInventoryItemsRequest *")] PFInventoryPurchaseInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryPurchaseInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryPurchaseInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryPurchaseInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemAppleAppStoreInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryRedeemAppleAppStoreInventoryItemsRequest *")] PFInventoryRedeemAppleAppStoreInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemAppleAppStoreInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemAppleAppStoreInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryRedeemAppleAppStoreInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemGooglePlayInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryRedeemGooglePlayInventoryItemsRequest *")] PFInventoryRedeemGooglePlayInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemGooglePlayInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemGooglePlayInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryRedeemGooglePlayInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemMicrosoftStoreInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryRedeemMicrosoftStoreInventoryItemsRequest *")] PFInventoryRedeemMicrosoftStoreInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemMicrosoftStoreInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemMicrosoftStoreInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryRedeemMicrosoftStoreInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemNintendoEShopInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryRedeemNintendoEShopInventoryItemsRequest *")] PFInventoryRedeemNintendoEShopInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemNintendoEShopInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemNintendoEShopInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryRedeemNintendoEShopInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemPlayStationStoreInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryRedeemPlayStationStoreInventoryItemsRequest *")] PFInventoryRedeemPlayStationStoreInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemPlayStationStoreInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemPlayStationStoreInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryRedeemPlayStationStoreInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemSteamInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryRedeemSteamInventoryItemsRequest *")] PFInventoryRedeemSteamInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemSteamInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryRedeemSteamInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryRedeemSteamInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventorySubtractInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventorySubtractInventoryItemsRequest *")] PFInventorySubtractInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventorySubtractInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventorySubtractInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventorySubtractInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryTransferInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryTransferInventoryItemsRequest *")] PFInventoryTransferInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryTransferInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryTransferInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryTransferInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryUpdateInventoryItemsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFInventoryUpdateInventoryItemsRequest *")] PFInventoryUpdateInventoryItemsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryUpdateInventoryItemsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInventoryUpdateInventoryItemsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFInventoryUpdateInventoryItemsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);
    }
}
