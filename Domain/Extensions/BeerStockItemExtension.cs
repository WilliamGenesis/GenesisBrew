using Domain.Entities;
using Domain.Models;
using System;
using System.Linq;

namespace Domain.Extensions
{
    public static class BeerStockItemExtension
    {
        public static BeerStockItem ToModel(this BeerStockItemEntity entity)
        {
            return new BeerStockItem
            {
                Id = entity.Id,
                Beer = entity.Beer.ToModel(),
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                Wholesaler = entity.Wholesaler.ToModel()
            };
        }

        public static BeerStockItem[] ToModels(this BeerStockItemEntity[] entities)
        {
            return entities.Select(entity => entity.ToModel()).ToArray();
        }

        public static BeerStockItemEntity ToEntity(this BeerStockItem model)
        {
            return new BeerStockItemEntity
            {
                Id = model.Id,
                BeerId = model.Beer?.Id ?? Guid.Empty,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                WholesalerId = model.Wholesaler?.Id ?? Guid.Empty
            };
        }

        public static BeerStockItemEntity[] ToEntities(this BeerStockItem[] models)
        {
            return models.Select(model => model.ToEntity()).ToArray();
        }
    }
}
