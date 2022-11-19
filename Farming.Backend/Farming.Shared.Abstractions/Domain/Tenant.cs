
namespace Farming.Shared.Abstractions.Domain
{
    public class Tenant : ITenant
    {
        public Guid TenantId { get; set; } = Guid.Empty;

        public void SetTenantId(Guid tenantId)
        {
            TenantId = tenantId;
        }
    }
}
