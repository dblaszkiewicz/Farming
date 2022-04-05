using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllPesticideWarehousesQuery : IRequest<IEnumerable<PesticideWarehouseDto>>
    {
    }
}
