using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PesticideTypeReadConfiguration : IEntityTypeConfiguration<PesticideTypeReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideTypeReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("PesticideTypes");
        }
    }
}
