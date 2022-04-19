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
    internal sealed class ProcessPlantActionHandler : IRequestHandler<ProcessPlantActionCommand,
        Response<ProcessPlantActionResponse>>
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IPlantWarehouseRepository _plantWarehouseRepository;
        private readonly IUserReadService _userReadService;
        private readonly IPlantActionFactory _plantActionFactory;
        private readonly IPlantDomainService _plantDomainService;
        private readonly ILandRepository _landRepository;
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessPlantActionHandler(ISeasonRepository seasonRepository,
            IUserReadService userReadService, IUnitOfWork unitOfWork, 
            IPlantWarehouseRepository plantWarehouseRepository, ILandRepository landRepository, 
            IPlantRepository plantRepository)
        {
            _seasonRepository = seasonRepository;
            _userReadService = userReadService;
            _unitOfWork = unitOfWork;
            _plantWarehouseRepository = plantWarehouseRepository;
            _landRepository = landRepository;
            _plantRepository = plantRepository;
            _plantActionFactory = new PlantActionFactory();
            _plantDomainService = new PlantDomainService();
        }

        public async Task<Response<ProcessPlantActionResponse>> Handle(ProcessPlantActionCommand command,
            CancellationToken cancellationToken)
        {
            var validator = new ProcessPlantActionCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            var plantAction = _plantActionFactory.Create(command.PlantId, command.UserId, command.Quantity);

            if (!await _userReadService.ExistsByIdAsync(command.UserId))
            {
                throw new UserNotFoundException(command.UserId);
            }

            var currentSeason = await _seasonRepository.GetCurrentSeasonWithPlantActionsAsync();
            if (currentSeason is null)
            {
                throw new ActiveSeasonNotFoundException();
            }

            var plant = await _plantRepository.GetAsync(command.PlantId);
            if (plant is null)
            {
                throw new PlantNotFoundException(command.PlantId);
            }

            var land = await _landRepository.GetAsync(command.LandId);
            if (land is null)
            {
                throw new LandNotFoundException(command.LandId);
            }

            var plantWarehouseWithStates = await _plantWarehouseRepository.GetWithStatesAsync(command.PlantWarehouseId);
            if (plantWarehouseWithStates is null)
            {
                throw new PlantWarehouseNotFoundException(command.PlantWarehouseId);
            }

            _plantDomainService.ProcessPlantAction(currentSeason, plantWarehouseWithStates, plantAction, land, plant);

            await _landRepository.UpdateAsync(land);
            await _seasonRepository.UpdateAsync(currentSeason);
            await _plantWarehouseRepository.UpdateAsync(plantWarehouseWithStates);

            await _unitOfWork.CommitAsync();

            return new Response<ProcessPlantActionResponse>();
        }
    }
}
