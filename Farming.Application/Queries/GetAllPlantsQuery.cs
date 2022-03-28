using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllPlantsQuery : IRequest<IEnumerable<PlantDto>>
    {
    }
}
