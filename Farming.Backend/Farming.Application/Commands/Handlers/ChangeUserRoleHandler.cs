using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class ChangeUserRoleHandler : IRequestHandler<ChangeUserRoleCommand, Response<ChangeUserRoleResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserReadService _userReadService;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeUserRoleHandler(IUserRepository userRepository, IUserReadService userReadService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userReadService = userReadService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ChangeUserRoleResponse>> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
        {
            if (!await _userReadService.IsUserActiveByIdAsync(request.CurrentUserId))
            {
                throw new UserNotActiveException();
            }

            if (!await _userReadService.IsAdminByIdAsync(request.CurrentUserId))
            {
                throw new ChangeUserActiveNoPermissionException();
            }

            var user = await _userRepository.GetAsync(request.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            if (request.UserId == request.CurrentUserId)
            {
                throw new ChangeUserRolSelfDegradationException();
            }

            if (!await _userReadService.AreMoreActiveAdministratorsAsync(request.UserId))
            {
                throw new NoMoreActiveAdministratorException();
            }

            user.ChangeRole();

            await _userRepository.UpdateAsync(user);
            await _unitOfWork.CommitAsync();

            return new Response<ChangeUserRoleResponse>();
        }
    }
}
