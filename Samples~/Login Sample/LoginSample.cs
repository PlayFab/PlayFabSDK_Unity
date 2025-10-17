using System;
using System.Threading.Tasks;
using UnityEngine;
using PlayFab;

/// <summary>
/// A simple PlayFab login sample demonstrating the core concepts of the PlayFab SDK.
/// This sample shows how to initialize the SDK, create a service configuration,
/// log in a player, and properly clean up resources.
/// </summary>
public class LoginSample : MonoBehaviour
{
    [Header("PlayFab Configuration")]
    [Tooltip("Your PlayFab Title ID - found in Game Manager on the PlayFab website")]
    public string TitleId = ""; // Replace with your actual Title ID

    // Xbox platform login is provided through the com.unity.microsoft.gdk package.
    // Install that and the com.unity.microsoft.gdk.tools package and configure GDK project
    // settings to enable XUser login in this sample.
    [Header("Login Configuration")]
#if MICROSOFT_GDK_SUPPORT
    [Tooltip("Login using an XUser")]
    public bool LoginWithXbox = false;
#endif

    [Tooltip("A unique identifier for a player if not logging in with an XUser")]
    public string CustomPlayerId = "UnityPlayerId";

    // PlayFab Core/Services/GameSave APIs use an instance-based model.
    // This means you create and manage instances of these objects:

    /// <summary>
    /// Service Configuration - Contains connection settings for your PlayFab title.
    /// </summary>
    private PFServiceConfig _serviceConfig;
    
    /// <summary>
    /// Player Entity - Represents a logged-in player and provides access to player-specific APIs.
    /// This is your main interface for making API calls on behalf of the player.
    /// </summary>
    private PFPlayerEntity _playerEntity;

    private bool _cleanedUp = false;

    async void Start()
    {
        Debug.Log("=== PlayFab Login Sample Started ===");
        
        // Validate configuration before proceeding
        if (string.IsNullOrEmpty(TitleId))
        {
            Debug.LogError("TitleId is required! Please set your PlayFab Title ID in the inspector.");
            return;
        }

        // Execute the login flow
        bool success = await ExecuteLoginFlow();
        
        if (success)
        {
            Debug.Log("=== Login Sample Completed Successfully ===");
            
            // In a real game, you would now use _playerEntity to make API calls
            // For example: _playerEntity.DataGetObjectsAsync(...), _playerEntity.ProfilesGetProfileAsync(...), etc.
            
            // For this sample, we'll just wait a moment then log out
            await Task.Delay(2000);
        }
        else
        {
            Debug.LogError("=== Login Sample Failed ===");
        }

        await LogoutAndCleanup();
    }

    /// <summary>
    /// Executes the complete login flow: Initialize → Create Config → Login
    /// </summary>
    private async Task<bool> ExecuteLoginFlow()
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

        return true;
    }

    /// <summary>
    /// Step 1: Initialize PlayFab Services
    /// This must be called before using any PlayFab functionality.
    /// </summary>
    private bool InitializePlayFabServices()
    {
        Debug.Log("Step 1: Initializing PlayFab Services...");

        // Initialize the PlayFab Core services
        // This sets up internal state needed for all PlayFab operations
        
        // All PlayFab APIs return PFResult<T> which contains an HRESULT success/failure code
        // and may contain result data when available (e.g., the CreateServiceConfig call below returns PFResult<PFServiceConfig>)
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

    /// <summary>
    /// Step 2: Create Service Configuration
    /// The service config tells the SDK which PlayFab title to connect to and where to find it.
    /// </summary>
    private bool CreateServiceConfiguration()
    {
        Debug.Log("Step 2: Creating Service Configuration...");
        
        // Create a service configuration for your PlayFab title
        // This combines your title ID with the API endpoint URL
        string apiEndpoint = $"https://{TitleId}.playfabapi.com";
        PFResult<PFServiceConfig> configResult = PFCore.CreateServiceConfig(apiEndpoint, TitleId);
        
        if (CheckForError(configResult, "Failed to create service configuration"))
            return false;

        // Store the service config - we'll need it for making API calls
        _serviceConfig = configResult.Result;
        
        Debug.Log($"Service configuration created for Title ID: {TitleId}");
        return true;
    }

    /// <summary>
    /// Step 3: Login Player
    /// This authenticates the player and creates a player entity for making API calls.
    /// </summary>
    private async Task<bool> LoginPlayer()
    {
        Debug.Log("Step 3: Logging in player...");

        bool loginSuccess = false;
#if MICROSOFT_GDK_SUPPORT
        if (LoginWithXbox)
        {
            loginSuccess = await LoginWithXUser();
        }
        else
        {
            loginSuccess = await LoginWithCustomId();
        }
#else
        loginSuccess = await LoginWithCustomId();
#endif

        if (!loginSuccess)
        {
            return false;
        }

        Debug.Log($"Player logged in successfully!");

        // A player entity can provide additional info about the player's login
        if (_playerEntity.LoginResult.HasValue)
        {
            // Extract some useful information from the login result
            string playFabId = _playerEntity.LoginResult.Value.PlayFabId;
            DateTime lastLoginTime = _playerEntity.LoginResult.Value.LastLoginTime.HasValue
                ? new DateTime(1970, 1, 1).AddSeconds(_playerEntity.LoginResult.Value.LastLoginTime.Value)
                : DateTime.MinValue;

            Debug.Log($"PlayFab ID: {playFabId}");
            Debug.Log($"Last Login: {(lastLoginTime == DateTime.MinValue ? "First time login" : lastLoginTime.ToString())}");
            Debug.Log($"Account Status: {(_playerEntity.LoginResult.Value.NewlyCreated ? "Newly Created" : "Existing Account")}");
        }

        return true;
    }

    /// <summary>
    /// Logs in the player using Custom ID authentication.
    /// This is a simple authentication method good for testing where you provide a unique string.
    /// In a production scenario, you would use a more secure authentication method usually associated with a platform.
    /// e.g. LoginWithXUser or LoginWithSteam
    /// </summary>
    private async Task<bool> LoginWithCustomId()
    {
        var loginRequest = new PFAuthenticationLoginWithCustomIDRequest
        {
            CustomId = CustomPlayerId,      // Your unique identifier for this player
            CreateAccount = true            // Automatically create account if it doesn't exist
            // InfoRequestParameters           Optional parameters to include additional information in the login result
        };

        Debug.Log($"Attempting login with Custom ID: {CustomPlayerId}");

        // Call the login API - this is an async operation
        var playerResult = await _serviceConfig.AuthenticationLoginWithCustomIDAsync(loginRequest);

        if (CheckForError(playerResult, "Failed to log in player"))
            return false;

        // Store the player entity - this represents the logged-in player
        _playerEntity = playerResult.Result;

        return true;
    }

#if MICROSOFT_GDK_SUPPORT
    /// <summary>
    /// Logs in the player using XUser authentication.
    /// </summary>
    private async Task<bool> LoginWithXUser()
    {
        Debug.Log("Attempting to add XUser");

        TaskCompletionSource<Unity.XGamingRuntime.XUserHandle> xUserTask = new();
        Unity.XGamingRuntime.XAsyncCompletionRoutine callback = (Unity.XGamingRuntime.XAsyncBlock asyncBlock) =>
        {
            Unity.XGamingRuntime.XUserHandle xUser;
            int hr = Unity.XGamingRuntime.SDK.XUserAddResult(asyncBlock, out xUser);
            if (HRESULT.Failed(hr))
            {
                Debug.LogError($"Failed to get XUser result: {hr}");
                xUserTask.SetResult(null);
            }
            else
            {
                xUserTask.SetResult(xUser);
            }
        };

        Unity.XGamingRuntime.XAsyncBlock block = new(null, callback, IntPtr.Zero);
        int hr = Unity.XGamingRuntime.SDK.XUserAddAsync(Unity.XGamingRuntime.XUserAddOptions.AddDefaultUserAllowingUI, block);
        if (HRESULT.Failed(hr))
        {
            Debug.LogError($"Failed to add XUser: {hr}");
            xUserTask.SetResult(null);
            return false;
        }

        Unity.XGamingRuntime.XUserHandle xUser = await xUserTask.Task;
        if (xUser == null)
        {
            return false;
        }

        Debug.Log($"XUser added successfully");

        var loginRequest = new PFAuthenticationLoginWithXUserRequest
        {
            UserHandle = xUser.Handle,      // Use the current user
            CreateAccount = true            // Automatically create account if it doesn't exist
            // InfoRequestParameters           Optional parameters to include additional information in the login result
        };

        Debug.Log($"Attempting login to PlayFab with XUser: {CustomPlayerId}");

        // Call the login API - this is an async operation
        var playerResult = await _serviceConfig.AuthenticationLoginWithXUserAsync(loginRequest);

        if (CheckForError(playerResult, "Failed to log in player"))
            return false;

        // Store the player entity - this represents the logged-in player
        _playerEntity = playerResult.Result;

        return true;
    }
#endif

#pragma warning disable CS1998
    /// <summary>
    /// Logs out the player and cleans up all PlayFab resources.
    /// </summary>
    private async Task LogoutAndCleanup()
    {
        if (_cleanedUp) return;

        _cleanedUp = true;

        Debug.Log("Cleaning up PlayFab resources...");

        // Titles should proactively dispose entities and service configs when no longer needed

        // Dispose of the player entity if we have one
        // This releases the authentication token and associated resources
        if (_playerEntity != null)
        {
            Debug.Log("Disposing player entity...");
            _playerEntity.Dispose();
            _playerEntity = null;
        }

        // Dispose of the service configuration
        // This releases the connection configuration
        if (_serviceConfig != null)
        {
            Debug.Log("Disposing service configuration...");
            _serviceConfig.Dispose();
            _serviceConfig = null;
        }

// Temporary workaround only for play-in-editor while the native uninitialize -> reinitialize flow has an issue with the default queue
#if !UNITY_EDITOR
        // Uninitialize PlayFab services
        // Call when you're done with PlayFab operations
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
