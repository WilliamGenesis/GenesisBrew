using Application.Validation;
using DataAccess;
using Domain.Extensions;
using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandDataAccess _brandDataAccess;
        private readonly IBrandValidation _brandValidation;
        public BrandService(IBrandDataAccess brandDataAccess, IBrandValidation brandValidation)
        {
            _brandDataAccess = brandDataAccess;
            _brandValidation = brandValidation;
        }

        public async Task<Guid> CreateBeer(Beer beer)
        {
            await _brandValidation.ValidateBeer(beer);

            return await _brandDataAccess.CreateBeer(beer.ToEntity());
        }

        public async Task<Beer[]> GetBeers(Guid breweryId)
        {
            var beers = await _brandDataAccess.GetBeers(breweryId);

            return beers.ToModels();
        }

        public async Task<Brewery[]> GetBreweries()
        {
            var breweries = await _brandDataAccess.GetBreweries();

            return breweries.ToModels();
        }

        public async Task<Guid> MarkBeerAsObsolete(Guid beerId)
        {
            await _brandValidation.ValidateBeerExists(beerId);

            return await _brandDataAccess.MarkBeerAsObsolete(beerId);
        }
    }
}
