using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPlantActionsByLandAndSeasonQuery : IRequest<IEnumerable<PlantActionDto>>
    {
        public Guid SeasonId { get; set; }
        public Guid LandId { get; set; }

        public GetPlantActionsByLandAndSeasonQuery(Guid seasonId, Guid landId)
        {
            SeasonId = seasonId;
            LandId = landId;
        }
    }
}
