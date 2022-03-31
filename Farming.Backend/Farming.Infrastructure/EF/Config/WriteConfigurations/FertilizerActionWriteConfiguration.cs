using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class FertilizerActionWriteConfiguration : IEntityTypeConfiguration<FertilizerAction>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<FertilizerAction> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerActionId(x));

            builder
                .Property(x => x.FertilizerId)
                .HasConversion(x => x.Value, x => new FertilizerId(x));

            builder
                .Property(x => x.LandRealizationId)
                .HasConversion(x => x.Value, x => new LandRealizationId(x));

            builder
                .Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new FertilizerActionQuantity(x));

            builder
                .Property(x => x.RealizationDate)
                .HasConversion(x => x.Value, x => new FertilizerActionRealizationDate(x));

            builder
                .HasOne(x => x.Fertilizer)
                .WithMany(x => x.FertilizerActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.LandRealization)
                .WithMany(x => x.FertilizerActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.FertilizerActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("FertilzierActions");
        }
    }
}
