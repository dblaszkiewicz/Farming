using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class UserReadConfiguration : IEntityTypeConfiguration<UserReadModel>, IReadConfiguration
    {
        private readonly Tenant _tenant;

        public UserReadConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            //builder
            //    .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.ToTable("Users");
        }
    }
}
