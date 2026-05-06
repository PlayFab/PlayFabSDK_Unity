using PlayFab;
using PlayFab.Party;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Experimental.GraphView.GraphView;

#if MICROSOFT_GDK_SUPPORT
using Unity.XGamingRuntime;
#endif

namespace PartyTestApp
{
    public class TestAppLogic : MonoBehaviour
    {
        public InputField inputField;

#if MICROSOFT_GDK_SUPPORT
    private XUserHandle _xblLocalUserHandle;
#endif

        private ulong _userId;
#if MICROSOFT_GDK_SUPPORT
    private XUserHandle _user;
#endif
        private string _SCID;
#if MICROSOFT_GDK_SUPPORT
    private XblContextHandle _xblContext;
#endif
        private byte[] _body;

        PlayFabMultiplayerManager mpManager;

        EventSystem system;

        public Toggle UseP2P;

        private PFServiceConfig _serviceConfig;
        private PFServiceConfig _serviceConfigDuplicate;
        private PFTitleEntity _title;

        public string TitleId;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
        private bool _xGameRuntimeInitialized;
#endif
        private bool _playFabServicesInitialized;

        private enum PlayFabMultiplayerManagerMessageType : sbyte
        {
            Unset = 0,
            Game = 1,
            PolicyManager = 2
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct PlayFabMultiplayerManagerMessage
        {
            public PlayFabMultiplayerManagerMessageType type;
            public byte[] buffer;
        }

        private async Task<bool> TryInitServices(bool failOnAlreadyInitialized = false)
        {
            Debug.Log("Initializing PlayFab services...");
            if (!EnsureRuntimeInitialized())
            {
                await Cleanup();
                return false;
            }

            var initResult = PFServices.Initialize();
            if (CheckFailed(initResult, "Failed to initialize services"))
            {
                if (initResult.HResult == HRESULT.E_PF_CORE_ALREADY_INITIALIZED ||
                    initResult.HResult == HRESULT.E_PF_SERVICES_ALREADY_INITIALIZED)
                {
                    Debug.LogWarning("PlayFab already initialized");
                    _playFabServicesInitialized = true;
                    if (failOnAlreadyInitialized)
                    {
                        await Cleanup();
                        return false;
                    }
                }
                else
                {
                    await Cleanup();
                    return false;
                }
            }

            _playFabServicesInitialized = true;
            Debug.LogWarning("Initialized Services");
            return true;
        }

        private async Task<bool> TryCreateServiceConfig()
        {
            Debug.Log("Creating service config...");
            // Provide your titleId here
            var serviceConfigResult = PFCore.CreateServiceConfig($"https://{TitleId}.playfabapi.com", TitleId);
            if (CheckFailed(serviceConfigResult, "Failed to create service config"))
            {
                await Cleanup();
                return false;
            }

            _serviceConfig = serviceConfigResult.Result;
            Debug.LogWarning("Created service config");
            return true;
        }

        private async Task Cleanup()
        {

            if (_serviceConfig is not null)
            {
                _serviceConfig.Dispose();
                _serviceConfig = null;
            }
            if (_serviceConfigDuplicate is not null)
            {
                _serviceConfigDuplicate.Dispose();
                _serviceConfigDuplicate = null;
            }
            if (_title is not null)
            {
                _title.Dispose();
                _title = null;
            }

            if (_playFabServicesInitialized)
            {
                Debug.Log("Cleaning up PlayFab services...");
                var result = await PFServices.UninitializeAsync();

                if (HRESULT.Failed(result.HResult))
                {
                    string errorCode = result.HResult.ToString("X8");
                    Debug.LogError($"Failed to uninitialize services: 0x{errorCode}");
                }
                else
                {
                    _playFabServicesInitialized = false;
                    Debug.LogWarning("Uninitialized Services");
                }
            }
            else
            {
                Debug.Log("PlayFab services were not initialized; skipping PlayFab services uninitialize.");
            }

            UninitializeRuntime();
            return;
        }

        private bool CheckFailed(PFResult result, string errorMessage)
        {
            if (result.Failed())
            {
                string errorCode = result.HResult.ToString("X8");
                Debug.LogError($"{errorMessage}: 0x{errorCode}");
                return true;
            }

            return false;
        }

        private async Task<bool> TryLoginWithCustomId()
        {
            PFAuthenticationLoginWithCustomIDRequest loginRequest = new()
            {
                CreateAccount = true,
                CustomId = "PartySampleCustomId_" +  UnityEngine.Random.value.ToString()
            };

            Debug.Log("Logging in with custom ID...");
            var loginResult = await _serviceConfig.AuthenticationLoginWithCustomIDAsync(loginRequest);
            if (CheckFailed(loginResult, "Failed to login with"))
            {
                await Cleanup();
                return false;
            }

            PFPlayerEntity player = loginResult.Result;
            var mpManager = PlayFabMultiplayerManager.Get();
            mpManager.SetPlayer(player);
            
            var id = player.LoginResult.Value.PlayFabId;
            var lastLoginTime = new DateTime(1970, 1, 1).AddSeconds(player.LoginResult.Value.LastLoginTime ?? 0);
            Debug.LogWarning($"Login successful for ID = {id} with LastLoginTime = {lastLoginTime}");
            return true;
        }

        // Start is called before the first frame update
        async void Start()
        {
            await Cleanup();

            if (!await TryInitServices()) return;
            if (!await TryCreateServiceConfig()) return;
            if (!await TryLoginWithCustomId()) return;

            var mpManager = PlayFabMultiplayerManager.Get();
            mpManager.LogLevel = PlayFabMultiplayerManager.LogLevelType.Verbose;

            mpManager.OnNetworkJoined += MpManager_OnNetworkJoined1;
            mpManager.OnNetworkLeft += MpManager_OnNetworkLeft;
            mpManager.OnNetworkChanged += MpManager_OnNetworkChanged;

            mpManager.LocalPlayer.IsMuted = false;
            mpManager.LocalPlayer.VoiceLevel = 0.1f;
            var languageCode = mpManager.LocalPlayer.LanguageCode;
            var platformSpecificUserID = mpManager.LocalPlayer.PlatformSpecificUserId;
            var networkId = mpManager.NetworkId;

#if MICROSOFT_GDK_SUPPORT && !UNITY_EDITOR
            // Uncomment these lines if you want to test text to speech
            //mpManager.LocalPlayer.TextToSpeechMode = AccessibilityMode.PlatformDefault;
            //mpManager.LocalPlayer.SpeechToTextMode = AccessibilityMode.PlatformDefault;
#endif

            system = EventSystem.current;
        }

        private void OnNetworkJoined(object sender, string networkId)
        {
            // Grab the Network ID and pass it to other clients.
        }

        public void LogoutAllUsers()
        {
            
        }

        private void MpManager_OnNetworkChanged(object sender, string newNetworkId)
        {
            Debug.Log("Network changed: " + newNetworkId);
        }

        private void MpManager_OnNetworkLeft(object sender, string networkId)
        {
            Debug.Log("Left Network");
        }

        private void MpManager_OnNetworkJoined1(object sender, string networkID)
        {
            mpManager = PlayFabMultiplayerManager.Get();
            mpManager.LocalPlayer.IsMuted = false;
            mpManager.LocalPlayer.VoiceLevel = 1f;
            var languageCode = mpManager.LocalPlayer.LanguageCode;
            var platformSpecificUserID = mpManager.LocalPlayer.PlatformSpecificUserId;
            mpManager.OnChatMessageReceived += LocalPlayer_OnChatMessageReceived1;
            mpManager.OnDataMessageReceived += LocalPlayer_OnDataMessageReceived1;
        }

        private void LocalPlayer_OnDataMessageReceived1(object sender, PlayFabPlayer from, byte[] buffer)
        {
        }

        private void LocalPlayer_OnChatMessageReceived1(object sender, PlayFabPlayer from, string message, ChatMessageType type)
        {
        }

        public void InitializeRuntime()
        {
            EnsureRuntimeInitialized();
        }

        private bool EnsureRuntimeInitialized()
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
            // Windows/GDK builds and Windows Editor Play Mode must initialize XGameRuntime before any PlayFab API.
            if (_xGameRuntimeInitialized)
            {
                return true;
            }

            int hr = PlayFab.XGameRuntime.Initialize();
            if (HRESULT.Failed(hr))
            {
                Debug.LogError($"Failed to initialize XGameRuntime: 0x{hr:X8}");
                return false;
            }

            _xGameRuntimeInitialized = true;

#if MICROSOFT_GDK_SUPPORT
            int hResult = SDK.CreateDefaultTaskQueue();
            if (HR.FAILED(hResult))
            {
                Debug.Log($"FAILED: XTaskQueueCreate, HResult: 0x{hResult:X}");
                UninitializeRuntime();
                return false;
            }
            StartCoroutine(DispatchGDKTaskQueue());
#endif
            Debug.LogWarning("Initialized XGameRuntime");
#endif
            return true;
        }

        private void UninitializeRuntime()
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
            if (!_xGameRuntimeInitialized)
            {
                return;
            }

            PlayFab.XGameRuntime.Uninitialize();
            _xGameRuntimeInitialized = false;
            Debug.LogWarning("Uninitialized XGameRuntime");
#endif
        }

        public void AddUser()
        {
#if MICROSOFT_GDK_SUPPORT
        XUserAddOptions options = XUserAddOptions.AddDefaultUserSilently; // could also allow guests, or silently
        SDK.XUserAddAsync(options, AddUserComplete);
#endif
        }

#if MICROSOFT_GDK_SUPPORT
    private void AddUserComplete(int hresult, XUserHandle userHandle)
    {
        var foo = hresult;
        LogHR("add user completed", hresult);
        if (hresult >= 0)
        {
            XUserAddOptions options = XUserAddOptions.None;
            SDK.XUserAddAsync(options, SignInSilentlyComplete);
        }
    }
#endif

#if MICROSOFT_GDK_SUPPORT
    private void SignInSilentlyComplete(int hresult, XUserHandle userHandle)
    {
        // retrieve some details about this user
        string gamertag;
        SDK.XUserGetGamertag(userHandle, XUserGamertagComponent.UniqueModern, out gamertag);
        bool hasPriviledge = false;
        XUserPrivilegeDenyReason reason;
        SDK.XUserCheckPrivilege(userHandle, XUserPrivilegeOptions.AllUsers, XUserPrivilege.Communications, out hasPriviledge, out reason);
        SDK.XUserGetId(userHandle, out _userId);
        _user = userHandle;

        List<byte> bodyList = new List<byte>() { 0x0, 0x1, 0x2, 0x3 };
        _body = bodyList.ToArray();
    }
#endif

        protected void LogHR(string s, int hr)
        {
            string hrString = string.Format("{0} -- hr=0x{1}", s, hr.ToString("X8"));
            Debug.Log(string.Format("{0} -- hr=0x{1}", s, hr.ToString("X8")));
        }

        public void CreateAndJoinNetwork()
        {
            mpManager = PlayFabMultiplayerManager.Get();
            PlayFabNetworkConfiguration config = new PlayFabNetworkConfiguration();
            config.MaxPlayerCount = 10;
            if (!UseP2P.isOn)
            {
                config.DirectPeerConnectivityOptions = PartyCSharpSDK.PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS.PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS_NONE;
            }
            // Create and join a network
            mpManager.CreateAndJoinNetwork(config);
            mpManager.OnNetworkJoined += MpManager_OnNetworkJoined;
            mpManager.OnDataMessageReceived += LocalPlayer_OnDataMessageReceived;
            mpManager.OnChatMessageReceived += LocalPlayer_OnChatMessageReceived;
        }

        private void LocalPlayer_OnChatMessageReceived(object sender, PlayFabPlayer from, string message, ChatMessageType type)
        {
            Debug.Log("Message" + message + ", Type: " + type);
        }

        public void JoinNetwork()
        {
            mpManager = PlayFabMultiplayerManager.Get();
#if PARTY_CHAT_SAVE_NETWORK_DESCRIPTOR_TO_CLOUD
            GetDescriptorAndJoinNetwork(PartyCSharpSDK.PartyConstants.c_partyChatRoom);
#else
            string networkID = inputField.text;
            mpManager.JoinNetwork(networkID);
#endif
            mpManager.OnNetworkJoined += MpManager_OnNetworkJoined;
            mpManager.OnDataMessageReceived += LocalPlayer_OnDataMessageReceived;
        }

        public void LeaveNetwork()
        {
            var pfMM = PlayFabMultiplayerManager.Get();
            pfMM.LeaveNetwork();
        }

        public void ResetParty()
        {
            var mpManager = PlayFabMultiplayerManager.Get();
            mpManager.ResetParty();
        }

        public void Suspend()
        {
            var mpManager = PlayFabMultiplayerManager.Get();
            mpManager.Suspend();
        }

        public void Resume()
        {
            var mpManager = PlayFabMultiplayerManager.Get();
            mpManager.Resume();
        }

        private void LocalPlayer_OnDataMessageReceived(object sender, PlayFabPlayer from, byte[] buffer)
        {
            Debug.Log("Data message recieved: " + buffer);
        }

        private void MpManager_OnNetworkJoined(object sender, string networkID)
        {
#if PARTY_CHAT_SAVE_NETWORK_DESCRIPTOR_TO_CLOUD
            // If we joined successfully then we update the network Id irrespective if its from CreateAndJoin or JoinNetwork
            SetDescriptor(PartyCSharpSDK.PartyConstants.c_partyChatRoom, networkID);
#endif
            inputField.text = networkID;
            Debug.Log(networkID);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("XButton"))
            {
                if (EnsureRuntimeInitialized())
                {
                    AddUser();
                    PlayFabMultiplayerManager.Get().LogLevel = PlayFabMultiplayerManager.LogLevelType.Verbose;
                }
            }
            else if (Input.GetButtonDown("YButton"))
            {
                JoinNetwork();
            }
            else if (Input.GetButtonDown("BButton"))
            {
                LeaveNetwork();
            }
            else if (Input.GetButtonDown("MenuButton"))
            {
                // Get the networkID from a file
                string networkID = File.ReadAllText("D:\\networkid.txt");
                inputField.text = networkID;
            }
            else if (Input.GetButtonDown("LBumper"))
            {
                byte[] buffer = Encoding.ASCII.GetBytes("HelloXboxDataMessage");
                PlayFabMultiplayerManager.Get().SendDataMessageToAllPlayers(buffer);
            }
            else if (Input.GetButtonDown("RBumper"))
            {
                PlayFabMultiplayerManager.Get().SendChatMessageToAllPlayers("HelloXboxChatMessage");
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
               //[MEM] - login i guess?
            }
        }

#if MICROSOFT_GDK_SUPPORT
       private static IEnumerator DispatchGDKTaskQueue()
        {
            while (true)
            {
                SDK.XTaskQueueDispatch(0);
                yield return null;
            }
        }
#endif

#if PARTY_CHAT_SAVE_NETWORK_DESCRIPTOR_TO_CLOUD
        [Serializable]
        private class GetNetworkDescriptorResult
        {
            public GetNetworkDescriptorResultDetails network;
        }

        [Serializable]
        private class GetNetworkDescriptorResultDetails
        {
            public string Value;
            public string LastUpdated;
            public string Permission;
        }

        private void SetDescriptor(string key, string descriptor)
        {
            PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
            {
                FunctionName = "save_network_descriptor",
                FunctionParameter = new { roomId = key, networkDescriptor = descriptor },
                GeneratePlayStreamEvent = true,
            }, SetDescriptorCallback, SetDescriptorErrorCallback);
        }

        private void SetDescriptorErrorCallback(PlayFabError obj)
        {
            Debug.Log("SetDescriptorErrorCallback()");
        }

        private void SetDescriptorCallback(ExecuteCloudScriptResult obj)
        {
            Debug.Log("SetDescriptorCallback()");
            if (obj.Error != null)
            {
                Debug.Log("obj.Error " + obj.Error.Message.ToString());
                Debug.Log("obj.StackTrace " + obj.Error.StackTrace.ToString());
            }
            if (obj.FunctionResult != null)
            {
                Debug.Log("obj.FunctionResult " + obj.FunctionResult.ToString());
            }
        }

        public void GetDescriptorAndJoinNetwork(string key)
        {
            PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
            {
                FunctionName = "get_network_descriptor",
                FunctionParameter = new { roomId = key },
                GeneratePlayStreamEvent = true,
            }, GetDescriptorCallback, GetDescriptorErrorCallback);
        }

        private void GetDescriptorErrorCallback(PlayFabError obj)
        {
            Debug.Log("GetDescriptorErrorCallback()");
        }

        private void GetDescriptorCallback(ExecuteCloudScriptResult obj)
        {
            Debug.Log("GetDescriptorCallback()");
            if (obj.Error != null)
            {
                Debug.Log("obj.Error " + obj.Error.Message.ToString());
                Debug.Log("obj.StackTrace " + obj.Error.StackTrace.ToString());
            }
            if (obj.FunctionResult != null)
            {
                Debug.Log("obj.FunctionResult " + obj.FunctionResult.ToString());
            }
            else
            {
                return;
            }

            var invitationDescriptor = JsonUtility.FromJson<GetNetworkDescriptorResult>(obj.FunctionResult.ToString());
            PlayFabMultiplayerManager.Get().JoinNetwork(invitationDescriptor.network.Value.ToString());
        }
#endif
    }

    public class Player
    {
        public PFEntityKey entityKey;
        public string name;
        public PlayerListItem playerListItem;
        public GameObject playerGO;
        public PlayFabPlayer pfPlayer;
    }
}
