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

                    // Allocate unmanaged memory for the struct
                    IntPtr structPtr = Marshal.AllocHGlobal(sizeof(MultiplayerInitializationConfiguration));

                    MultiplayerInitializationConfiguration initConfig;
                    initConfig.titleId = titlePtr.Pointer;
                    initConfig.multiplayerTaskQueue = AsyncHelpers.DefaultQueue.handle.intPtr;

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

                    return PFMultiplayerHandle.WrapAndReturnError(err, interopUserHandle, out handle);
                }
            }
        }

        public static int PFMultiplayerUninitialize(
            PFMultiplayerHandle handle)
        {
            unsafe
            {
                return Methods.PFMultiplayerUninitialize(handle.InteropHandle);
            }
        }

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
