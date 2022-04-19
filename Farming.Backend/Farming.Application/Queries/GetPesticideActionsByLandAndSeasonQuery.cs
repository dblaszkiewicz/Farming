using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPesticideActionsByLandAndSeasonQuery : IRequest<IEnumerable<PesticideActionDto>>
    {
        public Guid SeasonId { get; set; }
        public Guid LandId { get; set; }

        public GetPesticideActionsByLandAndSeasonQuery(Guid seasonId, Guid landId)
        {
            SeasonId = seasonId;
            LandId = landId;
        }
    }
}
