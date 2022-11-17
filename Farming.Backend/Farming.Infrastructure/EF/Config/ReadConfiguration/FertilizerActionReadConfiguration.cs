using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class FertilizerActionReadConfiguration : IEntityTypeConfiguration<FertilizerActionReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public FertilizerActionReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<FertilizerActionReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Fertilizer)
                .WithMany(x => x.FertilizerActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.LandRealization)
                .WithMany(x => x.FertilizerActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.FertilizerActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("FertilzierActions");
        }
    }
}
