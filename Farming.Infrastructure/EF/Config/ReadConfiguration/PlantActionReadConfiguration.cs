using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PlantActionReadConfiguration : IEntityTypeConfiguration<PlantActionReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PlantActionReadModel> builder)
        {
            builder.HasKey(x => x.Id);
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

            builder.ToTable("PlantActions");
        }
    }
}
