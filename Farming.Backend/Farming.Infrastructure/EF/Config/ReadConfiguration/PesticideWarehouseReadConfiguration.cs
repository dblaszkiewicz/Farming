using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PesticideWarehouseReadConfiguration : IEntityTypeConfiguration<PesticideWarehouseReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PesticideWarehouses");
        }
    }
}
