using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.User;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class UserWriteConfiguration : IEntityTypeConfiguration<User>, IWriteConfiguration
    {
        private readonly Tenant _tenant;

        public UserWriteConfiguration(Tenant tenant)
        {
            _tenant = tenant;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder
                .Property(x => x.Login)
                .HasConversion(x => x.Value, x => new UserLogin(x));

            builder
                .Property(x => x.Password)
                .HasConversion(x => x.Value, x => new UserPassword(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new UserName(x));

            builder
                .Property(x => x.Active)
                .HasConversion(x => x.Value, x => new UserActive(x));

            builder
                .Property(x => x.IsAdmin)
                .HasConversion(x => x.Value, x => new UserIsAdmin(x));

            builder
                .Property(x => x.Created)
                .HasConversion(x => x.Value, x => new UserCreated(x));

            //builder
            //    .HasQueryFilter(x => x.TenantId == _tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Users");
        }
    }
}
