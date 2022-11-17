using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class FertilizerTypeWriteConfiguration : IEntityTypeConfiguration<FertilizerType>, IWriteConfiguration
    {
        private readonly Tenant _tenant;

        public FertilizerTypeWriteConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<FertilizerType> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerTypeId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new FertilizerTypeName(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new FertilizerTypeDescription(x));

            builder
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("FertilizerTypes");
        }
    }
}
