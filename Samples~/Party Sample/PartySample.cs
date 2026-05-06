using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PlayFab;
using PlayFab.Party;

/// <summary>
/// A PlayFab Party sample demonstrating the core concepts of the PlayFab Party networking SDK.
/// This sample shows how to initialize the SDK, log in a player, obtain the Party manager,
/// create and join a Party network, send chat and data messages, and properly clean up resources.
///
/// PlayFab Party provides real-time networking and voice/text chat capabilities.
/// The PlayFabMultiplayerManager is a singleton MonoBehaviour that manages the underlying
/// Party network. It must exist in the scene (via its prefab) before calling Get().
///
/// In a real multiplayer scenario you would:
/// 1. Have the host create a network and share the NetworkId with other players
///    (e.g., via PlayFab matchmaking, a lobby system, or a shared cloud script).
/// 2. Have joining players call JoinNetwork(networkId) with the shared NetworkId.
/// 3. Subscribe to OnRemotePlayerJoined / OnRemotePlayerLeft to track participants.
/// 4. Use OnChatMessageReceived / OnDataMessageReceived for real-time communication.
/// </summary>
public class PartySample : MonoBehaviour
{
    [Header("PlayFab Configuration")]
    [Tooltip("Your PlayFab Title ID - found in Game Manager on the PlayFab website")]
    public string TitleId = ""; // Replace with your actual Title ID

    [Header("Login Configuration")]
    [Tooltip("A unique identifier for a player")]
    public string CustomPlayerId = "UnityPartyPlayerId";

    // PlayFab Core/Services/Party APIs use an instance-based model.
    // This means you create and manage instances of these objects:

    /// <summary>
    /// Service Configuration - Contains connection settings for your PlayFab title.
    /// </summary>
    private PFServiceConfig _serviceConfig;

    /// <summary>
    /// Player Entity - Represents a logged-in player and provides access to player-specific APIs.
    /// </summary>
    private PFPlayerEntity _playerEntity;

    /// <summary>
    /// The PlayFab Party multiplayer manager singleton. Manages Party network lifecycle,
    /// messaging, and voice chat. This is a MonoBehaviour that must exist in the scene.
    /// </summary>
    private PlayFabMultiplayerManager _multiplayerManager;

    private bool _cleanedUp = false;

#if !UNITY_EDITOR && (UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT)
    private bool _xGameRuntimeInitialized = false;
#endif

    async void Start()
    {
        Debug.Log("=== PlayFab Party Sample Started ===");

        // Validate configuration before proceeding
        if (string.IsNullOrEmpty(TitleId))
        {
            Debug.LogError("TitleId is required! Please set your PlayFab Title ID in the inspector.");
            return;
        }

        // Execute the full Party flow
        bool success = await ExecutePartyFlow();

        if (success)
        {
            Debug.Log("=== Party Sample Completed Successfully ===");
        }
        else
        {
            Debug.LogError("=== Party Sample Failed ===");
        }

        await LogoutAndCleanup();
    }

    /// <summary>
    /// Executes the complete Party flow:
    /// Initialize → Login → Get Party Manager → Set Player → Create &amp; Join Network →
    /// Send Messages → Leave Network → Cleanup
    /// </summary>
    private async Task<bool> ExecutePartyFlow()
    {
        // Step 1: Initialize the PlayFab SDK
        if (!InitializePlayFabServices())
            return false;

        _cleanedUp = false;

        // Step 2: Create a service configuration for your title
        if (!CreateServiceConfiguration())
            return false;

        // Step 3: Log in the player
        if (!await LoginPlayer())
            return false;

        // Step 4: Get the PlayFab Party multiplayer manager
        if (!GetPartyManager())
            return false;

        // Step 5: Register the logged-in player with the Party manager
        SetPlayerOnManager();

        // Step 6: Create and join a Party network
        if (!await CreateAndJoinNetwork())
            return false;

        // Step 7: Send a chat message to all players on the network
        SendSampleChatMessage();

        // Step 8: Send a data message to all players on the network
        SendSampleDataMessage();

        // Allow time for messages to be processed by the Party network
        await Task.Delay(2000);

        // Step 9: Leave the network
        if (!await LeaveNetwork())
            return false;

        return true;
    }

    //
    // Step 1: Initialize PlayFab Services
    //

    /// <summary>
    /// Initializes PlayFab Services. This must be called before using any PlayFab functionality.
    /// </summary>
    private bool InitializePlayFabServices()
    {
        Debug.Log("Step 1: Initializing PlayFab Services...");

#if !UNITY_EDITOR && (UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT)
        if (!_xGameRuntimeInitialized)
        {
            int xGameRuntimeResult = PlayFab.XGameRuntime.Initialize();
            if (HRESULT.Failed(xGameRuntimeResult))
            {
                Debug.LogError($"Failed to initialize XGameRuntime: 0x{xGameRuntimeResult:X8}");
                return false;
            }

            _xGameRuntimeInitialized = true;
        }
#endif

        PFResult initResult = PFServices.Initialize();

        if (CheckForError(initResult, "Failed to initialize PlayFab services"))
        {
            // Special case: if already initialized, that's usually okay
            if (initResult.HResult == HRESULT.E_PF_CORE_ALREADY_INITIALIZED ||
                initResult.HResult == HRESULT.E_PF_SERVICES_ALREADY_INITIALIZED)
            {
                Debug.LogWarning("PlayFab services were already initialized - continuing...");
                return true;
            }
            return false;
        }

        Debug.Log("PlayFab Services initialized successfully");
        return true;
    }

    //
    // Step 2: Create Service Configuration
    //

    /// <summary>
    /// Creates a service configuration that tells the SDK which PlayFab title to connect to.
    /// </summary>
    private bool CreateServiceConfiguration()
    {
        Debug.Log("Step 2: Creating Service Configuration...");

        string apiEndpoint = $"https://{TitleId}.playfabapi.com";
        PFResult<PFServiceConfig> configResult = PFCore.CreateServiceConfig(apiEndpoint, TitleId);

        if (CheckForError(configResult, "Failed to create service configuration"))
            return false;

        _serviceConfig = configResult.Result;

        Debug.Log($"Service configuration created for Title ID: {TitleId}");
        return true;
    }

    //
    // Step 3: Login Player
    //

    /// <summary>
    /// Authenticates the player using Custom ID and creates a player entity.
    /// </summary>
    private async Task<bool> LoginPlayer()
    {
        Debug.Log("Step 3: Logging in player...");

        var loginRequest = new PFAuthenticationLoginWithCustomIDRequest
        {
            CustomId = CustomPlayerId,
            CreateAccount = true
        };

        Debug.Log($"Attempting login with Custom ID: {CustomPlayerId}");

        var playerResult = await _serviceConfig.AuthenticationLoginWithCustomIDAsync(loginRequest);

        if (CheckForError(playerResult, "Failed to log in player"))
            return false;

        _playerEntity = playerResult.Result;

        if (_playerEntity.LoginResult.HasValue)
        {
            string playFabId = _playerEntity.LoginResult.Value.PlayFabId;
            DateTime lastLoginTime = _playerEntity.LoginResult.Value.LastLoginTime.HasValue
                ? new DateTime(1970, 1, 1).AddSeconds(_playerEntity.LoginResult.Value.LastLoginTime.Value)
                : DateTime.MinValue;

            Debug.Log($"Player logged in successfully!");
            Debug.Log($"PlayFab ID: {playFabId}");
            Debug.Log($"Last Login: {(lastLoginTime == DateTime.MinValue ? "First time login" : lastLoginTime.ToString())}");
            Debug.Log($"Account Status: {(_playerEntity.LoginResult.Value.NewlyCreated ? "Newly Created" : "Existing Account")}");
        }

        return true;
    }

    //
    // Step 4: Get Party Manager
    //

    /// <summary>
    /// Obtains the PlayFabMultiplayerManager singleton.
    /// The PlayFabMultiplayerManager prefab must already exist in the scene. The Get() method
    /// searches for an existing instance via FindObjectsByType. If no prefab is present it will
    /// log an error.
    ///
    /// To ensure the prefab exists you can either:
    ///   a) Add the PlayFabMultiplayerManager prefab to your scene in the editor, or
    ///   b) Instantiate it from Resources at runtime before calling Get():
    ///      var prefab = Resources.Load&lt;PlayFabMultiplayerManager&gt;("PlayFabMultiplayerManager");
    ///      Instantiate(prefab);
    /// </summary>
    private bool GetPartyManager()
    {
        Debug.Log("Step 4: Getting PlayFab Party Manager...");

        _multiplayerManager = PlayFabMultiplayerManager.Get();

        if (_multiplayerManager == null)
        {
            Debug.LogError(
                "PlayFabMultiplayerManager not found. " +
                "Ensure the PlayFabMultiplayerManager prefab is added to your scene.");
            return false;
        }

        // Enable verbose logging for this sample so we can see Party internals
        _multiplayerManager.LogLevel = PlayFabMultiplayerManager.LogLevelType.Verbose;

        // Subscribe to the error event so we can surface any Party errors
        _multiplayerManager.OnError += OnPartyError;

        Debug.Log($"Party Manager obtained. Current state: {_multiplayerManager.State}");
        return true;
    }

    //
    // Step 5: Set Player on Manager
    //

    /// <summary>
    /// Registers the authenticated player entity with the Party manager.
    /// This must be done after login and before any network operations (create, join, send).
    /// </summary>
    private void SetPlayerOnManager()
    {
        Debug.Log("Step 5: Setting player on Party Manager...");

        _multiplayerManager.SetPlayer(_playerEntity);

        // Configure local player defaults
        _multiplayerManager.LocalPlayer.IsMuted = false;

        Debug.Log("Player registered with Party Manager");
    }

    //
    // Step 6: Create and Join Network
    //

    /// <summary>
    /// Creates a new Party network and joins it. Uses a TaskCompletionSource to bridge
    /// the event-driven OnNetworkJoined callback into an awaitable Task.
    ///
    /// Once joined, the NetworkId is available. In a multiplayer game you would share
    /// this NetworkId with other players so they can call JoinNetwork(networkId).
    /// </summary>
    private async Task<bool> CreateAndJoinNetwork()
    {
        Debug.Log("Step 6: Creating and joining Party network...");

        var networkJoinedTcs = new TaskCompletionSource<string>();

        // Bridge the event callback to async/await
        PlayFabMultiplayerManager.OnNetworkJoinedHandler onJoined = null;
        PlayFabMultiplayerManager.OnErrorEventHandler onError = null;

        onJoined = (sender, networkId) =>
        {
            // Unsubscribe to avoid duplicate callbacks
            _multiplayerManager.OnNetworkJoined -= onJoined;
            _multiplayerManager.OnError -= onError;
            networkJoinedTcs.TrySetResult(networkId);
        };

        onError = (sender, args) =>
        {
            if (args.Type == PlayFabMultiplayerManagerErrorType.NetworkCreateError ||
                args.Type == PlayFabMultiplayerManagerErrorType.NetworkJoinError)
            {
                _multiplayerManager.OnNetworkJoined -= onJoined;
                _multiplayerManager.OnError -= onError;
                networkJoinedTcs.TrySetException(
                    new Exception($"Party network error ({args.Type}): {args.Message} (code: 0x{args.Code:X8})"));
            }
        };

        _multiplayerManager.OnNetworkJoined += onJoined;
        _multiplayerManager.OnError += onError;

        // Configure and create the network
        var networkConfig = new PlayFabNetworkConfiguration
        {
            MaxPlayerCount = 10
        };

        _multiplayerManager.CreateAndJoinNetwork(networkConfig);

        try
        {
            string networkId = await networkJoinedTcs.Task;

            Debug.Log($"Successfully joined Party network!");
            Debug.Log($"Network ID: {networkId}");
            Debug.Log($"Manager state: {_multiplayerManager.State}");

            // In a multiplayer scenario you would now share this networkId with other players.
            // For example:
            //   - Store it in PlayFab shared group data or title data
            //   - Send it through a matchmaking system
            //   - Use PlayFab Lobby to share it with matched players
            // Other players would then call: _multiplayerManager.JoinNetwork(networkId);

            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to create/join network: {ex.Message}");
            return false;
        }
    }

    //
    // Step 7: Send Chat Message
    //

    /// <summary>
    /// Sends a sample text chat message to all players on the network.
    /// Chat messages support text, speech-to-text, and text-to-speech via Party accessibility features.
    /// </summary>
    private void SendSampleChatMessage()
    {
        Debug.Log("Step 7: Sending chat message to all players...");

        string chatMessage = "Hello from the PlayFab Party sample!";
        _multiplayerManager.SendChatMessageToAllPlayers(chatMessage);

        Debug.Log($"Chat message sent: \"{chatMessage}\"");
    }

    //
    // Step 8: Send Data Message
    //

    /// <summary>
    /// Sends a sample binary data message to all players on the network.
    /// Data messages are used for game-specific payloads (positions, actions, state updates, etc.).
    /// </summary>
    private void SendSampleDataMessage()
    {
        Debug.Log("Step 8: Sending data message to all players...");

        byte[] dataPayload = Encoding.UTF8.GetBytes("SampleDataPayload_12345");
        _multiplayerManager.SendDataMessageToAllPlayers(dataPayload);

        Debug.Log($"Data message sent ({dataPayload.Length} bytes)");
    }

    //
    // Step 9: Leave Network
    //

    /// <summary>
    /// Leaves the Party network. Uses a TaskCompletionSource to bridge the event-driven
    /// OnNetworkLeft callback into an awaitable Task.
    /// </summary>
    private async Task<bool> LeaveNetwork()
    {
        Debug.Log("Step 9: Leaving Party network...");

        // If we're not connected, nothing to leave
        if (_multiplayerManager.State != PlayFabMultiplayerManagerState.ConnectedToNetwork)
        {
            Debug.Log("Not connected to a network - skipping leave");
            return true;
        }

        var networkLeftTcs = new TaskCompletionSource<bool>();

        PlayFabMultiplayerManager.OnNetworkLeftHandler onLeft = null;
        PlayFabMultiplayerManager.OnErrorEventHandler onError = null;

        onLeft = (sender, networkId) =>
        {
            _multiplayerManager.OnNetworkLeft -= onLeft;
            _multiplayerManager.OnError -= onError;
            networkLeftTcs.TrySetResult(true);
        };

        onError = (sender, args) =>
        {
            if (args.Type == PlayFabMultiplayerManagerErrorType.NetworkLeaveError)
            {
                _multiplayerManager.OnNetworkLeft -= onLeft;
                _multiplayerManager.OnError -= onError;
                networkLeftTcs.TrySetException(
                    new Exception($"Party leave error: {args.Message} (code: 0x{args.Code:X8})"));
            }
        };

        _multiplayerManager.OnNetworkLeft += onLeft;
        _multiplayerManager.OnError += onError;

        _multiplayerManager.LeaveNetwork();

        try
        {
            await networkLeftTcs.Task;
            Debug.Log("Successfully left Party network");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to leave network: {ex.Message}");
            return false;
        }
    }

    //
    // Event Handlers
    //

    /// <summary>
    /// Global error handler for Party errors. Logs error details for debugging.
    /// </summary>
    private void OnPartyError(object sender, PlayFabMultiplayerManagerErrorArgs args)
    {
        Debug.LogError($"Party Error [{args.Type}]: {args.Message} (code: 0x{args.Code:X8})");
    }

    //
    // Cleanup
    //

#pragma warning disable CS1998
    /// <summary>
    /// Logs out the player and cleans up all PlayFab and Party resources.
    /// </summary>
    private async Task LogoutAndCleanup()
    {
        if (_cleanedUp) return;

        _cleanedUp = true;

        Debug.Log("Cleaning up PlayFab Party resources...");

        // Unsubscribe from Party events
        if (_multiplayerManager != null)
        {
            _multiplayerManager.OnError -= OnPartyError;
        }

        // Dispose of the player entity if we have one
        if (_playerEntity != null)
        {
            Debug.Log("Disposing player entity...");
            _playerEntity.Dispose();
            _playerEntity = null;
        }

        // Dispose of the service configuration
        if (_serviceConfig != null)
        {
            Debug.Log("Disposing service configuration...");
            _serviceConfig.Dispose();
            _serviceConfig = null;
        }

// Temporary workaround only for play-in-editor while the native uninitialize -> reinitialize flow has an issue with the default queue
#if !UNITY_EDITOR
        // Uninitialize PlayFab services
        Debug.Log("Uninitializing PlayFab services...");
        var uninitResult = await PFServices.UninitializeAsync();

        if (!CheckForError(uninitResult, "There was an issue during cleanup, but continuing..."))
        {
            Debug.Log("PlayFab services uninitialized successfully");
        }

#if UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
        if (_xGameRuntimeInitialized)
        {
            PlayFab.XGameRuntime.Uninitialize();
            _xGameRuntimeInitialized = false;
            Debug.Log("XGameRuntime uninitialized successfully");
        }
#endif
#endif

        Debug.Log("=== Cleanup Complete ===");
    }
#pragma warning restore CS1998

    //
    // Utility
    //

    /// <summary>
    /// Helper method to check for errors and log them appropriately.
    /// Returns true if there was an error, false if successful.
    /// </summary>
    private bool CheckForError(PFResult result, string errorMessage)
    {
        if (result.Failed())
        {
            string errorCode = result.HResult.ToString("X8");
            Debug.LogError($"{errorMessage}. Error Code: 0x{errorCode}");
            return true;
        }
        return false;
    }
}
