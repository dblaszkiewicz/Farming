using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPlantDeliveriesByWarehouseQuery : IRequest<IEnumerable<PlantDeliveryByWarehouseDto>>
    {
        public Guid WarehouseId { get; set; }

        public GetPlantDeliveriesByWarehouseQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
