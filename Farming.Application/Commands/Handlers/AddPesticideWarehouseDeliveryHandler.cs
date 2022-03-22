using Farming.Application.Commands.Responses;
using Farming.Application.Commands.Validators;
using Farming.Application.Exceptions;
using Farming.Domain.Factories;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class AddPesticideWarehouseDeliveryHandler : IRequestHandler<AddPesticideWarehouseDeliveryCommand, 
        Response<AddPesticideWarehouseDeliveryResponse>>
    {
        private readonly IPesticideWarehouseRepository _pesticideWarehouseRepository;
        private readonly IPesticideRepository _pesticideRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPesticideWarehouseDeliveryFactory _pesticideWarehouseDeliveryFactory;

        public AddPesticideWarehouseDeliveryHandler(IPesticideWarehouseRepository pesticideWarehouseRepository, IPesticideRepository pesticideRepository, 
            IUserRepository userRepository)
        {
            _pesticideWarehouseRepository = pesticideWarehouseRepository;
            _pesticideRepository = pesticideRepository;
            _userRepository = userRepository;
            _pesticideWarehouseDeliveryFactory = new PesticideWarehouseDeliveryFactory();
        }

        public async Task<Response<AddPesticideWarehouseDeliveryResponse>> Handle(AddPesticideWarehouseDeliveryCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddPesticideWarehouseDeliveryCommandValidator();
            var validateResult = await validator.ValidateAsync(command);

            if (!validateResult.IsValid)
            {
                throw new ValidateCommandException(validateResult.ToString(". "));
            }

            var pesticideWarehouse = await _pesticideWarehouseRepository.GetAsync(command.PesticideWarehouseId);
            if (pesticideWarehouse is null)
            {
                throw new PesticideWarehouseNotFoundException(command.PesticideWarehouseId);
            }

            var pesticide = await _pesticideRepository.GetAsync(command.PesticideId);
            if (pesticide is null)
            {
                throw new PesticideNotFoundException(command.PesticideId);
            }

            var user = await _userRepository.GetAsync(command.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var deliveryId = Guid.NewGuid();

            var delivery = _pesticideWarehouseDeliveryFactory.Create(deliveryId, command.PesticideId, command.UserId,
                command.Quantity, command.Price);

            pesticideWarehouse.AddDelivery(delivery);

            await _pesticideWarehouseRepository.UpdateAsync(pesticideWarehouse);

            return ResponseFactory.CreateSuccessResponse<AddPesticideWarehouseDeliveryResponse>();
        }
    }
}
