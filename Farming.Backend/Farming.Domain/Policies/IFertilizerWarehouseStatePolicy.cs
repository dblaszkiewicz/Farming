using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;

namespace Farming.Domain.Policies
{
    public interface IFertilizerWarehouseStatePolicy
    {
        bool IsEnoughFertilizer(FertilizerWarehouseState state, FertilizerWarehouseQuantity quantity);
    }
}
