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
        private readonly IUserReadService _userReadService;
        private readonly IFertilizerReadService _fertilizerReadService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFertilizerWarehouseDeliveryFactory _fertilizerWarehouseDeliveryFactory;

        public AddFertilizerWarehouseDeliveryHandler(IFertilizerWarehouseRepository fertilizerWarehouseRepository,
            IUserReadService userReadService, IFertilizerReadService fertilizerReadService, IUnitOfWork unitOfWork)
        {
            _fertilizerWarehouseRepository = fertilizerWarehouseRepository;
            _userReadService = userReadService;
            _fertilizerReadService = fertilizerReadService;
            _unitOfWork = unitOfWork;

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

            var delivery = _fertilizerWarehouseDeliveryFactory.Create(command.FertilizerId,
                command.UserId, command.Quantity, command.Price);

            if (!await _fertilizerReadService.ExistsByIdAsync(command.FertilizerId))
            {
                throw new FertilizerNotFoundException(command.FertilizerId);
            }

            if (!await _userReadService.ExistsByIdAsync(command.UserId))
            {
                throw new UserNotFoundException(command.UserId);
            }

            if (!await _userReadService.IsUserActiveByIdAsync(command.UserId))
            {
                throw new UserNotActiveException();
            }

            var fertilizerWarehouse = await _fertilizerWarehouseRepository.GetWithStateAndDeliveriesAsync(command.FertilizerWarehouseId);
            if (fertilizerWarehouse is null)
            {
                throw new FertilizerWarehouseNotFoundException(command.FertilizerWarehouseId);
            }

            fertilizerWarehouse.AddDelivery(delivery);

            await _fertilizerWarehouseRepository.UpdateAsync(fertilizerWarehouse);
            await _unitOfWork.CommitAsync();

            return new Response<AddFertilizerWarehouseDeliveryResponse>();
        }
    }
}
