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
    public class ProcessPlantActionHandlerTests
    {
        [Fact]
        public async Task HandleAsync_Throws_PlantWarehouseNotFoundException_When_Warehouse_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPlantActionCommand(landId, userId, plantId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithPlantActionsAsync().Returns(new Season());
            _plantRepository.GetAsync(plantId).Returns(new Plant());
            _landRepository.GetAsync(landId).Returns(new Land());
            _plantWarehouseRepository.GetWithStatesAsync(warehouseId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PlantWarehouseNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_LandNotFoundException_When_Land_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPlantActionCommand(landId, userId, plantId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithPlantActionsAsync().Returns(new Season());
            _plantRepository.GetAsync(plantId).Returns(new Plant());
            _landRepository.GetAsync(landId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<LandNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_PlantNotFoundException_When_Plant_Does_Not_Exists()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPlantActionCommand(landId, userId, plantId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithPlantActionsAsync().Returns(new Season());
            _plantRepository.GetAsync(plantId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PlantNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ActiveSeasonNotFoundException_When_There_Is_No_Active_Season()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPlantActionCommand(landId, userId, plantId, warehouseId, quantity);

            _userReadService.ExistsByIdAsync(userId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(userId).Returns(true);
            _seasonRepository.GetCurrentSeasonWithPlantActionsAsync().ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ActiveSeasonNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_UserNotActiveException_When_Current_User_Is_Not_Active()
        {
            var landId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = 100m;

            var command = new ProcessPlantActionCommand(landId, userId, plantId, warehouseId, quantity);

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
            var plantId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var quantity = -1m;

            var command = new ProcessPlantActionCommand(landId, userId, plantId, warehouseId, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        private readonly IRequestHandler<ProcessPlantActionCommand,
            Response<ProcessPlantActionResponse>> _handler;

        private readonly ISeasonRepository _seasonRepository;
        private readonly IPlantWarehouseRepository _plantWarehouseRepository;
        private readonly IUserReadService _userReadService;
        private readonly ILandRepository _landRepository;
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessPlantActionHandlerTests()
        {
            _userReadService = Substitute.For<IUserReadService>();
            _seasonRepository = Substitute.For<ISeasonRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _landRepository = Substitute.For<ILandRepository>();
            _plantRepository = Substitute.For<IPlantRepository>();
            _plantWarehouseRepository = Substitute.For<IPlantWarehouseRepository>();

            _handler = new ProcessPlantActionHandler(_seasonRepository, _userReadService, _unitOfWork, _plantWarehouseRepository,
                _landRepository, _plantRepository);
        }
    }
}
