
namespace Farming.Infrastructure.EF.Models
{
    internal abstract class BaseTenantReadModel
    {
        public Guid TenantId { get; set; }
    }
}
