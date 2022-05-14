using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPlantActionsByLandAndSeasonHandler : IRequestHandler<GetPlantActionsByLandAndSeasonQuery, IEnumerable<PlantActionDto>>
    {
        private readonly DbSet<LandRealizationReadModel> _landRealizations;

        public GetPlantActionsByLandAndSeasonHandler(ReadDbContext context)
        {
            _landRealizations = context.LandRealizations;
        }

        public async Task<IEnumerable<PlantActionDto>> Handle(GetPlantActionsByLandAndSeasonQuery request, CancellationToken cancellationToken)
        {
            var landRealization = await _landRealizations
                .AsNoTracking()
                .Include(x => x.PlantActions)
                    .ThenInclude(x => x.User)
                .Include(x => x.PlantActions)
                    .ThenInclude(x => x.Plant)
                .FirstOrDefaultAsync(x => x.SeasonId == request.SeasonId && x.LandId == request.LandId);

            if (landRealization is not null && landRealization.PlantActions.Any())
            {
                return landRealization.PlantActions
                    .Select(x => new PlantActionDto
                    {
                        Name = x.Plant.Name,
                        Description = x.Plant.Description,
                        Quantity = x.Quantity,
                        Unit = x.Plant.Unit,
                        RealizationDate = x.RealizationDate,
                        UserName = x.User.Name
                    }).OrderBy(x => x.RealizationDate).ToList();
            }
            else
            {
                return Enumerable.Empty<PlantActionDto>();
            }
        }
    }
}
