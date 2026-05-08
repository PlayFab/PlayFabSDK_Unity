// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT

namespace PlayFab
{
    /// <summary>
    /// Manages the XGameRuntime lifecycle for the PlayFab SDK on Windows/GDK.
    /// 
    /// XGameRuntime provides the process-level task queue infrastructure that
    /// the PlayFab native SDK depends on. It must be initialized before any
    /// PlayFab API call and uninitialised after all PlayFab cleanup completes.
    /// 
    /// Typical usage:
    /// <code>
    /// // At startup
    /// PlayFab.XGameRuntime.Initialize();
    /// PFServices.Initialize();
    /// 
    /// // ... use PlayFab APIs ...
    /// 
    /// // At shutdown
    /// await PFServices.UninitializeAsync();
    /// PlayFab.XGameRuntime.Uninitialize();
    /// </code>
    /// 
    /// This matches the native PlayFab C SDK pattern, where the caller (game)
    /// owns the XGameRuntime lifecycle independently from PlayFab init/uninit.
    /// </summary>
    public static class XGameRuntime
    {
        /// <summary>
        /// Initializes XGameRuntime. Call before any PlayFab API.
        /// Safe to call multiple times (ref-counted by the OS).
        /// </summary>
        /// <returns>S_OK (0) on success, or an HRESULT error code.</returns>
        public static int Initialize()
        {
            try
            {
                return Interop.Methods.XGameRuntimeInitialize();
            }
            catch (System.DllNotFoundException)
            {
                return unchecked((int)0x80070002); // ERROR_FILE_NOT_FOUND
            }
            catch (System.EntryPointNotFoundException)
            {
                return unchecked((int)0x80070002);
            }
        }

        /// <summary>
        /// Uninitializes XGameRuntime. Call after all PlayFab cleanup completes.
        /// Must be paired with a corresponding Initialize call.
        /// </summary>
        public static void Uninitialize()
        {
            Interop.Methods.XGameRuntimeUninitialize();
        }
    }
}

#endif
