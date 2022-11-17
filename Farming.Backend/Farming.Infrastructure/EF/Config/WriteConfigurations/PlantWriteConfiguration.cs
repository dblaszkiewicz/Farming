using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PlantWriteConfiguration : IEntityTypeConfiguration<Plant>, IWriteConfiguration
    {
        private readonly Tenant _tenant;

        public PlantWriteConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PlantId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new PlantName(x));

            builder
                .Property(x => x.RequiredAmountPerHectare)
                .HasConversion(x => x.Value, x => new PlantRequiredAmountPerHectare(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new PlantDescription(x));

            builder
                .Property(x => x.Unit)
                .HasConversion(x => x.Value, x => new PlantUnit(x));

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

            builder.ToTable("Plants");
        }
    }
}
