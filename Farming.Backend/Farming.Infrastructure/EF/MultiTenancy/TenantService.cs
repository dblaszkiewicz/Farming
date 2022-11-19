
namespace Farming.Infrastructure.EF.MultiTenancy
{
    internal class TenantService : ITenantGetter, ITenantSetter
    {
        public TenantId TenantId { get; private set; } = Guid.Empty;

        public void SetTenant(TenantId tenant)
        {
            TenantId = tenant;
        }
    }
}
