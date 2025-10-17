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
    public class PFLobbySearchFriendsFilter
    {
        public bool IncludeSteamFriends { get; set; }

        public bool IncludeFacebookFriends { get; set; }

        public string IncludeXboxFriendsToken { get; set; }

        internal unsafe Interop.Multiplayer.PFLobbySearchFriendsFilter* ToPointer(DisposableCollection disposableCollection)
        {
            Interop.Multiplayer.PFLobbySearchFriendsFilter interopPtr = new Interop.Multiplayer.PFLobbySearchFriendsFilter();

            interopPtr.includeSteamFriends = this.IncludeSteamFriends ? (byte)1 : (byte)0;
            interopPtr.includeFacebookFriends = this.IncludeFacebookFriends ? (byte)1 : (byte)0;
            if (!string.IsNullOrEmpty(this.IncludeXboxFriendsToken))
            {
                UTF8StringPtr includeXboxFriendsTokenPtr = new UTF8StringPtr(this.IncludeXboxFriendsToken, disposableCollection);
                interopPtr.includeXboxFriendsToken = includeXboxFriendsTokenPtr.Pointer;
            }

            return (Interop.Multiplayer.PFLobbySearchFriendsFilter*)Converters.StructToPtr<Interop.Multiplayer.PFLobbySearchFriendsFilter>(interopPtr, disposableCollection);
        }
    }
}
