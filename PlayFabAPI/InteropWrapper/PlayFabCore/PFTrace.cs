// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab.InteropWrapper.Core
{
    public static class PFTrace
    {
        public static int PFTraceEnableTraceToFile(string traceFileDirectory)
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                sbyte* traceFileDirectoryInterop;
                WrapperHelpers.StringToInterop(traceFileDirectory, &traceFileDirectoryInterop, disposableBuffer);

                return Interop.Methods.PFTraceEnableTraceToFile(traceFileDirectoryInterop);
            }
        }
    }
}
