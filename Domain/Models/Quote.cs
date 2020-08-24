using System;

namespace Domain.Models
{
    public class Quote
    {
        public float Price { get; set; }
        public float RawPrice { get; set; }
        public float Discount { get; set; }
        public Guid WholesalerId { get; set; }
        public BeerStockItem[] QuotedItems { get; set; }
    }
}
