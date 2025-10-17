// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFGroups
    {

        /// <summary>
        /// Accepts an outstanding invitation to to join a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Accepts an outstanding invitation to to join a group if the invited entity is not blocked by the
        /// group. Nothing is returned in the case of success. See also GroupApplyToGroupAsync, GroupListGroupApplicationsAsync,
        /// GroupRemoveGroupApplicationAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ENTITY_BLOCKED_BY_GROUP, E_PF_ENTITY_IS_ALREADY_MEMBER, E_PF_GROUP_APPLICATION_NOT_FOUND
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsAcceptGroupApplicationAsync(
            PFEntityHandle entityHandle,
            PFGroupsAcceptGroupApplicationRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsAcceptGroupApplicationRequest* requestInterop = stackalloc Interop.PFGroupsAcceptGroupApplicationRequest[1];
                PFGroupsAcceptGroupApplicationRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsAcceptGroupApplicationAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Accepts an invitation to join a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Accepts an outstanding invitation to join the group if the invited entity is not blocked by the group.
        /// Only the invited entity or a parent in its chain (e.g. title) may accept the invitation on the invited
        /// entity's behalf. Nothing is returned in the case of success. See also GroupInviteToGroupAsync, GroupListGroupInvitationsAsync,
        /// GroupListMembershipOpportunitiesAsync, GroupRemoveGroupInvitationAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ENTITY_BLOCKED_BY_GROUP, E_PF_ENTITY_IS_ALREADY_MEMBER, E_PF_GROUP_INVITATION_NOT_FOUND,
        /// E_PF_ROLE_DOES_NOT_EXIST or any of the global PlayFab Service errors. See doc page "Handling PlayFab
        /// Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsAcceptGroupInvitationAsync(
            PFEntityHandle entityHandle,
            PFGroupsAcceptGroupInvitationRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsAcceptGroupInvitationRequest* requestInterop = stackalloc Interop.PFGroupsAcceptGroupInvitationRequest[1];
                PFGroupsAcceptGroupInvitationRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsAcceptGroupInvitationAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Adds members to a group or role.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Adds members to a group or role. Existing members of the group will added to roles within the group,
        /// but if the user is not already a member of the group, only title claimants may add them to the group,
        /// and others must use the group application or invite system to add new members to a group. Returns
        /// nothing if successful. See also GroupApplyToGroupAsync, GroupInviteToGroupAsync, GroupListGroupMembersAsync,
        /// GroupRemoveMembersAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ROLE_DOES_NOT_EXIST or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsAddMembersAsync(
            PFEntityHandle entityHandle,
            PFGroupsAddMembersRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsAddMembersRequest* requestInterop = stackalloc Interop.PFGroupsAddMembersRequest[1];
                PFGroupsAddMembersRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsAddMembersAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Applies to join a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsApplyToGroupResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Creates an application to join a group. Calling this while a group application already exists will
        /// return the same application instead of an error and will not refresh the time before the application
        /// expires. By default, if the entity has an invitation to join the group outstanding, this will accept
        /// the invitation to join the group instead and return an error indicating such, rather than creating
        /// a duplicate application to join that will need to be cleaned up later. Returns information about the
        /// application or an error indicating an invitation was accepted instead. See also GroupAcceptGroupApplicationAsync,
        /// GroupListGroupApplicationsAsync, GroupRemoveGroupApplicationAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsApplyToGroupGetResultSize"/> and
        /// <see cref="PFGroupsApplyToGroupGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsApplyToGroupResponse>> PFGroupsApplyToGroupAsync(
            PFEntityHandle entityHandle,
            PFGroupsApplyToGroupRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsApplyToGroupResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsApplyToGroupGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsApplyToGroupResponse* result = null;

                    hr = Interop.Methods.PFGroupsApplyToGroupGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsApplyToGroupRequest* requestInterop = stackalloc Interop.PFGroupsApplyToGroupRequest[1];
                PFGroupsApplyToGroupRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsApplyToGroupAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Blocks a list of entities from joining a group.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Blocks a list of entities from joining a group. Blocked entities may not create new applications
        /// to join, be invited to join, accept an invitation, or have an application accepted. Failure due to
        /// being blocked does not clean up existing applications or invitations to the group. No data is returned
        /// in the case of success. See also GroupListGroupBlocksAsync, GroupUnblockEntityAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsBlockEntityAsync(
            PFEntityHandle entityHandle,
            PFGroupsBlockEntityRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsBlockEntityRequest* requestInterop = stackalloc Interop.PFGroupsBlockEntityRequest[1];
                PFGroupsBlockEntityRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsBlockEntityAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Changes the role membership of a list of entities from one role to another.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Changes the role membership of a list of entities from one role to another in in a single operation.
        /// The destination role must already exist. This is equivalent to adding the entities to the destination
        /// role and removing from the origin role. Returns nothing if successful. See also GroupAddMembersAsync,
        /// GroupCreateRoleAsync, GroupRemoveMembersAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ROLE_DOES_NOT_EXIST or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsChangeMemberRoleAsync(
            PFEntityHandle entityHandle,
            PFGroupsChangeMemberRoleRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsChangeMemberRoleRequest* requestInterop = stackalloc Interop.PFGroupsChangeMemberRoleRequest[1];
                PFGroupsChangeMemberRoleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsChangeMemberRoleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Creates a new group.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsCreateGroupResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Creates a new group, as well as administration and member roles, based off of a title's group template.
        /// Returns information about the group that was created. See also GroupAddMembersAsync, GroupApplyToGroupAsync,
        /// GroupDeleteGroupAsync, GroupInviteToGroupAsync, GroupListGroupMembersAsync, GroupRemoveMembersAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsCreateGroupGetResultSize"/> and <see
        /// cref="PFGroupsCreateGroupGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsCreateGroupResponse>> PFGroupsCreateGroupAsync(
            PFEntityHandle entityHandle,
            PFGroupsCreateGroupRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsCreateGroupResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsCreateGroupGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsCreateGroupResponse* result = null;

                    hr = Interop.Methods.PFGroupsCreateGroupGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsCreateGroupRequest* requestInterop = stackalloc Interop.PFGroupsCreateGroupRequest[1];
                PFGroupsCreateGroupRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsCreateGroupAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Creates a new group role.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsCreateGroupRoleResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Creates a new role within an existing group, with no members. Both the role ID and role name must
        /// be unique within the group, but the name can be the same as the ID. The role ID is set at creation
        /// and cannot be changed. Returns information about the role that was created. See also GroupDeleteRoleAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsCreateRoleGetResultSize"/> and <see
        /// cref="PFGroupsCreateRoleGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsCreateGroupRoleResponse>> PFGroupsCreateRoleAsync(
            PFEntityHandle entityHandle,
            PFGroupsCreateGroupRoleRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsCreateGroupRoleResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsCreateRoleGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsCreateGroupRoleResponse* result = null;

                    hr = Interop.Methods.PFGroupsCreateRoleGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsCreateGroupRoleRequest* requestInterop = stackalloc Interop.PFGroupsCreateGroupRoleRequest[1];
                PFGroupsCreateGroupRoleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsCreateRoleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Deletes a group and all roles, invitations, join requests, and blocks associated with it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Deletes a group and all roles, invitations, join requests, and blocks associated with it. Permission
        /// to delete is only required the group itself to execute this action. The group and data cannot be cannot
        /// be recovered once removed, but any abuse reports about the group will remain. No data is returned
        /// in the case of success. See also GroupCreateGroupAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsDeleteGroupAsync(
            PFEntityHandle entityHandle,
            PFGroupsDeleteGroupRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsDeleteGroupRequest* requestInterop = stackalloc Interop.PFGroupsDeleteGroupRequest[1];
                PFGroupsDeleteGroupRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsDeleteGroupAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Deletes an existing role in a group.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns information about the role See also GroupCreateRoleAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ROLE_DOES_NOT_EXIST, E_PF_ROLE_IS_GROUP_ADMIN, E_PF_ROLE_IS_GROUP_DEFAULT_MEMBER
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsDeleteRoleAsync(
            PFEntityHandle entityHandle,
            PFGroupsDeleteRoleRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsDeleteRoleRequest* requestInterop = stackalloc Interop.PFGroupsDeleteRoleRequest[1];
                PFGroupsDeleteRoleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsDeleteRoleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets information about a group and its roles
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsGetGroupResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns the ID, name, role list and other non-membership related information about a group. See also
        /// GroupUpdateGroupAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsGetGroupGetResultSize"/> and <see
        /// cref="PFGroupsGetGroupGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsGetGroupResponse>> PFGroupsGetGroupAsync(
            PFEntityHandle entityHandle,
            PFGroupsGetGroupRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsGetGroupResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsGetGroupGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsGetGroupResponse* result = null;

                    hr = Interop.Methods.PFGroupsGetGroupGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsGetGroupRequest* requestInterop = stackalloc Interop.PFGroupsGetGroupRequest[1];
                PFGroupsGetGroupRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsGetGroupAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Invites a player to join a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsInviteToGroupResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Invites a player to join a group, if they are not blocked by the group. An optional role can be provided
        /// to automatically assign the player to the role if they accept the invitation. By default, if the entity
        /// has an application to the group outstanding, this will accept the application instead and return an
        /// error indicating such, rather than creating a duplicate invitation to join that will need to be cleaned
        /// up later. Returns information about the new invitation or an error indicating an existing application
        /// to join was accepted. See also GroupAcceptGroupInvitationAsync, GroupListGroupInvitationsAsync, GroupListMembershipOpportunitiesAsync,
        /// GroupRemoveGroupInvitationAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsInviteToGroupGetResultSize"/> and
        /// <see cref="PFGroupsInviteToGroupGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsInviteToGroupResponse>> PFGroupsInviteToGroupAsync(
            PFEntityHandle entityHandle,
            PFGroupsInviteToGroupRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsInviteToGroupResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsInviteToGroupGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsInviteToGroupResponse* result = null;

                    hr = Interop.Methods.PFGroupsInviteToGroupGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsInviteToGroupRequest* requestInterop = stackalloc Interop.PFGroupsInviteToGroupRequest[1];
                PFGroupsInviteToGroupRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsInviteToGroupAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Checks to see if an entity is a member of a group or role within the group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsIsMemberResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Checks to see if an entity is a member of a group or role within the group. A result indicating if
        /// the entity is a member of the group is returned, or a permission error if the caller does not have
        /// permission to read the group's member list. See also GroupGetGroupAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsIsMemberGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsIsMemberResponse>> PFGroupsIsMemberAsync(
            PFEntityHandle entityHandle,
            PFGroupsIsMemberRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsIsMemberResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFGroupsIsMemberResponse result = default;

                    hr = Interop.Methods.PFGroupsIsMemberGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsIsMemberRequest* requestInterop = stackalloc Interop.PFGroupsIsMemberRequest[1];
                PFGroupsIsMemberRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsIsMemberAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists all outstanding requests to join a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsListGroupApplicationsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Lists all outstanding requests to join a group. Returns a list of all requests to join, as well as
        /// when the request will expire. To get the group applications for a specific entity, use ListMembershipOpportunities.
        /// See also GroupAcceptGroupApplicationAsync, GroupApplyToGroupAsync, GroupRemoveGroupApplicationAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsListGroupApplicationsGetResultSize"/>
        /// and <see cref="PFGroupsListGroupApplicationsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsListGroupApplicationsResponse>> PFGroupsListGroupApplicationsAsync(
            PFEntityHandle entityHandle,
            PFGroupsListGroupApplicationsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsListGroupApplicationsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsListGroupApplicationsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsListGroupApplicationsResponse* result = null;

                    hr = Interop.Methods.PFGroupsListGroupApplicationsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsListGroupApplicationsRequest* requestInterop = stackalloc Interop.PFGroupsListGroupApplicationsRequest[1];
                PFGroupsListGroupApplicationsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsListGroupApplicationsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists all entities blocked from joining a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsListGroupBlocksResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Lists all entities blocked from joining a group. A list of blocked entities is returned See also
        /// GroupBlockEntityAsync, GroupUnblockEntityAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsListGroupBlocksGetResultSize"/> and
        /// <see cref="PFGroupsListGroupBlocksGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsListGroupBlocksResponse>> PFGroupsListGroupBlocksAsync(
            PFEntityHandle entityHandle,
            PFGroupsListGroupBlocksRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsListGroupBlocksResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsListGroupBlocksGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsListGroupBlocksResponse* result = null;

                    hr = Interop.Methods.PFGroupsListGroupBlocksGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsListGroupBlocksRequest* requestInterop = stackalloc Interop.PFGroupsListGroupBlocksRequest[1];
                PFGroupsListGroupBlocksRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsListGroupBlocksAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists all outstanding invitations for a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsListGroupInvitationsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Lists all outstanding invitations for a group. Returns a list of entities that have been invited,
        /// as well as when the invitation will expire. To get the group invitations for a specific entity, use
        /// ListMembershipOpportunities. See also GroupAcceptGroupInvitationAsync, GroupInviteToGroupAsync, GroupListMembershipOpportunitiesAsync,
        /// GroupRemoveGroupInvitationAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsListGroupInvitationsGetResultSize"/>
        /// and <see cref="PFGroupsListGroupInvitationsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsListGroupInvitationsResponse>> PFGroupsListGroupInvitationsAsync(
            PFEntityHandle entityHandle,
            PFGroupsListGroupInvitationsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsListGroupInvitationsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsListGroupInvitationsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsListGroupInvitationsResponse* result = null;

                    hr = Interop.Methods.PFGroupsListGroupInvitationsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsListGroupInvitationsRequest* requestInterop = stackalloc Interop.PFGroupsListGroupInvitationsRequest[1];
                PFGroupsListGroupInvitationsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsListGroupInvitationsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists all members for a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsListGroupMembersResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Gets a list of members and the roles they belong to within the group. If the caller does not have
        /// permission to view the role, and the member is in no other role, the member is not displayed. Returns
        /// a list of entities that are members of the group. See also GroupListMembershipAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsListGroupMembersGetResultSize"/>
        /// and <see cref="PFGroupsListGroupMembersGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsListGroupMembersResponse>> PFGroupsListGroupMembersAsync(
            PFEntityHandle entityHandle,
            PFGroupsListGroupMembersRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsListGroupMembersResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsListGroupMembersGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsListGroupMembersResponse* result = null;

                    hr = Interop.Methods.PFGroupsListGroupMembersGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsListGroupMembersRequest* requestInterop = stackalloc Interop.PFGroupsListGroupMembersRequest[1];
                PFGroupsListGroupMembersRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsListGroupMembersAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists all groups and roles for an entity
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsListMembershipResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Lists the groups and roles that an entity is a part of, checking to see if group and role metadata
        /// and memberships should be visible to the caller. If the entity is not in any roles that are visible
        /// to the caller, the group is not returned in the results, even if the caller otherwise has permission
        /// to see that the entity is a member of that group. See also GroupListGroupMembersAsync, GroupListMembershipOpportunitiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsListMembershipGetResultSize"/> and
        /// <see cref="PFGroupsListMembershipGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsListMembershipResponse>> PFGroupsListMembershipAsync(
            PFEntityHandle entityHandle,
            PFGroupsListMembershipRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsListMembershipResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsListMembershipGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsListMembershipResponse* result = null;

                    hr = Interop.Methods.PFGroupsListMembershipGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsListMembershipRequest* requestInterop = stackalloc Interop.PFGroupsListMembershipRequest[1];
                PFGroupsListMembershipRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsListMembershipAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists all outstanding invitations and group applications for an entity
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsListMembershipOpportunitiesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Lists all outstanding group applications and invitations for an entity. Anyone may call this for
        /// any entity, but data will only be returned for the entity or a parent of that entity. To list invitations
        /// or applications for a group to check if a player is trying to join, use ListGroupInvitations and ListGroupApplications.
        /// See also GroupListGroupApplicationsAsync, GroupListGroupInvitationsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsListMembershipOpportunitiesGetResultSize"/>
        /// and <see cref="PFGroupsListMembershipOpportunitiesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsListMembershipOpportunitiesResponse>> PFGroupsListMembershipOpportunitiesAsync(
            PFEntityHandle entityHandle,
            PFGroupsListMembershipOpportunitiesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsListMembershipOpportunitiesResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsListMembershipOpportunitiesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsListMembershipOpportunitiesResponse* result = null;

                    hr = Interop.Methods.PFGroupsListMembershipOpportunitiesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsListMembershipOpportunitiesRequest* requestInterop = stackalloc Interop.PFGroupsListMembershipOpportunitiesRequest[1];
                PFGroupsListMembershipOpportunitiesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsListMembershipOpportunitiesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Removes an application to join a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Removes an existing application to join the group. This is used for both rejection of an application
        /// as well as withdrawing an application. The applying entity or a parent in its chain (e.g. title) may
        /// withdraw the application, and any caller with appropriate access in the group may reject an application.
        /// No data is returned in the case of success. See also GroupAcceptGroupApplicationAsync, GroupApplyToGroupAsync,
        /// GroupListGroupApplicationsAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_GROUP_APPLICATION_NOT_FOUND or any of the global PlayFab Service errors.
        /// See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsRemoveGroupApplicationAsync(
            PFEntityHandle entityHandle,
            PFGroupsRemoveGroupApplicationRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsRemoveGroupApplicationRequest* requestInterop = stackalloc Interop.PFGroupsRemoveGroupApplicationRequest[1];
                PFGroupsRemoveGroupApplicationRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsRemoveGroupApplicationAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Removes an invitation join a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Removes an existing invitation to join the group. This is used for both rejection of an invitation
        /// as well as rescinding an invitation. The invited entity or a parent in its chain (e.g. title) may
        /// reject the invitation by calling this method, and any caller with appropriate access in the group
        /// may rescind an invitation. No data is returned in the case of success. See also GroupAcceptGroupInvitationAsync,
        /// GroupInviteToGroupAsync, GroupListGroupInvitationsAsync, GroupListMembershipOpportunitiesAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_GROUP_INVITATION_NOT_FOUND or any of the global PlayFab Service errors.
        /// See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsRemoveGroupInvitationAsync(
            PFEntityHandle entityHandle,
            PFGroupsRemoveGroupInvitationRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsRemoveGroupInvitationRequest* requestInterop = stackalloc Interop.PFGroupsRemoveGroupInvitationRequest[1];
                PFGroupsRemoveGroupInvitationRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsRemoveGroupInvitationAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Removes members from a group.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Removes members from a group. A member can always remove themselves from a group, regardless of permissions.
        /// Returns nothing if successful. See also GroupAddMembersAsync, GroupListGroupMembersAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ROLE_DOES_NOT_EXIST or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsRemoveMembersAsync(
            PFEntityHandle entityHandle,
            PFGroupsRemoveMembersRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsRemoveMembersRequest* requestInterop = stackalloc Interop.PFGroupsRemoveMembersRequest[1];
                PFGroupsRemoveMembersRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsRemoveMembersAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unblocks a list of entities from joining a group
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Unblocks a list of entities from joining a group. No data is returned in the case of success. See
        /// also GroupBlockEntityAsync, GroupListGroupBlocksAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFGroupsUnblockEntityAsync(
            PFEntityHandle entityHandle,
            PFGroupsUnblockEntityRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsUnblockEntityRequest* requestInterop = stackalloc Interop.PFGroupsUnblockEntityRequest[1];
                PFGroupsUnblockEntityRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsUnblockEntityAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates non-membership data about a group.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsUpdateGroupResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Updates data about a group, such as the name or default member role. Returns information about whether
        /// the update was successful. Only title claimants may modify the administration role for a group. See
        /// also GroupCreateGroupAsync, GroupDeleteGroupAsync, GroupGetGroupAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsUpdateGroupGetResultSize"/> and <see
        /// cref="PFGroupsUpdateGroupGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsUpdateGroupResponse>> PFGroupsUpdateGroupAsync(
            PFEntityHandle entityHandle,
            PFGroupsUpdateGroupRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsUpdateGroupResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsUpdateGroupGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsUpdateGroupResponse* result = null;

                    hr = Interop.Methods.PFGroupsUpdateGroupGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsUpdateGroupRequest* requestInterop = stackalloc Interop.PFGroupsUpdateGroupRequest[1];
                PFGroupsUpdateGroupRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsUpdateGroupAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates metadata about a role.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFGroupsUpdateGroupRoleResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Updates the role name. Returns information about whether the update was successful. See also GroupCreateRoleAsync,
        /// GroupDeleteRoleAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFGroupsUpdateRoleGetResultSize"/> and <see
        /// cref="PFGroupsUpdateRoleGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFGroupsUpdateGroupRoleResponse>> PFGroupsUpdateRoleAsync(
            PFEntityHandle entityHandle,
            PFGroupsUpdateGroupRoleRequest request
        )
        {
            TaskCompletionSource<PFResult<PFGroupsUpdateGroupRoleResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFGroupsUpdateRoleGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFGroupsUpdateGroupRoleResponse* result = null;

                    hr = Interop.Methods.PFGroupsUpdateRoleGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFGroupsUpdateGroupRoleRequest* requestInterop = stackalloc Interop.PFGroupsUpdateGroupRoleRequest[1];
                PFGroupsUpdateGroupRoleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFGroupsUpdateRoleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

    }
}
