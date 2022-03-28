using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class FertilizerReadConfiguration : IEntityTypeConfiguration<FertilizerReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<FertilizerReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.SuitablePlants)
                .WithMany(x => x.SuitableFertilizers);

            builder
                .HasOne(x => x.FertilizerType)
                .WithMany(x => x.Fertilizers)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Fertilizers");
        }
    }
}
