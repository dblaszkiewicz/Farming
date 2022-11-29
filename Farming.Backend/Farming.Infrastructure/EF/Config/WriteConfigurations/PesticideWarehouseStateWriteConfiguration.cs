using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PesticideWarehouseStateWriteConfiguration : IEntityTypeConfiguration<PesticideWarehouseState>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public PesticideWarehouseStateWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PesticideWarehouseState> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PesticideWarehouseStateId(x));

            builder
                .Property(x => x.PesticideId)
                .HasConversion(x => x.Value, x => new PesticideId(x));

            builder
                .Property(x => x.PesticideWarehouseId)
                .HasConversion(x => x.Value, x => new PesticideWarehouseId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new PesticideWarehouseQuantity(x));

            builder
                .HasOne(x => x.Pesticide)
                .WithMany(x => x.PesticideWarehouseStates)
                .OnDelete(DeleteBehavior.Restrict);
                

            builder
                .HasOne(x => x.PesticideWarehouse)
                .WithMany(x => x.States)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter((System.Linq.Expressions.Expression<Func<PesticideWarehouseState, bool>>)(x => x.TenantId == _context.TenantId.Value));

            builder.HasIndex(x => x.TenantId);

            builder.Property(x => x.Version).IsConcurrencyToken();

            builder.ToTable("PesticideWarehouseStates");
        }
    }
}
