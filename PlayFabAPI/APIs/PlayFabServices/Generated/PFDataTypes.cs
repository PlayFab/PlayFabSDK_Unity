// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFDataAbortFileUploadsRequest data model. Aborts the pending upload of the requested files.
    /// </summary>
    public struct PFDataAbortFileUploadsRequest
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
        /// Names of the files to have their pending uploads aborted.
        /// </summary>
        public string[] FileNames;

        /// <summary>
        /// (Optional) The expected version of the profile, if set and doesn't match the current version of the
        /// profile the operation will not be performed.
        /// </summary>
        public int? ProfileVersion;

        internal unsafe static void ToInterop(PFDataAbortFileUploadsRequest self, Interop.PFDataAbortFileUploadsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.FileNames, &interop->fileNames, buffer);
            interop->fileNamesCount = (uint)self.FileNames.Length;

            if (self.ProfileVersion != null)
            {
                *interop->profileVersion = self.ProfileVersion.Value;
            }

        }
            
    }

    /// <summary>
    /// PFDataAbortFileUploadsResponse data model.
    /// </summary>
    public struct PFDataAbortFileUploadsResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        internal unsafe PFDataAbortFileUploadsResponse(Interop.PFDataAbortFileUploadsResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            ProfileVersion = interop.profileVersion;

        }
            
    }

    /// <summary>
    /// PFDataDeleteFilesRequest data model. Deletes the requested files from the entity's profile.
    /// </summary>
    public struct PFDataDeleteFilesRequest
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
        /// Names of the files to be deleted.
        /// </summary>
        public string[] FileNames;

        /// <summary>
        /// (Optional) The expected version of the profile, if set and doesn't match the current version of the
        /// profile the operation will not be performed.
        /// </summary>
        public int? ProfileVersion;

        internal unsafe static void ToInterop(PFDataDeleteFilesRequest self, Interop.PFDataDeleteFilesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.FileNames, &interop->fileNames, buffer);
            interop->fileNamesCount = (uint)self.FileNames.Length;

            if (self.ProfileVersion != null)
            {
                *interop->profileVersion = self.ProfileVersion.Value;
            }

        }
            
    }

    /// <summary>
    /// PFDataDeleteFilesResponse data model.
    /// </summary>
    public struct PFDataDeleteFilesResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        internal unsafe PFDataDeleteFilesResponse(Interop.PFDataDeleteFilesResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            ProfileVersion = interop.profileVersion;

        }
            
    }

    /// <summary>
    /// PFDataFinalizeFileUploadsRequest data model. Finalizes the upload of the requested files. Verifies
    /// that the files have been successfully uploaded and moves the file pointers from pending to live.
    /// </summary>
    public struct PFDataFinalizeFileUploadsRequest
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
        /// Names of the files to be finalized. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'.
        /// </summary>
        public string[] FileNames;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        internal unsafe static void ToInterop(PFDataFinalizeFileUploadsRequest self, Interop.PFDataFinalizeFileUploadsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.FileNames, &interop->fileNames, buffer);
            interop->fileNamesCount = (uint)self.FileNames.Length;

            interop->profileVersion = self.ProfileVersion;

        }
            
    }

    /// <summary>
    /// PFDataGetFileMetadata data model.
    /// </summary>
    public struct PFDataGetFileMetadata
    {
        /// <summary>
        /// (Optional) Checksum value for the file, can be used to check if the file on the server has changed.
        /// </summary>
        public string? Checksum;

        /// <summary>
        /// (Optional) Download URL where the file can be retrieved.
        /// </summary>
        public string? DownloadUrl;

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

        internal unsafe PFDataGetFileMetadata(Interop.PFDataGetFileMetadata interop)
        {

            Checksum = (interop.checksum == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.checksum);

            DownloadUrl = (interop.downloadUrl == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.downloadUrl);

            FileName = (interop.fileName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.fileName);

            LastModified = interop.lastModified;

            Size = interop.size;

        }

        internal unsafe static void ToInterop(PFDataGetFileMetadata self, Interop.PFDataGetFileMetadata* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Checksum != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Checksum, &interop->checksum, buffer);
            }

            if (self.DownloadUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DownloadUrl, &interop->downloadUrl, buffer);
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
    /// PFDataFinalizeFileUploadsResponse data model.
    /// </summary>
    public struct PFDataFinalizeFileUploadsResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) Collection of metadata for the entity's files.
        /// </summary>
        public Dictionary<string, PFDataGetFileMetadata>? Metadata;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        internal unsafe PFDataFinalizeFileUploadsResponse(Interop.PFDataFinalizeFileUploadsResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            Metadata = (interop.metadata == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.metadata, interop.metadataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFDataGetFileMetadata(*pair.value)));

            ProfileVersion = interop.profileVersion;

        }
            
    }

    /// <summary>
    /// PFDataGetFilesRequest data model. Returns URLs that may be used to download the files for a profile
    /// for a limited length of time. Only returns files that have been successfully uploaded, files that
    /// are still pending will either return the old value, if it exists, or nothing.
    /// </summary>
    public struct PFDataGetFilesRequest
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

        internal unsafe static void ToInterop(PFDataGetFilesRequest self, Interop.PFDataGetFilesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

        }
            
    }

    /// <summary>
    /// PFDataGetFilesResponse data model.
    /// </summary>
    public struct PFDataGetFilesResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) Collection of metadata for the entity's files.
        /// </summary>
        public Dictionary<string, PFDataGetFileMetadata>? Metadata;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        internal unsafe PFDataGetFilesResponse(Interop.PFDataGetFilesResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            Metadata = (interop.metadata == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.metadata, interop.metadataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFDataGetFileMetadata(*pair.value)));

            ProfileVersion = interop.profileVersion;

        }
            
    }

    /// <summary>
    /// PFDataGetObjectsRequest data model. Gets JSON objects from an entity profile and returns it. .
    /// </summary>
    public struct PFDataGetObjectsRequest
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
        /// (Optional) Determines whether the object will be returned as an escaped JSON string or as a un-escaped
        /// JSON object. Default is JSON object.
        /// </summary>
        public bool? EscapeObject;

        internal unsafe static void ToInterop(PFDataGetObjectsRequest self, Interop.PFDataGetObjectsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            if (self.EscapeObject != null)
            {
                *interop->escapeObject = InteropWrapper.WrapperHelpers.BoolToInterop(self.EscapeObject.Value);
            }

        }
            
    }

    /// <summary>
    /// PFDataObjectResult data model.
    /// </summary>
    public struct PFDataObjectResult
    {
        /// <summary>
        /// (Optional) Un-escaped JSON object, if EscapeObject false or default.
        /// </summary>
        public PFJsonObject DataObject;

        /// <summary>
        /// (Optional) Escaped string JSON body of the object, if EscapeObject is true.
        /// </summary>
        public string? EscapedDataObject;

        /// <summary>
        /// (Optional) Name of the object. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'.
        /// </summary>
        public string? ObjectName;

        internal unsafe PFDataObjectResult(Interop.PFDataObjectResult interop)
        {

            DataObject = (interop.dataObject.stringValue == null) ? default : new PFJsonObject(interop.dataObject);

            EscapedDataObject = (interop.escapedDataObject == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.escapedDataObject);

            ObjectName = (interop.objectName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.objectName);

        }

        internal unsafe static void ToInterop(PFDataObjectResult self, Interop.PFDataObjectResult* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFDataGetObjectsResponse data model.
    /// </summary>
    public struct PFDataGetObjectsResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) Requested objects that the calling entity has access to.
        /// </summary>
        public Dictionary<string, PFDataObjectResult>? Objects;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        internal unsafe PFDataGetObjectsResponse(Interop.PFDataGetObjectsResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            Objects = (interop.objects == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.objects, interop.objectsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFDataObjectResult(*pair.value)));

            ProfileVersion = interop.profileVersion;

        }
            
    }

    /// <summary>
    /// PFDataInitiateFileUploadsRequest data model. Returns URLs that may be used to upload the files for
    /// a profile 5 minutes. After using the upload calls FinalizeFileUploads must be called to move the file
    /// status from pending to live.
    /// </summary>
    public struct PFDataInitiateFileUploadsRequest
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
        /// Names of the files to be set. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'.
        /// </summary>
        public string[] FileNames;

        /// <summary>
        /// (Optional) The expected version of the profile, if set and doesn't match the current version of the
        /// profile the operation will not be performed.
        /// </summary>
        public int? ProfileVersion;

        internal unsafe static void ToInterop(PFDataInitiateFileUploadsRequest self, Interop.PFDataInitiateFileUploadsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.FileNames, &interop->fileNames, buffer);
            interop->fileNamesCount = (uint)self.FileNames.Length;

            if (self.ProfileVersion != null)
            {
                *interop->profileVersion = self.ProfileVersion.Value;
            }

        }
            
    }

    /// <summary>
    /// PFDataInitiateFileUploadMetadata data model.
    /// </summary>
    public struct PFDataInitiateFileUploadMetadata
    {
        /// <summary>
        /// (Optional) Name of the file.
        /// </summary>
        public string? FileName;

        /// <summary>
        /// (Optional) Location the data should be sent to via an HTTP PUT operation.
        /// </summary>
        public string? UploadUrl;

        internal unsafe PFDataInitiateFileUploadMetadata(Interop.PFDataInitiateFileUploadMetadata interop)
        {

            FileName = (interop.fileName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.fileName);

            UploadUrl = (interop.uploadUrl == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.uploadUrl);

        }

        internal unsafe static void ToInterop(PFDataInitiateFileUploadMetadata self, Interop.PFDataInitiateFileUploadMetadata* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FileName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FileName, &interop->fileName, buffer);
            }

            if (self.UploadUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.UploadUrl, &interop->uploadUrl, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFDataInitiateFileUploadsResponse data model.
    /// </summary>
    public struct PFDataInitiateFileUploadsResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;

        /// <summary>
        /// (Optional) Collection of file names and upload urls.
        /// </summary>
        public PFDataInitiateFileUploadMetadata[]? UploadDetails;

        internal unsafe PFDataInitiateFileUploadsResponse(Interop.PFDataInitiateFileUploadsResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            ProfileVersion = interop.profileVersion;

            UploadDetails = (interop.uploadDetails == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.uploadDetails, interop.uploadDetailsCount, elem => new PFDataInitiateFileUploadMetadata(elem));

        }
            
    }

    /// <summary>
    /// PFDataSetObject data model.
    /// </summary>
    public struct PFDataSetObject
    {
        /// <summary>
        /// (Optional) Body of the object to be saved. If empty and DeleteObject is true object will be deleted
        /// if it exists, or no operation will occur if it does not exist. Only one of Object or EscapedDataObject
        /// fields may be used.
        /// </summary>
        public PFJsonObject DataObject;

        /// <summary>
        /// (Optional) Flag to indicate that this object should be deleted. Both DataObject and EscapedDataObject
        /// must not be set as well.
        /// </summary>
        public bool? DeleteObject;

        /// <summary>
        /// (Optional) Body of the object to be saved as an escaped JSON string. If empty and DeleteObject is
        /// true object will be deleted if it exists, or no operation will occur if it does not exist. Only one
        /// of DataObject or EscapedDataObject fields may be used.
        /// </summary>
        public string? EscapedDataObject;

        /// <summary>
        /// Name of object. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'.
        /// </summary>
        public string ObjectName;

        internal unsafe PFDataSetObject(Interop.PFDataSetObject interop)
        {

            DataObject = (interop.dataObject.stringValue == null) ? default : new PFJsonObject(interop.dataObject);

            DeleteObject = (interop.deleteObject == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.deleteObject);

            EscapedDataObject = (interop.escapedDataObject == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.escapedDataObject);

            ObjectName = InteropWrapper.WrapperHelpers.InteropToString(interop.objectName)!;

        }

        internal unsafe static void ToInterop(PFDataSetObject self, Interop.PFDataSetObject* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.DataObject.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DataObject.stringValue, &interop->dataObject.stringValue, buffer);
            }

            if (self.DeleteObject != null)
            {
                *interop->deleteObject = InteropWrapper.WrapperHelpers.BoolToInterop(self.DeleteObject.Value);
            }

            if (self.EscapedDataObject != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EscapedDataObject, &interop->escapedDataObject, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.ObjectName, &interop->objectName, buffer);

        }
            
    }

    /// <summary>
    /// PFDataSetObjectsRequest data model. Sets JSON objects on the requested entity profile. May include
    /// a version number to be used to perform optimistic concurrency operations during update. If the current
    /// version differs from the version in the request the request will be ignored. If no version is set
    /// on the request then the value will always be updated if the values differ. Using the version value
    /// does not guarantee a write though, ConcurrentEditError may still occur if multiple clients are attempting
    /// to update the same profile. .
    /// </summary>
    public struct PFDataSetObjectsRequest
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
        /// (Optional) Optional field used for concurrency control. By specifying the previously returned value
        /// of ProfileVersion from GetProfile API, you can ensure that the object set will only be performed if
        /// the profile has not been updated by any other clients since the version you last loaded.
        /// </summary>
        public int? ExpectedProfileVersion;

        /// <summary>
        /// Collection of objects to set on the profile.
        /// </summary>
        public PFDataSetObject[] Objects;

        internal unsafe static void ToInterop(PFDataSetObjectsRequest self, Interop.PFDataSetObjectsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
            PFEntityKey.ToInterop(self.Entity, interop->entity, buffer);

            if (self.ExpectedProfileVersion != null)
            {
                *interop->expectedProfileVersion = self.ExpectedProfileVersion.Value;
            }

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Objects, &interop->objects, buffer, PFDataSetObject.ToInterop);
            interop->objectsCount = (uint)self.Objects.Length;

        }
            
    }

    /// <summary>
    /// PFDataSetObjectInfo data model.
    /// </summary>
    public struct PFDataSetObjectInfo
    {
        /// <summary>
        /// (Optional) Name of the object.
        /// </summary>
        public string? ObjectName;

        /// <summary>
        /// (Optional) Optional reason to explain why the operation was the result that it was.
        /// </summary>
        public string? OperationReason;

        /// <summary>
        /// (Optional) Indicates which operation was completed, either Created, Updated, Deleted or None.
        /// </summary>
        public PFOperationTypes? SetResult;

        internal unsafe PFDataSetObjectInfo(Interop.PFDataSetObjectInfo interop)
        {

            ObjectName = (interop.objectName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.objectName);

            OperationReason = (interop.operationReason == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationReason);

            SetResult = (interop.setResult == null) ? null : (PFOperationTypes?)(*interop.setResult);

        }

        internal unsafe static void ToInterop(PFDataSetObjectInfo self, Interop.PFDataSetObjectInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ObjectName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ObjectName, &interop->objectName, buffer);
            }

            if (self.OperationReason != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OperationReason, &interop->operationReason, buffer);
            }

            if (self.SetResult != null)
            {
                *interop->setResult = (Interop.PFOperationTypes)self.SetResult.Value;
            }

        }
            
    }

    /// <summary>
    /// PFDataSetObjectsResponse data model.
    /// </summary>
    public struct PFDataSetObjectsResponse
    {
        /// <summary>
        /// New version of the entity profile.
        /// </summary>
        public int ProfileVersion;

        /// <summary>
        /// (Optional) New version of the entity profile.
        /// </summary>
        public PFDataSetObjectInfo[]? SetResults;

        internal unsafe PFDataSetObjectsResponse(Interop.PFDataSetObjectsResponse interop)
        {

            ProfileVersion = interop.profileVersion;

            SetResults = (interop.setResults == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.setResults, interop.setResultsCount, elem => new PFDataSetObjectInfo(elem));

        }
            
    }

}
