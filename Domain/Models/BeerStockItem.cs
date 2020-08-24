using System;

namespace Domain.Models
{
    public class BeerStockItem
    {
        public Guid Id { get; set; }
        public Guid WholesalerId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }

        public Beer Beer { get; set; }
    }
}
