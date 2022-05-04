﻿using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class ChangeLandToHarvestedHandler : IRequestHandler<ChangeLandToHarvestedCommand, Response<ChangeLandToHarvestedResponse>>
    {
        private readonly ILandRepository _landRepository;
        private readonly IUserReadService _userReadService;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeLandToHarvestedHandler(ILandRepository landRepository, IUserReadService userReadService, IUnitOfWork unitOfWork)
        {
            _landRepository = landRepository;
            _userReadService = userReadService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ChangeLandToHarvestedResponse>> Handle(ChangeLandToHarvestedCommand request, CancellationToken cancellationToken)
        {
            var land = await _landRepository.GetAsync(request.LandId);

            if (land is null)
            {
                throw new LandNotFoundException(request.LandId);
            }

            if (!await _userReadService.IsUserActiveByIdAsync(request.CurrentUserId))
            {
                throw new UserNotActiveException();
            }

            land.ChangeStatusToHarvested();

            await _landRepository.UpdateAsync(land);
            await _unitOfWork.CommitAsync();

            return new Response<ChangeLandToHarvestedResponse>();
        }
    }
}
