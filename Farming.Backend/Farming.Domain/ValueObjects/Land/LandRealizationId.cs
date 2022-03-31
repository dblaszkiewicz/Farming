using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Land
{
    public record LandRealizationId
    {
        public Guid Value { get; }

        public LandRealizationId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyLandRealizationIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(LandRealizationId id)
            => id.Value;

        public static implicit operator LandRealizationId(Guid id)
            => new(id);
    }
}
