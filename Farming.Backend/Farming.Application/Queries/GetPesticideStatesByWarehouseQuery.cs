using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPesticideStatesByWarehouseQuery : IRequest<IEnumerable<PesticideStateDto>>
    {
        public Guid WarehouseId { get; set; }

        public GetPesticideStatesByWarehouseQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
