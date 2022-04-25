using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class ChangeUserActiveHandler : IRequestHandler<ChangeUserActiveCommand, Response<ChangeUserActiveResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserReadService _userReadService;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeUserActiveHandler(IUserRepository userRepository, IUserReadService userReadService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userReadService = userReadService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ChangeUserActiveResponse>> Handle(ChangeUserActiveCommand request, CancellationToken cancellationToken)
        {
            if (!await _userReadService.IsAdmin(request.CurrentUserId))
            {
                throw new ChangeUserActiveNoPermissionException();
            }

            var user = await _userRepository.GetAsync(request.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            if (request.CurrentUserId == request.UserId)
            {
                throw new ChangeUserSelfDeactivationException();
            }

            if (!await _userReadService.AreMoreActiveAdministrators(request.UserId))
            {
                throw new NoMoreActiveAdministratorException();
            }

            user.ChangeActive();

            await _userRepository.UpdateAsync(user);
            await _unitOfWork.CommitAsync();

            return new Response<ChangeUserActiveResponse>();
        }
    }
}
