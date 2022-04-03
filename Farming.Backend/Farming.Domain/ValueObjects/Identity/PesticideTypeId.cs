namespace Farming.Domain.ValueObjects.Identity
{
    public record PesticideTypeId
    {
        public Guid Value { get; }

        public PesticideTypeId(Guid value)
        {
            Value = value;
        }

        public static implicit operator Guid(PesticideTypeId id)
            => id.Value;

        public static implicit operator PesticideTypeId(Guid id)
            => new(id);
    }
}
