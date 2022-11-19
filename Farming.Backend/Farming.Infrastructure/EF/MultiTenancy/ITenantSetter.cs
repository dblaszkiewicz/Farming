
namespace Farming.Infrastructure.EF.MultiTenancy
{
    public interface ITenantSetter
    {
        void SetTenant(TenantId tenantId);
    }
}
