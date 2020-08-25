using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public class WholesalerDataAccess : IWholesalerDataAccess
    {
        public Task<Guid> CreateStockItem(BeerStockItemEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<BeerStockItemEntity> GetBeerStockItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WholesalerEntity> GetWholesaler(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WholesalerEntity[]> GetWholesalers()
        {
            throw new NotImplementedException();
        }

        public Task<WholesalerEntity[]> GetWholesalersByBeerId(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<BeerStockItemEntity[]> GetWholesalerStock(Guid wholesalerId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateStockItem(BeerStockItemEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
