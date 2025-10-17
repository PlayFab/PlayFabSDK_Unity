// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PlayFab
{

    /// <summary>
    /// Handle to a PlayFab service configuration. When no longer needed, the handle must be closed with PFServiceConfigCloseHandle.
    /// </summary>
    public readonly struct PFServiceConfigHandle
    {
        public readonly IntPtr Handle;

        public PFServiceConfigHandle(IntPtr handle)
        {
            Handle = handle;
        }
    }

}
