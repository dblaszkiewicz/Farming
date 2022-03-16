using Farming.Application.Commands.Responses;
using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class AddFertilizerWarehouseDeliveryHandler : IRequestHandler<AddFertilizerWarehouseDeliveryCommand, Response<AddFertilizerWarehouseDeliveryResponse>>
    {
        private readonly IFertilizerWarehouseRepository _fertilizerWarehouseRepository;
        public AddFertilizerWarehouseDeliveryHandler(IFertilizerWarehouseRepository fertilizerWarehouseRepository)
        {
            _fertilizerWarehouseRepository = fertilizerWarehouseRepository;
        }

        public async Task<Response<AddFertilizerWarehouseDeliveryResponse>> Handle(AddFertilizerWarehouseDeliveryCommand request, CancellationToken cancellationToken)
        {
            // fluent Validation requesta

            var fertilizerWarehouse = await _fertilizerWarehouseRepository.GetAsync(request.FertilizerWarehouseId);

            if (fertilizerWarehouse is null)
            {
                throw new Exception("Nie znaleziono magazynu");
            }

            // reczne mapowanie do obiektow domenowych

            var fertilizerId = new FertilizerId(request.FertilizerId);
            var userId = new UserId(request.UserId);
            var quantity = new FertilizerWarehouseDeliveryQuantity(request.Quantity);
            var price = new FertilizerWarehouseDeliveryPrice(request.Price);
            var realizationDate = new FertilizerWarehouseDeliveryRealizationDate();
            var deliveryId = new FertilizerWarehouseDeliveryId(Guid.NewGuid());

            var delivery = new FertilizerWarehouseDelivery(deliveryId, fertilizerId, userId, quantity, price, realizationDate);

            fertilizerWarehouse.AddDelivery(delivery);

            await _fertilizerWarehouseRepository.UpdateAsync(fertilizerWarehouse);

            return new Response<AddFertilizerWarehouseDeliveryResponse>
            {
                Succeeded = true,
                Error = null,
                Content = null
            };
        }
    }
}
