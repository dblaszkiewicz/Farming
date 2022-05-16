using Farming.Application.Commands;
using Farming.Application.Commands.Handlers;
using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace Farming.UnitTests.Application
{
    public class ProcessPesticideActionHandlerTests
    {
        [Fact]
        public async Task HandleAsync_Throws_PesticideWarehouseNotFoundException_When_Warehouse_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPesticideActionCommand(landId, userId, pesticideId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithPesticideActionsAsync().Returns(new Season());
            _pesticideRepository.GetAsync(pesticideId).Returns(new Pesticide());
            _landRepository.GetAsync(landId).Returns(new Land());
            _pesticideWarehouseRepository.GetWithStatesAndDeliveriesAsync(warehouseId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PesticideWarehouseNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_LandNotFoundException_When_Land_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPesticideActionCommand(landId, userId, pesticideId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithPesticideActionsAsync().Returns(new Season());
            _pesticideRepository.GetAsync(pesticideId).Returns(new Pesticide());
            _landRepository.GetAsync(landId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<LandNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_PesticideNotFoundException_When_Land_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPesticideActionCommand(landId, userId, pesticideId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithPesticideActionsAsync().Returns(new Season());
            _pesticideRepository.GetAsync(pesticideId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PesticideNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ActiveSeasonNotFoundException_When_There_Is_No_Active_Season()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPesticideActionCommand(landId, userId, pesticideId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithPesticideActionsAsync().ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ActiveSeasonNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_UserNotActiveException_When_Current_User_Is_Not_Active()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPesticideActionCommand(landId, userId, pesticideId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(false);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserNotActiveException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ValidateCommandException_Quantity_Is_Below_Or_Equal_Zero()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 0m;

            var command = new ProcessPesticideActionCommand(landId, userId, pesticideId, warehouseId, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        private readonly IRequestHandler<ProcessPesticideActionCommand,
            Response<ProcessPesticideActionResponse>> _handler;

        private readonly IUserReadService _userReadService;
        private readonly ISeasonRepository _seasonRepository;
        private readonly ILandRepository _landRepository;
        private readonly IPesticideRepository _pesticideRepository;
        private readonly IPesticideWarehouseRepository _pesticideWarehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessPesticideActionHandlerTests()
        {
            _userReadService = Substitute.For<IUserReadService>();
            _seasonRepository = Substitute.For<ISeasonRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _landRepository = Substitute.For<ILandRepository>();
            _pesticideRepository = Substitute.For<IPesticideRepository>();
            _pesticideWarehouseRepository = Substitute.For<IPesticideWarehouseRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            _handler = new ProcessPesticideActionHandler(_userReadService, _seasonRepository, _landRepository,
                _pesticideRepository, _pesticideWarehouseRepository, _unitOfWork);
        }

    }
}
