using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Identity
{
    public record FertilizerWarehouseId
    {
        public Guid Value { get; }

        public FertilizerWarehouseId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyFertilizerWarehouseIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(FertilizerWarehouseId id)
            => id.Value;

        public static implicit operator FertilizerWarehouseId(Guid id)
            => new(id);
    }
}
