using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetFertilizerDeliveriesByWarehouseAndFertilizerHandler
        : IRequestHandler<GetFertilizerDeliveriesByWarehouseAndFertilizerQuery,
            FertilizerDeliveryByWarehouseAndFertilizerDto>
    {
        private readonly DbSet<FertilizerWarehouseReadModel> _fertilizerWarehouses;
        private readonly DbSet<FertilizerWarehouseDeliveryReadModel> _fertilizerDeliveries;

        public GetFertilizerDeliveriesByWarehouseAndFertilizerHandler(ReadDbContext context)
        {
            _fertilizerWarehouses = context.FertilizerWarehouses;
            _fertilizerDeliveries = context.FertilizerWarehouseDeliveries;
        }

        public async Task<FertilizerDeliveryByWarehouseAndFertilizerDto> Handle(GetFertilizerDeliveriesByWarehouseAndFertilizerQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _fertilizerWarehouses
                .AsNoTracking()
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            var statesIds = warehouse.States
                .Where(x => x.FertilizerId == request.FertilizerId)
                .Select(x => x.Id);

            var deliveries = await _fertilizerDeliveries
                .AsNoTracking()
                .Where(x => statesIds.Contains(x.FertilizerWarehouseStateId))
                .Include(x => x.User)
                .Include(x => x.Fertilizer)
                .Select(x => x.AsDtoByFertilzier())
                .ToListAsync();

            var averagePricePerTon = deliveries.Sum(x => x.PricePerTon) / deliveries.Count;

            return new FertilizerDeliveryByWarehouseAndFertilizerDto()
            {
                Deliveries = deliveries,
                AveragePricePerTon = averagePricePerTon
            };
        }
    }
}
