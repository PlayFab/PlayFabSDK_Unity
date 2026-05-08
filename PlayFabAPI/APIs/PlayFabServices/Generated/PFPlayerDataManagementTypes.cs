// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest data model. Deletes custom properties
    /// for the specified player. The list of provided property names must be non-empty.
    /// </summary>
    public struct PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Optional field used for concurrency control. One can ensure that the delete operation
        /// will only be performed if the player's properties have not been updated by any other clients since
        /// the last version.
        /// </summary>
        public int? ExpectedPropertiesVersion;

        /// <summary>
        /// A list of property names denoting which properties should be deleted.
        /// </summary>
        public string[] PropertyNames;

        internal unsafe static void ToInterop(PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest self, Interop.PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ExpectedPropertiesVersion != null)
            {
                interop->expectedPropertiesVersion = (int*)buffer.AddBuffer(sizeof(int));
                *interop->expectedPropertiesVersion = self.ExpectedPropertiesVersion.Value;
            }

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.PropertyNames, &interop->propertyNames, buffer);
            interop->propertyNamesCount = (uint)self.PropertyNames.Length;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementDeletedPropertyDetails data model.
    /// </summary>
    public struct PFPlayerDataManagementDeletedPropertyDetails
    {
        /// <summary>
        /// (Optional) The name of the property which was requested to be deleted.
        /// </summary>
        public string? Name;

        /// <summary>
        /// Indicates whether or not the property was deleted. If false, no property with that name existed.
        /// </summary>
        public bool WasDeleted;

        internal unsafe PFPlayerDataManagementDeletedPropertyDetails(Interop.PFPlayerDataManagementDeletedPropertyDetails interop)
        {

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            WasDeleted = InteropWrapper.WrapperHelpers.InteropToBool(interop.wasDeleted);

        }

        internal unsafe static void ToInterop(PFPlayerDataManagementDeletedPropertyDetails self, Interop.PFPlayerDataManagementDeletedPropertyDetails* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            interop->wasDeleted = InteropWrapper.WrapperHelpers.BoolToInterop(self.WasDeleted);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult data model.
    /// </summary>
    public struct PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult
    {
        /// <summary>
        /// (Optional) The list of properties requested to be deleted.
        /// </summary>
        public PFPlayerDataManagementDeletedPropertyDetails[]? DeletedProperties;

        /// <summary>
        /// Indicates the current version of a player's properties that have been set. This is incremented after
        /// updates and deletes. This version can be provided in update and delete calls for concurrency control.
        /// </summary>
        public int PropertiesVersion;

        internal unsafe PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult(Interop.PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult interop)
        {

            DeletedProperties = (interop.deletedProperties == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.deletedProperties, interop.deletedPropertiesCount, elem => new PFPlayerDataManagementDeletedPropertyDetails(elem));

            PropertiesVersion = interop.propertiesVersion;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementClientGetPlayerCustomPropertyRequest data model.
    /// </summary>
    public struct PFPlayerDataManagementClientGetPlayerCustomPropertyRequest
    {
        /// <summary>
        /// Specific property name to search for in the player's properties.
        /// </summary>
        public string PropertyName;

        internal unsafe static void ToInterop(PFPlayerDataManagementClientGetPlayerCustomPropertyRequest self, Interop.PFPlayerDataManagementClientGetPlayerCustomPropertyRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.PropertyName, &interop->propertyName, buffer);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementCustomPropertyDetails data model.
    /// </summary>
    public struct PFPlayerDataManagementCustomPropertyDetails
    {
        /// <summary>
        /// (Optional) The custom property's name.
        /// </summary>
        public string? Name;

        /// <summary>
        /// (Optional) The custom property's value.
        /// </summary>
        public PFJsonObject Value;

        internal unsafe PFPlayerDataManagementCustomPropertyDetails(Interop.PFPlayerDataManagementCustomPropertyDetails interop)
        {

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            Value = (interop.value.stringValue == null) ? default : new PFJsonObject(interop.value);

        }

        internal unsafe static void ToInterop(PFPlayerDataManagementCustomPropertyDetails self, Interop.PFPlayerDataManagementCustomPropertyDetails* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            if (self.Value.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Value.stringValue, &interop->value.stringValue, buffer);
            }

        }
    }

    /// <summary>
    /// PFPlayerDataManagementClientGetPlayerCustomPropertyResult data model.
    /// </summary>
    public struct PFPlayerDataManagementClientGetPlayerCustomPropertyResult
    {
        /// <summary>
        /// Indicates the current version of a player's properties that have been set. This is incremented after
        /// updates and deletes. This version can be provided in update and delete calls for concurrency control.
        /// </summary>
        public int PropertiesVersion;

        /// <summary>
        /// (Optional) Player specific property and its corresponding value.
        /// </summary>
        public PFPlayerDataManagementCustomPropertyDetails? Property;

        internal unsafe PFPlayerDataManagementClientGetPlayerCustomPropertyResult(Interop.PFPlayerDataManagementClientGetPlayerCustomPropertyResult interop)
        {

            PropertiesVersion = interop.propertiesVersion;

            Property = (interop.property == null) ? null : new(*interop.property);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementGetUserDataRequest data model. Data is stored as JSON key-value pairs. Every
    /// time the data is updated via any source, the version counter is incremented. If the Version parameter
    /// is provided, then this call will only return data if the current version on the system is greater
    /// than the value provided. If the Keys parameter is provided, the data object returned will only contain
    /// the data specific to the indicated Keys. Otherwise, the full set of custom user data will be returned.
    /// </summary>
    public struct PFPlayerDataManagementGetUserDataRequest
    {
        /// <summary>
        /// (Optional) The version that currently exists according to the caller. The call will return the data
        /// for all of the keys if the version in the system is greater than this.
        /// </summary>
        public uint? IfChangedFromDataVersion;

        /// <summary>
        /// (Optional) List of unique keys to load from.
        /// </summary>
        public string[]? Keys;

        /// <summary>
        /// (Optional) Unique PlayFab identifier of the user to load data for. Optional, defaults to yourself
        /// if not set. When specified to a PlayFab id of another player, then this will only return public keys
        /// for that account.
        /// </summary>
        public string? PlayFabId;

        internal unsafe static void ToInterop(PFPlayerDataManagementGetUserDataRequest self, Interop.PFPlayerDataManagementGetUserDataRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.IfChangedFromDataVersion != null)
            {
                interop->ifChangedFromDataVersion = (uint*)buffer.AddBuffer(sizeof(uint));
                *interop->ifChangedFromDataVersion = self.IfChangedFromDataVersion.Value;
            }

            if (self.Keys != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Keys, &interop->keys, buffer);
                interop->keysCount = (uint)self.Keys.Length;
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

        }
    }

    /// <summary>
    /// PFPlayerDataManagementClientGetUserDataResult data model.
    /// </summary>
    public struct PFPlayerDataManagementClientGetUserDataResult
    {
        /// <summary>
        /// (Optional) User specific data for this title.
        /// </summary>
        public Dictionary<string, PFUserDataRecord>? Data;

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call
        /// for that type of data (read-only, internal, etc). This version can be provided in Get calls to find
        /// updated data.
        /// </summary>
        public uint DataVersion;

        internal unsafe PFPlayerDataManagementClientGetUserDataResult(Interop.PFPlayerDataManagementClientGetUserDataResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.data, interop.dataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFUserDataRecord(*pair.value)));

            DataVersion = interop.dataVersion;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementClientListPlayerCustomPropertiesResult data model.
    /// </summary>
    public struct PFPlayerDataManagementClientListPlayerCustomPropertiesResult
    {
        /// <summary>
        /// (Optional) Player specific properties and their corresponding values for this title.
        /// </summary>
        public PFPlayerDataManagementCustomPropertyDetails[]? Properties;

        /// <summary>
        /// Indicates the current version of a player's properties that have been set. This is incremented after
        /// updates and deletes. This version can be provided in update and delete calls for concurrency control.
        /// </summary>
        public int PropertiesVersion;

        internal unsafe PFPlayerDataManagementClientListPlayerCustomPropertiesResult(Interop.PFPlayerDataManagementClientListPlayerCustomPropertiesResult interop)
        {

            Properties = (interop.properties == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.properties, interop.propertiesCount, elem => new PFPlayerDataManagementCustomPropertyDetails(elem));

            PropertiesVersion = interop.propertiesVersion;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementUpdateProperty data model.
    /// </summary>
    public struct PFPlayerDataManagementUpdateProperty
    {
        /// <summary>
        /// Name of the custom property. Can contain Unicode letters and digits. They are limited in size.
        /// </summary>
        public string Name;

        /// <summary>
        /// Value of the custom property. Limited to booleans, numbers, and strings.
        /// </summary>
        public PFJsonObject Value;

        internal unsafe PFPlayerDataManagementUpdateProperty(Interop.PFPlayerDataManagementUpdateProperty interop)
        {

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

            Value = new PFJsonObject(interop.value)!;

        }

        internal unsafe static void ToInterop(PFPlayerDataManagementUpdateProperty self, Interop.PFPlayerDataManagementUpdateProperty* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.Value.stringValue, &interop->value.stringValue, buffer);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest data model. Performs an additive
    /// update of the custom properties for the specified player. In updating the player's custom properties,
    /// properties which already exist will have their values overwritten. No other properties will be changed
    /// apart from those specified in the call.
    /// </summary>
    public struct PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Optional field used for concurrency control. One can ensure that the update operation
        /// will only be performed if the player's properties have not been updated by any other clients since
        /// last the version.
        /// </summary>
        public int? ExpectedPropertiesVersion;

        /// <summary>
        /// Collection of properties to be set for a player.
        /// </summary>
        public PFPlayerDataManagementUpdateProperty[] Properties;

        internal unsafe static void ToInterop(PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest self, Interop.PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ExpectedPropertiesVersion != null)
            {
                interop->expectedPropertiesVersion = (int*)buffer.AddBuffer(sizeof(int));
                *interop->expectedPropertiesVersion = self.ExpectedPropertiesVersion.Value;
            }

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Properties, &interop->properties, buffer, PFPlayerDataManagementUpdateProperty.ToInterop);
            interop->propertiesCount = (uint)self.Properties.Length;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult data model.
    /// </summary>
    public struct PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult
    {
        /// <summary>
        /// Indicates the current version of a player's properties that have been set. This is incremented after
        /// updates and deletes. This version can be provided in update and delete calls for concurrency control.
        /// </summary>
        public int PropertiesVersion;

        internal unsafe PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult(Interop.PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult interop)
        {

            PropertiesVersion = interop.propertiesVersion;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementClientUpdateUserDataRequest data model. This function performs an additive
    /// update of the arbitrary strings containing the custom data for the user. In updating the custom data
    /// object, keys which already exist in the object will have their values overwritten, while keys with
    /// null values will be removed. New keys will be added, with the given values. No other key-value pairs
    /// will be changed apart from those specified in the call.
    /// </summary>
    public struct PFPlayerDataManagementClientUpdateUserDataRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace,
        /// are limited in size, and may not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string, string>? Data;

        /// <summary>
        /// (Optional) Optional list of Data-keys to remove from UserData. Some SDKs cannot insert null-values
        /// into Data due to language constraints. Use this to delete the keys directly.
        /// </summary>
        public string[]? KeysToRemove;

        /// <summary>
        /// (Optional) Permission to be applied to all user data keys written in this request. Defaults to "private"
        /// if not set. This is used for requests by one player for information about another player; those requests
        /// will only return Public keys.
        /// </summary>
        public PFUserDataPermission? Permission;

        internal unsafe static void ToInterop(PFPlayerDataManagementClientUpdateUserDataRequest self, Interop.PFPlayerDataManagementClientUpdateUserDataRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Data != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.Data, &interop->data, buffer);
                interop->dataCount = (uint)self.Data.Count;
            }

            if (self.KeysToRemove != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.KeysToRemove, &interop->keysToRemove, buffer);
                interop->keysToRemoveCount = (uint)self.KeysToRemove.Length;
            }

            if (self.Permission != null)
            {
                interop->permission = (Interop.PFUserDataPermission*)buffer.AddBuffer(sizeof(Interop.PFUserDataPermission));
                *interop->permission = (Interop.PFUserDataPermission)self.Permission.Value;
            }

        }
    }

    /// <summary>
    /// PFPlayerDataManagementUpdateUserDataResult data model.
    /// </summary>
    public struct PFPlayerDataManagementUpdateUserDataResult
    {
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call
        /// for that type of data (read-only, internal, etc). This version can be provided in Get calls to find
        /// updated data.
        /// </summary>
        public uint DataVersion;

        internal unsafe PFPlayerDataManagementUpdateUserDataResult(Interop.PFPlayerDataManagementUpdateUserDataResult interop)
        {

            DataVersion = interop.dataVersion;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest data model. Deletes custom properties
    /// for the specified player. The list of provided property names must be non-empty.
    /// </summary>
    public struct PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Optional field used for concurrency control. One can ensure that the delete operation
        /// will only be performed if the player's properties have not been updated by any other clients since
        /// the last version.
        /// </summary>
        public int? ExpectedPropertiesVersion;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// A list of property names denoting which properties should be deleted.
        /// </summary>
        public string[] PropertyNames;

        internal unsafe static void ToInterop(PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest self, Interop.PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ExpectedPropertiesVersion != null)
            {
                interop->expectedPropertiesVersion = (int*)buffer.AddBuffer(sizeof(int));
                *interop->expectedPropertiesVersion = self.ExpectedPropertiesVersion.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.PropertyNames, &interop->propertyNames, buffer);
            interop->propertyNamesCount = (uint)self.PropertyNames.Length;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult data model.
    /// </summary>
    public struct PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult
    {
        /// <summary>
        /// (Optional) The list of properties requested to be deleted.
        /// </summary>
        public PFPlayerDataManagementDeletedPropertyDetails[]? DeletedProperties;

        /// <summary>
        /// (Optional) PlayFab unique identifier of the user whose properties were deleted.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// Indicates the current version of a player's properties that have been set. This is incremented after
        /// updates and deletes. This version can be provided in update and delete calls for concurrency control.
        /// </summary>
        public int PropertiesVersion;

        internal unsafe PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult(Interop.PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult interop)
        {

            DeletedProperties = (interop.deletedProperties == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.deletedProperties, interop.deletedPropertiesCount, elem => new PFPlayerDataManagementDeletedPropertyDetails(elem));

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            PropertiesVersion = interop.propertiesVersion;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerGetPlayerCustomPropertyRequest data model.
    /// </summary>
    public struct PFPlayerDataManagementServerGetPlayerCustomPropertyRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Specific property name to search for in the player's properties.
        /// </summary>
        public string PropertyName;

        internal unsafe static void ToInterop(PFPlayerDataManagementServerGetPlayerCustomPropertyRequest self, Interop.PFPlayerDataManagementServerGetPlayerCustomPropertyRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.PropertyName, &interop->propertyName, buffer);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerGetPlayerCustomPropertyResult data model.
    /// </summary>
    public struct PFPlayerDataManagementServerGetPlayerCustomPropertyResult
    {
        /// <summary>
        /// (Optional) PlayFab unique identifier of the user whose properties are being returned.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// Indicates the current version of a player's properties that have been set. This is incremented after
        /// updates and deletes. This version can be provided in update and delete calls for concurrency control.
        /// </summary>
        public int PropertiesVersion;

        /// <summary>
        /// (Optional) Player specific property and its corresponding value.
        /// </summary>
        public PFPlayerDataManagementCustomPropertyDetails? Property;

        internal unsafe PFPlayerDataManagementServerGetPlayerCustomPropertyResult(Interop.PFPlayerDataManagementServerGetPlayerCustomPropertyResult interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            PropertiesVersion = interop.propertiesVersion;

            Property = (interop.property == null) ? null : new(*interop.property);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerGetUserDataResult data model.
    /// </summary>
    public struct PFPlayerDataManagementServerGetUserDataResult
    {
        /// <summary>
        /// (Optional) User specific data for this title.
        /// </summary>
        public Dictionary<string, PFUserDataRecord>? Data;

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call
        /// for that type of data (read-only, internal, etc). This version can be provided in Get calls to find
        /// updated data.
        /// </summary>
        public uint DataVersion;

        /// <summary>
        /// (Optional) PlayFab unique identifier of the user whose custom data is being returned.
        /// </summary>
        public string? PlayFabId;

        internal unsafe PFPlayerDataManagementServerGetUserDataResult(Interop.PFPlayerDataManagementServerGetUserDataResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.data, interop.dataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFUserDataRecord(*pair.value)));

            DataVersion = interop.dataVersion;

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementListPlayerCustomPropertiesRequest data model.
    /// </summary>
    public struct PFPlayerDataManagementListPlayerCustomPropertiesRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFPlayerDataManagementListPlayerCustomPropertiesRequest self, Interop.PFPlayerDataManagementListPlayerCustomPropertiesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerListPlayerCustomPropertiesResult data model.
    /// </summary>
    public struct PFPlayerDataManagementServerListPlayerCustomPropertiesResult
    {
        /// <summary>
        /// (Optional) PlayFab unique identifier of the user whose properties are being returned.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Player specific properties and their corresponding values for this title.
        /// </summary>
        public PFPlayerDataManagementCustomPropertyDetails[]? Properties;

        /// <summary>
        /// Indicates the current version of a player's properties that have been set. This is incremented after
        /// updates and deletes. This version can be provided in update and delete calls for concurrency control.
        /// </summary>
        public int PropertiesVersion;

        internal unsafe PFPlayerDataManagementServerListPlayerCustomPropertiesResult(Interop.PFPlayerDataManagementServerListPlayerCustomPropertiesResult interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            Properties = (interop.properties == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.properties, interop.propertiesCount, elem => new PFPlayerDataManagementCustomPropertyDetails(elem));

            PropertiesVersion = interop.propertiesVersion;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest data model. Performs an additive
    /// update of the custom properties for the specified player. In updating the player's custom properties,
    /// properties which already exist will have their values overwritten. No other properties will be changed
    /// apart from those specified in the call.
    /// </summary>
    public struct PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Optional field used for concurrency control. One can ensure that the update operation
        /// will only be performed if the player's properties have not been updated by any other clients since
        /// last the version.
        /// </summary>
        public int? ExpectedPropertiesVersion;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Collection of properties to be set for a player.
        /// </summary>
        public PFPlayerDataManagementUpdateProperty[] Properties;

        internal unsafe static void ToInterop(PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest self, Interop.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ExpectedPropertiesVersion != null)
            {
                interop->expectedPropertiesVersion = (int*)buffer.AddBuffer(sizeof(int));
                *interop->expectedPropertiesVersion = self.ExpectedPropertiesVersion.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Properties, &interop->properties, buffer, PFPlayerDataManagementUpdateProperty.ToInterop);
            interop->propertiesCount = (uint)self.Properties.Length;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult data model.
    /// </summary>
    public struct PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult
    {
        /// <summary>
        /// (Optional) PlayFab unique identifier of the user whose properties were updated.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// Indicates the current version of a player's properties that have been set. This is incremented after
        /// updates and deletes. This version can be provided in update and delete calls for concurrency control.
        /// </summary>
        public int PropertiesVersion;

        internal unsafe PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult(Interop.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult interop)
        {

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            PropertiesVersion = interop.propertiesVersion;

        }
    }

    /// <summary>
    /// PFPlayerDataManagementServerUpdateUserDataRequest data model. This function performs an additive
    /// update of the arbitrary JSON object containing the custom data for the user. In updating the custom
    /// data object, keys which already exist in the object will have their values overwritten, while keys
    /// with null values will be removed. No other key-value pairs will be changed apart from those specified
    /// in the call.
    /// </summary>
    public struct PFPlayerDataManagementServerUpdateUserDataRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace,
        /// are limited in size, and may not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string, string>? Data;

        /// <summary>
        /// (Optional) Optional list of Data-keys to remove from UserData. Some SDKs cannot insert null-values
        /// into Data due to language constraints. Use this to delete the keys directly.
        /// </summary>
        public string[]? KeysToRemove;

        /// <summary>
        /// (Optional) Permission to be applied to all user data keys written in this request. Defaults to "private"
        /// if not set.
        /// </summary>
        public PFUserDataPermission? Permission;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFPlayerDataManagementServerUpdateUserDataRequest self, Interop.PFPlayerDataManagementServerUpdateUserDataRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Data != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.Data, &interop->data, buffer);
                interop->dataCount = (uint)self.Data.Count;
            }

            if (self.KeysToRemove != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.KeysToRemove, &interop->keysToRemove, buffer);
                interop->keysToRemoveCount = (uint)self.KeysToRemove.Length;
            }

            if (self.Permission != null)
            {
                interop->permission = (Interop.PFUserDataPermission*)buffer.AddBuffer(sizeof(Interop.PFUserDataPermission));
                *interop->permission = (Interop.PFUserDataPermission)self.Permission.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFPlayerDataManagementUpdateUserInternalDataRequest data model. This function performs an additive
    /// update of the arbitrary JSON object containing the custom data for the user. In updating the custom
    /// data object, keys which already exist in the object will have their values overwritten, keys with
    /// null values will be removed. No other key-value pairs will be changed apart from those specified in
    /// the call.
    /// </summary>
    public struct PFPlayerDataManagementUpdateUserInternalDataRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace,
        /// are limited in size, and may not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string, string>? Data;

        /// <summary>
        /// (Optional) Optional list of Data-keys to remove from UserData. Some SDKs cannot insert null-values
        /// into Data due to language constraints. Use this to delete the keys directly.
        /// </summary>
        public string[]? KeysToRemove;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFPlayerDataManagementUpdateUserInternalDataRequest self, Interop.PFPlayerDataManagementUpdateUserInternalDataRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Data != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.Data, &interop->data, buffer);
                interop->dataCount = (uint)self.Data.Count;
            }

            if (self.KeysToRemove != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.KeysToRemove, &interop->keysToRemove, buffer);
                interop->keysToRemoveCount = (uint)self.KeysToRemove.Length;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

}
