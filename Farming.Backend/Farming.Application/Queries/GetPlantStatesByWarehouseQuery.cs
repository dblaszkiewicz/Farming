using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPlantStatesByWarehouseQuery : IRequest<IEnumerable<PlantStateDto>>
    {
        public Guid WarehouseId { get; set; }

        public GetPlantStatesByWarehouseQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
