using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllPesticidesQuery : IRequest<IEnumerable<PesticideDto>>
    {
    }
}
