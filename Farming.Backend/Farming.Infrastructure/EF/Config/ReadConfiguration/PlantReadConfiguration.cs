using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PlantReadConfiguration : IEntityTypeConfiguration<PlantReadModel>, IReadConfiguration
    {
        private readonly Tenant _tenant;

        public PlantReadConfiguration(Tenant tenant)
        {
            _tenant = tenant;
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
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Plants");
        }
    }
}
