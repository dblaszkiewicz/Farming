using Farming.Application.Commands.Responses;
using Farming.Application.Commands.Validators;
using Farming.Application.Exceptions;
using Farming.Domain.Factories;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class AddFertilizerWarehouseDeliveryHandler : IRequestHandler<AddFertilizerWarehouseDeliveryCommand, Response<AddFertilizerWarehouseDeliveryResponse>>
    {
        private readonly IFertilizerWarehouseRepository _fertilizerWarehouseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFertilizerRepository _fertilizerRepository;
        private readonly IFertilizerWarehouseDeliveryFactory _fertilizerWarehouseDeliveryFactory;


        public AddFertilizerWarehouseDeliveryHandler(IFertilizerWarehouseRepository fertilizerWarehouseRepository, IUserRepository userRepository, 
            IFertilizerRepository fertilizerRepository)
        {
            _fertilizerWarehouseRepository = fertilizerWarehouseRepository;
            _userRepository = userRepository;
            _fertilizerRepository = fertilizerRepository;
            _fertilizerWarehouseDeliveryFactory = new FertilizerWarehouseDeliveryFactory();
        }

        public async Task<Response<AddFertilizerWarehouseDeliveryResponse>> Handle(AddFertilizerWarehouseDeliveryCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddFertilizerWarehouseDeliveryCommandValidator();
            var validateResult = await validator.ValidateAsync(command);

            if (!validateResult.IsValid)
            {
                throw new ValidateCommandException(validateResult.ToString(". "));
            }

            var fertilizerWarehouse = await _fertilizerWarehouseRepository.GetAsync(command.FertilizerWarehouseId);
            if (fertilizerWarehouse is null)
            {
                throw new FertilizerWarehouseNotFoundException(command.FertilizerWarehouseId);
            }

            var fertilizer = await _fertilizerRepository.GetAsync(command.FertilizerId);
            if (fertilizer is null)
            {
                throw new FertilizerNotFoundException(command.FertilizerId);
            }

            var user = await _userRepository.GetAsync(command.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var deliveryId = Guid.NewGuid();

            var delivery = _fertilizerWarehouseDeliveryFactory.Create(deliveryId, command.FertilizerId, command.UserId,
                command.Quantity, command.Price);

            fertilizerWarehouse.AddDelivery(delivery);

            await _fertilizerWarehouseRepository.UpdateAsync(fertilizerWarehouse);

            return ResponseFactory.CreateSuccessResponse<AddFertilizerWarehouseDeliveryResponse>();
        }
    }
}
