using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllSeasonsQuery : IRequest<IEnumerable<SeasonDto>>
    {
    }
}
