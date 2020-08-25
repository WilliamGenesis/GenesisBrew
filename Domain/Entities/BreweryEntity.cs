using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BreweryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<BeerEntity> Beers { get; set; }
    }
}
