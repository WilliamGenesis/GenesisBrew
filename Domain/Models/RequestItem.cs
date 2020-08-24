using System;

namespace Domain.Models
{
    public class BeerStockItemRequest
    {
        public Guid BeerStockItemId { get; set; }
        public int Quantity { get; set; }
    }
}
