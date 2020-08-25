using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBrandDataAccess
    {
        Task<BreweryEntity> GetBrewery(Guid id);
        Task<BeerEntity> GetBeer(Guid id);
        Task<BreweryEntity[]> GetBreweries();
        Task<BeerEntity[]> GetBeers(Guid BreweryId);
        Task<Guid> CreateBeer(BeerEntity beer);
        Task<Guid> MarkBeerAsObsolete(Guid beerId);
    }
}
