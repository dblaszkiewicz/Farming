using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record FertilizerId
    {
        public Guid Value { get; }

        public FertilizerId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyFertilizerIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(FertilizerId id)
            => id.Value;

        public static implicit operator FertilizerId(Guid id)
            => new(id);
    }
}
