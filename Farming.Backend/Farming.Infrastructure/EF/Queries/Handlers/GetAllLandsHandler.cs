using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllLandsHandler : IRequestHandler<GetAllLandsQuery, IEnumerable<LandDto>>
    {
        private readonly DbSet<LandReadModel> _lands;

        public GetAllLandsHandler(ReadDbContext context)
        {
            _lands = context.Lands;
        }

        public async Task<IEnumerable<LandDto>> Handle(GetAllLandsQuery request, CancellationToken cancellationToken)
        {
            return await _lands.Select(x => x.AsDto()).ToListAsync();
        }
    }
}
