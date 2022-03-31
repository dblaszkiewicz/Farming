using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerActionId
    {
        public Guid Value { get; }

        public FertilizerActionId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyFertilizerActionIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(FertilizerActionId id)
            => id.Value;

        public static implicit operator FertilizerActionId(Guid id)
            => new(id);
    }
}
