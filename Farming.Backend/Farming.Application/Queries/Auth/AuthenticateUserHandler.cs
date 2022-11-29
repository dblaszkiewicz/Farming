using Farming.Application.Auth;
using Farming.Application.Commands.Validators;
using Farming.Application.Exceptions;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Queries.Auth
{
    internal sealed class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, Response<AuthenticateUserResponse>>
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUserRepository _userRepository;

        public AuthenticateUserHandler(IAuthenticateService authenticateService, IUserRepository userRepository)
        {
            _authenticateService = authenticateService;
            _userRepository = userRepository;
        }

        public async Task<Response<AuthenticateUserResponse>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var validator = new AuthenticateUserQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            var user = await _userRepository.GetByLoginAndPasswordAsync(request.Login, request.Password);

            if (user is null)
            {
                throw new AuthenticationUserNotFoundException();
            }

            var token = this._authenticateService.Authenticate(user);

            return new Response<AuthenticateUserResponse>(new AuthenticateUserResponse(token));
        }
    }
}
