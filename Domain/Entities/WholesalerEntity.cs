using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WholesalerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<BeerStockItemEntity> BeerStockItems;
    }
}
