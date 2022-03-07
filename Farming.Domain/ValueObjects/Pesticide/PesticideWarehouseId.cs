using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideWarehouseId
    {
        public Guid Value { get; }

        public PesticideWarehouseId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPesticideWarehouseIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PesticideWarehouseId id)
            => id.Value;

        public static implicit operator PesticideWarehouseId(Guid id)
            => new(id);
    }
}
