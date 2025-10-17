// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab
{
    /// <summary>
    /// Wrapper for <see cref="Interop.Core.HRESULT"/>
    /// </summary>
    public partial class HRESULT
    {
        // Client-side errors. Typically these errors indicate improper calling patterns.
        public const int E_PF_SERVICES_NOT_INITIALIZED     = unchecked((int)0x89235A00L);
        
        public const int E_PF_SERVICES_ALREADY_INITIALIZED = unchecked((int)0x89235A01L);
    }
}
