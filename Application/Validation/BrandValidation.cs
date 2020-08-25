using DataAccess;
using Domain.Exceptions;
using Domain.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class BrandValidation
    {
        private readonly IBrandDataAccess _brandDataAccess;

        public BrandValidation(IBrandDataAccess brandDataAccess)
        {
            _brandDataAccess = brandDataAccess;
        }

        public async Task ValidateBeer(Beer beer)
        {
            await ValidateBeerBrewery(beer.Brewery.Id);
        }

        private async Task ValidateBeerBrewery(Guid breweryId)
        {
            if (breweryId.Equals(Guid.Empty))
                throw new HttpException(HttpStatusCode.BadRequest, "A beer must always have a brewery");

            if (await _brandDataAccess.GetBrewery(breweryId) is null)
                throw new HttpException(HttpStatusCode.BadRequest, "A beer must always be linked to an existing brewery");
        }
    }
}
