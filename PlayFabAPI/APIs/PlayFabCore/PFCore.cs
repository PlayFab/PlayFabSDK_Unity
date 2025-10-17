// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public static partial class PFCore
    {
        /// <summary>
        /// Initialize PlayFabCore global state. Custom platform hooks must be configured prior to calling PFInitialize.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult Initialize()
        {
            return InteropWrapper.Core.PFCore.PFInitialize();
        }

        /// <summary>
        /// Cleanup PlayFab global state.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>Asynchronous result returned via XAsyncGetStatus.</remarks>
        public static Task<PFResult> UninitializeAsync()
        {
            return InteropWrapper.Core.PFCore.PFUninitializeAsync();
        }
    }
}
