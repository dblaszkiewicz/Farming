using Farming.Application.Commands.Responses;
using Farming.Application.Commands.Validators;
using Farming.Application.Commands.Validators.CommandValidators;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Exceptions;
using Farming.Domain.Factories;
using Farming.Domain.Repositories;
using Farming.Domain.Services;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{

    public sealed class ProcessPesticideActionHandler : IRequestHandler<ProcessPesticideActionCommand,
        Response<ProcessPesticideActionResponse>>
    {
        private readonly IPesticideDomainService _pesticideDomainService;
        private readonly IPesticideActionFactory _pesticideActionFactory;
        private readonly IUserReadService _userReadService;
        private readonly ISeasonRepository _seasonRepository;
        private readonly ILandRepository _landRepository;
        private readonly IPesticideRepository _pesticideRepository;
        private readonly IPesticideWarehouseRepository _pesticideWarehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessPesticideActionHandler(IUserReadService userReadService, ISeasonRepository seasonRepository,
            ILandRepository landRepository, IPesticideRepository pesticideRepository, IPesticideWarehouseRepository pesticideWarehouseRepository, 
            IUnitOfWork unitOfWork, IPesticideDomainService pesticideDomainService, IPesticideActionFactory pesticideActionFactory)
        {
            _pesticideDomainService = pesticideDomainService;
            _pesticideActionFactory = pesticideActionFactory;
            _userReadService = userReadService;
            _seasonRepository = seasonRepository;
            _landRepository = landRepository;
            _pesticideRepository = pesticideRepository;
            _pesticideWarehouseRepository = pesticideWarehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ProcessPesticideActionResponse>> Handle(ProcessPesticideActionCommand command, CancellationToken cancellationToken)
        {
            var validator = new ProcessPesticideActionCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            var pesticideAction = _pesticideActionFactory.Create(command.PesticideId, command.UserId, command.Quantity);

            if (!await _userReadService.ExistsByIdAsync(command.UserId))
            {
                throw new UserNotFoundException(command.UserId);
            }

            if (!await _userReadService.IsUserActiveByIdAsync(command.UserId))
            {
                throw new UserNotActiveException();
            }

            var currentSeason = await _seasonRepository.GetCurrentSeasonWithPesticideActionsAsync();
            if (currentSeason is null)
            {
                throw new ActiveSeasonNotFoundException();
            }

            var pesticide = await _pesticideRepository.GetAsync(command.PesticideId);
            if (pesticide is null)
            {
                throw new PesticideNotFoundException(command.PesticideId);
            }

            var land = await _landRepository.GetAsync(command.LandId);
            if (land is null)
            {
                throw new LandNotFoundException(command.LandId);
            }

            var pesticideWarehouseWithStates = await _pesticideWarehouseRepository.GetWithStatesAsync(command.PesticideWarehouseId);
            if (pesticideWarehouseWithStates is null)
            {
                throw new PesticideWarehouseNotFoundException(command.PesticideWarehouseId);
            }

            _pesticideDomainService.ProcessPesticideAction(currentSeason, pesticideWarehouseWithStates, pesticideAction, pesticide, land);

            await _seasonRepository.UpdateAsync(currentSeason);
            await _pesticideWarehouseRepository.UpdateAsync(pesticideWarehouseWithStates);

            await _unitOfWork.CommitAsync();

            return new Response<ProcessPesticideActionResponse>();
        }
    }
}
