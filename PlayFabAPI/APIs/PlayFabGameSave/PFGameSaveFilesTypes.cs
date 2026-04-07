// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT
namespace PlayFab
{
    // GameSave specific error codes
    public partial class HRESULT
    {
        /// <summary>
        /// User cancelled.  This is returned by the async operation if after a UI callback the response is set to cancel.
        /// </summary>
        public const int E_PF_GAMESAVE_USER_CANCELLED = unchecked((int)0x800704c7L); // same as __HRESULT_FROM_WIN32(ERROR_CANCELLED)

        /// <summary>
        /// Not initialized.  This is returned if PFGameSaveFilesInitialize() was not called.
        /// </summary>
        public const int E_PF_GAMESAVE_NOT_INITIALIZED = unchecked((int)0x89237000L);

        /// <summary>
        /// Already initialized.  This is returned if PFGameSaveFilesInitialize() was already called without a matching PFGameSaveFilesUninitializeAsync().
        /// </summary>
        public const int E_PF_GAMESAVE_ALREADY_INITIALIZED = unchecked((int)0x89237001L);

        /// <summary>
        /// User already added.  This is returned if PFGameSaveFilesAddUserWithUiAsync() is called with the same user.  
        /// To re-add a user, you must re-init by calling PFGameSaveFilesUninitializeAsync() and when that 
        /// completes call PFGameSaveFilesInitialize().
        /// </summary>
        public const int E_PF_GAMESAVE_USER_ALREADY_ADDED = unchecked((int)0x89237002L);

        /// <summary>
        /// User not found.  
        /// This is returned if PFGameSaveFilesAddUserWithUiAsync() was not called or has not completed yet.
        /// </summary>
        public const int E_PF_GAMESAVE_USER_NOT_ADDED = unchecked((int)0x89237003L);
    }

    /// <summary>
    /// Options to use when initializing the game save system.
    /// </summary>
    public enum PFGameSaveInitOptions : ulong
    {
        /// <summary>
        /// Other options might be added in future release
        /// </summary>
        None = Interop.PFGameSaveInitOptions.None
    }

    /// <summary>
    /// PlayFab Game Save initialization arguments.
    /// </summary>
    public struct PFGameSaveInitArgs
    {
        /// <summary>
        /// The initialization options.
        /// </summary>
        public PFGameSaveInitOptions Options;

#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX
        /// <summary>
        /// On some platforms, the game can store save files in various locations (e.g. My Docs, local app data, etc)
        /// On those platforms, this lets the game specify where save files are stored.
        /// This should be the root folder of where the game save files are stored.
        /// All its files and subfolders will be synchronized with the cloud.
        /// </summary>
        public string SaveFolder;
#endif

        internal unsafe static void ToInterop(PFGameSaveInitArgs self, Interop.PFGameSaveInitArgs* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->options = (ulong)self.Options;

#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX
            if (self.SaveFolder != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SaveFolder, &interop->saveFolder, buffer);
            }
#endif
        }
    }

    /// <summary>
    /// Options for adding a user to the Game Save system.
    /// </summary>
    public enum PFGameSaveFilesAddUserOptions : uint
    {
        /// <summary>
        /// Default behavior
        /// </summary>
        None = Interop.PFGameSaveFilesAddUserOptions.None,
    
        /// <summary>
        /// Sync using the most recently verified prior cloud save state (a previously loaded save that was later replaced by a newer upload).
        /// Use when you suspect the latest upload is bad (e.g. load failure, failed integrity / version check, crash during or immediately after save,
        /// player reports corrupted / regressed state) and you want to automatically recover to the last known good manifest. If no earlier verified
        /// state exists this behaves like None and the current latest is kept.
        /// </summary>
        RollbackToLastKnownGood = Interop.PFGameSaveFilesAddUserOptions.RollbackToLastKnownGood,

        /// <summary>
        /// Sync using the save state that was kept aside (the "losing" choice) from the most recent conflict resolution; falls back to latest if none.
        /// Use when you determine (or the player reports) that they chose the wrong side during the last conflict resolution dialog and you want to
        /// restore the alternate snapshot that was preserved for exactly that recovery opportunity. If no preserved conflict snapshot remains this
        /// quietly falls back to the current latest.
        /// </summary>
        RollbackToLastConflict = Interop.PFGameSaveFilesAddUserOptions.RollbackToLastConflict,
    }

    /// <summary>
    /// Sync state of the game save system
    /// </summary>
    public enum PFGameSaveFilesSyncState : uint
    {
        /// <summary>
        /// Not started
        /// </summary>
        NotStarted = Interop.PFGameSaveFilesSyncState.NotStarted,

        /// <summary>
        /// Preparing for download
        /// </summary>
        PreparingForDownload = Interop.PFGameSaveFilesSyncState.PreparingForDownload,

        /// <summary>
        /// Downloading
        /// </summary>
        Downloading = Interop.PFGameSaveFilesSyncState.Downloading,

        /// <summary>
        /// Preparing for upload
        /// </summary>
        PreparingForUpload = Interop.PFGameSaveFilesSyncState.PreparingForUpload,

        /// <summary>
        /// Uploading
        /// </summary>
        Uploading = Interop.PFGameSaveFilesSyncState.Uploading,

        /// <summary>
        /// Sync complete
        /// </summary>
        SyncComplete = Interop.PFGameSaveFilesSyncState.SyncComplete
    }

    /// <summary>
    /// Options to use when uploading game save files
    /// </summary>
    public enum PFGameSaveFilesUploadOption : uint
    {
        /// <summary>
        /// Default behavior
        /// The device will be kept active after the upload
        /// </summary>
        KeepDeviceActive = Interop.PFGameSaveFilesUploadOption.KeepDeviceActive,

        /// <summary>
        /// Release the device as active.
        /// After this, this device can no longer be used to upload game save files.
        /// To upload again on the same session, call PFGameSaveUninitializeAsync and wait for it to complete.
        /// </summary>
        ReleaseDeviceAsActive = Interop.PFGameSaveFilesUploadOption.ReleaseDeviceAsActive
    }

    /// <summary>
    /// Game save descriptor.
    /// </summary>
    public struct PFGameSaveDescriptor
    {
        /// <summary>
        /// Relevant time of the descriptor (can differ depending upon state and usage)
        /// </summary>
        public long Time;

        /// <summary>
        /// total bytes of the save
        /// </summary>
        public ulong TotalBytes;

        /// <summary>
        /// size of the pending upload, if any.
        /// </summary>
        public ulong UploadedBytes;

        /// <summary>
        /// Device Type (limit to 255 characters)
        /// </summary>
        public string DeviceType;

        /// <summary>
        /// A unique identifier for the device (limit to 255 characters)
        /// </summary>
        public string DeviceId;

        /// <summary>
        /// User friendly name for the device, e.g. "My Xbox One" (limit to 255 characters)
        /// </summary>
        public string DeviceFriendlyName;

        /// <summary>
        /// If the game saves pfthumbnail.png at the root this will be the URI to it, otherwise it will be blank. (limit to 2047 characters)
        /// </summary>
        public string ThumbnailUri;

        /// <summary>
        /// Short description of the save, can be shown in the Conflict or Device Contention UX along with the thumbnail. (limit to 4095 characters)
        /// </summary>
        public string ShortSaveDescription;

        internal unsafe PFGameSaveDescriptor(Interop.PFGameSaveDescriptor interop)
        {
            Time = interop.time;
            TotalBytes = interop.totalBytes;
            UploadedBytes = interop.uploadedBytes;
            DeviceType = (interop.deviceType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.deviceType);
            DeviceId = (interop.deviceId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.deviceId);
            DeviceFriendlyName = (interop.deviceFriendlyName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.deviceFriendlyName);
            ThumbnailUri = (interop.thumbnailUri == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.thumbnailUri);
            ShortSaveDescription = (interop.shortSaveDescription == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.shortSaveDescription);
        }

        internal unsafe static void ToInterop(PFGameSaveDescriptor self, Interop.PFGameSaveDescriptor* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->time = self.Time;
            interop->totalBytes = self.TotalBytes;
            interop->uploadedBytes = self.UploadedBytes;

            if (self.DeviceType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DeviceType, &interop->deviceType, buffer);
            }

            if (self.DeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DeviceId, &interop->deviceId, buffer);
            }

            if (self.DeviceFriendlyName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DeviceFriendlyName, &interop->deviceFriendlyName, buffer);
            }

            if (self.ThumbnailUri != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ThumbnailUri, &interop->thumbnailUri, buffer);
            }

            if (self.ShortSaveDescription != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ShortSaveDescription, &interop->shortSaveDescription, buffer);
            }
        }
    }
    
    public delegate void PFGameSaveFilesActiveDeviceChangedCallback(
        PFLocalUser localUser,
        PFGameSaveDescriptor activeDevice,
        object context
    );
}
#endif
