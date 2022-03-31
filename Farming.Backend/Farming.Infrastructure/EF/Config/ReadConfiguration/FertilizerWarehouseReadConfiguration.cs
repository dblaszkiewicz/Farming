using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class FertilizerWarehouseReadConfiguration : IEntityTypeConfiguration<FertilizerWarehouseReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<FertilizerWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("FertilizerWarehouses");
        }
    }
}
