using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PlayFab.InteropWrapper
{
    internal class DisposableBuffer : IDisposable
    {
        internal List<IntPtr> Buffers { get; } = new List<IntPtr>();

        internal DisposableBuffer()
        {
            GC.SuppressFinalize(this);
        }

        internal IntPtr AddBuffer(int size)
        {
            IntPtr buffer = Marshal.AllocHGlobal(size);

            // Zero out memory
            byte[] zeroMem = new byte[size];
            Marshal.Copy(zeroMem, 0, buffer, size);

            Buffers.Add(buffer);

            return buffer;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (Buffers.Count != 0)
            {
                foreach (IntPtr buffer in Buffers)
                {
                    Marshal.FreeHGlobal(buffer);
                }

                Buffers.Clear();
            }
        }

        ~DisposableBuffer()
        {
            Dispose(false);
        }
    }
}
