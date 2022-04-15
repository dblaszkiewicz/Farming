using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetFertilizerStatesByWarehouseAndPlantHandler : IRequestHandler<GetFertilizerStatesByWarehouseAndPlantQuery, IEnumerable<FertilizerStateDto>>
    {
        private readonly DbSet<FertilizerWarehouseStateReadModel> _fertilizerWarehouseStates;
        private readonly DbSet<PlantReadModel> _plants;

        public GetFertilizerStatesByWarehouseAndPlantHandler(ReadDbContext context)
        {
            _fertilizerWarehouseStates = context.FertilizerWarehouseStates;
            _plants = context.Plants;
        }

        public async Task<IEnumerable<FertilizerStateDto>> Handle(GetFertilizerStatesByWarehouseAndPlantQuery request, CancellationToken cancellationToken)
        {
            var suitableFertilizerIds = (await _plants
                .Include(x => x.SuitableFertilizers)
                .FirstOrDefaultAsync(x => x.Id == request.PlantId)).SuitableFertilizers
                .Select(x => x.Id)
                .ToList();

            return await _fertilizerWarehouseStates
                .AsNoTracking()
                .Where(x => 
                    x.FertilizerWarehouseId == request.WarehouseId && 
                    x.Quantity > 0 && 
                    suitableFertilizerIds.Contains(x.FertilizerId))
                .Include(x => x.Fertilizer)
                    .ThenInclude(x => x.FertilizerType)
                .Include(x => x.Fertilizer)
                .OrderByDescending(x => x.Quantity)
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
