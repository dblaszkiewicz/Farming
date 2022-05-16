using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Shouldly;
using System;
using Xunit;


namespace Farming.UnitTests.Domain
{
    public class PlantWarehouseStateTests
    {
        [Fact]
        public void AddDelivery_Throws_InvalidPlantWarehouseDeliveryQuantityException_When_Delivery_Has_Wrong_Quantity()
        {
            // Arrange
            var plantId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(plantId);

            // Act
            var exception = Record.Exception(() => state.AddDelivery(GetDeliveryWithWrongQuantity(plantId)));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPlantWarehouseDeliveryQuantityException>();
        }

        [Fact]
        public void AddDelivery_Throws_InvalidPlantWarehouseDeliveryPriceException_When_Delivery_Has_Wrong_Price()
        {
            // Arrange
            var plantId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(plantId);

            // Act
            var exception = Record.Exception(() => state.AddDelivery(GetDeliveryWithWrongPrice(plantId)));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPlantWarehouseDeliveryPriceException>();
        }

        [Fact]
        public void SpendPlants_Throws_InvalidPlantWarehouseQuantityException_When_State_Has_No_Enough_Quantity()
        {
            // Arrange
            var plantId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(plantId);

            // Act
            var exception = Record.Exception(() => state.SpendPlants(10));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPlantWarehouseQuantityException>();
        }

        [Fact]
        public void SpendPlants_Throws_InvalidPlantActionQuantityException_When_Quantity_Action_Is_Below_Zero()
        {
            // Arrange
            var plantId = Guid.NewGuid();
            var state = GetStateWithZeroQuantity(plantId);

            // Act
            var exception = Record.Exception(() => state.SpendPlants(-5));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPlantActionQuantityException>();
        }

        private PlantWarehouseState GetStateWithZeroQuantity(Guid plantId)
        {
            return new PlantWarehouseState(plantId);
        }

        private PlantWarehouseDelivery GetDeliveryWithWrongQuantity(Guid plantId)
        {
            return new PlantWarehouseDelivery(plantId, Guid.NewGuid(), -5, 10, DateTimeOffset.UtcNow);
        }

        private PlantWarehouseDelivery GetDeliveryWithWrongPrice(Guid plantId)
        {
            return new PlantWarehouseDelivery(plantId, Guid.NewGuid(), 10, -1, DateTimeOffset.UtcNow);
        }
    }
}
