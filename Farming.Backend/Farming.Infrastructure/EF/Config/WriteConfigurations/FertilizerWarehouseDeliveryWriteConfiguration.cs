using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class FertilizerWarehouseDeliveryWriteConfiguration : IEntityTypeConfiguration<FertilizerWarehouseDelivery>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public FertilizerWarehouseDeliveryWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouseDelivery> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseDeliveryId(x));

            builder
                .Property(x => x.FertilizerId)
                .HasConversion(x => x.Value, x => new FertilizerId(x));

            builder
                .Property(x => x.FertilizerWarehouseStateId)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseStateId(x));

            builder
                .Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseDeliveryQuantity(x));

            builder
                .Property(x => x.Price)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseDeliveryPrice(x));

            builder
                .Property(x => x.RealizationDate)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseDeliveryRealizationDate(x));

            builder
                .HasOne(x => x.Fertilizer)
                .WithMany(x => x.FertilizerWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.FertilizerWarehouseState)
                .WithMany(x => x.FertilizerWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.FertilizerDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter((System.Linq.Expressions.Expression<Func<FertilizerWarehouseDelivery, bool>>)(x => x.TenantId == _context.TenantId.Value));

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("FertilizerWarehouseDeliveries");
        }
    }
}
