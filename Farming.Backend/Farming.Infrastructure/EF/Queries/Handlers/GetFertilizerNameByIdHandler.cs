using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetFertilizerNameByIdHandler : IRequestHandler<GetFertilizerNameByIdQuery, string>
    {
        private readonly DbSet<FertilizerReadModel> _fertilizers;

        public GetFertilizerNameByIdHandler(ReadDbContext context)
        {
            _fertilizers = context.Fertilizers;
        }

        public async Task<string> Handle(GetFertilizerNameByIdQuery request, CancellationToken cancellationToken)
        {
            var fertilizer = await _fertilizers.FirstOrDefaultAsync(x => x.Id == request.FertilizerId);

            return fertilizer.Name;
        }
    }
}
