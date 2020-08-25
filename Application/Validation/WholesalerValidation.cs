using DataAccess;
using Domain.Exceptions;
using Domain.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class WholesalerValidation : IWholesalerValidation
    {
        private readonly IWholesalerDataAccess _wholesalerDataAccess;

        public WholesalerValidation(IWholesalerDataAccess wholesalerDataAccess)
        {
            _wholesalerDataAccess = wholesalerDataAccess;
        }

        public async Task ValidateBeerStockItemExist(Guid id)
        {
            var beerStockItem = await _wholesalerDataAccess.GetBeerStockItem(id);

            if (beerStockItem is null)
                throw new HttpException(HttpStatusCode.BadRequest, "The beer stock item does not exist");
        }

        public async Task ValidateQuoteRequest(QuoteRequest request)
        {
            ValidateQuoteRequestNotEmpty(request);
            ValidateQuoteRequestAllUnique(request);
            await ValidateWholesalerStockForRequest(request);
        }

        public async Task ValidateBeerStockItem(BeerStockItem item)
        {
            await ValidateWholesalerExists(item.Wholesaler?.Id ?? Guid.Empty);
        }

        public async Task ValidateWholesalerExists(Guid id)
        {
            var wholesaler = await _wholesalerDataAccess.GetWholesaler(id);

            if(wholesaler is null)
                throw new HttpException(HttpStatusCode.BadRequest, "The wholesaler does not exist");
        }

        #region Quote Request Validation

        private void ValidateQuoteRequestNotEmpty(QuoteRequest request)
        {
            if (request is null || request.BeerRequests is null || request.BeerRequests.Length == 0)
                throw new HttpException(HttpStatusCode.BadRequest, "Quote request cannot be empty");
        }

        private void ValidateQuoteRequestAllUnique(QuoteRequest request)
        {
            var allUnique = request.BeerRequests.GroupBy(x => x.BeerId).All(g => g.Count() == 1);

            if (!allUnique)
                throw new HttpException(HttpStatusCode.BadRequest, "All request items should be unique");
        }

        private async Task ValidateWholesalerStockForRequest(QuoteRequest request)
        {
            var wholesalerStock = await _wholesalerDataAccess.GetWholesalerStock(request.WholesalerId);

            foreach (var requestItem in request.BeerRequests)
            {
                var requestedItemInStock = wholesalerStock.FirstOrDefault(stockItem => stockItem.Beer.Id.Equals(requestItem.BeerId));

                if (requestedItemInStock is null)
                    throw new HttpException(HttpStatusCode.BadRequest, "Requested Item is not sold by this wholesaler");
                if (requestedItemInStock.Quantity < requestItem.Quantity)
                    throw new HttpException(HttpStatusCode.BadRequest, $"Requested quantity for item {requestItem.BeerId} is not available at this wholesaler");
            }
        }

        #endregion


    }
}
