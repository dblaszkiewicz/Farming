using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class ChangeLandToDestroyedCommand : IRequest<Response<ChangeLandToDestroyedResponse>>
    {
        public Guid LandId { get; set; }
        public ChangeLandToDestroyedCommand(Guid landId)
        {
            LandId = landId;
        }
    }
}
