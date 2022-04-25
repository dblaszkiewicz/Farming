using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class ChangeUserActiveCommand : IRequest<Response<ChangeUserActiveResponse>>
    {
        public Guid UserId { get; set; }
        public Guid CurrentUserId { get; set; }

        public ChangeUserActiveCommand(Guid userId, Guid currentUserId)
        {
            UserId = userId;
            CurrentUserId = currentUserId;
        }
    }
}
