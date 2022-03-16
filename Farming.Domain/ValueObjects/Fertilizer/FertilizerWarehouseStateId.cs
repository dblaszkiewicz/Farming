using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerWarehouseStateId
    {
        public Guid Value { get; }

        public FertilizerWarehouseStateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyFertilizerWarehouseStateIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(FertilizerWarehouseStateId id)
            => id.Value;

        public static implicit operator FertilizerWarehouseStateId(Guid id)
            => new(id);
    }
}
