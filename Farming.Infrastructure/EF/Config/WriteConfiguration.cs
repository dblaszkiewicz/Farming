using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<User>, IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .HasConversion(id => id.Value, id => new UserId(id));

            builder
                .Property(u => u.Login)
                .HasConversion(login => login.Value, login => new UserLogin(login));

            builder
                .Property(u => u.FirstName)
                .HasConversion(firstName => firstName.Value, firstName => new UserFirstName(firstName));

            builder
                .Property(u => u.LastName)
                .HasConversion(lastName => lastName.Value, lastName => new UserLastName(lastName));

            builder
                .Property(u => u.Active)
                .HasConversion(active => active.Value, active => new UserActive(active));

            builder.ToTable("Users");
        }

        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasConversion(name => name.Value, name => new PlantName(name));

            builder
                .Property(p => p.Description)
                .HasConversion(description => description.Value, description => new PlantDescription(description));

            builder
                .Property(p => p.RequiredAmountPerHectare)
                .HasConversion(requiredAmount => requiredAmount.Value, requiredAmount => new PlantRequiredAmountPerHectare(requiredAmount));

            builder.ToTable("Plants");
        }
    }
}
