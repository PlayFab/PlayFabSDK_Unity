// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PlayFab
{
    /// <summary>
    /// Defines the compression level that will be used on the compression algorithm.
    /// Lower levels perform less compression but have the highest speed in the compression and
    /// higher levels perform better compression but have the slowest speed in the compression.
    /// </summary>
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
    };

    public class HCInitArgs
    {
        /// <summary>
        /// The Java Virtual Machine.
        /// </summary>
        public IntPtr JavaVM;

        /// <summary>
        /// The Java Application Context.
        /// </summary>
        public IntPtr ApplicationContext;

        internal unsafe HCInitArgs(Interop.HCInitArgs interop)
        {
            JavaVM = interop.javaVM;
            ApplicationContext = interop.applicationContext;
        }

        internal unsafe static void ToInterop(HCInitArgs self, Interop.HCInitArgs* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->javaVM = self.JavaVM;
            interop->applicationContext = self.ApplicationContext;
        }
    }
}
