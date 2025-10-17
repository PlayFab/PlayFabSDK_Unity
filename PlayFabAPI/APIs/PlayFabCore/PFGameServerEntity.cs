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
            return Duplicate<PFGameServerEntity>();
        }
    }
}
