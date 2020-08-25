using System;

namespace Domain.Models
{
    public class QuoteRequest
    {
        public Guid WholesalerId { get; set; }
        public BeerRequest[] BeerRequests { get; set; }
    }
}
