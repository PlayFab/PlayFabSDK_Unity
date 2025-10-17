// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT
namespace PlayFab
{
    /// <summary>
    /// Progress of the current operation callback.
    /// </summary>
    /// <param name="localUser">Local user.</param>
    /// <param name="syncState">Sync state of the operation.</param>
    /// <param name="context">Context to pass to the callback.</param>
    public delegate void PFGameSaveFilesUiProgressCallback(
        PFLocalUser localUser,
        PFGameSaveFilesSyncState syncState,
        object context
    );

    /// <summary>
    /// Sync failed callback.
    /// </summary>
    /// <param name="localUser">Local user.</param>
    /// <param name="syncState">Sync state of the operation.</param>
    /// <param name="error">The failure error code.</param>
    /// <param name="context">Context to pass to the callback.</param>
    public delegate void PFGameSaveFilesUiSyncFailedCallback(
        PFLocalUser localUser,
        PFGameSaveFilesSyncState syncState,
        int error,
        object context
    );

    /// <summary>
    /// Active device contention callback.
    /// </summary>
    /// <param name="localUser">Local user.</param>
    /// <param name="localGameSave">Descriptor of local save game.</param>
    /// <param name="remoteGameSave">Descriptor of remote save game.</param>
    /// <param name="context">Context to pass to the callback.</param>
    public delegate void PFGameSaveFilesUiActiveDeviceContentionCallback(
        PFLocalUser localUser,
        PFGameSaveDescriptor localGameSave,
        PFGameSaveDescriptor remoteGameSave,
        object context
    );

    /// <summary>
    /// Conflict callback.
    /// </summary>
    /// <param name="localGameSave">Descriptor of local save game.</param>
    /// <param name="remoteGameSave">Descriptor of remote save game.</param>
    /// <param name="context">Context to pass to the callback.</param>
    public delegate void PFGameSaveFilesUiConflictCallback(
        PFLocalUser localUser,
        PFGameSaveDescriptor localGameSave,
        PFGameSaveDescriptor remoteGameSave,
        object context
    );

    /// <summary>
    /// Callback triggered when the local device is out of storage space.
    /// </summary>
    /// <param name="localUser">Local user.</param>
    /// <param name="requiredBytes">Required bytes.</param>
    /// <param name="context">Context to pass to the callback.</param>
    public delegate void PFGameSaveFilesUiOutOfStorageCallback(
        PFLocalUser localUser,
        ulong requiredBytes,
        object context
    );

    /// <summary>
    /// UI callbacks for game save operations.
    /// </summary>
    public struct PFGameSaveUICallbacks
    {
        /// <summary>
        /// Optional callback for upload and download progress.
        /// </summary>
        public PFGameSaveFilesUiProgressCallback ProgressCallback;

        /// <summary>
        /// Context to pass to the progressCallback.
        /// </summary>
        public object ProgressContext;

        /// <summary>
        /// Optional callback for sync failure.
        /// </summary>
        public PFGameSaveFilesUiSyncFailedCallback SyncFailedCallback;

        /// <summary>
        /// Context to pass to the syncFailedCallback.
        /// </summary>
        public object SyncFailedContext;

        /// <summary>
        /// Optional callback for active device contention
        /// </summary>
        public PFGameSaveFilesUiActiveDeviceContentionCallback ActiveDeviceContentionCallback;

        /// <summary>
        /// Context to pass to the activeDeviceContentionCallback.
        /// </summary>
        public object ActiveDeviceContentionContext;

        /// <summary>
        /// Optional callback for conflict between local and remote save data.
        /// </summary>
        public PFGameSaveFilesUiConflictCallback ConflictCallback;

        /// <summary>
        /// Context to pass to the conflictCallback.
        /// </summary>
        public object ConflictContext;

        /// <summary>
        /// Optional callback for out of local storage.
        /// </summary>
        public PFGameSaveFilesUiOutOfStorageCallback OutOfStorageCallback;

        /// <summary>
        /// Context to pass to the outOfStorageCallback.
        /// </summary>
        public object OutOfStorageContext;
    }

    /// <summary>
    /// UI progress user actions.
    /// </summary>
    public enum PFGameSaveFilesUiProgressUserAction : uint
    {
        /// <summary>
        /// Cancel the current operation.
        /// </summary>
        Cancel = Interop.PFGameSaveFilesUiProgressUserAction.Cancel
    }

    /// <summary>
    /// UI sync failed user actions.
    /// </summary>
    public enum PFGameSaveFilesUiSyncFailedUserAction : uint
    {
        /// <summary>
        /// Cancel the current operation.
        /// </summary>
        Cancel = Interop.PFGameSaveFilesUiSyncFailedUserAction.Cancel,

        /// <summary>
        /// Retry the current operation.
        /// </summary>
        Retry = Interop.PFGameSaveFilesUiSyncFailedUserAction.Retry,

        /// <summary>
        /// Treat the user as disconnected from cloud.
        /// This action may only be set during PFGameSaveFilesAddUserWithUiAsync()
        /// 
        /// If PFGameSaveFilesAddUserWithUiAsync() was called without network access and 
        /// the user chooses PFGameSaveFilesUiSyncFailedUserAction::UseOffline in the PFGameSaveFilesUiSyncFailedCallback
        /// then the user is considered disconnected from cloud.
        /// 
        /// When the user is disconnected from cloud, PFGameSaveFilesAddUserWithUiAsync() can be called again if you want to try to 
        /// make the user connected to cloud. 
        /// It will show the failure UI again if the network is still offline.  No need to re-init gamesave but you can if desired.
        /// 
        /// While the user is disconnected from cloud, PFGameSaveFilesUploadWithUiAsync() will not do anything but return 
        /// E_PF_GAMESAVE_DISCONNECTED_FROM_CLOUD in the async completion even if there's network access.
        /// </summary>
        UseOffline = Interop.PFGameSaveFilesUiSyncFailedUserAction.UseOffline
    }

    /// <summary>
    /// UI active device contention user actions.
    /// </summary>
    public enum PFGameSaveFilesUiActiveDeviceContentionUserAction : uint
    {
        /// <summary>
        /// Cancel the current operation.
        /// </summary>
        Cancel = Interop.PFGameSaveFilesUiActiveDeviceContentionUserAction.Cancel,

        /// <summary>
        /// Retry the current operation.
        /// </summary>
        Retry = Interop.PFGameSaveFilesUiActiveDeviceContentionUserAction.Retry,

        /// <summary>
        /// Sync the last saved data.  This makes the local device active.
        /// 
        /// After this, the remote device will not be able to upload since it is no longer the active device.
        /// This prevents unsynchronized progression from multiple devices 
        /// </summary>
        SyncLastSavedData = Interop.PFGameSaveFilesUiActiveDeviceContentionUserAction.SyncLastSavedData
    }

    /// <summary>
    /// UI conflict user actions.
    /// </summary>
    public enum PFGameSaveFilesUiConflictUserAction : uint
    {
        /// <summary>
        /// Cancel the current operation.
        /// </summary>
        Cancel = Interop.PFGameSaveFilesUiConflictUserAction.Cancel,

        /// <summary>
        /// Take the local version.
        /// </summary>
        TakeLocal = Interop.PFGameSaveFilesUiConflictUserAction.TakeLocal,

        /// <summary>
        /// Take the remote version.
        /// </summary>
        TakeRemote = Interop.PFGameSaveFilesUiConflictUserAction.TakeRemote
    }

    /// <summary>
    /// UI out of storage user actions.
    /// </summary>
    public enum PFGameSaveFilesUiOutOfStorageUserAction : uint
    {
        /// <summary>
        /// Cancel the current operation.
        /// </summary>
        Cancel = Interop.PFGameSaveFilesUiOutOfStorageUserAction.Cancel,

        /// <summary>
        /// Local storage space was cleared, so retry
        /// </summary>
        Retry = Interop.PFGameSaveFilesUiOutOfStorageUserAction.Retry
    }

    public static partial class PFGameSaveFiles
    {
        /// <summary>
        /// Sets the UI callbacks.  These UI callbacks will trigger during PFGameSaveFilesAddUserWithUiAsync() or 
        /// PFGameSaveFilesUploadWithUiAsync().
        /// 
        /// PFGameSaveFilesAddUserWithUiAsync() may trigger any UI callback while 
        /// PFGameSaveFilesUploadWithUiAsync() will only trigger PFGameSaveFilesUiProgressCallback and/or 
        /// PFGameSaveFilesUiSyncFailedCallback.
        /// 
        /// On non-Windows platforms, setting these callbacks is required to trigger game rendered UI dialogs.
        /// 
        /// On Xbox and Windows platforms, file sync is done in out of process and stock UI is provided by the platform
        /// however the title can set these callbacks to render custom UI dialogs as desired.
        /// </summary>
        /// <param name="callbacks">The callbacks to set.</param>
        public static PFResult SetUiCallbacks(PFGameSaveUICallbacks callbacks)
        {
            return InteropWrapper.GameSave.PFGameSaveFilesUI.PFGameSaveFilesSetUiCallbacks(callbacks);
        }
    }

    public partial class PFLocalUser
    {
        /// <summary>
        /// For use inside PFGameSaveFilesUiProgressCallback.
        /// Get the progress of the current operation.
        /// </summary>
        /// <param name="syncState">Sync state of the operation.</param>
        /// <param name="current">Current progress.</param>
        /// <param name="total">Total progress.</param>
        public PFResult GameSaveFilesUiProgressGetProgress(out PFGameSaveFilesSyncState syncState, out ulong current, out ulong total)
        {
            return InteropWrapper.GameSave.PFGameSaveFilesUI.PFGameSaveFilesUiProgressGetProgress(InteropHandle, out syncState, out current, out total);
        }

        /// <summary>
        /// Sets the user response for the PFGameSaveFilesUiProgressCallback.
        /// This can be called inside or outside of the callback.  The state machine won't progress until the 
        /// the user chooses a response, or the async API is canceled.
        /// </summary>
        /// <param name="action">The user action.</param>
        public PFResult GameSaveFilesSetUiProgressResponse(PFGameSaveFilesUiProgressUserAction action)
        {
            return InteropWrapper.GameSave.PFGameSaveFilesUI.PFGameSaveFilesSetUiProgressResponse(InteropHandle, action);
        }

        /// <summary>
        /// Sets the user response for the PFGameSaveFilesUiSyncFailedCallback.
        /// This can be called inside or outside of the callback.  The state machine won't progress until the 
        /// the user chooses a response, or the async API is canceled.
        /// </summary>
        /// <param name="action">The user action.</param>
        public PFResult GameSaveFilesSetUiSyncFailedResponse(PFGameSaveFilesUiSyncFailedUserAction action)
        {
            return InteropWrapper.GameSave.PFGameSaveFilesUI.PFGameSaveFilesSetUiSyncFailedResponse(InteropHandle, action);
        }

        /// <summary>
        /// Sets the user response for the PFGameSaveFilesUiActiveDeviceContentionCallback.
        /// This can be called inside or outside of the callback.  The state machine won't progress until the 
        /// the user chooses a response, or the async API is canceled.
        /// </summary>
        /// <param name="action">The user action.</param>
        public PFResult GameSaveFilesSetUiActiveDeviceContentionResponse(PFGameSaveFilesUiActiveDeviceContentionUserAction action)
        {
            return InteropWrapper.GameSave.PFGameSaveFilesUI.PFGameSaveFilesSetUiActiveDeviceContentionResponse(InteropHandle, action);
        }

        /// <summary>
        /// Sets the user response for the PFGameSaveFilesUiConflictCallback.
        /// This can be called inside or outside of the callback.  The state machine won't progress until the 
        /// the user chooses a response, or the async API is canceled.
        /// </summary>
        /// <param name="action">The user action.</param>
        public PFResult GameSaveFilesSetUiConflictResponse(PFGameSaveFilesUiConflictUserAction action)
        {
            return InteropWrapper.GameSave.PFGameSaveFilesUI.PFGameSaveFilesSetUiConflictResponse(InteropHandle, action);
        }

        /// <summary>
        /// Sets the user response for the PFGameSaveFilesUiOutOfStorageCallback.
        /// This can be called inside or outside of the callback.  The state machine won't progress until the 
        /// the user chooses a response, or the async API is canceled.
        /// </summary>
        /// <param name="action">The user action.</param>
        public PFResult GameSaveFilesSetUiOutOfStorageResponse(PFGameSaveFilesUiOutOfStorageUserAction action)
        {
            return InteropWrapper.GameSave.PFGameSaveFilesUI.PFGameSaveFilesSetUiOutOfStorageResponse(InteropHandle, action);
        }
    }
}
#endif
