using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPesticideStatesByWarehouseAndPlantQuery : IRequest<IEnumerable<PesticideStateDto>>
    {
        public Guid WarehouseId { get; set; }
        public Guid PlantId { get; set; }
        public GetPesticideStatesByWarehouseAndPlantQuery(Guid warehouseId, Guid plantId)
        {
            this.WarehouseId = warehouseId;
            this.PlantId = plantId;
        }
    }
}
