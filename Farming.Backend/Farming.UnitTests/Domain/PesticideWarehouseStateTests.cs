using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Shouldly;
using System;
using Xunit;

namespace Farming.UnitTests.Domain
{
    public class PesticideWarehouseStateTests
    {
        [Fact]
        public void AddDelivery_Throws_InvalidPesticideWarehouseDeliveryQuantityException_When_Delivery_Has_Wrong_Quantity()
        {
            // Arrange
            var pesticideId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(pesticideId);

            // Act
            var exception = Record.Exception(() => state.AddDelivery(GetDeliveryWithWrongQuantity(pesticideId)));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPesticideWarehouseDeliveryQuantityException>();
        }

        [Fact]
        public void AddDelivery_Throws_InvalidPesticideWarehouseDeliveryPriceException_When_Delivery_Has_Wrong_Price()
        {
            // Arrange
            var pesticideId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(pesticideId);

            // Act
            var exception = Record.Exception(() => state.AddDelivery(GetDeliveryWithWrongPrice(pesticideId)));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPesticideWarehouseDeliveryPriceException>();
        }

        [Fact]
        public void SpendPesticide_Throws_InvalidPesticideWarehouseQuantityException_When_State_Has_No_Enough_Quantity()
        {
            // Arrange
            var pesticideId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(pesticideId);

            // Act
            var exception = Record.Exception(() => state.SpendPesticide(10));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPesticideWarehouseQuantityException>();
        }

        [Fact]
        public void SpendPesticide_Throws_InvalidPesticideActionQuantityException_When_Quantity_Action_Is_Below_Zero()
        {
            // Arrange
            var pesticideId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(pesticideId);

            // Act
            var exception = Record.Exception(() => state.SpendPesticide(-5));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPesticideActionQuantityException>();
        }

        private PesticideWarehouseState GetStateWithZeroQuantity(Guid pesticideId)
        {
            return new PesticideWarehouseState(pesticideId);
        }

        private PesticideWarehouseDelivery GetDeliveryWithWrongQuantity(Guid pesticideId)
        {
            return new PesticideWarehouseDelivery(pesticideId, Guid.NewGuid(), -5, 10, DateTimeOffset.UtcNow);
        }

        private PesticideWarehouseDelivery GetDeliveryWithWrongPrice(Guid pesticideId)
        {
            return new PesticideWarehouseDelivery(pesticideId, Guid.NewGuid(), 10, -1, DateTimeOffset.UtcNow);
        }
    }
}
