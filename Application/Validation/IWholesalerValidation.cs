using Domain.Models;
using System.Threading.Tasks;

namespace Application.Validation
{
    public interface IWholesalerValidation
    {
        Task ValidateStockItem(BeerStockItem item);
        Task ValidateQuoteRequest(QuoteRequest request);
    }
}
