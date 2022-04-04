using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal class GetAllFertilizerWarehouseHandler : IRequestHandler<GetAllFertilizerWarehouseQuery, IEnumerable<FertilizerWarehouseDto>>
    {
        private readonly DbSet<FertilizerWarehouseReadModel> _fertilizerWarehouses;

        public GetAllFertilizerWarehouseHandler(ReadDbContext context)
        {
            _fertilizerWarehouses = context.FertilizerWarehouses;
        }

        public async Task<IEnumerable<FertilizerWarehouseDto>> Handle(GetAllFertilizerWarehouseQuery request, CancellationToken cancellationToken)
        {
            return await _fertilizerWarehouses
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
