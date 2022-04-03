using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record PesticideId
    {
        public Guid Value { get; }

        public PesticideId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPesticideIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PesticideId id)
            => id.Value;

        public static implicit operator PesticideId(Guid id)
            => new(id);
    }
}
