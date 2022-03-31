using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetSuitablePesticidesByPlantQuery : IRequest<IEnumerable<PesticideDto>>
    {
        public Guid PlantId { get; set; }
        public GetSuitablePesticidesByPlantQuery(Guid plantId)
        {
            PlantId = plantId;
        }
    }
}
