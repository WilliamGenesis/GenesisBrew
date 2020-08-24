using System;

namespace Domain.Entities
{
    public class BeerStockItemEntity
    {
        public Guid Id { get; set; }
        public Guid WholesalerId { get; set; }
        public Guid BeerId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }

        public WholesalerEntity Wholesaler { get; set; }
        public BeerEntity Beer { get; set; }
    }
}
