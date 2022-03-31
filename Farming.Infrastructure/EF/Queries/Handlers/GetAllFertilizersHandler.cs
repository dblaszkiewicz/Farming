using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllFertilizersHandler : IRequestHandler<GetAllFertilizersQuery, IEnumerable<FertilizerDto>>
    {
        private readonly DbSet<FertilizerReadModel> _fertilizers;

        public GetAllFertilizersHandler(ReadDbContext context)
        {
            _fertilizers = context.Fertilizers;
        }

        public async Task<IEnumerable<FertilizerDto>> Handle(GetAllFertilizersQuery request, CancellationToken cancellationToken)
        {
            return await _fertilizers
                .AsNoTracking()
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
