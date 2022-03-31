using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal class PesticideReadConfiguration : IEntityTypeConfiguration<PesticideReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.PesticideType)
                .WithMany(x => x.Pesticides)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Pesticides");
        }
    }
}
