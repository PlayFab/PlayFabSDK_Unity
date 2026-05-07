# PlayFab SDK

## Overview

The PlayFab SDK package provides Unity projections for native PlayFab APIs, including Core, Services, Game Save, Multiplayer, and Party.

## Package contents

| Location | Description |
| --- | --- |
| `PlayFabAPI/` | Runtime PlayFab API, interop, and wrapper code. |
| `PlayFabTools/` | Unity Editor tooling for PlayFab SDK setup and native binary management. |
| `Samples~/` | Importable samples for login, Game Save, Multiplayer, Party, and Party tests. |

## Installation instructions

Install the package through Unity Package Manager from either the package Git URL or a local tarball. For a local tarball, run `packTarball.ps1` at the package repository root, then select **Install package from tarball** in Unity Package Manager.

After installation, import any samples you need from the package details panel in Unity Package Manager.

## Requirements

- Unity 6000.0 or newer.
- Microsoft GDK 2604 for Win64 and Xbox development.
- A PlayFab account with a configured title.
- `com.unity.microsoft.gdk.discovery`, which is declared as a package dependency.

## Limitations

- Official platform support is currently Win64 and Xbox.
- Game Save functionality requires supported Win64 or Xbox targets and XUser authentication.
- XGameRuntime is caller-managed on Windows and GDK platforms. Initialize it before PlayFab APIs and uninitialize it only after PlayFab cleanup completes.

## Workflows

1. Configure your PlayFab title and authentication method.
2. Initialize the required platform runtime, if applicable.
3. Initialize PlayFab Core or Services.
4. Await SDK async APIs from Unity code instead of blocking on tasks from the Unity main thread.
5. Dispose PlayFab handles and uninitialize PlayFab before shutting down platform runtime state.

## Samples

The package includes importable samples for login, Game Save, Multiplayer, Party, and Party tests. Open Unity Package Manager, select the PlayFab SDK package, and import the sample you want to inspect or run.

## Additional resources

- [PlayFab documentation](https://docs.microsoft.com/gaming/playfab/)
- [PlayFab REST API reference](https://docs.microsoft.com/rest/api/playfab/)
- [Unity GDK package documentation](https://docs.unity3d.com/Packages/com.unity.microsoft.gdk@latest)
- [Unity GDK Tools package documentation](https://docs.unity3d.com/Packages/com.unity.microsoft.gdk.tools@latest)
