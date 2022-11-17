using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PesticideWarehouseWriteConfiguration : IEntityTypeConfiguration<PesticideWarehouse>, IWriteConfiguration
    {
        private readonly Tenant _tenant;

        public PesticideWarehouseWriteConfiguration(Tenant tenant)
        {
            _tenant = tenant;
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
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PesticideWarehouses");
        }
    }
}
