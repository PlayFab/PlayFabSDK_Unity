// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFTitleEntity
    {
        /// <summary>
        /// Lists details of all build aliases for a title. Accepts tokens for title and if game client access
        /// is enabled, allows game client to request list of builds with player entity token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFMultiplayerServerListBuildAliasesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns a list of summarized details of all multiplayer server builds for a title. See also MultiplayerServerCreateBuildWithManagedContainerAsync,
        /// MultiplayerServerDeleteBuildAsync, MultiplayerServerGetBuildAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFMultiplayerServerListBuildAliasesGetResultSize"/>
        /// and <see cref="PFMultiplayerServerListBuildAliasesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFMultiplayerServerListBuildAliasesResponse>> MultiplayerServerListBuildAliasesAsync(
            PFMultiplayerServerListBuildAliasesRequest request
        )
        {
            return InteropWrapper.Services.PFMultiplayerServer.PFMultiplayerServerListBuildAliasesAsync(InteropHandle, request);
        }

        /// <summary>
        /// Lists summarized details of all multiplayer server builds for a title. Accepts tokens for title and
        /// if game client access is enabled, allows game client to request list of builds with player entity
        /// token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFMultiplayerServerListBuildSummariesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns a list of summarized details of all multiplayer server builds for a title. See also MultiplayerServerCreateBuildWithManagedContainerAsync,
        /// MultiplayerServerDeleteBuildAsync, MultiplayerServerGetBuildAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFMultiplayerServerListBuildSummariesV2GetResultSize"/>
        /// and <see cref="PFMultiplayerServerListBuildSummariesV2GetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFMultiplayerServerListBuildSummariesResponse>> MultiplayerServerListBuildSummariesV2Async(
            PFMultiplayerServerListBuildSummariesRequest request
        )
        {
            return InteropWrapper.Services.PFMultiplayerServer.PFMultiplayerServerListBuildSummariesV2Async(InteropHandle, request);
        }

        /// <summary>
        /// Lists quality of service servers for the title. By default, servers are only returned for regions
        /// where a Multiplayer Servers build has been deployed.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFMultiplayerServerListQosServersForTitleResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns a list of quality of service servers for a title.
        ///
        /// When the asynchronous task is complete, call <see cref="PFMultiplayerServerListQosServersForTitleGetResultSize"/>
        /// and <see cref="PFMultiplayerServerListQosServersForTitleGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFMultiplayerServerListQosServersForTitleResponse>> MultiplayerServerListQosServersForTitleAsync(
            PFMultiplayerServerListQosServersForTitleRequest request
        )
        {
            return InteropWrapper.Services.PFMultiplayerServer.PFMultiplayerServerListQosServersForTitleAsync(InteropHandle, request);
        }

        /// <summary>
        /// Request a multiplayer server session. Accepts tokens for title and if game client access is enabled,
        /// allows game client to request a server with player entity token.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFMultiplayerServerRequestMultiplayerServerResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Requests a multiplayer server session from a particular build in any of the given preferred regions.
        /// See also MultiplayerServerGetMultiplayerServerDetailsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFMultiplayerServerRequestMultiplayerServerGetResultSize"/>
        /// and <see cref="PFMultiplayerServerRequestMultiplayerServerGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFMultiplayerServerRequestMultiplayerServerResponse>> MultiplayerServerRequestMultiplayerServerAsync(
            PFMultiplayerServerRequestMultiplayerServerRequest request
        )
        {
            return InteropWrapper.Services.PFMultiplayerServer.PFMultiplayerServerRequestMultiplayerServerAsync(InteropHandle, request);
        }
    }
}
