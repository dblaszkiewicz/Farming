using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class ProcessPesticideActionCommand : IRequest<Response<ProcessPesticideActionResponse>>
    {
        public Guid LandId { get; set; }
        public Guid UserId { get; set; }
        public Guid PesticideId { get; set; }
        public Guid PesticideWarehouseId { get; set; }
        public decimal Quantity { get; set; }
    }
}
