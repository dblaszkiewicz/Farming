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
    public class AddFertilizerWarehouseDeliveryHandlerTests
    {
        [Fact]
        public async Task HandleAsync_Throws_FertilizerWarehouseNotFoundException_When_Warehouse_Does_Not_Exists()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var fertilzierId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddFertilizerWarehouseDeliveryCommand(warehouseId, fertilzierId, currentUserId, price, quantity);

            _fertilizerReadService.ExistsByIdAsync(fertilzierId).Returns(true);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(true);
            _fertilizerWarehouseRepository.GetWithStateAndDeliveriesAsync(warehouseId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<FertilizerWarehouseNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_UserNotActiveException_When_Current_User_Is_Not_Active()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var fertilzierId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddFertilizerWarehouseDeliveryCommand(warehouseId, fertilzierId, currentUserId, price, quantity);

            _fertilizerReadService.ExistsByIdAsync(fertilzierId).Returns(true);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(false);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserNotActiveException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_FertilizerNotFoundException_When_Fertilizer_Does_Not_Exists()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var fertilzierId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddFertilizerWarehouseDeliveryCommand(warehouseId, fertilzierId, currentUserId, price, quantity);

            _fertilizerReadService.ExistsByIdAsync(fertilzierId).Returns(false);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(true);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<FertilizerNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ValidateCommandException_Price_Is_Below_Zero()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var fertilzierId = Guid.NewGuid();
            var quantity = 130m;
            var price = -200m;

            var command = new AddFertilizerWarehouseDeliveryCommand(warehouseId, fertilzierId, currentUserId, price, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ValidateCommandException_When_Quantity_Is_Below_Zero()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var fertilzierId = Guid.NewGuid();
            var quantity = -130m;
            var price = 200m;

            var command = new AddFertilizerWarehouseDeliveryCommand(warehouseId, fertilzierId, currentUserId, price, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        private readonly IRequestHandler<AddFertilizerWarehouseDeliveryCommand,
            Response<AddFertilizerWarehouseDeliveryResponse>> _handler;

        private readonly IFertilizerReadService _fertilizerReadService;
        private readonly IUserReadService _userReadService;
        private readonly IFertilizerWarehouseRepository _fertilizerWarehouseRepository;

        public AddFertilizerWarehouseDeliveryHandlerTests()
        {
            var _unitOfWork = Substitute.For<IUnitOfWork>();
            _userReadService = Substitute.For<IUserReadService>();
            _fertilizerReadService = Substitute.For<IFertilizerReadService>();
            _fertilizerWarehouseRepository = Substitute.For<IFertilizerWarehouseRepository>();

            _handler = new AddFertilizerWarehouseDeliveryHandler(_fertilizerWarehouseRepository, _userReadService, 
                _fertilizerReadService, _unitOfWork);
        }
    }
}
