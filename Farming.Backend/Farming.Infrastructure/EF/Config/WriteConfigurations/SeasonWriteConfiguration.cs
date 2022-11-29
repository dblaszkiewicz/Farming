using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Season;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class SeasonWriteConfiguration : IEntityTypeConfiguration<Season>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public SeasonWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new SeasonId(x));

            builder
                .Property(x => x.Active)
                .HasConversion(x => x.Value, x => new SeasonActive(x));

            builder
                .Property(x => x.StartDate)
                .HasConversion(x => x.Value, x => new SeasonStartDate(x));

            builder
                .HasQueryFilter((System.Linq.Expressions.Expression<Func<Season, bool>>)(x => x.TenantId == _context.TenantId.Value));

            builder.HasIndex(x => x.TenantId);

            builder.Property(x => x.Version).IsConcurrencyToken();

            builder.ToTable("Seasons");
        }
    }
}
