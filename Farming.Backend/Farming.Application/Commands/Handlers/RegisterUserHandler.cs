﻿using Farming.Application.Commands.Responses;
using Farming.Application.Commands.Validators;
using Farming.Application.Commands.Validators.CommandValidators;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    public sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand,
        Response<RegisterUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserReadService _userReadService;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(IUserRepository userRepository, IUserReadService userReadService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userReadService = userReadService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<RegisterUserResponse>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new RegisterUserCommandValidator(_userReadService);
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            var user = new User(command.Login, command.Password, command.Name);

            await _userRepository.AddAsync(user);

            await _unitOfWork.CommitAsync();

            return new Response<RegisterUserResponse>();
        }
    }
}
