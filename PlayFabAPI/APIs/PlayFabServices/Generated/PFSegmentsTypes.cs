// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// ChurnRiskLevel enum.
    /// </summary>
    public enum PFSegmentsChurnRiskLevel : uint
    {
        NoData = Interop.PFSegmentsChurnRiskLevel.NoData,
        LowRisk = Interop.PFSegmentsChurnRiskLevel.LowRisk,
        MediumRisk = Interop.PFSegmentsChurnRiskLevel.MediumRisk,
        HighRisk = Interop.PFSegmentsChurnRiskLevel.HighRisk
    }

    /// <summary>
    /// PFSegmentsGetSegmentResult data model.
    /// </summary>
    public struct PFSegmentsGetSegmentResult
    {
        /// <summary>
        /// (Optional) Identifier of the segments AB Test, if it is attached to one.
        /// </summary>
        public string? ABTestParent;

        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string Id;

        /// <summary>
        /// (Optional) Segment name.
        /// </summary>
        public string? Name;

        internal unsafe PFSegmentsGetSegmentResult(Interop.PFSegmentsGetSegmentResult interop)
        {

            ABTestParent = (interop.aBTestParent == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.aBTestParent);

            Id = InteropWrapper.WrapperHelpers.InteropToString(interop.id)!;

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

        }

        internal unsafe static void ToInterop(PFSegmentsGetSegmentResult self, Interop.PFSegmentsGetSegmentResult* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ABTestParent != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ABTestParent, &interop->aBTestParent, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFSegmentsGetPlayerSegmentsResult data model.
    /// </summary>
    public struct PFSegmentsGetPlayerSegmentsResult
    {
        /// <summary>
        /// (Optional) Array of segments the requested player currently belongs to.
        /// </summary>
        public PFSegmentsGetSegmentResult[]? Segments;

        internal unsafe PFSegmentsGetPlayerSegmentsResult(Interop.PFSegmentsGetPlayerSegmentsResult interop)
        {

            Segments = (interop.segments == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.segments, interop.segmentsCount, elem => new PFSegmentsGetSegmentResult(elem));

        }
            
    }

    /// <summary>
    /// PFSegmentsGetPlayerTagsRequest data model. This API will return a list of canonical tags which includes
    /// both namespace and tag's name. If namespace is not provided, the result is a list of all canonical
    /// tags. TagName can be used for segmentation and Namespace is limited to 128 characters.
    /// </summary>
    public struct PFSegmentsGetPlayerTagsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Optional namespace to filter results by.
        /// </summary>
        public string? playfabNamespace;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFSegmentsGetPlayerTagsRequest self, Interop.PFSegmentsGetPlayerTagsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.playfabNamespace != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.playfabNamespace, &interop->playfabNamespace, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
            
    }

    /// <summary>
    /// PFSegmentsGetPlayerTagsResult data model.
    /// </summary>
    public struct PFSegmentsGetPlayerTagsResult
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Canonical tags (including namespace and tag's name) for the requested user.
        /// </summary>
        public string[] Tags;

        internal unsafe PFSegmentsGetPlayerTagsResult(Interop.PFSegmentsGetPlayerTagsResult interop)
        {

            PlayFabId = InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId)!;

            Tags = InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount)!;

        }
            
    }

    /// <summary>
    /// PFSegmentsAddPlayerTagRequest data model. This API will trigger a player_tag_added event and add
    /// a tag with the given TagName and PlayFabID to the corresponding player profile. TagName can be used
    /// for segmentation and it is limited to 256 characters. Also there is a limit on the number of tags
    /// a title can have.
    /// </summary>
    public struct PFSegmentsAddPlayerTagRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName;

        internal unsafe static void ToInterop(PFSegmentsAddPlayerTagRequest self, Interop.PFSegmentsAddPlayerTagRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.TagName, &interop->tagName, buffer);

        }
            
    }

    /// <summary>
    /// PFSegmentsGetAllSegmentsResult data model.
    /// </summary>
    public struct PFSegmentsGetAllSegmentsResult
    {
        /// <summary>
        /// (Optional) Array of segments for this title.
        /// </summary>
        public PFSegmentsGetSegmentResult[]? Segments;

        internal unsafe PFSegmentsGetAllSegmentsResult(Interop.PFSegmentsGetAllSegmentsResult interop)
        {

            Segments = (interop.segments == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.segments, interop.segmentsCount, elem => new PFSegmentsGetSegmentResult(elem));

        }
            
    }

    /// <summary>
    /// PFSegmentsGetPlayersSegmentsRequest data model.
    /// </summary>
    public struct PFSegmentsGetPlayersSegmentsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFSegmentsGetPlayersSegmentsRequest self, Interop.PFSegmentsGetPlayersSegmentsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
            
    }

    /// <summary>
    /// PFSegmentsGetPlayersInSegmentRequest data model. Initial request must contain at least a Segment
    /// ID. Subsequent requests must contain the Segment ID as well as the Continuation Token. Failure to
    /// send the Continuation Token will result in a new player segment list being generated. Each time the
    /// Continuation Token is passed in the length of the Total Seconds to Live is refreshed. If too much
    /// time passes between requests to the point that a subsequent request is past the Total Seconds to Live
    /// an error will be returned and paging will be terminated. This API is resource intensive and should
    /// not be used in scenarios which might generate high request volumes. Only one request to this API at
    /// a time should be made per title. Concurrent requests to the API may be rejected with the APIConcurrentRequestLimitExceeded
    /// error.
    /// </summary>
    public struct PFSegmentsGetPlayersInSegmentRequest
    {
        /// <summary>
        /// (Optional) Continuation token if retrieving subsequent pages of results.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) If set to true, the profiles are loaded asynchronously and the response will include a
        /// continuation token and approximate profile count until the first batch of profiles is loaded. Use
        /// this parameter to help avoid network timeouts.
        /// </summary>
        public bool? GetProfilesAsync;

        /// <summary>
        /// (Optional) Maximum is 10,000. The value 0 will prevent loading any profiles and return only the count
        /// of profiles matching this segment.
        /// </summary>
        public uint? MaxBatchSize;

        /// <summary>
        /// (Optional) Number of seconds to keep the continuation token active. After token expiration it is
        /// not possible to continue paging results. Default is 300 (5 minutes). Maximum is 5,400 (90 minutes).
        /// </summary>
        public uint? SecondsToLive;

        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string SegmentId;

        internal unsafe static void ToInterop(PFSegmentsGetPlayersInSegmentRequest self, Interop.PFSegmentsGetPlayersInSegmentRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ContinuationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ContinuationToken, &interop->continuationToken, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.GetProfilesAsync != null)
            {
                *interop->getProfilesAsync = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetProfilesAsync.Value);
            }

            if (self.MaxBatchSize != null)
            {
                *interop->maxBatchSize = self.MaxBatchSize.Value;
            }

            if (self.SecondsToLive != null)
            {
                *interop->secondsToLive = self.SecondsToLive.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.SegmentId, &interop->segmentId, buffer);

        }
            
    }

    /// <summary>
    /// PFSegmentsAdCampaignAttribution data model.
    /// </summary>
    public struct PFSegmentsAdCampaignAttribution
    {
        /// <summary>
        /// UTC time stamp of attribution.
        /// </summary>
        public long AttributedAt;

        /// <summary>
        /// (Optional) Attribution campaign identifier.
        /// </summary>
        public string? CampaignId;

        /// <summary>
        /// (Optional) Attribution network name.
        /// </summary>
        public string? Platform;

        internal unsafe PFSegmentsAdCampaignAttribution(Interop.PFSegmentsAdCampaignAttribution interop)
        {

            AttributedAt = interop.attributedAt;

            CampaignId = (interop.campaignId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.campaignId);

            Platform = (interop.platform == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.platform);

        }

        internal unsafe static void ToInterop(PFSegmentsAdCampaignAttribution self, Interop.PFSegmentsAdCampaignAttribution* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->attributedAt = self.AttributedAt;

            if (self.CampaignId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CampaignId, &interop->campaignId, buffer);
            }

            if (self.Platform != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Platform, &interop->platform, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFSegmentsContactEmailInfo data model.
    /// </summary>
    public struct PFSegmentsContactEmailInfo
    {
        /// <summary>
        /// (Optional) The email address.
        /// </summary>
        public string? EmailAddress;

        /// <summary>
        /// (Optional) The name of the email info data.
        /// </summary>
        public string? Name;

        /// <summary>
        /// (Optional) The verification status of the email.
        /// </summary>
        public PFEmailVerificationStatus? VerificationStatus;

        internal unsafe PFSegmentsContactEmailInfo(Interop.PFSegmentsContactEmailInfo interop)
        {

            EmailAddress = (interop.emailAddress == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.emailAddress);

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            VerificationStatus = (interop.verificationStatus == null) ? null : (PFEmailVerificationStatus?)(*interop.verificationStatus);

        }

        internal unsafe static void ToInterop(PFSegmentsContactEmailInfo self, Interop.PFSegmentsContactEmailInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.EmailAddress != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EmailAddress, &interop->emailAddress, buffer);
            }

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            if (self.VerificationStatus != null)
            {
                *interop->verificationStatus = (Interop.PFEmailVerificationStatus)self.VerificationStatus.Value;
            }

        }
            
    }

    /// <summary>
    /// PFSegmentsPlayerLinkedAccount data model.
    /// </summary>
    public struct PFSegmentsPlayerLinkedAccount
    {
        /// <summary>
        /// (Optional) Linked account's email.
        /// </summary>
        public string? Email;

        /// <summary>
        /// (Optional) Authentication platform.
        /// </summary>
        public PFLoginIdentityProvider? Platform;

        /// <summary>
        /// (Optional) Platform user identifier.
        /// </summary>
        public string? PlatformUserId;

        /// <summary>
        /// (Optional) Linked account's username.
        /// </summary>
        public string? Username;

        internal unsafe PFSegmentsPlayerLinkedAccount(Interop.PFSegmentsPlayerLinkedAccount interop)
        {

            Email = (interop.email == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.email);

            Platform = (interop.platform == null) ? null : (PFLoginIdentityProvider?)(*interop.platform);

            PlatformUserId = (interop.platformUserId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.platformUserId);

            Username = (interop.username == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.username);

        }

        internal unsafe static void ToInterop(PFSegmentsPlayerLinkedAccount self, Interop.PFSegmentsPlayerLinkedAccount* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Email != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Email, &interop->email, buffer);
            }

            if (self.Platform != null)
            {
                *interop->platform = (Interop.PFLoginIdentityProvider)self.Platform.Value;
            }

            if (self.PlatformUserId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlatformUserId, &interop->platformUserId, buffer);
            }

            if (self.Username != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Username, &interop->username, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFSegmentsPlayerLocation data model.
    /// </summary>
    public struct PFSegmentsPlayerLocation
    {
        /// <summary>
        /// (Optional) City of the player's geographic location.
        /// </summary>
        public string? City;

        /// <summary>
        /// The two-character continent code for this location.
        /// </summary>
        public PFContinentCode ContinentCode;

        /// <summary>
        /// The two-character ISO 3166-1 country code for the country associated with the location.
        /// </summary>
        public PFCountryCode CountryCode;

        /// <summary>
        /// (Optional) Latitude coordinate of the player's geographic location.
        /// </summary>
        public double? Latitude;

        /// <summary>
        /// (Optional) Longitude coordinate of the player's geographic location.
        /// </summary>
        public double? Longitude;

        internal unsafe PFSegmentsPlayerLocation(Interop.PFSegmentsPlayerLocation interop)
        {

            City = (interop.city == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.city);

            ContinentCode = (PFContinentCode)(interop.continentCode);

            CountryCode = (PFCountryCode)(interop.countryCode);

            Latitude = (interop.latitude == null) ? null : *interop.latitude;

            Longitude = (interop.longitude == null) ? null : *interop.longitude;

        }

        internal unsafe static void ToInterop(PFSegmentsPlayerLocation self, Interop.PFSegmentsPlayerLocation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.City != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.City, &interop->city, buffer);
            }

            interop->continentCode = (Interop.PFContinentCode)self.ContinentCode;

            interop->countryCode = (Interop.PFCountryCode)self.CountryCode;

            if (self.Latitude != null)
            {
                *interop->latitude = self.Latitude.Value;
            }

            if (self.Longitude != null)
            {
                *interop->longitude = self.Longitude.Value;
            }

        }
            
    }

    /// <summary>
    /// PFSegmentsPlayerStatistic data model.
    /// </summary>
    public struct PFSegmentsPlayerStatistic
    {
        /// <summary>
        /// (Optional) Statistic ID.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) Statistic name.
        /// </summary>
        public string? Name;

        /// <summary>
        /// Current statistic value.
        /// </summary>
        public int StatisticValue;

        /// <summary>
        /// Statistic version (0 if not a versioned statistic).
        /// </summary>
        public int StatisticVersion;

        internal unsafe PFSegmentsPlayerStatistic(Interop.PFSegmentsPlayerStatistic interop)
        {

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            StatisticValue = interop.statisticValue;

            StatisticVersion = interop.statisticVersion;

        }

        internal unsafe static void ToInterop(PFSegmentsPlayerStatistic self, Interop.PFSegmentsPlayerStatistic* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            interop->statisticValue = self.StatisticValue;

            interop->statisticVersion = self.StatisticVersion;

        }
            
    }

    /// <summary>
    /// PFSegmentsPushNotificationRegistration data model.
    /// </summary>
    public struct PFSegmentsPushNotificationRegistration
    {
        /// <summary>
        /// (Optional) Notification configured endpoint.
        /// </summary>
        public string? NotificationEndpointARN;

        /// <summary>
        /// (Optional) Push notification platform.
        /// </summary>
        public PFPushNotificationPlatform? Platform;

        internal unsafe PFSegmentsPushNotificationRegistration(Interop.PFSegmentsPushNotificationRegistration interop)
        {

            NotificationEndpointARN = (interop.notificationEndpointARN == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.notificationEndpointARN);

            Platform = (interop.platform == null) ? null : (PFPushNotificationPlatform?)(*interop.platform);

        }

        internal unsafe static void ToInterop(PFSegmentsPushNotificationRegistration self, Interop.PFSegmentsPushNotificationRegistration* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.NotificationEndpointARN != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NotificationEndpointARN, &interop->notificationEndpointARN, buffer);
            }

            if (self.Platform != null)
            {
                *interop->platform = (Interop.PFPushNotificationPlatform)self.Platform.Value;
            }

        }
            
    }

    /// <summary>
    /// PFSegmentsPlayerProfile data model.
    /// </summary>
    public struct PFSegmentsPlayerProfile
    {
        /// <summary>
        /// (Optional) Array of ad campaigns player has been attributed to.
        /// </summary>
        public PFSegmentsAdCampaignAttribution[]? AdCampaignAttributions;

        /// <summary>
        /// (Optional) Image URL of the player's avatar.
        /// </summary>
        public string? AvatarUrl;

        /// <summary>
        /// (Optional) Banned until UTC Date. If permanent ban this is set for 20 years after the original ban
        /// date.
        /// </summary>
        public long? BannedUntil;

        /// <summary>
        /// (Optional) The prediction of the player to churn within the next seven days.
        /// </summary>
        public PFSegmentsChurnRiskLevel? ChurnPrediction;

        /// <summary>
        /// (Optional) Array of contact email addresses associated with the player.
        /// </summary>
        public PFSegmentsContactEmailInfo[]? ContactEmailAddresses;

        /// <summary>
        /// (Optional) Player record created.
        /// </summary>
        public long? Created;

        /// <summary>
        /// (Optional) Dictionary of player's custom properties.
        /// </summary>
        public PFJsonObject CustomProperties;

        /// <summary>
        /// (Optional) Player Display Name.
        /// </summary>
        public string? DisplayName;

        /// <summary>
        /// (Optional) Last login.
        /// </summary>
        public long? LastLogin;

        /// <summary>
        /// (Optional) Array of third party accounts linked to this player.
        /// </summary>
        public PFSegmentsPlayerLinkedAccount[]? LinkedAccounts;

        /// <summary>
        /// (Optional) Dictionary of player's locations by type.
        /// </summary>
        public Dictionary<string, PFSegmentsPlayerLocation>? Locations;

        /// <summary>
        /// (Optional) Player account origination.
        /// </summary>
        public PFLoginIdentityProvider? Origination;

        /// <summary>
        /// (Optional) List of player variants for experimentation.
        /// </summary>
        public string[]? PlayerExperimentVariants;

        /// <summary>
        /// (Optional) PlayFab Player ID.
        /// </summary>
        public string? PlayerId;

        /// <summary>
        /// (Optional) Array of player statistics.
        /// </summary>
        public PFSegmentsPlayerStatistic[]? PlayerStatistics;

        /// <summary>
        /// (Optional) Publisher this player belongs to.
        /// </summary>
        public string? PublisherId;

        /// <summary>
        /// (Optional) Array of configured push notification end points.
        /// </summary>
        public PFSegmentsPushNotificationRegistration[]? PushNotificationRegistrations;

        /// <summary>
        /// (Optional) Dictionary of player's statistics using only the latest version's value.
        /// </summary>
        public Dictionary<string, int>? Statistics;

        /// <summary>
        /// (Optional) List of player's tags for segmentation.
        /// </summary>
        public string[]? Tags;

        /// <summary>
        /// (Optional) Title ID this profile applies to.
        /// </summary>
        public string? TitleId;

        /// <summary>
        /// (Optional) A sum of player's total purchases in USD across all currencies.
        /// </summary>
        public uint? TotalValueToDateInUSD;

        /// <summary>
        /// (Optional) Dictionary of player's total purchases by currency.
        /// </summary>
        public Dictionary<string, uint>? ValuesToDate;

        /// <summary>
        /// (Optional) Dictionary of player's virtual currency balances.
        /// </summary>
        public Dictionary<string, int>? VirtualCurrencyBalances;

        internal unsafe PFSegmentsPlayerProfile(Interop.PFSegmentsPlayerProfile interop)
        {

            AdCampaignAttributions = (interop.adCampaignAttributions == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.adCampaignAttributions, interop.adCampaignAttributionsCount, elem => new PFSegmentsAdCampaignAttribution(elem));

            AvatarUrl = (interop.avatarUrl == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.avatarUrl);

            BannedUntil = (interop.bannedUntil == null) ? null : *interop.bannedUntil;

            ChurnPrediction = (interop.churnPrediction == null) ? null : (PFSegmentsChurnRiskLevel?)(*interop.churnPrediction);

            ContactEmailAddresses = (interop.contactEmailAddresses == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.contactEmailAddresses, interop.contactEmailAddressesCount, elem => new PFSegmentsContactEmailInfo(elem));

            Created = (interop.created == null) ? null : *interop.created;

            CustomProperties = (interop.customProperties.stringValue == null) ? default : new PFJsonObject(interop.customProperties);

            DisplayName = (interop.displayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.displayName);

            LastLogin = (interop.lastLogin == null) ? null : *interop.lastLogin;

            LinkedAccounts = (interop.linkedAccounts == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.linkedAccounts, interop.linkedAccountsCount, elem => new PFSegmentsPlayerLinkedAccount(elem));

            Locations = (interop.locations == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.locations, interop.locationsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFSegmentsPlayerLocation(*pair.value)));

            Origination = (interop.origination == null) ? null : (PFLoginIdentityProvider?)(*interop.origination);

            PlayerExperimentVariants = (interop.playerExperimentVariants == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.playerExperimentVariants, interop.playerExperimentVariantsCount);

            PlayerId = (interop.playerId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playerId);

            PlayerStatistics = (interop.playerStatistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.playerStatistics, interop.playerStatisticsCount, elem => new PFSegmentsPlayerStatistic(elem));

            PublisherId = (interop.publisherId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.publisherId);

            PushNotificationRegistrations = (interop.pushNotificationRegistrations == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.pushNotificationRegistrations, interop.pushNotificationRegistrationsCount, elem => new PFSegmentsPushNotificationRegistration(elem));

            Statistics = (interop.statistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.statistics, interop.statisticsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount);

            TitleId = (interop.titleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.titleId);

            TotalValueToDateInUSD = (interop.totalValueToDateInUSD == null) ? null : *interop.totalValueToDateInUSD;

            ValuesToDate = (interop.valuesToDate == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.valuesToDate, interop.valuesToDateCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            VirtualCurrencyBalances = (interop.virtualCurrencyBalances == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.virtualCurrencyBalances, interop.virtualCurrencyBalancesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

        }

        internal unsafe static void ToInterop(PFSegmentsPlayerProfile self, Interop.PFSegmentsPlayerProfile* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AdCampaignAttributions != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.AdCampaignAttributions, &interop->adCampaignAttributions, buffer, PFSegmentsAdCampaignAttribution.ToInterop);
                interop->adCampaignAttributionsCount = (uint)self.AdCampaignAttributions.Length;
            }

            if (self.AvatarUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AvatarUrl, &interop->avatarUrl, buffer);
            }

            if (self.BannedUntil != null)
            {
                *interop->bannedUntil = self.BannedUntil.Value;
            }

            if (self.ChurnPrediction != null)
            {
                *interop->churnPrediction = (Interop.PFSegmentsChurnRiskLevel)self.ChurnPrediction.Value;
            }

            if (self.ContactEmailAddresses != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.ContactEmailAddresses, &interop->contactEmailAddresses, buffer, PFSegmentsContactEmailInfo.ToInterop);
                interop->contactEmailAddressesCount = (uint)self.ContactEmailAddresses.Length;
            }

            if (self.Created != null)
            {
                *interop->created = self.Created.Value;
            }

            if (self.CustomProperties.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CustomProperties.stringValue, &interop->customProperties.stringValue, buffer);
            }

            if (self.DisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayName, &interop->displayName, buffer);
            }

            if (self.LastLogin != null)
            {
                *interop->lastLogin = self.LastLogin.Value;
            }

            if (self.LinkedAccounts != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.LinkedAccounts, &interop->linkedAccounts, buffer, PFSegmentsPlayerLinkedAccount.ToInterop);
                interop->linkedAccountsCount = (uint)self.LinkedAccounts.Length;
            }

            if (self.Locations != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.Locations, &interop->locations, buffer, (KeyValuePair<string, PFSegmentsPlayerLocation> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFSegmentsPlayerLocation* valueBuf = (Interop.PFSegmentsPlayerLocation*)buffer.AddBuffer(sizeof(Interop.PFSegmentsPlayerLocation));
                    PFSegmentsPlayerLocation.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFSegmentsPlayerLocationDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->locationsCount = (uint)self.Locations.Count;
            }

            if (self.Origination != null)
            {
                *interop->origination = (Interop.PFLoginIdentityProvider)self.Origination.Value;
            }

            if (self.PlayerExperimentVariants != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.PlayerExperimentVariants, &interop->playerExperimentVariants, buffer);
                interop->playerExperimentVariantsCount = (uint)self.PlayerExperimentVariants.Length;
            }

            if (self.PlayerId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerId, &interop->playerId, buffer);
            }

            if (self.PlayerStatistics != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.PlayerStatistics, &interop->playerStatistics, buffer, PFSegmentsPlayerStatistic.ToInterop);
                interop->playerStatisticsCount = (uint)self.PlayerStatistics.Length;
            }

            if (self.PublisherId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PublisherId, &interop->publisherId, buffer);
            }

            if (self.PushNotificationRegistrations != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.PushNotificationRegistrations, &interop->pushNotificationRegistrations, buffer, PFSegmentsPushNotificationRegistration.ToInterop);
                interop->pushNotificationRegistrationsCount = (uint)self.PushNotificationRegistrations.Length;
            }

            if (self.Statistics != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.Statistics, &interop->statistics, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->statisticsCount = (uint)self.Statistics.Count;
            }

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
                interop->tagsCount = (uint)self.Tags.Length;
            }

            if (self.TitleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TitleId, &interop->titleId, buffer);
            }

            if (self.TotalValueToDateInUSD != null)
            {
                *interop->totalValueToDateInUSD = self.TotalValueToDateInUSD.Value;
            }

            if (self.ValuesToDate != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.ValuesToDate, &interop->valuesToDate, buffer, (KeyValuePair<string, uint> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFUint32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->valuesToDateCount = (uint)self.ValuesToDate.Count;
            }

            if (self.VirtualCurrencyBalances != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.VirtualCurrencyBalances, &interop->virtualCurrencyBalances, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->virtualCurrencyBalancesCount = (uint)self.VirtualCurrencyBalances.Count;
            }

        }
            
    }

    /// <summary>
    /// PFSegmentsGetPlayersInSegmentResult data model.
    /// </summary>
    public struct PFSegmentsGetPlayersInSegmentResult
    {
        /// <summary>
        /// (Optional) Continuation token to use to retrieve subsequent pages of results. If token returns null
        /// there are no more results.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) Array of player profiles in this segment.
        /// </summary>
        public PFSegmentsPlayerProfile[]? PlayerProfiles;

        /// <summary>
        /// Count of profiles matching this segment.
        /// </summary>
        public int ProfilesInSegment;

        internal unsafe PFSegmentsGetPlayersInSegmentResult(Interop.PFSegmentsGetPlayersInSegmentResult interop)
        {

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

            PlayerProfiles = (interop.playerProfiles == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.playerProfiles, interop.playerProfilesCount, elem => new PFSegmentsPlayerProfile(elem));

            ProfilesInSegment = interop.profilesInSegment;

        }
            
    }

    /// <summary>
    /// PFSegmentsRemovePlayerTagRequest data model. This API will trigger a player_tag_removed event and
    /// remove a tag with the given TagName and PlayFabID from the corresponding player profile. TagName can
    /// be used for segmentation and it is limited to 256 characters.
    /// </summary>
    public struct PFSegmentsRemovePlayerTagRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName;

        internal unsafe static void ToInterop(PFSegmentsRemovePlayerTagRequest self, Interop.PFSegmentsRemovePlayerTagRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.TagName, &interop->tagName, buffer);

        }
            
    }

}
