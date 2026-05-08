// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PlayFab
{
    internal class PFEntitySafeHandle : SafeHandle
    {
        public override bool IsInvalid => handle == IntPtr.Zero;

        public PFEntitySafeHandle(PFEntityHandle entityHandle) : base(IntPtr.Zero, true)
        {
            SetHandle(entityHandle.Handle);
        }

        protected override bool ReleaseHandle()
        {
            InteropWrapper.Core.PFEntity.PFEntityCloseHandle(new(handle));
            return true;
        }
    }

    public partial class PFEntity : IDisposable
    {
        internal PFEntitySafeHandle EntityHandle { get; set; }

        internal PFEntityHandle InteropHandle { get; }

        public PFEntity(PFEntityHandle handle)
        {
            EntityHandle = new(handle);
            InteropHandle = handle;
        }

        ~PFEntity()
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
                EntityHandle?.Dispose();
                EntityHandle = null;
            }
        }

        public Task<PFResult<PFEntityToken>> GetEntityTokenAsync()
        {
            return InteropWrapper.Core.PFEntity.PFEntityGetEntityTokenAsync(InteropHandle);
        }

        public PFResult<string> GetSecretKey()
        {
            return InteropWrapper.Core.PFEntity.PFEntityGetSecretKey(InteropHandle);
        }

        public PFResult<PFEntityKey> GetEntityKey()
        {
            return InteropWrapper.Core.PFEntity.PFEntityGetEntityKey(InteropHandle);
        }

        public PFResult<bool> IsTitlePlayer()
        {
            return InteropWrapper.Core.PFEntity.PFEntityIsTitlePlayer(InteropHandle);
        }

        public PFResult<string> GetAPIEndpoint()
        {
            return InteropWrapper.Core.PFEntity.PFEntityGetAPIEndpoint(InteropHandle);
        }

        public PFResult<string> GetTitleId()
        {
            return InteropWrapper.Core.PFEntity.PFEntityGetTitleId(InteropHandle);
        }

        public PFResult<PFCallbackToken> RegisterTokenExpiredEventHandler(PFEntityTokenExpiredEventHandler handler, object context)
        {
            return InteropWrapper.Core.PFEntity.PFEntityRegisterTokenExpiredEventHandler(handler, context);
        }

        public void UnregisterTokenExpiredEventHandler(PFCallbackToken token)
        {
            InteropWrapper.Core.PFEntity.PFEntityUnregisterTokenExpiredEventHandler(token);
        }

        public PFResult<PFCallbackToken> RegisterTokenRefreshedEventHandler(PFEntityTokenRefreshedEventHandler handler, object context)
        {
            return InteropWrapper.Core.PFEntity.PFEntityRegisterTokenRefreshedEventHandler(handler, context);
        }

        public void UnregisterTokenRefreshedEventHandler(PFCallbackToken token)
        {
            InteropWrapper.Core.PFEntity.PFEntityUnregisterTokenRefreshedEventHandler(token);
        }
    }
}
