using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class ProcessPlantActionCommand : IRequest<Response<ProcessPlantActionResponse>>
    {
        public Guid LandId { get; set; }
        public Guid UserId { get; set; }
        public Guid PlantId { get; set; }
        public Guid PlantWarehouseId { get; set; }
        public decimal Quantity { get; set; }
    }
}
