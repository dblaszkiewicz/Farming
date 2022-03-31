using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerWarehouseDeliveryId
    {
        public Guid Value { get; }

        public FertilizerWarehouseDeliveryId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyFertilizerWarehouseDeliveryIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(FertilizerWarehouseDeliveryId id)
            => id.Value;

        public static implicit operator FertilizerWarehouseDeliveryId(Guid id)
            => new(id);
    }
}
