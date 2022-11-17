using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PlantWarehouseStateWriteConfiguration : IEntityTypeConfiguration<PlantWarehouseState>, IWriteConfiguration
    {
        private readonly Tenant _tenant;

        public PlantWarehouseStateWriteConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<PlantWarehouseState> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PlantWarehouseStateId(x));

            builder
                .Property(x => x.PlantId)
                .HasConversion(x => x.Value, x => new PlantId(x));

            builder
                .Property(x => x.PlantWarehouseId)
                .HasConversion(x => x.Value, x => new PlantWarehouseId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new PlantWarehouseQuantity(x));

            builder
                .HasOne(x => x.Plant)
                .WithMany(x => x.PlantWarehouseStates)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.PlantWarehouse)
                .WithMany(x => x.States)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.ToTable("PlantWarehouseStates");
        }
    }
}
