using System;

namespace PlayFab.Interop
{
    /// <summary>
    /// Used to wrap the JavaVM and ApplicationContext on Android devices.
    /// </summary>
    public unsafe partial struct HCInitArgs
    {
        /// <summary>
        /// The Java Virtual machine.
        /// </summary>
        [NativeTypeName("JavaVM*")]
        public IntPtr javaVM;

        /// <summary>
        /// The Java Application Context.
        /// </summary>
        [NativeTypeName("jobject")]
        public IntPtr applicationContext;
    }
}