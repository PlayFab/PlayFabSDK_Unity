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
            return Duplicate<PFTitleEntity>();
        }
    }
}
