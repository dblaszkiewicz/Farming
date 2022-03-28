using Farming.Application.Commands.Responses;
using Farming.Application.Commands.Validators;
using Farming.Application.Commands.Validators.CommandValidators;
using Farming.Application.Exceptions;
using Farming.Application.Services;
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
        private readonly IPlantWarehouseDeliveryFactory _plantWarehouseDeliveryFactory;
        private readonly IUserReadService _userReadService;
        private readonly IPlantReadService _plantReadService;
        private readonly IPlantWarehouseReadService _plantWarehouseReadService;
        private readonly IUnitOfWork _unitOfWork;

        public AddPlantWarehouseDeliveryHandler(IPlantWarehouseRepository plantWarehouseRepository, IUnitOfWork unitOfWork, 
            IUserReadService userReadService, IPlantWarehouseReadService plantWarehouseReadService, IPlantReadService plantReadService)
        {
            _plantWarehouseRepository = plantWarehouseRepository;
            _userReadService = userReadService;
            _plantWarehouseReadService = plantWarehouseReadService;
            _plantReadService = plantReadService;
            _unitOfWork = unitOfWork;
            _plantWarehouseDeliveryFactory = new PlantWarehouseDeliveryFactory();
        }

        public async Task<Response<AddPlantWarehouseDeliveryResponse>> Handle(AddPlantWarehouseDeliveryCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddPlantWarehouseDeliveryCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            if (!await _plantWarehouseReadService.ExistsByIdAsync(command.PlantWarehouseId))
            {
                throw new PlantWarehouseDoesNotExistException(command.PlantWarehouseId);
            }

            if (!await _plantReadService.ExistsByIdAsync(command.PlantId))
            {
                throw new PlantDoesNotExistException(command.PlantId);
            }

            if (!await _userReadService.ExistsByIdAsync(command.UserId))
            {
                throw new UserDoesNotExistException(command.UserId);
            }

            var delivery = _plantWarehouseDeliveryFactory.Create(command.PlantId, command.UserId,
                command.Quantity, command.Price);

            var plantWarehouse = await _plantWarehouseRepository.GetWithStatesAndDeliveriesAsync(command.PlantWarehouseId);
            plantWarehouse.AddDelivery(delivery);

            await _plantWarehouseRepository.UpdateAsync(plantWarehouse);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.CreateSuccessResponse<AddPlantWarehouseDeliveryResponse>();
        }
    }
}
