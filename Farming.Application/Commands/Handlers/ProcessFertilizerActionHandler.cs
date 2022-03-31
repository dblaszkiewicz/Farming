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
    internal sealed class ProcessFertilizerActionHandler : IRequestHandler<ProcessFertilizerActionCommand, Response<ProcessFertilizerActionResponse>>
    {
        private readonly IFertilizerActionFactory _fertilizerActionFactory;
        private readonly IFertilizerDomainService _fertilizerDomainService;
        private readonly IUserReadService _userReadService;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IFertilizerRepository _fertilizerRepository;
        private readonly IFertilizerWarehouseRepository _fertilizerWarehouseRepository;
        private readonly ILandRepository _landRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessFertilizerActionHandler(IUserReadService userReadService, ISeasonRepository seasonRepository, 
            IFertilizerRepository fertilizerRepository, IFertilizerWarehouseRepository fertilizerWarehouseRepository, 
            ILandRepository landRepository, IUnitOfWork unitOfWork)
        {
            _fertilizerActionFactory = new FertilizerActionFactory();
            _fertilizerDomainService = new FertilizerDomainService();
            _userReadService = userReadService;
            _seasonRepository = seasonRepository;
            _fertilizerRepository = fertilizerRepository;
            _fertilizerWarehouseRepository = fertilizerWarehouseRepository;
            _unitOfWork = unitOfWork;
            _landRepository = landRepository;
        }

        public async Task<Response<ProcessFertilizerActionResponse>> Handle(ProcessFertilizerActionCommand command, CancellationToken cancellationToken)
        {
            var validator = new ProcessFertilizerActionCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            var fertilizerAction = _fertilizerActionFactory.Create(command.FertilizerId, command.UserId, command.Quantity);

            if (!await _userReadService.ExistsByIdAsync(command.UserId))
            {
                throw new UserNotFoundException(command.UserId);
            }

            var currentSeason = await _seasonRepository.GetCurrentSeasonAsync();
            if (currentSeason is null)
            {
                throw new ActiveSeasonNotFoundException();
            }

            var fertilizer = await _fertilizerRepository.GetAsync(command.FertilizerId);
            if (fertilizer is null)
            {
                throw new FertilizerNotFoundException(command.FertilizerId);
            }

            var land = await _landRepository.GetAsync(command.LandId);
            if (land is null)
            {
                throw new LandNotFoundException(command.LandId);
            }

            var fertilizerarehouseWithStates = await _fertilizerWarehouseRepository.GetWithStatesAsync(command.FertilizerWarehouseId);
            if (fertilizerarehouseWithStates is null)
            {
                throw new FertilizerWarehouseNotFoundException(command.FertilizerWarehouseId);
            }

            _fertilizerDomainService.ProcessFertilizerAction(currentSeason, fertilizerarehouseWithStates, fertilizerAction, fertilizer, land);

            await _seasonRepository.UpdateAsync(currentSeason);
            await _fertilizerWarehouseRepository.UpdateAsync(fertilizerarehouseWithStates);

            await _unitOfWork.CommitAsync();

            return new Response<ProcessFertilizerActionResponse>();
        }
    }
}
