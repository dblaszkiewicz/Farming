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
    public class AddPesticideWarehouseDeliveryHandlerTests
    {
        [Fact]
        public async Task HandleAsync_Throws_PesticideWarehouseNotFoundException_When_Warehouse_Does_Not_Exists()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddPesticideWarehouseDeliveryCommand(warehouseId, pesticideId, currentUserId, price, quantity);

            _pesticideReadService.ExistsByIdAsync(pesticideId).Returns(true);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(true);
            _pesticideWarehouseRepository.GetWithStatesAndDeliveriesAsync(warehouseId).ReturnsNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PesticideWarehouseNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_UserNotActiveException_When_Current_User_Is_Not_Active()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddPesticideWarehouseDeliveryCommand(warehouseId, pesticideId, currentUserId, price, quantity);

            _pesticideReadService.ExistsByIdAsync(pesticideId).Returns(true);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(false);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserNotActiveException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_PesticideNotFoundException_When_Pesticide_Does_Not_Exists()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var quantity = 130m;
            var price = 200m;

            var command = new AddPesticideWarehouseDeliveryCommand(warehouseId, pesticideId, currentUserId, price, quantity);

            _pesticideReadService.ExistsByIdAsync(pesticideId).Returns(false);
            _userReadService.ExistsByIdAsync(currentUserId).Returns(true);
            _userReadService.IsUserActiveByIdAsync(currentUserId).Returns(true);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PesticideNotFoundException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ValidateCommandException_When_Price_Is_Below_Zero()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var quantity = 130m;
            var price = -10m;

            var command = new AddPesticideWarehouseDeliveryCommand(warehouseId, pesticideId, currentUserId, price, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_ValidateCommandException_When_Quantity_Is_Below_Zero()
        {
            var currentUserId = Guid.NewGuid();
            var warehouseId = Guid.NewGuid();
            var pesticideId = Guid.NewGuid();
            var quantity = -130m;
            var price = 10m;

            var command = new AddPesticideWarehouseDeliveryCommand(warehouseId, pesticideId, currentUserId, price, quantity);

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ValidateCommandException>();
        }

        private readonly IRequestHandler<AddPesticideWarehouseDeliveryCommand, 
            Response<AddPesticideWarehouseDeliveryResponse>> _handler;

        private readonly IPesticideReadService _pesticideReadService;
        private readonly IUserReadService _userReadService;
        private readonly IPesticideWarehouseRepository _pesticideWarehouseRepository;

        public AddPesticideWarehouseDeliveryHandlerTests()
        {
            var _unitOfWork = Substitute.For<IUnitOfWork>();
            _userReadService = Substitute.For<IUserReadService>();
            _pesticideReadService = Substitute.For<IPesticideReadService>();
            _pesticideWarehouseRepository = Substitute.For<IPesticideWarehouseRepository>();

            _handler = new AddPesticideWarehouseDeliveryHandler(_pesticideWarehouseRepository, _unitOfWork,
                _userReadService, _pesticideReadService);
        }
    }
}
