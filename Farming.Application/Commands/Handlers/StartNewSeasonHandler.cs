using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Domain.Entities;
using Farming.Domain.Factories;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class StartNewSeasonHandler : IRequestHandler<StartNewSeasonCommand, Response<StartNewSeasonResponse>>
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StartNewSeasonHandler(ISeasonRepository seasonRepository, IUnitOfWork unitOfWork)
        {
            _seasonRepository = seasonRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<StartNewSeasonResponse>> Handle(StartNewSeasonCommand request, CancellationToken cancellationToken)
        {
            var currentSeason = await _seasonRepository.GetCurrentSeasonAsync();

            if (currentSeason is not null)
            {
                throw new StartNewSeasonAnotherActiveException();
            }

            var newSeason = new Season();

            await _seasonRepository.AddAsync(newSeason);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.CreateSuccessResponse<StartNewSeasonResponse>();
        }
    }
}
