using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPesticideStatesByWarehouseAndPlantHandler : IRequestHandler<GetPesticideStatesByWarehouseAndPlantQuery, IEnumerable<PesticideStateDto>>
    {
        private readonly DbSet<PesticideWarehouseStateReadModel> _pesticideWarehouseStates;
        private readonly DbSet<PlantReadModel> _plants;

        public GetPesticideStatesByWarehouseAndPlantHandler(ReadDbContext context)
        {
            _pesticideWarehouseStates = context.PesticideWarehouseStates;
            _plants = context.Plants;
        }

        public async Task<IEnumerable<PesticideStateDto>> Handle(GetPesticideStatesByWarehouseAndPlantQuery request, CancellationToken cancellationToken)
        {
            var suitablePesticideIds = (await _plants
                .Include(x => x.SuitablePesticides)
                .FirstOrDefaultAsync(x => x.Id == request.PlantId)).SuitablePesticides
                .Select(x => x.Id)
                .ToList();

            return await _pesticideWarehouseStates
                .AsNoTracking()
                .Where(x =>
                    x.PesticideWarehouseId == request.WarehouseId &&
                    x.Quantity > 0 &&
                    suitablePesticideIds.Contains(x.PesticideId))
                .Include(x => x.Pesticide)
                    .ThenInclude(x => x.PesticideType)
                .OrderByDescending(x => x.Quantity)
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
