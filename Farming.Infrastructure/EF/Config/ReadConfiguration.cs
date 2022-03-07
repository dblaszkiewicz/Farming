using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<UserReadModel>, IEntityTypeConfiguration<PlantReadModel>
    {
        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable("Users");
        }

        public void Configure(EntityTypeBuilder<PlantReadModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Plants");
        }
    }
}
