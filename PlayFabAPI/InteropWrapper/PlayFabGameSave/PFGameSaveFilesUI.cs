// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.GameSave
{
    /// <summary>
    /// Wrapper for PlayFab Game Save Files UI functionality
    /// </summary>
    public static partial class PFGameSaveFilesUI
    {
        /// <summary>
        /// Sets the UI callbacks for the game save system.
        /// </summary>
        /// <param name="callbacks">The callbacks to register.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesSetUiCallbacks(PFGameSaveUICallbacks callbacks)
        {
            unsafe
            {
                Interop.PFGameSaveUICallbacks* callbacksInterop = stackalloc Interop.PFGameSaveUICallbacks[1];
                callbacksInterop->progressCallback = Marshal.GetFunctionPointerForDelegate(_PFGameSaveFilesUiProgressCallbackManager.GetInteropCallback());
                callbacksInterop->syncFailedCallback = Marshal.GetFunctionPointerForDelegate(_PFGameSaveFilesUiSyncFailedCallbackManager.GetInteropCallback());
                callbacksInterop->activeDeviceContentionCallback = Marshal.GetFunctionPointerForDelegate(_PFGameSaveFilesUiActiveDeviceContentionCallbackManager.GetInteropCallback());
                callbacksInterop->conflictCallback = Marshal.GetFunctionPointerForDelegate(_PFGameSaveFilesUiConflictCallbackManager.GetInteropCallback());
                callbacksInterop->outOfStorageCallback = Marshal.GetFunctionPointerForDelegate(_PFGameSaveFilesUiOutOfStorageCallbackManager.GetInteropCallback());
                int hr = Interop.Methods.PFGameSaveFilesSetUiCallbacks(callbacksInterop);

                if (HRESULT.Succeeded(hr))
                {
                    _PFGameSaveFilesUiProgressCallbackManager.SetCallback(callbacks.ProgressCallback, callbacks.ProgressContext);
                    _PFGameSaveFilesUiSyncFailedCallbackManager.SetCallback(callbacks.SyncFailedCallback, callbacks.SyncFailedContext);
                    _PFGameSaveFilesUiActiveDeviceContentionCallbackManager.SetCallback(callbacks.ActiveDeviceContentionCallback, callbacks.ActiveDeviceContentionContext);
                    _PFGameSaveFilesUiConflictCallbackManager.SetCallback(callbacks.ConflictCallback, callbacks.ConflictContext);
                    _PFGameSaveFilesUiOutOfStorageCallbackManager.SetCallback(callbacks.OutOfStorageCallback, callbacks.OutOfStorageContext);
                }

                return new(hr);
            }
        }

        /// <summary>
        /// Gets the progress of the game save synchronization.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="syncState">The current synchronization state.</param>
        /// <param name="current">The current progress value.</param>
        /// <param name="total">The total progress value.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesUiProgressGetProgress(PFLocalUserHandle localUserHandle, out PFGameSaveFilesSyncState syncState, out ulong current, out ulong total)
        {
            unsafe
            {
                Interop.PFGameSaveFilesSyncState* state = stackalloc Interop.PFGameSaveFilesSyncState[1];
                ulong* currentValue = stackalloc ulong[1];
                ulong* totalValue = stackalloc ulong[1];

                int hr = Interop.Methods.PFGameSaveFilesUiProgressGetProgress(localUserHandle.Handle, state, currentValue, totalValue);

                syncState = (PFGameSaveFilesSyncState)(*state);
                current = *currentValue;
                total = *totalValue;

                return new(hr);
            }
        }

        /// <summary>
        /// Sets the response to a progress UI.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="action">The user action.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesSetUiProgressResponse(PFLocalUserHandle localUserHandle, PFGameSaveFilesUiProgressUserAction action)
        {
            int hr = Interop.Methods.PFGameSaveFilesSetUiProgressResponse(localUserHandle.Handle, (Interop.PFGameSaveFilesUiProgressUserAction)action);
            return new(hr);
        }

        /// <summary>
        /// Sets the response to a sync failed UI.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="action">The user action.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesSetUiSyncFailedResponse(PFLocalUserHandle localUserHandle, PFGameSaveFilesUiSyncFailedUserAction action)
        {
            int hr = Interop.Methods.PFGameSaveFilesSetUiSyncFailedResponse(localUserHandle.Handle, (Interop.PFGameSaveFilesUiSyncFailedUserAction)action);
            return new(hr);
        }

        /// <summary>
        /// Sets the response to an active device contention UI.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="action">The user action.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesSetUiActiveDeviceContentionResponse(PFLocalUserHandle localUserHandle, PFGameSaveFilesUiActiveDeviceContentionUserAction action)
        {
            int hr = Interop.Methods.PFGameSaveFilesSetUiActiveDeviceContentionResponse(localUserHandle.Handle, (Interop.PFGameSaveFilesUiActiveDeviceContentionUserAction)action);
            return new(hr);
        }

        /// <summary>
        /// Sets the response to a conflict UI.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="action">The user action.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesSetUiConflictResponse(PFLocalUserHandle localUserHandle, PFGameSaveFilesUiConflictUserAction action)
        {
            int hr = Interop.Methods.PFGameSaveFilesSetUiConflictResponse(localUserHandle.Handle, (Interop.PFGameSaveFilesUiConflictUserAction)action);
            return new(hr);
        }

        /// <summary>
        /// Sets the response to an out of storage UI.
        /// </summary>
        /// <param name="localUserHandle">The local user handle.</param>
        /// <param name="action">The user action.</param>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult PFGameSaveFilesSetUiOutOfStorageResponse(PFLocalUserHandle localUserHandle, PFGameSaveFilesUiOutOfStorageUserAction action)
        {
            int hr = Interop.Methods.PFGameSaveFilesSetUiOutOfStorageResponse(localUserHandle.Handle, (Interop.PFGameSaveFilesUiOutOfStorageUserAction)action);
            return new(hr);
        }

        private static readonly PFGameSaveFilesUiProgressCallbackManager _PFGameSaveFilesUiProgressCallbackManager = new();
        private static readonly PFGameSaveFilesUiSyncFailedCallbackManager _PFGameSaveFilesUiSyncFailedCallbackManager = new();
        private static readonly PFGameSaveFilesUiActiveDeviceContentionCallbackManager _PFGameSaveFilesUiActiveDeviceContentionCallbackManager = new();
        private static readonly PFGameSaveFilesUiConflictCallbackManager _PFGameSaveFilesUiConflictCallbackManager = new();
        private static readonly PFGameSaveFilesUiOutOfStorageCallbackManager _PFGameSaveFilesUiOutOfStorageCallbackManager = new();

        private class PFGameSaveFilesUiProgressCallbackManager :
            InteropCallbackManager<PFGameSaveFilesUiProgressCallback>
        {
            private Interop.PFGameSaveFilesUiProgressCallback _interopCallback;

            internal unsafe Interop.PFGameSaveFilesUiProgressCallback GetInteropCallback()
            {
                if (_interopCallback == null)
                {
                    _interopCallback = new Interop.PFGameSaveFilesUiProgressCallback(InteropPInvokeCallback);
                }
                return _interopCallback;
            }

            internal unsafe void InteropPInvokeCallback(IntPtr localUserHandle, Interop.PFGameSaveFilesSyncState syncState, void* context)
            {
                if (Callback == null) return;

                IssueEventCallback(new PFLocalUser(new(localUserHandle)), (PFGameSaveFilesSyncState)syncState);
            }

            private unsafe void IssueEventCallback(PFLocalUser localUser, PFGameSaveFilesSyncState syncState)
            {
                TryGetCallback(out PFGameSaveFilesUiProgressCallback callback, out object context);
                callback.Invoke(localUser, syncState, context);
            }
        }

        private class PFGameSaveFilesUiSyncFailedCallbackManager :
            InteropCallbackManager<PFGameSaveFilesUiSyncFailedCallback>
        {
            private static Interop.PFGameSaveFilesUiSyncFailedCallback _interopCallback;

            internal unsafe Interop.PFGameSaveFilesUiSyncFailedCallback GetInteropCallback()
            {
                if (_interopCallback == null)
                {
                    _interopCallback = new Interop.PFGameSaveFilesUiSyncFailedCallback(InteropPInvokeCallback);
                }
                return _interopCallback;
            }

            internal unsafe void InteropPInvokeCallback(IntPtr localUserHandle, Interop.PFGameSaveFilesSyncState syncState, int error, void* context)
            {
                if (Callback == null) return;

                IssueEventCallback(new PFLocalUser(new(localUserHandle)), (PFGameSaveFilesSyncState)syncState, error);
            }

            private unsafe void IssueEventCallback(PFLocalUser localUser, PFGameSaveFilesSyncState syncState, int error)
            {
                TryGetCallback(out PFGameSaveFilesUiSyncFailedCallback callback, out object context);
                callback.Invoke(localUser, syncState, error, context);
            }
        }

        private class PFGameSaveFilesUiActiveDeviceContentionCallbackManager :
            InteropCallbackManager<PFGameSaveFilesUiActiveDeviceContentionCallback>
        {
            private static Interop.PFGameSaveFilesUiActiveDeviceContentionCallback _interopCallback;

            internal unsafe Interop.PFGameSaveFilesUiActiveDeviceContentionCallback GetInteropCallback()
            {
                if (_interopCallback == null)
                {
                    _interopCallback = new Interop.PFGameSaveFilesUiActiveDeviceContentionCallback(InteropPInvokeCallback);
                }
                return _interopCallback;
            }

            internal unsafe void InteropPInvokeCallback(IntPtr localUserHandle, Interop.PFGameSaveDescriptor* localGameSave, Interop.PFGameSaveDescriptor* remoteGameSave, void* context)
            {
                if (Callback == null) return;

                var localGameSaveWrapper = new PFGameSaveDescriptor(*localGameSave);
                var remoteGameSaveWrapper = new PFGameSaveDescriptor(*remoteGameSave);

                IssueEventCallback(new PFLocalUser(new(localUserHandle)), localGameSaveWrapper, remoteGameSaveWrapper);
            }

            private unsafe void IssueEventCallback(PFLocalUser localUser, PFGameSaveDescriptor localGameSave, PFGameSaveDescriptor remoteGameSave)
            {
                TryGetCallback(out PFGameSaveFilesUiActiveDeviceContentionCallback callback, out object context);
                callback.Invoke(localUser, localGameSave, remoteGameSave, context);
            }
        }

        private class PFGameSaveFilesUiConflictCallbackManager :
            InteropCallbackManager<PFGameSaveFilesUiConflictCallback>
        {
            private static Interop.PFGameSaveFilesUiConflictCallback _interopCallback;

            internal unsafe Interop.PFGameSaveFilesUiConflictCallback GetInteropCallback()
            {
                if (_interopCallback == null)
                {
                    _interopCallback = new Interop.PFGameSaveFilesUiConflictCallback(InteropPInvokeCallback);
                }
                return _interopCallback;
            }

            internal unsafe void InteropPInvokeCallback(IntPtr localUserHandle, Interop.PFGameSaveDescriptor* localGameSave, Interop.PFGameSaveDescriptor* remoteGameSave, void* context)
            {
                if (Callback == null) return;

                var localGameSaveWrapper = new PFGameSaveDescriptor(*localGameSave);
                var remoteGameSaveWrapper = new PFGameSaveDescriptor(*remoteGameSave);

                IssueEventCallback(new PFLocalUser(new(localUserHandle)), localGameSaveWrapper, remoteGameSaveWrapper);
            }

            private unsafe void IssueEventCallback(PFLocalUser localUser, PFGameSaveDescriptor localGameSave, PFGameSaveDescriptor remoteGameSave)
            {
                TryGetCallback(out PFGameSaveFilesUiConflictCallback callback, out object context);
                callback.Invoke(localUser, localGameSave, remoteGameSave, context);
            }
        }

        private class PFGameSaveFilesUiOutOfStorageCallbackManager :
            InteropCallbackManager<PFGameSaveFilesUiOutOfStorageCallback>
        {
            private static Interop.PFGameSaveFilesUiOutOfStorageCallback _interopCallback;

            internal unsafe Interop.PFGameSaveFilesUiOutOfStorageCallback GetInteropCallback()
            {
                if (_interopCallback == null)
                {
                    _interopCallback = new Interop.PFGameSaveFilesUiOutOfStorageCallback(InteropPInvokeCallback);
                }
                return _interopCallback;
            }

            internal unsafe void InteropPInvokeCallback(IntPtr localUserHandle, ulong requiredBytes, void* context)
            {
                if (Callback == null) return;

                IssueEventCallback(new PFLocalUser(new(localUserHandle)), requiredBytes);
            }

            private unsafe void IssueEventCallback(PFLocalUser localUser, ulong requiredBytes)
            {
                TryGetCallback(out PFGameSaveFilesUiOutOfStorageCallback callback, out object context);
                callback.Invoke(localUser, requiredBytes, context);
            }
        }
    }
}
