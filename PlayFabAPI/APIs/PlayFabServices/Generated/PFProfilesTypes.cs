// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// EffectType enum.
    /// </summary>
    public enum PFProfilesEffectType : uint
    {
        Allow = Interop.PFProfilesEffectType.Allow,
        Deny = Interop.PFProfilesEffectType.Deny
    }

    /// <summary>
    /// PFProfilesGetEntityProfileRequest data model. Given an entity type and entity identifier will retrieve
    /// the profile from the entity store. If the profile being retrieved is the caller's, then the read operation
    /// is consistent, if not it is an inconsistent read. An inconsistent read means that we do not guarantee
    /// all committed writes have occurred before reading the profile, allowing for a stale read. If consistency
    /// is important the Version Number on the result can be used to compare which version of the profile
    /// any reader has.
    /// </summary>
    public struct PFProfilesGetEntityProfileRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Determines whether the objects will be returned as an escaped JSON string or as a un-escaped
        /// JSON object. Default is JSON string.
        /// </summary>
        public bool? DataAsObject;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe static void ToInterop(PFProfilesGetEntityProfileRequest self, Interop.PFProfilesGetEntityProfileRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.DataAsObject != null)
            {
                *interop->dataAsObject = InteropWrapper.WrapperHelpers.BoolToInterop(self.DataAsObject.Value);
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFProfilesEntityProfileFileMetadata data model. An entity file's meta data. To get a download URL
    /// call File/GetFiles API.
    /// </summary>
    public struct PFProfilesEntityProfileFileMetadata
    {
        /// <summary>
        /// (Optional) Checksum value for the file, can be used to check if the file on the server has changed.
        /// </summary>
        public string? Checksum;

        /// <summary>
        /// (Optional) Name of the file.
        /// </summary>
        public string? FileName;

        /// <summary>
        /// Last UTC time the file was modified.
        /// </summary>
        public long LastModified;

        /// <summary>
        /// Storage service's reported byte count.
        /// </summary>
        public int Size;

        internal unsafe PFProfilesEntityProfileFileMetadata(Interop.PFProfilesEntityProfileFileMetadata interop)
        {

            Checksum = (interop.checksum == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.checksum);

            FileName = (interop.fileName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.fileName);

            LastModified = interop.lastModified;

            Size = interop.size;

        }

        internal unsafe static void ToInterop(PFProfilesEntityProfileFileMetadata self, Interop.PFProfilesEntityProfileFileMetadata* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Checksum != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Checksum, &interop->checksum, buffer);
            }

            if (self.FileName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FileName, &interop->fileName, buffer);
            }

            interop->lastModified = self.LastModified;

            interop->size = self.Size;

        }
            
    }

    /// <summary>
    /// PFProfilesEntityDataObject data model. An entity object and its associated meta data.
    /// </summary>
    public struct PFProfilesEntityDataObject
    {
        /// <summary>
        /// (Optional) Un-escaped JSON object, if DataAsObject is true.
        /// </summary>
        public PFJsonObject DataObject;

        /// <summary>
        /// (Optional) Escaped string JSON body of the object, if DataAsObject is default or false.
        /// </summary>
        public string? EscapedDataObject;

        /// <summary>
        /// (Optional) Name of this object.
        /// </summary>
        public string? ObjectName;

        internal unsafe PFProfilesEntityDataObject(Interop.PFProfilesEntityDataObject interop)
        {

            DataObject = (interop.dataObject.stringValue == null) ? default : new PFJsonObject(interop.dataObject);

            EscapedDataObject = (interop.escapedDataObject == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.escapedDataObject);

            ObjectName = (interop.objectName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.objectName);

        }

        internal unsafe static void ToInterop(PFProfilesEntityDataObject self, Interop.PFProfilesEntityDataObject* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.DataObject.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DataObject.stringValue, &interop->dataObject.stringValue, buffer);
            }

            if (self.EscapedDataObject != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EscapedDataObject, &interop->escapedDataObject, buffer);
            }

            if (self.ObjectName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ObjectName, &interop->objectName, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFProfilesEntityPermissionStatement data model.
    /// </summary>
    public struct PFProfilesEntityPermissionStatement
    {
        /// <summary>
        /// The action this statement effects. May be 'Read', 'Write' or '*' for both read and write.
        /// </summary>
        public string Action;

        /// <summary>
        /// (Optional) A comment about the statement. Intended solely for bookkeeping and debugging.
        /// </summary>
        public string? Comment;

        /// <summary>
        /// (Optional) Additional conditions to be applied for entity resources.
        /// </summary>
        public PFJsonObject Condition;

        /// <summary>
        /// The effect this statement will have. It may be either Allow or Deny.
        /// </summary>
        public PFProfilesEffectType Effect;

        /// <summary>
        /// The principal this statement will effect.
        /// </summary>
        public PFJsonObject Principal;

        /// <summary>
        /// The resource this statements effects. Similar to 'pfrn:data--title![Title ID]/Profile/*'.
        /// </summary>
        public string Resource;

        internal unsafe PFProfilesEntityPermissionStatement(Interop.PFProfilesEntityPermissionStatement interop)
        {

            Action = InteropWrapper.WrapperHelpers.InteropToString(interop.action)!;

            Comment = (interop.comment == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.comment);

            Condition = (interop.condition.stringValue == null) ? default : new PFJsonObject(interop.condition);

            Effect = (PFProfilesEffectType)(interop.effect);

            Principal = new PFJsonObject(interop.principal)!;

            Resource = InteropWrapper.WrapperHelpers.InteropToString(interop.resource)!;

        }

        internal unsafe static void ToInterop(PFProfilesEntityPermissionStatement self, Interop.PFProfilesEntityPermissionStatement* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Action, &interop->action, buffer);

            if (self.Comment != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Comment, &interop->comment, buffer);
            }

            if (self.Condition.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Condition.stringValue, &interop->condition.stringValue, buffer);
            }

            interop->effect = (Interop.PFProfilesEffectType)self.Effect;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Principal.stringValue, &interop->principal.stringValue, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.Resource, &interop->resource, buffer);

        }
            
    }

    /// <summary>
    /// PFEntityStatisticValue data model.
    /// </summary>
    public struct PFEntityStatisticValue
    {
        /// <summary>
        /// (Optional) Metadata associated with the Statistic.
        /// </summary>
        public string? Metadata;

        /// <summary>
        /// (Optional) Statistic name.
        /// </summary>
        public string? Name;

        /// <summary>
        /// (Optional) Statistic scores.
        /// </summary>
        public string[]? Scores;

        /// <summary>
        /// Statistic version.
        /// </summary>
        public int Version;

        internal unsafe PFEntityStatisticValue(Interop.PFEntityStatisticValue interop)
        {

            Metadata = (interop.metadata == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.metadata);

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            Scores = (interop.scores == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.scores, interop.scoresCount);

            Version = interop.version;

        }

        internal unsafe static void ToInterop(PFEntityStatisticValue self, Interop.PFEntityStatisticValue* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Metadata != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Metadata, &interop->metadata, buffer);
            }

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            if (self.Scores != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Scores, &interop->scores, buffer);
                interop->scoresCount = (uint)self.Scores.Length;
            }

            interop->version = self.Version;

        }
            
    }

    /// <summary>
    /// PFProfilesEntityProfileBody data model.
    /// </summary>
    public struct PFProfilesEntityProfileBody
    {
        /// <summary>
        /// (Optional) Avatar URL for the entity.
        /// </summary>
        public string? AvatarUrl;

        /// <summary>
        /// The creation time of this profile in UTC.
        /// </summary>
        public long Created;

        /// <summary>
        /// (Optional) The display name of the entity. This field may serve different purposes for different
        /// entity types. i.e.: for a title player account it could represent the display name of the player,
        /// whereas on a character it could be character's name.
        /// </summary>
        public string? DisplayName;

        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The chain of responsibility for this entity. Use Lineage.
        /// </summary>
        public string? EntityChain;

        /// <summary>
        /// (Optional) The experiment variants of this profile.
        /// </summary>
        public string[]? ExperimentVariants;

        /// <summary>
        /// (Optional) The files on this profile.
        /// </summary>
        public Dictionary<string, PFProfilesEntityProfileFileMetadata>? Files;

        /// <summary>
        /// (Optional) The language on this profile.
        /// </summary>
        public string? Language;

        /// <summary>
        /// (Optional) The lineage of this profile.
        /// </summary>
        public PFEntityLineage? Lineage;

        /// <summary>
        /// (Optional) The objects on this profile.
        /// </summary>
        public Dictionary<string, PFProfilesEntityDataObject>? Objects;

        /// <summary>
        /// (Optional) The permissions that govern access to this entity profile and its properties. Only includes
        /// permissions set on this profile, not global statements from titles and namespaces.
        /// </summary>
        public PFProfilesEntityPermissionStatement[]? Permissions;

        /// <summary>
        /// (Optional) The statistics on this profile.
        /// </summary>
        public Dictionary<string, PFEntityStatisticValue>? Statistics;

        /// <summary>
        /// The version number of the profile in persistent storage at the time of the read. Used for optional
        /// optimistic concurrency during update.
        /// </summary>
        public int VersionNumber;

        internal unsafe PFProfilesEntityProfileBody(Interop.PFProfilesEntityProfileBody interop)
        {

            AvatarUrl = (interop.avatarUrl == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.avatarUrl);

            Created = interop.created;

            DisplayName = (interop.displayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.displayName);

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            EntityChain = (interop.entityChain == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.entityChain);

            ExperimentVariants = (interop.experimentVariants == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.experimentVariants, interop.experimentVariantsCount);

            Files = (interop.files == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.files, interop.filesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFProfilesEntityProfileFileMetadata(*pair.value)));

            Language = (interop.language == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.language);

            Lineage = (interop.lineage == null) ? null : new(*interop.lineage);

            Objects = (interop.objects == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.objects, interop.objectsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFProfilesEntityDataObject(*pair.value)));

            Permissions = (interop.permissions == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.permissions, interop.permissionsCount, elem => new PFProfilesEntityPermissionStatement(elem));

            Statistics = (interop.statistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.statistics, interop.statisticsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFEntityStatisticValue(*pair.value)));

            VersionNumber = interop.versionNumber;

        }

        internal unsafe static void ToInterop(PFProfilesEntityProfileBody self, Interop.PFProfilesEntityProfileBody* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AvatarUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AvatarUrl, &interop->avatarUrl, buffer);
            }

            interop->created = self.Created;

            if (self.DisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayName, &interop->displayName, buffer);
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            if (self.EntityChain != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EntityChain, &interop->entityChain, buffer);
            }

            if (self.ExperimentVariants != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.ExperimentVariants, &interop->experimentVariants, buffer);
                interop->experimentVariantsCount = (uint)self.ExperimentVariants.Length;
            }

            if (self.Files != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.Files, &interop->files, buffer, (KeyValuePair<string, PFProfilesEntityProfileFileMetadata> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFProfilesEntityProfileFileMetadata* valueBuf = (Interop.PFProfilesEntityProfileFileMetadata*)buffer.AddBuffer(sizeof(Interop.PFProfilesEntityProfileFileMetadata));
                    PFProfilesEntityProfileFileMetadata.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFProfilesEntityProfileFileMetadataDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->filesCount = (uint)self.Files.Count;
            }

            if (self.Language != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Language, &interop->language, buffer);
            }

            if (self.Lineage != null)
            {
                interop->lineage = (Interop.PFEntityLineage*)buffer.AddBuffer(sizeof(Interop.PFEntityLineage));
                PFEntityLineage.ToInterop(self.Lineage.Value, interop->lineage, buffer);
            }

            if (self.Objects != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.Objects, &interop->objects, buffer, (KeyValuePair<string, PFProfilesEntityDataObject> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFProfilesEntityDataObject* valueBuf = (Interop.PFProfilesEntityDataObject*)buffer.AddBuffer(sizeof(Interop.PFProfilesEntityDataObject));
                    PFProfilesEntityDataObject.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFProfilesEntityDataObjectDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->objectsCount = (uint)self.Objects.Count;
            }

            if (self.Permissions != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Permissions, &interop->permissions, buffer, PFProfilesEntityPermissionStatement.ToInterop);
                interop->permissionsCount = (uint)self.Permissions.Length;
            }

            if (self.Statistics != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.Statistics, &interop->statistics, buffer, (KeyValuePair<string, PFEntityStatisticValue> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFEntityStatisticValue* valueBuf = (Interop.PFEntityStatisticValue*)buffer.AddBuffer(sizeof(Interop.PFEntityStatisticValue));
                    PFEntityStatisticValue.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFEntityStatisticValueDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->statisticsCount = (uint)self.Statistics.Count;
            }

            interop->versionNumber = self.VersionNumber;

        }
            
    }

    /// <summary>
    /// PFProfilesGetEntityProfileResponse data model.
    /// </summary>
    public struct PFProfilesGetEntityProfileResponse
    {
        /// <summary>
        /// (Optional) Entity profile.
        /// </summary>
        public PFProfilesEntityProfileBody? Profile;

        internal unsafe PFProfilesGetEntityProfileResponse(Interop.PFProfilesGetEntityProfileResponse interop)
        {

            Profile = (interop.profile == null) ? null : new(*interop.profile);

        }
            
    }

    /// <summary>
    /// PFProfilesGetEntityProfilesRequest data model. Given a set of entity types and entity identifiers
    /// will retrieve all readable profiles properties for the caller. Profiles that the caller is not allowed
    /// to read will silently not be included in the results.
    /// </summary>
    public struct PFProfilesGetEntityProfilesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Determines whether the objects will be returned as an escaped JSON string or as a un-escaped
        /// JSON object. Default is JSON string.
        /// </summary>
        public bool? DataAsObject;

        /// <summary>
        /// Entity keys of the profiles to load. Must be between 1 and 25.
        /// </summary>
        public PFEntityKey[] Entities;

        internal unsafe static void ToInterop(PFProfilesGetEntityProfilesRequest self, Interop.PFProfilesGetEntityProfilesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.DataAsObject != null)
            {
                *interop->dataAsObject = InteropWrapper.WrapperHelpers.BoolToInterop(self.DataAsObject.Value);
            }

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Entities, &interop->entities, buffer, PFEntityKey.ToInterop);
            interop->entitiesCount = (uint)self.Entities.Length;

        }
            
    }

    /// <summary>
    /// PFProfilesGetEntityProfilesResponse data model.
    /// </summary>
    public struct PFProfilesGetEntityProfilesResponse
    {
        /// <summary>
        /// (Optional) Entity profiles.
        /// </summary>
        public PFProfilesEntityProfileBody[]? Profiles;

        internal unsafe PFProfilesGetEntityProfilesResponse(Interop.PFProfilesGetEntityProfilesResponse interop)
        {

            Profiles = (interop.profiles == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.profiles, interop.profilesCount, elem => new PFProfilesEntityProfileBody(elem));

        }
            
    }

    /// <summary>
    /// PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest data model. Given a master player account
    /// id (PlayFab ID), returns all title player accounts associated with it.
    /// </summary>
    public struct PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Master player account ids.
        /// </summary>
        public string[] MasterPlayerAccountIds;

        /// <summary>
        /// (Optional) Id of title to get players from.
        /// </summary>
        public string? TitleId;

        internal unsafe static void ToInterop(PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest self, Interop.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.MasterPlayerAccountIds, &interop->masterPlayerAccountIds, buffer);
            interop->masterPlayerAccountIdsCount = (uint)self.MasterPlayerAccountIds.Length;

            if (self.TitleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TitleId, &interop->titleId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse data model.
    /// </summary>
    public struct PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse
    {
        /// <summary>
        /// (Optional) Optional id of title to get players from, required if calling using a master_player_account.
        /// </summary>
        public string? TitleId;

        /// <summary>
        /// (Optional) Dictionary of master player ids mapped to title player entity keys and id pairs.
        /// </summary>
        public Dictionary<string, PFEntityKey>? TitlePlayerAccounts;

        internal unsafe PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse(Interop.PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse interop)
        {

            TitleId = (interop.titleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.titleId);

            TitlePlayerAccounts = (interop.titlePlayerAccounts == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.titlePlayerAccounts, interop.titlePlayerAccountsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFEntityKey(*pair.value)));

        }
            
    }

    /// <summary>
    /// PFProfilesSetProfileLanguageRequest data model. Given an entity profile, will update its language
    /// to the one passed in if the profile's version is equal to the one passed in.
    /// </summary>
    public struct PFProfilesSetProfileLanguageRequest
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
        /// (Optional) The expected version of a profile to perform this update on.
        /// </summary>
        public int? ExpectedVersion;

        /// <summary>
        /// (Optional) The language to set on the given entity. Deletes the profile's language if passed in a
        /// null string.
        /// </summary>
        public string? Language;

        internal unsafe static void ToInterop(PFProfilesSetProfileLanguageRequest self, Interop.PFProfilesSetProfileLanguageRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            if (self.ExpectedVersion != null)
            {
                *interop->expectedVersion = self.ExpectedVersion.Value;
            }

            if (self.Language != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Language, &interop->language, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFProfilesSetProfileLanguageResponse data model.
    /// </summary>
    public struct PFProfilesSetProfileLanguageResponse
    {
        /// <summary>
        /// (Optional) The type of operation that occured on the profile's language.
        /// </summary>
        public PFOperationTypes? OperationResult;

        /// <summary>
        /// (Optional) The updated version of the profile after the language update.
        /// </summary>
        public int? VersionNumber;

        internal unsafe PFProfilesSetProfileLanguageResponse(Interop.PFProfilesSetProfileLanguageResponse interop)
        {

            OperationResult = (interop.operationResult == null) ? null : (PFOperationTypes?)(*interop.operationResult);

            VersionNumber = (interop.versionNumber == null) ? null : *interop.versionNumber;

        }
            
    }

    /// <summary>
    /// PFProfilesSetEntityProfilePolicyRequest data model. This will set the access policy statements on
    /// the given entity profile. This is not additive, any existing statements will be replaced with the
    /// statements in this request.
    /// </summary>
    public struct PFProfilesSetEntityProfilePolicyRequest
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
        /// The statements to include in the access policy.
        /// </summary>
        public PFProfilesEntityPermissionStatement[] Statements;

        internal unsafe static void ToInterop(PFProfilesSetEntityProfilePolicyRequest self, Interop.PFProfilesSetEntityProfilePolicyRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Statements, &interop->statements, buffer, PFProfilesEntityPermissionStatement.ToInterop);
            interop->statementsCount = (uint)self.Statements.Length;

        }
            
    }

    /// <summary>
    /// PFProfilesSetEntityProfilePolicyResponse data model.
    /// </summary>
    public struct PFProfilesSetEntityProfilePolicyResponse
    {
        /// <summary>
        /// (Optional) The permissions that govern access to this entity profile and its properties. Only includes
        /// permissions set on this profile, not global statements from titles and namespaces.
        /// </summary>
        public PFProfilesEntityPermissionStatement[]? Permissions;

        internal unsafe PFProfilesSetEntityProfilePolicyResponse(Interop.PFProfilesSetEntityProfilePolicyResponse interop)
        {

            Permissions = (interop.permissions == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.permissions, interop.permissionsCount, elem => new PFProfilesEntityPermissionStatement(elem));

        }
            
    }

}
