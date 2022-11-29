using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PlantWarehouseWriteConfiguration : IEntityTypeConfiguration<PlantWarehouse>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public PlantWarehouseWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PlantWarehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PlantWarehouseId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new PlantWarehouseName(x));

            builder
                .HasQueryFilter((System.Linq.Expressions.Expression<Func<PlantWarehouse, bool>>)(x => x.TenantId == _context.TenantId.Value));

            builder.HasIndex(x => x.TenantId);

            builder.Property(x => x.Version).IsConcurrencyToken();

            builder.ToTable("PlantWarehouses");
        }
    }
}
