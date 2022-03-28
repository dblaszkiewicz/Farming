using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class PesticideWarehouseDoesNotExistException : FarmingException
    {
        public Guid PesticideWarehouseId { get; set; }
        public PesticideWarehouseDoesNotExistException(Guid pesticideWarehouseId) : base($"Pesticide Warehouse with ID: '{pesticideWarehouseId}' does not exist")
        {
            PesticideWarehouseId = pesticideWarehouseId;
        }
    }
}
