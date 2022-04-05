using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllPesticideWarehousesHandler : IRequestHandler<GetAllPesticideWarehousesQuery, IEnumerable<PesticideWarehouseDto>>
    {
        private readonly DbSet<PesticideWarehouseReadModel> _pesticideWarehouses;

        public GetAllPesticideWarehousesHandler(ReadDbContext context)
        {
            _pesticideWarehouses = context.PesticideWarehouses;
        }

        public async Task<IEnumerable<PesticideWarehouseDto>> Handle(GetAllPesticideWarehousesQuery request, CancellationToken cancellationToken)
        {
            return await _pesticideWarehouses
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
