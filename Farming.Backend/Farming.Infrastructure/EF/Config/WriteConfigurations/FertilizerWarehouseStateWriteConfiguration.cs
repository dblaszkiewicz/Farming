using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class FertilizerWarehouseStateWriteConfiguration : IEntityTypeConfiguration<FertilizerWarehouseState>, IWriteConfiguration
    {
        private readonly Tenant _tenant;

        public FertilizerWarehouseStateWriteConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouseState> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseStateId(x));

            builder
                .Property(x => x.FertilizerId)
                .HasConversion(x => x.Value, x => new FertilizerId(x));

            builder
                .Property(x => x.FertilizerWarehouseId)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseQuantity(x));

            builder
                .HasOne(x => x.Fertilizer)
                .WithMany(x => x.FertilizerWarehouseStates)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.FertilizerWarehouse)
                .WithMany(x => x.States)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("FertilizerWarehouseStates");
        }
    }
}
