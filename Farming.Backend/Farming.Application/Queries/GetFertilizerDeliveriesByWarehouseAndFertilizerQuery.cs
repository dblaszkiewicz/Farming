using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetFertilizerDeliveriesByWarehouseAndFertilizerQuery : IRequest<FertilizerDeliveryByWarehouseAndFertilizerDto>
    {
        public Guid WarehouseId { get; set; }
        public Guid FertilizerId { get; set; }

        public GetFertilizerDeliveriesByWarehouseAndFertilizerQuery(Guid warehouseId, Guid fertilizerId)
        {
            WarehouseId = warehouseId;
            FertilizerId = fertilizerId;
        }
    }
}
