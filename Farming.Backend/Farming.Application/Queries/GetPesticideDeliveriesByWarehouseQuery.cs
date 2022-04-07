using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPesticideDeliveriesByWarehouseQuery : IRequest<IEnumerable<PesticideDeliveryByWarehouseDto>>
    {
        public Guid WarehouseId { get; set; }

        public GetPesticideDeliveriesByWarehouseQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
