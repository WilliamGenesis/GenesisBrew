﻿using Domain.Models;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IWholesalerDataAccess
    {
        Task<Wholesaler[]> GetWholesalers();
        Task<Wholesaler> GetWholesaler(Guid id);
        Task<BeerStockItem> GetStockItem(Guid id);
        Task<BeerStockItem[]> GetWholesalerStock(Guid wholesalerId);
        Task<Wholesaler[]> GetWholesalersByItemId(Guid itemId);
        Task<Guid> CreateStockItem(BeerStockItem item);
        Task<Guid> UpdateStockItem(BeerStockItem item);
    }
}