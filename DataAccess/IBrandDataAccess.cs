using Domain.Models;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBrandDataAccess
    {
        Task<Brewery> GetBrewery(Guid id);
        Task<Beer> GetBeer(Guid id);
        Task<Brewery[]> GetBreweries();
        Task<Beer[]> GetBeers(Guid BreweryId);
        Task<Guid> CreateBeer(Beer beer);
        Task<Guid> MarkBeerAsObsolete(Guid beerId);
    }
}
