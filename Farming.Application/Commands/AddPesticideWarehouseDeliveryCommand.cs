using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class AddPesticideWarehouseDeliveryCommand : IRequest<Response<AddPesticideWarehouseDeliveryResponse>>
    {
        public Guid PesticideWarehouseId { get; set; }
        public Guid PesticideId { get; set; }
        public Guid UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
