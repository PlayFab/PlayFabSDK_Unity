// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
#if MICROSOFT_GDK_SUPPORT
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFServiceConfig
    {
        public PFResult<PFLocalUser> LocalUserCreateHandleWithXboxUser(IntPtr userHandle, object customContext)
        {
            var result = InteropWrapper.Core.PFLocalUser.PFLocalUserCreateHandleWithXboxUser(InteropHandle, userHandle, customContext);
            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }
    }
}
#endif