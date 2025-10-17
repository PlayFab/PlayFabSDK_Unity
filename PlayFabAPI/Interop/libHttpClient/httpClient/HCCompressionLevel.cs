namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum HCCompressionLevel : uint
    {
        /// <summary>
        /// A value of "None" indicates that no compression will be made.
        /// </summary>
        None = 0,

        /// <summary>
        /// A value of "Low" indicates that compression level 1 will be made.
        /// </summary>
        Low = 1,

        /// <summary>
        /// A value of "Medium" indicates that compression level 6 will be made.
        /// </summary>
        Medium = 6,

        /// <summary>
        /// A value of "High" indicates that compression level 9 will be made.
        /// </summary>
        High = 9
    }
}
