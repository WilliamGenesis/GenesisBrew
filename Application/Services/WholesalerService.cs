using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WholesalerService : IWholesalerService
    {
        public Task<Guid> CreateStockItem(BeerStockItem item)
        {
            throw new NotImplementedException();
        }

        public Task<Quote> GenerateQuote(QuoteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Wholesaler[]> GetWholesalers()
        {
            throw new NotImplementedException();
        }

        public Task<Wholesaler[]> GetWholesalersByItem(Guid itemId)
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
