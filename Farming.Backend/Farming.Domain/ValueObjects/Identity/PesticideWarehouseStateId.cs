using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record PesticideWarehouseStateId
    {
        public Guid Value { get; }

        public PesticideWarehouseStateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPesticideWarehouseStateIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PesticideWarehouseStateId id)
            => id.Value;

        public static implicit operator PesticideWarehouseStateId(Guid id)
            => new(id);
    }
}
