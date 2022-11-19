using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class FertilizerReadConfiguration : IEntityTypeConfiguration<FertilizerReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public FertilizerReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<FertilizerReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.FertilizerType)
                .WithMany(x => x.Fertilizers)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _context.TenantId.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Fertilizers");
        }
    }
}
