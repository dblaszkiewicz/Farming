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
    public sealed class AddUserHandler : IRequestHandler<AddUserCommand, Response<AddUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserReadService _userReadService;
        private readonly IUnitOfWork _unitOfWork;

        public AddUserHandler(IUserRepository userRepository, IUserReadService userReadService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userReadService = userReadService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<AddUserResponse>> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddUserCommandValidator(_userReadService);
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidateCommandException(FluentValidationHelper.GetExceptionMessage(validationResult));
            }

            var currentUser = await _userRepository.GetAsync(command.CurrentUserId);

            if (currentUser is null)
            {
                throw new UserNotFoundException(command.CurrentUserId);
            }

            if (!currentUser.Active)
            {
                throw new UserNotActiveException();
            }

            if (!currentUser.IsAdmin)
            {
                throw new AddUserNoPermissionException();
            }

            var user = new User(command.Login, command.Password, command.Name, currentUser.TenantId);

            await _userRepository.AddAsync(user);

            await _unitOfWork.CommitAsync();

            return new Response<AddUserResponse>();
        }
    }
}
