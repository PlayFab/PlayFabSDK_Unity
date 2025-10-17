namespace PlayFab.Interop
{
    public unsafe partial struct PFExperimentationGetTreatmentAssignmentResult
    {
        [NativeTypeName("const PFTreatmentAssignment *")]
        public PFTreatmentAssignment* treatmentAssignment;
    }
}
