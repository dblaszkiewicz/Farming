using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PesticideWarehouseWriteConfiguration : IEntityTypeConfiguration<PesticideWarehouse>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public PesticideWarehouseWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PesticideWarehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PesticideWarehouseId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new PesticideWarehouseName(x));

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PesticideWarehouses");
        }
    }
}
