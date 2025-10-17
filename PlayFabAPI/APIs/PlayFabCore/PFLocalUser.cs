// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFServiceConfig
    {
        /// <summary>
        /// Creates a PlayFab Local User to be used when a PlayFab identity is needed but PlayFab login is unavailable (ex. the device is offline).
        /// It is the title's responsibility to ensure the localId provided is:
        /// 1) Locally Unique. If multiple users play the title on the same device (simultaneously or during different play sessions) they must
        ///    have different localIds.
        /// 2) The same for a given user across multiple play sessions.
        /// Additionally, the title must provide a custom PFLocalUserLoginHandler. This handler will be called by the SDK to authenticate the user
        /// with PlayFab. See <see cref="PFLocalUserLoginHandler"> for more details.
        /// </summary>
        /// <param name="persistedLocalId">Locally unique ID string that identifies the user. ID will be persisted across play sessions.</param>
        /// <param name="loginHandle">Custom handler that will be called to log the local user into PlayFab.</param>
        /// <param name="customContext">Custom context to be associated with the local user.</param>
        /// <returns>Result code for this API operation containing a PFLocalUser if successful.  Possible values are S_OK, E_PF_NOT_INITIALIZED, or E_INVALIDARG.</returns>
        public PFResult<PFLocalUser> LocalUserCreateHandleWithPersistedLocalId(string persistedLocalId, PFLocalUserLoginHandler loginHandler, object customContext)
        {
            var result = InteropWrapper.Core.PFLocalUser.PFLocalUserCreateHandleWithPersistedLocalId(InteropHandle, persistedLocalId, loginHandler, customContext);
            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }
    }

    internal class PFLocalUserSafeHandle : SafeHandle
    {
        public override bool IsInvalid => handle == IntPtr.Zero;

        public PFLocalUserSafeHandle(PFLocalUserHandle entityHandle) : base(IntPtr.Zero, true)
        {
            SetHandle(entityHandle.Handle);
        }

        protected override bool ReleaseHandle()
        {
            InteropWrapper.Core.PFLocalUser.PFLocalUserCloseHandle(new(handle));
            return true;
        }
    }

    public partial class PFLocalUser : IDisposable
    {
        internal PFLocalUserSafeHandle LocalUserHandle { get; set; }

        internal PFLocalUserHandle InteropHandle { get; }

        /// <summary>
        /// Gets the PFPlayerEntity associated with the local user if there is one. If the user isn't logged into PlayFab, this is null.
        /// </summary>
        public PFPlayerEntity PlayerEntity { get; private set; }

        public PFLocalUser(PFLocalUserHandle handle)
        {
            LocalUserHandle = new(handle);
            InteropHandle = handle;
            PlayerEntity = null;
        }

        ~PFLocalUser()
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
                LocalUserHandle?.Dispose();
                LocalUserHandle = null;
            }
        }

        /// <summary>
        /// Duplicates a PFLocalUser.
        /// </summary>
        /// <returns>Result code for this API operation with the duplicated PFLocalUser if successful.</returns> 
        /// <remarks>
        /// Both the duplicated local user and the original local user need to be disposed when they
        /// are no longer needed.
        /// </remarks>
        public PFResult<PFLocalUser> Duplicate()
        {
            var result = InteropWrapper.Core.PFLocalUser.PFLocalUserDuplicateHandle(InteropHandle);
            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }

        /// <summary>
        /// Compares two PFLocalUserHandle objects.
        /// </summary>
        /// <param name="other">Second user to compare.</param>
        /// <returns>Returns 0 if the handles are equal, a negative number if this user is less than other, and a positive number if this user is greater than other.</returns>
        public int CompareTo(PFLocalUser other)
        {
            if (other == null) return 1;
            return InteropWrapper.Core.PFLocalUser.PFLocalUserHandleCompare(InteropHandle, other.InteropHandle);
        }

        /// <summary>
        /// Gets the PFServiceConfig associated with the local user.
        /// </summary>
        /// <returns>Result code for this API operation containing a PFServiceConfig if successful.</returns>
        public PFResult<PFServiceConfig> GetServiceConfig()
        {
            var result = InteropWrapper.Core.PFLocalUser.PFLocalUserGetServiceConfigHandle(InteropHandle);
            return result.Failed() ? new(result.HResult)
                                   : new(new PFServiceConfig(result.Result), result.HResult);
        }

        /// <summary>
        /// Get the localId for a user.
        /// </summary>
        /// <returns>Result code for this API operation containing the local id if successful.</returns>
        public PFResult<string> GetLocalId()
        {
            var result = InteropWrapper.Core.PFLocalUser.PFLocalUserGetLocalId(InteropHandle);
            return result.Failed() ? new(result.HResult)
                                   : new(result.Result, result.HResult);
        }

        /// <summary>
        /// Get the custom context that was associated with a local user when it was created.
        /// </summary>
        /// <returns>Result code for this API operation with the custom context if successful.</returns>
        public PFResult<object> GetCustomContext()
        {
            var result = InteropWrapper.Core.PFLocalUser.PFLocalUserGetCustomContext(InteropHandle);
            return result.Failed() ? new(result.HResult)
                                   : new(result.Result, result.HResult);
        }

        /// <summary>
        /// Get the PFPlayerEntity associated with the local user if there is one. If the user isn't logged into PlayFab and there isn't an
        /// associated handle, E_PF_CORE_LOCAL_USER_NOT_LOGGED_IN will be returned.
        /// </summary>
        /// <returns>Result code for this API operation with the PFPlayerEntity if successful.</returns>
        /// <remarks>
        /// If the call succeeds, the populated PFPlayerEntity is owned by the title. After calling this API, it is the title's responsibility
        /// to dispose it when it is no longer needed.
        public PFResult<PFPlayerEntity> TryGetEntity()
        {
            if (PlayerEntity != null)
            {
                return new(PlayerEntity, HRESULT.S_OK);
            }

            var result = InteropWrapper.Core.PFLocalUser.PFLocalUserTryGetEntityHandle(InteropHandle);
            if (result.Failed())
            {
                return new(result.HResult);
            }

            PlayerEntity = new PFPlayerEntity(result.Result, null);
            return new(PlayerEntity, HRESULT.S_OK);
        }

        /// <summary>
        /// Attempts to login the local user with the default PlayFab login provider, or the custom login handler provided when the local
        /// user was created.
        /// </summary>
        /// <param name="createAccount">Whether or not to automatically create a PlayFab account if one doesn't yet exist for the user.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// The resulting PFPlayerEntity will automatically be associated with the local user who is logging in.
        /// </remarks>
        public async Task<PFResult> LoginAsync(bool createAccount)
        {
            var loginResult = await InteropWrapper.Core.PFLocalUser.PFLocalUserLoginAsync(InteropHandle, createAccount);
            if (loginResult.Failed())
            {
                return new(loginResult.HResult);
            }

            PlayerEntity = new PFPlayerEntity(loginResult.Result.entity, loginResult.Result.loginResult);
            return new(HRESULT.S_OK);
        }
    }
}
