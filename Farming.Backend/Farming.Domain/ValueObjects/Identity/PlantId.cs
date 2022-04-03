using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record PlantId
    {
        public Guid Value { get; }

        public PlantId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPlantIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PlantId id)
            => id.Value;

        public static implicit operator PlantId(Guid id)
            => new(id);
    }
}
