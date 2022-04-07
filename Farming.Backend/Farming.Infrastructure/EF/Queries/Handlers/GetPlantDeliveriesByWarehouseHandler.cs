using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPlantDeliveriesByWarehouseHandler : IRequestHandler<GetPlantDeliveriesByWarehouseQuery, IEnumerable<PlantDeliveryByWarehouseDto>>
    {
        private readonly DbSet<PlantWarehouseReadModel> _plantWarehouse;
        private readonly DbSet<PlantWarehouseDeliveryReadModel> _plantDeliveries;

        public GetPlantDeliveriesByWarehouseHandler(ReadDbContext context)
        {
            _plantWarehouse = context.PlantWarehouses;
            _plantDeliveries = context.PlantWarehouseDeliveries;
        }

        public async Task<IEnumerable<PlantDeliveryByWarehouseDto>> Handle(GetPlantDeliveriesByWarehouseQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _plantWarehouse
                .AsNoTracking()
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            var statesIds = warehouse.States.Select(x => x.Id);

            return await _plantDeliveries
                .AsNoTracking()
                .Where(x => statesIds.Contains(x.PlantWarehouseStateId))
                .Include(x => x.User)
                .Include(x => x.Plant)
                .Select(x => x.AsDtoByWarehouse())
                .ToListAsync();
        }
    }
}
