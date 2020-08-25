using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class WholesalerValidation : IWholesalerValidation
    {
        public Task StockItemExist(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task ValidateQuoteRequest(QuoteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task ValidateStockItem(BeerStockItem item)
        {
            throw new NotImplementedException();
        }

        public Task WholesalerExists(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
