using System;

namespace Domain.Entities
{
    public class StockItemEntity
    {
        public Guid Id { get; set; }
        public Guid WholesalerId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }

        public BeerEntity Item { get; set; }
    }
}
