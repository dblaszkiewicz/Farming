using Farming.Application.Commands.Responses;
using Farming.Application.Commands.Validators;
using Farming.Application.Exceptions;
using Farming.Domain.Factories;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class AddPlantWarehouseDeliveryHandler : IRequestHandler<AddPlantWarehouseDeliveryCommand,
        Response<AddPlantWarehouseDeliveryResponse>>
    {
        private readonly IPlantWarehouseRepository _plantWarehouseRepository;
        private readonly IPlantRepository _plantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPlantWarehouseDeliveryFactory _plantWarehouseDeliveryFactory;

        public AddPlantWarehouseDeliveryHandler(IPlantWarehouseRepository plantWarehouseRepository, IPlantRepository plantRepository, 
            IUserRepository userRepository)
        {
            _plantWarehouseRepository = plantWarehouseRepository;
            _plantRepository = plantRepository;
            _userRepository = userRepository;
            _plantWarehouseDeliveryFactory = new PlantWarehouseDeliveryFactory();
        }

        public async Task<Response<AddPlantWarehouseDeliveryResponse>> Handle(AddPlantWarehouseDeliveryCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddPlantWarehouseDeliveryCommandValidator();
            var validateResult = await validator.ValidateAsync(command);

            if (!validateResult.IsValid)
            {
                throw new ValidateCommandException(validateResult.ToString(". "));
            }

            var plantWarehouse = await _plantWarehouseRepository.GetAsync(command.PlantWarehouseId);
            if (plantWarehouse is null)
            {
                throw new PlantWarehouseNotFoundException(command.PlantWarehouseId);
            }

            var plant = await _plantRepository.GetAsync(command.PlantId);
            if (plant is null)
            {
                throw new PlantNotFoundException(command.PlantId);
            }

            var user = await _userRepository.GetAsync(command.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var deliveryId = Guid.NewGuid();

            var delivery = _plantWarehouseDeliveryFactory.Create(deliveryId, command.PlantId, command.UserId,
                command.Quantity, command.Price);

            plantWarehouse.AddDelivery(delivery);

            await _plantWarehouseRepository.UpdateAsync(plantWarehouse);

            return ResponseFactory.CreateSuccessResponse<AddPlantWarehouseDeliveryResponse>();
        }
    }
}
