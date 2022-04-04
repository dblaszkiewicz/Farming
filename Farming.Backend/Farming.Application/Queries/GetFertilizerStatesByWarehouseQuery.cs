using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetFertilizerStatesByWarehouseQuery : IRequest<IEnumerable<FertilizerStateDto>>
    {
        public Guid WarehouseId { get; set; }

        public GetFertilizerStatesByWarehouseQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
