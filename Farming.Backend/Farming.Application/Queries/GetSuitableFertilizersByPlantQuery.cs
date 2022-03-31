using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetSuitableFertilizersByPlantQuery : IRequest<IEnumerable<FertilizerDto>>
    {
        public Guid PlantId { get; set; }

        public GetSuitableFertilizersByPlantQuery(Guid plantId)
        {
            PlantId = plantId;
        }
    }
}
