// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFPlayerEntity
    {
        /// <summary>
        /// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list
        /// of the local user. At least one of FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName
        /// should be initialized.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFFriendsAddFriendResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientGetFriendsListAsync, ClientSetFriendTagsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFFriendsClientAddFriendGetResult"/> to get
        /// the result.
        /// </remarks>
        public Task<PFResult<PFFriendsAddFriendResult>> FriendsClientAddFriendAsync(
            PFFriendsClientAddFriendRequest request
        )
        {
            return InteropWrapper.Services.PFFriends.PFFriendsClientAddFriendAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts.
        /// Friends from linked accounts (Facebook, Steam) are also included. You may optionally exclude some
        /// linked services' friends.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFFriendsGetFriendsListResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientAddFriendAsync, ClientGetPlayerProfileAsync, ClientRemoveFriendAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFFriendsClientGetFriendsListGetResultSize"/>
        /// and <see cref="PFFriendsClientGetFriendsListGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFFriendsGetFriendsListResult>> FriendsClientGetFriendsListAsync(
            PFFriendsClientGetFriendsListRequest request
        )
        {
            return InteropWrapper.Services.PFFriends.PFFriendsClientGetFriendsListAsync(InteropHandle, request);
        }

        /// <summary>
        /// Removes a specified user from the friend list of the local user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also ClientAddFriendAsync, ClientSetFriendTagsAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public Task<PFResult> FriendsClientRemoveFriendAsync(
            PFFriendsClientRemoveFriendRequest request
        )
        {
            return InteropWrapper.Services.PFFriends.PFFriendsClientRemoveFriendAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of the local user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This operation is not additive. It will completely replace the tag list for the specified user. Please
        /// note that only users in the PlayFab friends list can be assigned tags. Attempting to set a tag on
        /// a friend only included in the friends list from a social site integration (such as Facebook or Steam)
        /// will return the AccountNotFound error. See also ClientAddFriendAsync, ClientRemoveFriendAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public Task<PFResult> FriendsClientSetFriendTagsAsync(
            PFFriendsClientSetFriendTagsRequest request
        )
        {
            return InteropWrapper.Services.PFFriends.PFFriendsClientSetFriendTagsAsync(InteropHandle, request);
        }
    }

    public partial class PFTitleEntity
    {
        /// <summary>
        /// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of FriendPlayFabId,FriendUsername,FriendEmail,
        /// or FriendTitleDisplayName should be initialized.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerGetFriendsListAsync, ServerRemoveFriendAsync, ServerSetFriendTagsAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_USERS_ALREADY_FRIENDS or any of the global PlayFab Service errors. See
        /// doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> FriendsServerAddFriendAsync(
            PFFriendsServerAddFriendRequest request
        )
        {
            return InteropWrapper.Services.PFFriends.PFFriendsServerAddFriendAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab
        /// accounts. Friends from linked accounts (Facebook, Steam) are also included. You may optionally exclude
        /// some linked services' friends.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFFriendsGetFriendsListResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerAddFriendAsync, ServerGetPlayerProfileAsync, ServerRemoveFriendAsync, ServerSetFriendTagsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFFriendsServerGetFriendsListGetResultSize"/>
        /// and <see cref="PFFriendsServerGetFriendsListGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFFriendsGetFriendsListResult>> FriendsServerGetFriendsListAsync(
            PFFriendsServerGetFriendsListRequest request
        )
        {
            return InteropWrapper.Services.PFFriends.PFFriendsServerGetFriendsListAsync(InteropHandle, request);
        }

        /// <summary>
        /// Removes the specified friend from the the user's friend list
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerAddFriendAsync, ServerSetFriendTagsAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_ACCOUNT_NOT_FOUND or any of the global PlayFab Service errors. See doc
        /// page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> FriendsServerRemoveFriendAsync(
            PFFriendsServerRemoveFriendRequest request
        )
        {
            return InteropWrapper.Services.PFFriends.PFFriendsServerRemoveFriendAsync(InteropHandle, request);
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of another user
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This operation is not additive. It will completely replace the tag list for the specified user. Please
        /// note that only users in the PlayFab friends list can be assigned tags. Attempting to set a tag on
        /// a friend only included in the friends list from a social site integration (such as Facebook or Steam)
        /// will return the AccountNotFound error. See also ServerAddFriendAsync, ServerGetFriendsListAsync, ServerRemoveFriendAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public Task<PFResult> FriendsServerSetFriendTagsAsync(
            PFFriendsServerSetFriendTagsRequest request
        )
        {
            return InteropWrapper.Services.PFFriends.PFFriendsServerSetFriendTagsAsync(InteropHandle, request);
        }
    }
}
