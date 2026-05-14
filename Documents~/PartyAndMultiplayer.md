# PlayFab Unity SDK - Party and Multiplayer Setup

This guide covers the package-specific prerequisites and first setup steps for PlayFab Party and PlayFab Multiplayer on Win64 and Xbox.

This SDK already bundles Multiplayer and Party under `PlayFabAPI/`; the steps below are tailored to this package and only cover Win64 and Xbox.

## Shared Prerequisites

| Requirement | Notes |
|---|---|
| PlayFab title | Create or select a title in [PlayFab Game Manager](https://developer.playfab.com) and keep the Title ID available. |
| PlayFab Unity SDK installed | Install `microsoft.playfab.sdk` through Unity Package Manager. |
| GDK 2604 or later | Required for the current Win64 and Xbox package scope. |
| Unity 6 | Package metadata targets Unity 6000.0 or later. |
| Win64 build target | For Windows standalone builds, use the 64-bit Windows target. |
| GDK binaries selected | Use **PlayFab > Change GDK** after package import or GDK updates. |
| PlayFab login flow | Multiplayer and Party operations require an authenticated `PFPlayerEntity`. |

On Windows/GDK, initialize XGameRuntime before any PlayFab API and uninitialize it only after PlayFab cleanup has completed.

## Party Prerequisites

PlayFab Party provides networking, voice chat, text chat, transcription, and translation APIs. Before using it:

1. Enable the Party feature for your PlayFab title.
2. Confirm your title can log in through the SDK and produce a `PFPlayerEntity`.
3. Add the `PlayFabMultiplayerManager` prefab from `PlayFabAPI/PlayFabPartySDK/Prefabs/PlayFabMultiplayerManager.prefab` to your scene, or instantiate it before calling `PlayFabMultiplayerManager.Get()`.
4. For Xbox/GDK builds that use Xbox Live authentication, configure the Xbox app title in Partner Center, sandbox, and development Xbox Live accounts.
5. Install and configure the Unity GDK and GDK Tools packages when using XUser authentication or Xbox builds.

The prefab is included in the package at `PlayFabAPI/PlayFabPartySDK/Prefabs/PlayFabMultiplayerManager.prefab`.

## Party Getting Started

1. Initialize XGameRuntime on Windows/GDK.
2. Call `PFServices.Initialize()`.
3. Create a `PFServiceConfig` with `PFCore.CreateServiceConfig()`.
4. Log in and keep the returned `PFPlayerEntity`.
5. Add or instantiate `PlayFabMultiplayerManager` from `PlayFabAPI/PlayFabPartySDK/Prefabs/PlayFabMultiplayerManager.prefab`.
6. Call `PlayFabMultiplayerManager.Get()` and subscribe to `OnError` and network events needed by your game.
7. Call `SetPlayer(playerEntity)` before Party network operations.
8. Create a Party network or join one by Network ID. Hosts typically share the Network ID through PlayFab Lobby, matchmaking, or another title-managed channel.
9. Use the manager APIs for voice, chat, and data messages.
10. Leave the network, dispose PlayFab handles, and then uninitialize PlayFab and XGameRuntime.

Example manager setup:

```csharp
using PlayFab.Party;
using UnityEngine;

PlayFabMultiplayerManager manager = PlayFabMultiplayerManager.Get();
if (manager == null)
{
    Debug.LogError("Add the PlayFabMultiplayerManager prefab to the scene before using Party.");
    return;
}

manager.OnError += OnPartyError;
manager.SetPlayer(playerEntity);
```

The importable **PlayFab Party** sample demonstrates manager setup, player registration, network creation, chat messages, data messages, and cleanup.

## Multiplayer Prerequisites

PlayFab Multiplayer provides lobby and matchmaking APIs. Before using it:

1. Confirm your title can log in through the SDK and produce a `PFPlayerEntity`.
2. Confirm GDK binaries are selected with **PlayFab > Change GDK**.
3. For Xbox builds, complete the required GDK and Xbox project setup for your title.

The old standalone plugin required a `PlayfabMultiplayerEventProcessor` prefab. In this package, `PlayfabMultiplayerEventProcessor` is a component available under `PlayFab.Multiplayer`; you can add it to a scene or create it at runtime.

## Multiplayer Getting Started

1. Initialize XGameRuntime on Windows/GDK.
2. Call `PFServices.Initialize()`.
3. Create a `PFServiceConfig` with `PFCore.CreateServiceConfig()`.
4. Log in and keep the returned `PFPlayerEntity`.
5. Add a `PlayfabMultiplayerEventProcessor` and set its `PlayFabTitleID`, or manually call `PlayFabMultiplayer.Initialize(titleId)` and process lobby and matchmaking state changes every frame.
6. Register Multiplayer event handlers before starting operations. Lobby and matchmaking APIs are event-driven.
7. Call Multiplayer APIs such as `CreateAndJoinLobby`, `FindLobbies`, or matchmaking ticket APIs.
8. Leave or disconnect lobbies, uninitialize Multiplayer, dispose PlayFab handles, and then uninitialize PlayFab and XGameRuntime.

Example event processor setup:

```csharp
using PlayFab.Multiplayer;
using UnityEngine;

var processorObject = new GameObject("PlayFabMultiplayerEventProcessor");
var processor = processorObject.AddComponent<PlayfabMultiplayerEventProcessor>();
processor.PlayFabTitleID = TitleId;
```

The importable **PlayFab Multiplayer** sample demonstrates this flow and bridges event callbacks to `async`/`await` with `TaskCompletionSource`.

## Platform Notes

| Platform | Notes |
|---|---|
| Win64 | Use 64-bit Windows builds. XUser login requires the Unity GDK package; Custom ID login is useful for development and samples. |
| Xbox | Requires GDK setup, Xbox configuration, and XUser/Xbox Live authentication for Xbox scenarios. |

## Related Docs

- [Installation Guide](Installation.md)
- [API Overview](ApiOverview.md)
- [Troubleshooting](Troubleshooting.md)
