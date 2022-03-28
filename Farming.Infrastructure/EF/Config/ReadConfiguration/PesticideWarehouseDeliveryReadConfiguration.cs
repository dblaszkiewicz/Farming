using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PesticideWarehouseDeliveryReadConfiguration : IEntityTypeConfiguration<PesticideWarehouseDeliveryReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideWarehouseDeliveryReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Pesticide)
                .WithMany(x => x.PesticideWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.PesticideDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.PesticideWarehouseState)
                .WithMany(x => x.PesticideWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("PesticideWarehouseDeliveries");
        }
    }
}
