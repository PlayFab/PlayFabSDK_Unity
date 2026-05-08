// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
        /// <summary>
        /// Abort pending file uploads to an entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataAbortFileUploadsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Aborts the pending upload of the requested files. See also FileDeleteFilesAsync, FileFinalizeFileUploadsAsync,
        /// FileGetFilesAsync, FileInitiateFileUploadsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataAbortFileUploadsGetResultSize"/> and
        /// <see cref="PFDataAbortFileUploadsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFDataAbortFileUploadsResponse>> DataAbortFileUploadsAsync(
            PFDataAbortFileUploadsRequest request
        )
        {
            return InteropWrapper.Services.PFData.PFDataAbortFileUploadsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Delete files on an entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataDeleteFilesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Deletes the requested files from the entity's profile. See also FileAbortFileUploadsAsync, FileFinalizeFileUploadsAsync,
        /// FileGetFilesAsync, FileInitiateFileUploadsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataDeleteFilesGetResultSize"/> and <see
        /// cref="PFDataDeleteFilesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFDataDeleteFilesResponse>> DataDeleteFilesAsync(
            PFDataDeleteFilesRequest request
        )
        {
            return InteropWrapper.Services.PFData.PFDataDeleteFilesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Finalize file uploads to an entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataFinalizeFileUploadsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Finalizes the upload of the requested files. Verifies that the files have been successfully uploaded
        /// and moves the file pointers from pending to live. See also FileAbortFileUploadsAsync, FileDeleteFilesAsync,
        /// FileGetFilesAsync, FileInitiateFileUploadsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataFinalizeFileUploadsGetResultSize"/>
        /// and <see cref="PFDataFinalizeFileUploadsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFDataFinalizeFileUploadsResponse>> DataFinalizeFileUploadsAsync(
            PFDataFinalizeFileUploadsRequest request
        )
        {
            return InteropWrapper.Services.PFData.PFDataFinalizeFileUploadsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves file metadata from an entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataGetFilesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns URLs that may be used to download the files for a profile for a limited length of time. Only
        /// returns files that have been successfully uploaded, files that are still pending will either return
        /// the old value, if it exists, or nothing. See also FileAbortFileUploadsAsync, FileDeleteFilesAsync,
        /// FileFinalizeFileUploadsAsync, FileInitiateFileUploadsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataGetFilesGetResultSize"/> and <see cref="PFDataGetFilesGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFDataGetFilesResponse>> DataGetFilesAsync(
            PFDataGetFilesRequest request
        )
        {
            return InteropWrapper.Services.PFData.PFDataGetFilesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves objects from an entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataGetObjectsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Gets JSON objects from an entity profile and returns it.  See also ObjectSetObjectsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataGetObjectsGetResultSize"/> and <see
        /// cref="PFDataGetObjectsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFDataGetObjectsResponse>> DataGetObjectsAsync(
            PFDataGetObjectsRequest request
        )
        {
            return InteropWrapper.Services.PFData.PFDataGetObjectsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Initiates file uploads to an entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataInitiateFileUploadsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns URLs that may be used to upload the files for a profile 5 minutes. After using the upload
        /// calls FinalizeFileUploads must be called to move the file status from pending to live. See also FileAbortFileUploadsAsync,
        /// FileDeleteFilesAsync, FileFinalizeFileUploadsAsync, FileGetFilesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataInitiateFileUploadsGetResultSize"/>
        /// and <see cref="PFDataInitiateFileUploadsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFDataInitiateFileUploadsResponse>> DataInitiateFileUploadsAsync(
            PFDataInitiateFileUploadsRequest request
        )
        {
            return InteropWrapper.Services.PFData.PFDataInitiateFileUploadsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Sets objects on an entity's profile.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFDataSetObjectsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Sets JSON objects on the requested entity profile. May include a version number to be used to perform
        /// optimistic concurrency operations during update. If the current version differs from the version in
        /// the request the request will be ignored. If no version is set on the request then the value will always
        /// be updated if the values differ. Using the version value does not guarantee a write though, ConcurrentEditError
        /// may still occur if multiple clients are attempting to update the same profile.  See also ObjectGetObjectsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFDataSetObjectsGetResultSize"/> and <see
        /// cref="PFDataSetObjectsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFDataSetObjectsResponse>> DataSetObjectsAsync(
            PFDataSetObjectsRequest request
        )
        {
            return InteropWrapper.Services.PFData.PFDataSetObjectsAsync(InteropHandle, request);
        }
    }
}
