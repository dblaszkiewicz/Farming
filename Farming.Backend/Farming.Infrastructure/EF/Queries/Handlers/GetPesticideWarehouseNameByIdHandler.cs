using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPesticideWarehouseNameByIdHandler : IRequestHandler<GetPesticideWarehouseNameByIdQuery, string>
    {
        private readonly DbSet<PesticideWarehouseReadModel> _pesticideWarehouse;

        public GetPesticideWarehouseNameByIdHandler(ReadDbContext context)
        {
            _pesticideWarehouse = context.PesticideWarehouses;
        }

        public async Task<string> Handle(GetPesticideWarehouseNameByIdQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _pesticideWarehouse.FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            return warehouse.Name;
        }
    }
}
