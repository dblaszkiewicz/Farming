using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class SeasonReadConfiguration : IEntityTypeConfiguration<SeasonReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public SeasonReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<SeasonReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Seasons");
        }
    }
}
