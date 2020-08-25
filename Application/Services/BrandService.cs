using Application.Validation;
using DataAccess;
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

            return await _brandDataAccess.CreateBeer(beer);
        }

        public async Task<Beer[]> GetBeers(Guid breweryId)
        {
            return await _brandDataAccess.GetBeers(breweryId);
        }

        public async Task<Brewery[]> GetBreweries()
        {
            return await _brandDataAccess.GetBreweries();
        }

        public async Task<Guid> MarkBeerAsObsolete(Guid beerId)
        {
            await _brandValidation.ValidateBeerExists(beerId);

            return await _brandDataAccess.MarkBeerAsObsolete(beerId);
        }
    }
}
