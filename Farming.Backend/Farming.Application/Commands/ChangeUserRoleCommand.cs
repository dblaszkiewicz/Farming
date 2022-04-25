using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class ChangeUserRoleCommand : IRequest<Response<ChangeUserRoleResponse>>
    {
        public Guid UserId { get; set; }
        public Guid CurrentUserId { get; set; }

        public ChangeUserRoleCommand(Guid userId, Guid currentUserId)
        {
            UserId = userId;
            CurrentUserId = currentUserId;
        }
    }
}
