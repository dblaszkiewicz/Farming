
namespace Farming.Infrastructure.EF.MultiTenancy
{
    public interface ITenantGetter
    {
        TenantId TenantId { get; }
    }
}
