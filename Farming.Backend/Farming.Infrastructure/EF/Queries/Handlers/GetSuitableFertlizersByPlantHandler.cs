using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetSuitableFertlizersByPlantHandler : IRequestHandler<GetSuitableFertilizersByPlantQuery, IEnumerable<FertilizerDto>>
    {
        private readonly DbSet<PlantReadModel> _plants;

        public GetSuitableFertlizersByPlantHandler(ReadDbContext context)
        {
            _plants = context.Plants;
        }

        public async Task<IEnumerable<FertilizerDto>> Handle(GetSuitableFertilizersByPlantQuery request, CancellationToken cancellationToken)
        {
            var plantWithFertilziers = await _plants
                .AsNoTracking()
                .Include(x => x.SuitableFertilizers)
                .FirstOrDefaultAsync(x => x.Id == request.PlantId);

            if (plantWithFertilziers is null)
            {
                return null;
            }

            return plantWithFertilziers.SuitableFertilizers
                .Select(x => x.AsDto())
                .ToList();
        }
    }
}
