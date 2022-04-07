using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPlantWarehouseNameByIdHandler : IRequestHandler<GetPlantWarehouseNameByIdQuery, string>
    {

        private readonly DbSet<PlantWarehouseReadModel> _plantWarehouse;

        public GetPlantWarehouseNameByIdHandler(ReadDbContext context)
        {
            _plantWarehouse = context.PlantWarehouses;
        }

        public async Task<string> Handle(GetPlantWarehouseNameByIdQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _plantWarehouse.FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            return warehouse.Name;
        }
    }
}
