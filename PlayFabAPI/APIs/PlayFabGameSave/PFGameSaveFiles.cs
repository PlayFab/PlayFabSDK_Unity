// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT
using System.Threading.Tasks;

namespace PlayFab
{
    public static partial class PFGameSaveFiles
    {
        /// <summary>
        /// Initializes the PlayFab Game Save library instance.
        /// </summary>
        /// <remarks>
        /// This will internally call PFInitialize(nullptr) if it hasn't been called already by the
        /// title. If control of PFCore background work is needed, the title should explicitly call
        /// PFInitialize and PFUninitialize.
        /// </remarks>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult Initialize(PFGameSaveInitArgs initArgs)
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesInitialize(initArgs);
        }

        /// <summary>
        /// Sets the active device changed callback.
        /// When this callback is triggered, it means the user moved to another device so 
        /// this title should return to main menu
        /// </summary>
        /// <param name="callback">The callback to be invoked when the active device changes.</param>
        /// <param name="context">The context to be passed to the callback.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult SetActiveDeviceChangedCallback(PFGameSaveFilesActiveDeviceChangedCallback callback, object context)
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesSetActiveDeviceChangedCallback(callback, context);
        }

        /// <summary>
        /// Cleanup PlayFab Game Save library instance.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// To retrieve the result of a call to PFGameSaveFilesUninitializeAsync, call PFGameSaveFilesUninitializeResult.
        /// This will internally call PFUninitializeAsync() if PFGameSaveInitialize() needed 
        /// to call PFInitialize() internally.
        /// </remarks>
        public static Task<PFResult> UninitializeAsync()
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesUninitializeAsync();
        }
    }

    public partial class PFLocalUser
    {
        /// <summary>
        /// Adds a user to the game save system.
        /// This downloads save state from the cloud as needed, and might trigger these UI callbacks:
        ///     PFGameSaveFilesUiProgressCallback, 
        ///     PFGameSaveFilesUiSyncFailedCallback, 
        ///     PFGameSaveFilesUiActiveDeviceContentionCallback,
        ///     PFGameSaveFilesUiConflictCallback,
        ///     PFGameSaveFilesUiOutOfStorageCallback
        /// 
        /// See PFGameSaveFilesSetUiCallbacks for more detail.
        /// PFGameSaveFilesInitialize must be called prior.
        /// 
        /// On Xbox and Windows platforms, stock UI is provided by the system.
        /// </summary>
        /// <param name="options">Options to use when adding the user.</param>
        /// <returns>
        /// To retrieve the result of a call to PFGameSaveFilesAddUserWithUiAsync, call 
        /// PFGameSaveFilesAddUserWithUiResult. After this call completes, you can call 
        /// PFGameSaveFilesGetFolder to get the root folder of the game save files 
        /// and folders for this user.  All the root folder's files and subfolders will 
        /// be synchronized with the cloud.
        /// 
        /// This can only be called once per user, typically before showing the game's main menu.
        /// To re-trigger the download the same user, call PFGameSaveFilesUninitializeAsync and wait 
        /// for it to complete first
        /// </returns>
        public Task<PFResult> GameSaveFilesAddUserWithUiAsync(PFGameSaveFilesAddUserOptions options)
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesAddUserWithUiAsync(InteropHandle, options);
        }

        /// <summary>
        /// Returns the root folder of the game save files and folders for this user.
        /// All its files and subfolders will be synchronized with the cloud.
        /// The user must be added first using PFGameSaveFilesAddUserWithUiAsync.
        /// </summary>
        /// <returns>Result code for this API operation containing the root folder of the game save 
        /// files and folders.</returns>
        public PFResult<string> GameSaveFilesGetFolder()
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesGetFolder(InteropHandle);
        }

        /// <summary>
        /// Uploads all the files and folders in the folder returned by PFGameSaveFilesGetFolder().
        /// The user must be added first.
        /// 
        /// On non-Windows platforms, the upload happens in the same process as the game and 
        /// might trigger these UI callbacks:
        ///    PFGameSaveFilesUiProgressCallback,
        ///    PFGameSaveFilesUiSyncFailedCallback
        /// 
        /// On Xbox and Windows platforms, the upload is done out of process and stock UI is 
        /// provided by the system.  Calling this API is optional on Xbox and Windows platforms as the 
        /// upload will automatically happen when the game isn't running.
        /// </summary>
        /// <param name="option">Option to use when uploading the files and folders.</param>
        /// <returns>Result code for this API operation.</returns>
        public Task<PFResult> GameSaveFilesUploadWithUiAsync(PFGameSaveFilesUploadOption option)
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesUploadWithUiAsync(InteropHandle, option);
        }

        /// <summary>
        /// Returns the amount of data available to store save data in bytes using the PFGameSaveFiles API.
        /// Going over quota will return a negative number and cause the service to block the upload.
        /// </summary>
        /// <returns>Result code for this API operation. 
        /// If called when disconnected from cloud, it will return E_PF_GAMESAVE_DISCONNECTED_FROM_CLOUD.
        /// </returns>
        public PFResult<long> GameSaveFilesGetRemainingQuota()
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesGetRemainingQuota(InteropHandle);
        }

        /// <summary>
        /// Returns if the user is connected to cloud.
        /// 
        /// The user can be disconnected from cloud when calling PFGameSaveFilesAddUserWithUiAsync() without network access and 
        /// the user chooses PFGameSaveFilesUiSyncFailedUserAction::UseOffline in the PFGameSaveFilesUiSyncFailedCallback.
        /// The user can also be disconnected from cloud at anytime if another device becomes the active device.
        /// 
        /// When disconnected from cloud, PFGameSaveFilesAddUserWithUiAsync() can be called again if you want to try connect to the cloud.
        /// It will show the failure UI again if the network is still offline.  No need to re-init gamesave but you can if desired.
        /// 
        /// While disconnected from cloud, PFGameSaveFilesUploadWithUiAsync() will not do anything but return E_PF_GAMESAVE_DISCONNECTED_FROM_CLOUD 
        /// in the async completion even if there's network access.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        public PFResult<bool> GameSaveFilesIsConnectedToCloud()
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesIsConnectedToCloud(InteropHandle);
        }

        /// <summary>
        /// Set a short save description of the pending game save.
        /// This can be seen in the conflict or active device contention UI
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        public Task<PFResult> GameSaveFilesSetSaveDescriptionAsync(string shortSaveDescription)
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesSetSaveDescriptionAsync(InteropHandle, shortSaveDescription);
        }

        /// <summary>
        /// This resets the cloud game save state for this user.
        /// Normally this does not need to be called but might be useful during development or testing.
        /// This does not delete or alter the local game save.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        public Task<PFResult> GameSaveFilesResetCloudAsync()
        {
            return InteropWrapper.GameSave.PFGameSaveFiles.PFGameSaveFilesResetCloudAsync(InteropHandle);
        }
    }
}
#endif
