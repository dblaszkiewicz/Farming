using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Land;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class LandWriteConfiguration : IEntityTypeConfiguration<Land>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public LandWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<Land> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new LandId(x));

            builder
                .Property(x => x.LandCLass)
                .HasConversion(x => x.Value, x => new LandClass(x));

            builder
                .Property(x => x.Status)
                .HasConversion(x => x.Value, x => new LandStatus(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new LandName(x));

            builder
                .Property(x => x.Area)
                .HasConversion(x => x.Value, x => new LandArea(x));

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Lands");
        }
    }
}
