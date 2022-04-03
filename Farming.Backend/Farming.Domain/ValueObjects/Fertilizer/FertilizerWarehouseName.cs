
namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerWarehouseName
    {
        public string Value { get; }

        public FertilizerWarehouseName(string value)
        {
            Value = value;
        }

        public static implicit operator string(FertilizerWarehouseName name)
            => name.Value;

        public static implicit operator FertilizerWarehouseName(string name)
            => new(name);
    }
}
