using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class LandReadConfiguration : IEntityTypeConfiguration<LandReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<LandReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Lands");
        }
    }
}
