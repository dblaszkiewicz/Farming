using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PesticideWarehouseReadConfiguration : IEntityTypeConfiguration<PesticideWarehouseReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public PesticideWarehouseReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PesticideWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasQueryFilter(x => x.TenantId == _context.TenantId.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PesticideWarehouses");
        }
    }
}
