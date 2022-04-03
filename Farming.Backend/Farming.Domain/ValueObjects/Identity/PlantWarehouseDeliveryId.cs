using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record PlantWarehouseDeliveryId
    {
        public Guid Value { get; }

        public PlantWarehouseDeliveryId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPlantWarehouseDeliveryId();
            }

            Value = value;
        }

        public static implicit operator Guid(PlantWarehouseDeliveryId id)
            => id.Value;

        public static implicit operator PlantWarehouseDeliveryId(Guid id)
            => new(id);
    }
}
