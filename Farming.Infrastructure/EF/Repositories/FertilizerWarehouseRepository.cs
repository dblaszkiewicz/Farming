using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming.Infrastructure.EF.Repositories
{
    public sealed class FertilizerWarehouseRepository : IFertilizerWarehouseRepository
    {
        private readonly DbSet<FertilizerWarehouse> _fertilizerWarehouse;
        private readonly WriteDbContext _writeDbContext;

        public FertilizerWarehouseRepository(WriteDbContext writeDbContext)
        {
            _fertilizerWarehouse = writeDbContext.FertilizerWarehouses;
            _writeDbContext = writeDbContext;
        }

        public Task<FertilizerWarehouse> GetAsync(FertilizerWarehouseId id)
        {
            return _fertilizerWarehouse
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(FertilizerWarehouse fertilizerWarehouse)
        {
            _fertilizerWarehouse.Update(fertilizerWarehouse);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
