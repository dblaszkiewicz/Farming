
namespace Farming.Infrastructure.EF.MultiTenancy
{
    public record TenantId
    {
        public TenantId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static implicit operator Guid(TenantId tenantId)
            => tenantId.Value;

        public static implicit operator TenantId(Guid value)
            => new(value);
    }
}
