# PlayFab Unity SDK - API Overview

The PlayFab Unity SDK wraps native PlayFab libraries with Unity-facing C# APIs. The public surface is instance-based and handle-backed: initialize global PlayFab state, create a service config, authenticate an entity, call APIs through that entity, then dispose handles before shutdown.

## SDK Lifecycle

For most title flows that use PlayFab Services:

| Step | Action | Produces |
|---|---|---|
| 0 | On Windows/GDK, call `PlayFab.XGameRuntime.Initialize()` | XGameRuntime ready state |
| 1 | Call `PFServices.Initialize()` | PlayFab Core and Services ready state |
| 2 | Call `PFCore.CreateServiceConfig(endpoint, titleId)` | `PFServiceConfig` |
| 3 | Call a login method such as `AuthenticationLoginWithCustomIDAsync` | `PFPlayerEntity` |
| 4 | Call service APIs on `PFPlayerEntity`, `PFTitleEntity`, or other entity types | `PFResult<T>` |
| 5 | Dispose handles, call `PFServices.UninitializeAsync()`, then uninitialize XGameRuntime | Cleanup |

Game Save-only flows can initialize Core with `PFCore.Initialize()` and later call `PFCore.UninitializeAsync()`, but Services flows should use `PFServices.Initialize()`.

## Minimal Custom ID Login

```csharp
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
int xgrtResult = PlayFab.XGameRuntime.Initialize();
if (HRESULT.Failed(xgrtResult))
{
    Debug.LogError($"XGameRuntime initialization failed: 0x{xgrtResult:X8}");
    return;
}
#endif

PFResult initResult = PFServices.Initialize();
if (initResult.Failed()
    && initResult.HResult != HRESULT.E_PF_CORE_ALREADY_INITIALIZED
    && initResult.HResult != HRESULT.E_PF_SERVICES_ALREADY_INITIALIZED)
{
    Debug.LogError($"PlayFab initialization failed: 0x{initResult.HResult:X8}");
    return;
}

PFResult<PFServiceConfig> configResult =
    PFCore.CreateServiceConfig("https://ABCDEF.playfabapi.com", "ABCDEF");
if (configResult.Failed())
{
    Debug.LogError($"Service config creation failed: 0x{configResult.HResult:X8}");
    return;
}

PFServiceConfig serviceConfig = configResult.Result;

PFResult<PFPlayerEntity> loginResult =
    await serviceConfig.AuthenticationLoginWithCustomIDAsync(
        new PFAuthenticationLoginWithCustomIDRequest
        {
            CustomId = "player-1",
            CreateAccount = true
        });

if (loginResult.Failed())
{
    Debug.LogError($"Login failed: 0x{loginResult.HResult:X8}");
    serviceConfig.Dispose();
    return;
}

PFPlayerEntity player = loginResult.Result;

PFResult<PFEntityToken> tokenResult = await player.GetEntityTokenAsync();
if (tokenResult.Failed())
{
    Debug.LogError($"GetEntityToken failed: 0x{tokenResult.HResult:X8}");
}

player.Dispose();
serviceConfig.Dispose();
await PFServices.UninitializeAsync();

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
PlayFab.XGameRuntime.Uninitialize();
#endif
```

## PFResult Pattern

SDK calls return `PFResult` or `PFResult<T>` instead of throwing for expected API failures.

| Type | Use |
|---|---|
| `PFResult` | Operations with no payload, such as initialization. |
| `PFResult<T>` | Operations that return a payload, such as login or data queries. |

Check `Failed()` and inspect `HResult`:

```csharp
PFResult<PFPlayerEntity> result =
    await serviceConfig.AuthenticationLoginWithCustomIDAsync(request);

if (result.Failed())
{
    Debug.LogError($"Login failed: 0x{result.HResult:X8}");
    return;
}

PFPlayerEntity player = result.Result;
```

The static `HRESULT` class exposes named constants for common values, including `E_PF_CORE_ALREADY_INITIALIZED`, `E_PF_SERVICES_ALREADY_INITIALIZED`, and `E_PF_INVALIDHANDLE`.

## Handle Ownership

These public objects wrap native handles and implement `IDisposable`:

- `PFServiceConfig`
- `PFEntity` and subclasses such as `PFPlayerEntity`, `PFTitleEntity`, and `PFGameServerEntity`
- `PFLocalUser`
- Game Save provider objects

Dispose them when they are no longer needed. Completing `PFServices.UninitializeAsync()` or `PFCore.UninitializeAsync()` destroys the native handle tables, so any outstanding handles become invalid and later calls return `E_PF_INVALIDHANDLE` (`0x89235402`). Release references and recreate handles after the next initialization.

## Core Types

| Type | Role |
|---|---|
| `PFCore` | Core initialization, service config creation, HTTP config, tracing, and event pipeline support. |
| `PFServices` | Initializes and uninitializes the PlayFab Services layer. Also initializes Core if needed. |
| `PFServiceConfig` | Holds title ID and API endpoint; login methods are called on this object. |
| `PFPlayerEntity` | Represents a logged-in player and exposes player-scoped APIs. |
| `PFTitleEntity` | Represents title-scoped authentication for title-level operations. |
| `PFGameServerEntity` | Represents game server authentication for server-side flows. |
| `PFLocalUser` | Represents a local user identity used by Game Save and local-user login flows. |

## Authentication

### Custom ID

Custom ID login is useful for development, testing, and title-defined identities:

```csharp
var request = new PFAuthenticationLoginWithCustomIDRequest
{
    CustomId = "my-unique-player-id",
    CreateAccount = true
};

PFResult<PFPlayerEntity> result =
    await serviceConfig.AuthenticationLoginWithCustomIDAsync(request);
```

If the call succeeds, `result.Result.LoginResult` contains the login result returned by PlayFab.

### XUser

XUser login is available when `MICROSOFT_GDK_SUPPORT` is defined and the Unity GDK package is installed:

```csharp
#if MICROSOFT_GDK_SUPPORT
var request = new PFAuthenticationLoginWithXUserRequest
{
    UserHandle = xUser.Handle,
    CreateAccount = true
};

PFResult<PFPlayerEntity> result =
    await serviceConfig.AuthenticationLoginWithXUserAsync(request);
#endif
```

Acquire the `XUserHandle` through `Unity.XGamingRuntime.SDK.XUserAddAsync()` before calling the PlayFab login API.

## Local Users and Game Save

Game Save APIs operate on `PFLocalUser`, not directly on `PFPlayerEntity`.

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
```

On GDK, create a local user from an XUser handle with `LocalUserCreateHandleWithXboxUser`.

## Service Areas

| Component | Examples |
|---|---|
| PlayFab Core | Initialization, authentication, entity tokens, local users, tracing, event pipeline. |
| PlayFab Services | Account Management, Catalog, CloudScript, Friends, Groups, Inventory, Player Data, Profiles, Statistics, Leaderboards. |
| PlayFab Game Save | `PFGameSaveFiles`, `PFGameSaveFilesUI`, local save sync, conflict UI, upload, and quota APIs. |
| PlayFab Party | Party network creation/join, voice chat, text chat, data messages, transcription, translation. See [Party and Multiplayer Setup](PartyAndMultiplayer.md). |
| PlayFab Multiplayer | Lobby creation, lobby joins, lobby search, member/property updates, matchmaking tickets. See [Party and Multiplayer Setup](PartyAndMultiplayer.md). |

## Async Rules

Await SDK tasks from Unity code. Do not block SDK tasks with `.Result`, `.Wait()`, or `.GetAwaiter().GetResult()` on the Unity main thread.

Public wrappers generally return the underlying `Task<PFResult>` or `Task<PFResult<T>>` directly. Authentication login wrappers await native login internally so they can wrap returned native handles into the correct entity type.

## Preprocessor Directives

| Directive | Effect |
|---|---|
| `MICROSOFT_GDK_SUPPORT` | Enables GDK-specific APIs such as XUser authentication and Xbox local-user creation. |

## Additional Resources

- [PlayFab Unity SDK Overview](https://learn.microsoft.com/en-us/gaming/playfab/sdks/unified-unity/overview)
- [PlayFab Unified SDK Overview](https://learn.microsoft.com/gaming/playfab/sdks/unified-sdk/overview)
- [PlayFab REST API Reference](https://learn.microsoft.com/rest/api/playfab/)
- [PlayFab Documentation](https://learn.microsoft.com/gaming/playfab/)
- [Unity GDK Package Documentation](https://docs.unity3d.com/Packages/com.unity.microsoft.gdk@latest)
