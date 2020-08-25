using Application.Validation;
using DataAccess;
using Domain.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WholesalerService : IWholesalerService
    {
        private readonly IWholesalerDataAccess _wholesalerDataAccess;
        private readonly IWholesalerValidation _wholesalerValidation;
        public WholesalerService(IWholesalerDataAccess wholesalerDataAccess, IWholesalerValidation wholesalerValidation)
        {
            _wholesalerDataAccess = wholesalerDataAccess;
            _wholesalerValidation = wholesalerValidation;
        }
        public async Task<Guid> CreateStockItem(BeerStockItem item)
        {
            await _wholesalerValidation.ValidateBeerStockItem(item);

            return await _wholesalerDataAccess.CreateBeerStockItem(item.ToEntity());
        }

        public async Task<Quote> GenerateQuote(QuoteRequest request)
        {
            await _wholesalerValidation.ValidateQuoteRequest(request);

            var wholesalerStock = await _wholesalerDataAccess.GetWholesalerStock(request.WholesalerId);

            var quote = new Quote
            {
                WholesalerId = request.WholesalerId,
                QuotedItems = GetQuotedItems(request, wholesalerStock.ToModels()),
            };
            quote.RawPrice = quote.QuotedItems.Sum(item => item.UnitPrice * item.Quantity);
            quote.Discount = GetDiscount(quote.RawPrice, quote.QuotedItems.Sum(item => item.Quantity));
            quote.Price = quote.RawPrice - quote.Discount;

            return quote;
        }

        public async Task<Wholesaler[]> GetWholesalers()
        {
            var wholesalers = await _wholesalerDataAccess.GetWholesalers();

            return wholesalers.ToModels();
        }

        public async Task<Wholesaler[]> GetWholesalersByBeerId(Guid beerId)
        {
            var wholesalers = await _wholesalerDataAccess.GetWholesalersByBeerId(beerId);

            return wholesalers.ToModels();
        }

        public async Task<BeerStockItem[]> GetWholesalerStock(Guid wholesalerId)
        {
            var beerStockItems = await _wholesalerDataAccess.GetWholesalerStock(wholesalerId);

            return beerStockItems.ToModels();
        }

        public async Task<Guid> UpdateStockItem(BeerStockItem item)
        {
            await _wholesalerValidation.ValidateBeerStockItemExist(item.Id);
            await _wholesalerValidation.ValidateBeerStockItem(item);

            return await _wholesalerDataAccess.UpdateStockItem(item.ToEntity());
        }

        private BeerStockItem[] GetQuotedItems(QuoteRequest request, BeerStockItem[] wholesalerStock)
        {
            var requestedItems = new List<BeerStockItem>();

            foreach (var requestedItem in request.BeerRequests)
            {
                var wholesalerStockItem = wholesalerStock.FirstOrDefault(item => item.Beer.Id.Equals(requestedItem.BeerId));

                requestedItems.Add(
                    new BeerStockItem
                    {
                        Beer = wholesalerStockItem.Beer,
                        UnitPrice = wholesalerStockItem.UnitPrice,
                        Quantity = requestedItem.Quantity
                    });
            }

            return requestedItems.ToArray();
        }

        private float GetDiscount(float price, int quantity)
        {
            if (quantity <= 10)
                return 0;

            return quantity <= 20
                ? price * 0.1f
                : price * 0.2f;
        }
    }
}
