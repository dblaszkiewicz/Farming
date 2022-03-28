using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class SeasonReadConfiguration : IEntityTypeConfiguration<SeasonReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<SeasonReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Seasons");
        }
    }
}
