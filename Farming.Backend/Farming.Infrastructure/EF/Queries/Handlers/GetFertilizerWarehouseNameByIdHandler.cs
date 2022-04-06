using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetFertilizerWarehouseNameByIdHandler : IRequestHandler<GetFertilizerWarehouseNameByIdQuery, string>
    {
        private readonly DbSet<FertilizerWarehouseReadModel> _fertilizerWarehouses;

        public GetFertilizerWarehouseNameByIdHandler(ReadDbContext context)
        {
            _fertilizerWarehouses = context.FertilizerWarehouses;
        }

        public async Task<string> Handle(GetFertilizerWarehouseNameByIdQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _fertilizerWarehouses.FirstOrDefaultAsync(x => x.Id == request.WarehouseId);

            return warehouse.Name;
        }
    }
}
