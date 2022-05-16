using Farming.Application.Commands;
using Farming.Application.Commands.Handlers;
using Farming.Application.Commands.Responses;
using Farming.Application.Exceptions;
using Farming.Application.Services;
using Farming.Domain.Factories;
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
    public class AddPlantWarehouseDeliveryHandlerTests
    {
        [Fact]
        public async Task HandleAsync_Throws_PlantWarehouseNotFoundException_When_Warehouse_Does_Not_Exists()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddPlantWarehouseDeliveryCommand(warehouseId, plantId, currentUserId, price, quantity);

            _plantReadService.ExistsByIdAsync(plantId).Returns(true);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(true);
            _plantWarehouseRepository.GetWithStatesAndDeliveriesAsync(warehouseId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PlantWarehouseNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_UserNotActiveException_When_Current_User_Is_Not_Active()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddPlantWarehouseDeliveryCommand(warehouseId, plantId, currentUserId, price, quantity);

            _plantReadService.ExistsByIdAsync(plantId).Returns(true);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(false);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserNotActiveException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_PlantNotFoundException_When_Plant_Does_Not_Exists()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddPlantWarehouseDeliveryCommand(warehouseId, plantId, currentUserId, price, quantity);

            _plantReadService.ExistsByIdAsync(plantId).Returns(false);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(true);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PlantNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ValidateCommandException_When_Price_Is_Below_Zero()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var quantity = 130m;
            var price = -200m;

            var command = new AddPlantWarehouseDeliveryCommand(warehouseId, plantId, currentUserId, price, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ValidateCommandException_When_Quantity_Is_Below_Zero()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var plantId = Guid.NewGuid();
            var quantity = -130m;
            var price = 200m;

            var command = new AddPlantWarehouseDeliveryCommand(warehouseId, plantId, currentUserId, price, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        private readonly IRequestHandler<AddPlantWarehouseDeliveryCommand,
            Response<AddPlantWarehouseDeliveryResponse>> _handler;

        private readonly IPlantWarehouseRepository _plantWarehouseRepository;
        private readonly IUserReadService _userReadService;
        private readonly IPlantReadService _plantReadService;
        private readonly IUnitOfWork _unitOfWork;

        public AddPlantWarehouseDeliveryHandlerTests()
        {
            _plantWarehouseRepository = Substitute.For<IPlantWarehouseRepository>();
            _userReadService = Substitute.For<IUserReadService>();
            _plantReadService = Substitute.For<IPlantReadService>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            _handler = new AddPlantWarehouseDeliveryHandler(_plantWarehouseRepository, _unitOfWork, _userReadService, _plantReadService);
        }
    }
}
