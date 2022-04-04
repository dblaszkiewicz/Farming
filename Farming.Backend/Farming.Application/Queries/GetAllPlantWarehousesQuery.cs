using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllPlantWarehousesQuery : IRequest<IEnumerable<PlantWarehouseDto>>
    {
    }
}
