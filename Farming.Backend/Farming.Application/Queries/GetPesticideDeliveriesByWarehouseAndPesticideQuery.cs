using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPesticideDeliveriesByWarehouseAndPesticideQuery : IRequest<PesticideDeliveryByWarehouseAndPesticideDto>
    {
        public Guid WarehouseId { get; set; }
        public Guid PesticideId { get; set; }

        public GetPesticideDeliveriesByWarehouseAndPesticideQuery(Guid warehouseId, Guid pesticideId)
        {
            WarehouseId = warehouseId;
            PesticideId = pesticideId;
        }
    }
}
