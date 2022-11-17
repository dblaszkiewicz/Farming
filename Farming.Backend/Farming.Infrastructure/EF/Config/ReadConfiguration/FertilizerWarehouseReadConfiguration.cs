using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class FertilizerWarehouseReadConfiguration : IEntityTypeConfiguration<FertilizerWarehouseReadModel>, IReadConfiguration
    {
        private readonly Tenant _tenant;

        public FertilizerWarehouseReadConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }
        public void Configure(EntityTypeBuilder<FertilizerWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.ToTable("FertilizerWarehouses");
        }
    }
}
