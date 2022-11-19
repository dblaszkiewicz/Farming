using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.User;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class UserWriteConfiguration : IEntityTypeConfiguration<User>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public UserWriteConfiguration(WriteDbContext context)
        {
            _context = context;
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

            builder
                .HasQueryFilter((System.Linq.Expressions.Expression<Func<User, bool>>)(x => x.TenantId == _context.TenantId.Value));

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Users");
        }
    }
}
