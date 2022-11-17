using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class FertilizerTypeWriteConfiguration : IEntityTypeConfiguration<FertilizerType>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public FertilizerTypeWriteConfiguration(WriteDbContext context)
        {
            _context = context;
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
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("FertilizerTypes");
        }
    }
}
