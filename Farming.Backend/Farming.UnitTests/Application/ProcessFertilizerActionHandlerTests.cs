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
    public class ProcessFertilizerActionHandlerTests
    {

        [Fact]
        public async Task HandleAsync_Throws_FertilizerWarehouseNotFoundException_When_Warehouse_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var fertilizerId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessFertilizerActionCommand(landId, userId, fertilizerId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithFertilzierActionsAsync().Returns(new Season());
            _fertilizerRepository.GetAsync(fertilizerId).Returns(new Fertilizer());
            _landRepository.GetAsync(landId).Returns(new Land());
            _fertilizerWarehouseRepository.GetWithStateAndDeliveriesAsync(warehouseId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<FertilizerWarehouseNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_LandNotFoundException_When_Land_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var fertilizerId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessFertilizerActionCommand(landId, userId, fertilizerId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithFertilzierActionsAsync().Returns(new Season());
            _fertilizerRepository.GetAsync(fertilizerId).Returns(new Fertilizer());
            _landRepository.GetAsync(landId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<LandNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_FertilizerNotFoundException_When_Fertilizer_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var fertilizerId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessFertilizerActionCommand(landId, userId, fertilizerId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithFertilzierActionsAsync().Returns(new Season());
            _fertilizerRepository.GetAsync(fertilizerId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<FertilizerNotFoundException>();
        }


        [Fact]
        public async Task HandleAsync_Throws_ActiveSeasonNotFoundException_When_There_Is_No_Active_Season()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var fertilizerId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessFertilizerActionCommand(landId, userId, fertilizerId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithFertilzierActionsAsync().ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ActiveSeasonNotFoundException>();
        }


        [Fact]
        public async Task HandleAsync_Throws_UserNotActiveException_When_Current_User_Is_Not_Active()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var fertilizerId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessFertilizerActionCommand(landId, userId, fertilizerId, warehouseId, quantity);

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
            var fertilizerId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = -1;

            var command = new ProcessFertilizerActionCommand(landId, userId, fertilizerId, warehouseId, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        private readonly IRequestHandler<ProcessFertilizerActionCommand,
            Response<ProcessFertilizerActionResponse>> _handler;

        private readonly IUserReadService _userReadService;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IFertilizerRepository _fertilizerRepository;
        private readonly IFertilizerWarehouseRepository _fertilizerWarehouseRepository;
        private readonly ILandRepository _landRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessFertilizerActionHandlerTests()
        {
            _userReadService = Substitute.For<IUserReadService>();
            _seasonRepository = Substitute.For<ISeasonRepository>();
            _fertilizerRepository = Substitute.For<IFertilizerRepository>();
            _fertilizerWarehouseRepository = Substitute.For<IFertilizerWarehouseRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _landRepository = Substitute.For<ILandRepository>();

            _handler = new ProcessFertilizerActionHandler(_userReadService, _seasonRepository, _fertilizerRepository,
                _fertilizerWarehouseRepository, _landRepository, _unitOfWork);
        }
    }
}
