using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Validation
{
    public interface IWholesalerValidation
    {
        Task WholesalerExists(Guid id);
        Task StockItemExist(Guid id);
        Task ValidateStockItem(BeerStockItem item);
        Task ValidateQuoteRequest(QuoteRequest request);
    }
}
