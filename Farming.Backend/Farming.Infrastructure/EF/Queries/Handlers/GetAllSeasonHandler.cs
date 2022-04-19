using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllSeasonHandler : IRequestHandler<GetAllSeasonsQuery, IEnumerable<SeasonDto>>
    {
        private readonly DbSet<SeasonReadModel> _seasons;

        public GetAllSeasonHandler(ReadDbContext context)
        {
            _seasons = context.Seasons;
        }

        public async Task<IEnumerable<SeasonDto>> Handle(GetAllSeasonsQuery request, CancellationToken cancellationToken)
        {
            return await _seasons.Select(x => new SeasonDto
            {
                Id = x.Id,
                StartDate = x.StartDate
            }).OrderByDescending(x => x.StartDate).ToListAsync();
        }
    }
}
