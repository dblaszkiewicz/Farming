using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetFertilizerStatesByWarehouseHandler : IRequestHandler<GetFertilizerStatesByWarehouseQuery, IEnumerable<FertilizerStateDto>>
    {
        private readonly DbSet<FertilizerWarehouseStateReadModel> _fertilizerWarehouseStates;

        public GetFertilizerStatesByWarehouseHandler(ReadDbContext context)
        {
            _fertilizerWarehouseStates = context.FertilizerWarehouseStates;
        }

        public async Task<IEnumerable<FertilizerStateDto>> Handle(GetFertilizerStatesByWarehouseQuery request, CancellationToken cancellationToken)
        {
            return await _fertilizerWarehouseStates
                .AsNoTracking()
                .Where(x => x.Quantity > 0)
                .Include(x => x.Fertilizer)
                    .ThenInclude(x => x.FertilizerType)
                .OrderBy(x => x.Quantity)
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
