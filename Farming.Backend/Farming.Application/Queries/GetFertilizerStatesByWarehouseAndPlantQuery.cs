using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetFertilizerStatesByWarehouseAndPlantQuery : IRequest<IEnumerable<FertilizerStateDto>>
    {
        public Guid WarehouseId { get; set; }
        public Guid PlantId { get; set; }

        public GetFertilizerStatesByWarehouseAndPlantQuery(Guid warehouseId, Guid plantId)
        {
            WarehouseId = warehouseId;
            PlantId = plantId;
        }
    }
}
