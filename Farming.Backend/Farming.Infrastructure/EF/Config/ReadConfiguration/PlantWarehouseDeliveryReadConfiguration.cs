using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal class PlantWarehouseDeliveryReadConfiguration : IEntityTypeConfiguration<PlantWarehouseDeliveryReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public PlantWarehouseDeliveryReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

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

            builder
                .HasQueryFilter(x => x.TenantId == _context.TenantId.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PlantWarehouseDeliveries");
        }
    }
}
