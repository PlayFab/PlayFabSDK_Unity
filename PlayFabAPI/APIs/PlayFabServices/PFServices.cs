using System.Threading.Tasks;

namespace PlayFab
{
    public static class PFServices
    {
        /// <summary>
        /// Initializes PlayFab Services global state.
        /// </summary>
        /// <remarks>
        /// On Windows/GDK, XGameRuntime must be initialized before calling this method.
        /// See <see cref="PlayFab.XGameRuntime.Initialize"/>.
        /// This will internally call PFInitialize() if it hasn't been called already.
        /// </remarks>
        public static PFResult Initialize()
        {   
            return InteropWrapper.Services.PFServices.PFServicesInitialize();
        }

        /// <summary>
        /// Cleanup PlayFab Services global state.
        /// </summary>
        /// <remarks>
        /// <b>Handle invalidation:</b> Completing this call destroys the global handle tables.
        /// All outstanding <see cref="PFServiceConfig"/>, <see cref="PFEntity"/> (and subclasses
        /// such as <see cref="PFPlayerEntity"/> and <see cref="PFTitleEntity"/>),
        /// <see cref="PFLocalUser"/>, and <see cref="PlayFab.PFGameSaveProvider"/> instances
        /// become invalid. Using any of them after uninit returns
        /// <c>E_PF_INVALIDHANDLE</c> (0x89235402). Callers must release references and
        /// re-create handles after the next <see cref="Initialize"/>.
        /// </remarks>
        public static Task<PFResult> UninitializeAsync()
        {
            return InteropWrapper.Services.PFServices.PFServicesUninitializeAsync();
        }
    }
}
