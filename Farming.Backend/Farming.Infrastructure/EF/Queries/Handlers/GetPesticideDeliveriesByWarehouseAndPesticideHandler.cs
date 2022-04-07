using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPesticideDeliveriesByWarehouseAndPesticideHandler
        : IRequestHandler<GetPesticideDeliveriesByWarehouseAndPesticideQuery,
            PesticideDeliveryByWarehouseAndPesticideDto>
    {
        private readonly DbSet<PesticideReadModel> _pesticides;
        private readonly DbSet<PesticideWarehouseReadModel> _pesticideWarehouses;
        private readonly DbSet<PesticideWarehouseDeliveryReadModel> _pesticideDeliveries;

        public GetPesticideDeliveriesByWarehouseAndPesticideHandler(ReadDbContext context)
        {
            _pesticides = context.Pesticides;
            _pesticideWarehouses = context.PesticideWarehouses;
            _pesticideDeliveries = context.PesticideWarehouseDeliveries;
        }

        public async Task<PesticideDeliveryByWarehouseAndPesticideDto> Handle(GetPesticideDeliveriesByWarehouseAndPesticideQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _pesticideWarehouses
                .AsNoTracking()
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            var statesIds = warehouse.States
                .Where(x => x.PesticideId == request.PesticideId)
                .Select(x => x.Id);

            var deliveries = await _pesticideDeliveries
                .AsNoTracking()
                .Where(x => statesIds.Contains(x.PesticideWarehouseStateId))
                .Include(x => x.User)
                .Select(x => x.AsDtoByPesticide())
                .ToListAsync();

            var averagePricePerLiter = deliveries.Sum(x => x.PricePerLiter) / deliveries.Count;

            var pesticide = await _pesticides.FirstOrDefaultAsync(x => x.Id == request.PesticideId);

            return new PesticideDeliveryByWarehouseAndPesticideDto()
            {
                Deliveries = deliveries,
                AveragePricePerLiter = averagePricePerLiter,
                Name = pesticide.Name
            };
        }
    }
}
