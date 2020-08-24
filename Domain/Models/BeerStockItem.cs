using System;

namespace Domain.Models
{
    public class BeerStockItem
    {
        public Guid Id { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }

        public Beer Beer { get; set; }
    }
}
