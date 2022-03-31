using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllPesticidesHandler : IRequestHandler<GetAllPesticidesQuery, IEnumerable<PesticideDto>>
    {
        private readonly DbSet<PesticideReadModel> _pesticides;

        public GetAllPesticidesHandler(ReadDbContext context)
        {
            _pesticides = context.Pesticides;
        }

        public async Task<IEnumerable<PesticideDto>> Handle(GetAllPesticidesQuery request, CancellationToken cancellationToken)
        {
            return await _pesticides
                .AsNoTracking()
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
