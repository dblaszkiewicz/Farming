using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PesticideWarehouseStateReadConfiguration : IEntityTypeConfiguration<PesticideWarehouseStateReadModel>, IReadConfiguration
    {
        private readonly Tenant _tenant;

        public PesticideWarehouseStateReadConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<PesticideWarehouseStateReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.Pesticide)
                .WithMany(x => x.PesticideWarehouseStates)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.PesticideWarehouse)
                .WithMany(x => x.States)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PesticideWarehouseStates");
        }
    }
}
