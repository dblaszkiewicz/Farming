using Farming.Application.Commands.Responses;
using Farming.Application.Commands.Validators;
using Farming.Application.Commands.Validators.CommandValidators;
using Farming.Application.Exceptions;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, Response<ChangePasswordResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ChangePasswordResponse>> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var validator = new ChangePasswordCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            var user = await _userRepository.GetAsync(command.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }

            if (user.Password.Value != command.OldPassword)
            {
                throw new OldPasswordIncorrectException();
            }

            if (user.Password == command.NewPassword)
            {
                throw new NewPasswordSameAsOldException();
            }

            user.ChangePassword(command.NewPassword);

            await _userRepository.UpdateAsync(user);
            await _unitOfWork.CommitAsync();

            return new Response<ChangePasswordResponse>();
        }
    }
}
