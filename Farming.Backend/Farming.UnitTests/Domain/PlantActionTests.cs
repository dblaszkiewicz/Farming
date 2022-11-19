using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Farming.Domain.Policies;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace Farming.UnitTests.Domain
{
    public class PlantActionTests
    {
        private readonly IPlantWarehouseStatePolicy _plantWarehouseStatePolicy;

        public PlantActionTests()
        {
            _plantWarehouseStatePolicy = Substitute.For<IPlantWarehouseStatePolicy>();
        }

        [Fact]
        public void ProcessAction_Throws_PlantActionNotEnoughQuantityException_When_Warehouse_Does_Not_Have_Enough_State_Quantity()
        {
            // Arrange
            var plantId = Guid.NewGuid();
            var warehouse = GetWarehouseWithoutEnoughStateQuantity(plantId);

            // Act
            var exception = Record.Exception(() => warehouse.ProcessPlantAction(plantId, 10, _plantWarehouseStatePolicy));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PlantActionNotEnoughQuantityException>();
        }

        [Fact]
        public void ProcessAction_Throws_PlantWarehouseStateNotFoundException_When_Warehouse_Does_Not_Have_State()
        {
            // Arrange
            var plantId = Guid.NewGuid();
            var warehouse = GetWarehouseWithoutState();

            // Act
            var exception = Record.Exception(() => warehouse.ProcessPlantAction(plantId, 10, _plantWarehouseStatePolicy));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PlantWarehouseStateNotFoundException>();
        }

        private PlantWarehouse GetWarehouseWithoutEnoughStateQuantity(Guid plantId)
        {
            var states = new List<PlantWarehouseState>()
            {
                new PlantWarehouseState(plantId)
            };

            return new PlantWarehouse("Warehouse1", states);
        }

        private PlantWarehouse GetWarehouseWithoutState()
        {
            var states = new List<PlantWarehouseState>();

            return new PlantWarehouse("Warehouse1", states);
        }
    }
}
