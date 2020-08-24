using System;

namespace Domain.Entities
{
    public class BeerEntity
    {
        public Guid Id { get; set; }
        public Guid BreweryId { get; set; }
        public string Name { get; set; }
        public bool IsObsolete { get; set; }
        public BreweryEntity Brewery { get; set; }
    }
}
