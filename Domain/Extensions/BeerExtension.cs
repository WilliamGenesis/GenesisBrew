using Domain.Entities;
using Domain.Models;
using System;
using System.Linq;

namespace Domain.Extensions
{
    public static class BeerExtension
    {
        public static Beer ToModel(this BeerEntity entity)
        {
            return new Beer
            {
                Id = entity.Id,
                Name = entity.Name,
                Brewery = entity.Brewery?.ToModel()
            };
        }

        public static Beer[] ToModels(this BeerEntity[] entities)
        {
            return entities.Select(entity => entity.ToModel()).ToArray();
        }

        public static BeerEntity ToEntity(this Beer model)
        {
            return new BeerEntity
            {
                Id = model.Id,
                Name = model.Name,
                IsObsolete = false,
                BreweryId = model.Brewery?.Id ?? Guid.Empty
            };
        }

        public static BeerEntity[] ToEntities(this Beer[] models)
        {
            return models.Select(model => model.ToEntity()).ToArray();
        }
    }
}
