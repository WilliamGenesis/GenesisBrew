using Domain.Models;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BrandDataAccess : IBrandDataAccess
    {
        public Task<Guid> CreateBeer(Beer beer)
        {
            throw new NotImplementedException();
        }

        public Task<Beer> GetBeer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Beer[]> GetBeers(Guid BreweryId)
        {
            throw new NotImplementedException();
        }

        public Task<Brewery[]> GetBreweries()
        {
            throw new NotImplementedException();
        }

        public Task<Brewery> GetBrewery(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> MarkBeerAsObsolete(Guid beerId)
        {
            throw new NotImplementedException();
        }
    }
}
