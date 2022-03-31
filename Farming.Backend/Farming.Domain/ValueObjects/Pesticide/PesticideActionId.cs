using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideActionId
    {
        public Guid Value { get; }

        public PesticideActionId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPesticideActionIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PesticideActionId id)
            => id.Value;

        public static implicit operator PesticideActionId(Guid id)
            => new(id);
    }
}
