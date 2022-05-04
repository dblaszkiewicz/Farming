using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class EndCurrentSeasonCommand : IRequest<Response<EndCurrentSeasonResponse>>
    {
        public Guid CurrentUserId { get; set; }
        public EndCurrentSeasonCommand(Guid currentUserId)
        {
            CurrentUserId = currentUserId;
        }
    }
}
