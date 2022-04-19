using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class ChangeLandToHarvestedHandler : IRequestHandler<ChangeLandToHarvestedCommand, Response<ChangeLandToHarvestedResponse>>
    {
        private readonly ILandRepository _landRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeLandToHarvestedHandler(ILandRepository landRepository, IUnitOfWork unitOfWork)
        {
            _landRepository = landRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ChangeLandToHarvestedResponse>> Handle(ChangeLandToHarvestedCommand request, CancellationToken cancellationToken)
        {
            var land = await _landRepository.GetAsync(request.LandId);

            if (land is null)
            {
                throw new LandNotFoundException(request.LandId);
            }

            land.ChangeStatusToHarvested();

            await _landRepository.UpdateAsync(land);
            await _unitOfWork.CommitAsync();

            return new Response<ChangeLandToHarvestedResponse>();
        }
    }
}
