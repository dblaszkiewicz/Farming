using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal class PesticideActionReadConfiguration : IEntityTypeConfiguration<PesticideActionReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideActionReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Pesticide)
                .WithMany(x => x.PesticideActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.LandRealization)
                .WithMany(x => x.PesticideActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.PesticideActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("PesticideActions");
        }
    }
}
