using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PlantReadConfiguration : IEntityTypeConfiguration<PlantReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public PlantReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PlantReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.SuitablePesticides)
                .WithMany(x => x.SuitablePlants)
                .UsingEntity(x => x.ToTable("PlantPesticides"));

            builder
                .HasMany(x => x.SuitableFertilizers)
                .WithMany(x => x.SuitablePlants)
                .UsingEntity(x => x.ToTable("PlantFertilizers"));

            builder
                .HasQueryFilter(x => x.TenantId == _context.TenantId.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Plants");
        }
    }
}
