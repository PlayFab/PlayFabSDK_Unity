// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFLocalUser
    {
        public static PFResult<PFLocalUserHandle> PFLocalUserCreateHandleWithSteamUser(PFServiceConfigHandle serviceConfigHandle, object customContext)
        {
            unsafe
            {
                IntPtr localUserHandleInterop;
                int hr = Interop.Methods.PFLocalUserCreateHandleWithSteamUser(serviceConfigHandle.Handle, null, &localUserHandleInterop);

                if (HRESULT.Succeeded(hr))
                {
                    PFLocalUserHandle localUserHandle = new(localUserHandleInterop);
                    MapLocalUserToCallbackIdAndCustomContext(localUserHandle, customContext);

                    return new(localUserHandle, hr);
                }

                return new(hr);
            }
        }
    }
}
