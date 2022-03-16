using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantWarehouseStateId
    {
        public Guid Value { get; }

        public PlantWarehouseStateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPlantWarehouseStateIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PlantWarehouseStateId id)
            => id.Value;

        public static implicit operator PlantWarehouseStateId(Guid id)
            => new(id);
    }
}
