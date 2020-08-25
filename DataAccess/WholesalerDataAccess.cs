using DataAccess.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class WholesalerDataAccess : IWholesalerDataAccess
    {
        private GenesisBrewContext _context;
        public WholesalerDataAccess(GenesisBrewContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateBeerStockItem(BeerStockItemEntity item)
        {
            var newBeerStockItem = await _context.StockItem.AddAsync(item);

            await _context.SaveChangesAsync();

            return newBeerStockItem.Entity.Id;
        }

        public async Task<BeerStockItemEntity> GetBeerStockItem(Guid id)
        {
            return await _context.StockItem.Include(item => item.Wholesaler)
                .FirstOrDefaultAsync(item => item.Id.Equals(id));
        }

        public async Task<WholesalerEntity> GetWholesaler(Guid id)
        {
            return await _context.Wholesaler.FirstOrDefaultAsync(wholesaler => wholesaler.Id.Equals(id));
        }

        public async Task<WholesalerEntity[]> GetWholesalers()
        {
            return await _context.Wholesaler.ToArrayAsync();
        }

        public async Task<WholesalerEntity[]> GetWholesalersByBeerId(Guid itemId)
        {
            return await _context.Wholesaler.Include(wholesaler => wholesaler.BeerStockItems)
                .Where(wholesaler => wholesaler.BeerStockItems.Select(item => item.Id).Contains(itemId))
                .ToArrayAsync();
        }

        public async Task<BeerStockItemEntity[]> GetWholesalerStock(Guid wholesalerId)
        {
            return await _context.StockItem.Include(item => item.Wholesaler)
                .Include(item => item.Beer)
                .ThenInclude(beer => beer.Brewery)
                .Where(item => item.WholesalerId.Equals(wholesalerId))
                .ToArrayAsync();
        }

        public async Task<Guid> UpdateStockItem(BeerStockItemEntity beerStockItem)
        {
            var beerStockItemToUpdate = await _context.StockItem.FirstOrDefaultAsync(item => item.Id.Equals(beerStockItem.Id));

            beerStockItemToUpdate.Quantity = beerStockItem.Quantity;
            beerStockItemToUpdate.UnitPrice = beerStockItem.UnitPrice;
            beerStockItemToUpdate.WholesalerId = beerStockItem.WholesalerId;
            beerStockItemToUpdate.BeerId = beerStockItem.BeerId;

            await _context.SaveChangesAsync();

            return beerStockItem.Id;
        }
    }
}
