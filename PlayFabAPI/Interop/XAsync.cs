using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public enum XAsyncOp : uint
    {
        /// <summary>
        /// An async provider is invoked with this opcode during XAsyncBegin or XAsyncBeginAlloc.
        /// If the provider implements this op code, they should start their asynchronous task,
        /// either by calling XAsyncSchedule or through exterior means.  This callback is
        /// called synchronously in the XAsyncBegin call chain, so it should never block.
        /// </summary>
        Begin,

        /// <summary>
        /// An async provider is invoked with this opcode when XAsyncSchedule has been called to
        /// schedule work. Implementations should perform their asynchronous work and then call
        /// XAsyncComplete with the data payload size. If additional work needs to be done they
        /// can schedule it and return E_PENDING.
        /// </summary>
        DoWork,

        /// <summary>
        /// An async provider is invoked with this opcode after an async call completes and the
        /// user needs to get the resulting data payload. The buffer and bufferSize have
        /// been arg checked.
        /// </summary>
        GetResult,

        /// <summary>
        /// An async provider is invoked with this opcode when the async work should be canceled. If
        /// you can cancel your work you should call XAsyncComplete with an error code of E_ABORT when
        /// the work has been canceled.
        /// </summary>
        Cancel,

        /// <summary>
        /// An async provider is invoked with this opcode when the async call is over and
        /// data in the context can be cleaned up.
        /// </summary>
        Cleanup
    }

    /// <summary>
    /// A data block passed to an async provider callback.  Fields in this structure are filled
    /// in as the call progresses.
    /// </summary>
    public unsafe struct XAsyncProviderData
    {
        /// <summary>
        /// The async block for the call.
        /// </summary>
        public XAsyncBlock* async;

        /// <summary>
        /// Valid during a GetResult opcode and holds the size of the buffer.  This will
        /// be at least as large as the data size provided to XAsyncComplete.
        /// </summary>
        public ulong bufferSize;

        /// <summary>
        /// Valid during a GetResult opcode and holds the output data buffer.
        /// </summary>
        public void* buffer;

        /// <summary>
        /// Valid during any opcode this is a user provided context pointer that was provided
        /// to XAsyncBegin.  It should be freed during the Cleanup opcode.
        /// </summary>
        public void* context;
    };

    /// <summary>
    /// A callback function that implements the async call. This function will be invoked
    /// multiple times with different XAsyncOp operation codes to indicate what work it
    /// should perform.
    /// </summary>
    /// <param name='op'>The async operatiopn to perform.</param>
    /// <param name='data'>Data used to track the async call.</param>
    /// <seealso cref='XAsyncProviderData' />
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int XAsyncProvider(XAsyncOp op, XAsyncProviderData* data);

    public static unsafe partial class Methods
    {
        //STDAPI XTaskQueueCreate(
        //    _In_ XTaskQueueDispatchMode workDispatchMode,
        //    _In_ XTaskQueueDispatchMode completionDispatchMode,
        //    _Out_ XTaskQueueHandle* queue
        //    ) noexcept;
        [DllImport(XGameRuntimeLibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int XTaskQueueCreate(
            XTaskQueueDispatchMode workDispatchMode,
            XTaskQueueDispatchMode completionDispatchMode,
            out XTaskQueueHandle queue
        );

        //STDAPI_(void) XTaskQueueCloseHandle(
        //    _In_ XTaskQueueHandle queue
        //    ) noexcept;
        [DllImport(XGameRuntimeLibName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XTaskQueueCloseHandle(XTaskQueueHandle queue);

        //STDAPI_(bool) XTaskQueueDispatch(
        //    _In_ XTaskQueueHandle queue,
        //    _In_ XTaskQueuePort port,
        //    _In_ uint32_t timeoutInMs
        //    ) noexcept;
        [DllImport(XGameRuntimeLibName, CallingConvention = CallingConvention.StdCall)]
        public static extern byte XTaskQueueDispatch(XTaskQueueHandle queue, XTaskQueuePort port, uint timeoutInMs);

        //STDAPI XAsyncBegin(
        //    _Inout_ XAsyncBlock* asyncBlock,
        //    _In_opt_ void* context,
        //    _In_opt_ const void* identity,
        //    _In_opt_ const char* identityName,
        //    _In_ XAsyncProvider* provider
        //    ) noexcept;
        [DllImport(XGameRuntimeLibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int XAsyncBegin(XAsyncBlock* asyncBlock, void* context, void* identity, sbyte* identityName, XAsyncProvider provider);

        //STDAPI XAsyncGetStatus(
        //    _Inout_ XAsyncBlock* asyncBlock,
        //    _In_ bool wait
        //    ) noexcept;
        [DllImport(XGameRuntimeLibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int XAsyncGetStatus(XAsyncBlock* asyncBlock, byte wait);

        //STDAPI_(void) XAsyncComplete(
        //    _Inout_ XAsyncBlock* asyncBlock,
        //    _In_ HRESULT result,
        //    _In_ size_t requiredBufferSize
        //    ) noexcept;
        [DllImport(XGameRuntimeLibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int XAsyncComplete(XAsyncBlock* asyncBlock, int result, ulong requiredBufferSize);
    }
}
