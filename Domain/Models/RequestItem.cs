using System;

namespace Domain.Models
{
    public class BeerRequest
    {
        public Guid BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
