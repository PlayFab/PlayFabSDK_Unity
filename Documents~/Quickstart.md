# PlayFab Unity SDK - Quickstart

This quickstart creates a small `MonoBehaviour` that initializes PlayFab, creates a service configuration, signs in with Custom ID, and disposes native handles correctly.

Before starting, install the package and verify GDK setup with the [Installation Guide](Installation.md). You also need a PlayFab Title ID from [Game Manager](https://developer.playfab.com).

## Create the Script

Create a C# script named `PlayFabQuickstart.cs` and add it to a GameObject in your scene.

```csharp
using System.Threading.Tasks;
using PlayFab;
using UnityEngine;

public class PlayFabQuickstart : MonoBehaviour
{
    [Tooltip("Your PlayFab Title ID from Game Manager.")]
    public string TitleId = "";

    public string CustomPlayerId = "QuickstartPlayer";

    private PFServiceConfig _serviceConfig;
    private PFPlayerEntity _playerEntity;
    private bool _playFabInitialized;
    private bool _cleanedUp;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
    private bool _xGameRuntimeInitialized;
#endif

    private async void Start()
    {
        if (string.IsNullOrEmpty(TitleId))
        {
            Debug.LogError("Set TitleId in the Inspector before running the quickstart.");
            return;
        }

        if (!InitializePlayFab())
        {
            return;
        }

        if (!CreateServiceConfig())
        {
            await CleanupAsync();
            return;
        }

        if (!await LoginWithCustomIdAsync())
        {
            await CleanupAsync();
            return;
        }

        Debug.Log("PlayFab login succeeded.");
        Debug.Log($"PlayFab ID: {_playerEntity.LoginResult.Value.PlayFabId}");
    }

    private bool InitializePlayFab()
    {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
        int xgrtResult = PlayFab.XGameRuntime.Initialize();
        if (HRESULT.Failed(xgrtResult))
        {
            Debug.LogError($"XGameRuntime initialization failed: 0x{xgrtResult:X8}");
            return false;
        }

        _xGameRuntimeInitialized = true;
#endif

        PFResult initResult = PFServices.Initialize();
        if (initResult.Failed()
            && initResult.HResult != HRESULT.E_PF_CORE_ALREADY_INITIALIZED
            && initResult.HResult != HRESULT.E_PF_SERVICES_ALREADY_INITIALIZED)
        {
            Debug.LogError($"PlayFab initialization failed: 0x{initResult.HResult:X8}");
            return false;
        }

        _playFabInitialized = true;
        return true;
    }

    private bool CreateServiceConfig()
    {
        string apiEndpoint = $"https://{TitleId}.playfabapi.com";
        PFResult<PFServiceConfig> configResult = PFCore.CreateServiceConfig(apiEndpoint, TitleId);
        if (configResult.Failed())
        {
            Debug.LogError($"Service config creation failed: 0x{configResult.HResult:X8}");
            return false;
        }

        _serviceConfig = configResult.Result;
        return true;
    }

    private async Task<bool> LoginWithCustomIdAsync()
    {
        var request = new PFAuthenticationLoginWithCustomIDRequest
        {
            CustomId = CustomPlayerId,
            CreateAccount = true
        };

        PFResult<PFPlayerEntity> loginResult =
            await _serviceConfig.AuthenticationLoginWithCustomIDAsync(request);

        if (loginResult.Failed())
        {
            Debug.LogError($"Custom ID login failed: 0x{loginResult.HResult:X8}");
            return false;
        }

        _playerEntity = loginResult.Result;
        return true;
    }

    private async void OnDestroy()
    {
        await CleanupAsync();
    }

    private async Task CleanupAsync()
    {
        if (_cleanedUp)
        {
            return;
        }

        _cleanedUp = true;

        _playerEntity?.Dispose();
        _playerEntity = null;

        _serviceConfig?.Dispose();
        _serviceConfig = null;

        if (_playFabInitialized)
        {
            await PFServices.UninitializeAsync();
            _playFabInitialized = false;
        }

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
        if (_xGameRuntimeInitialized)
        {
            PlayFab.XGameRuntime.Uninitialize();
            _xGameRuntimeInitialized = false;
        }
#endif
    }
}
```

## Run It

1. Set `TitleId` in the Inspector.
2. Press **Play**.
3. Open **Window > General > Console** and look for `PlayFab login succeeded`.

For larger examples, import the package samples from Unity Package Manager. The Login, Game Save, Multiplayer, and Party samples show full setup and cleanup flows.

## Next Steps

- [API Overview](ApiOverview.md) - Learn the SDK lifecycle and service areas.
- [Party and Multiplayer Setup](PartyAndMultiplayer.md) - Set up networking, voice, chat, lobby, and matchmaking.
- [Troubleshooting](Troubleshooting.md) - Resolve common setup and runtime issues.
- [Migration Guide](MigrationGuide.md) - Convert existing code from the legacy PlayFab Unity SDK.
