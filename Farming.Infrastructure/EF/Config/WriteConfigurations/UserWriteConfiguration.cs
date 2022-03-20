using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class UserWriteConfiguration : IEntityTypeConfiguration<User>, IWriteConfiguration
    {
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
                .Property(x => x.FirstName)
                .HasConversion(x => x.Value, x => new UserFirstName(x));

            builder
                .Property(x => x.LastName)
                .HasConversion(x => x.Value, x => new UserLastName(x));

            builder
                .Property(x => x.Active)
                .HasConversion(x => x.Value, x => new UserActive(x));

            builder.ToTable("Users");
        }
    }
}
