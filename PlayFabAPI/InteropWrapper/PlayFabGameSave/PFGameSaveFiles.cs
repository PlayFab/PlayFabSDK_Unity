// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.GameSave
{
    /// <summary>
    /// Wrapper for PlayFab Game Save Files functionality
    /// </summary>
    public static partial class PFGameSaveFiles
    {
        /// <summary>
        /// Initialize PlayFabGameSave Files functionality.
        /// </summary>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesInitialize(PFGameSaveInitArgs args)
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFGameSaveInitArgs* argsInterop = stackalloc Interop.PFGameSaveInitArgs[1];
                PFGameSaveInitArgs.ToInterop(args, argsInterop, disposableBuffer);

                int result = Interop.Methods.PFGameSaveFilesInitialize(argsInterop);
                return new(result);
            }
        }

        /// <summary>
        /// Adds a user to the PlayFab Game Save Files system with UI.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="options">Options for adding a user.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public static Task<PFResult> PFGameSaveFilesAddUserWithUiAsync(PFLocalUserHandle localUserHandle, PFGameSaveFilesAddUserOptions options)
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.PFGameSaveFilesAddUserWithUiResult(asyncBlock);
                    completionSource.SetResult(new PFResult(hr));
                });

                int hr = Interop.Methods.PFGameSaveFilesAddUserWithUiAsync(localUserHandle.Handle, (Interop.PFGameSaveFilesAddUserOptions)options, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets the folder path where save data is stored.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult<string> PFGameSaveFilesGetFolder(PFLocalUserHandle localUserHandle)
        {
            unsafe
            {
                ulong folderSize;
                int hr = Interop.Methods.PFGameSaveFilesGetFolderSize(localUserHandle.Handle, &folderSize);

                if (HRESULT.Failed(hr))
                {
                    return new(hr);
                }

                sbyte* folderInterop = stackalloc sbyte[(int)folderSize];
                hr = Interop.Methods.PFGameSaveFilesGetFolder(localUserHandle.Handle, folderSize, folderInterop, null);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(WrapperHelpers.InteropToString(folderInterop), hr);
            }
        }

        /// <summary>
        /// Uploads the save data with UI.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="option">The upload option.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public static Task<PFResult> PFGameSaveFilesUploadWithUiAsync(PFLocalUserHandle localUserHandle, PFGameSaveFilesUploadOption option)
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.PFGameSaveFilesUploadWithUiResult(asyncBlock);
                    completionSource.SetResult(new PFResult(hr));
                });

                int hr = Interop.Methods.PFGameSaveFilesUploadWithUiAsync(localUserHandle.Handle, (Interop.PFGameSaveFilesUploadOption)option, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets the remaining quota for save data.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult<long> PFGameSaveFilesGetRemainingQuota(PFLocalUserHandle localUserHandle)
        {
            unsafe
            {
                long* quotaInterop = stackalloc long[1];
                int hr = Interop.Methods.PFGameSaveFilesGetRemainingQuota(localUserHandle.Handle, quotaInterop);

                return new(*quotaInterop, hr);
            }
        }

        /// <summary>
        /// Checks if the user is connected to the cloud.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult<bool> PFGameSaveFilesIsConnectedToCloud(PFLocalUserHandle localUserHandle)
        {
            unsafe
            {
                byte* connectedInterop = stackalloc byte[1];
                int hr = Interop.Methods.PFGameSaveFilesIsConnectedToCloud(localUserHandle.Handle, connectedInterop);

                return new(WrapperHelpers.InteropToBool(*connectedInterop), hr);
            }
        }

        /// <summary>
        /// Sets a callback for when the active device changes.
        /// </summary>
        /// <param name="callback">The callback to invoke when the active device changes.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesSetActiveDeviceChangedCallback(PFGameSaveFilesActiveDeviceChangedCallback callback, object context)
        {
            return _PFGameSaveFilesActiveDeviceChangedCallbackManager.AddCallback(callback, context);
        }

        /// <summary>
        /// Sets the save description.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="shortSaveDescription">A short description for the save.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public static Task<PFResult> PFGameSaveFilesSetSaveDescriptionAsync(PFLocalUserHandle localUserHandle, string shortSaveDescription)
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.PFGameSaveFilesSetSaveDescriptionResult(asyncBlock);
                    completionSource.SetResult(new PFResult(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                sbyte* shortSaveDescriptionInterop;
                WrapperHelpers.StringToInterop(shortSaveDescription, &shortSaveDescriptionInterop, disposableBuffer);
                int hr = Interop.Methods.PFGameSaveFilesSetSaveDescriptionAsync(localUserHandle.Handle, shortSaveDescriptionInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        public static Task<PFResult> PFGameSaveFilesResetCloudAsync(PFLocalUserHandle localUserHandle)
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.PFGameSaveFilesResetCloudResult(asyncBlock);
                    completionSource.SetResult(new PFResult(hr));
                });

                int hr = Interop.Methods.PFGameSaveFilesResetCloudAsync(localUserHandle.Handle, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        public static Task<PFResult> PFGameSaveFilesUninitializeAsync()
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.PFGameSaveFilesUninitializeResult(asyncBlock);

                    completionSource.SetResult(new PFResult(hr));
                });

                int hr = Interop.Methods.PFGameSaveFilesUninitializeAsync((Interop.XAsyncBlock*)asyncBlock.Handle);
                
                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        private static readonly PFGameSaveFilesActiveDeviceChangedCallbackManager _PFGameSaveFilesActiveDeviceChangedCallbackManager = new();

        private class PFGameSaveFilesActiveDeviceChangedCallbackManager :
            InteropCallbackManager<PFGameSaveFilesActiveDeviceChangedCallback>
        {
            private Interop.PFGameSaveFilesActiveDeviceChangedCallback _interopCallback;

            internal unsafe void InteropPInvokeCallback(IntPtr localUserHandle, Interop.PFGameSaveDescriptor* activeDevice, void* context)
            {
                if (Callback == null) return;

                var activeDeviceWrapper = new PFGameSaveDescriptor(*activeDevice);

                IssueEventCallback(new PFLocalUser(new(localUserHandle)), activeDeviceWrapper);
            }

            internal PFResult AddCallback(PFGameSaveFilesActiveDeviceChangedCallback callback, object context)
            {
                int hr;

                unsafe
                {
                    _interopCallback = new Interop.PFGameSaveFilesActiveDeviceChangedCallback(InteropPInvokeCallback);
                    hr = Interop.Methods.PFGameSaveFilesSetActiveDeviceChangedCallback(AsyncHelpers.DefaultQueue.handle.intPtr, _interopCallback, (void*)IntPtr.Zero);
                }

                if (HRESULT.Succeeded(hr))
                {
                    SetCallback(callback, context);
                }

                return new(hr);
            }

            private unsafe void IssueEventCallback(PFLocalUser localUser, PFGameSaveDescriptor activeDevice)
            {
                TryGetCallback(out PFGameSaveFilesActiveDeviceChangedCallback callback, out object context);
                callback.Invoke(localUser, activeDevice, context);
            }
        }
    }
}
