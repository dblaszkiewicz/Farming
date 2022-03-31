using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class StartNewSeasonCommand : IRequest<Response<StartNewSeasonResponse>>
    {
    }
}
