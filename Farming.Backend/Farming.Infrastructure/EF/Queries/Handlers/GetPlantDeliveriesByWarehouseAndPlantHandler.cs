using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPlantDeliveriesByWarehouseAndPlantHandler
        : IRequestHandler<GetPlantDeliveriesByWarehouseAndPlantQuery, PlantDeliveryByWarehouseAndPlantDto>
    {

        private readonly DbSet<PlantReadModel> _plants;
        private readonly DbSet<PlantWarehouseReadModel> _plantWarehouse;
        private readonly DbSet<PlantWarehouseDeliveryReadModel> _plantDeliveries;

        public GetPlantDeliveriesByWarehouseAndPlantHandler(ReadDbContext context)
        {
            _plants = context.Plants;
            _plantWarehouse = context.PlantWarehouses;
            _plantDeliveries = context.PlantWarehouseDeliveries;
        }

        public async Task<PlantDeliveryByWarehouseAndPlantDto> Handle(GetPlantDeliveriesByWarehouseAndPlantQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _plantWarehouse
                .AsNoTracking()
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            var statesIds = warehouse.States
                .Where(x => x.PlantId == request.PlantId)
                .Select(x => x.Id);

            var deliveries = await _plantDeliveries
                .AsNoTracking()
                .Where(x => statesIds.Contains(x.PlantWarehouseStateId))
                .Include(x => x.User)
                .Include(x => x.Plant)
                .Select(x => x.AsDtoByPlant())
                .ToListAsync();

            var plant = await _plants.FirstOrDefaultAsync(x => x.Id == request.PlantId);

            return new PlantDeliveryByWarehouseAndPlantDto()
            {
                Deliveries = deliveries,
                Name = plant.Name,
            };
        }
    }
}
