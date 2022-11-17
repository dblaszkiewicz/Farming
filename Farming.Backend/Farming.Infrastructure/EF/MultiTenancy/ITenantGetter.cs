
namespace Farming.Infrastructure.EF.MultiTenancy
{
    public interface ITenantGetter
    {
        Tenant Tenant { get; }
    }
}
