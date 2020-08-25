using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Context
{
    public class GenesisBrewMockData
    {
        public List<BeerEntity> Beer { get; set; }
        public List<BreweryEntity> Brewery { get; set; }
        public List<WholesalerEntity> Wholesaler { get; set; }
        public List<BeerStockItemEntity> StockItem { get; set; }

        public void Seed()
        {
            var breweries = new[]
                {
                    new BreweryEntity{Id = Guid.NewGuid(), Name = "William Brew"},
                    new BreweryEntity{Id = Guid.NewGuid(), Name = "Genesis Brew"},
                    new BreweryEntity{Id = Guid.NewGuid(), Name = "Supreme Brew"},
                    new BreweryEntity{Id = Guid.NewGuid(), Name = "Baguette Brew"},
                    new BreweryEntity{Id = Guid.NewGuid(), Name = "Zuzu Pils"},
                };

            var beers = new[]
                {
                    new BeerEntity {Id = Guid.NewGuid(), Name = "Willy Blond", BreweryId = breweries[0].Id},
                    new BeerEntity {Id = Guid.NewGuid(), Name = "Genesis IPA", BreweryId = breweries[1].Id},
                    new BeerEntity {Id = Guid.NewGuid(), Name = "Supreme Red", BreweryId = breweries[2].Id},
                    new BeerEntity {Id = Guid.NewGuid(), Name = "Du vin", BreweryId = breweries[3].Id},
                    new BeerEntity {Id = Guid.NewGuid(), Name = "Toujours du vin", BreweryId = breweries[3].Id},
                    new BeerEntity {Id = Guid.NewGuid(), Name = "Cara", BreweryId = breweries[4].Id},
                    new BeerEntity {Id = Guid.NewGuid(), Name = "Heineken", BreweryId = breweries[4].Id},
                };

            var wholesalers = new[]
            {
                new WholesalerEntity {Id = Guid.NewGuid(), Name = "Genesis Shop"},
                new WholesalerEntity {Id = Guid.NewGuid(), Name = "Zuzu Shop"},
                new WholesalerEntity {Id = Guid.NewGuid(), Name = "Pizza Beer"},
            };

            var stockItems = new[]
            {
                new BeerStockItemEntity {Id = Guid.NewGuid(), Quantity = 2, UnitPrice = 1.5f, BeerId =beers[0].Id, WholesalerId = wholesalers[0].Id},
                new BeerStockItemEntity {Id = Guid.NewGuid(), Quantity = 3, UnitPrice = 2.5f, BeerId =beers[1].Id, WholesalerId = wholesalers[1].Id},
                new BeerStockItemEntity {Id = Guid.NewGuid(), Quantity = 25, UnitPrice = 1.6f, BeerId =beers[2].Id, WholesalerId = wholesalers[0].Id},
                new BeerStockItemEntity {Id = Guid.NewGuid(), Quantity = 4, UnitPrice = 1.9f, BeerId =beers[3].Id, WholesalerId = wholesalers[2].Id},
                new BeerStockItemEntity {Id = Guid.NewGuid(), Quantity = 2, UnitPrice = 3.2f, BeerId =beers[4].Id, WholesalerId = wholesalers[0].Id},
                new BeerStockItemEntity {Id = Guid.NewGuid(), Quantity = 6, UnitPrice = 0.5f, BeerId =beers[5].Id, WholesalerId = wholesalers[2].Id},
                new BeerStockItemEntity {Id = Guid.NewGuid(), Quantity = 1, UnitPrice = 1.9f, BeerId =beers[6].Id, WholesalerId = wholesalers[1].Id}
            };

            Beer = beers.ToList();
            Brewery = breweries.ToList();
            Wholesaler = wholesalers.ToList();
            StockItem = stockItems.ToList();
        }
    }
}
