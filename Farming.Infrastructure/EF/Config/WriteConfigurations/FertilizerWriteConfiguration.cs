using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    public class FertilizerWriteConfiguration : IEntityTypeConfiguration<Fertilizer>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<Fertilizer> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerId(x));

            builder
                .Property(x => x.FertilizerTypeId)
                .HasConversion(x => x.Value, x => new FertilizerTypeId(x));

            builder
                .Property(x => x.FertilizerRequiredAmountPerHectare)
                .HasConversion(x => x.Value, x => new FertilizerRequiredAmountPerHectare(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new FertilizerName(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new FertilizerDescription(x));

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
