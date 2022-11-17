
namespace Farming.Infrastructure.EF.MultiTenancy
{
    internal class TenantService : ITenantGetter, ITenantSetter
    {
        public Tenant Tenant { get; private set; }

        public void SetTenant(Tenant tenant)
        {
            Tenant = tenant;
        }
    }
}
