using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class LandRealizationReadConfiguration : IEntityTypeConfiguration<LandRealizationReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<LandRealizationReadModel> builder)
        {
            builder.HasKey(x => x.Id);

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
