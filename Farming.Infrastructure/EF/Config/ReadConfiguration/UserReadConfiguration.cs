using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class UserReadConfiguration : IEntityTypeConfiguration<UserReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Users");
        }
    }
}
