using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetCurrentSeasonHandler : IRequestHandler<GetCurrentSeasonQuery, SeasonDto>
    {
        private readonly DbSet<SeasonReadModel> _seasons;

        public GetCurrentSeasonHandler(ReadDbContext context)
        {
            _seasons = context.Seasons;
        }

        public async Task<SeasonDto> Handle(GetCurrentSeasonQuery request, CancellationToken cancellationToken)
        {
            var currentSeason = await _seasons.FirstOrDefaultAsync(x => x.Active);

            if (currentSeason is not null)
            {
                return new SeasonDto
                {
                    Id = currentSeason.Id,
                    StartDate = currentSeason.StartDate,
                };
            }

            return null;
        }
    }
}
