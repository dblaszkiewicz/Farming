﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;

namespace Farming.Domain.Repositories
{
    public interface IFertilizerWarehouseRepository
    {
        Task<FertilizerWarehouse> GetWithStateAndDeliveriesAsync(FertilizerWarehouseId id);
        Task<FertilizerWarehouse> GetWithStatesAsync(FertilizerWarehouseId id);
        Task UpdateAsync(FertilizerWarehouse fertilizerWarehouse);
        Task AddAsync(FertilizerWarehouse fertilizerWarehouse);
    }
}
