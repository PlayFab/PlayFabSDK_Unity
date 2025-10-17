// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PlayFab.InteropWrapper.Core
{
    public static class PFServiceConfig
    {
        public static int PFServiceConfigCreateHandle(string apiEndpoint, string playFabTitleId, out PFServiceConfigHandle serviceConfigHandle)
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                sbyte* apiEndpointInterop;
                sbyte* playFabTitleIdInterop;
                WrapperHelpers.StringToInterop(apiEndpoint, &apiEndpointInterop, disposableBuffer);
                WrapperHelpers.StringToInterop(playFabTitleId, &playFabTitleIdInterop, disposableBuffer);

                IntPtr serviceConfigHandleInterop;
                int hr = Interop.Methods.PFServiceConfigCreateHandle(apiEndpointInterop, playFabTitleIdInterop, &serviceConfigHandleInterop);
                serviceConfigHandle = new(serviceConfigHandleInterop);

                return hr;
            }
        }

        public static int PFServiceConfigDuplicateHandle(PFServiceConfigHandle handle, out PFServiceConfigHandle duplicatedHandle)
        {
            unsafe
            {
                IntPtr duplicatedHandleInterop;
                int hr = Interop.Methods.PFServiceConfigDuplicateHandle(handle.Handle, &duplicatedHandleInterop);
                duplicatedHandle = new(duplicatedHandleInterop);
                
                return hr;
            }
        }

        public static void PFServiceConfigCloseHandle(PFServiceConfigHandle handle)
        {
            Interop.Methods.PFServiceConfigCloseHandle(handle.Handle);
        }

        public static int PFServiceConfigGetAPIEndpoint(PFServiceConfigHandle handle, out string apiEndpoint)
        {
            apiEndpoint = null;

            unsafe
            {
                ulong apiEndpointSize;
                int hr = Interop.Methods.PFServiceConfigGetAPIEndpointSize(handle.Handle, &apiEndpointSize);

                if (HRESULT.Failed(hr)) return hr;

                using DisposableBuffer disposableBuffer = new();
                sbyte* apiEndpointInterop;
                WrapperHelpers.StringToInterop(apiEndpoint, &apiEndpointInterop, disposableBuffer);

                hr = Interop.Methods.PFServiceConfigGetAPIEndpoint(handle.Handle, apiEndpointSize, apiEndpointInterop, null);
                apiEndpoint = new(apiEndpointInterop);

                return hr;
            }
        }

        public static int PFServiceConfigGetTitleId(PFServiceConfigHandle handle, out string titleId)
        {
            titleId = null;

            unsafe
            {
                ulong titleIdSize;
                int hr = Interop.Methods.PFServiceConfigGetTitleIdSize(handle.Handle, &titleIdSize);

                if (HRESULT.Failed(hr)) return hr;

                using DisposableBuffer disposableBuffer = new();
                sbyte* titleIdInterop;
                WrapperHelpers.StringToInterop(titleId, &titleIdInterop, disposableBuffer);

                hr = Interop.Methods.PFServiceConfigGetTitleId(handle.Handle, titleIdSize, titleIdInterop, null);
                titleId = new(titleIdInterop);

                return hr;
            }
        }
    }
}
