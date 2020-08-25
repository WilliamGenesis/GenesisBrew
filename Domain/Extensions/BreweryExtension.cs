using Domain.Entities;
using Domain.Models;
using System.Linq;

namespace Domain.Extensions
{
    public static class BreweryExtension
    {
        public static Brewery ToModel(this BreweryEntity entity)
        {
            return new Brewery
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Brewery[] ToModels(this BreweryEntity[] entities)
        {
            return entities.Select(entity => entity.ToModel()).ToArray();
        }

        public static BreweryEntity ToEntity(this Brewery model)
        {
            return new BreweryEntity
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static BreweryEntity[] ToEntities(this Brewery[] models)
        {
            return models.Select(model => model.ToEntity()).ToArray();
        }
    }
}
