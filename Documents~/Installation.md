# PlayFab Unity SDK - Installation Guide

This guide covers package installation, required Unity and GDK dependencies, GDK binary selection, and verification for the `microsoft.playfab.sdk` Unity package.

## Requirements

| Requirement | Details |
|---|---|
| Unity 6 | Unity 6000.0 or later. The repo currently validates with Unity 6000.4. |
| GDK 2604 or later | Required for the current Win64 and Xbox package scope. |
| PlayFab developer account | Create or select a title in [PlayFab Game Manager](https://developer.playfab.com). |

## Installation Methods

### Method 1: Install via Git URL

Use this method when Unity can access the public repository directly.

1. In Unity, open **Window > Package Manager**.
2. Select **+ > Install package from git URL...**.
3. Paste `https://github.com/PlayFab/PlayFabSDK_Unity.git`.
4. Click **Install**.

Unity resolves the package dependency on `com.unity.microsoft.gdk.discovery` automatically.

The `.git` suffix is required. If you paste `https://github.com/PlayFab/PlayFabSDK_Unity` without `.git`, Unity treats the value as a package name and reports it as invalid.

### Method 2: Install via Local Tarball

Use this method for offline environments or when you need a prebuilt `.tgz`.

1. Clone the repository and initialize submodules:

   ```powershell
   git clone <repository-url>
   Set-Location <repository-directory>
   git submodule update --init --recursive
   ```

2. Run the packaging script from the repository root:

   ```powershell
   .\packTarball.ps1
   ```

3. In Unity, open **Window > Package Manager**.
4. Select **+ > Install package from tarball...**.
5. Choose the generated `.tgz` file.

## Unity Package Dependencies

| Package | Version | Required | Purpose |
|---|---|---|---|
| `com.unity.microsoft.gdk.discovery` | 1.1.0 or later | Yes, installed automatically | Finds installed GDK layouts so PlayFab editor tooling can copy native binaries. |
| `com.unity.microsoft.gdk` | 1.5.1 or later recommended | Optional | Required for XUser authentication and GDK-specific Unity APIs. |
| `com.unity.microsoft.gdk.tools` | 1.5.1 or later recommended | Optional | Helps configure Xbox/GDK project settings, including `MicrosoftGame.config`. |

Install the optional GDK packages separately when your project uses XUser authentication or targets Xbox.

For Party networking, voice, chat, lobby, or matchmaking setup, see [Party and Multiplayer Setup](PartyAndMultiplayer.md).

## GDK Binary Management

The SDK includes Unity editor tooling that copies native binaries from a selected GDK installation for Win64 and Xbox.

1. Open Unity after installing the package.
2. Select **PlayFab > Change GDK**.
3. Choose the GDK installation to use.

Use the same menu after installing a new GDK or when switching between multiple GDK installations.

## XGameRuntime Lifecycle

On Windows/GDK, initialize XGameRuntime before any PlayFab API:

```csharp
int hr = PlayFab.XGameRuntime.Initialize();
if (HRESULT.Failed(hr))
{
    Debug.LogError($"XGameRuntime initialization failed: 0x{hr:X8}");
    return;
}

PFResult result = PFServices.Initialize();
```

During shutdown, dispose PlayFab handles first, then uninitialize PlayFab, then uninitialize XGameRuntime:

```csharp
playerEntity?.Dispose();
serviceConfig?.Dispose();

await PFServices.UninitializeAsync();
PlayFab.XGameRuntime.Uninitialize();
```

## Verifying Installation

After installation, confirm:

| Check | Expected Result |
|---|---|
| Package Manager | **PlayFab SDK** (`microsoft.playfab.sdk`) appears in the installed package list. |
| Unity menu | **PlayFab > Change GDK** is available on supported editor platforms. |
| Console | No PlayFab assembly import errors or native plugin import errors appear. |
| Samples | Package samples can be imported from the PlayFab SDK package details page. |

## Package Contents

| Directory | Contents |
|---|---|
| `PlayFabAPI/` | Core, Services, Game Save, Multiplayer, and Party C# API layers. |
| `PlayFabTools/` | Editor tools for GDK binary discovery, copy, version selection, and plugin import settings. |
| `Samples~/` | Importable samples for Login, Game Save, Multiplayer, Party, and Party tests. |
| `Documents~/` | Public documentation. |

## Upgrading

- **Git URL installs:** Select the package in Package Manager and update to the desired revision.
- **Tarball installs:** Pull the latest repository changes, run `packTarball.ps1` again, then install the new `.tgz`.

## Uninstalling

Remove **PlayFab SDK** from Package Manager. Unity may keep `com.unity.microsoft.gdk.discovery`, `com.unity.microsoft.gdk`, or `com.unity.microsoft.gdk.tools` if other packages still depend on them.

## Installation Troubleshooting

| Issue | Resolution |
|---|---|
| GDK binaries are not loading | Verify GDK 2604 or later is installed, then use **PlayFab > Change GDK** to select it. |
| XUser APIs are missing | Install `com.unity.microsoft.gdk` and confirm `MICROSOFT_GDK_SUPPORT` is defined for the target platform. |
| Xbox configuration errors | Install `com.unity.microsoft.gdk.tools` and verify `MicrosoftGame.config` and sandbox setup. |
| Package does not resolve | Confirm Unity can reach `https://github.com/PlayFab/PlayFabSDK_Unity.git` and the Unity Package Manager registry. |

For runtime issues, see [Troubleshooting](Troubleshooting.md).
