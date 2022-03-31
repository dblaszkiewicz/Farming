using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Land
{
    public record LandId
    {
        public Guid Value { get; }

        public LandId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyLandIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(LandId id)
            => id.Value;

        public static implicit operator LandId(Guid id)
            => new(id);
    }
}
