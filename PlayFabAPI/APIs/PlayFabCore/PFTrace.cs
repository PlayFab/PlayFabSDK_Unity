// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PlayFab
{
    public static partial class PFCore
    {
        public static PFResult TraceEnableTraceToFile(string traceFileDirectory)
        {
            var result = InteropWrapper.Core.PFTrace.PFTraceEnableTraceToFile(traceFileDirectory);
            return new(result);
        }
    }
}
