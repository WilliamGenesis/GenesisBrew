using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BrandService : IBrandService
    {
        public Task<Guid> CreateBeer(Beer beer)
        {
            throw new NotImplementedException();
        }

        public Task<Beer[]> GetBeers(Guid breweryId)
        {
            throw new NotImplementedException();
        }

        public Task<Brewery[]> GetBreweries()
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkBeerAsObsolete(Guid beerId)
        {
            throw new NotImplementedException();
        }
    }
}
