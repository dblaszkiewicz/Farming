using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPesticideStatesByWarehouseHandler : IRequestHandler<GetPesticideStatesByWarehouseQuery, IEnumerable<PesticideStateDto>>
    {
        private readonly DbSet<PesticideWarehouseStateReadModel> _pesticideWarehouseStates;

        public GetPesticideStatesByWarehouseHandler(ReadDbContext context)
        {
            _pesticideWarehouseStates = context.PesticideWarehouseStates;
        }

        public async Task<IEnumerable<PesticideStateDto>> Handle(GetPesticideStatesByWarehouseQuery request, CancellationToken cancellationToken)
        {
            return await _pesticideWarehouseStates
                .AsNoTracking()
                .Where(x => x.Quantity > 0)
                .Include(x => x.Pesticide)
                    .ThenInclude(x => x.PesticideType)
                .OrderByDescending(x => x.Quantity)
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
