using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using PlayFab;
using PlayFab.Multiplayer;

/// <summary>
/// A PlayFab Multiplayer Lobby sample demonstrating the core lobby lifecycle.
/// This sample shows how to initialize the SDK, log in a player, create a lobby,
/// read and update lobby properties, search for lobbies, and properly clean up.
///
/// The PlayFab Multiplayer API is event-driven: you subscribe to events on the
/// <see cref="PlayFabMultiplayer"/> static class, call methods to start operations,
/// then handle results in event callbacks. This sample uses <see cref="TaskCompletionSource{T}"/>
/// to bridge the event-driven API into an async/await flow for clarity.
///
/// In a real game you would keep event handlers registered for the lifetime of
/// your multiplayer session and react to lobby updates, member joins/leaves, and
/// disconnections as they occur rather than completing a linear sequence.
/// </summary>
public class MultiplayerSample : MonoBehaviour
{
    [Header("PlayFab Configuration")]
    [Tooltip("Your PlayFab Title ID - found in Game Manager on the PlayFab website")]
    public string TitleId = ""; // Replace with your actual Title ID

    [Header("Login Configuration")]
    [Tooltip("A unique identifier for a player")]
    public string CustomPlayerId = "UnityMultiplayerPlayerId";

    // PlayFab Core/Services APIs use an instance-based model.
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
    /// The lobby instance created during this sample run.
    /// </summary>
    private Lobby _lobby;

    /// <summary>
    /// Tracks whether cleanup has already been performed to avoid double-cleanup.
    /// </summary>
    private bool _cleanedUp = false;

    /// <summary>
    /// The event processor component that drives PlayFabMultiplayer state-change processing
    /// each frame. It is added dynamically so no prefab setup is required.
    /// </summary>
    private PlayfabMultiplayerEventProcessor _eventProcessor;

    // ------------------------------------------------------------------
    // TaskCompletionSource instances used to bridge event callbacks to
    // async/await. Each one is set when the corresponding event fires.
    // ------------------------------------------------------------------
    private TaskCompletionSource<(Lobby lobby, int result)> _createLobbyTcs;
    private TaskCompletionSource<(Lobby lobby, int result)> _postUpdateTcs;
    private TaskCompletionSource<(IList<LobbySearchResult> results, int result)> _findLobbiesTcs;
    private TaskCompletionSource<bool> _leaveLobbyTcs;

    async void Start()
    {
        Debug.Log("=== PlayFab Multiplayer Lobby Sample Started ===");

        // Validate configuration before proceeding
        if (string.IsNullOrEmpty(TitleId))
        {
            Debug.LogError("TitleId is required! Please set your PlayFab Title ID in the inspector.");
            return;
        }

        // Execute the full lobby lifecycle
        bool success = await ExecuteMultiplayerFlow();

        if (success)
        {
            Debug.Log("=== Multiplayer Lobby Sample Completed Successfully ===");
        }
        else
        {
            Debug.LogError("=== Multiplayer Lobby Sample Failed ===");
        }

        await CleanupAll();
    }

    // ==================================================================
    // Main Flow
    // ==================================================================

    /// <summary>
    /// Executes the complete multiplayer lobby flow:
    /// Initialize → Login → Init Multiplayer → Create Lobby → Read Properties →
    /// Update Properties → Find Lobbies → Leave → Cleanup
    /// </summary>
    private async Task<bool> ExecuteMultiplayerFlow()
    {
        // Step 1: Initialize PlayFab Services
        if (!InitializePlayFabServices())
            return false;

        _cleanedUp = false;

        // Step 2: Create a service configuration for your title
        if (!CreateServiceConfiguration())
            return false;

        // Step 3: Log in the player
        if (!await LoginPlayer())
            return false;

        // Step 4: Initialize the Multiplayer subsystem
        if (!InitializeMultiplayer())
            return false;

        // Step 5: Create and join a lobby
        if (!await CreateAndJoinLobby())
            return false;

        // Step 6: Read lobby properties
        ReadLobbyProperties();

        // Step 7: Update lobby properties
        if (!await UpdateLobbyProperties())
            return false;

        // Step 8: Find lobbies
        await FindLobbies();

        // Step 9: Leave the lobby
        await LeaveLobby();

        return true;
    }

    // ==================================================================
    // Step 1: Initialize PlayFab Services
    // ==================================================================

    /// <summary>
    /// Initializes PlayFab Core and Services.
    /// This must be called before using any PlayFab functionality.
    /// </summary>
    private bool InitializePlayFabServices()
    {
        Debug.Log("Step 1: Initializing PlayFab Services...");

        PFResult initResult = PFServices.Initialize();

        if (CheckForError(initResult, "Failed to initialize PlayFab services"))
        {
            // Already-initialized is acceptable when re-running in the editor
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

    // ==================================================================
    // Step 2: Create Service Configuration
    // ==================================================================

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

    // ==================================================================
    // Step 3: Login Player
    // ==================================================================

    /// <summary>
    /// Authenticates the player using Custom ID and creates a player entity.
    /// In a production game you would use platform-specific authentication
    /// (e.g. LoginWithXUser, LoginWithSteam).
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

        Debug.Log("Player logged in successfully!");

        if (_playerEntity.LoginResult.HasValue)
        {
            Debug.Log($"PlayFab ID: {_playerEntity.LoginResult.Value.PlayFabId}");
            Debug.Log($"Account Status: {(_playerEntity.LoginResult.Value.NewlyCreated ? "Newly Created" : "Existing Account")}");
        }

        return true;
    }

    // ==================================================================
    // Step 4: Initialize Multiplayer
    // ==================================================================

    /// <summary>
    /// Initializes the PlayFab Multiplayer library and sets up the event processor.
    /// The <see cref="PlayfabMultiplayerEventProcessor"/> component calls
    /// <see cref="PlayFabMultiplayer.ProcessLobbyStateChanges"/> and
    /// <see cref="PlayFabMultiplayer.ProcessMatchmakingStateChanges"/> every frame,
    /// which in turn fires the On* events your scripts subscribe to.
    /// </summary>
    private bool InitializeMultiplayer()
    {
        Debug.Log("Step 4: Initializing PlayFab Multiplayer...");

        // The PlayfabMultiplayerEventProcessor will call PlayFabMultiplayer.Initialize
        // in its Awake() if not already initialized, but we add it dynamically here
        // so that no manual prefab setup is required.
        if (_eventProcessor == null)
        {
            // Create a persistent GameObject to host the event processor.
            // DontDestroyOnLoad is handled inside PlayfabMultiplayerEventProcessor.Awake().
            var processorGo = new GameObject("PlayFabMultiplayerEventProcessor");
            _eventProcessor = processorGo.AddComponent<PlayfabMultiplayerEventProcessor>();
            _eventProcessor.PlayFabTitleID = TitleId;
        }

        // Register event handlers so we can bridge callbacks to async/await
        RegisterEventHandlers();

        Debug.Log("PlayFab Multiplayer initialized and event handlers registered");
        return true;
    }

    // ==================================================================
    // Step 5: Create and Join a Lobby
    // ==================================================================

    /// <summary>
    /// Creates a new lobby and joins it as the owner.
    /// The result arrives asynchronously via <see cref="PlayFabMultiplayer.OnLobbyCreateAndJoinCompleted"/>.
    /// </summary>
    private async Task<bool> CreateAndJoinLobby()
    {
        Debug.Log("Step 5: Creating and joining a lobby...");

        // Configure the lobby settings
        var createConfig = new LobbyCreateConfiguration
        {
            MaxMemberCount = 8,
            OwnerMigrationPolicy = LobbyOwnerMigrationPolicy.Automatic,
            AccessPolicy = LobbyAccessPolicy.Public,
            // Search properties are visible to non-members and can be used to filter search results.
            // In a real game you might store game mode, map name, region, etc.
            SearchProperties = new Dictionary<string, string>
            {
                { "string_key1", "SampleGameMode" }
            },
            // Lobby properties are visible only to members.
            LobbyProperties = new Dictionary<string, string>
            {
                { "GameState", "WaitingForPlayers" },
                { "MapName", "SampleArena" }
            }
        };

        // Member-specific properties for the creating player
        var joinConfig = new LobbyJoinConfiguration
        {
            MemberProperties = new Dictionary<string, string>
            {
                { "DisplayName", "SamplePlayer" },
                { "ReadyState", "NotReady" }
            }
        };

        // Prepare a TaskCompletionSource so we can await the event callback
        _createLobbyTcs = new TaskCompletionSource<(Lobby, int)>();

        // Start the create-and-join operation.
        // The Lobby object is returned immediately but is not yet usable
        // until the OnLobbyCreateAndJoinCompleted event fires with a success result.
        _lobby = PlayFabMultiplayer.CreateAndJoinLobby(_playerEntity, createConfig, joinConfig);

        Debug.Log("CreateAndJoinLobby called - waiting for completion event...");

        // Wait for the event callback to complete
        var (lobby, result) = await _createLobbyTcs.Task;

        if (result != 0)
        {
            Debug.LogError($"Failed to create and join lobby. Error: 0x{result:X8}");
            _lobby = null;
            return false;
        }

        _lobby = lobby;
        Debug.Log($"Lobby created and joined successfully! Lobby ID: {_lobby.Id}");
        Debug.Log($"Connection String: {_lobby.ConnectionString}");

        return true;
    }

    // ==================================================================
    // Step 6: Read Lobby Properties
    // ==================================================================

    /// <summary>
    /// Reads and logs the current lobby state: owner, members, search properties,
    /// lobby properties, and member properties.
    /// </summary>
    private void ReadLobbyProperties()
    {
        Debug.Log("Step 6: Reading lobby properties...");

        if (_lobby == null)
        {
            Debug.LogWarning("No lobby to read properties from.");
            return;
        }

        // --- Owner ---
        if (_lobby.TryGetOwner(out PFEntityKey owner))
        {
            Debug.Log($"  Owner: {owner.Id} (Type: {owner.Type})");
        }
        else
        {
            Debug.Log("  Owner: (none)");
        }

        // --- Basic settings ---
        Debug.Log($"  Max Members: {_lobby.MaxMemberCount}");
        Debug.Log($"  Access Policy: {_lobby.AccessPolicy}");
        Debug.Log($"  Owner Migration Policy: {_lobby.OwnerMigrationPolicy}");
        Debug.Log($"  Membership Lock: {_lobby.MembershipLock}");

        // --- Members ---
        IList<PFEntityKey> members = _lobby.GetMembers();
        Debug.Log($"  Current Members ({members.Count}):");
        foreach (PFEntityKey member in members)
        {
            Debug.Log($"    - {member.Id} (Type: {member.Type})");

            // Read per-member properties
            IDictionary<string, string> memberProps = _lobby.GetMemberProperties(member);
            foreach (var kvp in memberProps)
            {
                Debug.Log($"      [{kvp.Key}] = {kvp.Value}");
            }
        }

        // --- Search Properties ---
        IDictionary<string, string> searchProps = _lobby.GetSearchProperties();
        Debug.Log($"  Search Properties ({searchProps.Count}):");
        foreach (var kvp in searchProps)
        {
            Debug.Log($"    [{kvp.Key}] = {kvp.Value}");
        }

        // --- Lobby Properties ---
        IDictionary<string, string> lobbyProps = _lobby.GetLobbyProperties();
        Debug.Log($"  Lobby Properties ({lobbyProps.Count}):");
        foreach (var kvp in lobbyProps)
        {
            Debug.Log($"    [{kvp.Key}] = {kvp.Value}");
        }
    }

    // ==================================================================
    // Step 7: Update Lobby Properties
    // ==================================================================

    /// <summary>
    /// Demonstrates updating both lobby-wide properties (as owner) and
    /// the local member's own properties in a single <see cref="Lobby.PostUpdate"/> call.
    /// The result arrives via <see cref="PlayFabMultiplayer.OnLobbyPostUpdateCompleted"/>.
    /// </summary>
    private async Task<bool> UpdateLobbyProperties()
    {
        Debug.Log("Step 7: Updating lobby properties...");

        if (_lobby == null)
        {
            Debug.LogWarning("No lobby to update.");
            return false;
        }

        // Build the lobby-wide data update (only the owner can do this)
        var lobbyUpdate = new LobbyDataUpdate
        {
            LobbyProperties = new Dictionary<string, string>
            {
                { "GameState", "InProgress" },
                { "RoundNumber", "1" }
            },
            SearchProperties = new Dictionary<string, string>
            {
                { "string_key1", "SampleGameMode_Round1" }
            }
        };

        // Build updated member properties for the local player
        var memberProperties = new Dictionary<string, string>
        {
            { "ReadyState", "Ready" },
            { "Score", "0" }
        };

        _postUpdateTcs = new TaskCompletionSource<(Lobby, int)>();

        // PostUpdate sends both lobby-level and member-level changes in one call
        _lobby.PostUpdate(_playerEntity, lobbyUpdate, memberProperties);

        Debug.Log("PostUpdate called - waiting for completion event...");

        var (lobby, result) = await _postUpdateTcs.Task;

        if (result != 0)
        {
            Debug.LogError($"Failed to update lobby. Error: 0x{result:X8}");
            return false;
        }

        Debug.Log("Lobby properties updated successfully!");

        // Re-read to confirm the updates took effect
        ReadLobbyProperties();

        return true;
    }

    // ==================================================================
    // Step 8: Find Lobbies
    // ==================================================================

    /// <summary>
    /// Searches for public lobbies using an OData-like filter.
    /// The results arrive via <see cref="PlayFabMultiplayer.OnLobbyFindLobbiesCompleted"/>.
    /// In a real game you would use this to populate a server browser or
    /// automatic matchmaking UI.
    /// </summary>
    private async Task FindLobbies()
    {
        Debug.Log("Step 8: Searching for lobbies...");

        var searchConfig = new LobbySearchConfiguration
        {
            // Filter to lobbies whose string_key1 starts with "SampleGameMode"
            FilterString = "string_key1 eq 'SampleGameMode_Round1'",
            ClientSearchResultCount = 10
        };

        _findLobbiesTcs = new TaskCompletionSource<(IList<LobbySearchResult>, int)>();

        PlayFabMultiplayer.FindLobbies(_playerEntity, searchConfig);

        Debug.Log("FindLobbies called - waiting for completion event...");

        var (searchResults, result) = await _findLobbiesTcs.Task;

        if (result != 0)
        {
            Debug.LogError($"FindLobbies failed. Error: 0x{result:X8}");
            return;
        }

        Debug.Log($"Found {searchResults.Count} lobby(ies):");
        foreach (LobbySearchResult sr in searchResults)
        {
            Debug.Log($"  Lobby ID: {sr.LobbyId}");
            Debug.Log($"    Members: {sr.CurrentMemberCount}/{sr.MaxMemberCount}");
            Debug.Log($"    Membership Lock: {sr.MembershipLock}");
            Debug.Log($"    Owner: {sr.OwnerEntity.Id}");

            foreach (var kvp in sr.SearchProperties)
            {
                Debug.Log($"    Search [{kvp.Key}] = {kvp.Value}");
            }
        }
    }

    // ==================================================================
    // Step 9: Leave Lobby
    // ==================================================================

    /// <summary>
    /// Leaves the lobby. The completion arrives via
    /// <see cref="PlayFabMultiplayer.OnLobbyLeaveCompleted"/>.
    /// </summary>
    private async Task LeaveLobby()
    {
        Debug.Log("Step 9: Leaving lobby...");

        if (_lobby == null)
        {
            Debug.LogWarning("No lobby to leave.");
            return;
        }

        _leaveLobbyTcs = new TaskCompletionSource<bool>();

        _lobby.Leave(_playerEntity);

        Debug.Log("Leave called - waiting for completion event...");

        await _leaveLobbyTcs.Task;

        Debug.Log("Left the lobby successfully.");
        _lobby = null;
    }

    // ==================================================================
    // Event Handlers
    // ==================================================================

    /// <summary>
    /// Registers all PlayFabMultiplayer event handlers used by this sample.
    /// </summary>
    private void RegisterEventHandlers()
    {
        PlayFabMultiplayer.OnLobbyCreateAndJoinCompleted += OnLobbyCreateAndJoinCompleted;
        PlayFabMultiplayer.OnLobbyPostUpdateCompleted += OnLobbyPostUpdateCompleted;
        PlayFabMultiplayer.OnLobbyFindLobbiesCompleted += OnLobbyFindLobbiesCompleted;
        PlayFabMultiplayer.OnLobbyLeaveCompleted += OnLobbyLeaveCompleted;
        PlayFabMultiplayer.OnLobbyUpdated += OnLobbyUpdated;
        PlayFabMultiplayer.OnLobbyMemberAdded += OnLobbyMemberAdded;
        PlayFabMultiplayer.OnLobbyMemberRemoved += OnLobbyMemberRemoved;
        PlayFabMultiplayer.OnLobbyDisconnected += OnLobbyDisconnected;
        PlayFabMultiplayer.OnError += OnMultiplayerError;
    }

    /// <summary>
    /// Unregisters all PlayFabMultiplayer event handlers.
    /// </summary>
    private void UnregisterEventHandlers()
    {
        PlayFabMultiplayer.OnLobbyCreateAndJoinCompleted -= OnLobbyCreateAndJoinCompleted;
        PlayFabMultiplayer.OnLobbyPostUpdateCompleted -= OnLobbyPostUpdateCompleted;
        PlayFabMultiplayer.OnLobbyFindLobbiesCompleted -= OnLobbyFindLobbiesCompleted;
        PlayFabMultiplayer.OnLobbyLeaveCompleted -= OnLobbyLeaveCompleted;
        PlayFabMultiplayer.OnLobbyUpdated -= OnLobbyUpdated;
        PlayFabMultiplayer.OnLobbyMemberAdded -= OnLobbyMemberAdded;
        PlayFabMultiplayer.OnLobbyMemberRemoved -= OnLobbyMemberRemoved;
        PlayFabMultiplayer.OnLobbyDisconnected -= OnLobbyDisconnected;
        PlayFabMultiplayer.OnError -= OnMultiplayerError;
    }

    /// <summary>
    /// Fired when <see cref="PlayFabMultiplayer.CreateAndJoinLobby"/> completes.
    /// </summary>
    private void OnLobbyCreateAndJoinCompleted(Lobby lobby, int result)
    {
        Debug.Log($"[Event] OnLobbyCreateAndJoinCompleted - result: 0x{result:X8}");
        _createLobbyTcs?.TrySetResult((lobby, result));
    }

    /// <summary>
    /// Fired when <see cref="Lobby.PostUpdate"/> completes.
    /// </summary>
    private void OnLobbyPostUpdateCompleted(Lobby lobby, PFEntityKey localUser, int result)
    {
        Debug.Log($"[Event] OnLobbyPostUpdateCompleted - result: 0x{result:X8}");
        _postUpdateTcs?.TrySetResult((lobby, result));
    }

    /// <summary>
    /// Fired when <see cref="PlayFabMultiplayer.FindLobbies"/> completes.
    /// </summary>
    private void OnLobbyFindLobbiesCompleted(IList<LobbySearchResult> searchResults, PFEntityKey searchingEntity, int result)
    {
        Debug.Log($"[Event] OnLobbyFindLobbiesCompleted - result: 0x{result:X8}, count: {searchResults?.Count ?? 0}");
        _findLobbiesTcs?.TrySetResult((searchResults, result));
    }

    /// <summary>
    /// Fired when <see cref="Lobby.Leave"/> completes.
    /// </summary>
    private void OnLobbyLeaveCompleted(Lobby lobby, PFEntityKey localUser)
    {
        Debug.Log($"[Event] OnLobbyLeaveCompleted");
        _leaveLobbyTcs?.TrySetResult(true);
    }

    /// <summary>
    /// Fired whenever the lobby's shared state changes (properties, membership lock, etc.).
    /// In a real game you would refresh your UI here.
    /// </summary>
    private void OnLobbyUpdated(
        Lobby lobby,
        bool ownerUpdated,
        bool maxMembersUpdated,
        bool accessPolicyUpdated,
        bool membershipLockUpdated,
        IList<string> updatedSearchPropertyKeys,
        IList<string> updatedLobbyPropertyKeys,
        IList<LobbyMemberUpdateSummary> memberUpdates)
    {
        Debug.Log($"[Event] OnLobbyUpdated - Lobby: {lobby.Id}");

        if (ownerUpdated) Debug.Log("  Owner changed");
        if (maxMembersUpdated) Debug.Log("  Max members changed");
        if (accessPolicyUpdated) Debug.Log("  Access policy changed");
        if (membershipLockUpdated) Debug.Log("  Membership lock changed");

        if (updatedSearchPropertyKeys?.Count > 0)
            Debug.Log($"  Updated search properties: {string.Join(", ", updatedSearchPropertyKeys)}");

        if (updatedLobbyPropertyKeys?.Count > 0)
            Debug.Log($"  Updated lobby properties: {string.Join(", ", updatedLobbyPropertyKeys)}");

        if (memberUpdates?.Count > 0)
        {
            foreach (var update in memberUpdates)
            {
                Debug.Log($"  Member {update.Member.Id} updated properties: {string.Join(", ", update.UpdatedMemberPropertyKeys)}");
            }
        }
    }

    /// <summary>
    /// Fired when any member joins the lobby.
    /// </summary>
    private void OnLobbyMemberAdded(Lobby lobby, PFEntityKey member)
    {
        Debug.Log($"[Event] OnLobbyMemberAdded - Member: {member.Id} joined lobby {lobby.Id}");
    }

    /// <summary>
    /// Fired when any member leaves or is removed from the lobby.
    /// </summary>
    private void OnLobbyMemberRemoved(Lobby lobby, PFEntityKey member, LobbyMemberRemovedReason reason)
    {
        Debug.Log($"[Event] OnLobbyMemberRemoved - Member: {member.Id} removed from lobby {lobby.Id}, Reason: {reason}");
    }

    /// <summary>
    /// Fired when the client is disconnected from the lobby.
    /// </summary>
    private void OnLobbyDisconnected(Lobby lobby)
    {
        Debug.Log($"[Event] OnLobbyDisconnected - Lobby: {lobby.Id}");
    }

    /// <summary>
    /// Fired on any PlayFab Multiplayer error. Useful for debugging.
    /// </summary>
    private void OnMultiplayerError(PlayFabMultiplayerErrorArgs args)
    {
        Debug.LogError($"[Event] PlayFab Multiplayer Error - Code: 0x{args.Code:X8}, Message: {args.Message}");
    }

    // ==================================================================
    // Cleanup
    // ==================================================================

#pragma warning disable CS1998
    /// <summary>
    /// Cleans up all PlayFab resources in the correct order:
    /// unregister events → leave lobby → dispose entities → uninitialize Multiplayer → uninitialize Services.
    /// </summary>
    private async Task CleanupAll()
    {
        if (_cleanedUp) return;

        _cleanedUp = true;

        Debug.Log("Cleaning up PlayFab resources...");

        // Unregister event handlers first to avoid callbacks during teardown
        UnregisterEventHandlers();

        // If we still have a lobby reference, ensure we leave it
        if (_lobby != null)
        {
            Debug.Log("Leaving lobby during cleanup...");
            _lobby.LeaveAllLocalUsers();
            _lobby = null;
        }

        // Destroy the event processor GameObject
        if (_eventProcessor != null)
        {
            // Uninitialize is handled inside PlayfabMultiplayerEventProcessor.OnDestroy()
            Destroy(_eventProcessor.gameObject);
            _eventProcessor = null;
        }

        // Dispose of the player entity
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
#endif

        Debug.Log("=== Cleanup Complete ===");
    }
#pragma warning restore CS1998

    private void OnApplicationQuit()
    {
        // Ensure cleanup runs when the application is exiting
        _ = CleanupAll();
    }

    private void OnDestroy()
    {
        // Ensure cleanup runs when this MonoBehaviour is destroyed
        _ = CleanupAll();
    }

    // ==================================================================
    // Helpers
    // ==================================================================

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
