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
        private readonly IPesticideWarehouseReadService _pesticideWarehouseReadService;
        private readonly IUserReadService _userReadService;
        private readonly IUnitOfWork _unitOfWork;

        public AddPesticideWarehouseDeliveryHandler(IPesticideWarehouseRepository pesticideWarehouseRepository,
            IUnitOfWork unitOfWork, IUserReadService userReadService, IPesticideReadService pesticideReadService, IPesticideWarehouseReadService pesticideWarehouseReadService)
        {
            _pesticideWarehouseRepository = pesticideWarehouseRepository;
            _unitOfWork = unitOfWork;
            _userReadService = userReadService;
            _pesticideReadService = pesticideReadService;
            _pesticideWarehouseReadService = pesticideWarehouseReadService;

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

            if (!await _pesticideWarehouseReadService.ExistsByIdAsync(command.PesticideWarehouseId))
            {
                throw new PesticideWarehouseDoesNotExistException(command.PesticideWarehouseId);
            }

            if (!await _pesticideReadService.ExistsByIdAsync(command.PesticideId))
            {
                throw new PesticideDoesNotExistException(command.PesticideId);
            }

            if (!await _userReadService.ExistsByIdAsync(command.UserId))
            {
                throw new UserDoesNotExistException(command.UserId);
            }

            var delivery = _pesticideWarehouseDeliveryFactory.Create(command.PesticideId, command.UserId,
                command.Quantity, command.Price);

            var pesticideWarehouse = await _pesticideWarehouseRepository.GetWithStatesAndDeliveriesAsync(command.PesticideWarehouseId);
            pesticideWarehouse.AddDelivery(delivery);

            await _pesticideWarehouseRepository.UpdateAsync(pesticideWarehouse);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.CreateSuccessResponse<AddPesticideWarehouseDeliveryResponse>();
        }
    }
}
