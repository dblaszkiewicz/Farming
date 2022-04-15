using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllLandsWithPlantQuery : IRequest<IEnumerable<LandWithPlantedDto>>
    {
    }
}
