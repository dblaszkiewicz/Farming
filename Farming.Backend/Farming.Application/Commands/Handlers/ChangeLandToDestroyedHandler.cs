using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class ChangeLandToDestroyedHandler : IRequestHandler<ChangeLandToDestroyedCommand, Response<ChangeLandToDestroyedResponse>>
    {
        private readonly ILandRepository _landRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeLandToDestroyedHandler(ILandRepository landRepository, IUnitOfWork unitOfWork)
        {
            _landRepository = landRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ChangeLandToDestroyedResponse>> Handle(ChangeLandToDestroyedCommand request, CancellationToken cancellationToken)
        {
            var land = await _landRepository.GetAsync(request.LandId);

            if (land is null)
            {
                throw new LandNotFoundException(request.LandId);
            }

            land.ChangeStatusToDestroyed();

            await _landRepository.UpdateAsync(land);
            await _unitOfWork.CommitAsync();

            return new Response<ChangeLandToDestroyedResponse>();
        }
    }
}
