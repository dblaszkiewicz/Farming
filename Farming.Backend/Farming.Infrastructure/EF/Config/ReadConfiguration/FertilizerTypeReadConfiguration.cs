using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class FertilizerTypeReadConfiguration : IEntityTypeConfiguration<FertilizerTypeReadModel>, IReadConfiguration
    {
        private readonly Tenant _tenant;

        public FertilizerTypeReadConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<FertilizerTypeReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.ToTable("FertilizerTypes");
        }
    }
}
