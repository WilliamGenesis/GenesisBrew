using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IBrandService
    {
        Task<Brewery[]> GetBreweries();
        Task<Beer[]> GetBeers(Guid breweryId);
        Task<Guid> CreateBeer(Beer beer);
        Task<bool> MarkBeerAsObsolete(Guid beerId);
    }
}
