using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPlantDeliveriesByWarehouseAndPlantQuery : IRequest<PlantDeliveryByWarehouseAndPlantDto>
    {
        public Guid WarehouseId { get; set; }
        public Guid PlantId { get; set; }

        public GetPlantDeliveriesByWarehouseAndPlantQuery(Guid warehouseId, Guid plantId)
        {
            WarehouseId = warehouseId;
            PlantId = plantId;
        }
    }
}
