// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution
        /// of any kind of custom server-side functionality you can implement, and it can be used in conjunction
        /// with virtually anything.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCloudScriptExecuteCloudScriptResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Executes CloudScript with the entity profile that is defined in the request.
        ///
        /// When the asynchronous task is complete, call <see cref="PFCloudScriptExecuteEntityCloudScriptGetResultSize"/>
        /// and <see cref="PFCloudScriptExecuteEntityCloudScriptGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCloudScriptExecuteCloudScriptResult>> CloudScriptExecuteEntityCloudScriptAsync(
            PFCloudScriptExecuteEntityCloudScriptRequest request
        )
        {
            return await InteropWrapper.Services.PFCloudScript.PFCloudScriptExecuteEntityCloudScriptAsync(InteropHandle, request);
        }

        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution
        /// of any kind of custom server-side functionality you can implement, and it can be used in conjunction
        /// with virtually anything.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCloudScriptExecuteFunctionResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Executes an Azure Function with the profile of the entity that is defined in the request. See also
        /// CloudScriptRegisterHttpFunctionAsync, CloudScriptRegisterQueuedFunctionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFCloudScriptExecuteFunctionGetResultSize"/>
        /// and <see cref="PFCloudScriptExecuteFunctionGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCloudScriptExecuteFunctionResult>> CloudScriptExecuteFunctionAsync(
            PFCloudScriptExecuteFunctionRequest request
        )
        {
            return await InteropWrapper.Services.PFCloudScript.PFCloudScriptExecuteFunctionAsync(InteropHandle, request);
        }
    }

    public partial class PFPlayerEntity
    {
        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated
        /// player. The PlayFab ID is the entity ID of the player's master_player_account entity.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCloudScriptExecuteCloudScriptResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCloudScriptClientExecuteCloudScriptGetResultSize"/>
        /// and <see cref="PFCloudScriptClientExecuteCloudScriptGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCloudScriptExecuteCloudScriptResult>> CloudScriptClientExecuteCloudScriptAsync(
            PFCloudScriptExecuteCloudScriptRequest request
        )
        {
            return await InteropWrapper.Services.PFCloudScript.PFCloudScriptClientExecuteCloudScriptAsync(InteropHandle, request);
        }
    }

    public partial class PFTitleEntity
    {
        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated
        /// player. The PlayFab ID is the entity ID of the player's master_player_account entity.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCloudScriptExecuteCloudScriptResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFCloudScriptServerExecuteCloudScriptGetResultSize"/>
        /// and <see cref="PFCloudScriptServerExecuteCloudScriptGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCloudScriptExecuteCloudScriptResult>> CloudScriptServerExecuteCloudScriptAsync(
            PFCloudScriptExecuteCloudScriptServerRequest request
        )
        {
            return await InteropWrapper.Services.PFCloudScript.PFCloudScriptServerExecuteCloudScriptAsync(InteropHandle, request);
        }
    }
}
