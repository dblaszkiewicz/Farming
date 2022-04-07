using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPlantStatesByWarehouseHandler : IRequestHandler<GetPlantStatesByWarehouseQuery, IEnumerable<PlantStateDto>>
    {
        private readonly DbSet<PlantWarehouseStateReadModel> _plantWarehouseStates;

        public GetPlantStatesByWarehouseHandler(ReadDbContext context)
        {
            _plantWarehouseStates = context.PlantWarehouseStates;
        }

        public async Task<IEnumerable<PlantStateDto>> Handle(GetPlantStatesByWarehouseQuery request, CancellationToken cancellationToken)
        {
            return await _plantWarehouseStates
                .AsNoTracking()
                .Where(x => x.PlantWarehouseId == request.WarehouseId && x.Quantity > 0)
                .Include(x => x.Plant)
                .OrderByDescending(x => x.Quantity)
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
