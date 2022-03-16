using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Land;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal class LandWriteConfiguration : IEntityTypeConfiguration<Land>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<Land> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new LandId(x));

            builder
                .Property(x => x.Class)
                .HasConversion(x => x.Value, x => new LandClass(x));

            builder
                .Property(x => x.Status)
                .HasConversion(x => x.Value, x => new LandStatus(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new LandName(x));

            builder
                .Property(x => x.Area)
                .HasConversion(x => x.Value, x => new LandArea(x));

            builder.ToTable("Lands");
        }
    }
}
