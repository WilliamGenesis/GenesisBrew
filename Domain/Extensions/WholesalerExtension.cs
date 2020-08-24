using Domain.Entities;
using Domain.Models;
using System.Linq;

namespace Domain.Extensions
{
    public static class WholesalerExtension
    {
        public static Wholesaler ToModel(this WholesalerEntity entity)
        {
            return new Wholesaler
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Wholesaler[] ToModels(this WholesalerEntity[] entities)
        {
            return entities.Select(entity => entity.ToModel()).ToArray();
        }

        public static WholesalerEntity ToEntity(this Wholesaler model)
        {
            return new WholesalerEntity
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static WholesalerEntity[] ToEntities(this Wholesaler[] models)
        {
            return models.Select(model => model.ToEntity()).ToArray();
        }
    }
}
