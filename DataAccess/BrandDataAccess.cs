using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BrandDataAccess : IBrandDataAccess
    {
        public Task<Guid> CreateBeer(BeerEntity beer)
        {
            throw new NotImplementedException();
        }

        public Task<BeerEntity> GetBeer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BeerEntity[]> GetBeers(Guid BreweryId)
        {
            throw new NotImplementedException();
        }

        public Task<BreweryEntity[]> GetBreweries()
        {
            throw new NotImplementedException();
        }

        public Task<BreweryEntity> GetBrewery(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> MarkBeerAsObsolete(Guid beerId)
        {
            throw new NotImplementedException();
        }
    }
}
