
namespace Farming.Infrastructure.EF.MultiTenancy
{
    internal class TenantService : ITenantGetter, ITenantSetter
    {
        public Tenant Tenant { get; private set; } = Guid.Empty;

        public void SetTenant(Tenant tenant)
        {
            Tenant = tenant;
        }
    }
}
