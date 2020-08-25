using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Validation
{
    public interface IWholesalerValidation
    {
        Task ValidateWholesalerExists(Guid id);
        Task ValidateBeerStockItemExist(Guid id);
        Task ValidateBeerStockItem(BeerStockItem item);
        Task ValidateQuoteRequest(QuoteRequest request);
    }
}
