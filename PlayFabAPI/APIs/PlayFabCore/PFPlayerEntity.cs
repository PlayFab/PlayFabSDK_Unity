// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab
{
    public partial class PFPlayerEntity : PFEntity
    {
        public PFAuthenticationLoginResult? LoginResult { get; private set; }

        public PFPlayerEntity(PFEntityHandle handle, PFAuthenticationLoginResult? loginResult) : base(handle)
        {
            LoginResult = loginResult;
        }

        public PFResult<PFPlayerEntity> Duplicate()
        {
            var result = InteropWrapper.Core.PFEntity.PFEntityDuplicateHandle(InteropHandle);
            if (result.Failed()) return new PFResult<PFPlayerEntity>(result.HResult);
            var duplicated = new PFPlayerEntity(result.Result, LoginResult);
            return new PFResult<PFPlayerEntity>(duplicated, result.HResult);
        }
    }
}
