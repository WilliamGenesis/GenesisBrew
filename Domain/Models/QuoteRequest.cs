using System;

namespace Domain.Models
{
    public class QuoteRequest
    {
        public Guid WholesalerId { get; set; }
        public BeerStockItemRequest[] BeerStockItemRequest { get; set; }
    }
}
