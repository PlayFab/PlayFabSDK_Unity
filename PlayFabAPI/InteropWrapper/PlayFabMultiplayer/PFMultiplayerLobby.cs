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
    using System.Linq;
    using System.Runtime.InteropServices;
    using PlayFab.Interop.Multiplayer;
    using PlayFab.Multiplayer;

    public struct LobbyStateChangeCollection
    {
        public List<PFLobbyStateChange> StateChanges;
        public uint StateChangeCount;
        internal unsafe PlayFab.Interop.Multiplayer.PFLobbyStateChange** RawStateChanges;
    }

    public partial class PFMultiplayer
    {
        static PFMultiplayer()
        {
            ObjPool = new PlayFab.Multiplayer.ObjectPool();

            // Limit is arbitrary
            ObjPool.AddEntry<List<PFLobbyStateChange>>(4, new Type[] { });
            ObjPool.AddEntry<List<PFMatchmakingStateChange>>(4, new Type[] { });
        }

        // For storing high frequency objects
        internal static PlayFab.Multiplayer.ObjectPool ObjPool { get; set; }

        public static int PFMultiplayerStartProcessingLobbyStateChanges(
            PFMultiplayerHandle handle,
            out LobbyStateChangeCollection collection)
        {
            uint stateChangeCount = 0;

            collection.StateChanges = ObjPool.Retrieve<List<PFLobbyStateChange>>();
            unsafe
            {
                PlayFab.Interop.Multiplayer.PFLobbyStateChange** rawStateChanges = null;

                int err = Methods.PFMultiplayerStartProcessingLobbyStateChanges(
                    handle.InteropHandle,
                    &stateChangeCount,
                    &rawStateChanges);

                collection.RawStateChanges = rawStateChanges;
                collection.StateChangeCount = stateChangeCount;

                if (LobbyError.SUCCEEDED(err) && stateChangeCount > 0)
                {
                    for (int i = 0; i < stateChangeCount; i++)
                    {
                        PFLobbyStateChange stateChangeObj = PFLobbyStateChange.CreateFromPtr(rawStateChanges[i]);
                        if (stateChangeObj.GetType() != typeof(PFLobbyStateChange))
                        {
                            collection.StateChanges.Add(stateChangeObj);
                        }
                    }
                }

                return err;
            }
        }

        public static unsafe int PFMultiplayerFinishProcessingLobbyStateChanges(
            PFMultiplayerHandle handle,
            LobbyStateChangeCollection collection)
        {
            if (handle == null)
            {
                return LobbyError.InvalidArg;
            }

            unsafe
            {
                collection.StateChanges.Clear();
                ObjPool.Return(collection.StateChanges);

                int err = Methods.PFMultiplayerFinishProcessingLobbyStateChanges(
                    handle.InteropHandle,
                    collection.StateChangeCount,
                    collection.RawStateChanges);
                return err;
            }
        }

        public static int PFMultiplayerCreateAndJoinLobby(
            PFMultiplayerHandle handle,
            PFEntityHandle creator,
            PFLobbyCreateConfiguration createConfiguration,
            PFLobbyJoinConfiguration joinConfiguration,
            object asyncIdentifier,
            out PFLobbyHandle lobby)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                unsafe
                {
                    IntPtr asyncId = IntPtr.Zero;
                    if (asyncIdentifier != null)
                    {
                        asyncId = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
                    }

                    PFLobby* lobbyPtr = null;
                    void* asyncContext = asyncId.ToPointer();
                    int err = Methods.PFMultiplayerCreateAndJoinLobbyWithEntityHandle(
                        handle.InteropHandle,
                        creator.Handle,
                        createConfiguration.ToPointer(dc),
                        joinConfiguration.ToPointer(dc),
                        asyncContext,
                        &lobbyPtr);
                    //int err = Methods.PFMultiplayerCreateAndJoinLobby(
                    //    handle.InteropHandle,
                    //    creator.ToPointer(dc),
                    //    createConfiguration.ToPointer(dc),
                    //    joinConfiguration.ToPointer(dc),
                    //    asyncContext,
                    //    &lobbyPtr);

                    if (LobbyError.FAILED(err))
                    {
                        if (asyncId != IntPtr.Zero)
                        {
                            GCHandle asyncGcHandle = GCHandle.FromIntPtr(asyncId);
                            asyncGcHandle.Free();
                        }
                    }

                    lobby = new PFLobbyHandle(lobbyPtr);
                    return err;
                }
            }
        }

        public static int PFLobbyForceRemoveMember(
            PFLobbyHandle lobby,
            PFEntityKey targetMember,
            bool preventRejoin,
            object asyncContext)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                unsafe
                {
                    IntPtr asyncContextPtr = IntPtr.Zero;
                    if (asyncContext != null)
                    {
                        asyncContextPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
                    }

                    Interop.PFEntityKey* interopEntityKey = stackalloc Interop.PFEntityKey[1];
                    interopEntityKey = null;
                    InteropWrapper.DisposableBuffer disposableBuffer = new InteropWrapper.DisposableBuffer();
                    PFEntityKey.ToInterop(targetMember, interopEntityKey, disposableBuffer);
                    dc.Add(disposableBuffer);
                    int err = Methods.PFLobbyForceRemoveMember(
                        lobby.InteropHandle,
                        interopEntityKey,
                        (byte)(preventRejoin ? 1 : 0),
                        asyncContextPtr.ToPointer());
                    return err;
                }
            }
        }

        public static int PFLobbyAddMember(
            PFLobbyHandle lobby,
            PFEntityHandle localUserHandle,
            IDictionary<string, string> memberProperties,
            object asyncContext)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                unsafe
                {
                    IntPtr asyncContextPtr = IntPtr.Zero;
                    if (asyncContext != null)
                    {
                        asyncContextPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
                    }

                    SizeT count;
                    uint memberPropertyCount = Convert.ToUInt32(memberProperties.Count);
                    var memberPropertyKeys = (sbyte**)Converters.StringArrayToUTF8StringArray(memberProperties.Keys.ToArray(), dc, out count);
                    var memberPropertyValues = (sbyte**)Converters.StringArrayToUTF8StringArray(memberProperties.Values.ToArray(), dc, out count);

                    int err = Methods.PFLobbyAddMemberWithEntityHandle(
                        lobby.InteropHandle,
                        localUserHandle.Handle,
                        memberPropertyCount,
                        memberPropertyKeys,
                        memberPropertyValues,
                        asyncContextPtr.ToPointer());
                    return err;
                }
            }
        }

        public static int PFMultiplayerJoinLobby(
            PFMultiplayerHandle handle,
            PFEntityHandle newMemberHandle,
            string connectionString,
            PFLobbyJoinConfiguration configuration,
            object asyncContext,
            out PFLobbyHandle lobby)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                unsafe
                {
                    IntPtr asyncContextPtr = IntPtr.Zero;
                    if (asyncContext != null)
                    {
                        asyncContextPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
                    }

                    UTF8StringPtr connectionStringPtr = new UTF8StringPtr(connectionString, dc);
                    PFLobby* lobbyPtr = null;
                    int err = Methods.PFMultiplayerJoinLobbyWithEntityHandle(
                        handle.InteropHandle,
                        newMemberHandle.Handle,
                        connectionStringPtr.Pointer,
                        configuration.ToPointer(dc),
                        asyncContextPtr.ToPointer(),
                        &lobbyPtr);
                    if (LobbyError.FAILED(err))
                    {
                        if (asyncContextPtr != IntPtr.Zero)
                        {
                            GCHandle asyncGcHandle = GCHandle.FromIntPtr(asyncContextPtr);
                            asyncGcHandle.Free();
                        }
                    }

                    lobby = new PFLobbyHandle(lobbyPtr);
                    return err;
                }
            }
        }

        public static int PFMultiplayerJoinArrangedLobby(
            PFMultiplayerHandle handle,
            PFEntityHandle newMemberHandle,
            string arrangementString,
            PFLobbyArrangedJoinConfiguration configuration,
            object asyncContext,
            out PFLobbyHandle lobby)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                IntPtr asyncContextPtr = IntPtr.Zero;
                if (asyncContext != null)
                {
                    asyncContextPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
                }

                unsafe
                {
                    UTF8StringPtr arrangementStringPtr = new UTF8StringPtr(arrangementString, dc);
                    PFLobby* lobbyPtr = null;
                    int err = Methods.PFMultiplayerJoinArrangedLobbyWithEntityHandle(
                        handle.InteropHandle,
                        newMemberHandle.Handle,
                        arrangementStringPtr.Pointer,
                        configuration.ToPointer(dc),
                        asyncContextPtr.ToPointer(),
                        &lobbyPtr);
                    if (LobbyError.FAILED(err))
                    {
                        if (asyncContextPtr != IntPtr.Zero)
                        {
                            GCHandle asyncGcHandle = GCHandle.FromIntPtr(asyncContextPtr);
                            asyncGcHandle.Free();
                        }
                    }

                    lobby = new PFLobbyHandle(lobbyPtr);
                    return err;
                }
            }
        }

        public static int PFMultiplayerFindLobbies(
            PFMultiplayerHandle handle,
            PFEntityHandle searchingEntityHandle,
            PFLobbySearchConfiguration searchConfiguration,
            object asyncContext)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                IntPtr asyncContextPtr = IntPtr.Zero;
                if (asyncContext != null)
                {
                    asyncContextPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
                }

                unsafe
                {
                    int err = Methods.PFMultiplayerFindLobbiesWithEntityHandle(
                        handle.InteropHandle,
                        searchingEntityHandle.Handle,
                        searchConfiguration.ToPointer(dc),
                        asyncContextPtr.ToPointer());
                    return err;
                }
            }
        }

        public static int PFMultiplayerStartListeningForLobbyInvites(
            PFMultiplayerHandle handle, 
            PFEntityHandle listeningEntity)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                unsafe
                {
                    int err = Methods.PFMultiplayerStartListeningForLobbyInvitesWithEntityHandle(
                        handle.InteropHandle,
                        listeningEntity.Handle);
                    return err;
                }
            }
        }

        public static int PFMultiplayerStopListeningForLobbyInvites(
            PFMultiplayerHandle handle, 
            PFEntityHandle listeningEntityHandle)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                unsafe
                {
                    int err = Methods.PFMultiplayerStopListeningForLobbyInvitesWithEntityHandle(
                        handle.InteropHandle,
                        listeningEntityHandle.Handle);
                    return err;
                }
            }
        }

        public static int PFMultiplayerGetLobbyInviteListenerStatus(
            PFMultiplayerHandle handle, 
            PFEntityKey listeningEntity,
            out PFLobbyInviteListenerStatus status)
        {
            using (DisposableCollection dc = new DisposableCollection())
            {
                unsafe
                {
                    Interop.Multiplayer.PFLobbyInviteListenerStatus interopStatus;
                    
                    Interop.PFEntityKey* interopEntityKey = stackalloc Interop.PFEntityKey[1];
                    interopEntityKey = null;
                    InteropWrapper.DisposableBuffer disposableBuffer = new InteropWrapper.DisposableBuffer();
                    PFEntityKey.ToInterop(listeningEntity, interopEntityKey, disposableBuffer);
                    dc.Add(disposableBuffer);
                    int err = Methods.PFMultiplayerGetLobbyInviteListenerStatus(
                        handle.InteropHandle,
                        interopEntityKey,
                        &interopStatus);
                    status = (PFLobbyInviteListenerStatus)interopStatus;
                    return err;
                }
            }
        }
    }
}
