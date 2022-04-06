using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetFertilizerDeliveriesByWarehouseHandler : IRequestHandler<GetFertilizerDeliveriesByWarehouseQuery, IEnumerable<FertilizerDeliveryByWarehouseDto>>
    {
        private readonly DbSet<FertilizerWarehouseReadModel> _fertilizerWarehouses;
        private readonly DbSet<FertilizerWarehouseDeliveryReadModel> _fertilizerDeliveries;

        public GetFertilizerDeliveriesByWarehouseHandler(ReadDbContext context)
        {
            _fertilizerWarehouses = context.FertilizerWarehouses;
            _fertilizerDeliveries = context.FertilizerWarehouseDeliveries;
        }

        public async Task<IEnumerable<FertilizerDeliveryByWarehouseDto>> Handle(GetFertilizerDeliveriesByWarehouseQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _fertilizerWarehouses
                .AsNoTracking()
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            var statesIds = warehouse.States.Select(x => x.Id);

            return await _fertilizerDeliveries
                .AsNoTracking()
                .Where(x => statesIds.Contains(x.FertilizerWarehouseStateId))
                .Include(x => x.User)
                .Include(x => x.Fertilizer)
                .Select(x => x.AsDtoByWarehouse())
                .ToListAsync();
        }
    }
}
