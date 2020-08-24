using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BreweryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BeerEntity[] Beers { get; set; }
    }
}
