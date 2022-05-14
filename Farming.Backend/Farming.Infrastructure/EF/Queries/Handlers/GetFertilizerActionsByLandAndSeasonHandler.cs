using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetFertilizerActionsByLandAndSeasonHandler : IRequestHandler<GetFertilizerActionsByLandAndSeasonQuery, IEnumerable<FertilizerActionDto>>
    {
        private readonly DbSet<LandRealizationReadModel> _landRealizations;

        public GetFertilizerActionsByLandAndSeasonHandler(ReadDbContext context)
        {
            _landRealizations = context.LandRealizations;
        }

        public async Task<IEnumerable<FertilizerActionDto>> Handle(GetFertilizerActionsByLandAndSeasonQuery request, CancellationToken cancellationToken)
        {
            var landRealization = await _landRealizations
                .AsNoTracking()
                .Include(x => x.FertilizerActions)
                    .ThenInclude(x => x.User)
                .Include(x => x.FertilizerActions)
                    .ThenInclude(x => x.Fertilizer)
                .FirstOrDefaultAsync(x => x.SeasonId == request.SeasonId && x.LandId == request.LandId);

            if (landRealization is not null && landRealization.FertilizerActions.Any())
            {
                return landRealization.FertilizerActions
                    .Select(x => new FertilizerActionDto
                    {
                        Name = x.Fertilizer.Name,
                        Description = x.Fertilizer.Description,
                        Quantity = x.Quantity,
                        RealizationDate = x.RealizationDate,
                        UserName = x.User.Name
                    }).OrderBy(x => x.RealizationDate).ToList();
            }
            else
            {
                return Enumerable.Empty<FertilizerActionDto>();
            }
        }
    }
}
