using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IWholesalerService
    {
        Task<Wholesaler[]> GetWholesalers();
        Task<BeerStockItem[]> GetWholesalerStock(Guid wholesalerId);
        Task<Wholesaler[]> GetWholesalersByItem(Guid itemId);
        Task<Guid> CreateStockItem(BeerStockItem item);
        Task<Guid> UpdateStockItem(BeerStockItem item);
        Task<Quote> GenerateQuote(QuoteRequest request);
    }
}
