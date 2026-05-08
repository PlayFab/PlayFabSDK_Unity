// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
        /// <summary>
        /// Gets the treatment assignments for a player for every running experiment in the title.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFExperimentationGetTreatmentAssignmentResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFExperimentationGetTreatmentAssignmentGetResultSize"/>
        /// and <see cref="PFExperimentationGetTreatmentAssignmentGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFExperimentationGetTreatmentAssignmentResult>> ExperimentationGetTreatmentAssignmentAsync(
            PFExperimentationGetTreatmentAssignmentRequest request
        )
        {
            return InteropWrapper.Services.PFExperimentation.PFExperimentationGetTreatmentAssignmentAsync(InteropHandle, request);
        }
    }
}
