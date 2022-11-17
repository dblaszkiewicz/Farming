
namespace Farming.Infrastructure.EF.MultiTenancy
{
    public interface ITenantSetter
    {
        void SetTenant(Tenant tenant);
    }
}
