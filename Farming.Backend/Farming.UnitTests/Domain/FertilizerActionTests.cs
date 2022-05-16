using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace Farming.UnitTests.Domain
{
    public class FertilizerActionTests
    {
        [Fact]
        public void ProcessAction_Throws_FertilizerActionNotEnoughQuantityException_When_Warehouse_Does_Not_Have_Enough_State_Quantity()
        {
            // Arrange
            var fertilizerId = Guid.NewGuid();
            var warehouse = GetWarehouseWithoutEnoughStateQuantity(fertilizerId);

            // Act
            var exception = Record.Exception(() => warehouse.ProcessFertilizerAction(fertilizerId, 10));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<FertilizerActionNotEnoughQuantityException>();
        }

        [Fact]
        public void ProcessAction_Throws_FertilizerWarehouseStateNotFoundException_When_Warehouse_Does_Not_Have_State()
        {
            // Arrange
            var fertilizerId = Guid.NewGuid();
            var warehouse = GetWarehouseWithoutState();

            // Act
            var exception = Record.Exception(() => warehouse.ProcessFertilizerAction(fertilizerId, 10));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<FertilizerWarehouseStateNotFoundException>();
        }

        private FertilizerWarehouse GetWarehouseWithoutEnoughStateQuantity(Guid fertilizerId)
        {
            var states = new List<FertilizerWarehouseState>()
            {
                new FertilizerWarehouseState(fertilizerId)
            };

            return new FertilizerWarehouse("Warehouse1", states);
        }

        private FertilizerWarehouse GetWarehouseWithoutState()
        {
            var states = new List<FertilizerWarehouseState>();

            return new FertilizerWarehouse("Warehouse1", states);
        }
    }
}

