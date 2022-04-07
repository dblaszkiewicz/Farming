using MediatR;

namespace Farming.Application.Queries
{
    public class GetPesticideWarehouseNameByIdQuery : IRequest<string>
    {
        public Guid WarehouseId { get; set; }
        public GetPesticideWarehouseNameByIdQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
