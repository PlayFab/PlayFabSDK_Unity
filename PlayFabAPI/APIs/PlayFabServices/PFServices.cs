using System.Threading.Tasks;

namespace PlayFab
{
    public static class PFServices
    {
        public static PFResult Initialize()
        {   
            return InteropWrapper.Services.PFServices.PFServicesInitialize();
        }

        public static async Task<PFResult> UninitializeAsync()
        {
            return await InteropWrapper.Services.PFServices.PFServicesUninitializeAsync();
        }
    }
}
