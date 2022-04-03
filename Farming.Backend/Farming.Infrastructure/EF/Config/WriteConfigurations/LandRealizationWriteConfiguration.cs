using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Season;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class LandRealizationWriteConfiguration : IEntityTypeConfiguration<LandRealization>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<LandRealization> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new LandRealizationId(x));

            builder
                .Property(x => x.LandId)
                .HasConversion(x => x.Value, x => new LandId(x));

            builder
                .Property(x => x.SeasonId)
                .HasConversion(x => x.Value, x => new SeasonId(x));

            builder
                .HasOne(x => x.Land)
                .WithMany(x => x.LandRealizations)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Season)
                .WithMany(x => x.LandRealizations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("LandRealizations");
        }
    }
}
