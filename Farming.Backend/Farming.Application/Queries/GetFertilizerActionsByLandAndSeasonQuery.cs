using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetFertilizerActionsByLandAndSeasonQuery : IRequest<IEnumerable<FertilizerActionDto>>
    {
        public Guid SeasonId { get; set; }
        public Guid LandId { get; set; }

        public GetFertilizerActionsByLandAndSeasonQuery(Guid seasonId, Guid landId)
        {
            SeasonId = seasonId;
            LandId = landId;
        }
    }
}
