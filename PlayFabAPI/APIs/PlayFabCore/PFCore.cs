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
        /// <remarks>
        /// On Windows/GDK, XGameRuntime must be initialized before calling this method.
        /// See <see cref="PlayFab.XGameRuntime.Initialize"/>.
        /// </remarks>
        /// <returns>Result code for this API operation.</returns>
        public static PFResult Initialize()
        {
            return InteropWrapper.Core.PFCore.PFInitialize();
        }

        /// <summary>
        /// Cleanup PlayFab global state.
        /// </summary>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// Asynchronous result returned via XAsyncGetStatus.
        /// <b>Handle invalidation:</b> Completing this call destroys the global handle tables.
        /// All outstanding <see cref="PFServiceConfig"/>, <see cref="PFEntity"/> (and
        /// subclasses), and <see cref="PFLocalUser"/> instances become invalid. Using any of
        /// them after uninit returns <c>E_PF_INVALIDHANDLE</c> (0x89235402). Callers must
        /// release references and re-create handles after the next <see cref="Initialize"/>.
        /// </remarks>
        public static Task<PFResult> UninitializeAsync()
        {
            return InteropWrapper.Core.PFCore.PFUninitializeAsync();
        }
    }
}
