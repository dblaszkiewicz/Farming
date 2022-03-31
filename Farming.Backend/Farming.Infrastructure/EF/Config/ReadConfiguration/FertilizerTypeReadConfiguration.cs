using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class FertilizerTypeReadConfiguration : IEntityTypeConfiguration<FertilizerTypeReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<FertilizerTypeReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("FertilizerTypes");
        }
    }
}
