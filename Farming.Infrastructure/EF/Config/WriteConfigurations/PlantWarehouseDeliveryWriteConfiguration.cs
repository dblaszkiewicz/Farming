using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal class PlantWarehouseDeliveryWriteConfiguration : IEntityTypeConfiguration<PlantWarehouseDelivery>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<PlantWarehouseDelivery> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PlantWarehouseDeliveryId(x));

            builder
                .Property(x => x.PlantId)
                .HasConversion(x => x.Value, x => new PlantId(x));

            builder
                .Property(x => x.PlantWarehouseStateId)
                .HasConversion(x => x.Value, x => new PlantWarehouseStateId(x));

            builder
                .Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new PlantWarehouseDeliveryQuantity(x));

            builder
                .Property(x => x.Price)
                .HasConversion(x => x.Value, x => new PlantWarehouseDeliveryPrice(x));

            builder
                .Property(x => x.RealizationDate)
                .HasConversion(x => x.Value, x => new PlantWarehouseDeliveryRealizationDate(x));

            builder
                .HasOne(x => x.Plant)
                .WithMany(x => x.PlantWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.PlantDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.PlantWarehouseState)
                .WithMany(x => x.PlantWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("PlantWarehouseDeliveries");
        }
    }
}
