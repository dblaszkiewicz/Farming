
namespace Farming.Infrastructure.EF.MultiTenancy
{
    public interface ITenantSetter
    {
        void SetTenant(Guid tenant);
    }
}
