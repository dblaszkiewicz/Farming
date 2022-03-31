using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PlantWarehouseReadConfiguration : IEntityTypeConfiguration<PlantWarehouseReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PlantWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PlantWarehouses");
        }
    }
}
