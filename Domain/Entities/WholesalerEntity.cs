using System;

namespace Domain.Entities
{
    public class WholesalerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public BeerStockItemEntity[] StockItems;
    }
}
