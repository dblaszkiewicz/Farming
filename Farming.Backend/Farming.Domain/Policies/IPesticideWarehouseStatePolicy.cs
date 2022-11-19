using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Policies
{
    public interface IPesticideWarehouseStatePolicy
    {
        bool IsEnoughPesticide(PesticideWarehouseState state, PesticideWarehouseQuantity quantity);
    }
}
