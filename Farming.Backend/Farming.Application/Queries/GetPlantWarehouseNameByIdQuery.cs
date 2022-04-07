using MediatR;

namespace Farming.Application.Queries
{
    public class GetPlantWarehouseNameByIdQuery : IRequest<string>
    {
        public Guid WarehouseId { get; set; }

        public GetPlantWarehouseNameByIdQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
