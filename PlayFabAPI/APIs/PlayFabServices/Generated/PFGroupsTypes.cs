// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFGroupsAcceptGroupApplicationRequest data model. Accepts an outstanding invitation to to join a
    /// group if the invited entity is not blocked by the group. Nothing is returned in the case of success.
    /// </summary>
    public struct PFGroupsAcceptGroupApplicationRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Type of the entity to accept as. Must be the same entity as the claimant or an entity that is a child
        /// of the claimant entity.
        /// </summary>
        public PFEntityKey Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsAcceptGroupApplicationRequest self, Interop.PFGroupsAcceptGroupApplicationRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsAcceptGroupInvitationRequest data model. Accepts an outstanding invitation to join the group
    /// if the invited entity is not blocked by the group. Only the invited entity or a parent in its chain
    /// (e.g. title) may accept the invitation on the invited entity's behalf. Nothing is returned in the
    /// case of success.
    /// </summary>
    public struct PFGroupsAcceptGroupInvitationRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsAcceptGroupInvitationRequest self, Interop.PFGroupsAcceptGroupInvitationRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsAddMembersRequest data model. Adds members to a group or role. Existing members of the group
    /// will added to roles within the group, but if the user is not already a member of the group, only title
    /// claimants may add them to the group, and others must use the group application or invite system to
    /// add new members to a group. Returns nothing if successful.
    /// </summary>
    public struct PFGroupsAddMembersRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// List of entities to add to the group. Only entities of type title_player_account and character may
        /// be added to groups.
        /// </summary>
        public PFEntityKey[] Members;

        /// <summary>
        /// (Optional) Optional: The ID of the existing role to add the entities to. If this is not specified,
        /// the default member role for the group will be used. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string? RoleId;

        internal unsafe static void ToInterop(PFGroupsAddMembersRequest self, Interop.PFGroupsAddMembersRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Members, &interop->members, buffer, PFEntityKey.ToInterop);
            interop->membersCount = (uint)self.Members.Length;

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsApplyToGroupRequest data model. Creates an application to join a group. Calling this while
    /// a group application already exists will return the same application instead of an error and will not
    /// refresh the time before the application expires. By default, if the entity has an invitation to join
    /// the group outstanding, this will accept the invitation to join the group instead and return an error
    /// indicating such, rather than creating a duplicate application to join that will need to be cleaned
    /// up later. Returns information about the application or an error indicating an invitation was accepted
    /// instead.
    /// </summary>
    public struct PFGroupsApplyToGroupRequest
    {
        /// <summary>
        /// (Optional) Optional, default true. Automatically accept an outstanding invitation if one exists instead
        /// of creating an application.
        /// </summary>
        public bool? AutoAcceptOutstandingInvite;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsApplyToGroupRequest self, Interop.PFGroupsApplyToGroupRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AutoAcceptOutstandingInvite != null)
            {
                interop->autoAcceptOutstandingInvite = (byte*)buffer.AddBuffer(sizeof(byte));
                *interop->autoAcceptOutstandingInvite = InteropWrapper.WrapperHelpers.BoolToInterop(self.AutoAcceptOutstandingInvite.Value);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsEntityWithLineage data model. Entity wrapper class that contains the entity key and the entities
    /// that make up the lineage of the entity.
    /// </summary>
    public struct PFGroupsEntityWithLineage
    {
        /// <summary>
        /// (Optional) The entity key for the specified entity.
        /// </summary>
        public PFEntityKey? Key;

        /// <summary>
        /// (Optional) Dictionary of entity keys for related entities. Dictionary key is entity type.
        /// </summary>
        public Dictionary<string, PFEntityKey>? Lineage;

        internal unsafe PFGroupsEntityWithLineage(Interop.PFGroupsEntityWithLineage interop)
        {

            Key = (interop.key == null) ? null : new(*interop.key);

            Lineage = (interop.lineage == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.lineage, interop.lineageCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFEntityKey(*pair.value)));

        }

        internal unsafe static void ToInterop(PFGroupsEntityWithLineage self, Interop.PFGroupsEntityWithLineage* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Key != null)
            {
                interop->key = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Key.Value, interop->key, buffer);
            }

            if (self.Lineage != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.Lineage, &interop->lineage, buffer, (KeyValuePair<string, PFEntityKey> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFEntityKey* valueBuf = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                    PFEntityKey.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFEntityKeyDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->lineageCount = (uint)self.Lineage.Count;
            }

        }
    }

    /// <summary>
    /// PFGroupsApplyToGroupResponse data model. Describes an application to join a group.
    /// </summary>
    public struct PFGroupsApplyToGroupResponse
    {
        /// <summary>
        /// (Optional) Type of entity that requested membership.
        /// </summary>
        public PFGroupsEntityWithLineage? Entity;

        /// <summary>
        /// When the application to join will expire and be deleted.
        /// </summary>
        public long Expires;

        /// <summary>
        /// (Optional) ID of the group that the entity requesting membership to.
        /// </summary>
        public PFEntityKey? Group;

        internal unsafe PFGroupsApplyToGroupResponse(Interop.PFGroupsApplyToGroupResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            Expires = interop.expires;

            Group = (interop.group == null) ? null : new(*interop.group);

        }
    }

    /// <summary>
    /// PFGroupsBlockEntityRequest data model. Blocks a list of entities from joining a group. Blocked entities
    /// may not create new applications to join, be invited to join, accept an invitation, or have an application
    /// accepted. Failure due to being blocked does not clean up existing applications or invitations to the
    /// group. No data is returned in the case of success.
    /// </summary>
    public struct PFGroupsBlockEntityRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public PFEntityKey Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsBlockEntityRequest self, Interop.PFGroupsBlockEntityRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsChangeMemberRoleRequest data model. Changes the role membership of a list of entities from
    /// one role to another in in a single operation. The destination role must already exist. This is equivalent
    /// to adding the entities to the destination role and removing from the origin role. Returns nothing
    /// if successful.
    /// </summary>
    public struct PFGroupsChangeMemberRoleRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The ID of the role that the entities will become a member of. This must be an existing
        /// role. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string? DestinationRoleId;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// List of entities to move between roles in the group. All entities in this list must be members of
        /// the group and origin role.
        /// </summary>
        public PFEntityKey[] Members;

        /// <summary>
        /// The ID of the role that the entities currently are a member of. Role IDs must be between 1 and 64
        /// characters long.
        /// </summary>
        public string OriginRoleId;

        internal unsafe static void ToInterop(PFGroupsChangeMemberRoleRequest self, Interop.PFGroupsChangeMemberRoleRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.DestinationRoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DestinationRoleId, &interop->destinationRoleId, buffer);
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Members, &interop->members, buffer, PFEntityKey.ToInterop);
            interop->membersCount = (uint)self.Members.Length;

            InteropWrapper.WrapperHelpers.StringToInterop(self.OriginRoleId, &interop->originRoleId, buffer);

        }
    }

    /// <summary>
    /// PFGroupsCreateGroupRequest data model. Creates a new group, as well as administration and member
    /// roles, based off of a title's group template. Returns information about the group that was created.
    /// </summary>
    public struct PFGroupsCreateGroupRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The name of the group. This is unique at the title level by default.
        /// </summary>
        public string GroupName;

        internal unsafe static void ToInterop(PFGroupsCreateGroupRequest self, Interop.PFGroupsCreateGroupRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.GroupName, &interop->groupName, buffer);

        }
    }

    /// <summary>
    /// PFGroupsCreateGroupResponse data model.
    /// </summary>
    public struct PFGroupsCreateGroupResponse
    {
        /// <summary>
        /// (Optional) The ID of the administrator role for the group.
        /// </summary>
        public string? AdminRoleId;

        /// <summary>
        /// The server date and time the group was created.
        /// </summary>
        public long Created;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// (Optional) The name of the group.
        /// </summary>
        public string? GroupName;

        /// <summary>
        /// (Optional) The ID of the default member role for the group.
        /// </summary>
        public string? MemberRoleId;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        /// <summary>
        /// (Optional) The list of roles and names that belong to the group.
        /// </summary>
        public Dictionary<string, string>? Roles;

        internal unsafe PFGroupsCreateGroupResponse(Interop.PFGroupsCreateGroupResponse interop)
        {

            AdminRoleId = (interop.adminRoleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.adminRoleId);

            Created = interop.created;

            Group = new(*interop.group);

            GroupName = (interop.groupName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.groupName);

            MemberRoleId = (interop.memberRoleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.memberRoleId);

            ProfileVersion = interop.profileVersion;

            Roles = (interop.roles == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.roles, interop.rolesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

        }
    }

    /// <summary>
    /// PFGroupsCreateGroupRoleRequest data model. Creates a new role within an existing group, with no members.
    /// Both the role ID and role name must be unique within the group, but the name can be the same as the
    /// ID. The role ID is set at creation and cannot be changed. Returns information about the role that
    /// was created.
    /// </summary>
    public struct PFGroupsCreateGroupRoleRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// The ID of the role. This must be unique within the group and cannot be changed. Role IDs must be
        /// between 1 and 64 characters long and are restricted to a-Z, A-Z, 0-9, '(', ')', '_', '-' and '.'.
        /// </summary>
        public string RoleId;

        /// <summary>
        /// The name of the role. This must be unique within the group and can be changed later. Role names must
        /// be between 1 and 100 characters long.
        /// </summary>
        public string RoleName;

        internal unsafe static void ToInterop(PFGroupsCreateGroupRoleRequest self, Interop.PFGroupsCreateGroupRoleRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.RoleName, &interop->roleName, buffer);

        }
    }

    /// <summary>
    /// PFGroupsCreateGroupRoleResponse data model.
    /// </summary>
    public struct PFGroupsCreateGroupRoleResponse
    {
        /// <summary>
        /// The current version of the group profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        /// <summary>
        /// (Optional) ID for the role.
        /// </summary>
        public string? RoleId;

        /// <summary>
        /// (Optional) The name of the role.
        /// </summary>
        public string? RoleName;

        internal unsafe PFGroupsCreateGroupRoleResponse(Interop.PFGroupsCreateGroupRoleResponse interop)
        {

            ProfileVersion = interop.profileVersion;

            RoleId = (interop.roleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.roleId);

            RoleName = (interop.roleName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.roleName);

        }
    }

    /// <summary>
    /// PFGroupsDeleteGroupRequest data model. Deletes a group and all roles, invitations, join requests,
    /// and blocks associated with it. Permission to delete is only required the group itself to execute this
    /// action. The group and data cannot be cannot be recovered once removed, but any abuse reports about
    /// the group will remain. No data is returned in the case of success.
    /// </summary>
    public struct PFGroupsDeleteGroupRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// ID of the group or role to remove.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsDeleteGroupRequest self, Interop.PFGroupsDeleteGroupRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsDeleteRoleRequest data model. Returns information about the role.
    /// </summary>
    public struct PFGroupsDeleteRoleRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// (Optional) The ID of the role to delete. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string? RoleId;

        internal unsafe static void ToInterop(PFGroupsDeleteRoleRequest self, Interop.PFGroupsDeleteRoleRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsGetGroupRequest data model. Returns the ID, name, role list and other non-membership related
    /// information about a group.
    /// </summary>
    public struct PFGroupsGetGroupRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The identifier of the group.
        /// </summary>
        public PFEntityKey? Group;

        /// <summary>
        /// (Optional) The full name of the group.
        /// </summary>
        public string? GroupName;

        internal unsafe static void ToInterop(PFGroupsGetGroupRequest self, Interop.PFGroupsGetGroupRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Group != null)
            {
                interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Group.Value, interop->group, buffer);
            }

            if (self.GroupName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GroupName, &interop->groupName, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsGetGroupResponse data model.
    /// </summary>
    public struct PFGroupsGetGroupResponse
    {
        /// <summary>
        /// (Optional) The ID of the administrator role for the group.
        /// </summary>
        public string? AdminRoleId;

        /// <summary>
        /// The server date and time the group was created.
        /// </summary>
        public long Created;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// (Optional) The name of the group.
        /// </summary>
        public string? GroupName;

        /// <summary>
        /// (Optional) The ID of the default member role for the group.
        /// </summary>
        public string? MemberRoleId;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        /// <summary>
        /// (Optional) The list of roles and names that belong to the group.
        /// </summary>
        public Dictionary<string, string>? Roles;

        internal unsafe PFGroupsGetGroupResponse(Interop.PFGroupsGetGroupResponse interop)
        {

            AdminRoleId = (interop.adminRoleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.adminRoleId);

            Created = interop.created;

            Group = new(*interop.group);

            GroupName = (interop.groupName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.groupName);

            MemberRoleId = (interop.memberRoleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.memberRoleId);

            ProfileVersion = interop.profileVersion;

            Roles = (interop.roles == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.roles, interop.rolesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

        }
    }

    /// <summary>
    /// PFGroupsInviteToGroupRequest data model. Invites a player to join a group, if they are not blocked
    /// by the group. An optional role can be provided to automatically assign the player to the role if they
    /// accept the invitation. By default, if the entity has an application to the group outstanding, this
    /// will accept the application instead and return an error indicating such, rather than creating a duplicate
    /// invitation to join that will need to be cleaned up later. Returns information about the new invitation
    /// or an error indicating an existing application to join was accepted.
    /// </summary>
    public struct PFGroupsInviteToGroupRequest
    {
        /// <summary>
        /// (Optional) Optional, default true. Automatically accept an application if one exists instead of creating
        /// an invitation.
        /// </summary>
        public bool? AutoAcceptOutstandingApplication;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public PFEntityKey Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// (Optional) Optional. ID of an existing a role in the group to assign the user to. The group's default
        /// member role is used if this is not specified. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string? RoleId;

        internal unsafe static void ToInterop(PFGroupsInviteToGroupRequest self, Interop.PFGroupsInviteToGroupRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AutoAcceptOutstandingApplication != null)
            {
                interop->autoAcceptOutstandingApplication = (byte*)buffer.AddBuffer(sizeof(byte));
                *interop->autoAcceptOutstandingApplication = InteropWrapper.WrapperHelpers.BoolToInterop(self.AutoAcceptOutstandingApplication.Value);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsInviteToGroupResponse data model. Describes an invitation to a group.
    /// </summary>
    public struct PFGroupsInviteToGroupResponse
    {
        /// <summary>
        /// When the invitation will expire and be deleted.
        /// </summary>
        public long Expires;

        /// <summary>
        /// (Optional) The group that the entity invited to.
        /// </summary>
        public PFEntityKey? Group;

        /// <summary>
        /// (Optional) The entity that created the invitation.
        /// </summary>
        public PFGroupsEntityWithLineage? InvitedByEntity;

        /// <summary>
        /// (Optional) The entity that is invited.
        /// </summary>
        public PFGroupsEntityWithLineage? InvitedEntity;

        /// <summary>
        /// (Optional) ID of the role in the group to assign the user to.
        /// </summary>
        public string? RoleId;

        internal unsafe PFGroupsInviteToGroupResponse(Interop.PFGroupsInviteToGroupResponse interop)
        {

            Expires = interop.expires;

            Group = (interop.group == null) ? null : new(*interop.group);

            InvitedByEntity = (interop.invitedByEntity == null) ? null : new(*interop.invitedByEntity);

            InvitedEntity = (interop.invitedEntity == null) ? null : new(*interop.invitedEntity);

            RoleId = (interop.roleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.roleId);

        }
    }

    /// <summary>
    /// PFGroupsIsMemberRequest data model. Checks to see if an entity is a member of a group or role within
    /// the group. A result indicating if the entity is a member of the group is returned, or a permission
    /// error if the caller does not have permission to read the group's member list.
    /// </summary>
    public struct PFGroupsIsMemberRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public PFEntityKey Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// (Optional) Optional: ID of the role to check membership of. Defaults to any role (that is, check
        /// to see if the entity is a member of the group in any capacity) if not specified.
        /// </summary>
        public string? RoleId;

        internal unsafe static void ToInterop(PFGroupsIsMemberRequest self, Interop.PFGroupsIsMemberRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsIsMemberResponse data model.
    /// </summary>
    public struct PFGroupsIsMemberResponse
    {
        /// <summary>
        /// A value indicating whether or not the entity is a member.
        /// </summary>
        public bool IsMember;

        internal unsafe PFGroupsIsMemberResponse(Interop.PFGroupsIsMemberResponse interop)
        {

            IsMember = InteropWrapper.WrapperHelpers.InteropToBool(interop.isMember);

        }
    }

    /// <summary>
    /// PFGroupsListGroupApplicationsRequest data model. Lists all outstanding requests to join a group.
    /// Returns a list of all requests to join, as well as when the request will expire. To get the group
    /// applications for a specific entity, use ListMembershipOpportunities.
    /// </summary>
    public struct PFGroupsListGroupApplicationsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsListGroupApplicationsRequest self, Interop.PFGroupsListGroupApplicationsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsGroupApplication data model. Describes an application to join a group.
    /// </summary>
    public struct PFGroupsGroupApplication
    {
        /// <summary>
        /// (Optional) Type of entity that requested membership.
        /// </summary>
        public PFGroupsEntityWithLineage? Entity;

        /// <summary>
        /// When the application to join will expire and be deleted.
        /// </summary>
        public long Expires;

        /// <summary>
        /// (Optional) ID of the group that the entity requesting membership to.
        /// </summary>
        public PFEntityKey? Group;

        internal unsafe PFGroupsGroupApplication(Interop.PFGroupsGroupApplication interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            Expires = interop.expires;

            Group = (interop.group == null) ? null : new(*interop.group);

        }

        internal unsafe static void ToInterop(PFGroupsGroupApplication self, Interop.PFGroupsGroupApplication* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFGroupsEntityWithLineage*)buffer.AddBuffer(sizeof(Interop.PFGroupsEntityWithLineage));
                PFGroupsEntityWithLineage.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            interop->expires = self.Expires;

            if (self.Group != null)
            {
                interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Group.Value, interop->group, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsListGroupApplicationsResponse data model.
    /// </summary>
    public struct PFGroupsListGroupApplicationsResponse
    {
        /// <summary>
        /// (Optional) The requested list of applications to the group.
        /// </summary>
        public PFGroupsGroupApplication[]? Applications;

        internal unsafe PFGroupsListGroupApplicationsResponse(Interop.PFGroupsListGroupApplicationsResponse interop)
        {

            Applications = (interop.applications == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.applications, interop.applicationsCount, elem => new PFGroupsGroupApplication(elem));

        }
    }

    /// <summary>
    /// PFGroupsListGroupBlocksRequest data model. Lists all entities blocked from joining a group. A list
    /// of blocked entities is returned.
    /// </summary>
    public struct PFGroupsListGroupBlocksRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsListGroupBlocksRequest self, Interop.PFGroupsListGroupBlocksRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsGroupBlock data model. Describes an entity that is blocked from joining a group.
    /// </summary>
    public struct PFGroupsGroupBlock
    {
        /// <summary>
        /// (Optional) The entity that is blocked.
        /// </summary>
        public PFGroupsEntityWithLineage? Entity;

        /// <summary>
        /// ID of the group that the entity is blocked from.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe PFGroupsGroupBlock(Interop.PFGroupsGroupBlock interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            Group = new(*interop.group);

        }

        internal unsafe static void ToInterop(PFGroupsGroupBlock self, Interop.PFGroupsGroupBlock* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFGroupsEntityWithLineage*)buffer.AddBuffer(sizeof(Interop.PFGroupsEntityWithLineage));
                PFGroupsEntityWithLineage.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsListGroupBlocksResponse data model.
    /// </summary>
    public struct PFGroupsListGroupBlocksResponse
    {
        /// <summary>
        /// (Optional) The requested list blocked entities.
        /// </summary>
        public PFGroupsGroupBlock[]? BlockedEntities;

        internal unsafe PFGroupsListGroupBlocksResponse(Interop.PFGroupsListGroupBlocksResponse interop)
        {

            BlockedEntities = (interop.blockedEntities == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.blockedEntities, interop.blockedEntitiesCount, elem => new PFGroupsGroupBlock(elem));

        }
    }

    /// <summary>
    /// PFGroupsListGroupInvitationsRequest data model. Lists all outstanding invitations for a group. Returns
    /// a list of entities that have been invited, as well as when the invitation will expire. To get the
    /// group invitations for a specific entity, use ListMembershipOpportunities.
    /// </summary>
    public struct PFGroupsListGroupInvitationsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsListGroupInvitationsRequest self, Interop.PFGroupsListGroupInvitationsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsGroupInvitation data model. Describes an invitation to a group.
    /// </summary>
    public struct PFGroupsGroupInvitation
    {
        /// <summary>
        /// When the invitation will expire and be deleted.
        /// </summary>
        public long Expires;

        /// <summary>
        /// (Optional) The group that the entity invited to.
        /// </summary>
        public PFEntityKey? Group;

        /// <summary>
        /// (Optional) The entity that created the invitation.
        /// </summary>
        public PFGroupsEntityWithLineage? InvitedByEntity;

        /// <summary>
        /// (Optional) The entity that is invited.
        /// </summary>
        public PFGroupsEntityWithLineage? InvitedEntity;

        /// <summary>
        /// (Optional) ID of the role in the group to assign the user to.
        /// </summary>
        public string? RoleId;

        internal unsafe PFGroupsGroupInvitation(Interop.PFGroupsGroupInvitation interop)
        {

            Expires = interop.expires;

            Group = (interop.group == null) ? null : new(*interop.group);

            InvitedByEntity = (interop.invitedByEntity == null) ? null : new(*interop.invitedByEntity);

            InvitedEntity = (interop.invitedEntity == null) ? null : new(*interop.invitedEntity);

            RoleId = (interop.roleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.roleId);

        }

        internal unsafe static void ToInterop(PFGroupsGroupInvitation self, Interop.PFGroupsGroupInvitation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->expires = self.Expires;

            if (self.Group != null)
            {
                interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Group.Value, interop->group, buffer);
            }

            if (self.InvitedByEntity != null)
            {
                interop->invitedByEntity = (Interop.PFGroupsEntityWithLineage*)buffer.AddBuffer(sizeof(Interop.PFGroupsEntityWithLineage));
                PFGroupsEntityWithLineage.ToInterop(self.InvitedByEntity.Value, interop->invitedByEntity, buffer);
            }

            if (self.InvitedEntity != null)
            {
                interop->invitedEntity = (Interop.PFGroupsEntityWithLineage*)buffer.AddBuffer(sizeof(Interop.PFGroupsEntityWithLineage));
                PFGroupsEntityWithLineage.ToInterop(self.InvitedEntity.Value, interop->invitedEntity, buffer);
            }

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsListGroupInvitationsResponse data model.
    /// </summary>
    public struct PFGroupsListGroupInvitationsResponse
    {
        /// <summary>
        /// (Optional) The requested list of group invitations.
        /// </summary>
        public PFGroupsGroupInvitation[]? Invitations;

        internal unsafe PFGroupsListGroupInvitationsResponse(Interop.PFGroupsListGroupInvitationsResponse interop)
        {

            Invitations = (interop.invitations == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.invitations, interop.invitationsCount, elem => new PFGroupsGroupInvitation(elem));

        }
    }

    /// <summary>
    /// PFGroupsListGroupMembersRequest data model. Gets a list of members and the roles they belong to within
    /// the group. If the caller does not have permission to view the role, and the member is in no other
    /// role, the member is not displayed. Returns a list of entities that are members of the group.
    /// </summary>
    public struct PFGroupsListGroupMembersRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// ID of the group to list the members and roles for.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsListGroupMembersRequest self, Interop.PFGroupsListGroupMembersRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsEntityMemberRole data model.
    /// </summary>
    public struct PFGroupsEntityMemberRole
    {
        /// <summary>
        /// (Optional) The list of members in the role.
        /// </summary>
        public PFGroupsEntityWithLineage[]? Members;

        /// <summary>
        /// (Optional) The ID of the role.
        /// </summary>
        public string? RoleId;

        /// <summary>
        /// (Optional) The name of the role.
        /// </summary>
        public string? RoleName;

        internal unsafe PFGroupsEntityMemberRole(Interop.PFGroupsEntityMemberRole interop)
        {

            Members = (interop.members == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.members, interop.membersCount, elem => new PFGroupsEntityWithLineage(elem));

            RoleId = (interop.roleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.roleId);

            RoleName = (interop.roleName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.roleName);

        }

        internal unsafe static void ToInterop(PFGroupsEntityMemberRole self, Interop.PFGroupsEntityMemberRole* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Members != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Members, &interop->members, buffer, PFGroupsEntityWithLineage.ToInterop);
                interop->membersCount = (uint)self.Members.Length;
            }

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

            if (self.RoleName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleName, &interop->roleName, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsListGroupMembersResponse data model.
    /// </summary>
    public struct PFGroupsListGroupMembersResponse
    {
        /// <summary>
        /// (Optional) The requested list of roles and member entity IDs.
        /// </summary>
        public PFGroupsEntityMemberRole[]? Members;

        internal unsafe PFGroupsListGroupMembersResponse(Interop.PFGroupsListGroupMembersResponse interop)
        {

            Members = (interop.members == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.members, interop.membersCount, elem => new PFGroupsEntityMemberRole(elem));

        }
    }

    /// <summary>
    /// PFGroupsListMembershipRequest data model. Lists the groups and roles that an entity is a part of,
    /// checking to see if group and role metadata and memberships should be visible to the caller. If the
    /// entity is not in any roles that are visible to the caller, the group is not returned in the results,
    /// even if the caller otherwise has permission to see that the entity is a member of that group.
    /// </summary>
    public struct PFGroupsListMembershipRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe static void ToInterop(PFGroupsListMembershipRequest self, Interop.PFGroupsListMembershipRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsGroupRole data model. Describes a group role.
    /// </summary>
    public struct PFGroupsGroupRole
    {
        /// <summary>
        /// (Optional) ID for the role.
        /// </summary>
        public string? RoleId;

        /// <summary>
        /// (Optional) The name of the role.
        /// </summary>
        public string? RoleName;

        internal unsafe PFGroupsGroupRole(Interop.PFGroupsGroupRole interop)
        {

            RoleId = (interop.roleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.roleId);

            RoleName = (interop.roleName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.roleName);

        }

        internal unsafe static void ToInterop(PFGroupsGroupRole self, Interop.PFGroupsGroupRole* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

            if (self.RoleName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleName, &interop->roleName, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsGroupWithRoles data model. Describes a group and the roles that it contains.
    /// </summary>
    public struct PFGroupsGroupWithRoles
    {
        /// <summary>
        /// (Optional) ID for the group.
        /// </summary>
        public PFEntityKey? Group;

        /// <summary>
        /// (Optional) The name of the group.
        /// </summary>
        public string? GroupName;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        /// <summary>
        /// (Optional) The list of roles within the group.
        /// </summary>
        public PFGroupsGroupRole[]? Roles;

        internal unsafe PFGroupsGroupWithRoles(Interop.PFGroupsGroupWithRoles interop)
        {

            Group = (interop.group == null) ? null : new(*interop.group);

            GroupName = (interop.groupName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.groupName);

            ProfileVersion = interop.profileVersion;

            Roles = (interop.roles == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.roles, interop.rolesCount, elem => new PFGroupsGroupRole(elem));

        }

        internal unsafe static void ToInterop(PFGroupsGroupWithRoles self, Interop.PFGroupsGroupWithRoles* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Group != null)
            {
                interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Group.Value, interop->group, buffer);
            }

            if (self.GroupName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GroupName, &interop->groupName, buffer);
            }

            interop->profileVersion = self.ProfileVersion;

            if (self.Roles != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Roles, &interop->roles, buffer, PFGroupsGroupRole.ToInterop);
                interop->rolesCount = (uint)self.Roles.Length;
            }

        }
    }

    /// <summary>
    /// PFGroupsListMembershipResponse data model.
    /// </summary>
    public struct PFGroupsListMembershipResponse
    {
        /// <summary>
        /// (Optional) The list of groups.
        /// </summary>
        public PFGroupsGroupWithRoles[]? Groups;

        internal unsafe PFGroupsListMembershipResponse(Interop.PFGroupsListMembershipResponse interop)
        {

            Groups = (interop.groups == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.groups, interop.groupsCount, elem => new PFGroupsGroupWithRoles(elem));

        }
    }

    /// <summary>
    /// PFGroupsListMembershipOpportunitiesRequest data model. Lists all outstanding group applications and
    /// invitations for an entity. Anyone may call this for any entity, but data will only be returned for
    /// the entity or a parent of that entity. To list invitations or applications for a group to check if
    /// a player is trying to join, use ListGroupInvitations and ListGroupApplications.
    /// </summary>
    public struct PFGroupsListMembershipOpportunitiesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe static void ToInterop(PFGroupsListMembershipOpportunitiesRequest self, Interop.PFGroupsListMembershipOpportunitiesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsListMembershipOpportunitiesResponse data model.
    /// </summary>
    public struct PFGroupsListMembershipOpportunitiesResponse
    {
        /// <summary>
        /// (Optional) The requested list of group applications.
        /// </summary>
        public PFGroupsGroupApplication[]? Applications;

        /// <summary>
        /// (Optional) The requested list of group invitations.
        /// </summary>
        public PFGroupsGroupInvitation[]? Invitations;

        internal unsafe PFGroupsListMembershipOpportunitiesResponse(Interop.PFGroupsListMembershipOpportunitiesResponse interop)
        {

            Applications = (interop.applications == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.applications, interop.applicationsCount, elem => new PFGroupsGroupApplication(elem));

            Invitations = (interop.invitations == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.invitations, interop.invitationsCount, elem => new PFGroupsGroupInvitation(elem));

        }
    }

    /// <summary>
    /// PFGroupsRemoveGroupApplicationRequest data model. Removes an existing application to join the group.
    /// This is used for both rejection of an application as well as withdrawing an application. The applying
    /// entity or a parent in its chain (e.g. title) may withdraw the application, and any caller with appropriate
    /// access in the group may reject an application. No data is returned in the case of success.
    /// </summary>
    public struct PFGroupsRemoveGroupApplicationRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public PFEntityKey Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsRemoveGroupApplicationRequest self, Interop.PFGroupsRemoveGroupApplicationRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsRemoveGroupInvitationRequest data model. Removes an existing invitation to join the group.
    /// This is used for both rejection of an invitation as well as rescinding an invitation. The invited
    /// entity or a parent in its chain (e.g. title) may reject the invitation by calling this method, and
    /// any caller with appropriate access in the group may rescind an invitation. No data is returned in
    /// the case of success.
    /// </summary>
    public struct PFGroupsRemoveGroupInvitationRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public PFEntityKey Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsRemoveGroupInvitationRequest self, Interop.PFGroupsRemoveGroupInvitationRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsRemoveMembersRequest data model. Removes members from a group. A member can always remove
    /// themselves from a group, regardless of permissions. Returns nothing if successful.
    /// </summary>
    public struct PFGroupsRemoveMembersRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// List of entities to remove.
        /// </summary>
        public PFEntityKey[] Members;

        /// <summary>
        /// (Optional) The ID of the role to remove the entities from.
        /// </summary>
        public string? RoleId;

        internal unsafe static void ToInterop(PFGroupsRemoveMembersRequest self, Interop.PFGroupsRemoveMembersRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Members, &interop->members, buffer, PFEntityKey.ToInterop);
            interop->membersCount = (uint)self.Members.Length;

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsUnblockEntityRequest data model. Unblocks a list of entities from joining a group. No data
    /// is returned in the case of success.
    /// </summary>
    public struct PFGroupsUnblockEntityRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public PFEntityKey Entity;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        internal unsafe static void ToInterop(PFGroupsUnblockEntityRequest self, Interop.PFGroupsUnblockEntityRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

        }
    }

    /// <summary>
    /// PFGroupsUpdateGroupRequest data model. Updates data about a group, such as the name or default member
    /// role. Returns information about whether the update was successful. Only title claimants may modify
    /// the administration role for a group.
    /// </summary>
    public struct PFGroupsUpdateGroupRequest
    {
        /// <summary>
        /// (Optional) Optional: the ID of an existing role to set as the new administrator role for the group.
        /// </summary>
        public string? AdminRoleId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Optional field used for concurrency control. By specifying the previously returned value
        /// of ProfileVersion from the GetGroup API, you can ensure that the group data update will only be performed
        /// if the group has not been updated by any other clients since the version you last loaded.
        /// </summary>
        public int? ExpectedProfileVersion;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// (Optional) Optional: the new name of the group.
        /// </summary>
        public string? GroupName;

        /// <summary>
        /// (Optional) Optional: the ID of an existing role to set as the new member role for the group.
        /// </summary>
        public string? MemberRoleId;

        internal unsafe static void ToInterop(PFGroupsUpdateGroupRequest self, Interop.PFGroupsUpdateGroupRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AdminRoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AdminRoleId, &interop->adminRoleId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ExpectedProfileVersion != null)
            {
                interop->expectedProfileVersion = (int*)buffer.AddBuffer(sizeof(int));
                *interop->expectedProfileVersion = self.ExpectedProfileVersion.Value;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            if (self.GroupName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GroupName, &interop->groupName, buffer);
            }

            if (self.MemberRoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MemberRoleId, &interop->memberRoleId, buffer);
            }

        }
    }

    /// <summary>
    /// PFGroupsUpdateGroupResponse data model.
    /// </summary>
    public struct PFGroupsUpdateGroupResponse
    {
        /// <summary>
        /// (Optional) Optional reason to explain why the operation was the result that it was.
        /// </summary>
        public string? OperationReason;

        /// <summary>
        /// New version of the group data.
        /// </summary>
        public int ProfileVersion;

        /// <summary>
        /// (Optional) Indicates which operation was completed, either Created, Updated, Deleted or None.
        /// </summary>
        public PFOperationTypes? SetResult;

        internal unsafe PFGroupsUpdateGroupResponse(Interop.PFGroupsUpdateGroupResponse interop)
        {

            OperationReason = (interop.operationReason == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationReason);

            ProfileVersion = interop.profileVersion;

            SetResult = (interop.setResult == null) ? null : (PFOperationTypes?)(*interop.setResult);

        }
    }

    /// <summary>
    /// PFGroupsUpdateGroupRoleRequest data model. Updates the role name. Returns information about whether
    /// the update was successful.
    /// </summary>
    public struct PFGroupsUpdateGroupRoleRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Optional field used for concurrency control. By specifying the previously returned value
        /// of ProfileVersion from the GetGroup API, you can ensure that the group data update will only be performed
        /// if the group has not been updated by any other clients since the version you last loaded.
        /// </summary>
        public int? ExpectedProfileVersion;

        /// <summary>
        /// The identifier of the group.
        /// </summary>
        public PFEntityKey Group;

        /// <summary>
        /// (Optional) ID of the role to update. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string? RoleId;

        /// <summary>
        /// The new name of the role.
        /// </summary>
        public string RoleName;

        internal unsafe static void ToInterop(PFGroupsUpdateGroupRoleRequest self, Interop.PFGroupsUpdateGroupRoleRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ExpectedProfileVersion != null)
            {
                interop->expectedProfileVersion = (int*)buffer.AddBuffer(sizeof(int));
                *interop->expectedProfileVersion = self.ExpectedProfileVersion.Value;
            }

            interop->group = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Group, interop->group, buffer);

            if (self.RoleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoleId, &interop->roleId, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.RoleName, &interop->roleName, buffer);

        }
    }

    /// <summary>
    /// PFGroupsUpdateGroupRoleResponse data model.
    /// </summary>
    public struct PFGroupsUpdateGroupRoleResponse
    {
        /// <summary>
        /// (Optional) Optional reason to explain why the operation was the result that it was.
        /// </summary>
        public string? OperationReason;

        /// <summary>
        /// New version of the role data.
        /// </summary>
        public int ProfileVersion;

        /// <summary>
        /// (Optional) Indicates which operation was completed, either Created, Updated, Deleted or None.
        /// </summary>
        public PFOperationTypes? SetResult;

        internal unsafe PFGroupsUpdateGroupRoleResponse(Interop.PFGroupsUpdateGroupRoleResponse interop)
        {

            OperationReason = (interop.operationReason == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationReason);

            ProfileVersion = interop.profileVersion;

            SetResult = (interop.setResult == null) ? null : (PFOperationTypes?)(*interop.setResult);

        }
    }

}
