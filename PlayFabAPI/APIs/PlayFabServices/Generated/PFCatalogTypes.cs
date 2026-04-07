// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// ModerationStatus enum.
    /// </summary>
    public enum PFCatalogModerationStatus : uint
    {
        Unknown = Interop.PFCatalogModerationStatus.Unknown,
        AwaitingModeration = Interop.PFCatalogModerationStatus.AwaitingModeration,
        Approved = Interop.PFCatalogModerationStatus.Approved,
        Rejected = Interop.PFCatalogModerationStatus.Rejected
    }

    /// <summary>
    /// DisplayPropertyType enum.
    /// </summary>
    public enum PFCatalogDisplayPropertyType : uint
    {
        None = Interop.PFCatalogDisplayPropertyType.None,
        QueryDateTime = Interop.PFCatalogDisplayPropertyType.QueryDateTime,
        QueryDouble = Interop.PFCatalogDisplayPropertyType.QueryDouble,
        QueryString = Interop.PFCatalogDisplayPropertyType.QueryString,
        SearchString = Interop.PFCatalogDisplayPropertyType.SearchString
    }

    /// <summary>
    /// PublishResult enum.
    /// </summary>
    public enum PFCatalogPublishResult : uint
    {
        Unknown = Interop.PFCatalogPublishResult.Unknown,
        Pending = Interop.PFCatalogPublishResult.Pending,
        Succeeded = Interop.PFCatalogPublishResult.Succeeded,
        Failed = Interop.PFCatalogPublishResult.Failed,
        Canceled = Interop.PFCatalogPublishResult.Canceled
    }

    /// <summary>
    /// ConcernCategory enum.
    /// </summary>
    public enum PFCatalogConcernCategory : uint
    {
        None = Interop.PFCatalogConcernCategory.None,
        OffensiveContent = Interop.PFCatalogConcernCategory.OffensiveContent,
        ChildExploitation = Interop.PFCatalogConcernCategory.ChildExploitation,
        MalwareOrVirus = Interop.PFCatalogConcernCategory.MalwareOrVirus,
        PrivacyConcerns = Interop.PFCatalogConcernCategory.PrivacyConcerns,
        MisleadingApp = Interop.PFCatalogConcernCategory.MisleadingApp,
        PoorPerformance = Interop.PFCatalogConcernCategory.PoorPerformance,
        ReviewResponse = Interop.PFCatalogConcernCategory.ReviewResponse,
        SpamAdvertising = Interop.PFCatalogConcernCategory.SpamAdvertising,
        Profanity = Interop.PFCatalogConcernCategory.Profanity
    }

    /// <summary>
    /// HelpfulnessVote enum.
    /// </summary>
    public enum PFCatalogHelpfulnessVote : uint
    {
        None = Interop.PFCatalogHelpfulnessVote.None,
        UnHelpful = Interop.PFCatalogHelpfulnessVote.UnHelpful,
        Helpful = Interop.PFCatalogHelpfulnessVote.Helpful
    }

    /// <summary>
    /// PFCatalogCatalogAlternateId data model.
    /// </summary>
    public struct PFCatalogCatalogAlternateId
    {
        /// <summary>
        /// (Optional) Type of the alternate ID.
        /// </summary>
        public string? Type;

        /// <summary>
        /// (Optional) Value of the alternate ID.
        /// </summary>
        public string? Value;

        internal unsafe PFCatalogCatalogAlternateId(Interop.PFCatalogCatalogAlternateId interop)
        {

            Type = (interop.type == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.type);

            Value = (interop.value == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.value);

        }

        internal unsafe static void ToInterop(PFCatalogCatalogAlternateId self, Interop.PFCatalogCatalogAlternateId* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Type != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Type, &interop->type, buffer);
            }

            if (self.Value != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Value, &interop->value, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogContent data model.
    /// </summary>
    public struct PFCatalogContent
    {
        /// <summary>
        /// (Optional) The content unique ID.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The maximum client version that this content is compatible with. Client Versions can be
        /// up to 3 segments separated by periods(.) and each segment can have a maximum value of 65535.
        /// </summary>
        public string? MaxClientVersion;

        /// <summary>
        /// (Optional) The minimum client version that this content is compatible with. Client Versions can be
        /// up to 3 segments separated by periods(.) and each segment can have a maximum value of 65535.
        /// </summary>
        public string? MinClientVersion;

        /// <summary>
        /// (Optional) The list of tags that are associated with this content. Tags must be defined in the Catalog
        /// Config before being used in content.
        /// </summary>
        public string[]? Tags;

        /// <summary>
        /// (Optional) The client-defined type of the content. Content Types must be defined in the Catalog Config
        /// before being used.
        /// </summary>
        public string? Type;

        /// <summary>
        /// (Optional) The Azure CDN URL for retrieval of the catalog item binary content.
        /// </summary>
        public string? Url;

        internal unsafe PFCatalogContent(Interop.PFCatalogContent interop)
        {

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

            MaxClientVersion = (interop.maxClientVersion == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.maxClientVersion);

            MinClientVersion = (interop.minClientVersion == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.minClientVersion);

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount);

            Type = (interop.type == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.type);

            Url = (interop.url == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.url);

        }

        internal unsafe static void ToInterop(PFCatalogContent self, Interop.PFCatalogContent* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.MaxClientVersion != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MaxClientVersion, &interop->maxClientVersion, buffer);
            }

            if (self.MinClientVersion != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MinClientVersion, &interop->minClientVersion, buffer);
            }

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
                interop->tagsCount = (uint)self.Tags.Length;
            }

            if (self.Type != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Type, &interop->type, buffer);
            }

            if (self.Url != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Url, &interop->url, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogDeepLink data model.
    /// </summary>
    public struct PFCatalogDeepLink
    {
        /// <summary>
        /// (Optional) Target platform for this deep link.
        /// </summary>
        public string? Platform;

        /// <summary>
        /// (Optional) The deep link for this platform.
        /// </summary>
        public string? Url;

        internal unsafe PFCatalogDeepLink(Interop.PFCatalogDeepLink interop)
        {

            Platform = (interop.platform == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.platform);

            Url = (interop.url == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.url);

        }

        internal unsafe static void ToInterop(PFCatalogDeepLink self, Interop.PFCatalogDeepLink* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Platform != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Platform, &interop->platform, buffer);
            }

            if (self.Url != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Url, &interop->url, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogImage data model.
    /// </summary>
    public struct PFCatalogImage
    {
        /// <summary>
        /// (Optional) The image unique ID.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The client-defined tag associated with this image. Tags must be defined in the Catalog
        /// Config before being used in images.
        /// </summary>
        public string? Tag;

        /// <summary>
        /// (Optional) Images can be defined as either a "thumbnail" or "screenshot". There can only be one "thumbnail"
        /// image per item.
        /// </summary>
        public string? Type;

        /// <summary>
        /// (Optional) The URL for retrieval of the image.
        /// </summary>
        public string? Url;

        internal unsafe PFCatalogImage(Interop.PFCatalogImage interop)
        {

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

            Tag = (interop.tag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.tag);

            Type = (interop.type == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.type);

            Url = (interop.url == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.url);

        }

        internal unsafe static void ToInterop(PFCatalogImage self, Interop.PFCatalogImage* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.Tag != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Tag, &interop->tag, buffer);
            }

            if (self.Type != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Type, &interop->type, buffer);
            }

            if (self.Url != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Url, &interop->url, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogPriceAmount data model.
    /// </summary>
    public struct PFCatalogCatalogPriceAmount
    {
        /// <summary>
        /// The amount of the price.
        /// </summary>
        public int Amount;

        /// <summary>
        /// (Optional) The Item Id of the price.
        /// </summary>
        public string? ItemId;

        internal unsafe PFCatalogCatalogPriceAmount(Interop.PFCatalogCatalogPriceAmount interop)
        {

            Amount = interop.amount;

            ItemId = (interop.itemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemId);

        }

        internal unsafe static void ToInterop(PFCatalogCatalogPriceAmount self, Interop.PFCatalogCatalogPriceAmount* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->amount = self.Amount;

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogPrice data model.
    /// </summary>
    public struct PFCatalogCatalogPrice
    {
        /// <summary>
        /// (Optional) The amounts of the catalog item price. Each price can have up to 15 item amounts.
        /// </summary>
        public PFCatalogCatalogPriceAmount[]? Amounts;

        /// <summary>
        /// (Optional) The per-unit amount this price can be used to purchase.
        /// </summary>
        public int? UnitAmount;

        /// <summary>
        /// (Optional) The per-unit duration this price can be used to purchase. The maximum duration is 100
        /// years.
        /// </summary>
        public double? UnitDurationInSeconds;

        internal unsafe PFCatalogCatalogPrice(Interop.PFCatalogCatalogPrice interop)
        {

            Amounts = (interop.amounts == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.amounts, interop.amountsCount, elem => new PFCatalogCatalogPriceAmount(elem));

            UnitAmount = (interop.unitAmount == null) ? null : *interop.unitAmount;

            UnitDurationInSeconds = (interop.unitDurationInSeconds == null) ? null : *interop.unitDurationInSeconds;

        }

        internal unsafe static void ToInterop(PFCatalogCatalogPrice self, Interop.PFCatalogCatalogPrice* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amounts != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Amounts, &interop->amounts, buffer, PFCatalogCatalogPriceAmount.ToInterop);
                interop->amountsCount = (uint)self.Amounts.Length;
            }

            if (self.UnitAmount != null)
            {
                *interop->unitAmount = self.UnitAmount.Value;
            }

            if (self.UnitDurationInSeconds != null)
            {
                *interop->unitDurationInSeconds = self.UnitDurationInSeconds.Value;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogPriceOptions data model.
    /// </summary>
    public struct PFCatalogCatalogPriceOptions
    {
        /// <summary>
        /// (Optional) Prices of the catalog item. An item can have up to 15 prices.
        /// </summary>
        public PFCatalogCatalogPrice[]? Prices;

        internal unsafe PFCatalogCatalogPriceOptions(Interop.PFCatalogCatalogPriceOptions interop)
        {

            Prices = (interop.prices == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.prices, interop.pricesCount, elem => new PFCatalogCatalogPrice(elem));

        }

        internal unsafe static void ToInterop(PFCatalogCatalogPriceOptions self, Interop.PFCatalogCatalogPriceOptions* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Prices != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Prices, &interop->prices, buffer, PFCatalogCatalogPrice.ToInterop);
                interop->pricesCount = (uint)self.Prices.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogItemReference data model.
    /// </summary>
    public struct PFCatalogCatalogItemReference
    {
        /// <summary>
        /// (Optional) The amount of the catalog item.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// (Optional) The unique ID of the catalog item.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The prices the catalog item can be purchased for.
        /// </summary>
        public PFCatalogCatalogPriceOptions? PriceOptions;

        internal unsafe PFCatalogCatalogItemReference(Interop.PFCatalogCatalogItemReference interop)
        {

            Amount = (interop.amount == null) ? null : *interop.amount;

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

            PriceOptions = (interop.priceOptions == null) ? null : new(*interop.priceOptions);

        }

        internal unsafe static void ToInterop(PFCatalogCatalogItemReference self, Interop.PFCatalogCatalogItemReference* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.PriceOptions != null)
            {
                interop->priceOptions = (Interop.PFCatalogCatalogPriceOptions*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogPriceOptions));
                PFCatalogCatalogPriceOptions.ToInterop(self.PriceOptions.Value, interop->priceOptions, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogKeywordSet data model.
    /// </summary>
    public struct PFCatalogKeywordSet
    {
        /// <summary>
        /// (Optional) A list of localized keywords.
        /// </summary>
        public string[]? Values;

        internal unsafe PFCatalogKeywordSet(Interop.PFCatalogKeywordSet interop)
        {

            Values = (interop.values == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.values, interop.valuesCount);

        }

        internal unsafe static void ToInterop(PFCatalogKeywordSet self, Interop.PFCatalogKeywordSet* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Values != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Values, &interop->values, buffer);
                interop->valuesCount = (uint)self.Values.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogModerationState data model.
    /// </summary>
    public struct PFCatalogModerationState
    {
        /// <summary>
        /// (Optional) The date and time this moderation state was last updated.
        /// </summary>
        public long? LastModifiedDate;

        /// <summary>
        /// (Optional) The current stated reason for the associated item being moderated.
        /// </summary>
        public string? Reason;

        /// <summary>
        /// (Optional) The current moderation status for the associated item.
        /// </summary>
        public PFCatalogModerationStatus? Status;

        internal unsafe PFCatalogModerationState(Interop.PFCatalogModerationState interop)
        {

            LastModifiedDate = (interop.lastModifiedDate == null) ? null : *interop.lastModifiedDate;

            Reason = (interop.reason == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.reason);

            Status = (interop.status == null) ? null : (PFCatalogModerationStatus?)(*interop.status);

        }

        internal unsafe static void ToInterop(PFCatalogModerationState self, Interop.PFCatalogModerationState* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.LastModifiedDate != null)
            {
                *interop->lastModifiedDate = self.LastModifiedDate.Value;
            }

            if (self.Reason != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Reason, &interop->reason, buffer);
            }

            if (self.Status != null)
            {
                *interop->status = (Interop.PFCatalogModerationStatus)self.Status.Value;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogRating data model.
    /// </summary>
    public struct PFCatalogRating
    {
        /// <summary>
        /// (Optional) The average rating for this item.
        /// </summary>
        public float? Average;

        /// <summary>
        /// (Optional) The total count of 1 star ratings for this item.
        /// </summary>
        public int? Count1Star;

        /// <summary>
        /// (Optional) The total count of 2 star ratings for this item.
        /// </summary>
        public int? Count2Star;

        /// <summary>
        /// (Optional) The total count of 3 star ratings for this item.
        /// </summary>
        public int? Count3Star;

        /// <summary>
        /// (Optional) The total count of 4 star ratings for this item.
        /// </summary>
        public int? Count4Star;

        /// <summary>
        /// (Optional) The total count of 5 star ratings for this item.
        /// </summary>
        public int? Count5Star;

        /// <summary>
        /// (Optional) The total count of ratings for this item.
        /// </summary>
        public int? TotalCount;

        internal unsafe PFCatalogRating(Interop.PFCatalogRating interop)
        {

            Average = (interop.average == null) ? null : *interop.average;

            Count1Star = (interop.count1Star == null) ? null : *interop.count1Star;

            Count2Star = (interop.count2Star == null) ? null : *interop.count2Star;

            Count3Star = (interop.count3Star == null) ? null : *interop.count3Star;

            Count4Star = (interop.count4Star == null) ? null : *interop.count4Star;

            Count5Star = (interop.count5Star == null) ? null : *interop.count5Star;

            TotalCount = (interop.totalCount == null) ? null : *interop.totalCount;

        }

        internal unsafe static void ToInterop(PFCatalogRating self, Interop.PFCatalogRating* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Average != null)
            {
                *interop->average = self.Average.Value;
            }

            if (self.Count1Star != null)
            {
                *interop->count1Star = self.Count1Star.Value;
            }

            if (self.Count2Star != null)
            {
                *interop->count2Star = self.Count2Star.Value;
            }

            if (self.Count3Star != null)
            {
                *interop->count3Star = self.Count3Star.Value;
            }

            if (self.Count4Star != null)
            {
                *interop->count4Star = self.Count4Star.Value;
            }

            if (self.Count5Star != null)
            {
                *interop->count5Star = self.Count5Star.Value;
            }

            if (self.TotalCount != null)
            {
                *interop->totalCount = self.TotalCount.Value;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogRealMoneyPriceDetails data model. The multi-currency unit price, in real money, of the item
    /// that was redeemed within an individual marketplace. Each property is a dictionary where the key is
    /// the three-letter currency code as defined in ISO 4217, and the value is the currency amount in the
    /// smallest unit (e.g. cents, pence, etc.) in accordance with ISO 4217. Example: If the product price
    /// in USD is $1.39, the dictionary entry would be: ["USD"] = 139. Currently, only United States Dollar
    /// (USD) is supported.
    /// </summary>
    public struct PFCatalogRealMoneyPriceDetails
    {
        /// <summary>
        /// (Optional) The 'AppleAppStore' price amount per CurrencyCode. 'USD' supported only.
        /// </summary>
        public Dictionary<string, int>? AppleAppStorePrices;

        /// <summary>
        /// (Optional) The 'GooglePlay' price amount per CurrencyCode. 'USD' supported only.
        /// </summary>
        public Dictionary<string, int>? GooglePlayPrices;

        /// <summary>
        /// (Optional) The 'MicrosoftStore' price amount per CurrencyCode. 'USD' supported only.
        /// </summary>
        public Dictionary<string, int>? MicrosoftStorePrices;

        /// <summary>
        /// (Optional) The 'NintendoEShop' price amount per CurrencyCode. 'USD' supported only.
        /// </summary>
        public Dictionary<string, int>? NintendoEShopPrices;

        /// <summary>
        /// (Optional) The 'PlayStationStore' price amount per CurrencyCode. 'USD' supported only.
        /// </summary>
        public Dictionary<string, int>? PlayStationStorePrices;

        /// <summary>
        /// (Optional) The 'Steam' price amount per CurrencyCode. 'USD' supported only.
        /// </summary>
        public Dictionary<string, int>? SteamPrices;

        internal unsafe PFCatalogRealMoneyPriceDetails(Interop.PFCatalogRealMoneyPriceDetails interop)
        {

            AppleAppStorePrices = (interop.appleAppStorePrices == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.appleAppStorePrices, interop.appleAppStorePricesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            GooglePlayPrices = (interop.googlePlayPrices == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.googlePlayPrices, interop.googlePlayPricesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            MicrosoftStorePrices = (interop.microsoftStorePrices == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.microsoftStorePrices, interop.microsoftStorePricesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            NintendoEShopPrices = (interop.nintendoEShopPrices == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.nintendoEShopPrices, interop.nintendoEShopPricesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            PlayStationStorePrices = (interop.playStationStorePrices == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.playStationStorePrices, interop.playStationStorePricesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            SteamPrices = (interop.steamPrices == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.steamPrices, interop.steamPricesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

        }

        internal unsafe static void ToInterop(PFCatalogRealMoneyPriceDetails self, Interop.PFCatalogRealMoneyPriceDetails* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AppleAppStorePrices != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.AppleAppStorePrices, &interop->appleAppStorePrices, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->appleAppStorePricesCount = (uint)self.AppleAppStorePrices.Count;
            }

            if (self.GooglePlayPrices != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.GooglePlayPrices, &interop->googlePlayPrices, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->googlePlayPricesCount = (uint)self.GooglePlayPrices.Count;
            }

            if (self.MicrosoftStorePrices != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.MicrosoftStorePrices, &interop->microsoftStorePrices, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->microsoftStorePricesCount = (uint)self.MicrosoftStorePrices.Count;
            }

            if (self.NintendoEShopPrices != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.NintendoEShopPrices, &interop->nintendoEShopPrices, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->nintendoEShopPricesCount = (uint)self.NintendoEShopPrices.Count;
            }

            if (self.PlayStationStorePrices != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.PlayStationStorePrices, &interop->playStationStorePrices, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->playStationStorePricesCount = (uint)self.PlayStationStorePrices.Count;
            }

            if (self.SteamPrices != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.SteamPrices, &interop->steamPrices, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->steamPricesCount = (uint)self.SteamPrices.Count;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogFilterOptions data model.
    /// </summary>
    public struct PFCatalogFilterOptions
    {
        /// <summary>
        /// (Optional) The OData filter utilized. Mutually exclusive with 'IncludeAllItems'. More info about
        /// Filter Complexity limits can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search#limits.
        /// </summary>
        public string? Filter;

        /// <summary>
        /// (Optional) The flag that overrides the filter and allows for returning all catalog items. Mutually
        /// exclusive with 'Filter'.
        /// </summary>
        public bool? IncludeAllItems;

        internal unsafe PFCatalogFilterOptions(Interop.PFCatalogFilterOptions interop)
        {

            Filter = (interop.filter == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.filter);

            IncludeAllItems = (interop.includeAllItems == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.includeAllItems);

        }

        internal unsafe static void ToInterop(PFCatalogFilterOptions self, Interop.PFCatalogFilterOptions* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Filter != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Filter, &interop->filter, buffer);
            }

            if (self.IncludeAllItems != null)
            {
                *interop->includeAllItems = InteropWrapper.WrapperHelpers.BoolToInterop(self.IncludeAllItems.Value);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogPermissions data model.
    /// </summary>
    public struct PFCatalogPermissions
    {
        /// <summary>
        /// (Optional) The list of ids of Segments that the a player can be in to purchase from the store. When
        /// a value is provided, the player must be in at least one of the segments listed for the purchase to
        /// be allowed.
        /// </summary>
        public string[]? SegmentIds;

        internal unsafe PFCatalogPermissions(Interop.PFCatalogPermissions interop)
        {

            SegmentIds = (interop.segmentIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.segmentIds, interop.segmentIdsCount);

        }

        internal unsafe static void ToInterop(PFCatalogPermissions self, Interop.PFCatalogPermissions* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.SegmentIds != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.SegmentIds, &interop->segmentIds, buffer);
                interop->segmentIdsCount = (uint)self.SegmentIds.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogPriceAmountOverride data model.
    /// </summary>
    public struct PFCatalogCatalogPriceAmountOverride
    {
        /// <summary>
        /// (Optional) The exact value that should be utilized in the override.
        /// </summary>
        public int? FixedValue;

        /// <summary>
        /// (Optional) The id of the item this override should utilize.
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) The multiplier that will be applied to the base Catalog value to determine what value
        /// should be utilized in the override.
        /// </summary>
        public double? Multiplier;

        internal unsafe PFCatalogCatalogPriceAmountOverride(Interop.PFCatalogCatalogPriceAmountOverride interop)
        {

            FixedValue = (interop.fixedValue == null) ? null : *interop.fixedValue;

            ItemId = (interop.itemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemId);

            Multiplier = (interop.multiplier == null) ? null : *interop.multiplier;

        }

        internal unsafe static void ToInterop(PFCatalogCatalogPriceAmountOverride self, Interop.PFCatalogCatalogPriceAmountOverride* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FixedValue != null)
            {
                *interop->fixedValue = self.FixedValue.Value;
            }

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.Multiplier != null)
            {
                *interop->multiplier = self.Multiplier.Value;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogPriceOverride data model.
    /// </summary>
    public struct PFCatalogCatalogPriceOverride
    {
        /// <summary>
        /// (Optional) The currency amounts utilized in the override for a singular price.
        /// </summary>
        public PFCatalogCatalogPriceAmountOverride[]? Amounts;

        internal unsafe PFCatalogCatalogPriceOverride(Interop.PFCatalogCatalogPriceOverride interop)
        {

            Amounts = (interop.amounts == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.amounts, interop.amountsCount, elem => new PFCatalogCatalogPriceAmountOverride(elem));

        }

        internal unsafe static void ToInterop(PFCatalogCatalogPriceOverride self, Interop.PFCatalogCatalogPriceOverride* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amounts != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Amounts, &interop->amounts, buffer, PFCatalogCatalogPriceAmountOverride.ToInterop);
                interop->amountsCount = (uint)self.Amounts.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogPriceOptionsOverride data model.
    /// </summary>
    public struct PFCatalogCatalogPriceOptionsOverride
    {
        /// <summary>
        /// (Optional) The prices utilized in the override.
        /// </summary>
        public PFCatalogCatalogPriceOverride[]? Prices;

        internal unsafe PFCatalogCatalogPriceOptionsOverride(Interop.PFCatalogCatalogPriceOptionsOverride interop)
        {

            Prices = (interop.prices == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.prices, interop.pricesCount, elem => new PFCatalogCatalogPriceOverride(elem));

        }

        internal unsafe static void ToInterop(PFCatalogCatalogPriceOptionsOverride self, Interop.PFCatalogCatalogPriceOptionsOverride* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Prices != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Prices, &interop->prices, buffer, PFCatalogCatalogPriceOverride.ToInterop);
                interop->pricesCount = (uint)self.Prices.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogStoreDetails data model.
    /// </summary>
    public struct PFCatalogStoreDetails
    {
        /// <summary>
        /// (Optional) The options for the filter in filter-based stores. These options are mutually exclusive
        /// with item references.
        /// </summary>
        public PFCatalogFilterOptions? FilterOptions;

        /// <summary>
        /// (Optional) The permissions that control which players can purchase from the store.
        /// </summary>
        public PFCatalogPermissions? Permissions;

        /// <summary>
        /// (Optional) The global prices utilized in the store. These options are mutually exclusive with price
        /// options in item references.
        /// </summary>
        public PFCatalogCatalogPriceOptionsOverride? PriceOptionsOverride;

        internal unsafe PFCatalogStoreDetails(Interop.PFCatalogStoreDetails interop)
        {

            FilterOptions = (interop.filterOptions == null) ? null : new(*interop.filterOptions);

            Permissions = (interop.permissions == null) ? null : new(*interop.permissions);

            PriceOptionsOverride = (interop.priceOptionsOverride == null) ? null : new(*interop.priceOptionsOverride);

        }

        internal unsafe static void ToInterop(PFCatalogStoreDetails self, Interop.PFCatalogStoreDetails* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FilterOptions != null)
            {
                interop->filterOptions = (Interop.PFCatalogFilterOptions*)buffer.AddBuffer(sizeof(Interop.PFCatalogFilterOptions));
                PFCatalogFilterOptions.ToInterop(self.FilterOptions.Value, interop->filterOptions, buffer);
            }

            if (self.Permissions != null)
            {
                interop->permissions = (Interop.PFCatalogPermissions*)buffer.AddBuffer(sizeof(Interop.PFCatalogPermissions));
                PFCatalogPermissions.ToInterop(self.Permissions.Value, interop->permissions, buffer);
            }

            if (self.PriceOptionsOverride != null)
            {
                interop->priceOptionsOverride = (Interop.PFCatalogCatalogPriceOptionsOverride*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogPriceOptionsOverride));
                PFCatalogCatalogPriceOptionsOverride.ToInterop(self.PriceOptionsOverride.Value, interop->priceOptionsOverride, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogItem data model.
    /// </summary>
    public struct PFCatalogCatalogItem
    {
        /// <summary>
        /// (Optional) The alternate IDs associated with this item. An alternate ID can be set to 'FriendlyId'
        /// or any of the supported marketplace names.
        /// </summary>
        public PFCatalogCatalogAlternateId[]? AlternateIds;

        /// <summary>
        /// (Optional) The set of content/files associated with this item. Up to 100 files can be added to an
        /// item.
        /// </summary>
        public PFCatalogContent[]? Contents;

        /// <summary>
        /// (Optional) The client-defined type of the item.
        /// </summary>
        public string? ContentType;

        /// <summary>
        /// (Optional) The date and time when this item was created.
        /// </summary>
        public long? CreationDate;

        /// <summary>
        /// (Optional) The ID of the creator of this catalog item.
        /// </summary>
        public PFEntityKey? CreatorEntity;

        /// <summary>
        /// (Optional) The set of platform specific deep links for this item.
        /// </summary>
        public PFCatalogDeepLink[]? DeepLinks;

        /// <summary>
        /// (Optional) The Stack Id that will be used as default for this item in Inventory when an explicit
        /// one is not provided. This DefaultStackId can be a static stack id or '{guid}', which will generate
        /// a unique stack id for the item. If null, Inventory's default stack id will be used.
        /// </summary>
        public string? DefaultStackId;

        /// <summary>
        /// (Optional) A dictionary of localized descriptions. Key is language code and localized string is the
        /// value. The NEUTRAL locale is required. Descriptions have a 10000 character limit per country code.
        /// </summary>
        public Dictionary<string, string>? Description;

        /// <summary>
        /// (Optional) Game specific properties for display purposes. This is an arbitrary JSON blob. The Display
        /// Properties field has a 10000 byte limit per item.
        /// </summary>
        public PFJsonObject DisplayProperties;

        /// <summary>
        /// (Optional) The user provided version of the item for display purposes. Maximum character length of
        /// 50.
        /// </summary>
        public string? DisplayVersion;

        /// <summary>
        /// (Optional) The date of when the item will cease to be available. If not provided then the product
        /// will be available indefinitely.
        /// </summary>
        public long? EndDate;

        /// <summary>
        /// (Optional) The current ETag value that can be used for optimistic concurrency in the If-None-Match
        /// header.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The images associated with this item. Images can be thumbnails or screenshots. Up to 100
        /// images can be added to an item. Only .png, .jpg, .gif, and .bmp file types can be uploaded.
        /// </summary>
        public PFCatalogImage[]? Images;

        /// <summary>
        /// (Optional) Indicates if the item is hidden.
        /// </summary>
        public bool? IsHidden;

        /// <summary>
        /// (Optional) The item references associated with this item. For example, the items in a Bundle/Store/Subscription.
        /// Every item can have up to 50 item references.
        /// </summary>
        public PFCatalogCatalogItemReference[]? ItemReferences;

        /// <summary>
        /// (Optional) A dictionary of localized keywords. Key is language code and localized list of keywords
        /// is the value. Keywords have a 50 character limit per keyword and up to 32 keywords can be added per
        /// country code.
        /// </summary>
        public Dictionary<string, PFCatalogKeywordSet>? Keywords;

        /// <summary>
        /// (Optional) The date and time this item was last updated.
        /// </summary>
        public long? LastModifiedDate;

        /// <summary>
        /// (Optional) The moderation state for this item.
        /// </summary>
        public PFCatalogModerationState? Moderation;

        /// <summary>
        /// (Optional) The platforms supported by this item.
        /// </summary>
        public string[]? Platforms;

        /// <summary>
        /// (Optional) The prices the item can be purchased for.
        /// </summary>
        public PFCatalogCatalogPriceOptions? PriceOptions;

        /// <summary>
        /// (Optional) Rating summary for this item.
        /// </summary>
        public PFCatalogRating? Rating;

        /// <summary>
        /// (Optional) The real price the item was purchased for per marketplace.
        /// </summary>
        public PFCatalogRealMoneyPriceDetails? RealMoneyPriceDetails;

        /// <summary>
        /// (Optional) The date of when the item will be available. If not provided then the product will appear
        /// immediately.
        /// </summary>
        public long? StartDate;

        /// <summary>
        /// (Optional) Optional details for stores items.
        /// </summary>
        public PFCatalogStoreDetails? StoreDetails;

        /// <summary>
        /// (Optional) The list of tags that are associated with this item. Up to 32 tags can be added to an
        /// item.
        /// </summary>
        public string[]? Tags;

        /// <summary>
        /// (Optional) A dictionary of localized titles. Key is language code and localized string is the value.
        /// The NEUTRAL locale is required. Titles have a 512 character limit per country code.
        /// </summary>
        public Dictionary<string, string>? Title;

        /// <summary>
        /// (Optional) The high-level type of the item. The following item types are supported: bundle, catalogItem,
        /// currency, store, ugc, subscription.
        /// </summary>
        public string? Type;

        internal unsafe PFCatalogCatalogItem(Interop.PFCatalogCatalogItem interop)
        {

            AlternateIds = (interop.alternateIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.alternateIds, interop.alternateIdsCount, elem => new PFCatalogCatalogAlternateId(elem));

            Contents = (interop.contents == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.contents, interop.contentsCount, elem => new PFCatalogContent(elem));

            ContentType = (interop.contentType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.contentType);

            CreationDate = (interop.creationDate == null) ? null : *interop.creationDate;

            CreatorEntity = (interop.creatorEntity == null) ? null : new(*interop.creatorEntity);

            DeepLinks = (interop.deepLinks == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.deepLinks, interop.deepLinksCount, elem => new PFCatalogDeepLink(elem));

            DefaultStackId = (interop.defaultStackId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.defaultStackId);

            Description = (interop.description == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.description, interop.descriptionCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

            DisplayProperties = (interop.displayProperties.stringValue == null) ? default : new PFJsonObject(interop.displayProperties);

            DisplayVersion = (interop.displayVersion == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.displayVersion);

            EndDate = (interop.endDate == null) ? null : *interop.endDate;

            ETag = (interop.eTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.eTag);

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

            Images = (interop.images == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.images, interop.imagesCount, elem => new PFCatalogImage(elem));

            IsHidden = (interop.isHidden == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.isHidden);

            ItemReferences = (interop.itemReferences == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.itemReferences, interop.itemReferencesCount, elem => new PFCatalogCatalogItemReference(elem));

            Keywords = (interop.keywords == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.keywords, interop.keywordsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFCatalogKeywordSet(*pair.value)));

            LastModifiedDate = (interop.lastModifiedDate == null) ? null : *interop.lastModifiedDate;

            Moderation = (interop.moderation == null) ? null : new(*interop.moderation);

            Platforms = (interop.platforms == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.platforms, interop.platformsCount);

            PriceOptions = (interop.priceOptions == null) ? null : new(*interop.priceOptions);

            Rating = (interop.rating == null) ? null : new(*interop.rating);

            RealMoneyPriceDetails = (interop.realMoneyPriceDetails == null) ? null : new(*interop.realMoneyPriceDetails);

            StartDate = (interop.startDate == null) ? null : *interop.startDate;

            StoreDetails = (interop.storeDetails == null) ? null : new(*interop.storeDetails);

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount);

            Title = (interop.title == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.title, interop.titleCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

            Type = (interop.type == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.type);

        }

        internal unsafe static void ToInterop(PFCatalogCatalogItem self, Interop.PFCatalogCatalogItem* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateIds != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.AlternateIds, &interop->alternateIds, buffer, PFCatalogCatalogAlternateId.ToInterop);
                interop->alternateIdsCount = (uint)self.AlternateIds.Length;
            }

            if (self.Contents != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Contents, &interop->contents, buffer, PFCatalogContent.ToInterop);
                interop->contentsCount = (uint)self.Contents.Length;
            }

            if (self.ContentType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ContentType, &interop->contentType, buffer);
            }

            if (self.CreationDate != null)
            {
                *interop->creationDate = self.CreationDate.Value;
            }

            if (self.CreatorEntity != null)
            {
                interop->creatorEntity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.CreatorEntity.Value, interop->creatorEntity, buffer);
            }

            if (self.DeepLinks != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.DeepLinks, &interop->deepLinks, buffer, PFCatalogDeepLink.ToInterop);
                interop->deepLinksCount = (uint)self.DeepLinks.Length;
            }

            if (self.DefaultStackId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DefaultStackId, &interop->defaultStackId, buffer);
            }

            if (self.Description != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.Description, &interop->description, buffer);
                interop->descriptionCount = (uint)self.Description.Count;
            }

            if (self.DisplayProperties.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayProperties.stringValue, &interop->displayProperties.stringValue, buffer);
            }

            if (self.DisplayVersion != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayVersion, &interop->displayVersion, buffer);
            }

            if (self.EndDate != null)
            {
                *interop->endDate = self.EndDate.Value;
            }

            if (self.ETag != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ETag, &interop->eTag, buffer);
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.Images != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Images, &interop->images, buffer, PFCatalogImage.ToInterop);
                interop->imagesCount = (uint)self.Images.Length;
            }

            if (self.IsHidden != null)
            {
                *interop->isHidden = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsHidden.Value);
            }

            if (self.ItemReferences != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.ItemReferences, &interop->itemReferences, buffer, PFCatalogCatalogItemReference.ToInterop);
                interop->itemReferencesCount = (uint)self.ItemReferences.Length;
            }

            if (self.Keywords != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.Keywords, &interop->keywords, buffer, (KeyValuePair<string, PFCatalogKeywordSet> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFCatalogKeywordSet* valueBuf = (Interop.PFCatalogKeywordSet*)buffer.AddBuffer(sizeof(Interop.PFCatalogKeywordSet));
                    PFCatalogKeywordSet.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFCatalogKeywordSetDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->keywordsCount = (uint)self.Keywords.Count;
            }

            if (self.LastModifiedDate != null)
            {
                *interop->lastModifiedDate = self.LastModifiedDate.Value;
            }

            if (self.Moderation != null)
            {
                interop->moderation = (Interop.PFCatalogModerationState*)buffer.AddBuffer(sizeof(Interop.PFCatalogModerationState));
                PFCatalogModerationState.ToInterop(self.Moderation.Value, interop->moderation, buffer);
            }

            if (self.Platforms != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Platforms, &interop->platforms, buffer);
                interop->platformsCount = (uint)self.Platforms.Length;
            }

            if (self.PriceOptions != null)
            {
                interop->priceOptions = (Interop.PFCatalogCatalogPriceOptions*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogPriceOptions));
                PFCatalogCatalogPriceOptions.ToInterop(self.PriceOptions.Value, interop->priceOptions, buffer);
            }

            if (self.Rating != null)
            {
                interop->rating = (Interop.PFCatalogRating*)buffer.AddBuffer(sizeof(Interop.PFCatalogRating));
                PFCatalogRating.ToInterop(self.Rating.Value, interop->rating, buffer);
            }

            if (self.RealMoneyPriceDetails != null)
            {
                interop->realMoneyPriceDetails = (Interop.PFCatalogRealMoneyPriceDetails*)buffer.AddBuffer(sizeof(Interop.PFCatalogRealMoneyPriceDetails));
                PFCatalogRealMoneyPriceDetails.ToInterop(self.RealMoneyPriceDetails.Value, interop->realMoneyPriceDetails, buffer);
            }

            if (self.StartDate != null)
            {
                *interop->startDate = self.StartDate.Value;
            }

            if (self.StoreDetails != null)
            {
                interop->storeDetails = (Interop.PFCatalogStoreDetails*)buffer.AddBuffer(sizeof(Interop.PFCatalogStoreDetails));
                PFCatalogStoreDetails.ToInterop(self.StoreDetails.Value, interop->storeDetails, buffer);
            }

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
                interop->tagsCount = (uint)self.Tags.Length;
            }

            if (self.Title != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.Title, &interop->title, buffer);
                interop->titleCount = (uint)self.Title.Count;
            }

            if (self.Type != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Type, &interop->type, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCreateDraftItemRequest data model. The item will not be published to the public catalog
    /// until the PublishItem API is called for the item.
    /// </summary>
    public struct PFCatalogCreateDraftItemRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Metadata describing the new catalog item to be created.
        /// </summary>
        public PFCatalogCatalogItem? Item;

        /// <summary>
        /// Whether the item should be published immediately. This value is optional, defaults to false.
        /// </summary>
        public bool Publish;

        internal unsafe static void ToInterop(PFCatalogCreateDraftItemRequest self, Interop.PFCatalogCreateDraftItemRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFCatalogCatalogItem*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogItem));
                PFCatalogCatalogItem.ToInterop(self.Item.Value, interop->item, buffer);
            }

            interop->publish = InteropWrapper.WrapperHelpers.BoolToInterop(self.Publish);

        }
            
    }

    /// <summary>
    /// PFCatalogCreateDraftItemResponse data model.
    /// </summary>
    public struct PFCatalogCreateDraftItemResponse
    {
        /// <summary>
        /// (Optional) Updated metadata describing the catalog item just created.
        /// </summary>
        public PFCatalogCatalogItem? Item;

        internal unsafe PFCatalogCreateDraftItemResponse(Interop.PFCatalogCreateDraftItemResponse interop)
        {

            Item = (interop.item == null) ? null : new(*interop.item);

        }
            
    }

    /// <summary>
    /// PFCatalogUploadInfo data model.
    /// </summary>
    public struct PFCatalogUploadInfo
    {
        /// <summary>
        /// (Optional) Name of the file to be uploaded.
        /// </summary>
        public string? FileName;

        internal unsafe PFCatalogUploadInfo(Interop.PFCatalogUploadInfo interop)
        {

            FileName = (interop.fileName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.fileName);

        }

        internal unsafe static void ToInterop(PFCatalogUploadInfo self, Interop.PFCatalogUploadInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FileName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FileName, &interop->fileName, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCreateUploadUrlsRequest data model. Upload URLs point to Azure Blobs; clients must follow
    /// the Microsoft Azure Storage Blob Service REST API pattern for uploading content. The response contains
    /// upload URLs and IDs for each file. The IDs and URLs returned must be added to the item metadata and
    /// committed using the CreateDraftItem or UpdateDraftItem Item APIs.
    /// </summary>
    public struct PFCatalogCreateUploadUrlsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Description of the files to be uploaded by the client.
        /// </summary>
        public PFCatalogUploadInfo[]? Files;

        internal unsafe static void ToInterop(PFCatalogCreateUploadUrlsRequest self, Interop.PFCatalogCreateUploadUrlsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Files != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Files, &interop->files, buffer, PFCatalogUploadInfo.ToInterop);
                interop->filesCount = (uint)self.Files.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogUploadUrlMetadata data model.
    /// </summary>
    public struct PFCatalogUploadUrlMetadata
    {
        /// <summary>
        /// (Optional) Name of the file for which this upload URL was requested.
        /// </summary>
        public string? FileName;

        /// <summary>
        /// (Optional) Unique ID for the binary content to be uploaded to the target URL.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) URL for the binary content to be uploaded to.
        /// </summary>
        public string? Url;

        internal unsafe PFCatalogUploadUrlMetadata(Interop.PFCatalogUploadUrlMetadata interop)
        {

            FileName = (interop.fileName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.fileName);

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

            Url = (interop.url == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.url);

        }

        internal unsafe static void ToInterop(PFCatalogUploadUrlMetadata self, Interop.PFCatalogUploadUrlMetadata* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FileName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FileName, &interop->fileName, buffer);
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.Url != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Url, &interop->url, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCreateUploadUrlsResponse data model.
    /// </summary>
    public struct PFCatalogCreateUploadUrlsResponse
    {
        /// <summary>
        /// (Optional) List of URLs metadata for the files to be uploaded by the client.
        /// </summary>
        public PFCatalogUploadUrlMetadata[]? UploadUrls;

        internal unsafe PFCatalogCreateUploadUrlsResponse(Interop.PFCatalogCreateUploadUrlsResponse interop)
        {

            UploadUrls = (interop.uploadUrls == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.uploadUrls, interop.uploadUrlsCount, elem => new PFCatalogUploadUrlMetadata(elem));

        }
            
    }

    /// <summary>
    /// PFCatalogDeleteEntityItemReviewsRequest data model.
    /// </summary>
    public struct PFCatalogDeleteEntityItemReviewsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe static void ToInterop(PFCatalogDeleteEntityItemReviewsRequest self, Interop.PFCatalogDeleteEntityItemReviewsRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFCatalogDeleteItemRequest data model.
    /// </summary>
    public struct PFCatalogDeleteItemRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogDeleteItemRequest self, Interop.PFCatalogDeleteItemRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
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

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetCatalogConfigRequest data model.
    /// </summary>
    public struct PFCatalogGetCatalogConfigRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFCatalogGetCatalogConfigRequest self, Interop.PFCatalogGetCatalogConfigRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogSpecificConfig data model.
    /// </summary>
    public struct PFCatalogCatalogSpecificConfig
    {
        /// <summary>
        /// (Optional) The set of content types that will be used for validation. Each content type can have
        /// a maximum character length of 40 and up to 128 types can be listed.
        /// </summary>
        public string[]? ContentTypes;

        /// <summary>
        /// (Optional) The set of tags that will be used for validation. Each tag can have a maximum character
        /// length of 32 and up to 1024 tags can be listed.
        /// </summary>
        public string[]? Tags;

        internal unsafe PFCatalogCatalogSpecificConfig(Interop.PFCatalogCatalogSpecificConfig interop)
        {

            ContentTypes = (interop.contentTypes == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.contentTypes, interop.contentTypesCount);

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount);

        }

        internal unsafe static void ToInterop(PFCatalogCatalogSpecificConfig self, Interop.PFCatalogCatalogSpecificConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ContentTypes != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.ContentTypes, &interop->contentTypes, buffer);
                interop->contentTypesCount = (uint)self.ContentTypes.Length;
            }

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
                interop->tagsCount = (uint)self.Tags.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogDeepLinkFormat data model.
    /// </summary>
    public struct PFCatalogDeepLinkFormat
    {
        /// <summary>
        /// (Optional) The format of the deep link to return. The format should contain '{id}' to represent where
        /// the item ID should be placed.
        /// </summary>
        public string? Format;

        /// <summary>
        /// (Optional) The target platform for the deep link.
        /// </summary>
        public string? Platform;

        internal unsafe PFCatalogDeepLinkFormat(Interop.PFCatalogDeepLinkFormat interop)
        {

            Format = (interop.format == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.format);

            Platform = (interop.platform == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.platform);

        }

        internal unsafe static void ToInterop(PFCatalogDeepLinkFormat self, Interop.PFCatalogDeepLinkFormat* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Format != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Format, &interop->format, buffer);
            }

            if (self.Platform != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Platform, &interop->platform, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogDisplayPropertyIndexInfo data model.
    /// </summary>
    public struct PFCatalogDisplayPropertyIndexInfo
    {
        /// <summary>
        /// (Optional) The property name in the 'DisplayProperties' property to be indexed.
        /// </summary>
        public string? Name;

        /// <summary>
        /// (Optional) The type of the property to be indexed.
        /// </summary>
        public PFCatalogDisplayPropertyType? Type;

        internal unsafe PFCatalogDisplayPropertyIndexInfo(Interop.PFCatalogDisplayPropertyIndexInfo interop)
        {

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            Type = (interop.type == null) ? null : (PFCatalogDisplayPropertyType?)(*interop.type);

        }

        internal unsafe static void ToInterop(PFCatalogDisplayPropertyIndexInfo self, Interop.PFCatalogDisplayPropertyIndexInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            if (self.Type != null)
            {
                *interop->type = (Interop.PFCatalogDisplayPropertyType)self.Type.Value;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogFileConfig data model.
    /// </summary>
    public struct PFCatalogFileConfig
    {
        /// <summary>
        /// (Optional) The set of content types that will be used for validation. Each content type can have
        /// a maximum character length of 40 and up to 128 types can be listed.
        /// </summary>
        public string[]? ContentTypes;

        /// <summary>
        /// (Optional) The set of tags that will be used for validation. Each tag can have a maximum character
        /// length of 32 and up to 1024 tags can be listed.
        /// </summary>
        public string[]? Tags;

        internal unsafe PFCatalogFileConfig(Interop.PFCatalogFileConfig interop)
        {

            ContentTypes = (interop.contentTypes == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.contentTypes, interop.contentTypesCount);

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount);

        }

        internal unsafe static void ToInterop(PFCatalogFileConfig self, Interop.PFCatalogFileConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ContentTypes != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.ContentTypes, &interop->contentTypes, buffer);
                interop->contentTypesCount = (uint)self.ContentTypes.Length;
            }

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
                interop->tagsCount = (uint)self.Tags.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogImageConfig data model.
    /// </summary>
    public struct PFCatalogImageConfig
    {
        /// <summary>
        /// (Optional) The set of tags that will be used for validation. Each tag can have a maximum character
        /// length of 32 and up to 1024 tags can be listed.
        /// </summary>
        public string[]? Tags;

        internal unsafe PFCatalogImageConfig(Interop.PFCatalogImageConfig interop)
        {

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount);

        }

        internal unsafe static void ToInterop(PFCatalogImageConfig self, Interop.PFCatalogImageConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
                interop->tagsCount = (uint)self.Tags.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCategoryRatingConfig data model.
    /// </summary>
    public struct PFCatalogCategoryRatingConfig
    {
        /// <summary>
        /// (Optional) Name of the category.
        /// </summary>
        public string? Name;

        internal unsafe PFCatalogCategoryRatingConfig(Interop.PFCatalogCategoryRatingConfig interop)
        {

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

        }

        internal unsafe static void ToInterop(PFCatalogCategoryRatingConfig self, Interop.PFCatalogCategoryRatingConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogReviewConfig data model.
    /// </summary>
    public struct PFCatalogReviewConfig
    {
        /// <summary>
        /// (Optional) A set of categories that can be applied toward ratings and reviews.
        /// </summary>
        public PFCatalogCategoryRatingConfig[]? CategoryRatings;

        internal unsafe PFCatalogReviewConfig(Interop.PFCatalogReviewConfig interop)
        {

            CategoryRatings = (interop.categoryRatings == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.categoryRatings, interop.categoryRatingsCount, elem => new PFCatalogCategoryRatingConfig(elem));

        }

        internal unsafe static void ToInterop(PFCatalogReviewConfig self, Interop.PFCatalogReviewConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CategoryRatings != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.CategoryRatings, &interop->categoryRatings, buffer, PFCatalogCategoryRatingConfig.ToInterop);
                interop->categoryRatingsCount = (uint)self.CategoryRatings.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogUserGeneratedContentSpecificConfig data model.
    /// </summary>
    public struct PFCatalogUserGeneratedContentSpecificConfig
    {
        /// <summary>
        /// (Optional) The set of content types that will be used for validation.
        /// </summary>
        public string[]? ContentTypes;

        /// <summary>
        /// (Optional) The set of tags that will be used for validation.
        /// </summary>
        public string[]? Tags;

        internal unsafe PFCatalogUserGeneratedContentSpecificConfig(Interop.PFCatalogUserGeneratedContentSpecificConfig interop)
        {

            ContentTypes = (interop.contentTypes == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.contentTypes, interop.contentTypesCount);

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount);

        }

        internal unsafe static void ToInterop(PFCatalogUserGeneratedContentSpecificConfig self, Interop.PFCatalogUserGeneratedContentSpecificConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ContentTypes != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.ContentTypes, &interop->contentTypes, buffer);
                interop->contentTypesCount = (uint)self.ContentTypes.Length;
            }

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Tags, &interop->tags, buffer);
                interop->tagsCount = (uint)self.Tags.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogCatalogConfig data model.
    /// </summary>
    public struct PFCatalogCatalogConfig
    {
        /// <summary>
        /// (Optional) A list of player entity keys that will have admin permissions. There is a maximum of 64
        /// entities that can be added.
        /// </summary>
        public PFEntityKey[]? AdminEntities;

        /// <summary>
        /// (Optional) The set of configuration that only applies to catalog items.
        /// </summary>
        public PFCatalogCatalogSpecificConfig? Catalog;

        /// <summary>
        /// (Optional) A list of deep link formats. Up to 10 can be added.
        /// </summary>
        public PFCatalogDeepLinkFormat[]? DeepLinkFormats;

        /// <summary>
        /// (Optional) A list of display properties to index. Up to 5 mappings can be added per Display Property
        /// Type. More info on display properties can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/content-types-tags-and-properties#displayproperties.
        /// </summary>
        public PFCatalogDisplayPropertyIndexInfo[]? DisplayPropertyIndexInfos;

        /// <summary>
        /// (Optional) The set of configuration that only applies to Files.
        /// </summary>
        public PFCatalogFileConfig? File;

        /// <summary>
        /// (Optional) The set of configuration that only applies to Images.
        /// </summary>
        public PFCatalogImageConfig? Image;

        /// <summary>
        /// Flag defining whether catalog is enabled.
        /// </summary>
        public bool IsCatalogEnabled;

        /// <summary>
        /// (Optional) A list of Platforms that can be applied to catalog items. Each platform can have a maximum
        /// character length of 40 and up to 128 platforms can be listed.
        /// </summary>
        public string[]? Platforms;

        /// <summary>
        /// (Optional) The set of configuration that only applies to Ratings and Reviews.
        /// </summary>
        public PFCatalogReviewConfig? Review;

        /// <summary>
        /// (Optional) A set of player entity keys that are allowed to review content. There is a maximum of
        /// 128 entities that can be added.
        /// </summary>
        public PFEntityKey[]? ReviewerEntities;

        /// <summary>
        /// (Optional) The set of configuration that only applies to user generated contents.
        /// </summary>
        public PFCatalogUserGeneratedContentSpecificConfig? UserGeneratedContent;

        internal unsafe PFCatalogCatalogConfig(Interop.PFCatalogCatalogConfig interop)
        {

            AdminEntities = (interop.adminEntities == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.adminEntities, interop.adminEntitiesCount, elem => new PFEntityKey(elem));

            Catalog = (interop.catalog == null) ? null : new(*interop.catalog);

            DeepLinkFormats = (interop.deepLinkFormats == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.deepLinkFormats, interop.deepLinkFormatsCount, elem => new PFCatalogDeepLinkFormat(elem));

            DisplayPropertyIndexInfos = (interop.displayPropertyIndexInfos == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.displayPropertyIndexInfos, interop.displayPropertyIndexInfosCount, elem => new PFCatalogDisplayPropertyIndexInfo(elem));

            File = (interop.file == null) ? null : new(*interop.file);

            Image = (interop.image == null) ? null : new(*interop.image);

            IsCatalogEnabled = InteropWrapper.WrapperHelpers.InteropToBool(interop.isCatalogEnabled);

            Platforms = (interop.platforms == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.platforms, interop.platformsCount);

            Review = (interop.review == null) ? null : new(*interop.review);

            ReviewerEntities = (interop.reviewerEntities == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.reviewerEntities, interop.reviewerEntitiesCount, elem => new PFEntityKey(elem));

            UserGeneratedContent = (interop.userGeneratedContent == null) ? null : new(*interop.userGeneratedContent);

        }

        internal unsafe static void ToInterop(PFCatalogCatalogConfig self, Interop.PFCatalogCatalogConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AdminEntities != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.AdminEntities, &interop->adminEntities, buffer, PFEntityKey.ToInterop);
                interop->adminEntitiesCount = (uint)self.AdminEntities.Length;
            }

            if (self.Catalog != null)
            {
                interop->catalog = (Interop.PFCatalogCatalogSpecificConfig*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogSpecificConfig));
                PFCatalogCatalogSpecificConfig.ToInterop(self.Catalog.Value, interop->catalog, buffer);
            }

            if (self.DeepLinkFormats != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.DeepLinkFormats, &interop->deepLinkFormats, buffer, PFCatalogDeepLinkFormat.ToInterop);
                interop->deepLinkFormatsCount = (uint)self.DeepLinkFormats.Length;
            }

            if (self.DisplayPropertyIndexInfos != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.DisplayPropertyIndexInfos, &interop->displayPropertyIndexInfos, buffer, PFCatalogDisplayPropertyIndexInfo.ToInterop);
                interop->displayPropertyIndexInfosCount = (uint)self.DisplayPropertyIndexInfos.Length;
            }

            if (self.File != null)
            {
                interop->file = (Interop.PFCatalogFileConfig*)buffer.AddBuffer(sizeof(Interop.PFCatalogFileConfig));
                PFCatalogFileConfig.ToInterop(self.File.Value, interop->file, buffer);
            }

            if (self.Image != null)
            {
                interop->image = (Interop.PFCatalogImageConfig*)buffer.AddBuffer(sizeof(Interop.PFCatalogImageConfig));
                PFCatalogImageConfig.ToInterop(self.Image.Value, interop->image, buffer);
            }

            interop->isCatalogEnabled = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsCatalogEnabled);

            if (self.Platforms != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Platforms, &interop->platforms, buffer);
                interop->platformsCount = (uint)self.Platforms.Length;
            }

            if (self.Review != null)
            {
                interop->review = (Interop.PFCatalogReviewConfig*)buffer.AddBuffer(sizeof(Interop.PFCatalogReviewConfig));
                PFCatalogReviewConfig.ToInterop(self.Review.Value, interop->review, buffer);
            }

            if (self.ReviewerEntities != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.ReviewerEntities, &interop->reviewerEntities, buffer, PFEntityKey.ToInterop);
                interop->reviewerEntitiesCount = (uint)self.ReviewerEntities.Length;
            }

            if (self.UserGeneratedContent != null)
            {
                interop->userGeneratedContent = (Interop.PFCatalogUserGeneratedContentSpecificConfig*)buffer.AddBuffer(sizeof(Interop.PFCatalogUserGeneratedContentSpecificConfig));
                PFCatalogUserGeneratedContentSpecificConfig.ToInterop(self.UserGeneratedContent.Value, interop->userGeneratedContent, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetCatalogConfigResponse data model.
    /// </summary>
    public struct PFCatalogGetCatalogConfigResponse
    {
        /// <summary>
        /// (Optional) The catalog configuration.
        /// </summary>
        public PFCatalogCatalogConfig? Config;

        internal unsafe PFCatalogGetCatalogConfigResponse(Interop.PFCatalogGetCatalogConfigResponse interop)
        {

            Config = (interop.config == null) ? null : new(*interop.config);

        }
            
    }

    /// <summary>
    /// PFCatalogGetDraftItemRequest data model.
    /// </summary>
    public struct PFCatalogGetDraftItemRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogGetDraftItemRequest self, Interop.PFCatalogGetDraftItemRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
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

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetDraftItemResponse data model.
    /// </summary>
    public struct PFCatalogGetDraftItemResponse
    {
        /// <summary>
        /// (Optional) Full metadata of the catalog item requested.
        /// </summary>
        public PFCatalogCatalogItem? Item;

        internal unsafe PFCatalogGetDraftItemResponse(Interop.PFCatalogGetDraftItemResponse interop)
        {

            Item = (interop.item == null) ? null : new(*interop.item);

        }
            
    }

    /// <summary>
    /// PFCatalogGetDraftItemsRequest data model.
    /// </summary>
    public struct PFCatalogGetDraftItemsRequest
    {
        /// <summary>
        /// (Optional) List of item alternate IDs.
        /// </summary>
        public PFCatalogCatalogAlternateId[]? AlternateIds;

        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items created by the caller, if any
        /// are available. Should be null on initial request.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) Number of items to retrieve. This value is optional. Default value is 10.
        /// </summary>
        public int? Count;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) List of Item Ids.
        /// </summary>
        public string[]? Ids;

        internal unsafe static void ToInterop(PFCatalogGetDraftItemsRequest self, Interop.PFCatalogGetDraftItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateIds != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.AlternateIds, &interop->alternateIds, buffer, PFCatalogCatalogAlternateId.ToInterop);
                interop->alternateIdsCount = (uint)self.AlternateIds.Length;
            }

            if (self.ContinuationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ContinuationToken, &interop->continuationToken, buffer);
            }

            if (self.Count != null)
            {
                *interop->count = self.Count.Value;
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

            if (self.Ids != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Ids, &interop->ids, buffer);
                interop->idsCount = (uint)self.Ids.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetDraftItemsResponse data model.
    /// </summary>
    public struct PFCatalogGetDraftItemsResponse
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) A set of items created by the entity.
        /// </summary>
        public PFCatalogCatalogItem[]? Items;

        internal unsafe PFCatalogGetDraftItemsResponse(Interop.PFCatalogGetDraftItemsResponse interop)
        {

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

            Items = (interop.items == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.items, interop.itemsCount, elem => new PFCatalogCatalogItem(elem));

        }
            
    }

    /// <summary>
    /// PFCatalogGetEntityDraftItemsRequest data model.
    /// </summary>
    public struct PFCatalogGetEntityDraftItemsRequest
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items created by the caller, if any
        /// are available. Should be null on initial request.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// Number of items to retrieve. This value is optional. Default value is 10.
        /// </summary>
        public int Count;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) OData Filter to refine the items returned. CatalogItem properties 'type' can be used in
        /// the filter. For example: "type eq 'ugc'".
        /// </summary>
        public string? Filter;

        internal unsafe static void ToInterop(PFCatalogGetEntityDraftItemsRequest self, Interop.PFCatalogGetEntityDraftItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ContinuationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ContinuationToken, &interop->continuationToken, buffer);
            }

            interop->count = self.Count;

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

            if (self.Filter != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Filter, &interop->filter, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetEntityDraftItemsResponse data model.
    /// </summary>
    public struct PFCatalogGetEntityDraftItemsResponse
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) A set of items created by the entity.
        /// </summary>
        public PFCatalogCatalogItem[]? Items;

        internal unsafe PFCatalogGetEntityDraftItemsResponse(Interop.PFCatalogGetEntityDraftItemsResponse interop)
        {

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

            Items = (interop.items == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.items, interop.itemsCount, elem => new PFCatalogCatalogItem(elem));

        }
            
    }

    /// <summary>
    /// PFCatalogGetEntityItemReviewRequest data model.
    /// </summary>
    public struct PFCatalogGetEntityItemReviewRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogGetEntityItemReviewRequest self, Interop.PFCatalogGetEntityItemReviewRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
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

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogReview data model.
    /// </summary>
    public struct PFCatalogReview
    {
        /// <summary>
        /// (Optional) The star rating associated with each selected category in this review.
        /// </summary>
        public Dictionary<string, int>? CategoryRatings;

        /// <summary>
        /// The number of negative helpfulness votes for this review.
        /// </summary>
        public int HelpfulNegative;

        /// <summary>
        /// The number of positive helpfulness votes for this review.
        /// </summary>
        public int HelpfulPositive;

        /// <summary>
        /// Indicates whether the review author has the item installed.
        /// </summary>
        public bool IsInstalled;

        /// <summary>
        /// (Optional) The ID of the item being reviewed.
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) The version of the item being reviewed.
        /// </summary>
        public string? ItemVersion;

        /// <summary>
        /// (Optional) The locale for which this review was submitted in.
        /// </summary>
        public string? Locale;

        /// <summary>
        /// Star rating associated with this review.
        /// </summary>
        public int Rating;

        /// <summary>
        /// (Optional) The ID of the author of the review.
        /// </summary>
        public PFEntityKey? ReviewerEntity;

        /// <summary>
        /// (Optional) The ID of the review.
        /// </summary>
        public string? ReviewId;

        /// <summary>
        /// (Optional) The full text of this review.
        /// </summary>
        public string? ReviewText;

        /// <summary>
        /// The date and time this review was last submitted.
        /// </summary>
        public long Submitted;

        /// <summary>
        /// (Optional) The title of this review.
        /// </summary>
        public string? Title;

        internal unsafe PFCatalogReview(Interop.PFCatalogReview interop)
        {

            CategoryRatings = (interop.categoryRatings == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.categoryRatings, interop.categoryRatingsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            HelpfulNegative = interop.helpfulNegative;

            HelpfulPositive = interop.helpfulPositive;

            IsInstalled = InteropWrapper.WrapperHelpers.InteropToBool(interop.isInstalled);

            ItemId = (interop.itemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemId);

            ItemVersion = (interop.itemVersion == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemVersion);

            Locale = (interop.locale == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.locale);

            Rating = interop.rating;

            ReviewerEntity = (interop.reviewerEntity == null) ? null : new(*interop.reviewerEntity);

            ReviewId = (interop.reviewId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.reviewId);

            ReviewText = (interop.reviewText == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.reviewText);

            Submitted = interop.submitted;

            Title = (interop.title == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.title);

        }

        internal unsafe static void ToInterop(PFCatalogReview self, Interop.PFCatalogReview* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CategoryRatings != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.CategoryRatings, &interop->categoryRatings, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->categoryRatingsCount = (uint)self.CategoryRatings.Count;
            }

            interop->helpfulNegative = self.HelpfulNegative;

            interop->helpfulPositive = self.HelpfulPositive;

            interop->isInstalled = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsInstalled);

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.ItemVersion != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemVersion, &interop->itemVersion, buffer);
            }

            if (self.Locale != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Locale, &interop->locale, buffer);
            }

            interop->rating = self.Rating;

            if (self.ReviewerEntity != null)
            {
                interop->reviewerEntity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.ReviewerEntity.Value, interop->reviewerEntity, buffer);
            }

            if (self.ReviewId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ReviewId, &interop->reviewId, buffer);
            }

            if (self.ReviewText != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ReviewText, &interop->reviewText, buffer);
            }

            interop->submitted = self.Submitted;

            if (self.Title != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Title, &interop->title, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetEntityItemReviewResponse data model.
    /// </summary>
    public struct PFCatalogGetEntityItemReviewResponse
    {
        /// <summary>
        /// (Optional) The review the entity submitted for the requested item.
        /// </summary>
        public PFCatalogReview? Review;

        internal unsafe PFCatalogGetEntityItemReviewResponse(Interop.PFCatalogGetEntityItemReviewResponse interop)
        {

            Review = (interop.review == null) ? null : new(*interop.review);

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemRequest data model.
    /// </summary>
    public struct PFCatalogGetItemRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogGetItemRequest self, Interop.PFCatalogGetItemRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
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

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemResponse data model. Get item result.
    /// </summary>
    public struct PFCatalogGetItemResponse
    {
        /// <summary>
        /// (Optional) The item result.
        /// </summary>
        public PFCatalogCatalogItem? Item;

        internal unsafe PFCatalogGetItemResponse(Interop.PFCatalogGetItemResponse interop)
        {

            Item = (interop.item == null) ? null : new(*interop.item);

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemContainersRequest data model. Given an item, return a set of bundles and stores containing
    /// the item.
    /// </summary>
    public struct PFCatalogGetItemContainersRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items in the inventory, if any are available.
        /// Should be null on initial request.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// Number of items to retrieve. This value is optional. Default value is 10.
        /// </summary>
        public int Count;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogGetItemContainersRequest self, Interop.PFCatalogGetItemContainersRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.ContinuationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ContinuationToken, &interop->continuationToken, buffer);
            }

            interop->count = self.Count;

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

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemContainersResponse data model.
    /// </summary>
    public struct PFCatalogGetItemContainersResponse
    {
        /// <summary>
        /// (Optional) List of Bundles and Stores containing the requested items.
        /// </summary>
        public PFCatalogCatalogItem[]? Containers;

        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string? ContinuationToken;

        internal unsafe PFCatalogGetItemContainersResponse(Interop.PFCatalogGetItemContainersResponse interop)
        {

            Containers = (interop.containers == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.containers, interop.containersCount, elem => new PFCatalogCatalogItem(elem));

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemModerationStateRequest data model.
    /// </summary>
    public struct PFCatalogGetItemModerationStateRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogGetItemModerationStateRequest self, Interop.PFCatalogGetItemModerationStateRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemModerationStateResponse data model.
    /// </summary>
    public struct PFCatalogGetItemModerationStateResponse
    {
        /// <summary>
        /// (Optional) The current moderation state for the requested item.
        /// </summary>
        public PFCatalogModerationState? State;

        internal unsafe PFCatalogGetItemModerationStateResponse(Interop.PFCatalogGetItemModerationStateResponse interop)
        {

            State = (interop.state == null) ? null : new(*interop.state);

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemPublishStatusRequest data model.
    /// </summary>
    public struct PFCatalogGetItemPublishStatusRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogGetItemPublishStatusRequest self, Interop.PFCatalogGetItemPublishStatusRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
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

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemPublishStatusResponse data model.
    /// </summary>
    public struct PFCatalogGetItemPublishStatusResponse
    {
        /// <summary>
        /// (Optional) High level status of the published item.
        /// </summary>
        public PFCatalogPublishResult? Result;

        /// <summary>
        /// (Optional) Descriptive message about the current status of the publish.
        /// </summary>
        public string? StatusMessage;

        internal unsafe PFCatalogGetItemPublishStatusResponse(Interop.PFCatalogGetItemPublishStatusResponse interop)
        {

            Result = (interop.result == null) ? null : (PFCatalogPublishResult?)(*interop.result);

            StatusMessage = (interop.statusMessage == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.statusMessage);

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemReviewsRequest data model.
    /// </summary>
    public struct PFCatalogGetItemReviewsRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// Number of items to retrieve. This value is optional. Default value is 10.
        /// </summary>
        public int Count;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) An OData orderBy used to order the results of the query. Possible values are Helpfulness,
        /// Rating, and Submitted (For example: "Submitted desc").
        /// </summary>
        public string? OrderBy;

        internal unsafe static void ToInterop(PFCatalogGetItemReviewsRequest self, Interop.PFCatalogGetItemReviewsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.ContinuationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ContinuationToken, &interop->continuationToken, buffer);
            }

            interop->count = self.Count;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.OrderBy != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OrderBy, &interop->orderBy, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemReviewsResponse data model.
    /// </summary>
    public struct PFCatalogGetItemReviewsResponse
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) The paginated set of results.
        /// </summary>
        public PFCatalogReview[]? Reviews;

        internal unsafe PFCatalogGetItemReviewsResponse(Interop.PFCatalogGetItemReviewsResponse interop)
        {

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

            Reviews = (interop.reviews == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.reviews, interop.reviewsCount, elem => new PFCatalogReview(elem));

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemReviewSummaryRequest data model.
    /// </summary>
    public struct PFCatalogGetItemReviewSummaryRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogGetItemReviewSummaryRequest self, Interop.PFCatalogGetItemReviewSummaryRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemReviewSummaryResponse data model.
    /// </summary>
    public struct PFCatalogGetItemReviewSummaryResponse
    {
        /// <summary>
        /// (Optional) The least favorable review for this item.
        /// </summary>
        public PFCatalogReview? LeastFavorableReview;

        /// <summary>
        /// (Optional) The most favorable review for this item.
        /// </summary>
        public PFCatalogReview? MostFavorableReview;

        /// <summary>
        /// (Optional) The summary of ratings associated with this item.
        /// </summary>
        public PFCatalogRating? Rating;

        /// <summary>
        /// The total number of reviews associated with this item.
        /// </summary>
        public int ReviewsCount;

        internal unsafe PFCatalogGetItemReviewSummaryResponse(Interop.PFCatalogGetItemReviewSummaryResponse interop)
        {

            LeastFavorableReview = (interop.leastFavorableReview == null) ? null : new(*interop.leastFavorableReview);

            MostFavorableReview = (interop.mostFavorableReview == null) ? null : new(*interop.mostFavorableReview);

            Rating = (interop.rating == null) ? null : new(*interop.rating);

            ReviewsCount = interop.reviewsCount;

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemsRequest data model.
    /// </summary>
    public struct PFCatalogGetItemsRequest
    {
        /// <summary>
        /// (Optional) List of item alternate IDs.
        /// </summary>
        public PFCatalogCatalogAlternateId[]? AlternateIds;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) List of Item Ids.
        /// </summary>
        public string[]? Ids;

        internal unsafe static void ToInterop(PFCatalogGetItemsRequest self, Interop.PFCatalogGetItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateIds != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.AlternateIds, &interop->alternateIds, buffer, PFCatalogCatalogAlternateId.ToInterop);
                interop->alternateIdsCount = (uint)self.AlternateIds.Length;
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

            if (self.Ids != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Ids, &interop->ids, buffer);
                interop->idsCount = (uint)self.Ids.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogGetItemsResponse data model.
    /// </summary>
    public struct PFCatalogGetItemsResponse
    {
        /// <summary>
        /// (Optional) Metadata of set of items.
        /// </summary>
        public PFCatalogCatalogItem[]? Items;

        internal unsafe PFCatalogGetItemsResponse(Interop.PFCatalogGetItemsResponse interop)
        {

            Items = (interop.items == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.items, interop.itemsCount, elem => new PFCatalogCatalogItem(elem));

        }
            
    }

    /// <summary>
    /// PFCatalogPublishDraftItemRequest data model. The call kicks off a workflow to publish the item to
    /// the public catalog. The Publish Status API should be used to monitor the publish job.
    /// </summary>
    public struct PFCatalogPublishDraftItemRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) ETag of the catalog item to published from the working catalog to the public catalog.
        /// Used for optimistic concurrency. If the provided ETag does not match the ETag in the current working
        /// catalog, the request will be rejected. If not provided, the current version of the document in the
        /// working catalog will be published.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        internal unsafe static void ToInterop(PFCatalogPublishDraftItemRequest self, Interop.PFCatalogPublishDraftItemRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
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

            if (self.ETag != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ETag, &interop->eTag, buffer);
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogReportItemRequest data model.
    /// </summary>
    public struct PFCatalogReportItemRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) Category of concern for this report.
        /// </summary>
        public PFCatalogConcernCategory? ConcernCategory;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The string reason for this report.
        /// </summary>
        public string? Reason;

        internal unsafe static void ToInterop(PFCatalogReportItemRequest self, Interop.PFCatalogReportItemRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.ConcernCategory != null)
            {
                *interop->concernCategory = (Interop.PFCatalogConcernCategory)self.ConcernCategory.Value;
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

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.Reason != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Reason, &interop->reason, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogReportItemReviewRequest data model. Submit a report for an inappropriate review, allowing
    /// the submitting user to specify their concern.
    /// </summary>
    public struct PFCatalogReportItemReviewRequest
    {
        /// <summary>
        /// (Optional) An alternate ID of the item associated with the review.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The reason this review is being reported.
        /// </summary>
        public PFCatalogConcernCategory? ConcernCategory;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The string ID of the item associated with the review.
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) The string reason for this report.
        /// </summary>
        public string? Reason;

        /// <summary>
        /// (Optional) The ID of the review to submit a report for.
        /// </summary>
        public string? ReviewId;

        internal unsafe static void ToInterop(PFCatalogReportItemReviewRequest self, Interop.PFCatalogReportItemReviewRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.ConcernCategory != null)
            {
                *interop->concernCategory = (Interop.PFCatalogConcernCategory)self.ConcernCategory.Value;
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

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.Reason != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Reason, &interop->reason, buffer);
            }

            if (self.ReviewId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ReviewId, &interop->reviewId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogReviewItemRequest data model.
    /// </summary>
    public struct PFCatalogReviewItemRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The review to submit.
        /// </summary>
        public PFCatalogReview? Review;

        internal unsafe static void ToInterop(PFCatalogReviewItemRequest self, Interop.PFCatalogReviewItemRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
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

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.Review != null)
            {
                interop->review = (Interop.PFCatalogReview*)buffer.AddBuffer(sizeof(Interop.PFCatalogReview));
                PFCatalogReview.ToInterop(self.Review.Value, interop->review, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogStoreReference data model.
    /// </summary>
    public struct PFCatalogStoreReference
    {
        /// <summary>
        /// (Optional) An alternate ID of the store.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The unique ID of the store.
        /// </summary>
        public string? Id;

        internal unsafe PFCatalogStoreReference(Interop.PFCatalogStoreReference interop)
        {

            AlternateId = (interop.alternateId == null) ? null : new(*interop.alternateId);

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

        }

        internal unsafe static void ToInterop(PFCatalogStoreReference self, Interop.PFCatalogStoreReference* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogSearchItemsRequest data model.
    /// </summary>
    public struct PFCatalogSearchItemsRequest
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// Number of items to retrieve. This value is optional. Maximum page size is 50. Default value is 10.
        /// </summary>
        public int Count;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) An OData filter used to refine the search query (For example: "type eq 'ugc'"). More info
        /// about Filter Complexity limits can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search#limits.
        /// </summary>
        public string? Filter;

        /// <summary>
        /// (Optional) The locale to be returned in the result.
        /// </summary>
        public string? Language;

        /// <summary>
        /// (Optional) An OData orderBy used to order the results of the search query. For example: "rating/average
        /// asc" .
        /// </summary>
        public string? OrderBy;

        /// <summary>
        /// (Optional) The text to search for.
        /// </summary>
        public string? Search;

        /// <summary>
        /// (Optional) An OData select query option used to augment the search results. If not defined, the default
        /// search result metadata will be returned.
        /// </summary>
        public string? Select;

        /// <summary>
        /// (Optional) The store to restrict the search request to.
        /// </summary>
        public PFCatalogStoreReference? Store;

        internal unsafe static void ToInterop(PFCatalogSearchItemsRequest self, Interop.PFCatalogSearchItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ContinuationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ContinuationToken, &interop->continuationToken, buffer);
            }

            interop->count = self.Count;

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

            if (self.Filter != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Filter, &interop->filter, buffer);
            }

            if (self.Language != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Language, &interop->language, buffer);
            }

            if (self.OrderBy != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OrderBy, &interop->orderBy, buffer);
            }

            if (self.Search != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Search, &interop->search, buffer);
            }

            if (self.Select != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Select, &interop->select, buffer);
            }

            if (self.Store != null)
            {
                interop->store = (Interop.PFCatalogStoreReference*)buffer.AddBuffer(sizeof(Interop.PFCatalogStoreReference));
                PFCatalogStoreReference.ToInterop(self.Store.Value, interop->store, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogSearchItemsResponse data model.
    /// </summary>
    public struct PFCatalogSearchItemsResponse
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) The paginated set of results for the search query.
        /// </summary>
        public PFCatalogCatalogItem[]? Items;

        internal unsafe PFCatalogSearchItemsResponse(Interop.PFCatalogSearchItemsResponse interop)
        {

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

            Items = (interop.items == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.items, interop.itemsCount, elem => new PFCatalogCatalogItem(elem));

        }
            
    }

    /// <summary>
    /// PFCatalogSetItemModerationStateRequest data model.
    /// </summary>
    public struct PFCatalogSetItemModerationStateRequest
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The unique ID of the item.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The reason for the moderation state change for the associated item.
        /// </summary>
        public string? Reason;

        /// <summary>
        /// (Optional) The status to set for the associated item.
        /// </summary>
        public PFCatalogModerationStatus? Status;

        internal unsafe static void ToInterop(PFCatalogSetItemModerationStateRequest self, Interop.PFCatalogSetItemModerationStateRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.Reason != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Reason, &interop->reason, buffer);
            }

            if (self.Status != null)
            {
                *interop->status = (Interop.PFCatalogModerationStatus)self.Status.Value;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogSubmitItemReviewVoteRequest data model.
    /// </summary>
    public struct PFCatalogSubmitItemReviewVoteRequest
    {
        /// <summary>
        /// (Optional) An alternate ID of the item associated with the review.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) The string ID of the item associated with the review.
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) The ID of the review to submit a helpfulness vote for.
        /// </summary>
        public string? ReviewId;

        /// <summary>
        /// (Optional) The helpfulness vote of the review.
        /// </summary>
        public PFCatalogHelpfulnessVote? Vote;

        internal unsafe static void ToInterop(PFCatalogSubmitItemReviewVoteRequest self, Interop.PFCatalogSubmitItemReviewVoteRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
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

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.ReviewId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ReviewId, &interop->reviewId, buffer);
            }

            if (self.Vote != null)
            {
                *interop->vote = (Interop.PFCatalogHelpfulnessVote)self.Vote.Value;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogReviewTakedown data model.
    /// </summary>
    public struct PFCatalogReviewTakedown
    {
        /// <summary>
        /// (Optional) An alternate ID associated with this item.
        /// </summary>
        public PFCatalogCatalogAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The ID of the item associated with the review to take down.
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) The ID of the review to take down.
        /// </summary>
        public string? ReviewId;

        internal unsafe PFCatalogReviewTakedown(Interop.PFCatalogReviewTakedown interop)
        {

            AlternateId = (interop.alternateId == null) ? null : new(*interop.alternateId);

            ItemId = (interop.itemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemId);

            ReviewId = (interop.reviewId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.reviewId);

        }

        internal unsafe static void ToInterop(PFCatalogReviewTakedown self, Interop.PFCatalogReviewTakedown* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFCatalogCatalogAlternateId*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogAlternateId));
                PFCatalogCatalogAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.ReviewId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ReviewId, &interop->reviewId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFCatalogTakedownItemReviewsRequest data model. Submit a request to takedown one or more reviews,
    /// removing them from public view. Authors will still be able to see their reviews after being taken
    /// down.
    /// </summary>
    public struct PFCatalogTakedownItemReviewsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The set of reviews to take down.
        /// </summary>
        public PFCatalogReviewTakedown[]? Reviews;

        internal unsafe static void ToInterop(PFCatalogTakedownItemReviewsRequest self, Interop.PFCatalogTakedownItemReviewsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Reviews != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Reviews, &interop->reviews, buffer, PFCatalogReviewTakedown.ToInterop);
                interop->reviewsCount = (uint)self.Reviews.Length;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogUpdateCatalogConfigRequest data model.
    /// </summary>
    public struct PFCatalogUpdateCatalogConfigRequest
    {
        /// <summary>
        /// (Optional) The updated catalog configuration.
        /// </summary>
        public PFCatalogCatalogConfig? Config;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFCatalogUpdateCatalogConfigRequest self, Interop.PFCatalogUpdateCatalogConfigRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Config != null)
            {
                interop->config = (Interop.PFCatalogCatalogConfig*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogConfig));
                PFCatalogCatalogConfig.ToInterop(self.Config.Value, interop->config, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
            
    }

    /// <summary>
    /// PFCatalogUpdateDraftItemRequest data model.
    /// </summary>
    public struct PFCatalogUpdateDraftItemRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Updated metadata describing the catalog item to be updated.
        /// </summary>
        public PFCatalogCatalogItem? Item;

        /// <summary>
        /// Whether the item should be published immediately. This value is optional, defaults to false.
        /// </summary>
        public bool Publish;

        internal unsafe static void ToInterop(PFCatalogUpdateDraftItemRequest self, Interop.PFCatalogUpdateDraftItemRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFCatalogCatalogItem*)buffer.AddBuffer(sizeof(Interop.PFCatalogCatalogItem));
                PFCatalogCatalogItem.ToInterop(self.Item.Value, interop->item, buffer);
            }

            interop->publish = InteropWrapper.WrapperHelpers.BoolToInterop(self.Publish);

        }
            
    }

    /// <summary>
    /// PFCatalogUpdateDraftItemResponse data model.
    /// </summary>
    public struct PFCatalogUpdateDraftItemResponse
    {
        /// <summary>
        /// (Optional) Updated metadata describing the catalog item just updated.
        /// </summary>
        public PFCatalogCatalogItem? Item;

        internal unsafe PFCatalogUpdateDraftItemResponse(Interop.PFCatalogUpdateDraftItemResponse interop)
        {

            Item = (interop.item == null) ? null : new(*interop.item);

        }
            
    }

}
