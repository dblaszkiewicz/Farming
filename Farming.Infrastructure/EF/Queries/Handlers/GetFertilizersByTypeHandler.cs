using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetFertilizersByTypeHandler : IRequestHandler<GetFertilizersByTypeQuery, IEnumerable<FertilizerDto>>
    {
        private readonly DbSet<FertilizerReadModel> _fertilizers;

        public GetFertilizersByTypeHandler(ReadDbContext context)
        {
            _fertilizers = context.Fertilizers;
        }

        public async Task<IEnumerable<FertilizerDto>> Handle(GetFertilizersByTypeQuery request, CancellationToken cancellationToken)
        {
            return await _fertilizers
                .AsNoTracking()
                .Where(x => x.FertilizerTypeId == request.FertilizerTypeId)
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
