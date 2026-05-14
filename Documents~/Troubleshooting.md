# PlayFab Unity SDK - Troubleshooting

This guide covers common installation, GDK, authentication, Game Save, and lifecycle issues.

## Installation Issues

### SDK not appearing in Package Manager

- Verify the git URL is `https://github.com/PlayFab/PlayFabSDK_Unity.git` and reachable from your development machine. The `.git` suffix is required for Unity Package Manager git installs.
- Open **Window > General > Console** and check for package resolution errors.
- Confirm the project uses Unity 6 (6000.0 or later).

### GDK Discovery package not installing

`com.unity.microsoft.gdk.discovery` is a package dependency and should install automatically.

- If it does not appear, verify Unity Package Manager registry access.
- If needed, install it manually by package name through Package Manager.

### Compilation errors after installation

- Remove any legacy PlayFab SDK folders from `Assets/`, such as `Assets/PlayFabSDK/` and `Assets/PlayFabEditorExtensions/`.
- Confirm no legacy PlayFab scripting defines, such as `ENABLE_PLAYFABSERVER_API` or `ENABLE_PLAYFABADMIN_API`, remain in Player Settings.
- Restart Unity to force assembly reloads if the Console still shows stale errors.

## GDK and Native Binary Issues

### Native binaries not loading

- Verify GDK 2604 or later is installed.
- Use **PlayFab > Change GDK** to select the intended GDK installation.
- Check the Console for plugin import errors such as `DllNotFoundException`.
- Confirm the selected build target is Win64 or Xbox.

### "Change GDK" menu option not appearing

- Confirm `microsoft.playfab.sdk` is installed.
- Confirm the project is opened in a supported editor environment.
- Reimport the package if Unity did not compile editor scripts after installation.

### Wrong GDK version being used

Use **PlayFab > Change GDK** after installing or updating GDKs. The editor tooling tracks the selected GDK and updates copied native binaries accordingly.

## XGameRuntime Issues

### PlayFab initialization fails on Windows/GDK

Windows Editor Play Mode, Windows standalone builds, and GDK builds must initialize XGameRuntime before any PlayFab API call:

```csharp
int hr = PlayFab.XGameRuntime.Initialize();
if (HRESULT.Failed(hr))
{
    Debug.LogError($"XGameRuntime initialization failed: 0x{hr:X8}");
    return;
}

PFResult initResult = PFServices.Initialize();
```

During cleanup, dispose PlayFab handles, wait for PlayFab uninitialization, and only then uninitialize XGameRuntime.

## Authentication Issues

### `PFServices.Initialize()` reports already initialized

`E_PF_CORE_ALREADY_INITIALIZED` and `E_PF_SERVICES_ALREADY_INITIALIZED` mean the relevant PlayFab layer was already initialized. It is usually safe to continue:

```csharp
PFResult result = PFServices.Initialize();
if (result.Failed()
    && result.HResult != HRESULT.E_PF_CORE_ALREADY_INITIALIZED
    && result.HResult != HRESULT.E_PF_SERVICES_ALREADY_INITIALIZED)
{
    Debug.LogError($"Initialization failed: 0x{result.HResult:X8}");
    return;
}
```

### Service configuration failures

- Verify the Title ID in [PlayFab Game Manager](https://developer.playfab.com).
- Use the endpoint format `https://{TitleId}.playfabapi.com`.
- Confirm network connectivity to PlayFab services.

### Custom ID login failures

- Ensure the title exists and the Title ID is correct.
- Set `CreateAccount = true` when the account may not exist yet.
- Check `PFResult.HResult` for the specific failure.

### XUser login failures

- Install `com.unity.microsoft.gdk` 1.5.1 or later.
- Confirm `MICROSOFT_GDK_SUPPORT` is defined for the target platform.
- Call `Unity.XGamingRuntime.SDK.XUserAddAsync()` and verify it succeeds before PlayFab login.
- Verify the active Xbox account in the Microsoft Store and Xbox app.
- Check the sandbox with [XblPCSandbox](https://learn.microsoft.com/gaming/gdk/docs/tools/tools-services/live-pc-sandbox-switcher).
- Verify `MicrosoftGame.config` through GDK and GDK Tools guidance.

## Game Save Issues

### Game Save APIs are unavailable

- Game Save APIs are compiled for Windows Editor, Windows standalone, and GDK-supported builds.
- Use a `PFLocalUser`; Game Save APIs do not operate directly on `PFPlayerEntity`.
- Install `com.unity.microsoft.gdk` when using XUser-backed local users.

### Game Save sync failures

- Verify network connectivity.
- Check that the local save folder exists and is writable when a save folder is required.
- Inspect the returned `PFResult.HResult`.

### `GameSaveFilesGetRemainingQuota` returns `E_FAIL`

On non-console Windows, the GRTS provider can return `E_FAIL` because cloud quota is managed by Xbox platform services that are not present on desktop Windows. This is a platform limitation.

### `GameSaveFilesResetCloudAsync` returns `E_NOTIMPL`

The GRTS provider intentionally does not implement Reset Cloud. The API is present for providers that support it.

## Resource and Handle Issues

### Memory leaks or resource warnings

Dispose native-handle objects when done:

- `PFServiceConfig`
- `PFEntity` subclasses such as `PFPlayerEntity`, `PFTitleEntity`, and `PFGameServerEntity`
- `PFLocalUser`
- Game Save provider objects

### `E_PF_INVALIDHANDLE` after uninitializing

`PFServices.UninitializeAsync()` and `PFCore.UninitializeAsync()` destroy global native handle tables. All outstanding service configs, entities, local users, and Game Save providers become invalid. Dispose them, clear cached references, and recreate them after the next initialization.

## Error Code Reference

Format HRESULT values as hex for readability:

```csharp
Debug.LogError($"PlayFab call failed: 0x{result.HResult:X8}");
```

| Constant | Description |
|---|---|
| `E_PF_CORE_ALREADY_INITIALIZED` | PlayFab Core is already initialized. |
| `E_PF_SERVICES_ALREADY_INITIALIZED` | PlayFab Services is already initialized. |
| `E_PF_INVALIDHANDLE` | A native handle was disposed or invalidated by uninitialization. |
| `E_FAIL` | Generic failure; Game Save quota calls can return this on non-console Windows. |
| `E_NOTIMPL` | API is intentionally not implemented by the active provider. |

## Getting Help

- [PlayFab Documentation](https://learn.microsoft.com/gaming/playfab/)
- [PlayFab REST API Reference](https://learn.microsoft.com/rest/api/playfab/)
- [GDK Documentation](https://learn.microsoft.com/gaming/gdk/)
- [Unity GDK Package Documentation](https://docs.unity3d.com/Packages/com.unity.microsoft.gdk@latest)
