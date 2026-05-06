// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab
{
    public partial class PFTitleEntity : PFEntity
    {
        public PFTitleEntity(PFEntityHandle handle) : base(handle)
        {
        }

        public PFResult<PFTitleEntity> Duplicate()
        {
            var result = InteropWrapper.Core.PFEntity.PFEntityDuplicateHandle(InteropHandle);
            if (result.Failed()) return new PFResult<PFTitleEntity>(result.HResult);
            return new PFResult<PFTitleEntity>(new PFTitleEntity(result.Result), result.HResult);
        }
    }
}
