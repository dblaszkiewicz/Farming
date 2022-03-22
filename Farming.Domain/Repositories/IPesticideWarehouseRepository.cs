﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Repositories
{
    public interface IPesticideWarehouseRepository
    {
        Task AddAsync(PesticideWarehouse pesticideWarehouse);
        Task<PesticideWarehouse> GetAsync(PesticideWarehouseId id);
        Task UpdateAsync(PesticideWarehouse pesticideWarehouse);
    }
}
