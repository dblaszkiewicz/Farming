using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record PlantActionId
    {
        public Guid Value { get; }

        public PlantActionId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPlantActionIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PlantActionId id)
            => id.Value;

        public static implicit operator PlantActionId(Guid id)
            => new(id);
    }
}
