using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class UserReadConfiguration : IEntityTypeConfiguration<UserReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public UserReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasQueryFilter(x => x.TenantId == _context.TenantId.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("Users");
        }
    }
}
