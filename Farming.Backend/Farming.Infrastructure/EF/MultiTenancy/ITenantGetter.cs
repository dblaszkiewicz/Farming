
namespace Farming.Infrastructure.EF.MultiTenancy
{
    public interface ITenantGetter
    {
        Guid Tenant { get; }
    }
}
