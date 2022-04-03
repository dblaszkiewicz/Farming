
namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideWarehouseName
    {
        public string Value { get; }

        public PesticideWarehouseName(string value)
        {
            Value = value;
        }

        public static implicit operator string(PesticideWarehouseName name)
            => name.Value;

        public static implicit operator PesticideWarehouseName(string name)
            => new(name);
    }
}
