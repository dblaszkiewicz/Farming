using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record PlantWarehouseId
    {
        public Guid Value { get; }

        public PlantWarehouseId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPlantWarehouseIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PlantWarehouseId id)
            => id.Value;

        public static implicit operator PlantWarehouseId(Guid id)
            => new(id);
    }
}
