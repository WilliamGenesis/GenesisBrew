using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IWholesalerDataAccess
    {
        Task<WholesalerEntity[]> GetWholesalers();
        Task<WholesalerEntity> GetWholesaler(Guid id);
        Task<BeerStockItemEntity> GetBeerStockItem(Guid id);
        Task<BeerStockItemEntity[]> GetWholesalerStock(Guid wholesalerId);
        Task<WholesalerEntity[]> GetWholesalersByBeerId(Guid itemId);
        Task<Guid> CreateStockItem(BeerStockItemEntity item);
        Task<Guid> UpdateStockItem(BeerStockItemEntity item);
    }
}
