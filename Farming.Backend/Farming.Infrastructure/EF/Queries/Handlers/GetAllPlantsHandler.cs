using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllPlantsHandler : IRequestHandler<GetAllPlantsQuery, IEnumerable<PlantDto>>
    {
        private readonly DbSet<PlantReadModel> _plants;

        public GetAllPlantsHandler(ReadDbContext context)
        {
            _plants = context.Plants;
        }

        public async Task<IEnumerable<PlantDto>> Handle(GetAllPlantsQuery request, CancellationToken cancellationToken)
        {
            return await _plants
                .AsNoTracking()
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
