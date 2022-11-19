using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PesticideWarehouseStateReadConfiguration : IEntityTypeConfiguration<PesticideWarehouseStateReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public PesticideWarehouseStateReadConfiguration(ReadDbContext context)
        {
            _context = context;
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
                .HasQueryFilter(x => x.TenantId == _context.TenantId.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PesticideWarehouseStates");
        }
    }
}
