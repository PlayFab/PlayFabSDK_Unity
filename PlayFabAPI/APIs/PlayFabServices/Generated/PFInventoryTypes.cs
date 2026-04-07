// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFInventoryAlternateId data model.
    /// </summary>
    public struct PFInventoryAlternateId
    {
        /// <summary>
        /// (Optional) Type of the alternate ID.
        /// </summary>
        public string? Type;

        /// <summary>
        /// (Optional) Value of the alternate ID.
        /// </summary>
        public string? Value;

        internal unsafe PFInventoryAlternateId(Interop.PFInventoryAlternateId interop)
        {

            Type = (interop.type == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.type);

            Value = (interop.value == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.value);

        }

        internal unsafe static void ToInterop(PFInventoryAlternateId self, Interop.PFInventoryAlternateId* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFInventoryInventoryItemReference data model.
    /// </summary>
    public struct PFInventoryInventoryItemReference
    {
        /// <summary>
        /// (Optional) The inventory item alternate id the request applies to.
        /// </summary>
        public PFInventoryAlternateId? AlternateId;

        /// <summary>
        /// (Optional) The inventory item id the request applies to.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The inventory stack id the request should redeem to. (Default="default").
        /// </summary>
        public string? StackId;

        internal unsafe PFInventoryInventoryItemReference(Interop.PFInventoryInventoryItemReference interop)
        {

            AlternateId = (interop.alternateId == null) ? null : new(*interop.alternateId);

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

            StackId = (interop.stackId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.stackId);

        }

        internal unsafe static void ToInterop(PFInventoryInventoryItemReference self, Interop.PFInventoryInventoryItemReference* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AlternateId != null)
            {
                interop->alternateId = (Interop.PFInventoryAlternateId*)buffer.AddBuffer(sizeof(Interop.PFInventoryAlternateId));
                PFInventoryAlternateId.ToInterop(self.AlternateId.Value, interop->alternateId, buffer);
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.StackId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StackId, &interop->stackId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryInitialValues data model.
    /// </summary>
    public struct PFInventoryInitialValues
    {
        /// <summary>
        /// (Optional) Game specific properties for display purposes. The Display Properties field has a 1000
        /// byte limit.
        /// </summary>
        public PFJsonObject DisplayProperties;

        internal unsafe PFInventoryInitialValues(Interop.PFInventoryInitialValues interop)
        {

            DisplayProperties = (interop.displayProperties.stringValue == null) ? default : new PFJsonObject(interop.displayProperties);

        }

        internal unsafe static void ToInterop(PFInventoryInitialValues self, Interop.PFInventoryInitialValues* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.DisplayProperties.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayProperties.stringValue, &interop->displayProperties.stringValue, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryAddInventoryItemsRequest data model. Given an entity type, entity identifier and container
    /// details, will add the specified inventory items.
    /// </summary>
    public struct PFInventoryAddInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The amount to add for the current item.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default"). The
        /// number of inventory collections is unlimited.
        /// </summary>
        public string? CollectionId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The duration to add to the current item expiration date.
        /// </summary>
        public double? DurationInSeconds;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The Idempotency ID for this request. Idempotency IDs can be used to prevent operation
        /// replay in the medium term but will be garbage collected eventually.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The inventory item the request applies to.
        /// </summary>
        public PFInventoryInventoryItemReference? Item;

        /// <summary>
        /// (Optional) The values to apply to a stack newly created by this request.
        /// </summary>
        public PFInventoryInitialValues? NewStackValues;

        internal unsafe static void ToInterop(PFInventoryAddInventoryItemsRequest self, Interop.PFInventoryAddInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.DurationInSeconds != null)
            {
                *interop->durationInSeconds = self.DurationInSeconds.Value;
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

            if (self.IdempotencyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IdempotencyId, &interop->idempotencyId, buffer);
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.Item.Value, interop->item, buffer);
            }

            if (self.NewStackValues != null)
            {
                interop->newStackValues = (Interop.PFInventoryInitialValues*)buffer.AddBuffer(sizeof(Interop.PFInventoryInitialValues));
                PFInventoryInitialValues.ToInterop(self.NewStackValues.Value, interop->newStackValues, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryAddInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryAddInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The idempotency id used in the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryAddInventoryItemsResponse(Interop.PFInventoryAddInventoryItemsResponse interop)
        {

            ETag = (interop.eTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.eTag);

            IdempotencyId = (interop.idempotencyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.idempotencyId);

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryDeleteInventoryCollectionRequest data model. Delete an Inventory Collection by the specified
    /// Id for an Entity.
    /// </summary>
    public struct PFInventoryDeleteInventoryCollectionRequest
    {
        /// <summary>
        /// (Optional) The inventory collection id the request applies to.
        /// </summary>
        public string? CollectionId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity the request is about. Set to the caller by default.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        internal unsafe static void ToInterop(PFInventoryDeleteInventoryCollectionRequest self, Interop.PFInventoryDeleteInventoryCollectionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

        }
            
    }

    /// <summary>
    /// PFInventoryDeleteInventoryItemsRequest data model. Given an entity type, entity identifier and container
    /// details, will delete the entity's inventory items.
    /// </summary>
    public struct PFInventoryDeleteInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default"). The
        /// number of inventory collections is unlimited.
        /// </summary>
        public string? CollectionId;

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
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The Idempotency ID for this request. Idempotency IDs can be used to prevent operation
        /// replay in the medium term but will be garbage collected eventually.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The inventory item the request applies to.
        /// </summary>
        public PFInventoryInventoryItemReference? Item;

        internal unsafe static void ToInterop(PFInventoryDeleteInventoryItemsRequest self, Interop.PFInventoryDeleteInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.IdempotencyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IdempotencyId, &interop->idempotencyId, buffer);
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.Item.Value, interop->item, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryDeleteInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryDeleteInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The idempotency id used in the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryDeleteInventoryItemsResponse(Interop.PFInventoryDeleteInventoryItemsResponse interop)
        {

            ETag = (interop.eTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.eTag);

            IdempotencyId = (interop.idempotencyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.idempotencyId);

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryAddInventoryItemsOperation data model.
    /// </summary>
    public struct PFInventoryAddInventoryItemsOperation
    {
        /// <summary>
        /// (Optional) The amount to add to the current item amount.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// (Optional) The duration to add to the current item expiration date.
        /// </summary>
        public double? DurationInSeconds;

        /// <summary>
        /// (Optional) The inventory item the operation applies to.
        /// </summary>
        public PFInventoryInventoryItemReference? Item;

        /// <summary>
        /// (Optional) The values to apply to a stack newly created by this operation.
        /// </summary>
        public PFInventoryInitialValues? NewStackValues;

        internal unsafe PFInventoryAddInventoryItemsOperation(Interop.PFInventoryAddInventoryItemsOperation interop)
        {

            Amount = (interop.amount == null) ? null : *interop.amount;

            DurationInSeconds = (interop.durationInSeconds == null) ? null : *interop.durationInSeconds;

            Item = (interop.item == null) ? null : new(*interop.item);

            NewStackValues = (interop.newStackValues == null) ? null : new(*interop.newStackValues);

        }

        internal unsafe static void ToInterop(PFInventoryAddInventoryItemsOperation self, Interop.PFInventoryAddInventoryItemsOperation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            if (self.DurationInSeconds != null)
            {
                *interop->durationInSeconds = self.DurationInSeconds.Value;
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.Item.Value, interop->item, buffer);
            }

            if (self.NewStackValues != null)
            {
                interop->newStackValues = (Interop.PFInventoryInitialValues*)buffer.AddBuffer(sizeof(Interop.PFInventoryInitialValues));
                PFInventoryInitialValues.ToInterop(self.NewStackValues.Value, interop->newStackValues, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryDeleteInventoryItemsOperation data model.
    /// </summary>
    public struct PFInventoryDeleteInventoryItemsOperation
    {
        /// <summary>
        /// (Optional) The inventory item the operation applies to.
        /// </summary>
        public PFInventoryInventoryItemReference? Item;

        internal unsafe PFInventoryDeleteInventoryItemsOperation(Interop.PFInventoryDeleteInventoryItemsOperation interop)
        {

            Item = (interop.item == null) ? null : new(*interop.item);

        }

        internal unsafe static void ToInterop(PFInventoryDeleteInventoryItemsOperation self, Interop.PFInventoryDeleteInventoryItemsOperation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.Item.Value, interop->item, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryPurchasePriceAmount data model.
    /// </summary>
    public struct PFInventoryPurchasePriceAmount
    {
        /// <summary>
        /// The amount of the inventory item to use in the purchase .
        /// </summary>
        public int Amount;

        /// <summary>
        /// (Optional) The inventory item id to use in the purchase .
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) The inventory stack id the to use in the purchase. Set to "default" by default.
        /// </summary>
        public string? StackId;

        internal unsafe PFInventoryPurchasePriceAmount(Interop.PFInventoryPurchasePriceAmount interop)
        {

            Amount = interop.amount;

            ItemId = (interop.itemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemId);

            StackId = (interop.stackId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.stackId);

        }

        internal unsafe static void ToInterop(PFInventoryPurchasePriceAmount self, Interop.PFInventoryPurchasePriceAmount* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->amount = self.Amount;

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.StackId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StackId, &interop->stackId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryPurchaseInventoryItemsOperation data model.
    /// </summary>
    public struct PFInventoryPurchaseInventoryItemsOperation
    {
        /// <summary>
        /// (Optional) The amount to purchase.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the operation should be deleted from the
        /// inventory. (Default = false).
        /// </summary>
        public bool DeleteEmptyStacks;

        /// <summary>
        /// (Optional) The duration to purchase.
        /// </summary>
        public double? DurationInSeconds;

        /// <summary>
        /// (Optional) The inventory item the operation applies to.
        /// </summary>
        public PFInventoryInventoryItemReference? Item;

        /// <summary>
        /// (Optional) The values to apply to a stack newly created by this operation.
        /// </summary>
        public PFInventoryInitialValues? NewStackValues;

        /// <summary>
        /// (Optional) The per-item price the item is expected to be purchased at. This must match a value configured
        /// in the Catalog or specified Store.
        /// </summary>
        public PFInventoryPurchasePriceAmount[]? PriceAmounts;

        /// <summary>
        /// (Optional) The id of the Store to purchase the item from.
        /// </summary>
        public string? StoreId;

        internal unsafe PFInventoryPurchaseInventoryItemsOperation(Interop.PFInventoryPurchaseInventoryItemsOperation interop)
        {

            Amount = (interop.amount == null) ? null : *interop.amount;

            DeleteEmptyStacks = InteropWrapper.WrapperHelpers.InteropToBool(interop.deleteEmptyStacks);

            DurationInSeconds = (interop.durationInSeconds == null) ? null : *interop.durationInSeconds;

            Item = (interop.item == null) ? null : new(*interop.item);

            NewStackValues = (interop.newStackValues == null) ? null : new(*interop.newStackValues);

            PriceAmounts = (interop.priceAmounts == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.priceAmounts, interop.priceAmountsCount, elem => new PFInventoryPurchasePriceAmount(elem));

            StoreId = (interop.storeId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.storeId);

        }

        internal unsafe static void ToInterop(PFInventoryPurchaseInventoryItemsOperation self, Interop.PFInventoryPurchaseInventoryItemsOperation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            interop->deleteEmptyStacks = InteropWrapper.WrapperHelpers.BoolToInterop(self.DeleteEmptyStacks);

            if (self.DurationInSeconds != null)
            {
                *interop->durationInSeconds = self.DurationInSeconds.Value;
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.Item.Value, interop->item, buffer);
            }

            if (self.NewStackValues != null)
            {
                interop->newStackValues = (Interop.PFInventoryInitialValues*)buffer.AddBuffer(sizeof(Interop.PFInventoryInitialValues));
                PFInventoryInitialValues.ToInterop(self.NewStackValues.Value, interop->newStackValues, buffer);
            }

            if (self.PriceAmounts != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.PriceAmounts, &interop->priceAmounts, buffer, PFInventoryPurchasePriceAmount.ToInterop);
                interop->priceAmountsCount = (uint)self.PriceAmounts.Length;
            }

            if (self.StoreId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StoreId, &interop->storeId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventorySubtractInventoryItemsOperation data model.
    /// </summary>
    public struct PFInventorySubtractInventoryItemsOperation
    {
        /// <summary>
        /// (Optional) The amount to subtract from the current item amount.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the request should be deleted from the
        /// inventory. (Default = false).
        /// </summary>
        public bool DeleteEmptyStacks;

        /// <summary>
        /// (Optional) The duration to subtract from the current item expiration date.
        /// </summary>
        public double? DurationInSeconds;

        /// <summary>
        /// (Optional) The inventory item the operation applies to.
        /// </summary>
        public PFInventoryInventoryItemReference? Item;

        internal unsafe PFInventorySubtractInventoryItemsOperation(Interop.PFInventorySubtractInventoryItemsOperation interop)
        {

            Amount = (interop.amount == null) ? null : *interop.amount;

            DeleteEmptyStacks = InteropWrapper.WrapperHelpers.InteropToBool(interop.deleteEmptyStacks);

            DurationInSeconds = (interop.durationInSeconds == null) ? null : *interop.durationInSeconds;

            Item = (interop.item == null) ? null : new(*interop.item);

        }

        internal unsafe static void ToInterop(PFInventorySubtractInventoryItemsOperation self, Interop.PFInventorySubtractInventoryItemsOperation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            interop->deleteEmptyStacks = InteropWrapper.WrapperHelpers.BoolToInterop(self.DeleteEmptyStacks);

            if (self.DurationInSeconds != null)
            {
                *interop->durationInSeconds = self.DurationInSeconds.Value;
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.Item.Value, interop->item, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryTransferInventoryItemsOperation data model.
    /// </summary>
    public struct PFInventoryTransferInventoryItemsOperation
    {
        /// <summary>
        /// (Optional) The amount to transfer.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the operation should be deleted from the
        /// inventory. (Default = false).
        /// </summary>
        public bool DeleteEmptyStacks;

        /// <summary>
        /// (Optional) The inventory item the operation is transferring from.
        /// </summary>
        public PFInventoryInventoryItemReference? GivingItem;

        /// <summary>
        /// (Optional) The values to apply to a stack newly created by this operation.
        /// </summary>
        public PFInventoryInitialValues? NewStackValues;

        /// <summary>
        /// (Optional) The inventory item the operation is transferring to.
        /// </summary>
        public PFInventoryInventoryItemReference? ReceivingItem;

        internal unsafe PFInventoryTransferInventoryItemsOperation(Interop.PFInventoryTransferInventoryItemsOperation interop)
        {

            Amount = (interop.amount == null) ? null : *interop.amount;

            DeleteEmptyStacks = InteropWrapper.WrapperHelpers.InteropToBool(interop.deleteEmptyStacks);

            GivingItem = (interop.givingItem == null) ? null : new(*interop.givingItem);

            NewStackValues = (interop.newStackValues == null) ? null : new(*interop.newStackValues);

            ReceivingItem = (interop.receivingItem == null) ? null : new(*interop.receivingItem);

        }

        internal unsafe static void ToInterop(PFInventoryTransferInventoryItemsOperation self, Interop.PFInventoryTransferInventoryItemsOperation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            interop->deleteEmptyStacks = InteropWrapper.WrapperHelpers.BoolToInterop(self.DeleteEmptyStacks);

            if (self.GivingItem != null)
            {
                interop->givingItem = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.GivingItem.Value, interop->givingItem, buffer);
            }

            if (self.NewStackValues != null)
            {
                interop->newStackValues = (Interop.PFInventoryInitialValues*)buffer.AddBuffer(sizeof(Interop.PFInventoryInitialValues));
                PFInventoryInitialValues.ToInterop(self.NewStackValues.Value, interop->newStackValues, buffer);
            }

            if (self.ReceivingItem != null)
            {
                interop->receivingItem = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.ReceivingItem.Value, interop->receivingItem, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryInventoryItem data model.
    /// </summary>
    public struct PFInventoryInventoryItem
    {
        /// <summary>
        /// (Optional) The amount of the item.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// (Optional) Game specific properties for display purposes. This is an arbitrary JSON blob. The Display
        /// Properties field has a 1000 byte limit.
        /// </summary>
        public PFJsonObject DisplayProperties;

        /// <summary>
        /// (Optional) Only used for subscriptions. The date of when the item will expire in UTC.
        /// </summary>
        public long? ExpirationDate;

        /// <summary>
        /// (Optional) The id of the item. This should correspond to the item id in the catalog.
        /// </summary>
        public string? Id;

        /// <summary>
        /// (Optional) The stack id of the item.
        /// </summary>
        public string? StackId;

        /// <summary>
        /// (Optional) Only used for subscriptions. The date of when the item started in UTC.
        /// </summary>
        public long? StartDate;

        /// <summary>
        /// (Optional) The type of the item. This should correspond to the item type in the catalog.
        /// </summary>
        public string? Type;

        internal unsafe PFInventoryInventoryItem(Interop.PFInventoryInventoryItem interop)
        {

            Amount = (interop.amount == null) ? null : *interop.amount;

            DisplayProperties = (interop.displayProperties.stringValue == null) ? default : new PFJsonObject(interop.displayProperties);

            ExpirationDate = (interop.expirationDate == null) ? null : *interop.expirationDate;

            Id = (interop.id == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.id);

            StackId = (interop.stackId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.stackId);

            StartDate = (interop.startDate == null) ? null : *interop.startDate;

            Type = (interop.type == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.type);

        }

        internal unsafe static void ToInterop(PFInventoryInventoryItem self, Interop.PFInventoryInventoryItem* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            if (self.DisplayProperties.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayProperties.stringValue, &interop->displayProperties.stringValue, buffer);
            }

            if (self.ExpirationDate != null)
            {
                *interop->expirationDate = self.ExpirationDate.Value;
            }

            if (self.Id != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);
            }

            if (self.StackId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StackId, &interop->stackId, buffer);
            }

            if (self.StartDate != null)
            {
                *interop->startDate = self.StartDate.Value;
            }

            if (self.Type != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Type, &interop->type, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryUpdateInventoryItemsOperation data model.
    /// </summary>
    public struct PFInventoryUpdateInventoryItemsOperation
    {
        /// <summary>
        /// (Optional) The inventory item to update with the specified values.
        /// </summary>
        public PFInventoryInventoryItem? Item;

        internal unsafe PFInventoryUpdateInventoryItemsOperation(Interop.PFInventoryUpdateInventoryItemsOperation interop)
        {

            Item = (interop.item == null) ? null : new(*interop.item);

        }

        internal unsafe static void ToInterop(PFInventoryUpdateInventoryItemsOperation self, Interop.PFInventoryUpdateInventoryItemsOperation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItem*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItem));
                PFInventoryInventoryItem.ToInterop(self.Item.Value, interop->item, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryInventoryOperation data model.
    /// </summary>
    public struct PFInventoryInventoryOperation
    {
        /// <summary>
        /// (Optional) The add operation.
        /// </summary>
        public PFInventoryAddInventoryItemsOperation? Add;

        /// <summary>
        /// (Optional) The delete operation.
        /// </summary>
        public PFInventoryDeleteInventoryItemsOperation? DeleteOp;

        /// <summary>
        /// (Optional) The purchase operation.
        /// </summary>
        public PFInventoryPurchaseInventoryItemsOperation? Purchase;

        /// <summary>
        /// (Optional) The subtract operation.
        /// </summary>
        public PFInventorySubtractInventoryItemsOperation? Subtract;

        /// <summary>
        /// (Optional) The transfer operation.
        /// </summary>
        public PFInventoryTransferInventoryItemsOperation? Transfer;

        /// <summary>
        /// (Optional) The update operation.
        /// </summary>
        public PFInventoryUpdateInventoryItemsOperation? Update;

        internal unsafe PFInventoryInventoryOperation(Interop.PFInventoryInventoryOperation interop)
        {

            Add = (interop.add == null) ? null : new(*interop.add);

            DeleteOp = (interop.deleteOp == null) ? null : new(*interop.deleteOp);

            Purchase = (interop.purchase == null) ? null : new(*interop.purchase);

            Subtract = (interop.subtract == null) ? null : new(*interop.subtract);

            Transfer = (interop.transfer == null) ? null : new(*interop.transfer);

            Update = (interop.update == null) ? null : new(*interop.update);

        }

        internal unsafe static void ToInterop(PFInventoryInventoryOperation self, Interop.PFInventoryInventoryOperation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Add != null)
            {
                interop->add = (Interop.PFInventoryAddInventoryItemsOperation*)buffer.AddBuffer(sizeof(Interop.PFInventoryAddInventoryItemsOperation));
                PFInventoryAddInventoryItemsOperation.ToInterop(self.Add.Value, interop->add, buffer);
            }

            if (self.DeleteOp != null)
            {
                interop->deleteOp = (Interop.PFInventoryDeleteInventoryItemsOperation*)buffer.AddBuffer(sizeof(Interop.PFInventoryDeleteInventoryItemsOperation));
                PFInventoryDeleteInventoryItemsOperation.ToInterop(self.DeleteOp.Value, interop->deleteOp, buffer);
            }

            if (self.Purchase != null)
            {
                interop->purchase = (Interop.PFInventoryPurchaseInventoryItemsOperation*)buffer.AddBuffer(sizeof(Interop.PFInventoryPurchaseInventoryItemsOperation));
                PFInventoryPurchaseInventoryItemsOperation.ToInterop(self.Purchase.Value, interop->purchase, buffer);
            }

            if (self.Subtract != null)
            {
                interop->subtract = (Interop.PFInventorySubtractInventoryItemsOperation*)buffer.AddBuffer(sizeof(Interop.PFInventorySubtractInventoryItemsOperation));
                PFInventorySubtractInventoryItemsOperation.ToInterop(self.Subtract.Value, interop->subtract, buffer);
            }

            if (self.Transfer != null)
            {
                interop->transfer = (Interop.PFInventoryTransferInventoryItemsOperation*)buffer.AddBuffer(sizeof(Interop.PFInventoryTransferInventoryItemsOperation));
                PFInventoryTransferInventoryItemsOperation.ToInterop(self.Transfer.Value, interop->transfer, buffer);
            }

            if (self.Update != null)
            {
                interop->update = (Interop.PFInventoryUpdateInventoryItemsOperation*)buffer.AddBuffer(sizeof(Interop.PFInventoryUpdateInventoryItemsOperation));
                PFInventoryUpdateInventoryItemsOperation.ToInterop(self.Update.Value, interop->update, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryExecuteInventoryOperationsRequest data model. Execute a list of Inventory Operations for
    /// an Entity.
    /// </summary>
    public struct PFInventoryExecuteInventoryOperationsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default"). The
        /// number of inventory collections is unlimited.
        /// </summary>
        public string? CollectionId;

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
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The Idempotency ID for this request. Idempotency IDs can be used to prevent operation
        /// replay in the medium term but will be garbage collected eventually.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The operations to run transactionally. The operations will be executed in-order sequentially
        /// and will succeed or fail as a batch. Up to 50 operations can be added.
        /// </summary>
        public PFInventoryInventoryOperation[]? Operations;

        internal unsafe static void ToInterop(PFInventoryExecuteInventoryOperationsRequest self, Interop.PFInventoryExecuteInventoryOperationsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.IdempotencyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IdempotencyId, &interop->idempotencyId, buffer);
            }

            if (self.Operations != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Operations, &interop->operations, buffer, PFInventoryInventoryOperation.ToInterop);
                interop->operationsCount = (uint)self.Operations.Length;
            }

        }
            
    }

    /// <summary>
    /// PFInventoryExecuteInventoryOperationsResponse data model.
    /// </summary>
    public struct PFInventoryExecuteInventoryOperationsResponse
    {
        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The idempotency id used in the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The ids of the transactions that occurred as a result of the request.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryExecuteInventoryOperationsResponse(Interop.PFInventoryExecuteInventoryOperationsResponse interop)
        {

            ETag = (interop.eTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.eTag);

            IdempotencyId = (interop.idempotencyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.idempotencyId);

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryExecuteTransferOperationsRequest data model. Transfer the specified list of inventory
    /// items of an entity's container Id to another entity's container Id.
    /// </summary>
    public struct PFInventoryExecuteTransferOperationsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The inventory collection id the request is transferring from. (Default="default").
        /// </summary>
        public string? GivingCollectionId;

        /// <summary>
        /// (Optional) The entity the request is transferring from. Set to the caller by default.
        /// </summary>
        public PFEntityKey? GivingEntity;

        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? GivingETag;

        /// <summary>
        /// (Optional) The idempotency id for the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The transfer operations to run transactionally. The operations will be executed in-order
        /// sequentially and will succeed or fail as a batch. Up to 50 operations can be added.
        /// </summary>
        public PFInventoryTransferInventoryItemsOperation[]? Operations;

        /// <summary>
        /// (Optional) The inventory collection id the request is transferring to. (Default="default").
        /// </summary>
        public string? ReceivingCollectionId;

        /// <summary>
        /// (Optional) The entity the request is transferring to. Set to the caller by default.
        /// </summary>
        public PFEntityKey? ReceivingEntity;

        internal unsafe static void ToInterop(PFInventoryExecuteTransferOperationsRequest self, Interop.PFInventoryExecuteTransferOperationsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.GivingCollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GivingCollectionId, &interop->givingCollectionId, buffer);
            }

            if (self.GivingEntity != null)
            {
                interop->givingEntity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.GivingEntity.Value, interop->givingEntity, buffer);
            }

            if (self.GivingETag != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GivingETag, &interop->givingETag, buffer);
            }

            if (self.IdempotencyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IdempotencyId, &interop->idempotencyId, buffer);
            }

            if (self.Operations != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Operations, &interop->operations, buffer, PFInventoryTransferInventoryItemsOperation.ToInterop);
                interop->operationsCount = (uint)self.Operations.Length;
            }

            if (self.ReceivingCollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ReceivingCollectionId, &interop->receivingCollectionId, buffer);
            }

            if (self.ReceivingEntity != null)
            {
                interop->receivingEntity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.ReceivingEntity.Value, interop->receivingEntity, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryExecuteTransferOperationsResponse data model.
    /// </summary>
    public struct PFInventoryExecuteTransferOperationsResponse
    {
        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources (before transferring from).
        /// This value will be empty if the operation has not completed yet. More information about using ETags
        /// can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? GivingETag;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request's giving action.
        /// </summary>
        public string[]? GivingTransactionIds;

        /// <summary>
        /// (Optional) The Idempotency ID for this request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The transfer operation status. Possible values are 'InProgress' or 'Completed'. If the
        /// operation has completed, the response code will be 200. Otherwise, it will be 202.
        /// </summary>
        public string? OperationStatus;

        /// <summary>
        /// (Optional) The token that can be used to get the status of the transfer operation. This will only
        /// have a value if OperationStatus is 'InProgress'.
        /// </summary>
        public string? OperationToken;

        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources (before transferring to).
        /// This value will be empty if the operation has not completed yet.
        /// </summary>
        public string? ReceivingETag;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request's receiving action.
        /// </summary>
        public string[]? ReceivingTransactionIds;

        internal unsafe PFInventoryExecuteTransferOperationsResponse(Interop.PFInventoryExecuteTransferOperationsResponse interop)
        {

            GivingETag = (interop.givingETag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.givingETag);

            GivingTransactionIds = (interop.givingTransactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.givingTransactionIds, interop.givingTransactionIdsCount);

            IdempotencyId = (interop.idempotencyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.idempotencyId);

            OperationStatus = (interop.operationStatus == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationStatus);

            OperationToken = (interop.operationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationToken);

            ReceivingETag = (interop.receivingETag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.receivingETag);

            ReceivingTransactionIds = (interop.receivingTransactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.receivingTransactionIds, interop.receivingTransactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryGetInventoryCollectionIdsRequest data model. Get a list of Inventory Collection Ids for
    /// the specified Entity.
    /// </summary>
    public struct PFInventoryGetInventoryCollectionIdsRequest
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of collection ids, if any are available.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// Number of items to retrieve. This value is optional. The default value is 10.
        /// </summary>
        public int Count;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity the request is about. Set to the caller by default.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe static void ToInterop(PFInventoryGetInventoryCollectionIdsRequest self, Interop.PFInventoryGetInventoryCollectionIdsRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

        }
            
    }

    /// <summary>
    /// PFInventoryGetInventoryCollectionIdsResponse data model.
    /// </summary>
    public struct PFInventoryGetInventoryCollectionIdsResponse
    {
        /// <summary>
        /// (Optional) The requested inventory collection ids.
        /// </summary>
        public string[]? CollectionIds;

        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of collection ids, if any are available.
        /// </summary>
        public string? ContinuationToken;

        internal unsafe PFInventoryGetInventoryCollectionIdsResponse(Interop.PFInventoryGetInventoryCollectionIdsResponse interop)
        {

            CollectionIds = (interop.collectionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.collectionIds, interop.collectionIdsCount);

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

        }
            
    }

    /// <summary>
    /// PFInventoryGetInventoryItemsRequest data model. Given an entity type, entity identifier and container
    /// details, will get the entity's inventory items. .
    /// </summary>
    public struct PFInventoryGetInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items in the inventory, if any are available.
        /// Should be null on initial request.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// Number of items to retrieve. This value is optional. Maximum page size is 50. The default value is
        /// 10.
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
        /// (Optional) OData Filter to refine the items returned. InventoryItem properties 'type', 'id', and
        /// 'stackId' can be used in the filter. For example: "type eq 'currency'".
        /// </summary>
        public string? Filter;

        internal unsafe static void ToInterop(PFInventoryGetInventoryItemsRequest self, Interop.PFInventoryGetInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.Filter != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Filter, &interop->filter, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryGetInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryGetInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The requested inventory items.
        /// </summary>
        public PFInventoryInventoryItem[]? Items;

        internal unsafe PFInventoryGetInventoryItemsResponse(Interop.PFInventoryGetInventoryItemsResponse interop)
        {

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

            ETag = (interop.eTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.eTag);

            Items = (interop.items == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.items, interop.itemsCount, elem => new PFInventoryInventoryItem(elem));

        }
            
    }

    /// <summary>
    /// PFInventoryGetInventoryOperationStatusRequest data model. Get the status of an Inventory Operation
    /// using an OperationToken.
    /// </summary>
    public struct PFInventoryGetInventoryOperationStatusRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

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
        /// (Optional) The token to get the status of the inventory operation.
        /// </summary>
        public string? OperationToken;

        internal unsafe static void ToInterop(PFInventoryGetInventoryOperationStatusRequest self, Interop.PFInventoryGetInventoryOperationStatusRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.OperationToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OperationToken, &interop->operationToken, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryGetInventoryOperationStatusResponse data model.
    /// </summary>
    public struct PFInventoryGetInventoryOperationStatusResponse
    {
        /// <summary>
        /// (Optional) The inventory operation status.
        /// </summary>
        public string? OperationStatus;

        internal unsafe PFInventoryGetInventoryOperationStatusResponse(Interop.PFInventoryGetInventoryOperationStatusResponse interop)
        {

            OperationStatus = (interop.operationStatus == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationStatus);

        }
            
    }

    /// <summary>
    /// PFInventoryGetTransactionHistoryRequest data model. Get transaction history for specified entity
    /// and collection.
    /// </summary>
    public struct PFInventoryGetTransactionHistoryRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available. Should
        /// be null on initial request.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// Number of items to retrieve. This value is optional. The default value is 10.
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
        /// (Optional) An OData filter used to refine the TransactionHistory. Transaction properties 'timestamp',
        /// 'transactionid', 'apiname' and 'operationtype' can be used in the filter. Properties 'transactionid',
        /// 'apiname', and 'operationtype' cannot be used together in a single request. The 'timestamp' property
        /// can be combined with 'apiname' or 'operationtype' in a single request. For example: "timestamp ge
        /// 2023-06-20T23:30Z" or "transactionid eq '10'" or "(timestamp ge 2023-06-20T23:30Z) and (apiname eq
        /// 'AddInventoryItems')". By default, a 6 month timespan from the current date is used.
        /// </summary>
        public string? Filter;

        /// <summary>
        /// (Optional) An OData orderby to order TransactionHistory results. The only supported values are 'timestamp
        /// asc' or 'timestamp desc'. Default orderby is 'timestamp asc'.
        /// </summary>
        public string? OrderBy;

        internal unsafe static void ToInterop(PFInventoryGetTransactionHistoryRequest self, Interop.PFInventoryGetTransactionHistoryRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.Filter != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Filter, &interop->filter, buffer);
            }

            if (self.OrderBy != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OrderBy, &interop->orderBy, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryTransactionClawbackDetails data model.
    /// </summary>
    public struct PFInventoryTransactionClawbackDetails
    {
        /// <summary>
        /// (Optional) The id of the clawed back operation.
        /// </summary>
        public string? TransactionIdClawedback;

        internal unsafe PFInventoryTransactionClawbackDetails(Interop.PFInventoryTransactionClawbackDetails interop)
        {

            TransactionIdClawedback = (interop.transactionIdClawedback == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.transactionIdClawedback);

        }

        internal unsafe static void ToInterop(PFInventoryTransactionClawbackDetails self, Interop.PFInventoryTransactionClawbackDetails* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.TransactionIdClawedback != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TransactionIdClawedback, &interop->transactionIdClawedback, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryTransactionOperation data model.
    /// </summary>
    public struct PFInventoryTransactionOperation
    {
        /// <summary>
        /// (Optional) The amount of items in this transaction.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// (Optional) The duration modified in this transaction.
        /// </summary>
        public double? DurationInSeconds;

        /// <summary>
        /// (Optional) The friendly id of the items in this transaction.
        /// </summary>
        public string? ItemFriendlyId;

        /// <summary>
        /// (Optional) The item id of the items in this transaction.
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) The type of item that the operation occurred on.
        /// </summary>
        public string? ItemType;

        /// <summary>
        /// (Optional) The stack id of the items in this transaction.
        /// </summary>
        public string? StackId;

        /// <summary>
        /// (Optional) The type of the operation that occurred.
        /// </summary>
        public string? Type;

        internal unsafe PFInventoryTransactionOperation(Interop.PFInventoryTransactionOperation interop)
        {

            Amount = (interop.amount == null) ? null : *interop.amount;

            DurationInSeconds = (interop.durationInSeconds == null) ? null : *interop.durationInSeconds;

            ItemFriendlyId = (interop.itemFriendlyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemFriendlyId);

            ItemId = (interop.itemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemId);

            ItemType = (interop.itemType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemType);

            StackId = (interop.stackId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.stackId);

            Type = (interop.type == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.type);

        }

        internal unsafe static void ToInterop(PFInventoryTransactionOperation self, Interop.PFInventoryTransactionOperation* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            if (self.DurationInSeconds != null)
            {
                *interop->durationInSeconds = self.DurationInSeconds.Value;
            }

            if (self.ItemFriendlyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemFriendlyId, &interop->itemFriendlyId, buffer);
            }

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.ItemType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemType, &interop->itemType, buffer);
            }

            if (self.StackId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StackId, &interop->stackId, buffer);
            }

            if (self.Type != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Type, &interop->type, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryTransactionPurchaseDetails data model.
    /// </summary>
    public struct PFInventoryTransactionPurchaseDetails
    {
        /// <summary>
        /// (Optional) The friendly id of the item that was purchased.
        /// </summary>
        public string? ItemFriendlyId;

        /// <summary>
        /// (Optional) The id of the item that was purchased.
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) The friendly id of the Store the item was purchased from or null.
        /// </summary>
        public string? StoreFriendlyId;

        /// <summary>
        /// (Optional) The id of the Store the item was purchased from or null.
        /// </summary>
        public string? StoreId;

        internal unsafe PFInventoryTransactionPurchaseDetails(Interop.PFInventoryTransactionPurchaseDetails interop)
        {

            ItemFriendlyId = (interop.itemFriendlyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemFriendlyId);

            ItemId = (interop.itemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemId);

            StoreFriendlyId = (interop.storeFriendlyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.storeFriendlyId);

            StoreId = (interop.storeId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.storeId);

        }

        internal unsafe static void ToInterop(PFInventoryTransactionPurchaseDetails self, Interop.PFInventoryTransactionPurchaseDetails* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ItemFriendlyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemFriendlyId, &interop->itemFriendlyId, buffer);
            }

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.StoreFriendlyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StoreFriendlyId, &interop->storeFriendlyId, buffer);
            }

            if (self.StoreId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StoreId, &interop->storeId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryTransactionRedeemDetails data model.
    /// </summary>
    public struct PFInventoryTransactionRedeemDetails
    {
        /// <summary>
        /// (Optional) The marketplace that the offer is being redeemed from.
        /// </summary>
        public string? Marketplace;

        /// <summary>
        /// (Optional) The transaction Id returned from the marketplace.
        /// </summary>
        public string? MarketplaceTransactionId;

        /// <summary>
        /// (Optional) The offer Id of the item being redeemed.
        /// </summary>
        public string? OfferId;

        internal unsafe PFInventoryTransactionRedeemDetails(Interop.PFInventoryTransactionRedeemDetails interop)
        {

            Marketplace = (interop.marketplace == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.marketplace);

            MarketplaceTransactionId = (interop.marketplaceTransactionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.marketplaceTransactionId);

            OfferId = (interop.offerId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.offerId);

        }

        internal unsafe static void ToInterop(PFInventoryTransactionRedeemDetails self, Interop.PFInventoryTransactionRedeemDetails* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Marketplace != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Marketplace, &interop->marketplace, buffer);
            }

            if (self.MarketplaceTransactionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MarketplaceTransactionId, &interop->marketplaceTransactionId, buffer);
            }

            if (self.OfferId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OfferId, &interop->offerId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryTransactionTransferDetails data model.
    /// </summary>
    public struct PFInventoryTransactionTransferDetails
    {
        /// <summary>
        /// (Optional) The collection id the items were transferred from or null if it was the current collection.
        /// </summary>
        public string? GivingCollectionId;

        /// <summary>
        /// (Optional) The entity the items were transferred from or null if it was the current entity.
        /// </summary>
        public PFEntityKey? GivingEntity;

        /// <summary>
        /// (Optional) The collection id the items were transferred to or null if it was the current collection.
        /// </summary>
        public string? ReceivingCollectionId;

        /// <summary>
        /// (Optional) The entity the items were transferred to or null if it was the current entity.
        /// </summary>
        public PFEntityKey? ReceivingEntity;

        /// <summary>
        /// (Optional) The id of the transfer that occurred.
        /// </summary>
        public string? TransferId;

        internal unsafe PFInventoryTransactionTransferDetails(Interop.PFInventoryTransactionTransferDetails interop)
        {

            GivingCollectionId = (interop.givingCollectionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.givingCollectionId);

            GivingEntity = (interop.givingEntity == null) ? null : new(*interop.givingEntity);

            ReceivingCollectionId = (interop.receivingCollectionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.receivingCollectionId);

            ReceivingEntity = (interop.receivingEntity == null) ? null : new(*interop.receivingEntity);

            TransferId = (interop.transferId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.transferId);

        }

        internal unsafe static void ToInterop(PFInventoryTransactionTransferDetails self, Interop.PFInventoryTransactionTransferDetails* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.GivingCollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GivingCollectionId, &interop->givingCollectionId, buffer);
            }

            if (self.GivingEntity != null)
            {
                interop->givingEntity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.GivingEntity.Value, interop->givingEntity, buffer);
            }

            if (self.ReceivingCollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ReceivingCollectionId, &interop->receivingCollectionId, buffer);
            }

            if (self.ReceivingEntity != null)
            {
                interop->receivingEntity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.ReceivingEntity.Value, interop->receivingEntity, buffer);
            }

            if (self.TransferId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TransferId, &interop->transferId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryTransaction data model.
    /// </summary>
    public struct PFInventoryTransaction
    {
        /// <summary>
        /// (Optional) The API call that caused this transaction.
        /// </summary>
        public string? ApiName;

        /// <summary>
        /// (Optional) Additional details about the transaction. Null if it was not a clawback operation.
        /// </summary>
        public PFInventoryTransactionClawbackDetails? ClawbackDetails;

        /// <summary>
        /// (Optional) The custom tags associated with this transactions.
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The type of item that the the operation occurred on.
        /// </summary>
        public string? ItemType;

        /// <summary>
        /// (Optional) The operations that occurred.
        /// </summary>
        public PFInventoryTransactionOperation[]? Operations;

        /// <summary>
        /// (Optional) The type of operation that was run.
        /// </summary>
        public string? OperationType;

        /// <summary>
        /// (Optional) Additional details about the transaction. Null if it was not a purchase operation.
        /// </summary>
        public PFInventoryTransactionPurchaseDetails? PurchaseDetails;

        /// <summary>
        /// (Optional) Additional details about the transaction. Null if it was not a redeem operation.
        /// </summary>
        public PFInventoryTransactionRedeemDetails? RedeemDetails;

        /// <summary>
        /// The time this transaction occurred in UTC.
        /// </summary>
        public long Timestamp;

        /// <summary>
        /// (Optional) The id of the transaction. This should be treated like an opaque token.
        /// </summary>
        public string? TransactionId;

        /// <summary>
        /// (Optional) Additional details about the transaction. Null if it was not a transfer operation.
        /// </summary>
        public PFInventoryTransactionTransferDetails? TransferDetails;

        internal unsafe PFInventoryTransaction(Interop.PFInventoryTransaction interop)
        {

            ApiName = (interop.apiName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.apiName);

            ClawbackDetails = (interop.clawbackDetails == null) ? null : new(*interop.clawbackDetails);

            CustomTags = (interop.customTags == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.customTags, interop.customTagsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

            ItemType = (interop.itemType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemType);

            Operations = (interop.operations == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.operations, interop.operationsCount, elem => new PFInventoryTransactionOperation(elem));

            OperationType = (interop.operationType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationType);

            PurchaseDetails = (interop.purchaseDetails == null) ? null : new(*interop.purchaseDetails);

            RedeemDetails = (interop.redeemDetails == null) ? null : new(*interop.redeemDetails);

            Timestamp = interop.timestamp;

            TransactionId = (interop.transactionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.transactionId);

            TransferDetails = (interop.transferDetails == null) ? null : new(*interop.transferDetails);

        }

        internal unsafe static void ToInterop(PFInventoryTransaction self, Interop.PFInventoryTransaction* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ApiName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ApiName, &interop->apiName, buffer);
            }

            if (self.ClawbackDetails != null)
            {
                interop->clawbackDetails = (Interop.PFInventoryTransactionClawbackDetails*)buffer.AddBuffer(sizeof(Interop.PFInventoryTransactionClawbackDetails));
                PFInventoryTransactionClawbackDetails.ToInterop(self.ClawbackDetails.Value, interop->clawbackDetails, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.ItemType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemType, &interop->itemType, buffer);
            }

            if (self.Operations != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Operations, &interop->operations, buffer, PFInventoryTransactionOperation.ToInterop);
                interop->operationsCount = (uint)self.Operations.Length;
            }

            if (self.OperationType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OperationType, &interop->operationType, buffer);
            }

            if (self.PurchaseDetails != null)
            {
                interop->purchaseDetails = (Interop.PFInventoryTransactionPurchaseDetails*)buffer.AddBuffer(sizeof(Interop.PFInventoryTransactionPurchaseDetails));
                PFInventoryTransactionPurchaseDetails.ToInterop(self.PurchaseDetails.Value, interop->purchaseDetails, buffer);
            }

            if (self.RedeemDetails != null)
            {
                interop->redeemDetails = (Interop.PFInventoryTransactionRedeemDetails*)buffer.AddBuffer(sizeof(Interop.PFInventoryTransactionRedeemDetails));
                PFInventoryTransactionRedeemDetails.ToInterop(self.RedeemDetails.Value, interop->redeemDetails, buffer);
            }

            interop->timestamp = self.Timestamp;

            if (self.TransactionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TransactionId, &interop->transactionId, buffer);
            }

            if (self.TransferDetails != null)
            {
                interop->transferDetails = (Interop.PFInventoryTransactionTransferDetails*)buffer.AddBuffer(sizeof(Interop.PFInventoryTransactionTransferDetails));
                PFInventoryTransactionTransferDetails.ToInterop(self.TransferDetails.Value, interop->transferDetails, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryGetTransactionHistoryResponse data model.
    /// </summary>
    public struct PFInventoryGetTransactionHistoryResponse
    {
        /// <summary>
        /// (Optional) An opaque token used to retrieve the next page of items, if any are available. Should
        /// be null on initial request.
        /// </summary>
        public string? ContinuationToken;

        /// <summary>
        /// (Optional) The requested inventory transactions.
        /// </summary>
        public PFInventoryTransaction[]? Transactions;

        internal unsafe PFInventoryGetTransactionHistoryResponse(Interop.PFInventoryGetTransactionHistoryResponse interop)
        {

            ContinuationToken = (interop.continuationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.continuationToken);

            Transactions = (interop.transactions == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.transactions, interop.transactionsCount, elem => new PFInventoryTransaction(elem));

        }
            
    }

    /// <summary>
    /// PFInventoryPurchaseInventoryItemsRequest data model. Purchase a single item or bundle, paying the
    /// associated price.
    /// </summary>
    public struct PFInventoryPurchaseInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The amount to purchase.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default"). The
        /// number of inventory collections is unlimited.
        /// </summary>
        public string? CollectionId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the request should be deleted from the
        /// inventory. (Default=false).
        /// </summary>
        public bool DeleteEmptyStacks;

        /// <summary>
        /// (Optional) The duration to purchase.
        /// </summary>
        public double? DurationInSeconds;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The Idempotency ID for this request. Idempotency IDs can be used to prevent operation
        /// replay in the medium term but will be garbage collected eventually.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The inventory item the request applies to.
        /// </summary>
        public PFInventoryInventoryItemReference? Item;

        /// <summary>
        /// (Optional) The values to apply to a stack newly created by this request.
        /// </summary>
        public PFInventoryInitialValues? NewStackValues;

        /// <summary>
        /// (Optional) The per-item price the item is expected to be purchased at. This must match a value configured
        /// in the Catalog or specified Store. .
        /// </summary>
        public PFInventoryPurchasePriceAmount[]? PriceAmounts;

        /// <summary>
        /// (Optional) The id of the Store to purchase the item from.
        /// </summary>
        public string? StoreId;

        internal unsafe static void ToInterop(PFInventoryPurchaseInventoryItemsRequest self, Interop.PFInventoryPurchaseInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->deleteEmptyStacks = InteropWrapper.WrapperHelpers.BoolToInterop(self.DeleteEmptyStacks);

            if (self.DurationInSeconds != null)
            {
                *interop->durationInSeconds = self.DurationInSeconds.Value;
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

            if (self.IdempotencyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IdempotencyId, &interop->idempotencyId, buffer);
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.Item.Value, interop->item, buffer);
            }

            if (self.NewStackValues != null)
            {
                interop->newStackValues = (Interop.PFInventoryInitialValues*)buffer.AddBuffer(sizeof(Interop.PFInventoryInitialValues));
                PFInventoryInitialValues.ToInterop(self.NewStackValues.Value, interop->newStackValues, buffer);
            }

            if (self.PriceAmounts != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.PriceAmounts, &interop->priceAmounts, buffer, PFInventoryPurchasePriceAmount.ToInterop);
                interop->priceAmountsCount = (uint)self.PriceAmounts.Length;
            }

            if (self.StoreId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StoreId, &interop->storeId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryPurchaseInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryPurchaseInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The idempotency id used in the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryPurchaseInventoryItemsResponse(Interop.PFInventoryPurchaseInventoryItemsResponse interop)
        {

            ETag = (interop.eTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.eTag);

            IdempotencyId = (interop.idempotencyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.idempotencyId);

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemAppleAppStoreInventoryItemsRequest data model. Redeem items from the Apple App Store.
    /// </summary>
    public struct PFInventoryRedeemAppleAppStoreInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

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
        /// (Optional) The receipt provided by the Apple marketplace upon successful purchase.
        /// </summary>
        public string? Receipt;

        internal unsafe static void ToInterop(PFInventoryRedeemAppleAppStoreInventoryItemsRequest self, Interop.PFInventoryRedeemAppleAppStoreInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.Receipt != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Receipt, &interop->receipt, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryRedemptionFailure data model.
    /// </summary>
    public struct PFInventoryRedemptionFailure
    {
        /// <summary>
        /// (Optional) The marketplace failure code.
        /// </summary>
        public string? FailureCode;

        /// <summary>
        /// (Optional) The marketplace error details explaining why the offer failed to redeem.
        /// </summary>
        public string? FailureDetails;

        /// <summary>
        /// (Optional) The Marketplace Alternate ID being redeemed.
        /// </summary>
        public string? MarketplaceAlternateId;

        /// <summary>
        /// (Optional) The transaction id in the external marketplace.
        /// </summary>
        public string? MarketplaceTransactionId;

        internal unsafe PFInventoryRedemptionFailure(Interop.PFInventoryRedemptionFailure interop)
        {

            FailureCode = (interop.failureCode == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.failureCode);

            FailureDetails = (interop.failureDetails == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.failureDetails);

            MarketplaceAlternateId = (interop.marketplaceAlternateId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.marketplaceAlternateId);

            MarketplaceTransactionId = (interop.marketplaceTransactionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.marketplaceTransactionId);

        }

        internal unsafe static void ToInterop(PFInventoryRedemptionFailure self, Interop.PFInventoryRedemptionFailure* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FailureCode != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FailureCode, &interop->failureCode, buffer);
            }

            if (self.FailureDetails != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FailureDetails, &interop->failureDetails, buffer);
            }

            if (self.MarketplaceAlternateId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MarketplaceAlternateId, &interop->marketplaceAlternateId, buffer);
            }

            if (self.MarketplaceTransactionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MarketplaceTransactionId, &interop->marketplaceTransactionId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryRedemptionSuccess data model.
    /// </summary>
    public struct PFInventoryRedemptionSuccess
    {
        /// <summary>
        /// (Optional) The timestamp for when the redeem expired.
        /// </summary>
        public long? ExpirationTimestamp;

        /// <summary>
        /// (Optional) The Marketplace Alternate ID being redeemed.
        /// </summary>
        public string? MarketplaceAlternateId;

        /// <summary>
        /// (Optional) The transaction id in the external marketplace.
        /// </summary>
        public string? MarketplaceTransactionId;

        /// <summary>
        /// The timestamp for when the redeem was completed.
        /// </summary>
        public long SuccessTimestamp;

        internal unsafe PFInventoryRedemptionSuccess(Interop.PFInventoryRedemptionSuccess interop)
        {

            ExpirationTimestamp = (interop.expirationTimestamp == null) ? null : *interop.expirationTimestamp;

            MarketplaceAlternateId = (interop.marketplaceAlternateId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.marketplaceAlternateId);

            MarketplaceTransactionId = (interop.marketplaceTransactionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.marketplaceTransactionId);

            SuccessTimestamp = interop.successTimestamp;

        }

        internal unsafe static void ToInterop(PFInventoryRedemptionSuccess self, Interop.PFInventoryRedemptionSuccess* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ExpirationTimestamp != null)
            {
                *interop->expirationTimestamp = self.ExpirationTimestamp.Value;
            }

            if (self.MarketplaceAlternateId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MarketplaceAlternateId, &interop->marketplaceAlternateId, buffer);
            }

            if (self.MarketplaceTransactionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MarketplaceTransactionId, &interop->marketplaceTransactionId, buffer);
            }

            interop->successTimestamp = self.SuccessTimestamp;

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemAppleAppStoreInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryRedeemAppleAppStoreInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) The list of failed redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionFailure[]? Failed;

        /// <summary>
        /// (Optional) The list of successful redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionSuccess[]? Succeeded;

        /// <summary>
        /// (Optional) The Transaction IDs associated with the inventory modifications.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryRedeemAppleAppStoreInventoryItemsResponse(Interop.PFInventoryRedeemAppleAppStoreInventoryItemsResponse interop)
        {

            Failed = (interop.failed == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.failed, interop.failedCount, elem => new PFInventoryRedemptionFailure(elem));

            Succeeded = (interop.succeeded == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.succeeded, interop.succeededCount, elem => new PFInventoryRedemptionSuccess(elem));

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryGooglePlayProductPurchase data model.
    /// </summary>
    public struct PFInventoryGooglePlayProductPurchase
    {
        /// <summary>
        /// (Optional) The Product ID (SKU) of the InApp product purchased from the Google Play store.
        /// </summary>
        public string? ProductId;

        /// <summary>
        /// (Optional) The token provided to the player's device when the product was purchased.
        /// </summary>
        public string? Token;

        internal unsafe PFInventoryGooglePlayProductPurchase(Interop.PFInventoryGooglePlayProductPurchase interop)
        {

            ProductId = (interop.productId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.productId);

            Token = (interop.token == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.token);

        }

        internal unsafe static void ToInterop(PFInventoryGooglePlayProductPurchase self, Interop.PFInventoryGooglePlayProductPurchase* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ProductId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ProductId, &interop->productId, buffer);
            }

            if (self.Token != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Token, &interop->token, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemGooglePlayInventoryItemsRequest data model. Redeem items from the Google Play Store.
    /// </summary>
    public struct PFInventoryRedeemGooglePlayInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

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
        /// (Optional) The list of purchases to redeem.
        /// </summary>
        public PFInventoryGooglePlayProductPurchase[]? Purchases;

        internal unsafe static void ToInterop(PFInventoryRedeemGooglePlayInventoryItemsRequest self, Interop.PFInventoryRedeemGooglePlayInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.Purchases != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Purchases, &interop->purchases, buffer, PFInventoryGooglePlayProductPurchase.ToInterop);
                interop->purchasesCount = (uint)self.Purchases.Length;
            }

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemGooglePlayInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryRedeemGooglePlayInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) The list of failed redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionFailure[]? Failed;

        /// <summary>
        /// (Optional) The list of successful redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionSuccess[]? Succeeded;

        /// <summary>
        /// (Optional) The Transaction IDs associated with the inventory modifications.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryRedeemGooglePlayInventoryItemsResponse(Interop.PFInventoryRedeemGooglePlayInventoryItemsResponse interop)
        {

            Failed = (interop.failed == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.failed, interop.failedCount, elem => new PFInventoryRedemptionFailure(elem));

            Succeeded = (interop.succeeded == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.succeeded, interop.succeededCount, elem => new PFInventoryRedemptionSuccess(elem));

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemMicrosoftStoreInventoryItemsRequest data model. Redeem items from the Microsoft
    /// Store.
    /// </summary>
    public struct PFInventoryRedeemMicrosoftStoreInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

#if MICROSOFT_GDK_SUPPORT
        /// <summary>
        /// XUserHandle used for delegated Microsoft Store authentication.
        /// When using the Microsoft GDK Unity API, this is the Handle property or the value returned from DangerousGetHandle() of the XUserHandle object acquired from the XUserAddAsync or XUserAddByIdWithUiAsync methods.
        /// </summary>
        public IntPtr UserHandle;
#endif

        internal unsafe static void ToInterop(PFInventoryRedeemMicrosoftStoreInventoryItemsRequest self, Interop.PFInventoryRedeemMicrosoftStoreInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

#if MICROSOFT_GDK_SUPPORT
            interop->user = self.UserHandle;
#endif

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemMicrosoftStoreInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryRedeemMicrosoftStoreInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) The list of failed redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionFailure[]? Failed;

        /// <summary>
        /// (Optional) The list of successful redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionSuccess[]? Succeeded;

        /// <summary>
        /// (Optional) The Transaction IDs associated with the inventory modifications.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryRedeemMicrosoftStoreInventoryItemsResponse(Interop.PFInventoryRedeemMicrosoftStoreInventoryItemsResponse interop)
        {

            Failed = (interop.failed == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.failed, interop.failedCount, elem => new PFInventoryRedemptionFailure(elem));

            Succeeded = (interop.succeeded == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.succeeded, interop.succeededCount, elem => new PFInventoryRedemptionSuccess(elem));

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemNintendoEShopInventoryItemsRequest data model. Redeem items from the Nintendo EShop.
    /// </summary>
    public struct PFInventoryRedeemNintendoEShopInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

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
        /// (Optional) The Nintendo provided token authorizing redemption.
        /// </summary>
        public string? NintendoServiceAccountIdToken;

        internal unsafe static void ToInterop(PFInventoryRedeemNintendoEShopInventoryItemsRequest self, Interop.PFInventoryRedeemNintendoEShopInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.NintendoServiceAccountIdToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoServiceAccountIdToken, &interop->nintendoServiceAccountIdToken, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemNintendoEShopInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryRedeemNintendoEShopInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) The list of failed redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionFailure[]? Failed;

        /// <summary>
        /// (Optional) The list of successful redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionSuccess[]? Succeeded;

        /// <summary>
        /// (Optional) The Transaction IDs associated with the inventory modifications.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryRedeemNintendoEShopInventoryItemsResponse(Interop.PFInventoryRedeemNintendoEShopInventoryItemsResponse interop)
        {

            Failed = (interop.failed == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.failed, interop.failedCount, elem => new PFInventoryRedemptionFailure(elem));

            Succeeded = (interop.succeeded == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.succeeded, interop.succeededCount, elem => new PFInventoryRedemptionSuccess(elem));

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemPlayStationStoreInventoryItemsRequest data model. Redeem items from the PlayStation
    /// Store.
    /// </summary>
    public struct PFInventoryRedeemPlayStationStoreInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) Auth code returned by PlayStation :tm: Network OAuth system.
        /// </summary>
        public string? AuthorizationCode;

        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

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
        /// (Optional) Redirect URI supplied to PlayStation :tm: Network when requesting an auth code.
        /// </summary>
        public string? RedirectUri;

        /// <summary>
        /// (Optional) Optional Service Label to pass into the request.
        /// </summary>
        public string? ServiceLabel;

        internal unsafe static void ToInterop(PFInventoryRedeemPlayStationStoreInventoryItemsRequest self, Interop.PFInventoryRedeemPlayStationStoreInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AuthorizationCode != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AuthorizationCode, &interop->authorizationCode, buffer);
            }

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.RedirectUri != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RedirectUri, &interop->redirectUri, buffer);
            }

            if (self.ServiceLabel != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ServiceLabel, &interop->serviceLabel, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemPlayStationStoreInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryRedeemPlayStationStoreInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) The list of failed redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionFailure[]? Failed;

        /// <summary>
        /// (Optional) The list of successful redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionSuccess[]? Succeeded;

        /// <summary>
        /// (Optional) The Transaction IDs associated with the inventory modifications.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryRedeemPlayStationStoreInventoryItemsResponse(Interop.PFInventoryRedeemPlayStationStoreInventoryItemsResponse interop)
        {

            Failed = (interop.failed == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.failed, interop.failedCount, elem => new PFInventoryRedemptionFailure(elem));

            Succeeded = (interop.succeeded == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.succeeded, interop.succeededCount, elem => new PFInventoryRedemptionSuccess(elem));

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemSteamInventoryItemsRequest data model. Redeem inventory items from Steam.
    /// </summary>
    public struct PFInventoryRedeemSteamInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default").
        /// </summary>
        public string? CollectionId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe static void ToInterop(PFInventoryRedeemSteamInventoryItemsRequest self, Interop.PFInventoryRedeemSteamInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

        }
            
    }

    /// <summary>
    /// PFInventoryRedeemSteamInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryRedeemSteamInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) The list of failed redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionFailure[]? Failed;

        /// <summary>
        /// (Optional) The list of successful redemptions from the external marketplace.
        /// </summary>
        public PFInventoryRedemptionSuccess[]? Succeeded;

        /// <summary>
        /// (Optional) The Transaction IDs associated with the inventory modifications.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryRedeemSteamInventoryItemsResponse(Interop.PFInventoryRedeemSteamInventoryItemsResponse interop)
        {

            Failed = (interop.failed == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.failed, interop.failedCount, elem => new PFInventoryRedemptionFailure(elem));

            Succeeded = (interop.succeeded == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.succeeded, interop.succeededCount, elem => new PFInventoryRedemptionSuccess(elem));

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventorySubtractInventoryItemsRequest data model. Given an entity type, entity identifier and
    /// container details, will subtract the specified inventory items. .
    /// </summary>
    public struct PFInventorySubtractInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The amount to subtract for the current item.
        /// </summary>
        public int? Amount;

        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default"). The
        /// number of inventory collections is unlimited.
        /// </summary>
        public string? CollectionId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the request should be deleted from the
        /// inventory. (Default=false).
        /// </summary>
        public bool DeleteEmptyStacks;

        /// <summary>
        /// (Optional) The duration to subtract from the current item expiration date.
        /// </summary>
        public double? DurationInSeconds;

        /// <summary>
        /// (Optional) The entity to perform this action on.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The Idempotency ID for this request. Idempotency IDs can be used to prevent operation
        /// replay in the medium term but will be garbage collected eventually.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The inventory item the request applies to.
        /// </summary>
        public PFInventoryInventoryItemReference? Item;

        internal unsafe static void ToInterop(PFInventorySubtractInventoryItemsRequest self, Interop.PFInventorySubtractInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->deleteEmptyStacks = InteropWrapper.WrapperHelpers.BoolToInterop(self.DeleteEmptyStacks);

            if (self.DurationInSeconds != null)
            {
                *interop->durationInSeconds = self.DurationInSeconds.Value;
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

            if (self.IdempotencyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IdempotencyId, &interop->idempotencyId, buffer);
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.Item.Value, interop->item, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventorySubtractInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventorySubtractInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The idempotency id used in the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventorySubtractInventoryItemsResponse(Interop.PFInventorySubtractInventoryItemsResponse interop)
        {

            ETag = (interop.eTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.eTag);

            IdempotencyId = (interop.idempotencyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.idempotencyId);

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryTransferInventoryItemsRequest data model. Transfer the specified inventory items of an
    /// entity's container Id to another entity's container Id.
    /// </summary>
    public struct PFInventoryTransferInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The amount to transfer .
        /// </summary>
        public int? Amount;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the request should be deleted from the
        /// inventory. (Default = false).
        /// </summary>
        public bool DeleteEmptyStacks;

        /// <summary>
        /// (Optional) The inventory collection id the request is transferring from. (Default="default").
        /// </summary>
        public string? GivingCollectionId;

        /// <summary>
        /// (Optional) The entity the request is transferring from. Set to the caller by default.
        /// </summary>
        public PFEntityKey? GivingEntity;

        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources (before transferring from).
        /// More information about using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? GivingETag;

        /// <summary>
        /// (Optional) The inventory item the request is transferring from.
        /// </summary>
        public PFInventoryInventoryItemReference? GivingItem;

        /// <summary>
        /// (Optional) The idempotency id for the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The values to apply to a stack newly created by this request.
        /// </summary>
        public PFInventoryInitialValues? NewStackValues;

        /// <summary>
        /// (Optional) The inventory collection id the request is transferring to. (Default="default").
        /// </summary>
        public string? ReceivingCollectionId;

        /// <summary>
        /// (Optional) The entity the request is transferring to. Set to the caller by default.
        /// </summary>
        public PFEntityKey? ReceivingEntity;

        /// <summary>
        /// (Optional) The inventory item the request is transferring to.
        /// </summary>
        public PFInventoryInventoryItemReference? ReceivingItem;

        internal unsafe static void ToInterop(PFInventoryTransferInventoryItemsRequest self, Interop.PFInventoryTransferInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Amount != null)
            {
                *interop->amount = self.Amount.Value;
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            interop->deleteEmptyStacks = InteropWrapper.WrapperHelpers.BoolToInterop(self.DeleteEmptyStacks);

            if (self.GivingCollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GivingCollectionId, &interop->givingCollectionId, buffer);
            }

            if (self.GivingEntity != null)
            {
                interop->givingEntity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.GivingEntity.Value, interop->givingEntity, buffer);
            }

            if (self.GivingETag != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GivingETag, &interop->givingETag, buffer);
            }

            if (self.GivingItem != null)
            {
                interop->givingItem = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.GivingItem.Value, interop->givingItem, buffer);
            }

            if (self.IdempotencyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IdempotencyId, &interop->idempotencyId, buffer);
            }

            if (self.NewStackValues != null)
            {
                interop->newStackValues = (Interop.PFInventoryInitialValues*)buffer.AddBuffer(sizeof(Interop.PFInventoryInitialValues));
                PFInventoryInitialValues.ToInterop(self.NewStackValues.Value, interop->newStackValues, buffer);
            }

            if (self.ReceivingCollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ReceivingCollectionId, &interop->receivingCollectionId, buffer);
            }

            if (self.ReceivingEntity != null)
            {
                interop->receivingEntity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.ReceivingEntity.Value, interop->receivingEntity, buffer);
            }

            if (self.ReceivingItem != null)
            {
                interop->receivingItem = (Interop.PFInventoryInventoryItemReference*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItemReference));
                PFInventoryInventoryItemReference.ToInterop(self.ReceivingItem.Value, interop->receivingItem, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryTransferInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryTransferInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources (after transferring from).
        /// More information about using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? GivingETag;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request's giving action.
        /// </summary>
        public string[]? GivingTransactionIds;

        /// <summary>
        /// (Optional) The idempotency id for the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The transfer operation status. Possible values are 'InProgress' or 'Completed'. If the
        /// operation has completed, the response code will be 200. Otherwise, it will be 202.
        /// </summary>
        public string? OperationStatus;

        /// <summary>
        /// (Optional) The token that can be used to get the status of the transfer operation. This will only
        /// have a value if OperationStatus is 'InProgress'.
        /// </summary>
        public string? OperationToken;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request's receiving action.
        /// </summary>
        public string[]? ReceivingTransactionIds;

        internal unsafe PFInventoryTransferInventoryItemsResponse(Interop.PFInventoryTransferInventoryItemsResponse interop)
        {

            GivingETag = (interop.givingETag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.givingETag);

            GivingTransactionIds = (interop.givingTransactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.givingTransactionIds, interop.givingTransactionIdsCount);

            IdempotencyId = (interop.idempotencyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.idempotencyId);

            OperationStatus = (interop.operationStatus == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationStatus);

            OperationToken = (interop.operationToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.operationToken);

            ReceivingTransactionIds = (interop.receivingTransactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.receivingTransactionIds, interop.receivingTransactionIdsCount);

        }
            
    }

    /// <summary>
    /// PFInventoryUpdateInventoryItemsRequest data model. Given an entity type, entity identifier and container
    /// details, will update the entity's inventory items.
    /// </summary>
    public struct PFInventoryUpdateInventoryItemsRequest
    {
        /// <summary>
        /// (Optional) The id of the entity's collection to perform this action on. (Default="default"). The
        /// number of inventory collections is unlimited.
        /// </summary>
        public string? CollectionId;

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
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The Idempotency ID for this request. Idempotency IDs can be used to prevent operation
        /// replay in the medium term but will be garbage collected eventually.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The inventory item to update with the specified values.
        /// </summary>
        public PFInventoryInventoryItem? Item;

        internal unsafe static void ToInterop(PFInventoryUpdateInventoryItemsRequest self, Interop.PFInventoryUpdateInventoryItemsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CollectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CollectionId, &interop->collectionId, buffer);
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

            if (self.IdempotencyId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IdempotencyId, &interop->idempotencyId, buffer);
            }

            if (self.Item != null)
            {
                interop->item = (Interop.PFInventoryInventoryItem*)buffer.AddBuffer(sizeof(Interop.PFInventoryInventoryItem));
                PFInventoryInventoryItem.ToInterop(self.Item.Value, interop->item, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFInventoryUpdateInventoryItemsResponse data model.
    /// </summary>
    public struct PFInventoryUpdateInventoryItemsResponse
    {
        /// <summary>
        /// (Optional) ETags are used for concurrency checking when updating resources. More information about
        /// using ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags.
        /// </summary>
        public string? ETag;

        /// <summary>
        /// (Optional) The idempotency id used in the request.
        /// </summary>
        public string? IdempotencyId;

        /// <summary>
        /// (Optional) The ids of transactions that occurred as a result of the request.
        /// </summary>
        public string[]? TransactionIds;

        internal unsafe PFInventoryUpdateInventoryItemsResponse(Interop.PFInventoryUpdateInventoryItemsResponse interop)
        {

            ETag = (interop.eTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.eTag);

            IdempotencyId = (interop.idempotencyId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.idempotencyId);

            TransactionIds = (interop.transactionIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.transactionIds, interop.transactionIdsCount);

        }
            
    }

}
