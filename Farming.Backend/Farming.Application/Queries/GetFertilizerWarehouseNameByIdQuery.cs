using MediatR;

namespace Farming.Application.Queries
{
    public class GetFertilizerWarehouseNameByIdQuery : IRequest<string>
    {
        public Guid WarehouseId { get; set; }
        public GetFertilizerWarehouseNameByIdQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
