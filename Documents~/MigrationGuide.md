# Migrating from the Legacy PlayFab Unity SDK

## Introduction

The legacy PlayFab Unity SDK ([PlayFab/UnitySDK](https://github.com/PlayFab/UnitySDK)) is being deprecated. Its replacement — the new PlayFab Unity SDK — is a complete rewrite built on native C/C++ projections of the PlayFab libraries, offering modern async/await patterns, an instance-based API model, and a unified package that bundles Core, Services, GameSave, Multiplayer, and Party together.

This guide covers all the major changes between the two SDKs and provides side-by-side code comparisons to help you migrate your project as smoothly as possible.

> **Note:** The new SDK currently targets **Win64** and **Xbox** platforms and requires **GDK 2604+** and **Unity 6 (6000.0+)**. If your project targets mobile or other platforms, review the [Platform Scope](#overview-of-changes) section before beginning migration.

---

## Overview of Changes

| Area | Legacy SDK | New SDK |
|------|-----------|---------|
| **Architecture** | C# REST wrapper | Native C/C++ projection |
| **API Pattern** | Static classes (`PlayFabClientAPI`) | Instance-based (`PFServiceConfig`, `PFPlayerEntity`) |
| **Async Model** | Callbacks (success/failure delegates) | C# async/await |
| **Installation** | `.unitypackage` / Editor Extensions | Unity Package Manager (git URL or tarball) |
| **Configuration** | `PlayFabSharedSettings` ScriptableObject | Code-based via `PFCore.CreateServiceConfig()` |
| **Unity Version** | 5.3+ | Unity 6 (6000.0+) |
| **Platform Scope** | All Unity platforms | Win64, Xbox (GDK 2604+ required) |
| **Error Handling** | `PlayFabError` in callbacks | `PFResult<T>` with HRESULT codes |
| **Services** | Separate packages (Party, Multiplayer) | All-in-one (Core, Services, GameSave, Multiplayer, Party) |
| **Namespace** | `PlayFab`, `PlayFab.ClientModels` | `PlayFab` |

---

## Installation Changes

### Removing the Legacy SDK

1. **Delete the SDK folders** from your project:
   - `Assets/PlayFabSDK/`
   - `Assets/PlayFabEditorExtensions/`
2. **Remove any PlayFab scripting define symbols** from your project settings (e.g., `ENABLE_PLAYFABSERVER_API`, `ENABLE_PLAYFABADMIN_API`). You can find these in **Edit > Project Settings > Player > Scripting Define Symbols**.
3. Delete any leftover `.meta` files associated with the removed folders.

### Installing the New SDK

Install the new SDK via the Unity Package Manager. See the [Installation Guide](Installation.md) for detailed instructions on adding the package by git URL or tarball.

> **Note:** You must have **GDK 2604 or later** installed on your development machine before installing the new SDK.

---

## Configuration Changes

The legacy SDK used a `PlayFabSharedSettings` ScriptableObject (or static setters) for configuration. The new SDK replaces this with explicit, code-based initialization.

### Legacy

```csharp
// Option 1: Static setter
PlayFabSettings.staticSettings.TitleId = "YOUR_TITLE_ID";

// Option 2: PlayFabSharedSettings ScriptableObject (configured in the Inspector)
```

### New SDK

```csharp
// 1. On Windows/GDK, initialize XGameRuntime before any PlayFab API.
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
int xgrtResult = PlayFab.XGameRuntime.Initialize();
if (HRESULT.Failed(xgrtResult))
{
    Debug.LogError($"XGameRuntime initialization failed: 0x{xgrtResult:X8}");
    return;
}
#endif

// 2. Initialize the PlayFab service layer.
PFResult initResult = PFServices.Initialize();
if (initResult.Failed()
    && initResult.HResult != HRESULT.E_PF_CORE_ALREADY_INITIALIZED
    && initResult.HResult != HRESULT.E_PF_SERVICES_ALREADY_INITIALIZED)
{
    Debug.LogError($"PlayFab initialization failed: 0x{initResult.HResult:X8}");
    return;
}

// 3. Create a service configuration with your title ID.
string apiEndpoint = $"https://{TitleId}.playfabapi.com";
PFResult<PFServiceConfig> configResult = PFCore.CreateServiceConfig(apiEndpoint, TitleId);
if (configResult.Failed())
{
    Debug.LogError($"Service config creation failed: 0x{configResult.HResult:X8}");
    return;
}
PFServiceConfig serviceConfig = configResult.Result;
```

> **Note:** There is no Inspector-based configuration in the new SDK. All setup happens in code.

---

## Authentication Changes

Authentication moves from static class methods with callbacks to instance methods with async/await.

### Legacy — Custom ID Login

```csharp
using PlayFab;
using PlayFab.ClientModels;

var request = new LoginWithCustomIDRequest { CustomId = "Player1", CreateAccount = true };
PlayFabClientAPI.LoginWithCustomID(request,
    result => Debug.Log($"Success! PlayFab ID: {result.PlayFabId}"),
    error => Debug.LogError(error.GenerateErrorReport())
);
```

### New SDK — Custom ID Login

```csharp
using PlayFab;

var loginRequest = new PFAuthenticationLoginWithCustomIDRequest
{
    CustomId = "Player1",
    CreateAccount = true
};
var playerResult = await serviceConfig.AuthenticationLoginWithCustomIDAsync(loginRequest);
if (playerResult.Failed())
{
    Debug.LogError($"Login failed: 0x{playerResult.HResult:X8}");
    return;
}
PFPlayerEntity player = playerResult.Result;
Debug.Log($"Success! PlayFab ID: {player.LoginResult.Value.PlayFabId}");
```

**Key differences:**
- The request type changes from `LoginWithCustomIDRequest` to `PFAuthenticationLoginWithCustomIDRequest`.
- The call moves from the static `PlayFabClientAPI` class to an instance method on `PFServiceConfig`.
- Success/failure callbacks are replaced by `await` and a `PFResult<T>` return value.
- The result entity (`PFPlayerEntity`) is an `IDisposable` resource you must manage.

---

## Error Handling Changes

### Legacy

Errors arrived through a failure callback as `PlayFabError` objects:

```csharp
PlayFabClientAPI.LoginWithCustomID(request,
    result => { /* success */ },
    error =>
    {
        Debug.LogError(error.GenerateErrorReport());
        // error.Error — PlayFabErrorCode enum
        // error.ErrorMessage — human-readable message
        // error.ErrorDetails — dictionary of field-level errors
    }
);
```

### New SDK

All API calls return `PFResult<T>`. Check `Failed()` and inspect `HResult` for HRESULT error codes:

```csharp
var result = await serviceConfig.AuthenticationLoginWithCustomIDAsync(request);
if (result.Failed())
{
    // result.HResult contains the HRESULT error code
    Debug.LogError($"API call failed with HRESULT: 0x{result.HResult:X8}");
    return;
}
// Success — use result.Result
```

> **Note:** HRESULT values include standard system errors and PlayFab-specific errors exposed through the `HRESULT` constants.

---

## Resource Management (New Concept)

The new SDK introduces explicit resource management that did not exist in the legacy SDK. Because the underlying implementation uses native C/C++ libraries, you must dispose of resources when you are done with them.

### Rules

- `PFServiceConfig`, `PFEntity` subclasses such as `PFPlayerEntity`, and `PFLocalUser` implement `IDisposable`.
- Always call `Dispose()` when you are finished with these objects.
- Call `PFServices.UninitializeAsync()` when your application is completely done with PlayFab.
- `PFServices.UninitializeAsync()` and `PFCore.UninitializeAsync()` invalidate all outstanding handles. Release references and recreate them after the next initialization.
- On Windows/GDK, call `PlayFab.XGameRuntime.Uninitialize()` only after PlayFab cleanup has completed.

### Example

```csharp
public class PlayFabManager : MonoBehaviour
{
    public string TitleId = "YOUR_TITLE_ID";
    public string CustomPlayerId = "Player1";

    private PFServiceConfig _serviceConfig;
    private PFPlayerEntity _playerEntity;

    async void Start()
    {
        PFResult initResult = PFServices.Initialize();
        if (initResult.Failed()
            && initResult.HResult != HRESULT.E_PF_CORE_ALREADY_INITIALIZED
            && initResult.HResult != HRESULT.E_PF_SERVICES_ALREADY_INITIALIZED)
        {
            Debug.LogError($"PlayFab initialization failed: 0x{initResult.HResult:X8}");
            return;
        }

        string apiEndpoint = $"https://{TitleId}.playfabapi.com";
        PFResult<PFServiceConfig> configResult = PFCore.CreateServiceConfig(apiEndpoint, TitleId);
        if (configResult.Failed())
        {
            Debug.LogError($"Service config creation failed: 0x{configResult.HResult:X8}");
            return;
        }

        _serviceConfig = configResult.Result;

        var request = new PFAuthenticationLoginWithCustomIDRequest
        {
            CustomId = CustomPlayerId,
            CreateAccount = true
        };

        PFResult<PFPlayerEntity> loginResult =
            await _serviceConfig.AuthenticationLoginWithCustomIDAsync(request);
        if (loginResult.Failed())
        {
            Debug.LogError($"Login failed: 0x{loginResult.HResult:X8}");
            return;
        }

        _playerEntity = loginResult.Result;
    }

    void OnDestroy()
    {
        _playerEntity?.Dispose();
        _serviceConfig?.Dispose();
    }
}
```

> **Note:** Failing to dispose of native resources can lead to memory leaks. Always pair creation with disposal, ideally in `OnDestroy()` or a similar lifecycle method. During application shutdown, call `PFServices.UninitializeAsync()` after disposing PlayFab handles and before uninitializing XGameRuntime.

---

## API Naming Changes

The new SDK follows a different naming convention. Methods are grouped by service area and live on instances rather than static classes.

### Naming Pattern

| Legacy | New SDK |
|--------|---------|
| `PlayFabClientAPI.LoginWithCustomID()` | `serviceConfig.AuthenticationLoginWithCustomIDAsync()` |
| `PlayFabClientAPI.GetPlayerProfile()` | `playerEntity.ProfilesGetProfileAsync()` |
| `PlayFabClientAPI.UpdatePlayerStatistics()` | `playerEntity.LeaderboardsUpdateStatisticsAsync()` |

### Conventions

- **Instance methods, not static classes.** Methods are called on `PFServiceConfig`, `PFPlayerEntity`, or `PFLocalUser` instances.
- **Service prefix.** Methods are prefixed by their service area: `Authentication`, `Profiles`, `Data`, `Leaderboards`, `Economy`, etc.
- **`Async` suffix.** All asynchronous methods end with `Async` (e.g., `AuthenticationLoginWithCustomIDAsync`).
- **Request types** use the `PF` prefix and include the service area: `PFAuthenticationLoginWithCustomIDRequest`, `PFProfilesGetProfileRequest`, etc.

---

## Removed Concepts

The following concepts from the legacy SDK no longer exist in the new SDK:

| Removed | Details |
|---------|---------|
| **Editor Extensions** | Legacy configuration UI no longer exists. The current PlayFab menu is for GDK binary selection; title setup is code-based. |
| **PlayFabSharedSettings** | No longer exists. Use `PFCore.CreateServiceConfig()` to configure your title. |
| **Static API classes** | `PlayFabClientAPI`, `PlayFabServerAPI`, `PlayFabAdminAPI`, etc. are replaced by instance-based methods on `PFServiceConfig` and `PFPlayerEntity`. |
| **HTTP transport configuration** | Custom HTTP transports and `PlayFabHttp` are no longer needed. Transport is handled natively by the C/C++ layer. |
| **`ENABLE_PLAYFABSERVER_API` define** | Scripting define symbols for enabling server/admin APIs are removed. Server functionality follows different patterns in the new SDK. |

---

## New Concepts

The new SDK introduces several concepts that have no equivalent in the legacy SDK:

### PFLocalUser

For Game Saves and other features that require a local user identity, create a `PFLocalUser` from the service configuration:

```csharp
PFResult<PFLocalUser> localUserResult =
    serviceConfig.LocalUserCreateHandleWithPersistedLocalId(
        "local-user-1",
        LocalUserLoginHandler,
        null);

if (localUserResult.Failed())
{
    Debug.LogError($"Local user creation failed: 0x{localUserResult.HResult:X8}");
    return;
}

PFLocalUser localUser = localUserResult.Result;
// Use localUser for Game Save operations, then dispose it when done.
localUser.Dispose();
```

### GDK Integration

The new SDK's native binaries are managed through the GDK Discovery system. Use **PlayFab > Change GDK** in the Unity Editor menu to switch between installed GDK versions.

### XUser Authentication

For Xbox and Win64 GDK authentication, the new SDK integrates with XUser through the `com.unity.microsoft.gdk` package:

```csharp
// Requires com.unity.microsoft.gdk and MICROSOFT_GDK_SUPPORT define
var loginRequest = new PFAuthenticationLoginWithXUserRequest
{
    UserHandle = xUser.Handle,
    CreateAccount = true
};

var result = await serviceConfig.AuthenticationLoginWithXUserAsync(loginRequest);
```

### Preprocessor Directives

Use the `MICROSOFT_GDK_SUPPORT` scripting define symbol to enable GDK-specific code paths and features in your project. It is defined when the Unity GDK package is installed and active for the target platform.

---

## Step-by-Step Migration Checklist

Use this checklist to track your migration progress:

- [ ] **1. Install GDK 2604+** — Download and install the latest GDK from Microsoft.
- [ ] **2. Upgrade to Unity 6** — The new SDK requires Unity 6 (6000.0+).
- [ ] **3. Remove legacy SDK files** — Delete `Assets/PlayFabSDK/` and `Assets/PlayFabEditorExtensions/` folders and their `.meta` files.
- [ ] **4. Remove legacy scripting define symbols** — Remove `ENABLE_PLAYFABSERVER_API`, `ENABLE_PLAYFABADMIN_API`, and any other PlayFab-related defines from Player Settings.
- [ ] **5. Install the new SDK via Package Manager** — Follow the [Installation Guide](Installation.md) to add the `microsoft.playfab.sdk` package.
- [ ] **6. Replace configuration code** — Remove `PlayFabSettings` usage. On Windows/GDK, initialize XGameRuntime first, then initialize with `PFServices.Initialize()` and create a service config with `PFCore.CreateServiceConfig()`.
- [ ] **7. Convert callbacks to async/await** — Replace all success/failure delegate patterns with `await` and `PFResult<T>` checks.
- [ ] **8. Replace static API calls with instance methods** — Change `PlayFabClientAPI.Method()` calls to `serviceConfig.ServiceMethodAsync()` or `playerEntity.ServiceMethodAsync()` calls.
- [ ] **9. Add resource disposal** — Add `Dispose()` calls for all `PFPlayerEntity`, `PFServiceConfig`, and `PFLocalUser` instances, typically in `OnDestroy()`, and release references after uninitialization.
- [ ] **10. Update error handling** — Replace `PlayFabError` / `GenerateErrorReport()` patterns with `PFResult.Failed()` / `HResult` checks.
- [ ] **11. Test all PlayFab integrations** — Verify login, data operations, leaderboards, and any other PlayFab features your game uses.

---

## FAQ

### Can I use both SDKs simultaneously?

No. The legacy SDK and the new SDK are not compatible and cannot coexist in the same project. You must fully remove the legacy SDK before installing the new one.

### Do I need to recreate my PlayFab title?

No. Your existing PlayFab titles work with both SDKs. The backend services are the same — only the client SDK has changed.

### What about mobile platforms?

The new SDK currently supports **Win64** and **Xbox** only. If your project targets iOS, Android, or other mobile platforms, you will need to continue using the legacy SDK for those platforms until mobile support is available in the new SDK. Check the PlayFab documentation for future platform support updates.

### Where are the Editor Extensions?

The legacy Editor Extensions have been removed. In the new SDK, title configuration is code-based through `PFServices.Initialize()` and `PFCore.CreateServiceConfig()`. The current **PlayFab > Change GDK** menu only selects GDK binaries.

### Do I need the GDK for Win64 desktop development?

Yes. The new SDK requires GDK 2604 or later even for Win64 desktop builds, because the underlying native libraries depend on GDK infrastructure.

### How do I handle the transition for live games?

Since both SDKs communicate with the same PlayFab backend, you can migrate your client code without any server-side changes. Plan a testing period to validate all API interactions before shipping the updated client.
