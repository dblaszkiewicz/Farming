
namespace Farming.Infrastructure.EF.Models
{
    internal class BaseReadModel
    {
        public int Version { get; set; }
        public Guid TenantId { get; set; }
    }
}
