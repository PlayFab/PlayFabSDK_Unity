// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Runtime.InteropServices;

namespace PlayFab
{
    public class PFResult
    {
        public int HResult { get; }

        internal PFResult(int hResult)
        {
            HResult = hResult;
        }

        public bool Succeeded()
        {
            return HRESULT.Succeeded(HResult);
        }

        public bool Failed()
        {
            return HRESULT.Failed(HResult);
        }
    }

    /// <summary>
    /// Container for the result and error code of an async operation. The result is only valid if the error code is S_OK.
    /// </summary>
    /// <typeparam name="TResult">PlayFab response type</typeparam>
    public class PFResult<TResult> : PFResult
    {
        public TResult? Result { get; }

        internal PFResult(int hResult)
            : base(hResult)
        {
        }

        internal PFResult(TResult result, int hResult)
            : base(hResult)
        {
            Result = result;
        }
    }
}

namespace PlayFab.InteropWrapper
{
    internal class UnmanagedCallback<T, U>
    {
        internal T directCallback;
        internal U userCallback;

        internal UnmanagedCallback(T direct, U user)
        {
            directCallback = direct;
            userCallback = user;
        }
    }

    public static class AsyncHelpers
    {
        public static readonly Interop.XTaskQueue DefaultQueue = default;

        public static Interop.XAsyncBlockPtr WrapAsyncBlock(Interop.XTaskQueueHandle queue, Interop.XAsyncCompletionRoutine callback)
        {
            var acb = new UnmanagedCallback<Interop.XAsyncCompletionRoutine, Interop.XAsyncCompletionRoutine>(AsyncBlockCallback, callback);

            // Prevent callbacks from being GC'd
            GCHandle gcHandle = GCHandle.Alloc(acb);

            Interop.XAsyncBlock asyncBlock = new Interop.XAsyncBlock()
            {
                queue = queue,
                context = GCHandle.ToIntPtr(gcHandle),
                callback = Marshal.GetFunctionPointerForDelegate(acb.directCallback)
            };

            Int32 blockSize = Marshal.SizeOf(asyncBlock);
            IntPtr asyncBlockPnt = Marshal.AllocHGlobal(blockSize);
            Marshal.StructureToPtr(asyncBlock, asyncBlockPnt, false);

            return new Interop.XAsyncBlockPtr(asyncBlockPnt);
        }

        internal static void CleanupAsyncBlock(Interop.XAsyncBlockPtr block)
        {
            Interop.XAsyncBlock asyncBlock = (Interop.XAsyncBlock)Marshal.PtrToStructure(block.Handle, typeof(Interop.XAsyncBlock));
            GCHandle callbackHandle = GCHandle.FromIntPtr(asyncBlock.context);
            callbackHandle.Free();
            Marshal.FreeHGlobal(block.Handle);
        }

        private static void AsyncBlockCallback(Interop.XAsyncBlockPtr block)
        {
            Interop.XAsyncBlock asyncBlock = (Interop.XAsyncBlock)Marshal.PtrToStructure(block.Handle, typeof(Interop.XAsyncBlock));
            GCHandle callbackHandle = GCHandle.FromIntPtr(asyncBlock.context);
            var ab = callbackHandle.Target as UnmanagedCallback<Interop.XAsyncCompletionRoutine, Interop.XAsyncCompletionRoutine>;

            // invoke user callback
            ab?.userCallback(block);

            // clean up pinned GC content
            callbackHandle.Free();
            Marshal.FreeHGlobal(block.Handle);
        }
    }
}
