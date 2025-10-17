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

    public enum PFLobbyStateChangeType : uint
    {
        CreateAndJoinLobbyCompleted = Interop.Multiplayer.PFLobbyStateChangeType.CreateAndJoinLobbyCompleted,
        JoinLobbyCompleted = Interop.Multiplayer.PFLobbyStateChangeType.JoinLobbyCompleted,
        MemberAdded = Interop.Multiplayer.PFLobbyStateChangeType.MemberAdded,
        AddMemberCompleted = Interop.Multiplayer.PFLobbyStateChangeType.AddMemberCompleted,
        MemberRemoved = Interop.Multiplayer.PFLobbyStateChangeType.MemberRemoved,
        ForceRemoveMemberCompleted = Interop.Multiplayer.PFLobbyStateChangeType.ForceRemoveMemberCompleted,
        LeaveLobbyCompleted = Interop.Multiplayer.PFLobbyStateChangeType.LeaveLobbyCompleted,
        Updated = Interop.Multiplayer.PFLobbyStateChangeType.Updated,
        PostUpdateCompleted = Interop.Multiplayer.PFLobbyStateChangeType.PostUpdateCompleted,
        Disconnecting = Interop.Multiplayer.PFLobbyStateChangeType.Disconnecting,
        Disconnected = Interop.Multiplayer.PFLobbyStateChangeType.Disconnected,
        JoinArrangedLobbyCompleted = Interop.Multiplayer.PFLobbyStateChangeType.JoinArrangedLobbyCompleted,
        FindLobbiesCompleted = Interop.Multiplayer.PFLobbyStateChangeType.FindLobbiesCompleted,
        InviteReceived = Interop.Multiplayer.PFLobbyStateChangeType.InviteReceived,
        InviteListenerStatusChanged = Interop.Multiplayer.PFLobbyStateChangeType.InviteListenerStatusChanged,
        SendInviteCompleted = Interop.Multiplayer.PFLobbyStateChangeType.SendInviteCompleted,
        CreateAndClaimServerLobbyCompleted = Interop.Multiplayer.PFLobbyStateChangeType.CreateAndClaimServerLobbyCompleted,
        ClaimServerLobbyCompleted = Interop.Multiplayer.PFLobbyStateChangeType.ClaimServerLobbyCompleted,
        ServerPostUpdateCompleted = Interop.Multiplayer.PFLobbyStateChangeType.ServerPostUpdateCompleted,
        ServerDeleteLobbyCompleted = Interop.Multiplayer.PFLobbyStateChangeType.ServerDeleteLobbyCompleted,
        JoinLobbyAsServerCompleted = Interop.Multiplayer.PFLobbyStateChangeType.JoinLobbyAsServerCompleted,
        ServerPostUpdateAsServerCompleted = Interop.Multiplayer.PFLobbyStateChangeType.ServerPostUpdateAsServerCompleted,
        ServerLeaveLobbyAsServerCompleted = Interop.Multiplayer.PFLobbyStateChangeType.ServerLeaveLobbyAsServerCompleted,
    }
}
