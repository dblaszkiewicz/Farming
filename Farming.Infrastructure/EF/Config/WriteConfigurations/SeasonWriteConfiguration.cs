using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Season;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal class SeasonWriteConfiguration : IEntityTypeConfiguration<Season>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new SeasonId(x));

            builder
                .Property(x => x.Active)
                .HasConversion(x => x.Value, x => new SeasonActive(x));

            builder
                .Property(x => x.StartDate)
                .HasConversion(x => x.Value, x => new SeasonStartDate(x));

            builder
                .Property(x => x.EndDate)
                .HasConversion(x => x.Value, x => new SeasonEndDate(x));

            builder.ToTable("Seasons");
        }
    }
}
