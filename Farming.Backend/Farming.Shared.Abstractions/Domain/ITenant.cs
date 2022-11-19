
namespace Farming.Shared.Abstractions.Domain
{
    public interface ITenant
    {
        Guid TenantId { get; set; }
        void SetTenantId(Guid tenantId);
    }
}
