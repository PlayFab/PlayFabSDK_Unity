# PlayFab Unity SDK

The **PlayFab Unity SDK** is a Unity package (`microsoft.playfab.sdk`) that projects the native PlayFab libraries into C#. It provides Unity-friendly access to PlayFab Core, Services, Game Save, Multiplayer, and Party APIs from one package.

> **Note:** This SDK replaces the legacy [PlayFab Unity SDK](https://github.com/PlayFab/UnitySDK). If you are migrating from the legacy SDK, start with the [Migration Guide](Documents~/MigrationGuide.md).

## Documentation

| Document | Description |
|---|---|
| [Quickstart](Documents~/Quickstart.md) | Make a first PlayFab API call from Unity. |
| [Installation Guide](Documents~/Installation.md) | Detailed package, dependency, and GDK setup. |
| [Migration Guide](Documents~/MigrationGuide.md) | Move from the legacy callback-based Unity SDK to this SDK. |
| [API Overview](Documents~/ApiOverview.md) | SDK lifecycle, resource ownership, and service areas. |
| [Party and Multiplayer Setup](Documents~/PartyAndMultiplayer.md) | Prerequisites and first setup steps for networking, voice, chat, lobby, and matchmaking. |
| [Troubleshooting](Documents~/Troubleshooting.md) | Common setup and runtime issues. |

## Requirements

| Requirement | Notes |
|---|---|
| Unity 6 | Package metadata targets Unity 6000.0 or later. |
| GDK 2604 or later | Required for the current Win64 and Xbox package scope. |
| PlayFab title | Create or select a title in [PlayFab Game Manager](https://developer.playfab.com). |
| `com.unity.microsoft.gdk.discovery` | Package dependency; installed automatically by Unity Package Manager. |
| `com.unity.microsoft.gdk` and `com.unity.microsoft.gdk.tools` | Optional Unity packages, currently validated with 1.5.1, required for XUser authentication and Xbox/GDK project configuration. |

## Platform Support

| Platform | Status | Notes |
|---|---|---|
| Win64 | Supported | Windows desktop builds use GDK binaries. XUser authentication requires the Unity GDK package. |
| Xbox | Supported | Requires GDK setup and Xbox configuration. |

## What's Included

- **PlayFab Core** - Initialization, service configuration, authentication, entity handles, tracing, and event pipeline APIs.
- **PlayFab Services** - Account Management, Catalog, CloudScript, Friends, Groups, Inventory, Player Data, Profiles, Statistics, Leaderboards, and related service APIs.
- **PlayFab Game Save** - Cloud save APIs for Win64 and Xbox using `PFLocalUser`.
- **PlayFab Multiplayer** - Lobby and matchmaking APIs.
- **PlayFab Party** - Real-time networking, voice, text chat, transcription, and translation APIs.

## Package Structure

| Path | Contents |
|---|---|
| `PlayFabAPI/` | C# API, interop wrapper, and P/Invoke layers for the native PlayFab libraries. |
| `PlayFabTools/` | Unity Editor tooling for GDK binary discovery, selection, and plugin import settings. |
| `Samples~/` | Importable Unity samples for Login, Game Save, Multiplayer, Party, and Party tests. |
| `Documents~/` | Public documentation for package users. |

## Installation

Install the package through Unity Package Manager:

1. Open **Window > Package Manager**.
2. Select **+ > Install package from git URL...** and paste this repository's git URL.
3. If you need an offline or custom package, clone the repository, run `packTarball.ps1`, then choose **+ > Install package from tarball...** and select the generated `.tgz`.

See the [Installation Guide](Documents~/Installation.md) for dependency details, GDK setup, verification steps, and upgrade guidance.

## GDK Binaries and XGameRuntime

The package uses the GDK Discovery dependency to find installed GDKs and copy native binaries for Win64 and Xbox. Use **PlayFab > Change GDK** in the Unity menu to choose a specific GDK installation when more than one is available.

On Windows/GDK, the title owns the XGameRuntime lifecycle. Call `PlayFab.XGameRuntime.Initialize()` before any PlayFab API, then call `PlayFab.XGameRuntime.Uninitialize()` only after all PlayFab cleanup has completed.

## Samples

Import samples from the package details page in Unity Package Manager:

| Sample | Description |
|---|---|
| PlayFab Login | Initializes the SDK, creates a service config, and logs in with Custom ID or XUser. |
| PlayFab Game Save | Creates a local user, initializes Game Save, syncs, and uploads save data. |
| PlayFab Multiplayer | Demonstrates lobby creation, lobby search, property updates, event processing, and cleanup. |
| PlayFab Party | Demonstrates Party manager setup, player registration, network creation, chat, data messages, and cleanup. |
| PlayFab Party Tests | Importable Party test suite. |

## Async API Pattern

PlayFab SDK async methods return `Task<PFResult>` or `Task<PFResult<T>>` and should be awaited from Unity code. Avoid blocking SDK tasks with `.Result`, `.Wait()`, or `.GetAwaiter().GetResult()` on the Unity main thread.

Most public SDK wrappers return the inner native interop task directly. Authentication login wrappers are the main exception: they await native login internally so they can wrap returned native entity handles into `PFEntity` or `PFPlayerEntity`.

## Resource Lifetime

`PFServiceConfig`, `PFEntity` subclasses such as `PFPlayerEntity`, `PFLocalUser`, and Game Save provider objects wrap native handles and must be disposed when no longer needed. `PFServices.UninitializeAsync()` and `PFCore.UninitializeAsync()` invalidate all outstanding handles; release references and recreate them after the next initialization.

## Additional Resources

- [PlayFab Unity SDK Overview](https://learn.microsoft.com/en-us/gaming/playfab/sdks/unified-unity/overview)
- [PlayFab Unified SDK Overview](https://learn.microsoft.com/gaming/playfab/sdks/unified-sdk/overview)
- [PlayFab Documentation](https://learn.microsoft.com/gaming/playfab/)
- [PlayFab REST API Reference](https://learn.microsoft.com/rest/api/playfab/)
- [Unity GDK Package Documentation](https://docs.unity3d.com/Packages/com.unity.microsoft.gdk@latest)
- [Unity GDK Tools Package Documentation](https://docs.unity3d.com/Packages/com.unity.microsoft.gdk.tools@latest)
- [GDK Documentation](https://learn.microsoft.com/gaming/gdk/)
- [Microsoft Game Dev Discord](https://discord.com/invite/msftgamedev)

## License

See [LICENSE.txt](LICENSE.txt) for license information.
