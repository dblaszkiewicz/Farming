
namespace Farming.Infrastructure.EF.MultiTenancy
{
    public record Tenant
    {
        public Tenant(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static implicit operator Guid(Tenant tenant)
            => tenant.Value;

        public static implicit operator Tenant(Guid value)
            => new(value);
    }
}
