using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Policies
{
    public sealed class PesticideWarehouseStatePolicy : IPesticideWarehouseStatePolicy
    {
        public bool IsEnoughPesticide(PesticideWarehouseState state, PesticideWarehouseQuantity quantity)
            => state.Quantity >= quantity;
    }
}
