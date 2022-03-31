using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetSuitablePesticidesByPlantHandler : IRequestHandler<GetSuitablePesticidesByPlantQuery, IEnumerable<PesticideDto>>
    {
        private readonly DbSet<PlantReadModel> _plants;

        public GetSuitablePesticidesByPlantHandler(ReadDbContext context)
        {
            _plants = context.Plants;
        }

        public async Task<IEnumerable<PesticideDto>> Handle(GetSuitablePesticidesByPlantQuery request, CancellationToken cancellationToken)
        {
            var plantWithPesticides = await _plants
                .AsNoTracking()
                .Include(x => x.SuitablePesticides)
                .FirstOrDefaultAsync(x => x.Id == request.PlantId);

            if (plantWithPesticides is null)
            {
                return null;
            }

            return plantWithPesticides.SuitablePesticides
                .Select(x => x.AsDto())
                .ToList();
        }
    }
}
