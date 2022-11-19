using Farming.Application.Commands;
using Farming.Application.Commands.Handlers;
using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;
using NSubstitute;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Farming.UnitTests.Application
{
    public class AddUserHandlerTests
    {
        [Fact]
        public async Task HandleAsync_Throws_ValidateCommandException_Login_Is_Already_Taken()
        {
            var currentUserId = Guid.NewGuid();
            var command = new AddUserCommand("admin", "Admin", "Haslo12", "Haslo12", currentUserId);

            _userReadService.IsLoginAlreadyTakenAsync(command.Login).Returns(true);
            _userReadService.ExistsByIdAsync(command.CurrentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(command.CurrentUserId).Returns(true);
            _userReadService.IsAdminByIdAsync(command.CurrentUserId).Returns(true);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }


        private readonly IRequestHandler<AddUserCommand, Response<AddUserResponse>> _handler;
        private readonly IUserReadService _userReadService;

        public AddUserHandlerTests()
        {
            var _userRepository = Substitute.For<IUserRepository>();
            var _unitOfWork = Substitute.For<IUnitOfWork>();

            _userReadService = Substitute.For<IUserReadService>();
            _handler = new AddUserHandler(_userRepository, _userReadService, _unitOfWork);
        }
    }
}
