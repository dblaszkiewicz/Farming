using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class LandRealizationReadConfiguration : IEntityTypeConfiguration<LandRealizationReadModel>, IReadConfiguration
    {
        private readonly Tenant _tenant;

        public LandRealizationReadConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<LandRealizationReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Land)
                .WithMany(x => x.LandRealizations)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Season)
                .WithMany(x => x.LandRealizations)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("LandRealizations");
        }
    }
}
