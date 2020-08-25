using DataAccess.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BrandDataAccess : IBrandDataAccess
    {
        private GenesisBrewContext _context;
        public BrandDataAccess(GenesisBrewContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateBeer(BeerEntity beer)
        {
            var newBeer = await _context.Beer.AddAsync(beer);

            await _context.SaveChangesAsync();

            return newBeer.Entity.Id;
        }

        public async Task<BeerEntity> GetBeer(Guid id)
        {
            return await _context.Beer.FirstOrDefaultAsync(beer => beer.Id.Equals(id));
        }

        public async Task<BeerEntity[]> GetBeers(Guid breweryId)
        {
            return await _context.Beer.Where(beer => beer.BreweryId.Equals(breweryId) &&
                 beer.IsObsolete == false)
                .Include(beer => beer.Brewery)
                .ToArrayAsync();
        }

        public async Task<BreweryEntity[]> GetBreweries()
        {
            return await _context.Brewery.ToArrayAsync();
        }

        public async Task<BreweryEntity> GetBrewery(Guid id)
        {
            return await _context.Brewery.FirstOrDefaultAsync(brewery => brewery.Id.Equals(id));
        }

        public async Task<Guid> MarkBeerAsObsolete(Guid beerId)
        {
            var beer = await _context.Beer.FirstOrDefaultAsync(beer => beer.Id.Equals(beerId));
            beer.IsObsolete = true;

            await _context.SaveChangesAsync();

            return beer.Id;
        }
    }
}
