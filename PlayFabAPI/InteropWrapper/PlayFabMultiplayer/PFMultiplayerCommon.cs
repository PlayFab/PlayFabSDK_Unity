/*
 * PlayFab Unity SDK
 *
 * Copyright (c) Microsoft Corporation
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */

namespace PlayFab.InteropWrapper.Multiplayer
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using PlayFab.Interop.Multiplayer;

    public partial class PFMultiplayer
    {
#if UNITY_GAMECORE && !UNITY_EDITOR
        private static MultiplayerWorkQueue multiplayerWorkQueue;
#endif

        public const uint PFLobbyMaxMemberCountLowerLimit = Interop.Multiplayer.Methods.PFLobbyMaxMemberCountLowerLimit;
        public const uint PFLobbyMaxMemberCountUpperLimit = Interop.Multiplayer.Methods.PFLobbyMaxMemberCountUpperLimit;
        public const uint PFLobbyMaxSearchPropertyCount = Interop.Multiplayer.Methods.PFLobbyMaxSearchPropertyCount;
        public const uint PFLobbyMaxLobbyPropertyCount = Interop.Multiplayer.Methods.PFLobbyMaxLobbyPropertyCount;
        public const uint PFLobbyMaxMemberPropertyCount = Interop.Multiplayer.Methods.PFLobbyMaxMemberPropertyCount;
        public const uint PFLobbyMaxServerPropertyCount = Interop.Multiplayer.Methods.PFLobbyMaxServerPropertyCount;
        public const uint PFLobbyClientRequestedSearchResultCountUpperLimit = Interop.Multiplayer.Methods.PFLobbyClientRequestedSearchResultCountUpperLimit;

        public static string PFMultiplayerGetErrorMessage(
            int hresult)
        {
            unsafe
            {
                sbyte* errorMessagePtr = Methods.PFMultiplayerGetErrorMessage(hresult);
                if (errorMessagePtr != null)
                {
                    return Converters.PtrToStringUTF8((IntPtr)errorMessagePtr);
                }

                return null;
            }
        }

        public static int PFMultiplayerInitialize(
            string titleId,
            out PFMultiplayerHandle handle)
        {
            using (var disposableCollection = new DisposableCollection())
            {
                unsafe
                {
                    Interop.Multiplayer.PFMultiplayer* interopUserHandle;
                    var titlePtr = new UTF8StringPtr(titleId, disposableCollection);

                    MultiplayerInitializationConfiguration initConfig;
                    initConfig.titleId = titlePtr.Pointer;
                    initConfig.multiplayerTaskQueue = AsyncHelpers.DefaultQueue.handle.intPtr;
#if UNITY_GAMECORE && !UNITY_EDITOR
                    // A retained owner means teardown did not finish. Never start a second dispatcher.
                    if (multiplayerWorkQueue != null)
                    {
                        handle = null;
                        return unchecked((int)0x8000FFFF);
                    }

                    int created = MultiplayerWorkQueue.Create(out multiplayerWorkQueue);
                    if (created < 0)
                    {
                        handle = null;
                        return created;
                    }

                    initConfig.multiplayerTaskQueue = multiplayerWorkQueue.Handle;
#endif

                    // Allocate only after queue creation can no longer return early.
                    IntPtr structPtr = Marshal.AllocHGlobal(sizeof(MultiplayerInitializationConfiguration));

                    // Copy the managed struct to unmanaged memory
                    Marshal.StructureToPtr(initConfig, structPtr, false);

                    // Cast the IntPtr to a struct pointer
                    MultiplayerInitializationConfiguration* pConfig = (MultiplayerInitializationConfiguration*)structPtr;

                    int err = Methods.PFMultiplayerInitialize(
                        pConfig,
                        &interopUserHandle);

                    const int XBOX_E_MULTIPLAYER_API_ALREADY_INITIALIZED = unchecked((int)0x89236401);
                    if (err == XBOX_E_MULTIPLAYER_API_ALREADY_INITIALIZED)
                    {
                        Methods.PFMultiplayerUninitialize(null);
                        err = Methods.PFMultiplayerInitialize(
                            pConfig,
                            &interopUserHandle);
                    }

#if UNITY_GAMECORE && !UNITY_EDITOR
                    if (err < 0 && multiplayerWorkQueue != null)
                    {
                        multiplayerWorkQueue.StopAfterLibraryReturned();
                        multiplayerWorkQueue = null;
                    }
#endif
                    return PFMultiplayerHandle.WrapAndReturnError(err, interopUserHandle, out handle);
                }
            }
        }

        public static int PFMultiplayerUninitialize(
            PFMultiplayerHandle handle)
        {
            unsafe
            {
                int result = Methods.PFMultiplayerUninitialize(handle.InteropHandle);
#if UNITY_GAMECORE && !UNITY_EDITOR
                // Native invalidates library state when this call returns, including an HRESULT failure.
                if (multiplayerWorkQueue != null)
                {
                    multiplayerWorkQueue.StopAfterLibraryReturned();
                    multiplayerWorkQueue = null;
                }
#endif
                return result;
            }
        }

#if UNITY_GAMECORE && !UNITY_EDITOR
        internal sealed class MultiplayerWorkQueue
        {
            private const uint WaitMilliseconds = 100;
            private readonly Interop.XTaskQueueHandle queue;
            private readonly System.Threading.Thread dispatcher;
            private int stopped;

            private MultiplayerWorkQueue(Interop.XTaskQueueHandle queue)
            {
                this.queue = queue;
                dispatcher = new System.Threading.Thread(Dispatch) { IsBackground = true };
            }

            internal IntPtr Handle => queue.intPtr;

            internal static int Create(out MultiplayerWorkQueue owner)
            {
                owner = null;
                int result = Interop.Methods.XTaskQueueCreate(
                    Interop.XTaskQueueDispatchMode.Manual,
                    Interop.XTaskQueueDispatchMode.ThreadPool,
                    out var queue);
                if (result < 0)
                {
                    return result;
                }

                try
                {
                    owner = new MultiplayerWorkQueue(queue);
                    owner.dispatcher.Start();
                    return result;
                }
                catch
                {
                    Interop.Methods.XTaskQueueCloseHandle(queue);
                    owner = null;
                    throw;
                }
            }

            private void Dispatch()
            {
                while (System.Threading.Volatile.Read(ref stopped) == 0)
                {
                    Interop.Methods.XTaskQueueDispatch(queue, Interop.XTaskQueuePort.Work, WaitMilliseconds);
                }
            }

            internal void StopAfterLibraryReturned()
            {
                // Keep Work dispatch alive through termination. Completion uses the pool, never this caller.
                int result = Interop.Methods.XTaskQueueTerminate(queue, true, IntPtr.Zero, IntPtr.Zero);
                Marshal.ThrowExceptionForHR(result);
                System.Threading.Volatile.Write(ref stopped, 1);
                dispatcher.Join();
                Interop.Methods.XTaskQueueCloseHandle(queue);
            }
        }
#endif

        public static int PFMultiplayerSetThreadAffinityMask(
            PFMultiplayerThreadId threadId,
            ulong threadAffinityMask)
        {
            return Methods.PFMultiplayerSetThreadAffinityMask(
                (Interop.Multiplayer.PFMultiplayerThreadId)threadId,
                threadAffinityMask);
        }
    }
}
