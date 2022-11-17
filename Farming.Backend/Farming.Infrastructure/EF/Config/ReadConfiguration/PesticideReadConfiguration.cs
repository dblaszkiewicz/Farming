using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal class PesticideReadConfiguration : IEntityTypeConfiguration<PesticideReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public PesticideReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PesticideReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.PesticideType)
                .WithMany(x => x.Pesticides)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Pesticides");
        }
    }
}
