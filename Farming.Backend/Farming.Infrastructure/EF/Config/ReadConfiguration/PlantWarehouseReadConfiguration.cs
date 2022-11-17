using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PlantWarehouseReadConfiguration : IEntityTypeConfiguration<PlantWarehouseReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public PlantWarehouseReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PlantWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PlantWarehouses");
        }
    }
}
