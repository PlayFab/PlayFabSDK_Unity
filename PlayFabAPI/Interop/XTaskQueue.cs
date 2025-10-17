using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public enum XTaskQueueDispatchMode : UInt32
    {
        Manual = 0,
        ThreadPool,
        SerializedThreadPool,
        Immediate
    }

    public enum XTaskQueuePort : UInt32
    {
        Work = 0,
        Completion
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTaskQueueHandle
    {
        public readonly IntPtr intPtr;
        public XTaskQueueHandle(IntPtr ptr)
        {
            intPtr = ptr;
        }
        public static XTaskQueueHandle Null => new XTaskQueueHandle(IntPtr.Zero);
    }

    //struct XTaskQueueRegistrationToken
    //{
    //    uint64_t token;
    //};
    [StructLayout(LayoutKind.Sequential)]
    public struct XTaskQueueRegistrationToken
    {
        public readonly UInt64 token;
    }

    public struct XTaskQueue
    {
        public XTaskQueueHandle handle { get; set; }
    }
}
