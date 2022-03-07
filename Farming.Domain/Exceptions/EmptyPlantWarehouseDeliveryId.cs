﻿using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPlantWarehouseDeliveryId : FarmingException
    {
        public EmptyPlantWarehouseDeliveryId() : base("Plant Warehouse ID cannot be empty.")
        {
        }
    }
}
