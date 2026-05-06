// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFPlayerEntity
    {
        /// <summary>
        /// Deletes title-specific custom properties for a player
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Deletes custom properties for the specified player. The list of provided property names must be non-empty.
        /// See also ClientGetPlayerCustomPropertyAsync, ClientListPlayerCustomPropertiesAsync, ClientUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientDeletePlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientDeletePlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult>> PlayerDataManagementClientDeletePlayerCustomPropertiesAsync(
            PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientDeletePlayerCustomPropertiesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves a title-specific custom property value for a player.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetPlayerCustomPropertyResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientDeletePlayerCustomPropertiesAsync, ClientListPlayerCustomPropertiesAsync, ClientUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetPlayerCustomPropertyGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetPlayerCustomPropertyGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementClientGetPlayerCustomPropertyResult>> PlayerDataManagementClientGetPlayerCustomPropertyAsync(
            PFPlayerDataManagementClientGetPlayerCustomPropertyRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientGetPlayerCustomPropertyAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Data is stored as JSON key-value pairs. Every time the data is updated via any source, the version
        /// counter is incremented. If the Version parameter is provided, then this call will only return data
        /// if the current version on the system is greater than the value provided. If the Keys parameter is
        /// provided, the data object returned will only contain the data specific to the indicated Keys. Otherwise,
        /// the full set of custom user data will be returned. See also ClientGetUserReadOnlyDataAsync, ClientUpdateUserDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetUserDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetUserDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementClientGetUserDataResult>> PlayerDataManagementClientGetUserDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientGetUserDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ClientGetUserPublisherReadOnlyDataAsync, ClientUpdateUserPublisherDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetUserPublisherDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetUserPublisherDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementClientGetUserDataResult>> PlayerDataManagementClientGetUserPublisherDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientGetUserPublisherDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ClientGetUserPublisherDataAsync, ClientUpdateUserPublisherDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetUserPublisherReadOnlyDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetUserPublisherReadOnlyDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementClientGetUserDataResult>> PlayerDataManagementClientGetUserPublisherReadOnlyDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientGetUserPublisherReadOnlyDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Data is stored as JSON key-value pairs. Every time the data is updated via any source, the version
        /// counter is incremented. If the Version parameter is provided, then this call will only return data
        /// if the current version on the system is greater than the value provided. If the Keys parameter is
        /// provided, the data object returned will only contain the data specific to the indicated Keys. Otherwise,
        /// the full set of custom user data will be returned. See also ClientGetUserDataAsync, ClientUpdateUserDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientGetUserReadOnlyDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientGetUserReadOnlyDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementClientGetUserDataResult>> PlayerDataManagementClientGetUserReadOnlyDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientGetUserReadOnlyDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves title-specific custom property values for a player.
        /// </summary>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientListPlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientDeletePlayerCustomPropertiesAsync, ClientGetPlayerCustomPropertyAsync, ClientUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientListPlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementClientListPlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementClientListPlayerCustomPropertiesResult>> PlayerDataManagementClientListPlayerCustomPropertiesAsync(
            
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientListPlayerCustomPropertiesAsync(InteropHandle);
        }

        /// <summary>
        /// Updates the title-specific custom property values for a player
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Performs an additive update of the custom properties for the specified player. In updating the player's
        /// custom properties, properties which already exist will have their values overwritten. No other properties
        /// will be changed apart from those specified in the call. See also ClientDeletePlayerCustomPropertiesAsync,
        /// ClientGetPlayerCustomPropertyAsync, ClientListPlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientUpdatePlayerCustomPropertiesGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementClientUpdatePlayerCustomPropertiesResult>> PlayerDataManagementClientUpdatePlayerCustomPropertiesAsync(
            PFPlayerDataManagementClientUpdatePlayerCustomPropertiesRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientUpdatePlayerCustomPropertiesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user which is readable and writable by
        /// the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This function performs an additive update of the arbitrary strings containing the custom data for
        /// the user. In updating the custom data object, keys which already exist in the object will have their
        /// values overwritten, while keys with null values will be removed. New keys will be added, with the
        /// given values. No other key-value pairs will be changed apart from those specified in the call. See
        /// also ClientGetUserDataAsync, ClientGetUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientUpdateUserDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PlayerDataManagementClientUpdateUserDataAsync(
            PFPlayerDataManagementClientUpdateUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientUpdateUserDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Creates and updates the publisher-specific custom data for the user which is readable and writable
        /// by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This function performs an additive update of the arbitrary strings containing the custom data for
        /// the user. In updating the custom data object, keys which already exist in the object will have their
        /// values overwritten, while keys with null values will be removed. New keys will be added, with the
        /// given values. No other key-value pairs will be changed apart from those specified in the call. See
        /// also ClientGetUserPublisherDataAsync, ClientGetUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementClientUpdateUserPublisherDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PlayerDataManagementClientUpdateUserPublisherDataAsync(
            PFPlayerDataManagementClientUpdateUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementClientUpdateUserPublisherDataAsync(InteropHandle, request);
        }
    }

    public partial class PFTitleEntity
    {
        /// <summary>
        /// Deletes title-specific custom properties for a player
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Deletes custom properties for the specified player. The list of provided property names must be non-empty.
        /// See also ServerGetPlayerCustomPropertyAsync, ServerListPlayerCustomPropertiesAsync, ServerUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerDeletePlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerDeletePlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult>> PlayerDataManagementServerDeletePlayerCustomPropertiesAsync(
            PFPlayerDataManagementServerDeletePlayerCustomPropertiesRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerDeletePlayerCustomPropertiesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves a title-specific custom property value for a player.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetPlayerCustomPropertyResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ServerDeletePlayerCustomPropertiesAsync, ServerListPlayerCustomPropertiesAsync, ServerUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetPlayerCustomPropertyGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetPlayerCustomPropertyGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerGetPlayerCustomPropertyResult>> PlayerDataManagementServerGetPlayerCustomPropertyAsync(
            PFPlayerDataManagementServerGetPlayerCustomPropertyRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerGetPlayerCustomPropertyAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserInternalDataAsync, ServerGetUserReadOnlyDataAsync, ServerUpdateUserDataAsync,
        /// ServerUpdateUserInternalDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PlayerDataManagementServerGetUserDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerGetUserDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserDataAsync, ServerGetUserReadOnlyDataAsync, ServerUpdateUserDataAsync,
        /// ServerUpdateUserInternalDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserInternalDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserInternalDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PlayerDataManagementServerGetUserInternalDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerGetUserInternalDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserPublisherInternalDataAsync, ServerGetUserPublisherReadOnlyDataAsync,
        /// ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherInternalDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserPublisherDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserPublisherDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PlayerDataManagementServerGetUserPublisherDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerGetUserPublisherDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherReadOnlyDataAsync,
        /// ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherInternalDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserPublisherInternalDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserPublisherInternalDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PlayerDataManagementServerGetUserPublisherInternalDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerGetUserPublisherInternalDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherInternalDataAsync,
        /// ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherInternalDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserPublisherReadOnlyDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserPublisherReadOnlyDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PlayerDataManagementServerGetUserPublisherReadOnlyDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerGetUserPublisherReadOnlyDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerGetUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned
        /// will only contain the data specific to the indicated Keys. Otherwise, the full set of custom user
        /// data will be returned. See also ServerGetUserDataAsync, ServerGetUserInternalDataAsync, ServerUpdateUserDataAsync,
        /// ServerUpdateUserInternalDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerGetUserReadOnlyDataGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerGetUserReadOnlyDataGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerGetUserDataResult>> PlayerDataManagementServerGetUserReadOnlyDataAsync(
            PFPlayerDataManagementGetUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerGetUserReadOnlyDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves title-specific custom property values for a player.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerListPlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also ServerDeletePlayerCustomPropertiesAsync, ServerGetPlayerCustomPropertyAsync, ServerUpdatePlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerListPlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerListPlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerListPlayerCustomPropertiesResult>> PlayerDataManagementServerListPlayerCustomPropertiesAsync(
            PFPlayerDataManagementListPlayerCustomPropertiesRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerListPlayerCustomPropertiesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the title-specific custom property values for a player
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Performs an additive update of the custom properties for the specified player. In updating the player's
        /// custom properties, properties which already exist will have their values overwritten. No other properties
        /// will be changed apart from those specified in the call. See also ServerDeletePlayerCustomPropertiesAsync,
        /// ServerGetPlayerCustomPropertyAsync, ServerListPlayerCustomPropertiesAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdatePlayerCustomPropertiesGetResultSize"/>
        /// and <see cref="PFPlayerDataManagementServerUpdatePlayerCustomPropertiesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult>> PlayerDataManagementServerUpdatePlayerCustomPropertiesAsync(
            PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerUpdatePlayerCustomPropertiesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, while keys with null values will be removed. No other key-value pairs will
        /// be changed apart from those specified in the call. See also ServerGetUserDataAsync, ServerGetUserInternalDataAsync,
        /// ServerGetUserReadOnlyDataAsync, ServerUpdateUserInternalDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PlayerDataManagementServerUpdateUserDataAsync(
            PFPlayerDataManagementServerUpdateUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerUpdateUserDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, keys with null values will be removed. No other key-value pairs will be
        /// changed apart from those specified in the call. See also ServerGetUserDataAsync, ServerGetUserInternalDataAsync,
        /// ServerGetUserReadOnlyDataAsync, ServerUpdateUserDataAsync, ServerUpdateUserReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserInternalDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PlayerDataManagementServerUpdateUserInternalDataAsync(
            PFPlayerDataManagementUpdateUserInternalDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerUpdateUserInternalDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, while keys with null values will be removed. No other key-value pairs will
        /// be changed apart from those specified in the call. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherInternalDataAsync,
        /// ServerGetUserPublisherReadOnlyDataAsync, ServerUpdateUserPublisherInternalDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserPublisherDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PlayerDataManagementServerUpdateUserPublisherDataAsync(
            PFPlayerDataManagementServerUpdateUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerUpdateUserPublisherDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, keys with null values will be removed. No other key-value pairs will be
        /// changed apart from those specified in the call. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherInternalDataAsync,
        /// ServerGetUserPublisherReadOnlyDataAsync, ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherReadOnlyDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserPublisherInternalDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PlayerDataManagementServerUpdateUserPublisherInternalDataAsync(
            PFPlayerDataManagementUpdateUserInternalDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerUpdateUserPublisherInternalDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, keys with null values will be removed. No other key-value pairs will be
        /// changed apart from those specified in the call. See also ServerGetUserPublisherDataAsync, ServerGetUserPublisherInternalDataAsync,
        /// ServerGetUserPublisherReadOnlyDataAsync, ServerUpdateUserPublisherDataAsync, ServerUpdateUserPublisherInternalDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserPublisherReadOnlyDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PlayerDataManagementServerUpdateUserPublisherReadOnlyDataAsync(
            PFPlayerDataManagementServerUpdateUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerUpdateUserPublisherReadOnlyDataAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFPlayerDataManagementUpdateUserDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This function performs an additive update of the arbitrary JSON object containing the custom data
        /// for the user. In updating the custom data object, keys which already exist in the object will have
        /// their values overwritten, keys with null values will be removed. No other key-value pairs will be
        /// changed apart from those specified in the call. See also ServerGetUserDataAsync, ServerGetUserInternalDataAsync,
        /// ServerGetUserReadOnlyDataAsync, ServerUpdateUserDataAsync, ServerUpdateUserInternalDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFPlayerDataManagementServerUpdateUserReadOnlyDataGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFPlayerDataManagementUpdateUserDataResult>> PlayerDataManagementServerUpdateUserReadOnlyDataAsync(
            PFPlayerDataManagementServerUpdateUserDataRequest request
        )
        {
            return InteropWrapper.Services.PFPlayerDataManagement.PFPlayerDataManagementServerUpdateUserReadOnlyDataAsync(InteropHandle, request);
        }
    }
}
