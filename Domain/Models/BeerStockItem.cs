using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class BeerStockItem
    {
        public Guid Id { get; set; }
        public Wholesaler Wholesaler { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0, float.MaxValue)]
        public float UnitPrice { get; set; }

        public Beer Beer { get; set; }
    }
}
