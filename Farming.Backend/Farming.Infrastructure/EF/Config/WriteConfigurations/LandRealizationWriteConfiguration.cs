using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class LandRealizationWriteConfiguration : IEntityTypeConfiguration<LandRealization>, IWriteConfiguration
    {
        private readonly Tenant _tenant;

        public LandRealizationWriteConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<LandRealization> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new LandRealizationId(x));

            builder
                .Property(x => x.LandId)
                .HasConversion(x => x.Value, x => new LandId(x));

            builder
                .Property(x => x.SeasonId)
                .HasConversion(x => x.Value, x => new SeasonId(x));

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

            builder.ToTable("LandRealizations");
        }
    }
}
