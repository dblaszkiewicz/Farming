using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class FertilizerWarehouseWriteConfiguration : IEntityTypeConfiguration<FertilizerWarehouse>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<FertilizerWarehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseId(x));

            builder.ToTable("FertilizerWarehouses");
        }
    }
}
