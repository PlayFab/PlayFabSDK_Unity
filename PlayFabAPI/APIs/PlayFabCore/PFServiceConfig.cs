// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;

namespace PlayFab
{
    public partial class PFCore
    {
        /// <summary>
        /// Creates a PlayFab service configuration.
        /// </summary>
        /// <param name="apiEndpoint">String used to connect to a PlayFab Service instance.</param>
        /// <param name="playFabTitleId">PlayFab TitleId for the title. Found in the Game Manager for your title on the PlayFab Website.</param>
        /// <returns>Result for this API operation containing a PFServiceConfig if succeeded.  Possible values are S_OK, E_PF_NOT_INITIALIZED, or E_INVALIDARG.</returns>
        public static PFResult<PFServiceConfig> CreateServiceConfig(string apiEndpoint, string playFabTitleId)
        {
            int result = InteropWrapper.Core.PFServiceConfig.PFServiceConfigCreateHandle(apiEndpoint, playFabTitleId, out PFServiceConfigHandle serviceConfigHandle);
            return HRESULT.Failed(result) ? new(result)
                                          : new(new(serviceConfigHandle), result);
        }
    }

    internal class PFServiceConfigSafeHandle : SafeHandle
    {
        public override bool IsInvalid => handle == IntPtr.Zero;

        public PFServiceConfigSafeHandle(PFServiceConfigHandle serviceConfigHandle) : base(IntPtr.Zero, true)
        {
            SetHandle(serviceConfigHandle.Handle);
        }

        protected override bool ReleaseHandle()
        {
            InteropWrapper.Core.PFServiceConfig.PFServiceConfigCloseHandle(new(handle));
            return true;
        }
    }

    public partial class PFServiceConfig : IDisposable
    {
        private PFServiceConfigSafeHandle ServiceConfigHandle { get; set; }

        internal PFServiceConfigHandle InteropHandle { get; }

        public PFServiceConfig(PFServiceConfigHandle handle)
        {
            ServiceConfigHandle = new(handle);
            InteropHandle = handle;
        }

        ~PFServiceConfig()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServiceConfigHandle?.Dispose();
                ServiceConfigHandle = null;
            }
        }

        public PFResult<PFServiceConfig> Duplicate()
        {
            int result = InteropWrapper.Core.PFServiceConfig.PFServiceConfigDuplicateHandle(InteropHandle, out PFServiceConfigHandle duplicatedHandle);
            return HRESULT.Failed(result) ? new PFResult<PFServiceConfig>(result)
                                          : new PFResult<PFServiceConfig>(new PFServiceConfig(duplicatedHandle), result);
        }

        /// <summary>
        /// Gets the API endpoint for a service configuration.
        /// </summary>
        /// <returns>Result for this API operation containing the API endpoint if successful.</returns>
        public PFResult<string> GetAPIEndpoint()
        {
            int result = InteropWrapper.Core.PFServiceConfig.PFServiceConfigGetAPIEndpoint(InteropHandle, out string apiEndpoint);
            return HRESULT.Failed(result) ? new(result)
                                          : new(apiEndpoint, result);
        }

        /// <summary>
        /// Gets the PlayFab titleId for a service configuration.
        /// </summary>
        /// <returns>Result for this API operation containing the titleId if successful.</returns>
        public PFResult<string> GetTitleId()
        {
            int result = InteropWrapper.Core.PFServiceConfig.PFServiceConfigGetTitleId(InteropHandle, out string playFabTitleId);
            return HRESULT.Failed(result) ? new(result)
                                          : new(playFabTitleId, result);
        }
    }
}
