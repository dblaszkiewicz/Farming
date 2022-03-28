﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public interface IFertilizerWarehouseDeliveryFactory 
    {
        FertilizerWarehouseDelivery Create(FertilizerId fertilizerId, UserId userId, 
            FertilizerWarehouseDeliveryQuantity quantity, FertilizerWarehouseDeliveryPrice price);
    }
}