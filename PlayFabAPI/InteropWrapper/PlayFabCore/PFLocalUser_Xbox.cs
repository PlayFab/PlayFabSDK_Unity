// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFLocalUser
    {
        public static PFResult<PFLocalUserHandle> PFLocalUserCreateHandleWithXboxUser(PFServiceConfigHandle serviceConfigHandle, IntPtr userHandle, object customContext)
        {
            unsafe
            {
                IntPtr* localUserHandleInterop = stackalloc IntPtr[1];
                int hr = Interop.Methods.PFLocalUserCreateHandleWithXboxUser(serviceConfigHandle.Handle, userHandle, null, localUserHandleInterop);

                if (HRESULT.Succeeded(hr))
                {
                    PFLocalUserHandle localUserHandle = new(*localUserHandleInterop);
                    MapLocalUserToCallbackIdAndCustomContext(localUserHandle, customContext);

                    return new(localUserHandle, hr);
                }

                return new(hr);
            }
        }

        public static PFResult<IntPtr> PFLocalUserTryGetXUser(PFLocalUserHandle localUserHandle)
        {
            unsafe
            {
                IntPtr* userHandleInterop = stackalloc IntPtr[1];
                int hr = Interop.Methods.PFLocalUserTryGetXUser(localUserHandle.Handle, userHandleInterop);

                if (HRESULT.Succeeded(hr))
                {
                    return new(*userHandleInterop, hr);
                }

                return new(hr);
            }
        }
    }
}
