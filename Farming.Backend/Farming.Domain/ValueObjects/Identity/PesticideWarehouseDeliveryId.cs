using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record PesticideWarehouseDeliveryId
    {
        public Guid Value { get; }

        public PesticideWarehouseDeliveryId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPesticideWarehouseDeliveryIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PesticideWarehouseDeliveryId id)
            => id.Value;

        public static implicit operator PesticideWarehouseDeliveryId(Guid id)
            => new(id);
    }
}
