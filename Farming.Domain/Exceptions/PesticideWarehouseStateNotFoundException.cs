using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class PesticideWarehouseStateNotFoundException : FarmingException
    {
        public Guid PesticideId { get; set; }
        public Guid PesticideWarehouseId { get; set; }
        public PesticideWarehouseStateNotFoundException(Guid pesticideId, Guid pesticideWarehouseId) : 
            base($"State with pesticide ID: '{pesticideId}' on pesticide warehouse with ID: '{pesticideWarehouseId}' was not found")
        {
            PesticideId = pesticideId;
            PesticideWarehouseId = pesticideWarehouseId;
        }
    }
}
