using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;

namespace Farming.Domain.Policies
{
    public sealed class FertilizerWarehouseStatePolicy : IFertilizerWarehouseStatePolicy
    {
        public bool IsEnoughFertilizer(FertilizerWarehouseState state, FertilizerWarehouseQuantity quantity)
            => state.Quantity >= quantity;
    }
}
