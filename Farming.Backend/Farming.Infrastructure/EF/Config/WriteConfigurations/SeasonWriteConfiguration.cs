using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Season;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class SeasonWriteConfiguration : IEntityTypeConfiguration<Season>, IWriteConfiguration
    {
        private readonly Tenant _tenant;

        public SeasonWriteConfiguration(Tenant tenant)
        {
            _tenant = tenant;
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
                .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.ToTable("Seasons");
        }
    }
}
