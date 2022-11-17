using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PlantActionWriteConfiguration : IEntityTypeConfiguration<PlantAction>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public PlantActionWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PlantAction> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PlantActionId(x));

            builder
                .Property(x => x.PlantId)
                .HasConversion(x => x.Value, x => new PlantId(x));

            builder
                .Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder
                .Property(x => x.LandRealizationId)
                .HasConversion(x => x.Value, x => new LandRealizationId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new PlantActionQuantity(x));

            builder
                .Property(x => x.RealizationDate)
                .HasConversion(x => x.Value, x => new PlantActionRealizationDate(x));

            builder
                .HasOne(x => x.Plant)
                .WithMany(x => x.PlantActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.PlantActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.LandRealization)
                .WithMany(x => x.PlantActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PlantActions");
        }
    }
}
