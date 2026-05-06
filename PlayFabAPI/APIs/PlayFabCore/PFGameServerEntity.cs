// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab
{
    public partial class PFGameServerEntity : PFEntity
    {
        public PFGameServerEntity(PFEntityHandle handle) : base(handle)
        {
        }

        public PFResult<PFGameServerEntity> Duplicate()
        {
            var result = InteropWrapper.Core.PFEntity.PFEntityDuplicateHandle(InteropHandle);
            if (result.Failed()) return new PFResult<PFGameServerEntity>(result.HResult);
            return new PFResult<PFGameServerEntity>(new PFGameServerEntity(result.Result), result.HResult);
        }
    }
}
