using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal class PlantWarehouseDeliveryReadConfiguration : IEntityTypeConfiguration<PlantWarehouseDeliveryReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PlantWarehouseDeliveryReadModel> builder)
        {
            builder.HasKey(x => x.Id);

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
