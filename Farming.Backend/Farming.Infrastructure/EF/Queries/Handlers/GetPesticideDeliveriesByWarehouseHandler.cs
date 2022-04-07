using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPesticideDeliveriesByWarehouseHandler 
        : IRequestHandler<GetPesticideDeliveriesByWarehouseQuery, IEnumerable<PesticideDeliveryByWarehouseDto>>
    {
        private readonly DbSet<PesticideWarehouseReadModel> _pesticideWarehouses;
        private readonly DbSet<PesticideWarehouseDeliveryReadModel> _pesticideDeliveries;

        public GetPesticideDeliveriesByWarehouseHandler(ReadDbContext context)
        {
            _pesticideWarehouses = context.PesticideWarehouses;
            _pesticideDeliveries = context.PesticideWarehouseDeliveries;
        }

        public async Task<IEnumerable<PesticideDeliveryByWarehouseDto>> Handle(GetPesticideDeliveriesByWarehouseQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _pesticideWarehouses
                .AsNoTracking()
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            var statesIds = warehouse.States.Select(x => x.Id);

            return await _pesticideDeliveries
                .AsNoTracking()
                .Where(x => statesIds.Contains(x.PesticideWarehouseStateId))
                .Include(x => x.User)
                .Include(x => x.Pesticide)
                .Select(x => x.AsDtoByWarehouse())
                .ToListAsync();
        }
    }
}
