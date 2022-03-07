using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Season
{
    public record SeasonId
    {
        public Guid Value { get; }

        public SeasonId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptySeasonIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(SeasonId id)
            => id.Value;

        public static implicit operator SeasonId(Guid id)
            => new(id);
    }
}
