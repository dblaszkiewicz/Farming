using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class FertilizerWriteConfiguration : IEntityTypeConfiguration<Fertilizer>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public FertilizerWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<Fertilizer> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerId(x));

            builder
                .Property(x => x.FertilizerTypeId)
                .HasConversion(x => x.Value, x => new FertilizerTypeId(x));

            builder
                .Property(x => x.RequiredAmountPerHectare)
                .HasConversion(x => x.Value, x => new FertilizerRequiredAmountPerHectare(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new FertilizerName(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new FertilizerDescription(x));

            builder
                .HasOne(x => x.FertilizerType)
                .WithMany(x => x.Fertilizers)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter((System.Linq.Expressions.Expression<Func<Fertilizer, bool>>)(x => x.TenantId == _context.TenantId.Value));

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Fertilizers");
        }
    }
}
