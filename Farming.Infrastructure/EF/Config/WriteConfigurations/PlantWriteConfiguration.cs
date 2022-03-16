using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    public class PlantWriteConfiguration : IEntityTypeConfiguration<Plant>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PlantId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new PlantName(x));

            builder
                .Property(x => x.RequiredAmountPerHectare)
                .HasConversion(x => x.Value, x => new PlantRequiredAmountPerHectare(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new PlantDescription(x));

            builder.ToTable("Plants");
        }
    }
}
