using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace Farming.UnitTests.Domain
{
    public class PesticideActionTests
    {
        [Fact]
        public void ProcessAction_Throws_PesticideActionNotEnoughQuantityException_When_Warehouse_Does_Not_Have_Enough_State_Quantity()
        {
            // Arrange
            var pesticideId = Guid.NewGuid();
            var warehouse = GetWarehouseWithoutEnoughStateQuantity(pesticideId);

            // Act
            var exception = Record.Exception(() => warehouse.ProcessPesticideAction(pesticideId, 10));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PesticideActionNotEnoughQuantityException>();
        }

        [Fact]
        public void ProcessAction_Throws_PesticideWarehouseStateNotFoundException_When_Warehouse_Does_Not_Have_State()
        {
            // Arrange
            var pesticideId = Guid.NewGuid();
            var warehouse = GetWarehouseWithoutState();

            // Act
            var exception = Record.Exception(() => warehouse.ProcessPesticideAction(pesticideId, 10));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PesticideWarehouseStateNotFoundException>();
        }

        private PesticideWarehouse GetWarehouseWithoutEnoughStateQuantity(Guid pesticideId)
        {
            var states = new List<PesticideWarehouseState>()
            {
                new PesticideWarehouseState(pesticideId)
            };

            return new PesticideWarehouse("Warehouse1", states);
        }

        private PesticideWarehouse GetWarehouseWithoutState()
        {
            var states = new List<PesticideWarehouseState>();

            return new PesticideWarehouse("Warehouse1", states);
        }
    }
}
