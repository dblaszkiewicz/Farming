using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPesticideActionsByLandAndSeasonHandler : IRequestHandler<GetPesticideActionsByLandAndSeasonQuery, IEnumerable<PesticideActionDto>>
    {
        private readonly DbSet<LandRealizationReadModel> _landRealizations;

        public GetPesticideActionsByLandAndSeasonHandler(ReadDbContext context)
        {
            _landRealizations = context.LandRealizations;
        }

        public async Task<IEnumerable<PesticideActionDto>> Handle(GetPesticideActionsByLandAndSeasonQuery request, CancellationToken cancellationToken)
        {
            var landRealization = await _landRealizations
                .AsNoTracking()
                .Include(x => x.PesticideActions)
                    .ThenInclude(x => x.User)
                .Include(x => x.PesticideActions)
                    .ThenInclude(x => x.Pesticide)
                .FirstOrDefaultAsync(x => x.SeasonId == request.SeasonId && x.LandId == request.LandId);

            if (landRealization is not null && landRealization.PesticideActions.Any())
            {
                return landRealization.PesticideActions
                    .Select(x => new PesticideActionDto
                    {
                        Name = x.Pesticide.Name,
                        Description = x.Pesticide.Description,
                        Quantity = x.Quantity,
                        RealizationDate = x.RealizationDate,
                        UserName = x.User.Name
                    }).OrderBy(x => x.RealizationDate).ToList();
            }
            else
            {
                return Enumerable.Empty<PesticideActionDto>();
            }
        }
    }
}
