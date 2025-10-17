using System;
using System.Threading.Tasks;
using UnityEngine;
using PlayFab;

/// <summary>
/// A PlayFab Game Saves sample demonstrating how to use local users and Game Saves functionality.
/// This sample shows how to create a local user, set up Game Saves, and handle UI callbacks.
/// Game Saves allows players to save their game data to the cloud and sync across devices.
/// </summary>
public class GameSaveSample : MonoBehaviour
{
    [Header("PlayFab Configuration")]
    [Tooltip("Your PlayFab Title ID - found in Game Manager on the PlayFab website")]
    public string TitleId = ""; // Replace with your actual Title ID

#if !MICROSOFT_GDK_SUPPORT
    [Header("Game Saves Configuration")]
    [Tooltip("A unique identifier for a local user")]
    public string LocalUserId = "UnityGameSaveCustomId_Local";

    [Tooltip("A unique identifier for a player - tied to the LocalUserId")]
    public string CustomPlayerId = "UnityGameSaveCustomId";
#endif

    // PlayFab Core/Services/GameSave APIs use an instance-based model.
    // This means you create and manage instances of these objects:
    
    /// <summary>
    /// Service Configuration - Contains connection settings for your PlayFab title.
    /// </summary>
    private PFServiceConfig _serviceConfig;
    
    /// <summary>
    /// Local User - Represents a local player with a unique local id that can be tied to a unique PlayFab player entity.
    /// </summary>
    private PFLocalUser _localUser;

    /// <summary>
    /// Will hold the path to the local game save folder.
    /// </summary>
    private string _gameSaveFolder;

    async void Start()
    {
        Debug.Log("=== PlayFab Game Saves Sample Started ===");
        
        // Validate configuration before proceeding
        if (string.IsNullOrEmpty(TitleId))
        {
            Debug.LogError("TitleId is required! Please set your PlayFab Title ID in the inspector.");
            return;
        }

#if MICROSOFT_GDK_SUPPORT
        int hr = Unity.XGamingRuntime.SDK.XGameRuntimeInitialize();
        if (HRESULT.Failed(hr))
        {
            Debug.LogError($"Failed to initialize XGameRuntime: {hr}");
            return;
        }
#elif UNITY_EDITOR
        Debug.LogError("Running in the Editor or on Desktop currently requires XUser auth during the Game Saves public preview.");
#endif

        // Execute the Game Saves flow
        bool success = await ExecuteGameSaveFlow();
        
        if (success)
        {
            Debug.Log("=== Game Saves Sample Completed Successfully ===");
            
            // In a real game, you would now use the local user for game save operations:
            // e.g. _localUser.GameSaveFilesUploadWithUiAsync() to upload new save data

            // For this sample, we'll just wait a moment then clean up
            await Task.Delay(2000);
        }
        else
        {
            Debug.LogError("=== Game Saves Sample Failed ===");
        }

        await CleanupGameSave();
    }

    /// <summary>
    /// Executes the complete Game Saves flow: Initialize PFCore → Create Config → Create Local User → Initialize Game Saves → Add to Game Saves → Upload Save Data
    /// </summary>
    private async Task<bool> ExecuteGameSaveFlow()
    {
        // Step 1: Initialize PlayFab Core
        if (!InitializePlayFabCore())
            return false;

        // Step 2: Create a service configuration for your title
        if (!CreateServiceConfiguration())
            return false;

        // Step 3: Create a local user
        if (!await CreateLocalUser())
            return false;

        // Step 4: Initialize Game Saves system
        if (!InitializeGameSave())
            return false;

        // Step 5: Add the local user to Game Saves and download latest save from cloud
        if (!await AddUserToGameSave())
            return false;

        // Step 6: Upload a sample save file
        if (!await UploadSampleSaveData())
            return false;

        return true;
    }

    /// <summary>
    /// Step 1: Initialize PlayFab Core
    /// This must be called before using any PlayFab functionality, including Game Saves.
    /// Even though we're using local users, PFCore still needs to be initialized.
    /// </summary>
    private bool InitializePlayFabCore()
    {
        Debug.Log("Step 1: Initializing PlayFab Core...");

        // Initialize the PlayFab Core
        // This sets up internal state needed for all PlayFab operations
        var initResult = PFCore.Initialize();
        
        if (CheckForError(initResult, "Failed to initialize PlayFab Core"))
        {
            // Special case: if already initialized, that's usually okay
            if (initResult.HResult == HRESULT.E_PF_CORE_ALREADY_INITIALIZED)
            {
                Debug.LogWarning("PlayFab Core were already initialized - continuing...");
                return true;
            }
            return false;
        }

        Debug.Log("PlayFab Core initialized successfully");
        return true;
    }

    /// <summary>
    /// Step 2: Create Service Configuration
    /// Even for local users, we need a service config to specify which PlayFab title to connect to.
    /// </summary>
    private bool CreateServiceConfiguration()
    {
        Debug.Log("Step 2: Creating Service Configuration...");
        
        // Create a service configuration for your PlayFab title
        string apiEndpoint = $"https://{TitleId}.playfabapi.com";
        var configResult = PFCore.CreateServiceConfig(apiEndpoint, TitleId);
        
        if (CheckForError(configResult, "Failed to create service configuration"))
            return false;

        _serviceConfig = configResult.Result;
        
        Debug.Log($"Service configuration created for Title ID: {TitleId}");
        return true;
    }


#pragma warning disable CS1998
    /// <summary>
    /// Step 3: Create Local User
    /// Local users provide on-demand authentication and game save functionality.
    /// </summary>
    private async Task<bool> CreateLocalUser()
    {
        Debug.Log("Step 3: Creating Local User...");
        // Create a local user with a persisted local ID
        // The login handler will be called when the user needs to authenticate

#if MICROSOFT_GDK_SUPPORT
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

        var localUserResult = _serviceConfig.LocalUserCreateHandleWithXboxUser(xUser.Handle, null);
#else
        var localUserResult = _serviceConfig.LocalUserCreateHandleWithPersistedLocalId(
            LocalUserId,                   // Unique identifier for this local user
            LocalUserLoginHandler,         // Callback function to handle login
            null                           // Optional context data
        );
        // Other options include other platform local users (e.g. Steam):
        //_serviceConfig.LocalUserCreateHandleWithSteamUser(null);
#endif

        if (CheckForError(localUserResult, "Failed to create local user"))
            return false;

        _localUser = localUserResult.Result;

#if !MICROSOFT_GDK_SUPPORT
        Debug.Log($"Local user created with ID: {LocalUserId}");
#endif
        return true;
    }
#pragma warning restore CS1998

    /// <summary>
    /// Step 4: Initialize Game Saves System
    /// Game Saves requires initialization before it can be used.
    /// This sets up the file system and UI callback handlers.
    /// </summary>
    private bool InitializeGameSave()
    {
        Debug.Log("Step 4: Initializing Game Saves System...");

#if !UNITY_EDITOR
        // Create a temporary folder for Game Saves files for testing
        _gameSaveFolder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "UnityGameSaveDemo");
        
        // Clean up any existing files from previous runs
        if (System.IO.Directory.Exists(_gameSaveFolder))
        {
            System.IO.Directory.Delete(_gameSaveFolder, true);
        }
        System.IO.Directory.CreateDirectory(_gameSaveFolder);
#endif
        
        // Initialize Game Saves with our folder
        var initArgs = new PFGameSaveInitArgs
        {
            Options = PFGameSaveInitOptions.None,
            SaveFolder = _gameSaveFolder
        };
        
        var initResult = PFGameSaveFiles.Initialize(initArgs);
        
        if (CheckForError(initResult, "Failed to initialize Game Saves"))
        {
            // Special case: if already initialized, that's usually okay
            if (initResult.HResult == HRESULT.E_PF_GAMESAVE_ALREADY_INITIALIZED)
            {
                Debug.LogWarning("Game Saves was already initialized - continuing...");
            }
            else
            {
                return false;
            }
        }
        
        // Set up UI callbacks for handling sync conflicts and errors
        if (!SetupGameSaveUICallbacks())
            return false;

        Debug.Log($"Game Saves initialized");
        return true;
    }

    /// <summary>
    /// Set up UI callbacks for Game Saves conflict resolution and error handling.
    /// These callbacks are called when the system needs user input for sync conflicts.
    /// </summary>
    private bool SetupGameSaveUICallbacks()
    {
        Debug.Log("Setting up Game Saves UI callbacks...");
        
        // Define callbacks for various Game Saves UI scenarios
        var callbacks = new PFGameSaveUICallbacks
        {
            // Called when sync fails due to network or other issues
            SyncFailedCallback = (PFLocalUser localUser, PFGameSaveFilesSyncState syncState, int error, object context) =>
            {
                Debug.LogError($"Game Saves sync failed at state {syncState} with error: 0x{error:X8}");
                // In a real game, you might show a UI dialog to the user
                // For this sample, we'll just cancel the sync
                localUser.GameSaveFilesSetUiSyncFailedResponse(PFGameSaveFilesUiSyncFailedUserAction.Cancel);
            },
            
            // Called when there's a conflict between devices (same user on multiple devices)
            ActiveDeviceContentionCallback = (PFLocalUser localUser, PFGameSaveDescriptor localSave, PFGameSaveDescriptor remoteSave, object context) =>
            {
                Debug.LogWarning("Game Saves device contention detected - multiple devices accessing same save");
                // In a real game, you might show a dialog asking which save to keep
                // For this sample, we'll prefer the most recently saved data
                localUser.GameSaveFilesSetUiActiveDeviceContentionResponse(PFGameSaveFilesUiActiveDeviceContentionUserAction.SyncLastSavedData);
            },
            
            // Called when there's a save file conflict that needs manual resolution
            ConflictCallback = (PFLocalUser localUser, PFGameSaveDescriptor localSave, PFGameSaveDescriptor remoteSave, object context) =>
            {
                Debug.LogWarning("Game Saves conflict detected between local and remote saves");
                // In a real game, you might show detailed information about both saves
                // For this sample, we'll take the remote save
                localUser.GameSaveFilesSetUiConflictResponse(PFGameSaveFilesUiConflictUserAction.TakeRemote);
            }
        };
        
        var callbackResult = PFGameSaveFiles.SetUiCallbacks(callbacks);
        
        if (CheckForError(callbackResult, "Failed to set Game Saves UI callbacks"))
            return false;
        
        Debug.Log("Game Saves UI callbacks configured");
        return true;
    }

    /// <summary>
    /// Step 5: Add User to Game Saves
    /// This registers the local user with the Game Saves system so they can save/load data.
    /// Note: Local user login happens automatically when required during GameSaveFilesAddUserWithUiAsync.
    /// The login handler we configured earlier will be called automatically during this process.
    /// </summary>
    private async Task<bool> AddUserToGameSave()
    {
        Debug.Log("Step 5: Adding Local User to Game Saves...");
        Debug.Log("(Login will happen automatically during this process)");
        
        // Add the local user to Game Saves with UI support
        // This will automatically trigger the login handler if authentication is needed
        var addResult = await _localUser.GameSaveFilesAddUserWithUiAsync(PFGameSaveFilesAddUserOptions.None);
        
        if (CheckForError(addResult, "Failed to add local user to Game Saves"))
            return false;
        
        Debug.Log("Local user added to Game Saves successfully");
        Debug.Log("The user can now save and load game data to the cloud!");
        
        return true;
    }

    /// <summary>
    /// Step 6: Upload Sample Save Data
    /// Creates and uploads a sample save file to demonstrate Game Saves functionality.
    /// In a real game, this would be your actual game state data.
    /// </summary>
    private async Task<bool> UploadSampleSaveData()
    {
        Debug.Log("Step 6: Uploading Sample Save Data...");
        
        try
        {
            // Get the Game Saves folder for this user
            var folderResult = _localUser.GameSaveFilesGetFolder();
            if (CheckForError(folderResult, "Failed to get Game Saves folder"))
                return false;
            
            string gameSaveFolder = folderResult.Result;
            Debug.Log($"Game Saves folder: {gameSaveFolder}");
            
            string saveDataText = $"Player Save Data - Unity Sample\n" +
                                  $"Generated: {DateTime.UtcNow.ToLocalTime()}\n";
            
            // Write the save file to the Game Saves folder
            string saveFilePath = System.IO.Path.Combine(gameSaveFolder, "gamesave.txt");
            await System.IO.File.WriteAllTextAsync(saveFilePath, saveDataText);
            
            Debug.Log($"Sample save data written to: {saveFilePath}");
            Debug.Log($"{saveDataText}");

            // Upload all files in the Game Saves folder to the cloud
            Debug.Log("Uploading to PlayFab cloud...");
            var uploadResult = await _localUser.GameSaveFilesUploadWithUiAsync(PFGameSaveFilesUploadOption.ReleaseDeviceAsActive);
            // PFGameSaveFilesUploadOption.ReleaseDeviceAsActive should be used when the game is exiting and
            // tells the system to release the device lock on the save data
            // PFGameSaveFilesUploadOption.KeepDeviceActive should be used to upload during the game to keep the device lock

            System.IO.File.Delete(saveFilePath);

            if (CheckForError(uploadResult, "Failed to upload save data to cloud"))
                return false;
            
            Debug.Log("Sample save data uploaded successfully!");
            Debug.Log("The save data is now stored in PlayFab cloud and will sync across devices");
            
            // Note: In a real implementation, you would also implement:
            // - Setting description for save conflicts: await _localUser.GameSaveFilesSetSaveDescriptionAsync();
            // - Checking quota: await _localUser.GameSaveFilesGetRemainingQuota();
            // - Checking connection: await _localUser.GameSaveFilesIsConnectedToCloud();

            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception while uploading save data: {ex.Message}");
            return false;
        }
    }

#if !MICROSOFT_GDK_SUPPORT
    /// <summary>
    /// Login handler for the local user.
    /// This is called whenever the local user needs to authenticate with PlayFab.
    /// 
    /// This example uses Custom ID authentication, but you can use any PlayFab login method.
    /// </summary>
    private int LocalUserLoginHandler(
        PFLocalUser localUser,
        PFServiceConfig serviceConfig,
        PFPlayerEntity existingEntity,
        PFLocalUserLoginHandlerContext context)
    {
        Debug.Log("Local User Login Handler called...");

        // Create a login request using Custom ID authentication
        var loginRequest = new PFAuthenticationLoginWithCustomIDRequest
        {
            CustomId = CustomPlayerId,      // Your unique identifier for this player
            CreateAccount = true            // Automatically create account if it doesn't exist
        };

        PFResult result;

        // Check if we have an existing entity (re-login scenario) or need to create new one
        if (existingEntity != null)
        {
            Debug.Log("Re-logging in existing entity...");
            // Re-login with existing entity
            result = existingEntity.AuthenticationLocalUserReLoginWithCustomIDAsync(loginRequest, context);
        }
        else
        {
            Debug.Log("Logging in new entity...");
            // First time login - create new entity
            result = serviceConfig.AuthenticationLocalUserLoginWithCustomIDAsync(loginRequest, context);
        }

        if (result.Failed())
        {
            string errorCode = result.HResult.ToString("X8");
            Debug.LogError($"Local user login handler failed: 0x{errorCode}");
        }
        else
        {
            Debug.Log("Local user login handler succeeded");
        }

        // Return the HRESULT - this tells the system whether login succeeded or failed
        return result.HResult;
    }
#endif

    /// <summary>
    /// Clean up all Game Saves resources and uninitialize the system.
    /// </summary>
    private async Task CleanupGameSave()
    {
        if (_localUser != null)
        {
            Debug.Log("Finalizing cloud save state...");
            
            // Upload finalized save state on exiting the game and tell the service this device is no longer owning the save state in the cloud
            var uploadResult = await _localUser.GameSaveFilesUploadWithUiAsync(PFGameSaveFilesUploadOption.ReleaseDeviceAsActive);
            if (CheckForError(uploadResult, "Failed to upload finalized save state"))
            {
                Debug.LogWarning("There was an issue uploading the finalized save state, but continuing cleanup...");
#if UNITY_EDITOR
                Debug.LogWarning("Finalized save will upload in the background after app termination.");
#endif
            }
            else
            {
                Debug.Log("Finalized save state uploaded successfully");
            }
        }

        Debug.Log("Cleaning up Game Saves resources...");

        // Uninitialize Game Saves system
        Debug.Log("Uninitializing Game Saves system...");
        var gameSaveResult = await PFGameSaveFiles.UninitializeAsync();
        
        if (CheckForError(gameSaveResult, "Failed to uninitialize Game Saves"))
        {
            Debug.LogWarning("There was an issue uninitializing Game Saves, but continuing cleanup...");
        }
        else
        {
            Debug.Log("Game Saves system uninitialized successfully");
        }

        // Dispose of the local user
        if (_localUser != null)
        {
            Debug.Log("Disposing local user...");
            _localUser.Dispose();
            _localUser = null;
        }

        // Dispose of the service configuration
        if (_serviceConfig != null)
        {
            Debug.Log("Disposing service configuration...");
            _serviceConfig.Dispose();
            _serviceConfig = null;
        }

#if !UNITY_EDITOR
        // Clean up temporary Game Saves folder
        if (!string.IsNullOrEmpty(_gameSaveFolder) && System.IO.Directory.Exists(_gameSaveFolder))
        {
            try
            {
                System.IO.Directory.Delete(_gameSaveFolder, true);
                Debug.Log("Temporary Game Saves folder cleaned up");
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Could not delete temporary folder: {ex.Message}");
            }
        }
#endif

        // Temporary workaround only for play-in-editor while the native uninitialize -> reinitialize flow has an issue with the default queue
#if !UNITY_EDITOR
        // Uninitialize PlayFab Core
        Debug.Log("Uninitializing PlayFab Core...");
        var uninitResult = await PFCore.UninitializeAsync();
        
        if (!CheckForError(uninitResult, "There was an issue uninitializing PlayFab Core, but continuing..."))
        {
            Debug.Log("PlayFab Core uninitialized successfully");
        }
#endif

#if MICROSOFT_GDK_SUPPORT
        Unity.XGamingRuntime.SDK.XGameRuntimeUninitialize();
#endif

        Debug.Log("=== Game Saves Cleanup Complete ===");
    }

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
