# PlayFab Unity SDK

A comprehensive Unity SDK for PlayFab services, providing seamless integration with PlayFab's services for game development in Unity.

## Overview

This package includes the complete PlayFab API suite:

- **PlayFab Core** - Essential PlayFab services and authentication
- **PlayFab GameSave** - Cloud save functionality for cross-platform progression (currently available for PC and Xbox)
- **PlayFab Services** - Additional PlayFab services
- **PlayFab Multiplayer** - Multiplayer networking and matchmaking
- **PlayFab Party** - Voice and text communication services

## Package Structure

- `PlayFabAPI/` - PlayFab API projections for native libraries
- `PlayFabTools/` - Unity Editor tools and utilities
- `Samples~/` - Sample scenes for the SDK

## Prerequisites

Before integrating the PlayFab Unity SDK into your project, ensure you have the following:

### Software Requirements
- **GDK 2604** (Gaming Development Kit) installed
- **Unity 6**
- **PlayFab Account** with a configured title

### Platform Support
The plugin currently officially supports the following platforms:
- **Win64** (Windows Desktop for Xbox's or other storefronts)
- **Xbox**

## Installation

There are two ways to install this package in your Unity project. Installing directly from this repo's git URL is quicker. However, if you're building Multiplayer/Party functionality for PlayStation or Switch, you'll need to follow the steps for installing via a local tarball.

### Install via Git URL

1. Copy the git URL for this repo
2. In Unity, open the Package Manager (Window > Package Manager)
3. Click the "+" button and select "Install package from git URL..."
4. Paste the git URL

### Install via Local Tarball

1. Clone this repository and update submodules (ensure you have been granted access to the relevant platform submodules)
2. Run packTarball.ps1 at the root level of the repository which will generate a `.tgz` package with the integrated platform components
3. In Unity, open the Package Manager (Window > Package Manager)
4. Click the "+" button and select "Install package from tarball..."
5. Select the generated `.tgz` file

## Dependencies

This package depends on the **Microsoft GDK Discovery** package (`com.unity.microsoft.gdk.discovery`) which should automatically install when this package is added to your project.

## Important Platform Considerations

### Windows 64-bit (Win64) Development

XUser auth support is provided via the **Microsoft GDK** 1.4.4+ package (`com.unity.microsoft.gdk`) which must be installed separately. Version 1.4.4 of that package does not have bespoke support for GDK 2604 and will log a warning to that effect, but this can be safely ignored for auth purposes.

## Preprocessor Directives

The PlayFab Unity package uses Unity's platform preprocessor directives to conditionally compile features based on platform support and available authentication methods. It also utilizes the `MICROSOFT_GDK_SUPPORT` directive to enable XUser auth and also the new game saves feature.

## Available Services

The PlayFab Unity package provides access to the following services:

- **Account Management**: Player account operations
- **Authentication**: Player login and identity management
- **Catalog**: Game economy and item management
- **Cloud Script**: Execute server-side logic
- **Friends**: Social features and friend lists
- **Game Saves**: Cloud save functionality (requires XUser authentication)
- **Groups**: Guild and clan functionality
- **Inventory**: Manage virtual items and currencies
- **Multiplayer**: Lobby management, matchmaking, and session management
- **Party**: Real-time networking, voice chat, and text communication
- **Player Data**: Save and retrieve player-specific data
- **Statistics & Leaderboards**: Track and display player achievements

## Getting Started

After installation, the PlayFab tools will be available in the Unity Editor under the PlayFab menu. Configure your PlayFab settings and begin integrating PlayFab services into your game.

For detailed documentation and API references, visit the [PlayFab Documentation](https://docs.microsoft.com/gaming/playfab/).

### Getting Binaries

For Win64/Xbox platforms, the package will automatically pull the necessary binaries from your latest GDK installation. Use **PlayFab > Change GDK** from the menu to choose which GDK to pull binaries from if there are multiple installs.

### Getting Started with Code

For detailed implementation examples, configuration samples, and step-by-step code walkthroughs, import the included sample scenes into your project via the Unity Package Manager.

The code examples cover:
- Xbox and Custom ID authentication
- Service initialization and configuration
- PlayFab Game Saves implementation
- PlayFab Multiplayer lobby lifecycle
- PlayFab Party networking and messaging
- Proper cleanup and resource management

### Async API Pattern

PlayFab SDK async methods return `Task<PFResult>` or `Task<PFResult<T>>` and should be awaited from Unity code. Avoid blocking on SDK tasks with `.Result`, `.Wait()`, or `.GetAwaiter().GetResult()` on the Unity main thread, because continuations may need the Unity `SynchronizationContext`.

Most public SDK wrappers directly return the inner native interop task. Authentication login wrappers are the main exception: they remain `async` internally so they can await the native login result and wrap the returned entity handle into `PFEntity` or `PFPlayerEntity` before returning to callers. Those internal awaits intentionally avoid capturing the Unity `SynchronizationContext`.

## Additional Resources

- [PlayFab Documentation](https://docs.microsoft.com/gaming/playfab/)
- [PlayFab REST API Reference](https://docs.microsoft.com/rest/api/playfab/)
- [Unity GDK Package Documentation](https://docs.unity3d.com/Packages/com.unity.microsoft.gdk@latest)
- [Unity GDK Tools Package Documentation](https://docs.unity3d.com/Packages/com.unity.microsoft.gdk.tools@latest)

## Troubleshooting

### Common Issues

1. **Authentication Failures**: Verify your Title ID is correct in configuration
2. **Missing MicrosoftGame.config**: Ensure you've copied the config file for builds using XUser auth
3. **Game Saves Not Working**: Verify you're using Win64 or Xbox platform targets with the Unity GDK Package
4. **Unable to add XUser**: If `Unity.XGamingRuntime.SDK.XUserAddAsync()` from the GDK package returns an error, verify you're following all steps from the GDK and GDK Tools packages' instructions and double check:
   - **Missing Xbox Configuration**: Ensure Xbox-specific configuration is properly set in your Microsoft Game Config
   - **Wrong Sandbox**: If using a sandbox account, verify you're in the correct sandbox using the [XblPCSandbox utility](https://learn.microsoft.com/en-us/gaming/gdk/docs/tools/tools-services/live-pc-sandbox-switcher)
   - **Not Logged In**: Make sure you're logged in with your Xbox test account in both the Microsoft Store and Xbox app
