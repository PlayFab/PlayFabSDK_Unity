// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFServiceConfig
    {
        public PFResult<PFLocalUser> LocalUserCreateHandleWithSteamUser(object customContext)
        {
            var result = InteropWrapper.Core.PFLocalUser.PFLocalUserCreateHandleWithSteamUser(InteropHandle, customContext);
            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }
    }
}
