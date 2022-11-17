using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class LandRealizationWriteConfiguration : IEntityTypeConfiguration<LandRealization>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public LandRealizationWriteConfiguration(WriteDbContext context)
        {
            _context = context;
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
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("LandRealizations");
        }
    }
}
