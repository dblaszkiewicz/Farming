using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPesticidesByTypeHandler : IRequestHandler<GetPesticidesByTypeQuery, IEnumerable<PesticideDto>>
    {
        private readonly DbSet<PesticideReadModel> _pesticides;

        public GetPesticidesByTypeHandler(ReadDbContext context)
        {
            _pesticides = context.Pesticides;
        }

        public async Task<IEnumerable<PesticideDto>> Handle(GetPesticidesByTypeQuery request, CancellationToken cancellationToken)
        {
            return await _pesticides
                .AsNoTracking()
                .Where(x => x.PesticideTypeId == request.PesticideTypeId)
                .Select(x => x.AsDto())
                .ToListAsync();
        }
    }
}
