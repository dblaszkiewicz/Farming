using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Shouldly;
using System;
using Xunit;

namespace Farming.UnitTests.Domain
{
    public class FertilizerWarehouseStateTests
    {
        [Fact]
        public void AddDelivery_Throws_InvalidFertilizerWarehouseDeliveryQuantityException_When_Delivery_Has_Wrong_Quantity()
        {
            // Arrange
            var fertilizerId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(fertilizerId);

            // Act
            var exception = Record.Exception(() => state.AddDelivery(GetDeliveryWithWrongQuantity(fertilizerId)));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidFertilizerWarehouseDeliveryQuantityException>();
        }

        [Fact]
        public void AddDelivery_Throws_InvalidFertilizerWarehouseDeliveryPriceException_When_Delivery_Has_Wrong_Price()
        {
            // Arrange
            var fertilizerId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(fertilizerId);

            // Act
            var exception = Record.Exception(() => state.AddDelivery(GetDeliveryWithWrongPrice(fertilizerId)));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidFertilizerWarehouseDeliveryPriceException>();
        }

        [Fact]
        public void SpendFertilizer_Throws_InvalidFertilizerWarehouseQuantityException_When_State_Has_No_Enough_Quantity()
        {
            // Arrange
            var fertilizerId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(fertilizerId);

            // Act
            var exception = Record.Exception(() => state.SpendFertilizer(10));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidFertilizerWarehouseQuantityException>();
        }

        [Fact]
        public void SpendFertilizer_Throws_InvalidFertilizerActionQuantityException_When_Quantity_Action_Is_Below_Zero()
        {
            // Arrange
            var fertilizerId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(fertilizerId);

            // Act
            var exception = Record.Exception(() => state.SpendFertilizer(-5));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidFertilizerActionQuantityException>();
        }

        private FertilizerWarehouseState GetStateWithZeroQuantity(Guid fertilizerId)
        {
            return new FertilizerWarehouseState(fertilizerId);
        }

        private FertilizerWarehouseDelivery GetDeliveryWithWrongQuantity(Guid fertilizerId)
        {
            return new FertilizerWarehouseDelivery(fertilizerId, Guid.NewGuid(), -5, 10, DateTimeOffset.UtcNow);
        }

        private FertilizerWarehouseDelivery GetDeliveryWithWrongPrice(Guid fertilizerId)
        {
            return new FertilizerWarehouseDelivery(fertilizerId, Guid.NewGuid(), 10, -1, DateTimeOffset.UtcNow);
        }
    }
}
