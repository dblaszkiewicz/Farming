using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class AddFertilizerWarehouseDeliveryCommand : IRequest<Response<AddFertilizerWarehouseDeliveryResponse>>
    {
        public Guid FertilizerWarehouseId { get; }
        public Guid FertilizerId { get; }
        public Guid UserId { get; }
        public decimal Price { get; }
        public decimal Quantity { get; }
    }
}
