using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetFertilizerDeliveriesByWarehouseQuery : IRequest<IEnumerable<FertilizerDeliveryByWarehouseDto>>
    {
        public Guid WarehouseId { get; set; }

        public GetFertilizerDeliveriesByWarehouseQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
