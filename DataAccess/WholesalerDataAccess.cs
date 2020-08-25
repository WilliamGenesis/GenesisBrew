using Domain.Models;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public class WholesalerDataAccess : IWholesalerDataAccess
    {
        public Task<Guid> CreateStockItem(BeerStockItem item)
        {
            throw new NotImplementedException();
        }

        public Task<BeerStockItem> GetBeerStockItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Wholesaler> GetWholesaler(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Wholesaler[]> GetWholesalers()
        {
            throw new NotImplementedException();
        }

        public Task<Wholesaler[]> GetWholesalersByBeerId(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<BeerStockItem[]> GetWholesalerStock(Guid wholesalerId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateStockItem(BeerStockItem item)
        {
            throw new NotImplementedException();
        }
    }
}
