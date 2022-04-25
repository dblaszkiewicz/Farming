using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
