﻿using Microservices.InventoryServices.Models;

namespace Microservices.InventoryServices.Repository
{
    public interface IInventoryRepository
    {
        Task<int> GetProductStockAsync(int productId);
        Task UpdateProductStockAsync(int productId, int quantity,int sales);
        Task AddNewInventoryItemAsync(Inventory item);
        Task<bool> DeleteInventoryItemAsync(int productId);
    }
}
