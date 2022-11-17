using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal class PesticideActionReadConfiguration : IEntityTypeConfiguration<PesticideActionReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public PesticideActionReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

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

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PesticideActions");
        }
    }
}
