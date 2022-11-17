using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class LandRealizationReadConfiguration : IEntityTypeConfiguration<LandRealizationReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public LandRealizationReadConfiguration(ReadDbContext context)
        {
            _context = context;
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
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("LandRealizations");
        }
    }
}
