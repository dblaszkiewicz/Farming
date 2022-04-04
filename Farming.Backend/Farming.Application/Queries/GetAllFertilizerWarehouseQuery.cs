using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllFertilizerWarehouseQuery : IRequest<IEnumerable<FertilizerWarehouseDto>>
    {
    }
}
