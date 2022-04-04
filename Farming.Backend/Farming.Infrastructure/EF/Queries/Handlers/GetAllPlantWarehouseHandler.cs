using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllPlantWarehouseHandler : IRequestHandler<GetAllPlantWarehousesQuery, IEnumerable<PlantWarehouseDto>>
    {
        private readonly DbSet<PlantWarehouseReadModel> _plantWarehouses;
        public GetAllPlantWarehouseHandler(ReadDbContext context)
        {
            _plantWarehouses = context.PlantWarehouses;
        }

        public async Task<IEnumerable<PlantWarehouseDto>> Handle(GetAllPlantWarehousesQuery request, CancellationToken cancellationToken)
        {
            return await _plantWarehouses
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
