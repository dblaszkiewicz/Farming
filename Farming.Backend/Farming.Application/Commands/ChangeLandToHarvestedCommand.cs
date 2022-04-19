using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class ChangeLandToHarvestedCommand : IRequest<Response<ChangeLandToHarvestedResponse>>
    {
        public Guid LandId { get; set; }
        public ChangeLandToHarvestedCommand(Guid landId)
        {
            LandId = landId;
        }
    }
}
