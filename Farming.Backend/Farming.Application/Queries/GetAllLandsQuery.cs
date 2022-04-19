using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllLandsQuery : IRequest<IEnumerable<LandDto>>
    {
    }
}
