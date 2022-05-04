using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class EndCurrentSeasonHandler : IRequestHandler<EndCurrentSeasonCommand, Response<EndCurrentSeasonResponse>>
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IUserReadService _userReadService;
        private readonly IUnitOfWork _unitOfWork;

        public EndCurrentSeasonHandler(ISeasonRepository seasonRepository, IUserReadService userReadService, IUnitOfWork unitOfWork)
        {
            _seasonRepository = seasonRepository;
            _userReadService = userReadService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<EndCurrentSeasonResponse>> Handle(EndCurrentSeasonCommand request, CancellationToken cancellationToken)
        {
            if (!await _userReadService.IsUserActiveByIdAsync(request.CurrentUserId))
            {
                throw new UserNotActiveException();
            }

            var currentSeason = await _seasonRepository.GetCurrentSeasonAsync();

            if (currentSeason is null)
            {
                throw new EndCurrentSeasonNotFoundException();
            }

            currentSeason.EndSeason();

            await _seasonRepository.UpdateAsync(currentSeason);
            await _unitOfWork.CommitAsync();

            return new Response<EndCurrentSeasonResponse>();
        }
    }
}
