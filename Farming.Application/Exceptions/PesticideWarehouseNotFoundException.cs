using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class PesticideWarehouseNotFoundException : FarmingException
    {
        public Guid PesticideWarehouseId { get; set; }
        public PesticideWarehouseNotFoundException(Guid pesticideWarehouseId) : base($"Pesticide Warehouse with ID: '{pesticideWarehouseId}' was not found")
        {
            PesticideWarehouseId = pesticideWarehouseId;
        }
    }
}
