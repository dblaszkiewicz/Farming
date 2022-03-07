
namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerTypeId
    {
        public Guid Value { get; }

        public FertilizerTypeId(Guid value)
        {
            Value = value;
        }

        public static implicit operator Guid(FertilizerTypeId id)
            => id.Value;

        public static implicit operator FertilizerTypeId(Guid id)
            => new(id);
    }
}
