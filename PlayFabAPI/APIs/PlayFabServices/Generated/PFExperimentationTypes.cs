// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFExperimentationGetTreatmentAssignmentRequest data model. Given a title player or a title entity
    /// token, returns the treatment variants and variables assigned to the entity across all running experiments.
    /// </summary>
    public struct PFExperimentationGetTreatmentAssignmentRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe static void ToInterop(PFExperimentationGetTreatmentAssignmentRequest self, Interop.PFExperimentationGetTreatmentAssignmentRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFExperimentationGetTreatmentAssignmentResult data model.
    /// </summary>
    public struct PFExperimentationGetTreatmentAssignmentResult
    {
        /// <summary>
        /// (Optional) Treatment assignment for the entity.
        /// </summary>
        public PFTreatmentAssignment? TreatmentAssignment;

        internal unsafe PFExperimentationGetTreatmentAssignmentResult(Interop.PFExperimentationGetTreatmentAssignmentResult interop)
        {

            TreatmentAssignment = (interop.treatmentAssignment == null) ? null : new(*interop.treatmentAssignment);

        }
            
    }

}
