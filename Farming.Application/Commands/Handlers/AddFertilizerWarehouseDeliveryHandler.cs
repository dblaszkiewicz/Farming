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
    internal sealed class AddFertilizerWarehouseDeliveryHandler : IRequestHandler<AddFertilizerWarehouseDeliveryCommand, 
        Response<AddFertilizerWarehouseDeliveryResponse>>
    {
        private readonly IFertilizerWarehouseRepository _fertilizerWarehouseRepository;
        private readonly IFertilizerWarehouseDeliveryFactory _fertilizerWarehouseDeliveryFactory;
        private readonly IUserReadService _userReadService;
        private readonly IFertilizerReadService _fertilizerReadService;
        private readonly IFertilizerWarehouseReadService _fertilizerWarehouseReadService;
        private readonly IUnitOfWork _unitOfWork;


        public AddFertilizerWarehouseDeliveryHandler(IFertilizerWarehouseRepository fertilizerWarehouseRepository,
            IUnitOfWork unitOfWork, IUserReadService userReadService, IFertilizerReadService fertilizerReadService, IFertilizerWarehouseReadService fertilizerWarehouseReadService)
        {
            _fertilizerWarehouseRepository = fertilizerWarehouseRepository;
            _unitOfWork = unitOfWork;
            _userReadService = userReadService;
            _fertilizerReadService = fertilizerReadService;
            _fertilizerWarehouseReadService = fertilizerWarehouseReadService;
            _fertilizerWarehouseDeliveryFactory = new FertilizerWarehouseDeliveryFactory();
        }

        public async Task<Response<AddFertilizerWarehouseDeliveryResponse>> Handle(AddFertilizerWarehouseDeliveryCommand command, 
            CancellationToken cancellationToken)
        {
            var validator = new AddFertilizerWarehouseDeliveryCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            if (!await _fertilizerWarehouseReadService.ExistsByIdAsync(command.FertilizerWarehouseId))
            {
                throw new FertilizerWarehouseNotFoundException(command.FertilizerWarehouseId);
            }

            if (!await _fertilizerReadService.ExistsByIdAsync(command.FertilizerId))
            {
                throw new FertilizerNotFoundException(command.FertilizerId);
            }

            if (!await _userReadService.ExistsByIdAsync(command.UserId))
            {
                throw new UserDoesNotExistException(command.UserId);
            }

            var delivery = _fertilizerWarehouseDeliveryFactory.Create(command.FertilizerId,
                command.UserId, command.Quantity, command.Price);

            var fertilizerWarehouse = await _fertilizerWarehouseRepository.GetWithStateAndDeliveriesAsync(command.FertilizerWarehouseId);
            fertilizerWarehouse.AddDelivery(delivery);

            await _fertilizerWarehouseRepository.UpdateAsync(fertilizerWarehouse);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.CreateSuccessResponse<AddFertilizerWarehouseDeliveryResponse>();
        }
    }
}
