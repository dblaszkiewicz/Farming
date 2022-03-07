using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideName
    {
        public string Value { get; }

        public PesticideName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyPesticideNameException();
            }

            Value = value;
        }

        public static implicit operator string(PesticideName name)
            => name.Value;

        public static implicit operator PesticideName(string name)
            => new(name);
    }
}
