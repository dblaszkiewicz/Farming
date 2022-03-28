using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PlantReadConfiguration : IEntityTypeConfiguration<PlantReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PlantReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Plants");
        }
    }
}
