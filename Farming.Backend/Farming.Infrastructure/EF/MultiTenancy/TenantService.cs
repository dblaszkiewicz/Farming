
namespace Farming.Infrastructure.EF.MultiTenancy
{
    internal class TenantService : ITenantGetter, ITenantSetter
    {
        public Guid Tenant { get; private set; }

        public void SetTenant(Guid tenant)
        {
            Tenant = tenant;
        }
    }
}
