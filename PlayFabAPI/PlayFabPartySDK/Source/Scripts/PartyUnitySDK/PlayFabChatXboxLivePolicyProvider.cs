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

#if MICROSOFT_GDK_SUPPORT && !UNITY_EDITOR
#define BUILD_XBL_PLUGIN
#endif

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using PartyCSharpSDK;
using PartyXBLCSharpSDK;

#if MICROSOFT_GDK_SUPPORT
using Unity.XGamingRuntime;
using XGR = Unity.XGamingRuntime;
#endif

#if BUILD_XBL_PLUGIN
namespace PlayFab.Party._Internal
{
    /// <summary>
    /// The Party voice and text messages policy provider to be used when using Xbox Live player authentication.
    /// Using this policy provider helps game comply with Microsoft Game Core XR-015 and XR-045 requirements.
    /// </summary>
    internal class PlayFabChatXboxLivePolicyProvider : IPlayFabChatPlatformPolicyProvider
    {
        private PARTY_XBL_HANDLE _xblPartyHandle;
        private PlayFabMultiplayerManager _multiplayerManager;
        private PARTY_XBL_CHAT_USER_HANDLE _xblLocalChatUserHandle;

        private static PlayFabChatXboxLivePolicyProvider _xblPolicyProvider;
        private QueuedUpdateChatPermissionsOp _queuedUpdateChatPermissionsOp;
        private XUserHandle _xblLocalUserHandle;
        private Dictionary<PlayFabPlayer, PARTY_XBL_CHAT_PERMISSION_INFO> _playerChatPermissions;
        private List<QueuedCreateRemoteXboxLiveChatUserOp> _queuedCreateRemoteXboxLiveChatUserOps;
        private List<PARTY_XBL_STATE_CHANGE> _xblStateChanges;
        private byte[] _internalXuidExchangeMessageBuffer;

        private byte[] _XUID_EXCHANGE_REQUEST_AS_BYTES;
        private byte[] _XUID_EXCHANGE_RESPONSE_AS_BYTES;

        private const PARTY_CHAT_PERMISSION_OPTIONS _CHAT_PERMISSIONS_ALL =
            PARTY_CHAT_PERMISSION_OPTIONS.PARTY_CHAT_PERMISSION_OPTIONS_SEND_AUDIO |
            PARTY_CHAT_PERMISSION_OPTIONS.PARTY_CHAT_PERMISSION_OPTIONS_RECEIVE_AUDIO |
            PARTY_CHAT_PERMISSION_OPTIONS.PARTY_CHAT_PERMISSION_OPTIONS_RECEIVE_TEXT;
        private const uint _INTERNAL_XUID_EXCHANGE_MESSAGE_BUFFER_SIZE = 128;
        private const string _XUID_EXCHANGE_REQUEST_MESSAGE_PREFIX = "PFP-XBL-XUID-REQUEST";
        private const string _XUID_EXCHANGE_RESPONSE_MESSAGE_PREFIX = "PFP-XBL-XUID-RESPONSE";
        private const int _E_GAMEUSER_RESOLVE_USER_ISSUE_REQUIRED = -1994108670;

        private const string _ErrorMessageCouldNotGetXuid = "Could not get a XUID.";
        private const string _ErrorMessageCouldNotGetXboxLiveToken = "Could not get an Xbox Live token.";

        public static PlayFabChatXboxLivePolicyProvider Get()
        {
            if (_xblPolicyProvider == null)
            {
                _xblPolicyProvider = new PlayFabChatXboxLivePolicyProvider();
            }
            return _xblPolicyProvider;
        }

        public PlayFabChatXboxLivePolicyProvider()
        {
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:PlayFabChatXboxLivePolicyProvider()");

            _multiplayerManager = PlayFabMultiplayerManager.Get();
            string titleId = _multiplayerManager.TitleId;

            _playerChatPermissions = new Dictionary<PlayFabPlayer, PARTY_XBL_CHAT_PERMISSION_INFO>(new PlayerComparator());
            _queuedCreateRemoteXboxLiveChatUserOps = new List<QueuedCreateRemoteXboxLiveChatUserOp>();
            _xblStateChanges = new List<PARTY_XBL_STATE_CHANGE>();
            _internalXuidExchangeMessageBuffer = new byte[_INTERNAL_XUID_EXCHANGE_MESSAGE_BUFFER_SIZE];

            Succeeded(XBLSDK.PartyXblInitialize(titleId, out _xblPartyHandle));

            _XUID_EXCHANGE_REQUEST_AS_BYTES = Encoding.ASCII.GetBytes(_XUID_EXCHANGE_REQUEST_MESSAGE_PREFIX);
            _XUID_EXCHANGE_RESPONSE_AS_BYTES = Encoding.ASCII.GetBytes(_XUID_EXCHANGE_RESPONSE_MESSAGE_PREFIX);
        }

        public bool CleanUp()
        {
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:CleanUp()");

            bool succeeded = true;
            succeeded = Succeeded(XBLSDK.PartyXblCleanup(_xblPartyHandle));

            _xblPolicyProvider = null;
            _playerChatPermissions = null;
            _xblStateChanges = null;
            _queuedCreateRemoteXboxLiveChatUserOps = null;
            _internalXuidExchangeMessageBuffer = null;
            _XUID_EXCHANGE_REQUEST_AS_BYTES = null;
            _XUID_EXCHANGE_RESPONSE_AS_BYTES = null;
            _xblLocalChatUserHandle = null;
            if (_xblLocalUserHandle != null)
            {
                XGR.SDK.XUserCloseHandle(_xblLocalUserHandle);
                _xblLocalUserHandle = null;
            }
            _xblPartyHandle = null;
            return succeeded;
        }

        public bool SetLocalXboxUser(XUserHandle xboxUser)
        {
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:SetLocalXboxUser()");

            if (_xblLocalChatUserHandle != null)
            {
                return true;
            }

            ulong xuid;
            int hr = XGR.SDK.XUserGetId(xboxUser, out xuid);
            if (!HrSucceeded(hr))
            {
                PlayFabMultiplayerManager._LogError($"{_ErrorMessageCouldNotGetXuid} HRESULT: 0x{hr:X8}");
                return false;
            }

            XUserHandle localUserHandle;
            hr = XGR.SDK.XUserDuplicateHandle(xboxUser, out localUserHandle);
            if (!HrSucceeded(hr))
            {
                PlayFabMultiplayerManager._LogError($"{PlayFabMultiplayerManager._ErrorMessageCouldNotDuplicateXboxUser} HRESULT: 0x{hr:X8}");
                return false;
            }

            if (Succeeded(XBLSDK.PartyXblCreateLocalChatUser(
                    _xblPartyHandle,
                    xuid,
                    null,
                    out _xblLocalChatUserHandle
                )))
            {
                _xblLocalUserHandle = localUserHandle;
                return true;
            }

            XGR.SDK.XUserCloseHandle(localUserHandle);
            return false;
        }

        public void CreateOrUpdatePlatformUser(PlayFabPlayer player, bool isLocal)
        {
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:CreateOrUpdatePlatformUser()");

            if (isLocal)
            {
                ulong xuid;
                if (_xblLocalUserHandle != null && HrSucceeded(XGR.SDK.XUserGetId(_xblLocalUserHandle, out xuid)))
                {
                    player._platformSpecificUserId = xuid.ToString();
                }
            }
            else
            {
                TryCreateRemoteXboxLiveChatUser(player);
            }
        }

        public PARTY_CHAT_PERMISSION_OPTIONS GetChatPermissions(PlayFabPlayer targetPlayer)
        {
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:GetChatPermissions()");

            PARTY_CHAT_PERMISSION_OPTIONS chatPermissions = PARTY_CHAT_PERMISSION_OPTIONS.PARTY_CHAT_PERMISSION_OPTIONS_NONE;
            if (_playerChatPermissions.ContainsKey(targetPlayer))
            {
                chatPermissions = _playerChatPermissions[targetPlayer].ChatPermissionMask;
            }
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:get chat permissions for EntityId: " + targetPlayer.EntityKey.Id + ", chat permissions: " + chatPermissions);

            return chatPermissions;
        }

        public void ProcessEndpointMessage(PlayFabPlayer fromPlayer, IntPtr messageBuffer, uint messageSize, out bool isInternalMessage)
        {
            isInternalMessage = false;
            // Another client asks for our client's XUID
            if (messageSize > 0 &&
                messageSize < _INTERNAL_XUID_EXCHANGE_MESSAGE_BUFFER_SIZE)
            {
                Marshal.Copy(messageBuffer, _internalXuidExchangeMessageBuffer, 0, (int)messageSize);
                if (_multiplayerManager._StartsWithSequence(_internalXuidExchangeMessageBuffer, _XUID_EXCHANGE_REQUEST_AS_BYTES))
                {
                    isInternalMessage = true;
                    PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider: received remote XUID.");

                    // Find the other client and set their XIUD

                    // The buffer can contain trailing bytes if the application has received any message
                    // that passed the first if check in this function. (messageSize > 0 && messageSize < _INTERNAL_XUID_EXCHANGE_MESSAGE_BUFFER_SIZE)
                    // Alternative to this would be to clear _internalXuidExchangeMessageBuffer before copying the messageBuffer into it.
                    uint remoteXuidAsBytesLength = messageSize - (uint)_XUID_EXCHANGE_REQUEST_AS_BYTES.Length - 1;
                    if (remoteXuidAsBytesLength >= 0)
                    {
                        byte[] remoteXuidAsBytes = new byte[remoteXuidAsBytesLength];
                        Array.Copy(_internalXuidExchangeMessageBuffer, _XUID_EXCHANGE_REQUEST_AS_BYTES.Length + 1, remoteXuidAsBytes, 0, remoteXuidAsBytes.Length);
                        fromPlayer._platformSpecificUserId = Encoding.ASCII.GetString(remoteXuidAsBytes);

                        PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider: sent XUID exchange response message.");

                        // Update queued operations
                        for (int i = 0; i < _queuedCreateRemoteXboxLiveChatUserOps.Count; i++)
                        {
                            if (_queuedCreateRemoteXboxLiveChatUserOps[i].otherPlayer.EntityKey.Id == fromPlayer.EntityKey.Id)
                            {
                                ulong remoteXuid = Convert.ToUInt64(fromPlayer._platformSpecificUserId);
                                _queuedCreateRemoteXboxLiveChatUserOps[i].xuid = remoteXuid;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS GetPlatformUserChatTranscriptionPreferences()
        {
            PARTY_XBL_ACCESSIBILITY_SETTINGS accessibilitySettings;
            PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS partyChatTranscriptionOptions = PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS.PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS_NONE;
            Succeeded(XBLSDK.PartyXblLocalChatUserGetAccessibilitySettings(
                    _xblLocalChatUserHandle,
                    out accessibilitySettings
                ));
            if (accessibilitySettings != null &&
                accessibilitySettings.SpeechToTextEnabled != 0)
            {
                partyChatTranscriptionOptions = PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS.PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS_TRANSCRIBE_OTHER_CHAT_CONTROLS_WITH_MATCHING_LANGUAGES |
                    PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS.PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS_TRANSCRIBE_SELF;
            }
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:GetPlatformUserChatTranscriptionPreferences(), transcription options: " + partyChatTranscriptionOptions);

            return partyChatTranscriptionOptions;
        }

        public bool IsTextToSpeechEnabled()
        {
            bool isTextToSpeechEnabled = false;
            PARTY_XBL_ACCESSIBILITY_SETTINGS accessibilitySettings;
            Succeeded(XBLSDK.PartyXblLocalChatUserGetAccessibilitySettings(
            _xblLocalChatUserHandle,
            out accessibilitySettings
        ));
            if (accessibilitySettings != null &&
                accessibilitySettings.TextToSpeechEnabled != 0)
            {
                isTextToSpeechEnabled = true;
            }
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:IsTextToSpeechEnabled(), value: " + isTextToSpeechEnabled);

            return isTextToSpeechEnabled;
        }

        public void SendPlatformSpecificUserId(List<PlayFabPlayer> targetPlayers)
        {
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:SendPlatformSpecificUserId()");

            // Broadcast XUID to other endpoints in the network.
            ulong xuid;
            if (_xblLocalUserHandle != null && HrSucceeded(XGR.SDK.XUserGetId(_xblLocalUserHandle, out xuid)))
            {
                string xuidMessageString = _XUID_EXCHANGE_REQUEST_MESSAGE_PREFIX + ":" + xuid;
                byte[] xuidMessageBytes = Encoding.ASCII.GetBytes(xuidMessageString);
                _multiplayerManager._SendDataMessage(xuidMessageBytes, targetPlayers, DeliveryOption.Guaranteed);
            }
            else
            {
                PlayFabMultiplayerManager._LogError(_ErrorMessageCouldNotGetXuid);
            }
        }

        public void ProcessQueuedOperations()
        {
            if (_queuedUpdateChatPermissionsOp.queued &&
                IsReadyToSetChatPermissions(_queuedUpdateChatPermissionsOp.localXblChatUser, _queuedUpdateChatPermissionsOp.targetXblChatUser))
            {
                UpdateChatPermissionInfoComplete(
                    _queuedUpdateChatPermissionsOp.localXblChatUser,
                    _queuedUpdateChatPermissionsOp.targetXblChatUser
                    );
            }
            for (int i = _queuedCreateRemoteXboxLiveChatUserOps.Count - 1; i >= 0; i--)
            {
                if (_queuedCreateRemoteXboxLiveChatUserOps[i].xuid != 0)
                {
                    TryCreateRemoteXboxLiveChatUser(_queuedCreateRemoteXboxLiveChatUserOps[i].otherPlayer);
                }
            }
        }

        public void ProcessStateChanges()
        {
            if (Succeeded(XBLSDK.PartyXblStartProcessingStateChanges(_xblPartyHandle, out _xblStateChanges)))
            {
                foreach (PARTY_XBL_STATE_CHANGE stateChange in _xblStateChanges)
                {
                    PlayFabMultiplayerManager._LogInfo("XBL State change: " + stateChange.StateChangeType.ToString());
                    switch (stateChange.StateChangeType)
                    {
                        case PARTY_XBL_STATE_CHANGE_TYPE.PARTY_XBL_STATE_CHANGE_TYPE_TOKEN_AND_SIGNATURE_REQUESTED:
                            {
                                var stateChangeConverted = (PARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE)stateChange;
                                TrackableGetXTokenCompletedWrapper trackableGetXTokenCompletedWrapper = new TrackableGetXTokenCompletedWrapper();
                                trackableGetXTokenCompletedWrapper.provider = this;
                                trackableGetXTokenCompletedWrapper.correlationId = stateChangeConverted.correlationId;
                                trackableGetXTokenCompletedWrapper.url = stateChangeConverted.url;
                                trackableGetXTokenCompletedWrapper.method = stateChangeConverted.method;
                                XUserGetTokenAndSignatureOptions options = XUserGetTokenAndSignatureOptions.None;
                                if (stateChangeConverted.allUsers)
                                {
                                    options |= XUserGetTokenAndSignatureOptions.AllUsers;
                                }
                                if (stateChangeConverted.forceRefresh)
                                {
                                    options |= XUserGetTokenAndSignatureOptions.ForceRefresh;
                                }
                                XUserGetTokenAndSignatureUtf16HttpHeader[] tokenRequestHeaders = new XUserGetTokenAndSignatureUtf16HttpHeader[stateChangeConverted.headers.Length];
                                for (uint i = 0; i < stateChangeConverted.headers.Length; i++)
                                {
                                    string tokenRequestHeaderName = stateChangeConverted.headers[i].name;
                                    string tokenRequestHeaderValue = stateChangeConverted.headers[i].value;
                                    tokenRequestHeaders[i] = new XUserGetTokenAndSignatureUtf16HttpHeader();
                                    tokenRequestHeaders[i].Name = tokenRequestHeaderName;
                                    tokenRequestHeaders[i].Value = tokenRequestHeaderValue;
                                }

                                var headers = tokenRequestHeaders;
                                if (stateChangeConverted.headers.Length == 0)
                                {
                                    headers = null;
                                }
                                var body = stateChangeConverted.body;
                                if (stateChangeConverted.body.Length == 0)
                                {
                                    body = null;
                                }
                                trackableGetXTokenCompletedWrapper.options = options;
                                trackableGetXTokenCompletedWrapper.headers = headers;
                                trackableGetXTokenCompletedWrapper.body = body;
                                trackableGetXTokenCompletedWrapper.RequestToken();
                                break;
                            }
                        case PARTY_XBL_STATE_CHANGE_TYPE.PARTY_XBL_STATE_CHANGE_TYPE_CREATE_LOCAL_CHAT_USER_COMPLETED:
                            {
                                var stateChangeConverted = (PARTY_XBL_CREATE_LOCAL_CHAT_USER_COMPLETED_STATE_CHANGE)stateChange;
                                _multiplayerManager.InternalCheckStateChangeSucceededOrLogErrorIfFailed(stateChangeConverted.result, stateChangeConverted.errorDetail);
                                break;
                            }
                        case PARTY_XBL_STATE_CHANGE_TYPE.PARTY_XBL_STATE_CHANGE_TYPE_LOCAL_CHAT_USER_DESTROYED:
                            break;
                        case PARTY_XBL_STATE_CHANGE_TYPE.PARTY_XBL_STATE_CHANGE_TYPE_REQUIRED_CHAT_PERMISSION_INFO_CHANGED:
                            {
                                var stateChangeConverted = (PARTY_XBL_REQUIRED_CHAT_PERMISSION_INFO_CHANGED_STATE_CHANGE)stateChange;
                                PARTY_XBL_CHAT_USER_HANDLE localXblChatUser = stateChangeConverted.localChatUser;
                                PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser = stateChangeConverted.targetChatUser;
                                UpdateChatPermissionInfoStart(localXblChatUser, targetXblChatUser);
                            }
                            break;
                        default:
                            break;
                    }
                }
                Succeeded(XBLSDK.PartyXblFinishProcessingStateChanges(_xblPartyHandle, _xblStateChanges));
            }
        }

        private void UpdateChatPermissionInfoStart(PARTY_XBL_CHAT_USER_HANDLE localXblChatUser, PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser)
        {
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:UpdateChatPermissionInfoStart()");

            if (IsReadyToSetChatPermissions(localXblChatUser, targetXblChatUser))
            {
                UpdateChatPermissionInfoComplete(localXblChatUser, targetXblChatUser);
            }
            else
            {
                _queuedUpdateChatPermissionsOp = new QueuedUpdateChatPermissionsOp()
                {
                    queued = true,
                    localXblChatUser = localXblChatUser,
                    targetXblChatUser = targetXblChatUser
                };
            }
        }

        private bool IsReadyToSetChatPermissions(PARTY_XBL_CHAT_USER_HANDLE localXblChatUser, PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser)
        {
            bool isReadyToSetChatPermissions = false;
            ulong localXuid;
            ulong targetXuid;
            if (!Succeeded(XBLSDK.PartyXblChatUserGetXboxUserId(localXblChatUser, out localXuid)))
            {
                return false;
            }
            if (!Succeeded(XBLSDK.PartyXblChatUserGetXboxUserId(targetXblChatUser, out targetXuid)))
            {
                return false;
            }

            isReadyToSetChatPermissions = GetPlayerByXuid(localXuid) != null &&
            GetPlayerByXuid(targetXuid) != null;

            return isReadyToSetChatPermissions;
        }

        private void UpdateChatPermissionInfoComplete(PARTY_XBL_CHAT_USER_HANDLE localXblChatUser, PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser)
        {
            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:UpdateChatPermissionInfoComplete()");

            // UpdateChatPermissionInfoComplete() is called when we are finally ready to set permissions, 
            // and thus the cached operation in _queuedUpdateChatPermissionsOp is no longer needed
            // (if it was created then localXblChatUser and targetXblChatUser from it will be used in this method
            // to set permissions). It needs to be reset to prevent unnecessary continuous re-entrance to this method.
            if (_queuedUpdateChatPermissionsOp.queued)
            {
                _queuedUpdateChatPermissionsOp = new QueuedUpdateChatPermissionsOp(); // reset _queuedUpdateChatPermissionsOp to its initial (default) state
            }

            ulong localXuid;
            ulong targetXuid;
            if (!Succeeded(XBLSDK.PartyXblChatUserGetXboxUserId(localXblChatUser, out localXuid)))
            {
                return;
            }
            if (!Succeeded(XBLSDK.PartyXblChatUserGetXboxUserId(targetXblChatUser, out targetXuid)))
            {
                return;
            }
            PlayFabPlayer localPlayer = GetPlayerByXuid(localXuid);
            PlayFabPlayer targetPlayer = GetPlayerByXuid(targetXuid);
            if (localPlayer == null || targetPlayer == null)
            {
                return;
            }

            PARTY_XBL_CHAT_PERMISSION_INFO chatPermissionInfo;
            if (Succeeded(XBLSDK.PartyXblLocalChatUserGetRequiredChatPermissionInfo(
                    localXblChatUser,
                    targetXblChatUser,
                    out chatPermissionInfo
                )))
            {
                _playerChatPermissions[targetPlayer] = chatPermissionInfo;
            }
            else
            {
                _playerChatPermissions.Remove(targetPlayer);
            }

            var permissionsQuery = GetChatPermissions(targetPlayer);

            Succeeded(PartyCSharpSDK.SDK.PartyChatControlSetPermissions(
                    localPlayer._chatControlHandle,
                    targetPlayer._chatControlHandle,
                    permissionsQuery
                ));

            bool mute = permissionsQuery != _CHAT_PERMISSIONS_ALL;
            foreach (var playerKeyPair in _multiplayerManager.RemotePlayers)
            {
                if (playerKeyPair.EntityKey.Id == targetPlayer.EntityKey.Id)
                {
                    playerKeyPair._mutedByPlatform = mute;
                    playerKeyPair.IsMuted = mute;
                    break;
                }
            }
        }

        private void TryCreateRemoteXboxLiveChatUser(PlayFabPlayer otherPlayer)
        {
            if (string.IsNullOrEmpty(otherPlayer._platformSpecificUserId))
            {
                _queuedCreateRemoteXboxLiveChatUserOps.Add(new QueuedCreateRemoteXboxLiveChatUserOp()
                {
                    otherPlayer = otherPlayer
                });
                return;
            }
            ulong xuid = Convert.ToUInt64(otherPlayer._platformSpecificUserId);

            PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:TryCreateRemoteXboxLiveChatUser(), XUID: " + xuid);

            if (Succeeded(XBLSDK.PartyXblCreateRemoteChatUser(
                    _xblPartyHandle,
                    xuid,
                    out otherPlayer._xblChatUserHandle
                )))
            {
                for (int i = 0; i < _queuedCreateRemoteXboxLiveChatUserOps.Count; i++)
                {
                    if (xuid == _queuedCreateRemoteXboxLiveChatUserOps[i].xuid)
                    {
                        _queuedCreateRemoteXboxLiveChatUserOps.RemoveAt(i);
                        break;
                    }
                }


            }
        }

        private PlayFabPlayer GetPlayerByXuid(ulong xuid)
        {
            if (xuid == 0)
            {
                return null;
            }

            // check local player first
            if (_multiplayerManager.LocalPlayer != null && !string.IsNullOrEmpty(_multiplayerManager.LocalPlayer._platformSpecificUserId))
            {
                ulong localPlayerXuid = Convert.ToUInt64(_multiplayerManager.LocalPlayer._platformSpecificUserId);
                if (localPlayerXuid == xuid)
                {
                    return _multiplayerManager.LocalPlayer;
                }
            }

            // then check all remote players
            PlayFabPlayer player = null;
            foreach (PlayFabPlayer currentPlayer in _multiplayerManager.RemotePlayers)
            {
                if (string.IsNullOrEmpty(currentPlayer._platformSpecificUserId))
                {
                    continue;
                }

                ulong currentPlayerXuid = Convert.ToUInt64(currentPlayer._platformSpecificUserId);
                if (currentPlayerXuid == xuid)
                {
                    player = currentPlayer;
                    break;
                }
            }
            return player;
        }

        // Helper methods
        private bool Succeeded(uint errorCode)
        {
            return _multiplayerManager.PartySucceeded(errorCode);
        }

        private bool HrSucceeded(int hresult)
        {
            return hresult >= 0;
        }

        private class PlayerComparator : IEqualityComparer<PlayFabPlayer>
        {
            public bool Equals(PlayFabPlayer a, PlayFabPlayer b)
            {
                return a.EntityKey.Id == b.EntityKey.Id ? true : false;
            }
            public int GetHashCode(PlayFabPlayer player)
            {
                return player.GetHashCode();
            }
        }

        private class TrackableGetXTokenCompletedWrapper
        {
            public PlayFabChatXboxLivePolicyProvider provider;
            public uint correlationId;
            public XUserGetTokenAndSignatureOptions options;
            public string method;
            public string url;
            public XUserGetTokenAndSignatureUtf16HttpHeader[] headers;
            public byte[] body;

            private bool _resolveIssueWithUIAttempted;

            public void RequestToken()
            {
                if (provider._xblLocalUserHandle == null)
                {
                    PlayFabMultiplayerManager._LogError(_ErrorMessageCouldNotGetXboxLiveToken);
                    CompleteRequest(false, null, null);
                    return;
                }

                XGR.SDK.XUserGetTokenAndSignatureUtf16Async(
                        provider._xblLocalUserHandle,
                        options,
                        method,
                        url,
                        headers,
                        body,
                        CompleteGetXToken
                        );
            }

            private void CompleteGetXToken(int hresult, XUserGetTokenAndSignatureUtf16Data tokenData)
            {
                PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:CompleteGetXToken(), hr: " + hresult);

                if (hresult >= 0)
                {
                    CompleteRequest(true, tokenData.Token, tokenData.Signature);
                }
                else if (hresult == _E_GAMEUSER_RESOLVE_USER_ISSUE_REQUIRED && !_resolveIssueWithUIAttempted)
                {
                    _resolveIssueWithUIAttempted = true;
                    XGR.SDK.XUserResolveIssueWithUiUtf16Async(
                            provider._xblLocalUserHandle,
                            url,
                            ResolveUserIssueWithUICompleted
                        );
                }
                else
                {
                    PlayFabMultiplayerManager._LogError(_ErrorMessageCouldNotGetXboxLiveToken);
                    CompleteRequest(false, null, null);
                }
            }

            private void ResolveUserIssueWithUICompleted(int hresult)
            {
                PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:ResolveUserIssueWithUICompleted(), hr: " + hresult);

                if (provider._xblPartyHandle == null)
                {
                    return;
                }

                if (provider.HrSucceeded(hresult))
                {
                    RequestToken();
                }
                else
                {
                    PlayFabMultiplayerManager._LogError(_ErrorMessageCouldNotGetXboxLiveToken);
                    CompleteRequest(false, null, null);
                }
            }

            private void CompleteRequest(bool succeeded, string token, string signature)
            {
                if (provider._xblPartyHandle == null)
                {
                    return;
                }

                provider.Succeeded(XBLSDK.PartyXblCompleteGetTokenAndSignatureRequest(
                    provider._xblPartyHandle,
                    correlationId,
                    succeeded,
                    token,
                    signature
                    ));
            }
        }

        private class QueuedCreateRemoteXboxLiveChatUserOp
        {
            public PlayFabPlayer otherPlayer;
            public ulong xuid;
        }

        private struct QueuedUpdateChatPermissionsOp
        {
            public bool queued;
            public PARTY_XBL_CHAT_USER_HANDLE localXblChatUser;
            public PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser;
        }

        private enum XboxPolicyMessageType : sbyte
        {
            Unset = 0,
            XuidExchangeRequest = 1,
            XuidExchangeResponse = 2
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct XboxPolicyXuidExchangeResponseMessage
        {
            XboxPolicyMessageType type;
            UInt16 xuid;
        }
    }
}
#endif