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
    internal sealed class AddPesticideWarehouseDeliveryHandler : IRequestHandler<AddPesticideWarehouseDeliveryCommand, 
        Response<AddPesticideWarehouseDeliveryResponse>>
    {
        private readonly IPesticideWarehouseRepository _pesticideWarehouseRepository;
        private readonly IPesticideWarehouseDeliveryFactory _pesticideWarehouseDeliveryFactory;
        private readonly IPesticideReadService _pesticideReadService;
        private readonly IUserReadService _userReadService;
        private readonly IUnitOfWork _unitOfWork;

        public AddPesticideWarehouseDeliveryHandler(IPesticideWarehouseRepository pesticideWarehouseRepository,
            IUnitOfWork unitOfWork, IUserReadService userReadService, IPesticideReadService pesticideReadService)
        {
            _pesticideWarehouseRepository = pesticideWarehouseRepository;
            _unitOfWork = unitOfWork;
            _userReadService = userReadService;
            _pesticideReadService = pesticideReadService;

            _pesticideWarehouseDeliveryFactory = new PesticideWarehouseDeliveryFactory();
        }

        public async Task<Response<AddPesticideWarehouseDeliveryResponse>> Handle(AddPesticideWarehouseDeliveryCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddPesticideWarehouseDeliveryCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            var delivery = _pesticideWarehouseDeliveryFactory.Create(command.PesticideId, command.UserId,
                command.Quantity, command.Price);

            if (!await _pesticideReadService.ExistsByIdAsync(command.PesticideId))
            {
                throw new PesticideNotFoundException(command.PesticideId);
            }

            if (!await _userReadService.ExistsByIdAsync(command.UserId))
            {
                throw new UserNotFoundException(command.UserId);
            }

            var pesticideWarehouse = await _pesticideWarehouseRepository.GetWithStatesAndDeliveriesAsync(command.PesticideWarehouseId);
            if (pesticideWarehouse is null)
            {
                throw new PesticideWarehouseNotFoundException(command.PesticideWarehouseId);
            }

            pesticideWarehouse.AddDelivery(delivery);

            await _pesticideWarehouseRepository.UpdateAsync(pesticideWarehouse);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.CreateSuccessResponse<AddPesticideWarehouseDeliveryResponse>();
        }
    }
}
